using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.customer
{
    public partial class protocol : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                accounts.Value = Request.QueryString["accounts"];
                Bind(accounts.Value);
            }
        }
        BLL.cprotocol bllcp = new BLL.cprotocol();
        private void Bind(string accounts) {
            rep1.DataSource = bllcp.GetModelList("Accounts='" + accounts + "'");
            rep1.DataBind();
        }

        protected string GetTypeName(int id) {
            BLL.cpType bllrp = new BLL.cpType();
            return bllrp.GetModel(id).ptName;
        }

        protected string GetUser(string userid) {
            BLL.AccountsUsersBLL bllcp = new BLL.AccountsUsersBLL();
            return bllcp.GetModel(userid).UserName;
        }
    }
}