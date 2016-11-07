using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.Menus2
{
    public partial class methpay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                Bind();
            }
        }

        private void Bind() { 
            BLL.meth_pay bllmp=new BLL.meth_pay();
            rep1.DataSource = bllmp.GetList("meth_pay_name!='协议单位'");
            rep1.DataBind();
        }

        protected string GetIsOk(bool b) {
            if (b) {
                return "<img src='/images/yes.gif'>";
            }
            return "<img src='/images/no.gif'>";
        }
    }
}