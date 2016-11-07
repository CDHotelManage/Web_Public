using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace CdHotelManage.Web.Admin.banner
{
    public partial class bannerlist : System.Web.UI.Page
    {
        private int pageSize = 10;
        private int pageIndex = 1;
        BLL.bannerBLL bannerbll = new BLL.bannerBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hidSort.Value = "sortId";
                hidOrder.Value = "asc";
                hidCheck.Value = "false";
                buildGrid(pageSize, pageIndex);
            }
        }


        private void buildGrid(int pageSize, int pageindex)
        {

            string sort = hidSort.Value;
            string order = hidOrder.Value;
            int currentPage = Pager.CurrentPageIndex;



            rptBanner.DataSource = bannerbll.GetBannerPager(sort, order, currentPage, pageSize);
            rptBanner.DataBind();


            Pager.RecordCount = bannerbll.GetRecordCount("");
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


        #region 事件
        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            hidCheck.Value = "false";
            buildGrid(pageSize, Pager.CurrentPageIndex);
        }

        protected void rptBanner_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HiddenField hidid = (HiddenField)e.Item.FindControl("hidid");
            string banner_id = hidid.Value;
            if (e.CommandName == "delete")
            {
                Model.banner model = bannerbll.GetModel(banner_id);
                if (model != null)
                {
                    File.Delete(Server.MapPath(model.imgurl));
                }
                bannerbll.Delete(banner_id);
            }

            buildGrid(pageSize, Pager.CurrentPageIndex);
        }

        #endregion

        
    }
}