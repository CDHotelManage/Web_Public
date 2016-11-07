using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CdHotelManage.Web.Wap
{
    public partial class reg : System.Web.UI.Page
    {
        CdHotelManage.BLL.UsersBLL userbll = new BLL.UsersBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Model.Users model = new Model.Users();
                DataTable dt = userbll.GetList(" username='" + this.moblieReg.Text.Trim() + "'").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    this.labname.Text = "该用户名已存在";
                    return;
                }
                model.userid = Guid.NewGuid().ToString();
                model.username = this.moblieReg.Text.Trim();
                model.passwords = this.pwd.Text.Trim();
                model.user_type = 0;
                model.pubdate = DateTime.Now;

                if (userbll.Add(model))
                {
                    Maticsoft.Common.MessageBox.ShowAndRedirect(this, "提交成功！", ""); 
                }
                else
                {

                }
            }
            catch
            {

            }
        }
    }
}