using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CdHotelManage.Model;
using CdHotelManage.BLL;
using System.Data;
using System.Text;
using LTP.Accounts.Bus;

namespace CdHotelManage.Web.Admin.Book
{
    
              
    public partial class BookList : BasePageVaile,System.Web.SessionState.IRequiresSessionState
    {
        protected StringBuilder sbHtml = new StringBuilder();
        BLL.book_room brBll = new BLL.book_room();
        BLL.room_state rtBll = new BLL.room_state();
        BLL.Book_Rdetail brdBll = new BLL.Book_Rdetail();
        private int pageSize = 10;
        private int pageIndex = 1;

        //当前页合计
        public int SumNowRealNum = 0;
        //预定房间总合计
        public int SumRealNum = 0;
        BLL.BookState bllbs = new BLL.BookState();
        //状态下拉框绑定
        public void RoomStateBind()
        {
            //状态下拉框绑定
            RoomStateDdl.DataSource = bllbs.GetList("id>0 order by ID desc");
            RoomStateDdl.DataValueField = "ID";
            RoomStateDdl.DataTextField = "statName";
            RoomStateDdl.DataBind();
            
        }
        //根据条件分页查询
        public void BookDataBind(int pageSize, int pageindex)
        {

            string sort = "book_id";
            string order = "DESC";
            int currentPage = Pager.CurrentPageIndex;

            string strWhere = " WHERE 1=1 ";
  
            if (this.book_name.Value.Trim().Length > 0)
                strWhere += " AND book_Name LIKE '%" + this.book_name.Value.Trim() + "%'";

            if (this.date1.Value.Trim().ToString().Length > 0 && this.date2.Value.Trim().ToString().Length > 0)
                strWhere += "AND  CONVERT(VARCHAR(100), time_to, 23)   >= '" + this.date1.Value.Trim() + "' and CONVERT(VARCHAR(100), time_to, 23)  <= '" + this.date2.Value.Trim() + "'";

            if(this.book_no.Value.Trim().Length > 0)
                strWhere += " AND book_no LIKE '%" + this.book_no.Value.Trim() + "%'";

            if (this.tele_no.Value.Trim().Length > 0)
                strWhere += " AND tele_no LIKE '%" + this.tele_no.Value.Trim() + "%'";
            if (!IsPostBack) {
               string value1= this.RoomStateDdl.Items.FindByText("普通预定").Value;
               string value2 = this.RoomStateDdl.Items.FindByText("确认预定").Value;
               strWhere += " AND (state_id IN ('" + value1 + "','" + value2 + "')) ";
            }
            else
            {
                if (this.RoomStateDdl.SelectedValue.Trim().Length > 0)
                    if (this.RoomStateDdl.SelectedValue.Trim() != "全部")
                        strWhere += " AND (state_id IN (SELECT state_id FROM room_state WHERE state_id='" + this.RoomStateDdl.SelectedValue.Trim() + "')) ";
            }
            if (this.fengfangddl.SelectedValue.Trim() == "是")
                strWhere += " AND room_number IS NOT NULL";

            if (this.fengfangddl.SelectedValue.Trim() == "否")
                strWhere += " AND room_number IS NULL";

            IList<Model.book_room> list = brBll.GetBookRoomPager(sort, order, currentPage, pageSize, strWhere);
            if (list.Count> 0)
            {
                foreach (Model.book_room item in list)
                {
                    item.ListBr = brdBll.GetListModel("Book_no='" + item.book_no + "'");
                }
                GetListRoom(list);
            }
            Pager.RecordCount = sum;
            Pager.ShowCustomInfoSection = Wuqi.Webdiyer.ShowCustomInfoSection.Right;
            //Pager.PageSize = pageSize;
            //Pager.CurrentPageIndex = pageindex;
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

            return;
        }


        protected int sum = 0;

