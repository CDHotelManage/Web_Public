using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.Toroom
{
    public partial class accountlist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                BindRep();
                
            }
        }

        BLL.goods_account bllga = new BLL.goods_account();
        private void BindRep() {
            string orders = Request.QueryString["orderids"];
            rep1.DataSource = bllga.GetModelList1("ga_Type in (8,0,1,9,10,101,11) and ga_occuid='" + orders + "'");
            rep1.DataBind();
        }
    }
}