using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CdHotelManage.Web.Admin.ShiftExc
{
    public partial class HandOver : BasePageVaile
    {
        string uid = "1";
        int banc = 1; 
        public double Sum = 0;
        BLL.goods_account gaBll = new BLL.goods_account();
        protected string name = string.Empty;
        protected string banchi = string.Empty;
        BLL.Shift_Exc bllsf = new BLL.Shift_Exc();

        public override void SonLoad()
        {
            if (!IsPostBack)
            {
                string day = string.Empty;
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
                else {
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
                else {
                    uid = UserNow.UserID;
                }
                if (Request["banc"] != null)
                {
                    banc = Convert.ToInt32(Request["banc"].ToString());
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript'>alert('没有班次');window.location='../index.aspx';</script>");
                }

                name = new BLL.AccountsUsersBLL().GetModel(uid).UserName;
                banchi = new BLL.Shift().GetModel(Convert.ToInt32(banc)).shfit_name;

                //根据用户登录ID 查询
                //string strWhere = Session["UserID"].ToString();
                //先写死测试
                GridView1.DataSource = bllsf.GeMethPaySumMoney(" where a.UserId='" + uid + "' and a.ga_price!='0' and shift_id=" + banc + " and DATEDIFF(second ,'" + day + "',ga_date)>0 and DATEDIFF(second ,'" + day + "',ga_date)<86400");
                GridView1.DataBind();

                DataSet ds = bllsf.GeMethPaySumMoney(" where a.UserId='" + uid + "' and a.ga_price!='0' and shift_id=" + banc);

                foreach (DataRow row in ds.Tables[0].Rows)
                {

                    Sum += Convert.ToDouble(row["ga_sum_price"].ToString());
                    Session["Sum"] = Sum;
                }
            }
        }
    }
}