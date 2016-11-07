using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CdHotelManage.Web.Admin.ShiftExc
{
    public partial class DailySheet :BasePageVaile
    {
        BLL.occu_infor blloi = new BLL.occu_infor();
        protected System.Text.StringBuilder sbtext = new System.Text.StringBuilder();
        protected string day = string.Empty;
       

        protected void btnQuery_Click(object s, EventArgs e)
        {
            TimeSpan time = DateTime.Now - Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")).Add(SysModel.YsTime);
            day = Convert.ToDateTime(time_from.Value).ToString("yyyy-MM-dd");
            day = Convert.ToDateTime(day).Add(SysModel.YsTime).ToString();
            if (time.TotalSeconds < 0) {
                day = Convert.ToDateTime(day).AddDays(-1).ToString();
            }
            Bind(day);
        }

        /// <summary>
        /// 生成营业报表
        /// </summary>
        private void Bind(string day) {
            List<Model.occu_infor> listoi = blloi.GetDaySheet(day);
            if (listoi != null)
            {
                foreach (Model.occu_infor model in listoi)
                {
                    sbtext.Append("<tr class=\"sj\"><td>" + model.room_number + "</td><td>" + model.occ_name + "</td><td>" + model.Real_mode_mode.real_mode_name + "</td><td>" + GetRoomStatu(model.state_id) + "</td><td>" + GetRoomStatu(model) + "</td><td>" + model.real_price.ToString("0.##") + "</td><td>" + model.occ_time + "</td><td>" + model.depar_time + "</td><td class=\"ff\">" + GetGoodsFF(model) + "</td><td class=\"fy\">" + GetGoodsFh(model) + "</td><td><span class=\"hj\"></span></td></tr>");
                }
            }
        }

        BLL.goods_account bllga = new BLL.goods_account();
        /// <summary>
        /// 获得一个房间的商品费用
        /// </summary>
        /// <param name="statuid"></param>
        /// <returns></returns>
        public string GetGoodsFh(Model.occu_infor model)
        {
            DataTable dt = bllga.GetGoodsFh(model.room_number, "and DATEDIFF(second ,'" + day + "',ga_date)>0 and DATEDIFF(second ,'" + day + "',ga_date)<86400");
            if (dt != null)
            {
                string s= dt.Rows[0][0].ToString();
                if (s != "")
                {
                    return Convert.ToDouble(dt.Rows[0][0]).ToString("0.##");
                }
                else {
                    return "0";
                }
            }
            return "0";
        }

        /// <summary>
        /// 获得一个房间的房费用
        /// </summary>
        /// <param name="statuid"></param>
        /// <returns></returns>
        public string GetGoodsFF(Model.occu_infor model)
        {
            DataTable dt = bllga.GetGoodsFh1(model.room_number, "and DATEDIFF(second ,'" + day + "',ga_date)>0 and DATEDIFF(second ,'" + day + "',ga_date)<86400");
            if (dt != null)
            {
                string s = dt.Rows[0][0].ToString();
                if (s != "")
                {
                    return Convert.ToDouble(dt.Rows[0][0]).ToString("0.##");
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
            return Convert.ToDecimal(bllrn.GetModelList("Rn_roomNum='" + model.room_number + "'")[0].Rn_price).ToString("0.##");
        }
        BLL.room_number bllrn = new BLL.room_number();
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
                case 3:
                    return "离开";
            }
            return "";
        }

        public override void SonLoad()
        {
            if (!IsPostBack)
            {
                TimeSpan time = DateTime.Now - Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")).Add(SysModel.YsTime);
                time_from.Value = DateTime.Now.ToString("yyyy-MM-dd");
                if (Request.QueryString["day"] != null)
                {
                    day = Convert.ToDateTime(Request.QueryString["day"]).ToString("yyyy-MM-dd");
                }
                else
                {
                    day = DateTime.Now.ToString("yyyy-MM-dd");
                }
                day = Convert.ToDateTime(day).Add(SysModel.YsTime).ToString();
                if (time.TotalSeconds < 0)
                {
                    day = Convert.ToDateTime(day).AddDays(-1).ToString();
                }
                Bind(day);
            }
        }
    }
}