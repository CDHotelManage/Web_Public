using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Wap.center
{
    public partial class updatepwd : System.Web.UI.Page
    {
        CdHotelManage.BLL.UsersBLL userbll = new BLL.UsersBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["WapUser"] == null)
                {
                    Response.Redirect("../login.aspx?returnurl=" + Request.Url.ToString());
                }
            }
        }

        
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Model.Users User = (Model.Users)Session["WapUser"];
                if (User != null)
                {
                    if (this.txtpwd1.Text != User.passwords)
                    {
                        this.labname.Text = "原密码错误";
                        return;
                    }
                    else
                    {
                        Model.Users model = new Model.Users();
                        model.userid = User.userid;
                        model.passwords = this.pwd.Text.Trim();
                        userbll.UpdatePwd(model);
                        Response.Redirect("../index.aspx");
                    }
                }
            }
            catch
            { 
            
            }
        }

        
    }
}