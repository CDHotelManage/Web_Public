using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CdHotelManage.BLL;
using CdHotelManage.Model;

namespace CdHotelManage.Web.Admin.Book
{
    public partial class Book_Add : BasePageVaile
    {
        BLL.guest_source gsBll = new BLL.guest_source();
        BLL.meth_pay mpBll = new BLL.meth_pay();
        BLL.room_type rtBll = new BLL.room_type();
        BLL.hourse_scheme hsBll = new BLL.hourse_scheme();
        BLL.book_room bllbr = new BLL.book_room();
        BLL.Book_Rdetail bllrd = new BLL.Book_Rdetail();
        int id = 0;
        Model.book_room nowModel = new Model.book_room();
        protected System.Text.StringBuilder sbDel = new System.Text.StringBuilder();
        


        private string Geta(List<Model.Book_Rdetail> listbr) {
            System.Text.StringBuilder sbs = new System.Text.StringBuilder();
            foreach (Model.Book_Rdetail model in listbr)
            {
                sbs.Append("<a>" + model.Room_number + "</a> ");
            }
            return sbs.ToString();
        }

        /// <summary>
        /// 获得所有房间类型
        /// </summary>
        private void GetAllType(Model.Book_Rdetail modelbr) {
            List<Model.room_type> listrt = rtBll.GetModelList("");
            foreach (Model.room_type model in listrt)
            {
                if (model.id == modelbr.Real_type_Id)
                {
                    sbDel.Append("<option selected=\"selected\" value=\"" + model.id + "\">" + model.room_name + "</option>");
                }
                else {
                    sbDel.Append("<option value=\"" + model.id + "\">" + model.room_name + "</option>");
                }
            }
        }

        /// <summary>
        /// 获得所有优惠数据
        /// </summary>
        private void GetAllYh(Model.Book_Rdetail modelbr)
        {
            List<Model.hourse_scheme> listrt = hsBll.GetModelList("");
            foreach (Model.hourse_scheme model in listrt)
            {
                if (model.id == modelbr.Real_Scheme_Id)
                {
                    sbDel.Append("<option selected=\"selected\" value=\"" + model.id + "\">" + model.hs_name + "</option>");
                }
                else
                {
                    sbDel.Append("<option value=\"" + model.id + "\">" + model.hs_name + "</option>");
                }
            }
        }

        //第一次加载显示的值
        public void RealPrice()
        {
            //先获取房型房价 然后再打折扣
            int room_type_Id = Convert.ToInt32(this.RoomTypeDdl.SelectedValue);

            Model.room_type model = rtBll.GetModel(room_type_Id);
            pricetxt.Value = Convert.ToDecimal(model.room_listedmoney).ToString("0.##");
            int house_shame_id = Convert.ToInt32(this.HouseShameDdl.SelectedValue);

            Model.hourse_scheme hsmodel = hsBll.GetModel(house_shame_id);

            double room_money = (Convert.ToDouble(model.room_listedmoney));

            double discount = (Convert.ToDouble(hsmodel.hs_Discount));

            this.real_price.Value = (room_money * discount).ToString();

            //默认来店时间
            this.time_to.Value = System.DateTime.Now.Date.ToShortDateString();

            //默认入住时间
            this.real_time.Value = System.DateTime.Now.Date.AddDays(1).ToShortDateString() + " "+"18:00";
            Model.SysParamter modelsys = new Model.SysParamter();
            BLL.SysParameter blls = new SysParameter();
            modelsys = blls.GetModel(1);
            TimeSpan dt1 = TimeSpan.Parse(modelsys.DayOutTime.ToString());//得到系统设置的天房退房时间
            //默认离店时间
            this.time_from.Value = System.DateTime.Now.Date.AddDays(2).AddHours(dt1.Hours).ToString();
        }
        BLL.Book_Rdetail bllbrs = new BLL.Book_Rdetail();
        /// <summary>
        /// 绑定可预定数
        /// </summary>
        public void BindOkNum(int room_type_Id) {
            //先获取房型房价 然后再打折扣
            List<Model.room_number> list = bllrn.GetModelList("Rn_room=" + room_type_Id + " and Rn_state=3");
            List<Model.book_room> listbook = bllbr.GetModelList("DateDiff(s,'" + Convert.ToDateTime(Convert.ToDateTime(this.real_time.Value).ToString("yyyy-MM-dd")).Add(SysModel.YsTime) + "',time_from)>0 and state_id in (1,6)");
            int sumint = 0;
            if (listbook.Count > 0) {
                foreach (Model.book_room item in listbook)
                {
                    List<Model.Book_Rdetail> listbrs= bllbrs.GetListModel("Book_no='" + item.book_no + "'");
                    sumint += listbrs.Count;
                }
            }
            txtOkNum.InnerText = (list.Count - sumint).ToString();
        }
        BLL.room_type bllrt = new BLL.room_type();
        public string BindMaxNum(int room_type_Id)
        {
            List<Model.room_number> list = bllrn.GetModelList("Rn_room=" + room_type_Id + " and Rn_state=3");
            List<Model.book_room> listbook = bllbr.GetModelList("DateDiff(s,'" + Convert.ToDateTime(Convert.ToDateTime(this.real_time.Value).ToString("yyyy-MM-dd")).Add(SysModel.YsTime) + "',time_from)>0 and state_id in (1,6)");
            int sumint = 0;
            if (listbook.Count > 0)
            {
                foreach (Model.book_room item in listbook)
                {
                    List<Model.Book_Rdetail> listbrs = bllbrs.GetListModel("Book_no='" + item.book_no + "'");
                    sumint += listbrs.Count;
                }
            }
            double oknum = list.Count - sumint;
            double bfb = bllrt.GetModel(room_type_Id).Room_Bfb;
            int maxNums = Convert.ToInt32(oknum + (oknum * bfb * 0.01));
            return maxNums.ToString();
        }

