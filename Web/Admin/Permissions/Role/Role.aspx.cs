using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.Permissions.Role
{
    public partial class AddRole : System.Web.UI.Page
    {
        CdHotelManage.BLL.AccountsRolesBLL rolebll = new BLL.AccountsRolesBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["opera"]))
                {
                    string opera = Request.QueryString["opera"].ToString();
                    if (opera == "add")
                    {
                        this.PanelAdd.Visible = true;
                    }
                    else if (opera == "edit" && (!string.IsNullOrEmpty(Request.QueryString["roleid"].ToString())))
                    {
                        this.PanelEdit.Visible = true;
                        int roleid = Convert.ToInt32(Request.QueryString["roleid"].ToString());
                        BindRole(roleid);
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Model.AccountsRoles model = new Model.AccountsRoles();
                int count = rolebll.GetListByTitle( this.txtrolename.Text.Trim()).Tables[0].Rows.Count;
                if (count > 0)
                {
                    this.labname.Text = "该角色名已存在！";
                    return;
                }
                model.RoleID = rolebll.GetMaxId().ToString();
                model.Title = this.txtrolename.Text.Trim();
                model.Description = this.txtdescript.Text.Trim();
                rolebll.Add(model);
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('提交成功');parent.Window_Close();</script>");

                //Response.Write("<script> function CloseDiv() {Window_Close();}</script>");
            }
            catch 
            {
            }
        }

        private void BindRole(int RoleId)
        {
            if (RoleId != 0)
            {
                Model.AccountsRoles model = rolebll.GetModel(RoleId);
                if (model != null)
                {
                    this.rolename.Text = model.Title;
                    this.descript.Text = model.Description;
                }
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["roleid"]))
            {
                Model.AccountsRoles model = new Model.AccountsRoles();
                int roleid = Convert.ToInt32(Request.QueryString["roleid"].ToString());
                model.RoleID = roleid.ToString();
                model.Title = this.rolename.Text.Trim();
                model.Description = this.descript.Text.Trim();
                rolebll.Update(model);
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('编辑成功');parent.Window_Close();</script>");

            }
        }
    }
}