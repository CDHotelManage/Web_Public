using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CdHotelManage.Web.Admin.ShiftExc
{
    public partial class DailySheetMouth : BasePageVaile
    {
        BLL.occu_infor blloi = new BLL.occu_infor();
        protected System.Text.StringBuilder sbtext = new System.Text.StringBuilder();
        string day = string.Empty;
        string dayend = string.Empty;
        int sumroomnum = 0;
        protected System.Text.StringBuilder sbtr = new System.Text.StringBuilder();
       

        protected void btnQuery_Click(object s, EventArgs e)
        {
            day = Convert.ToDateTime(time_from.Value).ToString("yyyy-MM-dd");
            dayend = Convert.ToDateTime(time_fromend.Value).AddMonths(1).ToString("yyyy-MM-dd");
            sbtr.Append(Convert.ToDateTime(day).ToString("yyyy-MM") + "到" + Convert.ToDateTime(dayend).AddMonths(-1).ToString("yyyy-MM"));
            Bind(day, dayend);
        }
        BLL.goods_account bllga = new BLL.goods_account();
        /// <summary>
        /// 生成营业报表
        /// </summary>
        private void Bind(string day,string end)
        {
            //List<Model.occu_infor> listoi = blloi.GetDaySheet("CONVERT(varchar(100), oi.occ_time,23)>='"+day+"' and CONVERT(varchar(100), oi.occ_time,23)<='"+dayend+"'");
            //if (listoi != null)
            //{
            //    foreach (Model.occu_infor model in listoi)
            //    {
            //        sbtext.Append("<tr class=\"sj\"><td><a href='DailySheet.aspx?day=" + model.occ_time.ToString("yyyy-MM-dd") + "'>" + model.occ_time.ToString("yyyy-MM-dd") + "</a></td><td>" + model.room_number + "</td><td>" + model.occ_name + "</td><td>" + model.Real_mode_mode.real_mode_name + "</td><td>" + GetRoomStatu(model.state_id) + "</td><td>" + model.real_price + "</td><td>" + GetRoomStatu(model) + "</td><td>" + model.occ_time + "</td><td>" + model.depar_time + "</td><td class=\"ff\">" + GetRoomStatu(model) + "</td><td class=\"fy\">" + GetGoodsFh(model) + "</td><td><span class=\"hj\"></span></td></tr>");
            //    }
            //}
            DataSet ds = blloi.GetDaySheetbymouth("CONVERT(varchar(100), oi.occ_time,23)>='" + day + "' and CONVERT(varchar(100), oi.occ_time,23)<='" + dayend + "' group by CONVERT(varchar(100), oi.occ_time,23)");
            if (ds != null) {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    sbtext.Append("<tr class=\"sj\"><td><a onclick=\"ShowTab('" + dr[0].ToString() + "日报表','/Admin/ShiftExc/DailySheet.aspx?day=" + dr[0].ToString() + "')\" >" + dr[0].ToString() + "</a></td><td class=\"rz1\">" + dr[1].ToString() + "</td><td class=\"zf1\">" + sumroomnum + "</td><td class=\"rzn1\">" + Gn(sumroomnum.ToString(), dr[1].ToString()) + "</td><td class=\"pj1\">" + Convert.ToDecimal(dr[2].ToString()).ToString("0.##") + "</td><td class=\"fz\">" + Convert.ToDecimal(dr[3].ToString()).ToString("0.##") + "</td><td class=\"xf\">" + GetFy(dr[0].ToString()) + "</td><td class=\"xj\"></td></tr>");
                }
              
            }

        }

        BLL.room_number bllrn = new BLL.room_number();
        /// <summary>
        /// 计算入住率
        /// </summary>
        /// <returns></returns>
        private string Gn(string sum, string oksum)
        {
            double d = (Convert.ToDouble(oksum) / Convert.ToDouble(sum)) * 100;
            return d.ToString() + "%";
        }
        /// <summary>
        /// 获得一天中所有的费用
        /// </summary>
        /// <returns></returns>
        private string GetFy(string days)
        {string s=bllga.GetAllByday("CONVERT(varchar(100), ga_date,23)='" + days + "'");
            if ( s== "") {
                return "0.00";
            }
            return s;
        }
        

        /// <summary>
        /// 获得一个房间的商品费用
        /// </summary>
        /// <param name="statuid"></param>
        /// <returns></returns>
        public string GetGoodsFh(Model.occu_infor model)
        {
            DataTable dt = bllga.GetGoodsFh(model.room_number, "and CONVERT(varchar(100), ga.ga_date,23)='" + day + "'");
            if (dt != null)
            {
                string s = dt.Rows[0][0].ToString();
                if (s != "")
                {
                    return dt.Rows[0][0].ToString();
                }
                else
                {
                    return "0";
                }
            }
            return "0";
        }

        /// <summary>
        /// 获得实际费用
        /// </summary>
        /// <param name="statuid"></param>
        /// <returns></returns>
        public string GetRoomStatu(Model.occu_infor model)
        {
            double price = Convert.ToDouble(model.real_price);
            double zk = Convert.ToDouble(model.Hourse_scheme_model.hs_Discount) * Convert.ToDouble(0.1);
            return (price * zk).ToString();
        }

        /// <summary>
        /// 获得状态
        /// </summary>
        /// <param name="statuid"></param>
        /// <returns></returns>
        public string GetRoomStatu(int statuid)
        {
            switch (statuid)
            {
                case 0:

                    return "正常";
                case 1:
                    return "离开";
            }
            return "";
        }

        public override void SonLoad()
        {
            DataSet ds = bllrn.GetAllList(); ;
            if (ds != null)
            {
                sumroomnum = ds.Tables[0].Rows.Count;
            }
            if (!IsPostBack)
            {
                time_from.Value = DateTime.Now.ToString("yyyy-MM");
                time_fromend.Value = DateTime.Now.ToString("yyyy-MM");
                if (Request.QueryString["mouth"] != null)
                {

                    day = Convert.ToDateTime(Request.QueryString["mouth"]).ToString("yyyy-MM-dd");
                }
                else
                {
                    day = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM")).ToString("yyyy-MM-dd");
                }

                if (Request.QueryString["mouthend"] != null)
                {

                    dayend = Convert.ToDateTime(Request.QueryString["mouthend"]).AddHours(1).ToString("yyyy-MM-dd");
                }
                else
                {
                    dayend = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM")).AddMonths(1).ToString("yyyy-MM-dd");
                }
                sbtr.Append(Convert.ToDateTime(day).ToString("yyyy-MM"));
                Bind(day, dayend);
            }
        }
    }
}