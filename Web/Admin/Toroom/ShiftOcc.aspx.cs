using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CdHotelManage.Web.Admin.Toroom
{
    public partial class ShiftOcc :BasePage
    {
         protected System.Text.StringBuilder sbtext = new System.Text.StringBuilder();
         protected System.Text.StringBuilder sbtext1 = new System.Text.StringBuilder();
        public override void SonLoad()
        {
            if (!IsPostBack) {
                string orderid = Request.QueryString["orderids"];
                orderids.Value = orderid;
                Bind(orderid);
                Bind1(orderid);
            }
        }


        BLL.goods_account fmrz = new BLL.goods_account();

        private void Bind(string orderid) {
            DataSet dt = fmrz.GetList(" ga_occuid in ('" + orderid + "') and ga_Type in(4,6,7)");
            foreach (DataRow dr in dt.Tables[0].Rows)
            {

                if (dr["ga_Type"].ToString() == "0")
                {
                    dr["ga_remker"] = "消费（商品入账）";
                }
                if (dr["ga_Type"].ToString() == "1")
                {
                    dr["ga_remker"] = "消费（费用入账）" + "," + dr["ga_remker"].ToString();
                }
                if (dr["ga_Type"].ToString() == "3")
                {
                    dr["ga_remker"] = "续住押金";
                }
                if (dr["ga_Type"].ToString() == "4")
                {
                    dr["ga_remker"] = "结账（入账）";
                }
                if (dr["ga_Type"].ToString() == "5")
                {
                    dr["ga_remker"] = "退款（入账）";
                }
            }
            if (dt.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Tables[0].Rows)
                {
                    sbtext.Append("<tr><td><input type=\"radio\" name=\"radi\"></td><td>" + dr["ga_roomNumber"].ToString() + "</td><td class='sk'>" + Convert.ToDecimal(dr["ga_price"]).ToString("0.##") + "</td><td>" + GetKffsName(dr["ga_zffs_id"].ToString()) + "</td><td>" + GetUserName(dr["ga_people"].ToString()) + "</td><td class=\"tddate\">" + dr["ga_date"] + "</td><td>" + dr["ga_remker"] + "</td></tr>");
                }
            }
        }


        private void Bind1(string orderid)
        {
            DataSet dt = fmrz.GetList(" ga_occuid in ('" + orderid + "') and ga_Type in(5)");
            foreach (DataRow dr in dt.Tables[0].Rows)
            {

                if (dr["ga_Type"].ToString() == "0")
                {
                    dr["ga_remker"] = "消费（商品入账）";
                }
                if (dr["ga_Type"].ToString() == "1")
                {
                    dr["ga_remker"] = "消费（费用入账）" + "," + dr["ga_remker"].ToString();
                }
                if (dr["ga_Type"].ToString() == "3")
                {
                    dr["ga_remker"] = "续住押金";
                }
                if (dr["ga_Type"].ToString() == "4")
                {
                    dr["ga_remker"] = "结账（入账）";
                }
                if (dr["ga_Type"].ToString() == "5")
                {
                    dr["ga_remker"] = "退款（入账）";
                }
            }
            if (dt.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Tables[0].Rows)
                {
                    sbtext1.Append("<tr><td><input type=\"radio\" name=\"radi\"></td><td>" + dr["ga_roomNumber"].ToString() + "</td><td class='tk'>" + Convert.ToDecimal(dr["ga_sum_price"]).ToString("0.##") + "</td><td>" + GetKffsName(dr["ga_zffs_id"].ToString()) + "</td><td>" + GetUserName(dr["ga_people"].ToString()) + "</td><td class=\"tddate\">" + dr["ga_date"] + "</td><td>" + dr["ga_remker"] + "</td></tr>");
                }
            }
        }

        BLL.AccountsUsersBLL fmuser = new BLL.AccountsUsersBLL();
        BLL.meth_pay fmzffs = new BLL.meth_pay();

        public string GetUserName(string ides)
        {
            Model.AccountsUsers modes = fmuser.GetModel(ides.ToString());
            return modes.UserName;
        }

        //获得支付方式
        public string GetKffsName(string id)
        {
            try
            {
                Model.meth_pay model = fmzffs.GetModel(Convert.ToInt32(id.ToString()));
                return model.meth_pay_name;
            }
            catch
            {
                return "";
            }

        }
    }
}