using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.Toroom
{
    public partial class SetPwd : BasePage
    {
        
        private void Bind(string mid) { 
           
        }
        BLL.member bllme = new BLL.member();
        protected void btnSave_Click(object sender, EventArgs e) {
            Model.member model = bllme.GetModel(accout.Value);
            if (pwds.Value != model.Pwd)
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('密码错误!');</script>");
            }
            else {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript'>parent.document.getElementById('txt_hycard').value='1';parent.document.getElementById('btnAdds').click();</script>");
            }
        }

        public override void SonLoad()
        {
            if (!IsPostBack)
            {
                string mid = Request.QueryString["mid"];
                accout.Value = mid;
            }
        }
    }
}