using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace CdHotelManage.Web.Admin.Toroom
{
    public partial class SincetheAdds : System.Web.UI.Page
    {
        BLL.Remaker fmremaker = new BLL.Remaker();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                if (Request.QueryString["type"] != null)
                {
                    hidtype.Value = Request.QueryString["type"];
                    BindGV(Request.QueryString["type"]);
                }
            }
        }
        public void BindGV(string type)
        {
            
        
            string Content = "<table class='tablesa' cellpadding='0' cellspacing='0' width='100%'><tr><td style=\"text-align:left; text-indent:5px; font-size:15px;\">  备注</td></tr>";
            DataSet dt = fmremaker.GetList("type='" + type + "'");
            foreach (DataRow dr in dt.Tables[0].Rows) 
            {
                Content += "<tr bookno=" + dr["id"].ToString() + " onclick=\"Getid(" + dr["id"].ToString() + ",'" + dr["remaker"].ToString() + "')\" class='tr1'><td>" + dr["remaker"].ToString() + "</td></tr>";
            }
            Content += "</table>";
            DivGV.InnerHtml = Content;

        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            if (fmremaker.Delete(Convert.ToInt32(hidid.Value)))
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript'>alert('删除成功');</script>");

                BindGV(hidtype.Value);
            }
            else 
            {
            
            }
        }

        protected void btnsercher_Click(object sender, EventArgs e)
        {
            BindGV(hidtype.Value);
        }
    }
}