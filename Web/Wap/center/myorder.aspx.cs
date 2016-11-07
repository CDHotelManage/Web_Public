using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Wap.center
{
    public partial class myorder : System.Web.UI.Page
    {
        CdHotelManage.BLL.occu_infor occubll = new BLL.occu_infor();
        CdHotelManage.BLL.book_room orderbll = new BLL.book_room();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            try
            {
                if (Session["WapUser"] != null)
                {
                    Model.Users Users = (Model.Users)Session["WapUser"];
                    if (Users != null)
                    {
                        string userid = Users.userid;
                        rptMyOrder.DataSource = orderbll.GetList("userid='" + userid + "'").Tables[0];
                        rptMyOrder.DataBind();

                        rptMyHistory.DataSource = occubll.GetList("userid='" + userid + "'").Tables[0];
                        rptMyHistory.DataBind();
                    }

                }
                else
                {
                    Response.Redirect("../login.aspx?returnurl=" + Request.Url.ToString());
                }
            }
            catch
            {
                
            }
        }
    }
}