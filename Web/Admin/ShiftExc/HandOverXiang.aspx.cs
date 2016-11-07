using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CdHotelManage.Web.Admin.ShiftExc
{
    public partial class HandOverXiang : BasePageVaile
    {
        string uid = "1";
        int banc = 1;
        protected System.Text.StringBuilder sb = new System.Text.StringBuilder();
        protected System.Text.StringBuilder sbtext = new System.Text.StringBuilder();
        BLL.goods_account bllga = new BLL.goods_account();
        BLL.Shift_Exc bllse = new BLL.Shift_Exc();
        protected string name = string.Empty;
        protected string banchi = string.Empty;
        BLL.meth_pay bllmp = new BLL.meth_pay();
        

        /// <summary>
        /// 获得不同收费方式所产生所有的金额
        /// </summary>
        private void Bind3() {
            DataSet ds = bllse.GetAllBydays("UserId=" + uid + " and  shift_id=" + banc + " and ga_price!='0' and DATEDIFF(second ,'" + day + "',ga_date)>0 and DATEDIFF(second ,'" + day + "',ga_date)<86400   group by ga_zffs_id");
            if (ds != null) {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        sb.Append("<tr><td colspan=\"6\" style=\"text-indent:80px;\">" + GetRealTypeName(dr[1]) + ":" + dr[0] + "元</td></tr>");
                    }
            }
        }

        private void Bind() {
            double zj=0;
            string types = bllse.GeMethPayType("UserId=" + uid + " and shift_id=" + banc + " and ga_price!='0' and DATEDIFF(second ,'" + day + "',ga_date)>0 and DATEDIFF(second ,'" + day + "',ga_date)<86400  and ga_Type not in(6,1) group by ga_zffs_id");
            if (types != "")
            {
                types = types.Remove(types.Length - 1, 1);
            
            string[] typestr = types.Split(new char[1] { ',' });
            foreach (string s in typestr)
            {
                sb.Append("<tr><td>" + GetRealTypeName(s) + "</td><td colspan=\"6\"></td></tr>");
                sb.Append("<tr><td>房间号</td><td>帐号</td><td>收退款类型</td><td>金额</td><td>发生时间</td><td>单据号</td><td>备注</td></tr>");
                List<Model.Shift_Exc> listga = bllse.GetModelList("shift_id=" + banc + " and ga_price!='0'  and  ga_Type not in(6) and ga_zffs_id=" + s);
                double sum = 0;
                if (listga.Count >= 1)
                {

                    foreach (Model.Shift_Exc modelga in listga)
                    {
                        sb.Append("<tr><td>" + modelga.ga_roomNumber + "</td><td>" + modelga.ga_number + "</td><td>" + modelga.ga_name + "</td><td>" + modelga.ga_price + "</td><td>" + modelga.ga_date + "</td><td>" + modelga.ga_number + "</td><td>" + modelga.Remark + "</td></tr>");
                        sum += (double)modelga.ga_price;
                        zj+=(double)modelga.ga_price;
                    }
                }
                sb.Append("<tr class=\"xj\"><td colspan=\"7\" style=\"text-indent:100px;\">" + GetRealTypeName(s) + " 小计 " + sum + "元</td></tr>");
            }
            sb.Append("<tr class=\"shj\"><td colspan=\"7\" style=\"text-indent:80px;\">收款 合计:" + zj + "元</td></tr>");
            }
        }


        private void Bind1()
        {
            double zj = 0;
            string types = bllse.GeMethPayType("UserId=" + uid + " and shift_id=" + banc + " and ga_Type in(6) and DATEDIFF(second ,'" + day + "',ga_date)>0 and DATEDIFF(second ,'" + day + "',ga_date)<86400   group by ga_zffs_id");
            if (types != "")
            {
                types = types.Remove(types.Length - 1, 1);

                string[] typestr = types.Split(new char[1] { ',' });
                foreach (string s in typestr)
                {
                    sb.Append("<tr><td>" + GetRealTypeName(s) + "</td><td colspan=\"6\"></td></tr>");
                    sb.Append("<tr><td>房间号</td><td>帐号</td><td>收退款类型</td><td>金额</td><td>发生时间</td><td>单据号</td><td>备注</td></tr>");
                    List<Model.Shift_Exc> listga = bllse.GetModelList("shift_id=" + banc + " and ga_Type in(6) and ga_zffs_id=" + s);
                    double sum = 0;
                    if (listga.Count >= 1)
                    {

                        foreach (Model.Shift_Exc modelga in listga)
                        {
                            sb.Append("<tr><td>" + modelga.ga_roomNumber + "</td><td>" + modelga.ga_number + "</td><td>" + modelga.ga_name + "</td><td>" + modelga.ga_price + "</td><td>" + modelga.ga_date + "</td><td>" + modelga.ga_number + "</td><td>" + modelga.Remark + "</td></tr>");
                            sum += (double)modelga.ga_price;
                            zj += (double)modelga.ga_price;
                        }
                    }
                    sb.Append("<tr class=\"xj\"><td colspan=\"7\" style=\"text-indent:100px;\">" + GetRealTypeName(s) + " 小计 " + sum + "元</td></tr>");
                }
                sb.Append("<tr class=\"shj\"><td colspan=\"7\" style=\"text-indent:80px;\">退款 合计:" + zj + "元</td></tr>");
            }
            else { 
               
            }
        }

        //获取支付方式中文名称
        public string GetRealTypeName(object id)
        {
            if (id.ToString() == "")
            {
                return "";
            }
            BLL.meth_pay mpBll = new BLL.meth_pay();
            Model.meth_pay model = mpBll.GetModel(Convert.ToInt32(id.ToString()));
            return model.meth_pay_name;


        }
        protected string day = string.Empty;
        public override void SonLoad()
        {
            
            if (Request["dtime"] != null)
            {
                DateTime daytime = Convert.ToDateTime(Request["dtime"]);
                TimeSpan time = DateTime.Now - Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")).Add(SysModel.YsTime);
                day = Convert.ToDateTime(daytime).ToString("yyyy-MM-dd");
                day = Convert.ToDateTime(day).Add(SysModel.YsTime).ToString();
                if (time.TotalSeconds < 0)
                {
                    day = Convert.ToDateTime(day).AddDays(-1).ToString();
                }
            }
            else
            {
                TimeSpan time = DateTime.Now - Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")).Add(SysModel.YsTime);
                day = DateTime.Now.ToString("yyyy-MM-dd");
                day = Convert.ToDateTime(day).Add(SysModel.YsTime).ToString();
                if (time.TotalSeconds < 0)
                {
                    day = Convert.ToDateTime(day).AddDays(-1).ToString();
                }
            }
            if (Request["uid"] != null)
            {
                uid = Request["uid"].ToString();
            }
            else
            {
                uid = UserNow.UserID;
            }
            if (Request["banc"] != null)
            {
                banc = Convert.ToInt32(Request["banc"]);
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript'>alert('没有班次');window.location='../index.aspx';</script>");
            }
            Bind();
            Bind1();
            Bind3();
            name = new BLL.AccountsUsersBLL().GetModel(uid.ToString()).UserName;
            banchi = new BLL.Shift().GetModel(Convert.ToInt32(banc)).shfit_name;
        }
    }
}