        /// <summary>
        /// 绑定可预定数
        /// </summary>
        public int BindOkNum1(int room_type_Id)
        {
            //先获取房型房价 然后再打折扣
            List<Model.room_number> list = bllrn.GetModelList("Rn_room=" + room_type_Id + " and Rn_state=3");
            List<Model.book_room> listbook = bllbr.GetModelList("DateDiff(s,'" + Convert.ToDateTime(Convert.ToDateTime(this.real_time.Value).ToString("yyyy-MM-dd")).Add(SysModel.YsTime) + "',time_from)>0 and state_id in (1,6)");
            int sumint = 0;
            if (listbook.Count > 0) {
                foreach (Model.book_room item in listbook)
                {
                    List<Model.Book_Rdetail> listbrs= bllbrs.GetListModel("Book_no='" + item.book_no + "'");
                    sumint += listbrs.Count;
                }
            }
            return list.Count - sumint;
        }
        BLL.room_number bllrn = new BLL.room_number();
        //绑定来源下拉框
        public void GuestSourceData()
        {
            GuestSourceDdl.DataSource = gsBll.GetAllList();
            GuestSourceDdl.DataValueField = "id";
            GuestSourceDdl.DataTextField = "gs_name";
            GuestSourceDdl.DataBind();
        }

        //绑定支付方式下拉框
        public void MethPayData()
        {
            MethPayDdl.DataSource = mpBll.GetAllList();
           MethPayDdl.DataValueField = "meth_pay_id";
           MethPayDdl.DataTextField = "meth_pay_name";
           MethPayDdl.DataBind();
        }
        //BLL.room_number bllrn = new BLL.room_number();
        //private void BindHouseNumber() {
        //    HouseNumDdl.DataSource = bllrn.GetList("Rn_state=3");
        //    HouseNumDdl.DataValueField = "id";
        //    HouseNumDdl.DataTextField = "Rn_roomNum";
        //    HouseNumDdl.DataBind();
        //}

        //绑定房型下拉框
        public void RoomTypeData()
        {
            RoomTypeDdl.DataSource = rtBll.GetAllList();
            RoomTypeDdl.DataValueField = "id";
            RoomTypeDdl.DataTextField = "room_name";
            RoomTypeDdl.DataBind();
        }

        //绑定房态下拉框
        public void HouseShameData()
        {
            HouseShameDdl.DataSource = hsBll.GetAllList();
            HouseShameDdl.DataValueField = "id";
            HouseShameDdl.DataTextField = "hs_name";
            HouseShameDdl.DataBind();
        }
    
