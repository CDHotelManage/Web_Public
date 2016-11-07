using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace CdHotelManage.Web.Admin.Permissions.accountuser
{
    public partial class adduser : System.Web.UI.Page
    {
        CdHotelManage.BLL.AccountsUsersBLL aubll = new BLL.AccountsUsersBLL();
        CdHotelManage.BLL.AccountsRolesBLL arbll = new BLL.AccountsRolesBLL();
        CdHotelManage.BLL.AccountsUserRolesBLL aurbll = new BLL.AccountsUserRolesBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRole();
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid)
                {
                    string name = txtname.Text.Trim();
                    Model.AccountsUsers user = aubll.GetModelByName(name);
                    if (user != null)
                    {
                        labname.Text = "用户名已存在";
                        return;
                    }
                    Model.AccountsUsers au = new Model.AccountsUsers();
                    string id = Guid.NewGuid().ToString();
                    au.UserID = id;
                    au.UserName = txtname.Text.Trim();
                    au.Password = txtpassword.Text.Trim();
                    au.TrueName = txtTrueName.Text.Trim();
                    au.Sex = this.radsex.SelectedValue == "1" ? "男" : "女";
                    au.Phone = this.txtPhone.Text.Trim();
                    au.Email = "";
                    au.EmployeeID = 0;
                    au.DepartmentID = "";
                    au.Activity = true;
                    au.UserType = "AA";
                    au.Style = 1;
                    aubll.Add(au);

                    Model.AccountsUserRoles aur = new Model.AccountsUserRoles();
                    aur.UserID = id;
                    aur.RoleID = Convert.ToInt32(this.drpRole.SelectedValue);
                    aurbll.Add(aur);
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('提交成功');parent.Window_Close();</script>");
                }
            }
            catch (Exception)
            {

                Maticsoft.Common.MessageBox.ShowAndRedirect(this, "系统繁忙，请稍后再试！", "");
            }
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {

        }

        //绑定角色
        private void BindRole()
        {            
            drpRole.DataSource = arbll.GetList("");
            drpRole.DataValueField = "RoleID";
            drpRole.DataTextField = "title";
            drpRole.DataBind();
            drpRole.Items.Insert(0, new ListItem("--请选择--", ""));

        }
    }
}