using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.member
{
    public partial class addPice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                BLL.AddPrice blla = new BLL.AddPrice();
                rep1.DataSource= blla.GetAllList();
                rep1.DataBind();
            }
        }


        protected string GetStr(bool b) {
            if (b) {
                return "启用";
            }
            return "禁止";
        }

        protected string GetStr1(bool b)
        {
            if (b)
            {
                return "0";
            }
            return "1";
        }
    }
}