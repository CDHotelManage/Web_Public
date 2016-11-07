using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.customer
{
    public partial class contactsList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                accounts.Value = Request.QueryString["accounts"];
                Bind();
            }
        }
        BLL.Contacts bllcon = new BLL.Contacts();
        void Bind() {
            List<Model.Contacts> listconte = bllcon.GetModelList("Accounts='" + accounts.Value + "'");
            rep1.DataSource = listconte;
            rep1.DataBind();
        }

        protected string GetCall(int id) {
            BLL.cCall bllca = new BLL.cCall();
            return bllca.GetModel(id).callName;
        }

        protected string GetPost(int id)
        {
            BLL.cPost bllca = new BLL.cPost();
            return bllca.GetModel(id).cpName;
        }

        protected string GetDepartment(int id)
        {
            BLL.cDepartment bllca = new BLL.cDepartment();
            return bllca.GetModel(id).cDName;
        }

        protected string GetSex(bool b) {
            if (b)
            {
                return "女";
            }
            return "男";
        }
    }
}