using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.Permissions.accountuser
{
    public partial class edituser : System.Web.UI.Page
    {
        CdHotelManage.BLL.AccountsUsersBLL aubll = new BLL.AccountsUsersBLL();
        CdHotelManage.BLL.AccountsRolesBLL arbll = new BLL.AccountsRolesBLL();
        CdHotelManage.BLL.AccountsUserRolesBLL aurbll = new BLL.AccountsUserRolesBLL();
        string hotelID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hotelID = Request.QueryString["hid"];
                BindRole();
                if (!string.IsNullOrEmpty(Request.QueryString["uid"]))
                {
                    string uid = Request.QueryString["uid"].ToString();
                    BindData(uid);
                }
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(Request.QueryString["uid"]))
                {
                    string uid = Request.QueryString["uid"].ToString();
                    Model.AccountsUsers au = new Model.AccountsUsers();
                    au.UserID = uid;
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
                    aubll.Update(au);

                    Model.AccountsUserRoles aur = new Model.AccountsUserRoles();
                    Model.AccountsUserRoles urmodel= aurbll.GetModel(uid, hotelID);
                    if (urmodel != null)
                    {
                        aur.UserID = uid;
                        aur.RoleID = this.drpRole.SelectedValue;
                        aurbll.Update(aur);
                    }
                    else
                    {
                        aur.UserID = uid;
                        aur.RoleID = this.drpRole.SelectedValue;
                        aurbll.Add(aur);
                    }
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

        private void BindData(string uid)
        {
            try
            {
                if (uid != "")
                {
                    Model.AccountsUsers au = aubll.GetModel(uid);
                    if (au != null)
                    {
                        Model.AccountsUserRoles aur = aurbll.GetModel(au.UserID, hotelID);
                        if (aur != null)
                        {
                            labrole.Text = arbll.GetModel(aur.RoleID).Title;
                            drpRole.SelectedValue = arbll.GetModel(aur.RoleID).RoleID.ToString();
                        }
                        else
                        {
                            labrole.Text = "无";
                        }
                        txtname.Text = au.UserName;
                        txtpassword.Text = au.Password;
                        txtTrueName.Text = au.TrueName;
                        txtPhone.Text = au.Phone;
                        radsex.SelectedValue = au.Sex.ToString() == "男" ? "1" : "0";
                        

                    }
                    else
                    {
                        Response.Redirect("userlist.aspx");
                    }
                }
            }
            catch
            { 
            
            }
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