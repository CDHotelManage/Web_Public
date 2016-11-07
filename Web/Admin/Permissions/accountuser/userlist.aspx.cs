using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CdHotelManage.Web.Admin.Permissions.accountuser
{
    public partial class userlist : System.Web.UI.Page
    {
        private int pageSize = 10;
        private int pageIndex = 1;
        private readonly CdHotelManage.BLL.AccountsUsersBLL aubll = new BLL.AccountsUsersBLL();
        private readonly CdHotelManage.BLL.AccountsUserRolesBLL aurbll = new BLL.AccountsUserRolesBLL();
        private readonly CdHotelManage.BLL.AccountsRolesBLL rolebll = new BLL.AccountsRolesBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hidSort.Value = "Email";
                hidOrder.Value = "DESC";
                hidCheck.Value = "false";
                buildGrid(pageSize, pageIndex);
            }
        }

        #region 方法
        private void buildGrid(int pageSize, int pageindex)
        {

            string sort = hidSort.Value;
            string order = hidOrder.Value;
            int currentPage = Pager.CurrentPageIndex;



            rptUser.DataSource = aubll.GetUsersPager(sort, order, currentPage, pageSize);
            rptUser.DataBind();


            Pager.RecordCount = aubll.GetCount();
            Pager.ShowCustomInfoSection = Wuqi.Webdiyer.ShowCustomInfoSection.Right;
            Pager.PageSize = pageSize;
            Pager.CurrentPageIndex = pageindex;
            if (Pager != null)
            {
                if (Pager.RecordCount != 0)
                {
                    Pager.ShowPageIndex = true;
                    Pager.ShowDisabledButtons = true;
                    Pager.CustomInfoSectionWidth = new System.Web.UI.WebControls.Unit("40%");
                    Pager.ShowPageIndexBox = Wuqi.Webdiyer.ShowPageIndexBox.Always;
                    Pager.CustomInfoHTML = "&nbsp;记录总数：<b>" + Pager.RecordCount.ToString() + "</b>";
                    Pager.CustomInfoHTML += " 总页数：<b>" + Pager.PageCount.ToString() + "</b>";
                    Pager.CustomInfoHTML += " 当前页：<font color=\"red\"><b>" + Pager.CurrentPageIndex.ToString() + "</b></font>";
                }
                else
                {
                    Pager.ShowPageIndex = false;
                    Pager.ShowDisabledButtons = false;
                    Pager.ShowPageIndexBox = Wuqi.Webdiyer.ShowPageIndexBox.Never;
                    Pager.CustomInfoSectionWidth = new System.Web.UI.WebControls.Unit("100%");
                    Pager.CustomInfoHTML = "<div class='norecord'><span>当前无记录</span></div>";

                }
            }
        }

        //获取角色
        public string GetRole(string id)
        {
            string rolename="";
            try
            {
                Model.AccountsUserRoles urmodel = aurbll.GetModel(id);
                Model.AccountsRoles rolemodel = rolebll.GetModel(urmodel.RoleID);
                rolename = rolemodel.Title;
            }
            catch
            { 
            
            }
            return rolename;
        }
        #endregion

        #region 事件
        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            hidCheck.Value = "false";
            buildGrid(pageSize, Pager.CurrentPageIndex);
        }

        protected void rptUser_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HiddenField hidid = (HiddenField)e.Item.FindControl("hidid");
            string uid = hidid.Value;
            if (e.CommandName == "delete")
            {
                aubll.Delete(uid);
                aurbll.Delete(uid);
            }

            buildGrid(pageSize, Pager.CurrentPageIndex);
        }

        #endregion
    }
}