        #region 获得列表
        private void GetListRoom(IList<Model.book_room> list)
        {
            foreach (Model.book_room room in list)
            {
                if (room.ListBr.Count >= 1)
                {
                    sbHtml.Append("<tr class=\"tr1 trtop\" bookno=" + room.book_no + " id=" + room.book_id + " rooms=" + room.ListBr[0].Room_number + ">");
                    sbHtml.Append("<td rowspan=\"" + room.ListBr.Count + "\">" + room.book_no + "</td>");
                    sbHtml.Append("<td><input type=\"checkbox\" class=\"cbxCheck1\"><input type=\"hidden\" class=\"cbxCheck\" value=\"" + room.ListBr[0].Room_number + "\"></td>");
                    sbHtml.Append("<td>" + GetRoomStateName(room.ListBr[0].RoomTypeID) + "</td>");
                    sbHtml.Append("<td>" + room.ListBr[0].Room_number + "</td>");
                    sbHtml.Append("<td>" + GetRealTypeName(room.ListBr[0].Real_type_Id) + "</td>");
                    sbHtml.Append("<td>" + room.ListBr[0].Real_num + "</td>");
                    sbHtml.Append("<td>" + room.ListBr[0].Ok_num + "</td>");
                    sbHtml.Append("<td rowspan=\"" + room.ListBr.Count + "\">" + room.time_to + "</td>");
                    sbHtml.Append("<td rowspan=\"" + room.ListBr.Count + "\">" + room.real_time + "</td>");
                    sbHtml.Append("<td rowspan=\"" + room.ListBr.Count + "\">" + room.book_Name + "</td>");
                    sbHtml.Append("<td rowspan=\"" + room.ListBr.Count + "\">" + room.tele_no + "</td>");
                    sbHtml.Append("<td class=\"tdstate\" rowspan=\"" + room.ListBr.Count + "\">" + GetRoomStateName(room.state_id) + "</td>");
                    sbHtml.Append("<td rowspan=\"" + room.ListBr.Count + "\">" + GetSourceTypeName(room.source_id) + "</td>");
                    sbHtml.Append("<td rowspan=\"" + room.ListBr.Count + "\">" + room.deposit + "</td>");
                    //sbHtml.Append("<td rowspan=\"" + room.ListBr.Count + "\">" + GetRoomStateName(room.state_id) + "</td>");
                    if (room.state_id == 5 || room.state_id ==2)
                    {
                        sbHtml.Append("<td  rowspan=\"" + room.ListBr.Count + "\"><span class=\"fontblue\"><a href=\"#\" onclick=\"BookAdds(this,'edit'," + room.book_id + ")\">查看</a></span></td>");
                    }
                    else
                    {
                        sbHtml.Append("<td rowspan=\"" + room.ListBr.Count + "\"><span class=\"fontblue\"><a  href=\"#\" class=\"aedit\" onclick=\"BookAdd1(this,'edit'," + room.book_id + ")\">[编缉]</a> <a href=\"#\"  onclick=\"BookEancel(this," + room.book_id + ")\">[取消]</a></span></td>");
                    }
                    sbHtml.Append("</tr>");
                }
                if (room.ListBr.Count > 1)
                {
                    for (int i = 1; i < room.ListBr.Count; i++)
                    {

                        sbHtml.Append("<tr class=\"tr1 trtop\" bookno=" + room.book_no + " id=" + room.book_id + ">");
                        sbHtml.Append("<td><input type=\"checkbox\" class=\"cbxCheck1\"><input type=\"hidden\" class=\"cbxCheck\" value=\"" + room.ListBr[i].Room_number + "\"></td>");
                        sbHtml.Append("<td>" + GetRoomStateName(room.ListBr[i].RoomTypeID) + "</td>");
                        sbHtml.Append("<td>" + room.ListBr[i].Room_number + "</td>");
                        sbHtml.Append("<td>" + GetRealTypeName(room.ListBr[i].Real_type_Id) + "</td>");
                        sbHtml.Append("<td>" + room.ListBr[i].Real_num + "</td>");
                        sbHtml.Append("<td>" + room.ListBr[i].Ok_num + "</td>");
                        sbHtml.Append("</tr>");
                    }
                }
            }
        }
        #endregion


        /// <summary>
        /// 通过预定单号获得所有的房型
        /// </summary>
        private void GetDetileRoom() { 
          
        }

        #region 根据ID转换成中文名
        //获得房型名称
        public string GetRealTypeName(object id)
        {
            if (id.ToString() == "")
            {
                return "";
            }
            BLL.room_type rtbll = new BLL.room_type();

            Model.room_type model = rtbll.GetModel(Convert.ToInt32(id.ToString()));

            if (model != null)
            {
                if (model.room_name != null)
                {
                    if (model.room_name == "")
                    {
                        return "";
                    }
                }

                return model.room_name;

            }
            return "";
        }

        //获得客人来源中文名称

        public string GetSourceTypeName(object id)
        {
            if (id.ToString() == "")
            {
                return "";
            }
            BLL.guest_source gsbll = new BLL.guest_source();
            Model.guest_source model = gsbll.GetModel(Convert.ToInt32(id.ToString()));
            return model.gs_name;
           

        }

         //获得房间状态中文名称
        public string GetRoomStateName(object id)
        {
            if (id.ToString() == " ")
            {
                return "";
            }
            else
            {

                BLL.BookState rsbll = new BLL.BookState();
                Model.BookState model = rsbll.GetModel(Convert.ToInt32(id.ToString()));
                return model.statName;
            }

        }

        #endregion

        protected void button02_Click(object sender, EventArgs e)
        {
       
            BookDataBind(pageSize, pageIndex);
        }

        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            BookDataBind(pageSize, Pager.CurrentPageIndex);
        }
        public string Panduan(object State) 
        {
            if (Convert.ToInt32(State) == 1)
            {
                return "<span onclick='Openupdate(this,'')' class='fontblue'><a href='#' onclick='Openupdate(this,'')'>[编缉]</a> <a href='#'>[取消]</a></span>";
            }
            else 
            {
               return " <span onclick='Openupdate(this,'')' class='fontblue'><a  href='#'>[查看]</a></span>";
             

            }
        }


        public override void SonLoad()
        {
            sum = brBll.GetModelList("").Count;
            if (!IsPostBack)
            {
                
                 sbHtml.Clear();
                 RoomStateBind();
                 BookDataBind(pageSize, pageIndex);
            }
        }
    }
}
