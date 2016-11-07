using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.Menus2
{
    public partial class RoomsAllInfo : System.Web.UI.Page
    {
        private int pageIndex = 1;
        BLL.room_number fmtype = new BLL.room_number();
        BLL.floor_ld fmld = new BLL.floor_ld();
        BLL.floor_manage fmlc = new BLL.floor_manage();
        public int pageSize = 20;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGV(pageSize,pageIndex);
            }
        }

        /// <summary>
        /// 删除23
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (fmtype.DeleteList(txt_allids.Value))
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('删除成功！');</script>");

            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('删除失败！');</script>");

            }
            BindGV(pageSize, Pager.CurrentPageIndex);

        }
        public void BindGV(int pageSize, int CurrentPageIndex)
        {
            string sort = "id";
            string order = "asc";
            int currentPage = Pager.CurrentPageIndex;
            GrdCostRoom.DataSource = fmtype.GetBookRoomPager(sort, order, currentPage, pageSize, " where 1=1");
            Pager.RecordCount = fmtype.GetRecordCount("1=1");
            Pager.ShowCustomInfoSection = Wuqi.Webdiyer.ShowCustomInfoSection.Right;
            Pager.PageSize = 20;
            GrdCostRoom.DataBind();
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
        /// <summary>
        /// 单个删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btndelone_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txt_hidid.Value);
            if (fmtype.Delete(id))
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('删除成功！');</script>");

            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('删除失败！');</script>");

            }
            BindGV(pageSize, Pager.CurrentPageIndex);
        }
        /// <summary>
        /// 一行一行执行事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GrdCostRoom_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSerch_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            BindGV(pageSize, Pager.CurrentPageIndex);
        }
        //获得房型名称
        public string GetRealTypeName(int id)
        {

            BLL.room_type rtbll = new BLL.room_type();
            Model.room_type model = rtbll.GetModel(Convert.ToInt32(id.ToString()));
            string a = rtbll.GetModel(Convert.ToInt32(id.ToString())).room_name;
            return model.room_name;


        }
        //获得楼层
        public string GetRealTypelcmname(int id)
        {

            BLL.floor_manage rtbll = new BLL.floor_manage();
            Model.floor_manage model = rtbll.GetModel(Convert.ToInt32(id.ToString()));
            string a = rtbll.GetModel(Convert.ToInt32(id.ToString())).floor_name;
            return model.floor_name;
        }
        //获得楼层
        public string GetRealTypeld(int id)
        {

           
            Model.floor_ld model = fmld.GetModel(Convert.ToInt32(id.ToString()));
            return model.ld_Name;


        }
    }
}