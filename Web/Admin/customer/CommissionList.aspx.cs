using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.customer
{
    public partial class CommissionList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string acc = Request.QueryString["accounts"];
                accoun.Value = acc;
                Bind(acc);
            }

        }

        private void Bind(string account)
        {
            string where = string.Empty;
            if (DDLBack.SelectedValue != "-1")
            {
                where += " and IsBack=" + DDLBack.SelectedValue;
            }
            BLL.Commission bllcomm = new BLL.Commission();
            rep1.DataSource = bllcomm.GetModelList("CommSum!=0 and  Accounts='" + account + "' " + where);
            rep1.DataBind();
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            Bind(accoun.Value);
        }
        protected string GetISok(bool b)
        {
            if (b)
            {
                return "<input type=\"checkbox\" disabled=\"disabled\" class=\"chk\" />";
            }
            return "<input type=\"checkbox\" class=\"chk\" />";
        }

        protected string GetAuuoctn(string acc) {
            BLL.customer bllcus = new BLL.customer();
            return bllcus.GetAccounts(acc).cName;
        }

        protected string GetComm(bool b) {
            if (b) {
                return "反佣";
            }
            return "未反佣";
         }

        protected string GetComm1(bool b)
        {
            if (b)
            {
                return "是";
            }
            return "否";
        }
    }
}
