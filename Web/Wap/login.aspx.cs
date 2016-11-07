using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Wap
{
    public partial class login : System.Web.UI.Page
    {
        BLL.UsersBLL userbll = new BLL.UsersBLL();
        string userid = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid)
                {
                   CdHotelManage.Model.Users WapUser = userbll.CheckUser(this.txtname.Text.Trim(), this.txtpwd.Text.Trim());
                   if (WapUser != null)
                   {
                       Session["WapUser"] = WapUser;
                       userid = WapUser.userid;
                       ToPage();
                   }
                   else
                   {
                       lblMessage.Text = "用户名或密码不正确！";
                   }
                }
            }
            catch
            { 
            
            }
        }

        private void ToPage()
        {
            if (Request.QueryString["returnurl"] != null)
            {
                CdHotelManage.Model.Users user = userbll.GetModel(userid);
                string returnurl = Request.QueryString["returnurl"].ToString();
                Response.Redirect(returnurl);
            }
            else
            {
                Response.Redirect("index.aspx");
            }
        }
    }
}