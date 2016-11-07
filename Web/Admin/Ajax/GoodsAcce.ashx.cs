using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

using System.Web.Script.Serialization;

namespace CdHotelManage.Web.Admin.Ajax
{
    /// <summary>
    /// GoodsAcce 的摘要说明
    /// </summary>
    public class GoodsAcce : IHttpHandler
    {
        HttpContext context = null;
        public void ProcessRequest(HttpContext context)
        {
            this.context = context;
            string type = context.Request.QueryString["type"];
            switch (type)
            {
                case "GetGoods":
                    GetGoods();
                    break;
                case "addFus":
                    AddFus();
                    break;
                case "getFA":
                    GetFA();
                    break;
                case "getFA1":
                    GetFA1();
                    break;
                case "getyuan":
                    Getyuan();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 获得原价
        /// </summary>
        private void Getyuan()
        {
            int typeid = Convert.ToInt32(context.Request.QueryString["typeid"]);
            Model.room_type modelty = bllrt.GetModel(typeid);
            if (modelty != null) {
                context.Response.Write(Convert.ToDecimal(modelty.room_listedmoney).ToString("0.##"));
                context.Response.End();
            }
        }
        BLL.room_type bllrt = new BLL.room_type();
        private void GetFA1()
        {
            string id = context.Request.QueryString["id"];
            Model.hourse_scheme modelhs = bllhs.GetModel(Convert.ToInt32(id));
            if (modelhs != null)
            {
                context.Response.Write( Convert.ToDecimal(modelhs.Hs_zdr).ToString("0.##"));
            }
            else
            {
                context.Response.Write(1);
            }
        }
        BLL.hourse_scheme bllhs = new BLL.hourse_scheme();
        /// <summary>
        /// 通过方案ID获得方案折扣
        /// </summary>
        private void GetFA()
        {
            string id = context.Request.QueryString["id"];
            Model.hourse_scheme modelhs = bllhs.GetModel(Convert.ToInt32(id));
            if (modelhs != null)
            {
                context.Response.Write(modelhs.hs_Discount);
            }
            else
            {
                context.Response.Write(1);
            }
            
        }

        private void AddFus()
        {
            string ids = context.Request.QueryString["id"];
            BLL.hour_room bllhr = new BLL.hour_room();
            Model.hour_room modehr = bllhr.GetModel(Convert.ToInt32(ids));
            int res= bllhr.Add(modehr);
            JavaScriptSerializer js = new JavaScriptSerializer();
            string da = js.Serialize(bllhr.GetModel(res));
            if (res>0) {
                Common.AjaxMsgHelper.AjaxMsg1("ok", res.ToString(), da, "");
            }
        }


        BLL.goods_account fmrz = new BLL.goods_account();

        BLL.meth_pay fmzffs = new BLL.meth_pay();
        BLL.AccountsUsersBLL fmuser = new BLL.AccountsUsersBLL();
        BLL.occu_infor blloc = new BLL.occu_infor();
        private void GetGoods()
        {
            int readValue =Convert.ToInt32(context.Request.QueryString["readValue"]);
            string room = context.Request.QueryString["room"];
            string whereids = string.Empty;
            if (context.Request.QueryString["whereids"] != null) {
                whereids = context.Request.QueryString["whereids"].ToString();
            }
            System.Text.StringBuilder sbtext = new System.Text.StringBuilder();
            string orderid=string.Empty;
            if (context.Request.QueryString["orderid"] != null)
            {
                orderid = context.Request.QueryString["orderid"];
            }
            string where = "";
            if (readValue == 2) {
                where = " and ga_Type in(0,1,9,10,101,11,8)";
            }
            else if (readValue == 1) {
                where = " and ga_Type in(4,5,6,7)";
            }
            else if (readValue == 3) {
                where = " and ga_Type in(12)";
            }
            if (room != "0") {
                where += " and ga_roomNumber='" + room + "'";
            }
            if (whereids != "") {
                where += " and ID not in(" + whereids + ")";
            }
            double Money = 0;
            double ysMoney = 0;
            //if (blloc.GetModelList("order_id='" + orderid + "' and state_id=3").Count <= 0)
            //{
                DataSet dt = fmrz.GetList(" ga_occuid in ('" + orderid + "') " + where + "");
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
                    try
                    {
                        Money += double.Parse(dr["ga_price"].ToString());

                        ysMoney += double.Parse(dr["ga_sum_price"].ToString());
                    }
                    catch { }
                }
                if (dt.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Tables[0].Rows)
                    {
                        sbtext.Append("<tr><td>" + dr["ga_roomNumber"].ToString() + "</td><td>" + dr["ga_name"].ToString() + "</td><td>" + dr["ga_price"].ToString() + "</td><td>" + dr["ga_sum_price"] + "</td><td>" + GetKffsName(dr["ga_zffs_id"].ToString()) + "</td><td>" + GetUserName(dr["ga_people"].ToString()) + "</td><td class=\"tddate\">" + dr["ga_date"] + "</td><td class=\"tdreamk\">" + GetStr(dr["ga_remker"].ToString(), dr["id"].ToString()) + "</td><td>" + GetInp(dr) + "</td></tr>");
                    }
                }
                context.Response.Write("" + Money + "&" + sbtext.ToString() + "&" + ysMoney + "");
                context.Response.End();
           // }
            //else {
            //    context.Response.Write("err");
            //    context.Response.End();
            //}
            //JavaScriptSerializer js=new JavaScriptSerializer();
            //string str = js.Serialize(dt.Tables[0]);
            //Common.AjaxMsgHelper.AjaxMsg(@sbtext.ToString(), Money.ToString());
            //txt_xfMoneys.Value = txt_xfMoney.Value = ysMoney.ToString();
            //txt_ysMoneys.Value = txt_ysMoney.Value = Money.ToString();
            //txt_bcysMoneys.Value = txt_bcysMoney.Value = (double.Parse(txt_xfMoney.Value) - double.Parse(txt_ysMoney.Value)).ToString();
        }

        private string GetInp(DataRow dr) {
            if (Convert.ToInt32(dr["ga_Type"])==12)
            {
                return "";
            }
            
                return "<input type=\"button\" class=\"btnOk\" value=\"冲帐\" onclick=\"cz(this,'" + dr["id"] + "','add')\">";
            
        }

        public string GetStr(string str,string id) {
            if (str.Length >= 15) {
                return str.Substring(0, 15) + "<a href=\"#\" onclick=\"cz(this,'"+id+"','edit')\">详情</a>";
            }
            return str;
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
        public string GetUserName(string ides)
        {
            Model.AccountsUsers modes = fmuser.GetModel(ides.ToString());
            return modes.UserName;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}