using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace CdHotelManage.Web.Admin.Permissions.menu
{
    public partial class menulist : System.Web.UI.Page
    {
        private int pageSize = 10;
        private int pageIndex = 1;
        private readonly BLL.MenuBLL menubll = new BLL.MenuBLL ();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hidSort.Value = "sortId";
                hidOrder.Value = "ASC";
                hidCheck.Value = "false";

                ViewState["pid"] = "0";
                buildGrid(pageSize, pageIndex);
            }
        }

       
        private void buildGrid(int pageSize, int pageindex)
        {

            string sort = hidSort.Value;
            string order = hidOrder.Value;
            int currentPage = Pager.CurrentPageIndex;



            rptMenu.DataSource = menubll.GetMenuPager(sort, order, currentPage, pageSize, int.Parse(ViewState["pid"].ToString()));
            rptMenu.DataBind();


            Pager.RecordCount = menubll.GetRecordCount(" parent_id=" + int.Parse(ViewState["pid"].ToString()));
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
        //获取名称
        public string GetName(string did)
        {
            string name = "";
            if (did == "0")
            {
                name = "无";
            }
            else
            {
                Model.Menu d = menubll.GetModel(int.Parse(did));
                if (d != null)
                {
                    name = d.title;
                }
                else
                {
                    name = "不存在";
                }
            }
            return name;
        }
        

        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            hidCheck.Value = "false";
            buildGrid(pageSize, Pager.CurrentPageIndex);
        }

        protected void rptMenu_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HiddenField hidid = (HiddenField)e.Item.FindControl("hidid");
            int menu_id = Convert.ToInt32(hidid.Value);
            if (e.CommandName == "delete")
            {
                DataTable dt = menubll.GetList("parent_id =" + menu_id).Tables[0];
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //删除图片（子菜单）
                        File.Delete(Server.MapPath(dt.Rows[i]["imgurl"].ToString()));
                        //删除数据
                        menubll.Delete(Convert.ToInt32(dt.Rows[i]["menu_id"].ToString()));
                    }
                }
                //删除图片
                Model.Menu model = menubll.GetModel(menu_id);
                File.Delete(Server.MapPath(model.imgurl));
                //删除数据
                menubll.Delete(menu_id);
            }

            if (e.CommandName == "look")
            {
                ViewState["pid"] = e.CommandArgument;
            }

            buildGrid(pageSize, Pager.CurrentPageIndex);
        }
       
    }
}