        //保存按钮
        protected void BookAddButton_Click(object sender, EventArgs e)
        {
                    
            CdHotelManage.Model.book_room model = new CdHotelManage.Model.book_room();

            model.book_no = "Y" + System.DateTime.Now.ToString().Replace("-", "").Replace(":", "").Replace(" ","");
            model.book_Name = this.book_name.Value;
            model.tele_no = this.tele_no.Value;
            model.onli_no = this.onli_no.Value;
            model.guar_way = this.GuarWayDll.SelectedValue;
            model.mem_cardno = this.mem_cardNo.Value;

            model.time_to = Convert.ToDateTime(this.time_to.Value);
            model.time_from = Convert.ToDateTime(this.time_from.Value);
            model.real_time =  Convert.ToDateTime(this.real_time.Value);
            model.source_id = Convert.ToInt16(this.GuestSourceDdl.SelectedValue);
            model.meth_pay_id =Convert.ToInt16(this.MethPayDdl.SelectedValue);
            model.deposit =Convert.ToDecimal(deposit.Value);
            model.real_type_id =Convert.ToInt16(this.RoomTypeDdl.SelectedValue);
            model.real_scheme_id = Convert.ToInt16(this.HouseShameDdl.SelectedValue);
            model.real_price = Convert.ToDecimal(this.real_price.Value); ;
            model.state_id = 1;
            model.real_num = Convert.ToInt16(this.real_num.Value);
            model.remark = this.textRemaker.Value;

            CdHotelManage.BLL.book_room bll = new CdHotelManage.BLL.book_room();
            int Result = bll.Add(model);
            if (Result > 0)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "info", "<script>(\"保存成功\", \"info\",'../','');</script>");
                Response.Redirect("BookList.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "info", "<script>(\"系统繁忙，请稍后再试！\", \"info\",'../','');</script>");
                Response.Redirect("BookList.aspx");
            }
        }

        

        //根据房型和设置房价
        protected void RoomTypeDdl_SelectedIndexChanged(object sender, EventArgs e)
        {
            int room_type_Id = Convert.ToInt32(this.RoomTypeDdl.SelectedValue);

            Model.room_type model = rtBll.GetModel(room_type_Id);

            this.real_price.Value =(Convert.ToDouble(model.room_listedmoney)).ToString();

        }

        //根据方案设置房价
        protected void HouseShameDdl_SelectedIndexChanged(object sender, EventArgs e)
        {
            //先获取房型房价 然后再打折扣
            int room_type_Id = Convert.ToInt32(this.RoomTypeDdl.SelectedValue);

            Model.room_type model = rtBll.GetModel(room_type_Id);

            int house_shame_id = Convert.ToInt32(this.HouseShameDdl.SelectedValue);

            Model.hourse_scheme hsmodel = hsBll.GetModel(house_shame_id);

            double room_money = (Convert.ToDouble(model.room_listedmoney));

            double discount = (Convert.ToDouble(hsmodel.hs_Discount))*0.1;

            this.real_price.Value = (room_money * discount).ToString();
        }

