using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using LTP.Accounts.Bus;
namespace CdHotelManage.Web.Admin.RoomGustkr
{
    public partial class RoomkrSelect : System.Web.UI.Page
    {
        //页数
        private int pageSize = 10;
        //第几页开始
        private int pageIndex = 1;
        //当前页合计
        public int SumNowRealNum = 0;
        //合计已住天数
        public int Day = 0;
        //合计房价
        public double FjMoney = 0;
        //合计收款
        public double SKMoney = 0;
        //合计产生金额
        public double CSGZMoney = 0;
        //合计消费
        public double XFMoney = 0;
        //合计余额
        public double YEMoney = 0;
        //合计总已住天数
        public int Days = 0;
        //合计总房价
        public double FjMoneys = 0;
        //合计总收款
        public double SKMoneys = 0;
        //合计总产生金额
        public double CSGZMoneys = 0;
        //合计总消费
        public double XFMoneys = 0;
        //合计总余额
        public double YEMoneys = 0;
        //预定房间总合计
        public int SumRealNum = 0;
        BLL.occu_infor brBll = new BLL.occu_infor();
        BLL.room_state fmft = new BLL.room_state();
        BLL.goods_account fmgoods = new BLL.goods_account();
        BLL.room_number fmroom = new BLL.room_number();
        protected StringBuilder sbHtml = new StringBuilder();
        public string stwhere
        {

            get { return (string)ViewState["stwhere"]; }

            set { ViewState["stwhere"] = value; }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                ldDays(System.DateTime.Now);
                BindGv(pageSize, pageIndex);
            }
        }
       
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void button02_Click(object sender, EventArgs e)
        {
            BindGv(pageSize, pageIndex);
            if (ddlState.SelectedValue == "4")
            {
                btndisplay.Style.Add("display", "");
                btndisplay.Value = "撤销挂单";
                btnGuadan.Style.Add("display", "");
            }
           else if (ddlState.SelectedValue == "3")
            {
                btndisplay.Style.Add("display", "");
                btndisplay.Value = "撤销结账";
                btnGuadan.Style.Add("display", "none");
            }
            else 
            {
                btnGuadan.Style.Add("display", "none");
                btndisplay.Style.Add("display", "none");
            }   
          
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            BindGv(pageSize, Pager.CurrentPageIndex);
        }
        public string orsort = "";
        //根据条件分页查询
        public void BindGv(int pageSize, int pageindex)
        {
          
            Shwere();
            string sort = "order_id";
            string order = "DESC";
            int currentPage = Pager.CurrentPageIndex;
             IList<Model.occu_infor> list = brBll.GetBookRoomPager(sort, order, currentPage, pageSize, stwhere);
             foreach (Model.occu_infor item in list)
             {
                 if (orsort == "")
                 {
                     orsort = item.occ_id.ToString();
                 }
                 else
                 {
                     orsort += "," + item.occ_id.ToString();
                 }
             }
             if (list.Count > 0)
             { 
                 GetListRoom(list);
               
             }
             #region

             DataSet dt = brBll.GetLists(stwhere);
             foreach (DataRow dr in dt.Tables[0].Rows) 
             {
                 try
                 {
                     if (dr["amount_rece"] == null || dr["amount_rece"].ToString() == "") 
                     {
                         dr["amount_rece"] = 0;
                     }
                     if (dr["amount_money"] == null || dr["amount_money"].ToString() == "")
                     {
                         dr["amount_money"] = 0;
                     }
                     //Days += ldDays(Convert.ToDateTime(dr["occ_time"].ToString()));
                     //FjMoneys += Convert.ToDouble(dr["real_price"]);
                     //CSGZMoneys += GetFZ(ldDays(Convert.ToDateTime(dr["occ_time"].ToString())), dr["real_price"]);
                     //YEMoneys += GetYE(dr["occ_no"]);
                     //SKMoneys += GetSK(dr["occ_no"]);
                     //XFMoneys += GetXF(dr["occ_no"]);
                 }
                 catch { }
             }
             
            
             
             Pager.RecordCount = brBll.GetRecordCount(stwhere);
             Pager.ShowCustomInfoSection = Wuqi.Webdiyer.ShowCustomInfoSection.Right;
             //Pager.PageSize = pageSize;
             //Pager.CurrentPageIndex = pageindex;
             #endregion
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
        public void  Shwere() 
        {
            stwhere = " WHERE 1=1 and occ_with='否' and state_id not in (1,2)  ";
            if (ddlState.SelectedIndex > 0)
                stwhere += " AND state_id = " + ddlState.SelectedValue + "";
            if (book_no.Value.Length > 0) 
            {
                stwhere += " and occ_no='" + book_no.Value + "'";
            }
            if (txt_fh.Value.Length > 0) 
            {
                stwhere += " and room_number='" + txt_fh.Value + "'";
            } if (txt_name.Value.Length > 0) 
            {
                stwhere += " and occ_name like'%" + txt_name.Value + "%'";
            }
            if (Request.QueryString["accounts"]!=null) {
                stwhere += "and accounts='" + Request.QueryString["accounts"] + "' ";
            }
        }

        //获得房型名称
        public string GetRealTypeName(int id)
        {
            BLL.room_type rtbll = new BLL.room_type();
            Model.room_type model = rtbll.GetModel(Convert.ToInt32(id.ToString()));
            return model.room_name;
        }
        /// <summary>
        /// 产生房租
        /// </summary>
        /// <returns></returns>
        public double GetFZ(object Day, object Money) 
        {
            double ZongMoney = 0;
            ZongMoney = Convert.ToInt32(Day) * Convert.ToDouble(Money);
            return ZongMoney;
        }
        /// <summary>
        /// 余额
        /// </summary>
        /// <returns></returns>
        public double GetYE(object OccNo)
        {
            double ZongMoney = 0;
            double shoukuan = 0;
            double XFMoney = 0;
            IList<Model.goods_account> list = fmgoods.GetModelList1(" ga_occuid='" + OccNo + "'");
            for (int i = 0; i < list.Count; i++)
            {
                try
                {
                    XFMoney += Convert.ToDouble((list[i].ga_price));
                    shoukuan += Convert.ToDouble((list[i].ga_sum_price));
                }
                catch { }


            }
            ZongMoney = XFMoney - shoukuan;
            return ZongMoney;
        }
        /// <summary>
        /// 获取消费
        /// </summary>
        /// <param name="OccNo"></param>
        public double GetXF(object OccNo) 
        {
            double XFMoney = 0;

            IList<Model.goods_account> list = fmgoods.GetModelList1(" ga_occuid='" + OccNo + "' and ga_Type in(0,1)");
            for (int i = 0; i < list.Count; i++)
            {
                try
                {
                    XFMoney += Convert.ToDouble((list[i].ga_sum_price));
                }
                catch { }
                

            }
            return XFMoney;
        }
        /// <summary>
        /// 获取收款
        /// </summary>
        /// <param name="OccNo"></param>
        public double GetSK(object OccNo)
        {
            double shoukuan = 0;

            IList<Model.goods_account> list = fmgoods.GetModelList1(" ga_occuid='" + OccNo + "'");
            for (int i = 0; i < list.Count; i++)
            {
                try
                {
                    shoukuan += Convert.ToDouble((list[i].ga_price));
                }
                catch { }

            }
            return shoukuan;
        }
        /// <summary>
        /// huoqutianshu
        /// </summary>
        /// <param name="occ_time"></param>
        /// <returns></returns>
        public int ldDays(DateTime occ_time) 
        {
            //int a = (Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd")) - Convert.ToDateTime(occ_time.ToString("yyyy-MM-dd"))).Days;
            //(d1 - d2).Days
            int a = (System.DateTime.Now - occ_time).Days;
            if (a == 0) 
            {
                a = 1;
            }
            return a;
        }

        #region 获得列表
        private void GetListRoom(IList<Model.occu_infor> list)
        {
            string a = "";
            int Count = 0;
            int scont = 0;
            
            foreach (Model.occu_infor room in list)
            {
                
                    Count = brBll.GetRecordCount(" " + stwhere + " and order_id='" + room.order_id + "' and occ_id in(" + orsort + ") ");
                    sbHtml.Append("<tr class=\"tr1 trtop\" State_Id="+room.state_id+" orrderID=" + room.order_id + " bookno=" + room.occ_no + ">");
                    if (a != room.order_id) 
                    {
                        a = "";
                    }
                    if (Count==1)
                    {
                        sbHtml.Append("<td rowspan=\"" + Count + "\">" + room.occ_no + "</td>");
                        sbHtml.Append("<td><input type=\"checkbox\"   class=\"cbxCheck\"><input type=\"hidden\" class=\"cbxCheck\" value=\"" + room.occ_id + "\"></td>");
                        sbHtml.Append("<td ><a onclick=\"Bookchakan(this,"+room.occ_id+")\" href='#'>" + room.occ_no + "</a></td>");
                        sbHtml.Append("<td>" + room.room_number + "</td>");
                        sbHtml.Append("<td>" + GetRealTypeName(room.real_type_id) + "</td>");
                        sbHtml.Append("<td>" + room.occ_name + "</td>");
                        sbHtml.Append("<td>" + room.phonenum + "</td>");
                        sbHtml.Append("<td>" + room.occ_time + "</td>");
                        sbHtml.Append("<td>" + room.depar_time + "</td>");
                        sbHtml.Append("<td>" + room.Occ_TfTime + "</td>");
                        sbHtml.Append("<td>" + ldDays(room.occ_time) + "</td>");
                        sbHtml.Append("<td>" + room.real_price.ToString("0.##") + "</td>");
                        sbHtml.Append("<td>" + GetFZ(ldDays(room.occ_time), room.real_price) + "</td>");
                        sbHtml.Append("<td class='sk' rowspan=\"" + Count + "\">" + GetSK(room.order_id) + "</td>");
                        sbHtml.Append("<td class='xf' rowspan=\"" + Count + "\">" + GetXF(room.order_id) + "</td>");
                        sbHtml.Append("<td class='yue' rowspan=\"" + Count + "\">" + GetYE(room.order_id) + "</td>");
                        sbHtml.Append("</tr>");
                        SKMoney += GetSK(room.order_id);
                        XFMoney += GetXF(room.order_id);
                        YEMoney += GetYE(room.order_id);
                    }
                    else 
                    {
                        if (a == "")
                        {
                            sbHtml.Append("<td rowspan=\"" + Count + "\">" + room.occ_no + "</td>");
                            //a = room.order_id;

                        }
                       
                        sbHtml.Append("<td ><input type=\"checkbox\"  class=\"cbxCheck\"><input type=\"hidden\" class=\"cbxCheck\" value=\"" + room.occ_id + "\"></td>");
                        sbHtml.Append("<td ><a  onclick=\"Bookchakan(this," + room.occ_id + ")\" href='#'>" + room.occ_no + "</a></td>");
                        sbHtml.Append("<td>" + room.room_number + "</td>");
                        sbHtml.Append("<td>" + GetRealTypeName(room.real_type_id) + "</td>");
                        sbHtml.Append("<td>" + room.occ_name + "</td>");
                        sbHtml.Append("<td>" + room.phonenum + "</td>");
                        sbHtml.Append("<td>" + room.occ_time + "</td>");
                        sbHtml.Append("<td>" + room.depar_time + "</td>");
                        sbHtml.Append("<td>" + room.Occ_TfTime + "</td>");
                        sbHtml.Append("<td>" + ldDays(room.occ_time) + "</td>");
                        sbHtml.Append("<td>" + room.real_price.ToString("0.##") + "</td>");
                        sbHtml.Append("<td>" + GetFZ(ldDays(room.occ_time), room.real_price) + "</td>");
                        if (a == "")
                        {
                            a = room.order_id;

                       
                        sbHtml.Append("<td class='sk' rowspan=\"" + Count + "\">" + GetSK(room.order_id) + "</td>");
                        sbHtml.Append("<td class='xf' rowspan=\"" + Count + "\">" + GetXF(room.order_id) + "</td>");
                        sbHtml.Append("<td class='yue' rowspan=\"" + Count + "\">" + GetYE(room.order_id) + "</td>");
                        SKMoney += GetSK(room.order_id);
                        XFMoney += GetXF(room.order_id);
                        YEMoney += GetYE(room.order_id);
                        }
                        sbHtml.Append("</tr>");
                    }
                    scont++;
                    Day += ldDays(room.occ_time);
                    //FjMoney += Convert.ToDouble(room.real_price);
                    
                    CSGZMoney += GetFZ(ldDays(room.occ_time), room.real_price);
                    
            }
            string acc = sbHtml.ToString();
        }

        BLL.goods_account bllga = new BLL.goods_account();
        #endregion
        /// <summary>
        /// 撤销结账
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btncxSava_Click(object sender, EventArgs e)
        {
            if (ddlState.SelectedValue == "4")
            {
                string SQls = "update room_number set Rn_state=2 where Rn_roomNum='" + brBll.GetModel(Convert.ToInt32(txt_room.Value)).room_number + "'";
                string strs = "update occu_infor set state_id='0', tuifaId='0',occ_TfTime=null where occ_id=" + txt_room.Value + "";

                if (fmroom.Updates(SQls) && brBll.Updates(strs))
                {
                    Maticsoft.Common.MessageBox.ShowAndRedirect(this, "撤销挂单成功！", "");
                }
            }
            else
            {
                List<Model.goods_account> listga = bllga.GetModelList1("ga_occuid='" + brBll.GetModel(Convert.ToInt32(txt_room.Value)).order_id + "' and ga_isjz=1");
                if (listga != null && listga.Count > 0)
                {
                    Maticsoft.Common.MessageBox.ShowAndRedirect(this, "已交班不能撤销结账！", "");
                }
                else
                {
                    string strsql = "update goods_account set ga_sfacount='否' where ga_occuid='" + brBll.GetModel(Convert.ToInt32(txt_room.Value)).order_id + "'";
                    string SQl =string.Empty;
                    if (rooms.Value != "")
                    {
                        SQl = "update room_number set Rn_state=2 where Rn_roomNum in(" + rooms.Value + ")";
                    }
                    string strs = "update occu_infor set state_id='0', tuifaId='0' where order_id=" + brBll.GetModel(Convert.ToInt32(txt_room.Value)).order_id + "";
                    string SQls = "delete from goods_account where ga_Type in(4,6) and ga_occuid='" + brBll.GetModel(Convert.ToInt32(txt_room.Value)).order_id + "'";
                    if (fmroom.Updates(SQl) && brBll.Updates(strs))
                    {
                        fmgoods.Updates(strsql);
                        fmgoods.Deletes(SQls);
                        string up=rooms.Value.Replace("'","");
                        Helper.AddRoom(brBll.GetModel(Convert.ToInt32(txt_room.Value)).room_number, up + ",");
                        Maticsoft.Common.MessageBox.ShowAndRedirect(this, "撤销结账成功！", "");

                    }
                    else
                    {
                        Maticsoft.Common.MessageBox.ShowAndRedirect(this, "撤销结账失败！", "");
                    }
                }
            }
           
        }

       
    }

}