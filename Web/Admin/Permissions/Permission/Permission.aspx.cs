using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

namespace CdHotelManage.Web.Admin.Permissions.Permission
{
    public partial class Permission : System.Web.UI.Page
    {
        CdHotelManage.BLL.AccountsRolesBLL arbll = new BLL.AccountsRolesBLL();
        CdHotelManage.BLL.RoleMenuBLL rmbll = new BLL.RoleMenuBLL();
        CdHotelManage.BLL.AccountsUserRolesBLL urbll = new BLL.AccountsUserRolesBLL();
        CdHotelManage.BLL.MenuBLL menubll = new BLL.MenuBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRole();
                BindMenu();
                BindPermissions();
            }
        }

        //绑定角色
        private void BindRole()
        {
            rptRole.DataSource = arbll.GetList("");
            rptRole.DataBind();
        }

        private void BindMenu()
        {
            rptMenu.DataSource = menubll.GetList(" parent_id=0").Tables[0];
            rptMenu.DataBind();
        }

        protected void rptRole_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int roleid = Convert.ToInt32(e.CommandArgument.ToString());
            ViewState["RoleID"] = roleid;
            
            if (e.CommandName == "delete")
            {
                DataTable dt= urbll.GetList(" RoleID=" + roleid).Tables[0];
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        urbll.Delete(dt.Rows[i]["UserID"].ToString());
                    }
                }
                rmbll.Delete(roleid);
                arbll.Delete(roleid);
            }
            BindRole();
            BindPermissions();
            ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>showli(" + roleid + ")</script>");

        }

        protected void rptMenuRole_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rptMenuRole = (Repeater)e.Item.FindControl("rptMenuRole");
                HiddenField menu_id = (HiddenField)e.Item.FindControl("hidid");
                rptMenuRole.DataSource = menubll.GetList("parent_id=" + menu_id.Value);
                rptMenuRole.DataBind();
            }
        }

        private void BindPermissions()
        {
            try
            {
                Model.RoleMenu model = new Model.RoleMenu();
                for (int i = 0; i < rptMenu.Items.Count; i++)
                {
                    HiddenField menu_pid = (HiddenField)rptMenu.Items[i].FindControl("hidid");
                    Repeater rptMenuRole = (Repeater)rptMenu.Items[i].FindControl("rptMenuRole");
                    for (int j = 0; j < rptMenuRole.Items.Count; j++)
                    {
                        CheckBox cb = (CheckBox)rptMenuRole.Items[j].FindControl("cbMenu");
                        HiddenField hidchildid = (HiddenField)rptMenuRole.Items[j].FindControl("hidchildid");
                        DataTable dt = null;
                        if (ViewState["RoleID"] != null)
                        {
                            dt = rmbll.GetList("RoleID=" + Convert.ToInt32(ViewState["RoleID"].ToString())).Tables[0];
                        }
                        else
                        {
                            ViewState["RoleID"] = arbll.GetList(1, "", "RoleID Asc").Tables[0].Rows[0]["RoleID"].ToString();
                            dt = rmbll.GetList("RoleID=" + Convert.ToInt32(ViewState["RoleID"].ToString())).Tables[0];
                        }
                        cb.Checked = false;
                        for (int k = 0; k < dt.Rows.Count; k++)
                        {
                            if (dt.Rows[k]["RoleID"].ToString() == ViewState["RoleID"].ToString())
                            {
                                if (dt.Rows[k]["Menu_id"].ToString() == hidchildid.Value)
                                {
                                    cb.Checked = true;
                                }
                            }
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
                if (ViewState["RoleID"] != null)
                {
                    rmbll.DeleteALL(Convert.ToInt32(ViewState["RoleID"].ToString()));
                }
                else 
                {
                    ViewState["RoleID"] = arbll.GetList(1, "", "RoleID Asc").Tables[0].Rows[0]["RoleID"].ToString();
                }
                Model.RoleMenu model = new Model.RoleMenu();
                for (int i = 0; i < rptMenu.Items.Count; i++)
                {
                    HiddenField menu_pid = (HiddenField)rptMenu.Items[i].FindControl("hidid");
                    Repeater rptMenuRole = (Repeater)rptMenu.Items[i].FindControl("rptMenuRole");
                    for (int j = 0; j < rptMenuRole.Items.Count; j++)
                    {
                        HiddenField hidchildid = (HiddenField)rptMenuRole.Items[j].FindControl("hidchildid");
                        CheckBox cb = (CheckBox)rptMenuRole.Items[j].FindControl("cbMenu");
                        if (cb.Checked)
                        {
                            model.RoleID = Convert.ToInt32(ViewState["RoleID"].ToString());
                            model.Menu_id = Convert.ToInt32(hidchildid.Value);
                            model.Menu_pid = Convert.ToInt32(menu_pid.Value);
                            rmbll.Add(model);
                            Maticsoft.Common.MessageBox.ShowAndRedirect(this, "保存成功！", "");
                        }
                    }
                }
            }
            catch
            {
                Maticsoft.Common.MessageBox.ShowAndRedirect(this, "操作有误！", "");
            }
        }
    }
}