        BLL.SysParameter bllsys = new SysParameter();
        public override void SonLoad()
        {
            Model.SysParamter modelsys = bllsys.GetModel(1);
            isok.Value = modelsys.IsCy.ToString();
            RoomTypeDdl.Attributes.Add("onchange", "selectChange(this)");
            if (!IsPostBack)
            {
                GuestSourceData();
                MethPayData();
                RoomTypeData();
                //BindHouseNumber();
                HouseShameData();
                RealPrice();
                BindOkNum(Convert.ToInt32(this.RoomTypeDdl.SelectedValue));
                maxNum.InnerText = BindMaxNum(Convert.ToInt32(this.RoomTypeDdl.SelectedValue));
                string type = Request.QueryString["type"].ToString();
                if (type == "add")
                {
                    lblmsg.Text = "新增";

                }
                else if (type == "edit")
                {

                    lblmsg.Text = "修改";
                    deposit.Disabled = true;
                    BookAddButton.Text = "更新";
                    id = Convert.ToInt32(Request.QueryString["id"].ToString());
                    nowModel = bllbr.GetModel(id);
                    book_no_hid.Value = nowModel.book_no;
                    //通过ID获得实体,然后为控件赋值
                    book_name.Value = nowModel.book_Name;
                    tele_no.Value = nowModel.tele_no;
                    onli_no.Value = nowModel.onli_no;
                    real_time.Value = nowModel.time_to.ToString();
                    time_from.Value = Convert.ToDateTime(nowModel.time_from).ToString();
                    time_to.Value = Convert.ToDateTime(nowModel.real_time).ToString("yyyy-MM-dd");
                    mem_cardNo.Value = nowModel.mem_cardno;
                    GuarWayDll.SelectedValue = nowModel.guar_way;
                    GuestSourceDdl.SelectedValue = nowModel.source_id.ToString();
                    MethPayDdl.SelectedValue = nowModel.meth_pay_id.ToString();
                    deposit.Value = nowModel.deposit.ToString();
                    textRemaker.Value = nowModel.remark;
                    if (nowModel.Accounts != "" && nowModel.Accounts != null)
                    {
                        BLL.customer bllcus = new BLL.customer();
                        accounts.Value = nowModel.Accounts;//协议单位编号
                        CpId.Value = nowModel.CpID.ToString();
                        Model.customer modelcus = bllcus.GetAccounts(nowModel.Accounts);
                        customer.Value = modelcus.cName;
                    }
                    Dictionary<int, string> dic = new Dictionary<int, string>();
                    List<Model.Book_Rdetail> listbr = bllrd.GetListModel("Book_no='" + nowModel.book_no + "'");

                    foreach (Model.Book_Rdetail item in listbr)
                    {
                        if (dic.ContainsKey(item.Real_type_Id))
                        {
                            continue;
                        }
                        dic.Add(item.Real_type_Id, "true");
                        List<Model.Book_Rdetail> lists = listbr.Where(d => d.Real_type_Id == item.Real_type_Id).ToList();
                        if (lists.Count > 1)
                        {
                            //item = lists[0];
                        }
                        sbDel.Append("<tr class=\"tr\"><td class=\"w30\"><span>房 型：</span></td>");
                        sbDel.Append("<td class=\"w70\"><select name=\"RoomTypeDdl\" id=\"RoomTypeDdl\" onchange=\"selectChange(this)\">");
                        GetAllType(item);
                        sbDel.Append("</select></td>");
                        sbDel.Append("<td class=\"w30\">");
                        sbDel.Append("<span>方 案：</span>");
                        sbDel.Append("</td>");
                        sbDel.Append("<td class=\"w70\">");
                        sbDel.Append("<select name=\"HouseShameDdl\" id=\"HouseShameDdl\">");
                        GetAllYh(item);
                        sbDel.Append("</select>");
                        sbDel.Append("</td>");
                        sbDel.Append("<td class=\"w30\">");
                        sbDel.Append("<span>房 价：</span>");
                        sbDel.Append("</td>");
                        
                        sbDel.Append("<td class=\"w70\">");
                        sbDel.Append("<input name=\"real_price\" type=\"text\" id=\"real_price\" class=\"txtprice\" value=\"" + item.Real_Price + "\">");
                        sbDel.Append("</td>");
                        sbDel.Append("<td class=\"w70\">可预定数：<span  id=\"txtOkNum\" runat=\"server\" class=\"txtprice\"  >" + BindOkNum1(item.Real_type_Id) + "</span><span runat=\"server\" id=\"maxNum\" style=\" display:none;\">" + BindMaxNum(item.Real_type_Id) + "</span></td>");
                        sbDel.Append("<td class=\"w50\">");
                        sbDel.Append("<span>房间数量：</span>");
                        sbDel.Append("</td>");
                        sbDel.Append("<td class=\"w\" style=\"width:220px;\">");
                        sbDel.Append("<p onclick=\"SaleRealNum(this)\" class=\"jians\">");
                        sbDel.Append("-</p>");
                        sbDel.Append("<p style=\"float: left;\">");
                        if (lists.Count > 1)
                        {
                            sbDel.Append("  <input name=\"real_num\" type=\"text\" id=\"real_num\" value=\"" + lists.Count + "\" class=\"number fjslInp\"></p>");
                        }
                        else
                        {
                            sbDel.Append("  <input name=\"real_num\" type=\"text\" id=\"real_num\" value=\"" + item.Real_num + "\" class=\"number fjslInp\"></p>");
                        }
                        sbDel.Append("<p onclick=\"addRealNum(this)\" class=\"jia\">");
                        sbDel.Append("     +</p>");
                        sbDel.Append(" <p onclick=\"funAddTable()\" class=\"addBook\">");
                        sbDel.Append("       添加</p>");
                        sbDel.Append("  <p class=\"delBook\" onclick=\"DelTr(this)\">");
                        sbDel.Append("      删除</p>");
                        sbDel.Append("</td>");
                        sbDel.Append(" <td class=\"w30\">");
                        sbDel.Append("     <span>房 号：</span>");
                        sbDel.Append("   </td>");
                        sbDel.Append("   <td class=\"w30\" style=\"width:60px;\">");
                        if (lists.Count > 1)
                        {
                            sbDel.Append("     <span id=\"fh\">" + Geta(lists) + "</span><span class=\"yffh addBook\" onclick=\"ShowDiog(this)\" style=\" cursor:pointer;\">预 分</span>");
                        }
                        else
                        {
                            sbDel.Append("     <span id=\"fh\"><a>" + item.Room_number + "</a></span><span class=\"yffh addBook\" onclick=\"ShowDiog(this)\" style=\" cursor:pointer;\">预 分</span>");
                        }
                        sbDel.Append("     </td>");
                        sbDel.Append("    <td class=\"w70\">");
                        sbDel.Append("       <span id=\"HouseNumDdl\"></span>");
                        sbDel.Append("   </td>");
                        sbDel.Append("  </tr>");
                    }
                    if (Request["isok"]!=null) {
                        bool b = Convert.ToBoolean(Request["isok"]);
                        if (b) {
                            BookAddButton.Style.Add("display", "none");

                        }
                    }
                }

            }
        }
    }
}