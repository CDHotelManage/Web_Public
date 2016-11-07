using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CdHotelManage.Web.Wap.center
{
    public partial class updateinfo : System.Web.UI.Page
    {
        CdHotelManage.BLL.UsersBLL userbll = new BLL.UsersBLL();
        CdHotelManage.BLL.UserInfo infobll = new BLL.UserInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["WapUser"] != null)
                {
                    Model.Users model = (Model.Users)Session["WapUser"];
                    string uid = model.userid;
                    ViewState["uid"] = uid;
                    BindInfo(uid);
                }
                else
                {
                    Response.Redirect("../login.aspx?returnurl=" + Request.Url.ToString());
                }
            }
        }

        private void BindInfo(string uid)
        {
            try
            {
                if (uid != "")
                {
                    Model.Users User = userbll.GetModel(uid);
                    if (User != null)
                    {
                        this.username.Text = User.username;
                        DataTable dt = infobll.GetList(1, "userID='" + uid + "'", "ID desc").Tables[0];
                        if (dt != null)
                        {
                            this.truename.Text = dt.Rows[0]["truename"].ToString();
                            this.phonenum.Text = dt.Rows[0]["phone"].ToString();
                            this.birthday.Text = Convert.ToDateTime(dt.Rows[0]["bairthday"]).ToShortDateString();
                        }
                    }
                }
            }
            catch
            { 
            
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Model.Users users = new Model.Users();
                Model.UserInfo userinfo = new Model.UserInfo();

                users.userid = ViewState["uid"].ToString();
                users.username = this.username.Text.Trim();
               // userbll.UpdateInfo(users);

                userinfo.userID = ViewState["uid"].ToString();
                userinfo.phone = this.phonenum.Text.Trim();
                userinfo.bairthday = Convert.ToDateTime(this.birthday.Text.Trim());
                userinfo.Truename = this.truename.Text.Trim();
                infobll.UpdateInfo(userinfo);
                Maticsoft.Common.MessageBox.ShowAndRedirect(this, "修改成功！", ""); 
            }
            catch
            { 
            
            }
        }
    }
}