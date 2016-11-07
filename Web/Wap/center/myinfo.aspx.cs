using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CdHotelManage.Web.Wap.center
{
    public partial class myinfo : System.Web.UI.Page
    {
        CdHotelManage.BLL.UsersBLL userbll = new BLL.UsersBLL();
        CdHotelManage.BLL.UserInfo inforbll = new BLL.UserInfo();
        CdHotelManage.BLL.userType typebll = new BLL.userType();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["WapUser"] != null)
            {
                 Model.Users Users = (Model.Users)Session["WapUser"];
                 if (Users != null)
                 {
                     string userid = Users.userid;
                     Bindinfo(userid);
                 }
            }
            else
            {
                Response.Redirect("../login.aspx?returnurl=" + Request.Url.ToString());
            }
        }

        private void Bindinfo(string userid)
        {
            try
            {
                if (userid != ""&&userid!=null)
                {
                    Model.Users model = userbll.GetModel(userid);
                    if (model != null)
                    {
                        DataTable dt = inforbll.GetList(1, "userid='" + model.userid + "'", "ID asc").Tables[0];
                        if (dt != null)
                        {
                            this.labname.Text = model.username;
                            this.labphone.Text = dt.Rows[0]["phone"].ToString();
                            this.labsex.Text = dt.Rows[0]["sex"].ToString();
                            this.labtype.Text = GetType(Convert.ToInt32(dt.Rows[0]["typeid"].ToString()));
                            this.labaddress.Text = dt.Rows[0]["address"].ToString();
                        }
                    }
                }
            }
            catch
            { 
            
            }
        }

        private string GetType(int typeid)
        {
            string typename = "";
            if (typeid != 0)
            {
                Model.userType model = typebll.GetModel(typeid);
                if (model != null)
                {
                    typename = model.typename;
                }
            }
            return typename;
        }
    }
}