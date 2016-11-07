using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
namespace CdHotelManage.Web.Admin.Menus
{
    public partial class price : System.Web.UI.Page
    {
        BLL.cost_type fmcost = new BLL.cost_type();
        protected StringBuilder sbHtml = new StringBuilder();
        private int pageSize = 10;
        private int pageIndex = 1;
        public string stwhere
        {

            get { return (string)ViewState["stwhere"]; }

            set { ViewState["stwhere"] = value; }

        }
        public string ids
        {

            get { return (string)ViewState["ids"]; }

            set { ViewState["ids"] = value; }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                ids ="";
                Bind();
                BindGv(pageSize, pageIndex);
            }
        }
        /// <summary>
        /// 费用大类录入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            //string id = "";
            Model.cost_type frmfysz = new Model.cost_type();
            frmfysz.ct_name = txt_name.Value;
            string MaxNumber = fmcost.GetMaxNumber(" where ct_iftype=0").ToString().Trim();
            if (MaxNumber == "1")
            {
                frmfysz.ct_number = "0001";
            }
            else
            {
                frmfysz.ct_number = "000" + (Convert.ToInt32(MaxNumber) + 1);
            }
            frmfysz.ct_iftype = 0;
            if (ids == "")
            {
                int Result = fmcost.Add(frmfysz);
                if (Result > 0)
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('保存成功');parent.Window_Close();</script>");
                 //   alert('保存成功');parent.document.getElementById('btnsercher').click();parent.Window_Close();
                    Bind();
                    BindGv(pageSize, pageIndex);
                }
            }
            else
            {
                frmfysz.id = Convert.ToInt32(ids);
                if (fmcost.Update(frmfysz))
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('更新成功');parent.Window_Close();</script>");

                }
            }
        }

        public void Bind()
        {
            txt_name.Value = "";
            string Content = "<ul><li onclick=\"ShowDiv('0')\" style=\"background:#4486b7; color:#fff; \">&nbsp;&nbsp;&nbsp;全部</li>";
            DataSet dt = fmcost.GetList(" ct_iftype=0");
            foreach (DataRow dr in dt.Tables[0].Rows)
            {
                Content += "<li class=\"lis\" onclick=\"ShowDiv('"+dr["id"]+"',this)\">&nbsp;&nbsp;&nbsp;" + dr["ct_name"] + "<a href='#' class=\"dela\" onclick='deletes(" + dr["id"] + ")'><img src='../../images/scicon.png' width='14' height='16' /></a><a class=\"modif\" onclick=\"Goodsupa(this," + dr["id"] + ",1)\" href='#'><img src='../../images/bj_icon.png' width='14' height='16' /></a></li>";
            }
            Content += "</ul>";
            DivHrml.InnerHtml = Content;

        }
        public string TrContent = "";
      
        //根据条件分页查询
        public void BindGv(int pageSize, int pageindex)
        {

            Shwere();
            string sort = "id";
            string order = "DESC";
            int currentPage = Pager.CurrentPageIndex;
            IList<Model.cost_type> list = fmcost.GetBookRoomPager(sort, order, currentPage, pageSize, stwhere);
            if (list.Count > 0)
            {
                GetListRoom(list);
            }
            
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
        //查询条件
        public void Shwere()
        {

            stwhere = " WHERE 1=1 and ct_iftype=1 ";
            if (txt_NumberName.Value.Length > 0)
            {

                stwhere += " and (ct_number like '%" + txt_NumberName.Value + "%' or ct_name like '%" + txt_NumberName.Value + "%')";
            }
            

        }
        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            BindGv(pageSize, Pager.CurrentPageIndex);
        }
        #region 获得列表
        private void GetListRoom(IList<Model.cost_type> list)
        {

            foreach (Model.cost_type room in list)
            {
                sbHtml.Append("<tr class=\"tr1 trtop\">");
                sbHtml.Append("<td>" + room.ct_number + "</td>");
                sbHtml.Append("<td>" + room.ct_name + "</td>");
                sbHtml.Append("<td>" + Getname( Convert.ToInt32(room.ct_categories)) + "</td>");
                sbHtml.Append("<td>" + Convert.ToDecimal(room.ct_money).ToString("0.##") + "</td>");
                sbHtml.Append("<td><span class=\"fontblue\"><a  href=\"#\" class=\"aedit\" onclick=\"openupadd(this," + room.id + ",1)\">[编缉]</a> <a href=\"#\"  onclick=\"BookEancel("+ room.id + ")\">[删除]</a></span></td>");

                sbHtml.Append("</tr>");
            }

              
        }
        #endregion

        private string Getname(int cid) {
            return fmcost.GetModel(cid).ct_name;
        }
        /// <summary>
        /// 编辑显示
        /// </summary>
        public void BindEdit() 
        {
           // txt_name.Value =fmcost.GetModel(ids);
            
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btndelete1_Click(object sender, EventArgs e)
        {
            if (fmcost.Delete(Convert.ToInt32(txt_id.Value)))
            {
                Maticsoft.Common.MessageBox.ShowAndRedirect(this, "删除成功！", "");
                BindGv(pageSize, pageIndex);
            }
            else 
            {
                Maticsoft.Common.MessageBox.ShowAndRedirect(this, "删除失败！", "");
            }
           
        }
        /// <summary>
        /// 删除大类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btndelete_Click(object sender, EventArgs e)
        {
            if (fmcost.Delete(Convert.ToInt32(txt_id.Value)))
            {
                Maticsoft.Common.MessageBox.ShowAndRedirect(this, "删除成功！", "");
                BindGv(pageSize, pageIndex);
            }
            else
            {
                Maticsoft.Common.MessageBox.ShowAndRedirect(this, "删除失败！", "");
            }
        }
        /// <summary>
        /// 查询语句
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void button02_Click(object sender, EventArgs e)
        {
            BindGv(pageSize, pageIndex);
        }

    }
}