using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.customer
{
    public partial class GoodsList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                string id = Request.QueryString["id"];
                Bind(id);
            }
        }

        private void Bind(string goodno) {
            BLL.goods_account bllga = new BLL.goods_account();
            rep1.DataSource = bllga.GetModelList1("ga_goodNo='" + goodno + "'");
            rep1.DataBind();
        }

        protected string GetUserName(string userid) {
            BLL.AccountsUsersBLL bll = new BLL.AccountsUsersBLL();
            Model.AccountsUsers modelacc = bll.GetModel(userid);
            if (modelacc != null)
            {
                return modelacc.UserName;
            }
            return "";
        }
    }
}