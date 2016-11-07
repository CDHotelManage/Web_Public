using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.Menus2
{
    public partial class RoomNumberInfo : System.Web.UI.Page
    {
        BLL.room_type fmtype = new BLL.room_type();
        public int pageSize = 10;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                BindGV();
            }
        }
   
        /// <summary>
        /// 删除
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
            BindGV();
            
        }
        public void BindGV() 
        {
            string sort = "id";
            string order = "DESC";
            int currentPage = Pager.CurrentPageIndex;
            IList<Model.room_type> list = fmtype.GetBookRoomPager(sort, order, currentPage, pageSize, " where 1=1");
            GrdCostRoom.DataSource = list;
            GrdCostRoom.DataBind();
           
        }
        /// <summary>
        /// 单个删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btndelone_Click(object sender, EventArgs e)
        {
            int id =Convert.ToInt32( txt_hidid.Value);
            if (fmtype.Delete(id))
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('删除成功！');</script>");

            }
            else 
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('删除失败！');</script>");

            }
            BindGV();
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
           // BindGv(pageSize, Pager.CurrentPageIndex);
        }

    }
}