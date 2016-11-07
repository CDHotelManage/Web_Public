using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.customer
{
    public partial class custromerDestic : System.Web.UI.Page
    {
        protected string proaccid = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                accounts.Value = Request.QueryString["accounts"];
                proaccid = Request.QueryString["accounts"];
            }
        }
    }
}