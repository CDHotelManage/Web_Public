using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CdHotelManage.Web.Admin.Toroom
{
    public partial class GZlist : System.Web.UI.Page
    {
        protected System.Text.StringBuilder sbhtml1 = new System.Text.StringBuilder();
        protected System.Text.StringBuilder sbhtml2 = new System.Text.StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                BindZz(0);
                BindZz(4);
            }
        }
        BLL.occu_infor blloc = new BLL.occu_infor();
        private void BindZz(int state) {
            List<string> listorder = new List<string>();
             List<Model.occu_infor> listocc=null;
            if (Request.QueryString["orderid"] != null)
            {
                listocc = blloc.GetModelList("state_id=" + state + " and order_id!='" + Request.QueryString["orderid"] + "'");
            }
            else
            {
                listocc = blloc.GetModelList("state_id=" + state);
            }
            if (listocc.Count > 0)
            {
                foreach (Model.occu_infor model in listocc)
                {
                    if (!listorder.Contains(model.order_id))
                    {
                        listorder.Add(model.order_id);
                        if (state == 0)
                        {
                            sbhtml1.Append("<tr order='" + model.order_id + "' ids='" + model.occ_id + "'><td><input type='radio' name='ra' class='cbx'></td><td>" + model.room_number + "</td><td>" + model.occ_name + "</td><td>" + model.phonenum + "</td>" + BindGv(model.order_id) + "</tr>");
                        }
                        else
                        {
                            sbhtml2.Append("<tr order='" + model.order_id + "' ids='" + model.occ_id + "'><td><input type='radio' name='ra' class='cbx'></td><td>" + model.room_number + "</td><td>" + model.occ_name + "</td><td>" + model.phonenum + "</td>" + BindGv(model.order_id) + "</tr>");
                        }
                    }
                }
            }
            else
            {
                if (state == 0)
                {
                    sbhtml1.Append("<TR><td colspan=\"7\">暂无可挂帐目标!</td></TR>");
                }
                else {
                    sbhtml2.Append("<TR><td colspan=\"7\">暂无可挂帐目标!</td></TR>");
                }
            }
        }
        BLL.goods_account bllga = new BLL.goods_account();
        /// <summary>
        /// 绑定入账信息
        /// </summary>
        public string BindGv(string orderid)
        {
            double Money = 0;
            double ysMoney = 0;
            DataSet dt = bllga.GetList(" ga_occuid in ('" + orderid + "')");
            foreach (DataRow dr in dt.Tables[0].Rows)
            {
                try
                {
                    Money += double.Parse(dr["ga_price"].ToString());

                    ysMoney += double.Parse(dr["ga_sum_price"].ToString());
                }
                catch { }
            }

            string st = (Money - ysMoney).ToString();

            return "<td>" + ysMoney + "</td><td>" + Money + "</td><td>" + st + "</td>";
        }
    }
}