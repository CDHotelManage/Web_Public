using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace CdHotelManage.Web.Admin.Toroom
{
    public partial class PeopleInfoAddsCs1 : BasePage
    {
        BLL.room_type fxBll = new BLL.room_type();
        BLL.room_number fhBll = new BLL.room_number(); 
        BLL.card_type fsfBll = new BLL.card_type();
        BLL.meth_pay fmzffs = new BLL.meth_pay();
        BLL.hourse_scheme fmfjfa = new BLL.hourse_scheme();
        BLL.real_mode fmkffs = new BLL.real_mode();
        BLL.guest_source fmkrly = new BLL.guest_source();
        BLL.occu_infor fmmx = new BLL.occu_infor();
        BLL.order_infor fmorder = new BLL.order_infor();
        BLL.goods_account fmzj = new BLL.goods_account();
        BLL.Book_Rdetail fmrdet = new BLL.Book_Rdetail();
        BLL.book_room brBll = new BLL.book_room();
        public string ids
        {

            get { return (string)ViewState["ids"]; }

            set { ViewState["ids"] = value; }

        }
        public string roomsid
        {

            get { return (string)ViewState["roomsid"]; }

            set { ViewState["roomsid"] = value; }

        }
        public string roomsidcs
        {

            get { return (string)ViewState["roomsidcs"]; }

            set { ViewState["roomsidcs"] = value; }

        }
        public string roomycid
        {

            get { return (string)ViewState["roomycid"]; }

            set { ViewState["roomycid"] = value; }

        }
        public string cardnumber
        {

            get { return (string)ViewState["cardnumber"]; }

            set { ViewState["cardnumber"] = value; }

        }
        public string occno
        {

            get { return (string)ViewState["occno"]; }

            set { ViewState["occno"] = value; }

        }
        public string contents
        {

            get { return (string)ViewState["contents"]; }

            set { ViewState["contents"] = value; }

        }
        public int count
        {

            get { return (int)ViewState["count"]; }

            set { ViewState["count"] = value; }

        }
        public int yxcount
        {

            get { return (int)ViewState["yxcount"]; }

            set { ViewState["yxcount"] = value; }

        }

        BLL.SysParameter bllsys = new BLL.SysParameter();
        Model.SysParamter modelsys = new Model.SysParamter();
        /// <summary>
        /// 是否是凌晨房
        /// </summary>
        private bool IsEraly()
        {
            
            if (modelsys.IsEarlyRoom)
            {
                TimeSpan dt1 = TimeSpan.Parse(modelsys.EarlyStart.ToString());//得到系统设置的凌晨房开始时间
                TimeSpan dt11 = TimeSpan.Parse(modelsys.EarlyEnd.ToString());//得到系统设置的凌晨房结束时间
                DateTime dt2 = DateTime.Now;//得到当前时间
                DateTime dts = Convert.ToDateTime(Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd")).AddHours(dt1.Hours);//得到今日凌晨房开始时间
                DateTime dts1 = Convert.ToDateTime(Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd")).AddHours(dt11.Hours);//得到今日凌晨房结束时间
                TimeSpan to1 = dt2 - dts;
                TimeSpan to2 = dt2 - dts1;
                if (to1.TotalSeconds > 0 && to2.TotalSeconds < 0)
                {
                    return true;
                }
                return false;
            }
            else {
                return false;
            }
        }
        System.Text.StringBuilder sbyk = new System.Text.StringBuilder();
        BLL.room_type bllrt = new BLL.room_type();
        /// <summary>
        /// 绑定房型
        /// </summary>
        public void BindFX()
        {
            ddroomtype.DataSource = fxBll.GetAllList();

            ddroomtype.DataBind();
        }
        /// <summary>
        /// 绑定身份证
        /// </summary>
        public void BindSFZ()
        {
            DataSet dt = fsfBll.GetAllList();
            foreach (DataRow dr in dt.Tables[0].Rows)
            {
                txt_CardesName.Value += dr["id"].ToString() + "," + dr["ct_name"].ToString() + ";";
            }
            DDlSFz.DataSource = fsfBll.GetAllList();
            DDlSFz.DataBind();
        }
        BLL.modes fmmodel = new BLL.modes();
        public void BindMoshi()
        {
            DDlmoshi.DataSource = fmmodel.GetAllList();
            DDlmoshi.DataValueField = "id";
            DDlmoshi.DataTextField = "moshi_name";
            DDlmoshi.DataBind();
        }
        /// 绑定开放方式
        /// </summary>
        public void BindKFFS()
        {
            DDlKffs.DataSource = fmkffs.GetAllList();
            DDlKffs.DataTextField = "real_mode_name";
            DDlKffs.DataValueField = "real_mode_id";
            DDlKffs.DataBind();
        }

        /// <summary>
        /// 绑定支付方式
        /// </summary>
        public void BindZFFS()
        {
            DDlZffs.DataSource = fmzffs.GetModelList(" meth_is_ya=1 ");
            DDlZffs.DataBind();
            int count = fmzffs.GetRecordCount(" meth_is_ya=1 ");
           // count = count - 2;
            DDlZffs.Items.Insert(count, "信用预授权");
            DDlZffs.Items.Remove(new ListItem("储值卡", "10"));
           // DDlZffs.Items.RemoveAt(0);
        }

        /// <summary>
        /// 绑定房价方案
        /// </summary>
        public void BindFJFA()
        {
            int typeid = Convert.ToInt32(ddroomtype.SelectedValue);
            
            DataSet ds = fmfjfa.GetList("hs_room=" + typeid + " or Hs_isAll=1");
            if (ds.Tables[0].Rows.Count > 0)
            {
                DDLfjfa.DataSource = ds;
                DDLfjfa.DataTextField = "hs_name";
                DDLfjfa.DataValueField = "id";
                DDLfjfa.DataBind();
            }
        }
        /// <summary>
        /// 绑定房价方案
        /// </summary>
        public void BindKRLY()
        {
            DDlkrly.DataSource = fmkrly.GetAllList();
            DDlkrly.DataTextField = "gs_name";
            DDlkrly.DataValueField = "id";
            DDlkrly.DataBind();
        }
        public void bindInfo()
        {
            Model.room_number mod = new Model.room_number();

            
            if (Request.QueryString["type"].ToString() == "yding")
            {

                IList<Model.book_room> list = brBll.GetBookRoomPager("book_id", "Desc", 1, 1, " WHERE book_no='" + Request.QueryString["ydbookno"].ToString() + "' ");
                if (list.Count > 0)
                {
                    foreach (Model.book_room item in list)
                    {
                        item.ListBr = fmrdet.GetListModel("Book_no='" + item.book_no + "' and Room_number in (" + Request.QueryString["xqid"].ToString() + ") and Room_typeid=1");
                        foreach (Model.Book_Rdetail br in item.ListBr)
                        {
                            contents += br.Room_number + "#"
                          + (br.Real_type_Id.ToString()) + "#"
                          + (item.source_id.ToString()) + "#"
                          + (br.Real_Scheme_Id.ToString()) + "#"
                          + br.Real_Price.ToString() + "#"
                          + "否" + "#" + (this.DDlKffs.SelectedValue) + "#"
                          + (item.real_time.ToString()) + "#"
                          + 1 + "#"
                          + (item.time_from.ToString()) + "#"
                          + item.book_Name + "#"
                          + this.ddll_sex.SelectedValue + "#"
                          + this.txt_Date2.Value + "#"
                          + this.txt_mingzhu.Value + "#"
                          + (this.DDlSFz.SelectedValue) + "#"
                          + (this.txt_CardId.Value) + "#"
                          + this.txt_hycardId.Value + "#"
                          + item.remark + "#"
                          + (item.meth_pay_id.ToString()) + "#"
                          + txt_address.Value + "#"
                          + item.ListBr[0].Room_number + "#" + item.tele_no + "#" + DDlmoshi.SelectedValue + "#" + txt_sfr.Value + "#" + txt_img.Value + "#" + txtsort.Value + "#" + GetPrice(br.Real_type_Id) + "|";
                        }

                    }

                }

            }
            if (Request.QueryString["type"].ToString() == "0")
            {
                txt_roomid.Value = fhBll.GetModel(Convert.ToInt32(ids)).Rn_roomNum;
                ddroomtype.SelectedValue = fhBll.GetModel(Convert.ToInt32(ids)).Rn_room.ToString();
                //txt_money.Value = Convert.ToDecimal(fhBll.GetModel(Convert.ToInt32(ids)).Rn_price).ToString("0.00");
                txt_moneys.Value = Convert.ToDecimal(fhBll.GetModel(Convert.ToInt32(ids)).Rn_price).ToString("0.##");
                txt_rzdate.Value = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                txt_roomnumber.Value =  ids.ToString();
                txt_zfzhanghao.Value = txt_roomid.Value;
            }


            
           
        }
        BLL.occu_infor bllloc = new BLL.occu_infor();
        System.Text.StringBuilder sbroom = new System.Text.StringBuilder();
        /// <summary>
        ///添加入住信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdds_Click(object sender, EventArgs e)
        {

            try
            {
                if (!Helper.IsOcc(this.txt_roomid.Value) || Request.QueryString["type"]=="1")
                {
                    if (guazhangs.Value != "") {
                        occno = guazhangs.Value;
                        //bllloc.Updates("update occu_infor set lordRoomid='" + this.txt_roomid.Value + "'");
                    }
                    Model.order_infor ordermodel = new Model.order_infor();
                    Model.goods_account goodmodles = new Model.goods_account();
                    Model.goods_account goodmodlfz = new Model.goods_account();
                    CdHotelManage.Model.occu_infor model = new CdHotelManage.Model.occu_infor();
                    CdHotelManage.Model.occu_infor models = new CdHotelManage.Model.occu_infor();
                    CdHotelManage.BLL.occu_infor bll = new CdHotelManage.BLL.occu_infor();
                    model.order_id = occno;
                    model.occ_no = "RZ" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace("-", "").Replace(":", "").Replace(" ", "").Replace("/", "");
                    model.room_number = this.txt_roomid.Value;
                    model.real_type_id = Convert.ToInt32(this.ddroomtype.SelectedValue);
                    model.source_id = Convert.ToInt32(this.DDlkrly.SelectedValue);
                    model.real_scheme_id = Convert.ToInt32(this.DDLfjfa.SelectedValue);
                    model.real_price = Convert.ToDecimal(this.txt_money.Value);
                    model.occ_with = "否";
                    model.real_mode_id = Convert.ToInt32(this.DDlKffs.SelectedValue);
                    model.occ_time = Convert.ToDateTime(this.txt_rzdate.Value);
                    model.stay_day = Convert.ToInt32(this.txt_Day.Value);
                    model.depar_time = Convert.ToDateTime(this.txt_ylDate.Value);
                    model.occ_name = this.txt_name.Value.Trim();
                    model.sex = this.ddll_sex.SelectedValue;
                    model.brithday = this.txt_Date2.Value;
                    model.Occ_StyDate = Convert.ToInt32(txt_sfr.Value);
                    model.family_name = this.txt_mingzhu.Value;
                    model.card_id = Convert.ToInt32(this.DDlSFz.SelectedValue);
                    model.card_no = (this.txt_CardId.Value);
                    model.mem_cardno = this.txt_hycardId.Value;//会员卡号   
                    model.remark = this.txt_Remaker.Value;//备注
                    model.Occ_headerImg = txt_img.Value;//图片
                    model.GzRoom = guazhangRoom.Value;
                    if (CpId.Value != "")
                    {
                        model.CpID = Convert.ToInt32(CpId.Value);
                    }
                    else { 
                        
                    }
                    model.Accounts = accounts.Value;
                    
                    if (DDlKffs.SelectedItem.Text == "月租房")
                    {
                        model.sale_id = Convert.ToInt32(DDlmoshi.SelectedValue);//模式
                    }
                    else
                    {
                        model.sale_id = 0;
                    }
                    if (DDlZffs.SelectedValue == "信用预授权")
                    { // model.meth_pay_id = 0;

                    }
                    else
                    {
                        int mep = Convert.ToInt32(Request["DDlZffs"]);
                        model.meth_pay_id = mep;//支付方式
                    }
                    if (txt_yjmoney.Value == "")
                    {
                        model.deposit = 0;
                    }
                    else
                    {
                        model.deposit = Convert.ToDecimal(txt_yjmoney.Value);
                    }
                    model.address = txt_address.Value;//地址
                    if (guazhangs.Value != "")//如果有挂帐目标
                    {
                        
                        model.lordRoomid = bllloc.GetModel(Convert.ToInt32(guazhangRoom.Value)).room_number;
                    }
                    else {
                        model.lordRoomid = txt_zfzhanghao.Value;//主房账号
                    }
                    model.phonenum = txt_lxphone.Value;//联系电话
                    model.tuifaId = "0";
                    model.continuelive = 0;
                    model.sort = txtsort.Value;
                    string[] hidAdd = contents1.Value.Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    if (Request.QueryString["type"].ToString() == "0" || Request.QueryString["type"].ToString() == "yding" || Request.QueryString["type"].ToString() == "jiakai")
                    {
                        if (hidAdd.Length > 1)
                        {
                            for (int i = 0; i < hidAdd.Length; i++)
                            {
                                try
                                {
                                    if (!Helper.IsOcc(hidAdd[i].Split('#')[0]))
                                    {
                                        string NumNo = "000" + i;
                                        string a = hidAdd[i].Split('#')[0].Trim();

                                        model.order_id = occno.ToString();
                                        model.occ_no = "RZ" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace("-", "").Replace(":", "").Replace(" ", "").Replace("/", "") + NumNo;
                                        model.room_number = hidAdd[i].Split('#')[0];
                                        sbroom.Append(model.room_number + ",");
                                        model.real_type_id = Convert.ToInt32(hidAdd[i].Split('#')[1]);
                                        model.source_id = Convert.ToInt32(hidAdd[i].Split('#')[2]);
                                        model.real_scheme_id = Convert.ToInt32(hidAdd[i].Split('#')[3]);
                                        model.real_price = Convert.ToDecimal(hidAdd[i].Split('#')[4]);
                                        model.occ_with = hidAdd[i].Split('#')[5];
                                        model.real_mode_id = Convert.ToInt32(hidAdd[i].Split('#')[6]);
                                        model.occ_time = Convert.ToDateTime(hidAdd[i].Split('#')[7]);
                                        model.pre_live_day = Convert.ToInt32(hidAdd[i].Split('#')[8]);
                                        model.depar_time = Convert.ToDateTime(hidAdd[i].Split('#')[9]);
                                        model.occ_name = hidAdd[i].Split('#')[10];
                                        model.sex = hidAdd[i].Split('#')[11];
                                        model.brithday = hidAdd[i].Split('#')[12];
                                        model.family_name = hidAdd[i].Split('#')[13];
                                        model.card_id = Convert.ToInt32(hidAdd[i].Split('#')[14]);
                                        model.card_no = (hidAdd[i].Split('#')[15]);
                                        model.mem_cardno = hidAdd[i].Split('#')[16];//会员卡号    
                                        // model.remark = hidAdd[i].Split('#')[17];
                                        // model.meth_pay_id = Convert.ToInt32(contents.Split('#')[18]);//支付方式
                                        // model.deposit = Convert.ToInt32(contents.Split('#')[19]);
                                        model.address = hidAdd[i].Split('#')[19];//地址
                                        model.phonenum = hidAdd[i].Split('#')[21];
                                        model.sale_id = Convert.ToInt32(hidAdd[i].Split('#')[22]);
                                        model.Occ_StyDate = Convert.ToInt32(hidAdd[i].Split('#')[23]);
                                        model.Occ_headerImg = hidAdd[i].Split('#')[24];
                                        model.GzRoom = guazhangRoom.Value;
                                        if (a != "")
                                        {

                                            if (model.lordRoomid == model.room_number)
                                            {
                                                if (txt_yjmoney.Value == "")
                                                {
                                                    model.deposit = 0;
                                                }
                                                else
                                                {
                                                    model.deposit = Convert.ToDecimal(txt_yjmoney.Value);
                                                }
                                                model.remark = txt_Remaker.Value;
                                            }
                                            else
                                            {
                                                model.deposit = 0;
                                                txt_Remaker.Value = "";
                                            }
                                            List<Model.room_number> listrn = bllrn.GetModelList("Rn_roomNum='" + model.room_number + "'");
                                            if (listrn.Count > 0)
                                            {
                                                listrn[0].Rn_Tobe = 0;
                                                bllrn.Update(listrn[0]);
                                            }
                                            bll.Add(model);
                                            if (Request.QueryString["type"].ToString() == "yding")
                                            {
                                                try
                                                {
                                                    string sql = " update Book_Rdetail set Room_typeid=2 from Book_Rdetail where Book_no='" + Request.QueryString["ydbookno"].ToString() + "' and Room_typeid=1 and Room_number='" + model.room_number + "'";
                                                    fmrdet.Updates(sql);
                                                }
                                                catch
                                                {

                                                }
                                            }
                                            goodmodlfz.ga_name = "房费";
                                            goodmodlfz.ga_sum_price = Convert.ToDecimal(Convert.ToDecimal(hidAdd[i].Split('#')[4]).ToString("0.##"));
                                            goodmodlfz.ga_number = "FZ" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace("-", "").Replace(":", "").Replace(" ", "").Replace("/", "");
                                            goodmodlfz.ga_price = 0;
                                            goodmodlfz.ga_date = Convert.ToDateTime(System.DateTime.Now);
                                            goodmodlfz.ga_people = UserNow.UserID;
                                            goodmodlfz.ga_sfacount = "否";
                                            goodmodlfz.ga_Type = 8;
                                            goodmodlfz.ga_isjz = 0;
                                            goodmodlfz.Ga_goodNo = bll.GetModels(" where occ_with='否' and room_number='" + model.room_number.Trim() + "' and state_id=0").occ_no;

                                            // goodmodlfz.ga_zffs_id = Convert.ToInt32(DDlZffs.SelectedValue);
                                            goodmodlfz.ga_remker = txt_Remaker.Value;
                                            goodmodlfz.ga_roomNumber = model.room_number;
                                            goodmodlfz.ga_occuid = occno;
                                            fmzj.Add(goodmodlfz);
                                            string str2 = "update room_number set Rn_state=2 where Rn_roomNum='" + model.room_number + "'";
                                            fhBll.Updates(str2);

                                            Helper.UpdateRoom(goodmodles.ga_roomNumber);
                                            List<Model.Book_Rdetail> listbr = bllbr.GetListModel("Book_no='" + Request.QueryString["ydbookno"].ToString() + "' and Real_type_Id=" + model.real_type_id + " and Room_typeid in(1,3,6) ");
                                            if (listbr.Count > 0)
                                            {
                                                listbr[0].Room_number = model.room_number;
                                                listbr[0].RoomTypeID = 2;
                                                bllbr.Update(listbr[0]);
                                            }
                                        }
                                    }
                                    else {
                                        sbyk.Append(hidAdd[i].Split('#')[0] + ",");
                                    }
                                }
                                catch
                                {

                                }
                            }

                        }
                        else
                        {
                            if (bll.Add(model) > 0)
                            {
                                goodmodlfz.ga_name = "房费";
                                goodmodlfz.ga_sum_price = Convert.ToDecimal(txt_money.Value);
                                goodmodlfz.ga_number = "FZ" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace("-", "").Replace(":", "").Replace(" ", "").Replace("/", "");
                                goodmodlfz.ga_price = 0;
                                goodmodlfz.ga_date = Convert.ToDateTime(System.DateTime.Now);
                                goodmodlfz.ga_people = UserNow.UserID;
                                goodmodlfz.ga_sfacount = "否";
                                goodmodlfz.ga_Type = 8;
                                goodmodlfz.ga_isjz = 0;
                                // goodmodlfz.ga_zffs_id = Convert.ToInt32(DDlZffs.SelectedValue);
                                goodmodlfz.ga_remker = txt_Remaker.Value;
                                goodmodlfz.ga_roomNumber = txt_roomid.Value;
                                goodmodlfz.Ga_goodNo = bll.GetModels(" where occ_with='否' and room_number='" + txt_roomid.Value + "' and state_id=0").occ_no;
                                //  goodmodlfz.ga_occuid = bll.GetModels(" where occ_with='否' and room_number=" + txt_roomid.Value + " and state_id=0").order_id;
                                goodmodlfz.ga_occuid = occno;
                                sbroom.Append(goodmodlfz.ga_roomNumber + ",");
                                fmzj.Add(goodmodlfz);
                                string SQl = "update room_number set Rn_state=2 where Rn_roomNum='" + txt_roomid.Value + "'";
                                fhBll.Updates(SQl);
                            }
                        }
                    }
                    if (Request.QueryString["type"].ToString() == "1")
                    {
                        model.order_id = fmmx.GetModels(" where occ_with='否' and state_id=0 and room_number='" + roomsid + "'").order_id;
                        if (guazhang.Value!= "")
                        {
                            bllloc.Updates("update occu_infor set order_id=" + occno + " where order_id='" + model.order_id + "'");
                            fmzj.Updates("update goods_account set ga_occuid=" + occno + " where ga_occuid='" + model.order_id + "'");
                            bllloc.Updates("update occu_infor set lordRoomid=" + bllloc.GetModel(Convert.ToInt32(guazhangRoom.Value)).room_number + " where order_id='" + occno + "'");
                            model.order_id = occno;
                        }
                        model.occ_id = Convert.ToInt32(ids);

                        if (bll.Update(model))
                        {
                            List<Model.occu_infor> listocc = fmmx.GetModelList("order_id='" + occno + "'");
                            foreach (Model.occu_infor item in listocc)
                            {
                                sbroom.Append(item.room_number + ",");
                            }
                            Helper.AddRoom(model.room_number, sbroom.ToString());
                            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "click", "alert('修改成功');ShowTabs('房态图');", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "click", "alert('修改失败')", true);
                        }
                    }
                    else
                    {
                        ordermodel.order_no = occno;
                        ordermodel.order_time = System.DateTime.Now;
                        ordermodel.room_id = txt_zfzhanghao.Value;
                        if (fmorder.Add(ordermodel) > 0)
                        {
                            goodmodles.ga_name = "入住收款";
                            goodmodles.ga_sum_price = 0;
                            goodmodles.ga_number = "YZYJ" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace("-", "").Replace(":", "").Replace(" ", "");
                            if (txt_yjmoney.Value == "")
                            {
                                goodmodles.ga_price = 0;
                            }
                            else
                            {
                                goodmodles.ga_price = Convert.ToDecimal(Convert.ToDecimal(txt_yjmoney.Value).ToString("0.##"));
                            }
                            goodmodles.ga_date = Convert.ToDateTime(System.DateTime.Now);
                            goodmodles.ga_people = UserNow.UserID;
                            goodmodles.ga_sfacount = "是";
                            goodmodles.ga_Type = 7;
                            goodmodlfz.ga_isjz = 0;
                            goodmodles.Ga_goodNo = bll.GetModels(" where occ_with='否' and room_number='" + txt_roomid.Value + "' and state_id=0").occ_no;
                            goodmodles.ga_remker = txt_Remaker.Value;
                            goodmodles.ga_roomNumber = txt_roomid.Value;
                            if (DDlZffs.SelectedValue == "信用预授权")
                            {
                                // goodmodles.ga_zffs_id =0;
                                goodmodles.ga_occuid = bll.GetModels(" where occ_with='否' and room_number='" + txt_roomid.Value + "' and state_id=0").occ_no;

                            }
                            else
                            {
                                int mep = Convert.ToInt32(Request["DDlZffs"]);
                                goodmodles.ga_occuid = occno;
                                goodmodles.ga_zffs_id = mep;
                            }
                            if (Request.QueryString["type"].ToString() != "jiakai") //如果是加开就没有入住收
                            {
                                fmzj.Add(goodmodles);
                            }
                            if (sbroom.ToString() != "")
                            {
                                if (Request.QueryString["type"] == "jiakai" || guazhangs.Value != "")
                                {
                                    sbroom.Clear();
                                    List<Model.occu_infor> listocc = fmmx.GetModelList("order_id='" + occno + "'");
                                    foreach (Model.occu_infor item in listocc)
                                    {
                                        sbroom.Append(item.room_number + ",");
                                    }
                                    
                                }
                                Helper.AddRoom(goodmodles.ga_roomNumber, sbroom.ToString());
                            }
                            else
                            {
                                Helper.AddRoom(goodmodles.ga_roomNumber);
                            }
                            if (Request.QueryString["ydbookno"] != null && Request.QueryString["type"].ToString() == "yding")
                            {
                                Helper.UpdateRoom(goodmodles.ga_roomNumber);
                                int count = bllbr.GetListModel("Book_no='" + Request.QueryString["ydbookno"].ToString() + "'").Count;
                                int yikai = bllbr.GetListModel("Book_no='" + Request.QueryString["ydbookno"].ToString() + "' and Room_number!=''").Count;
                                List<Model.book_room> listbr = bllbr1.GetModelList("book_no='" + Request.QueryString["ydbookno"] + "'");
                                if (yikai >= count)
                                {
                                    if (listbr.Count > 0)
                                    {
                                        listbr[0].state_id = 2;
                                        bllbr1.Update(listbr[0]);
                                    }
                                }
                                else
                                {
                                    if (listbr.Count > 0)
                                    {
                                        listbr[0].state_id = 3;
                                        bllbr1.Update(listbr[0]);
                                    }
                                }
                            }
                            if (Request.QueryString["type"] != "jiakai")
                            {
                                if (sbyk.ToString() != "")
                                {
                                    //ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "click", "BindNav(); if(confirm('开房成功，其中" + sbyk.ToString() + "房间已开，是否打印入住单')){PrintRZ(this," + model.order_id + ");}else{ShowTabs('房态图');}", true);
                                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "click", "BindNav();MarkCard(this,'" + model.order_id + "')", true);
                                }
                                else
                                {
                                    //ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "click", "BindNav(); if(confirm('开房成功，是否打印入住单')){PrintRZ(this," + model.order_id + ");}else{ShowTabs('房态图');}", true);
                                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "click", "BindNav();MarkCard('" + model.order_id + "')", true);
                                }
                            }
                            else {
                                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "click", "BindNav(); alert('加开成功！');CloseTile('加开房间');", true);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "click", "alert('开房失败')", true);


                        }


                    }
                    string SQL = "delete from occu_infor where room_number='" + this.txt_roomid.Value + "' and state_id=0 and occ_with='是'";
                    fmmx.Deletes(SQL);
                    string[] content = txt_zhi.Value.Split('|');
                    for (int i = 0; i < content.Length; i++)
                    {
                        if (Request.QueryString["type"].ToString() == "1")
                        {
                            models.order_id = fmmx.GetModels(" where occ_with='否' and state_id=0 and room_number='" + roomsid + "'").order_id;
                            
                        }
                        else if (Request.QueryString["type"].ToString() == "0")
                        {
                            models.order_id = fmmx.GetModels(" where occ_with='否' and state_id=0 and room_number='" + goodmodles.ga_roomNumber + "'").order_id;
                        }
                        models.room_number = content[i].Split(',')[0];
                        models.occ_name = content[i].Split(',')[1];
                        models.sex = content[i].Split(',')[2];
                        models.brithday = content[i].Split(',')[3];
                        models.card_id = fsfBll.GetModelList(" ct_name='" + content[i].Split(',')[4] + "'")[0].id;
                        models.card_no = content[i].Split(',')[5];
                        models.address = content[i].Split(',')[6];
                        models.occ_time = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        models.occ_with = "是";
                        //  models.room_number = this.txt_roomid.Value;
                        bll.Add(models);
                    }
                }
                else {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "click", "Occerr()", true);
                }
            }
            catch { }
            

            
        }

        BLL.room_number bllrn = new BLL.room_number();
        /// <summary>
        /// 绑定可选可选房间
        /// </summary>
        public void BindKYGV()
        {
            DivKXRoom.InnerHtml = "";
            DataSet dt = null;
            string Table = "";

            if (roomsid == "" || roomsid == null)
            {
                dt = fhBll.GetList(" Rn_state=3  and Room_suod!='是'");
            }
            else
            {
                dt = fhBll.GetList("Rn_state=3 and id not in (" + roomsid + ") and Room_suod!='是'");
            }
            Table += "<table border='0' width='100%' cellspacing='0' cellpadding='0'>";
            foreach (DataRow dr in dt.Tables[0].Rows)
            {


                Table += "<tr ids='" + dr["id"] + "'  onclick='BTncher(" + dr["id"] + ",1,this)'><td style='width:70px;'>" + dr["Rn_roomNum"].ToString() + "</td><td style='width:260px;'>" + GetRealTypeName(Convert.ToInt32(dr["Rn_room"].ToString())) + "</td><td style='width:70px;'>" + Convert.ToDecimal(dr["Rn_price"]).ToString("0.##") + "</td></tr>";
                
            }
            Table += "</table>";
            DivKXRoom.InnerHtml = Table;
        }
        /// <summary>
        /// 绑定已选房间
        /// </summary>
        public void BindYXGV()
        {
            DivKXRoom.InnerHtml = "";
            DataSet dt = null;
            string Table = "";
            if (roomsid == "" || roomsid == null)
            {
                dt = fhBll.GetList(" 1 !=1 ");
            }
            else
            { 
                dt = fhBll.GetList(" id in (" + roomsid + ") ");      
            }
            Table += "<table border='0' width='100%' cellspacing='0' cellpadding='0'>";
            foreach (DataRow dr in dt.Tables[0].Rows)
            {

                Table += "<tr class=\"trs\" ids='" + dr["id"] + "' onclick='BTncher(" + dr["id"] + ",0,this)'><td style='width:70px;'>" + dr["Rn_roomNum"].ToString() + "</td><td style='width:260px;'>" + GetRealTypeName(Convert.ToInt32(dr["Rn_room"].ToString())) + "</td><td style='width:70px;'>" + GetPrice(dr["Rn_roomNum"].ToString()) + "</td></tr>";
            }
            Table += "</table>";
            DivYXRoom.InnerHtml = Table;
        }
        /// <summary>
        /// 多人开房   绑定值  0是已先。1上未选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBind_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txt_id.Value);

            Model.room_number mod = new Model.room_number();
            txt_roomid.Value = fhBll.GetModel(id).Rn_roomNum;
            ddroomtype.SelectedValue = (fhBll.GetModel(id).Rn_room).ToString();
            txt_moneys.Value = txt_price.Value;
            txt_rzdate.Value = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string a = hidSchool.Value;

            ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "Init();JSS('1');", true);
            if (txt_type.Value == "0")
            {
                string[] Content = contents.Split('|');
                
                for (int i = 0; i < Content.Length - 1; i++)
                {
                    if (Content[i].Split('#')[0] == txt_roomid.Value)
                    {
                        if (Convert.ToInt32(Content[i].Split('#')[6]) == 1)
                        {
                            moshi.Style.Add("display", "none");
                            fangan.Style.Add("display", "none");
                            listSfrq.Style.Add("display", "none");
                        }
                        else if (Convert.ToInt32(Content[i].Split('#')[6]) == 2)
                        {

                            moshi.Style.Add("display", "none");
                            listSfrq.Style.Add("display", "none");
                            fangan.Style.Add("display", "block");
                        }
                        else if (Convert.ToInt32(Content[i].Split('#')[6]) == 19)
                        {
                            moshi.Style.Add("display", "block");
                            listSfrq.Style.Add("display", "block");
                            fangan.Style.Add("display", "none");
                        }
                        else if (Convert.ToInt32(Content[i].Split('#')[6]) == 20)
                        {
                            moshi.Style.Add("display", "none");
                            fangan.Style.Add("display", "none");
                            listSfrq.Style.Add("display", "none");
                        }
                        string b = Content[i].Split('#')[3].ToString();
                        txt_name.Value = Content[i].Split('#')[10];
                        ddll_sex.SelectedValue = Content[i].Split('#')[11];
                        txt_CardId.Value = Content[i].Split('#')[15];
                        txt_ylDate.Value = Content[i].Split('#')[9];
                        txt_zfzhanghao.Value = Content[i].Split('#')[20];
                        txt_Day.Value = Content[i].Split('#')[8];
                        txt_Date2.Value = Content[i].Split('#')[12];
                        txt_CardId.Value = Content[i].Split('#')[15];
                        DDlSFz.SelectedValue = Content[i].Split('#')[14];
                        //  txt_address.Value = Content[i].Split('#')[20];
                        txt_mingzhu.Value = Content[i].Split('#')[13];
                        DDlKffs.SelectedValue = Content[i].Split('#')[6];
                        DDLfjfa.SelectedValue = Content[i].Split('#')[3].ToString();
                        DDlkrly.SelectedValue = Content[i].Split('#')[2];
                        txt_hycardId.Value = Content[i].Split('#')[16];
                        txt_address.Value = Content[i].Split('#')[19];
                        txt_lxphone.Value = Content[i].Split('#')[21];
                        DDlmoshi.SelectedValue = Content[i].Split('#')[22];
                        txt_sfr.Value = Content[i].Split('#')[23];
                        headimg.InnerHtml = "<img width='100px' height='100px' src='" + Content[i].Split('#')[24] + "'>";
                        ZD_hourse.SelectedValue = Content[i].Split('#')[25];
                    }
                }
            }
            else {
               
            }
           
            btn_rooms.Value = "终止开房";
            //DivDisHidroom.Style.Add("display", "block");
            if (DDlKffs.SelectedItem.Text == "月租房")
            {
                moshi.Style.Add("display", "block");
            }
            
          
        }

        private string GetPrice(string room) {
            string[] Content = contents.Split('|');

            for (int i = 0; i < Content.Length - 1; i++)
            {
                if (Content[i].Split('#')[0] == room)
                {
                    
                    return  Convert.ToDecimal(Content[i].Split('#')[26]).ToString("0.##");
                }
            }
            return "";
        }

        /// <summary>
        /// 添加房间号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnyzAdds_Click(object sender, EventArgs e) 
        {

            string pd = "";
            int id = 0;
            string[] Content = contents.Split('|');
          //  contents = "";
            for (int i = 0; i < Content.Length - 1; i++)
            {

                if (Content[i].Split('#')[0] == txt_roomid.Value)
                {
                    pd = txt_roomid.Value;
                }
            }
            if (pd == "")
            {
                contents += this.txt_roomid.Value + "#"
                            + this.ddroomtype.SelectedValue + "#"
                            + this.DDlkrly.SelectedValue + "#"
                            + this.DDLfjfa.SelectedValue + "#"
                            + this.txt_money.Value + "#"
                            + "否" + "#" + this.DDlKffs.SelectedValue + "#"
                            + (this.txt_rzdate.Value) + "#"
                            + this.txt_Day.Value + "#"
                            + (this.txt_ylDate.Value) + "#"
                            + this.txt_name.Value + "#"
                            + this.ddll_sex.SelectedValue + "#"
                            + this.txt_Date2.Value + "#"
                            + this.txt_mingzhu.Value + "#"
                            + this.DDlSFz.SelectedValue + "#"
                            + (this.txt_CardId.Value) + "#"
                            + this.txt_hycardId.Value + "#"
                            + this.txt_Remaker.Value + "#"
                            + DDlZffs.SelectedValue + "#"
                            + txt_address.Value + "#"
                            + txt_zfzhanghao.Value + "#" + txt_lxphone.Value + "#" + DDlmoshi.SelectedValue + "#" + txt_sfr.Value + "#" + txt_img.Value + "#" + txtsort.Value + "#" + txt_moneys.Value + "|";
            }
            //  txt_Info.Value += this.txt_roomid.Value + "#" + Convert.ToInt32(this.ddroomtype.SelectedValue) + "#" + (this.txt_yjmoney.Value) + "#" + "|";
            try
            {
                 id = Convert.ToInt32(txt_id.Value);
            }
            catch { }
            if (roomsid == "" || roomsid==null)
            {
                roomsid = id.ToString();
            }
            else
            {
                roomsid += "," + id;

            }
            txt_roomnumber.Value = roomsid;
            BindYXGV();
            BindKYGV();
            DivDisHidroom.Style.Add("display", "block");
            if (DDlKffs.SelectedItem.Text == "月租房")
            {
                moshi.Style.Add("display", "block");
            }
            else
            {
                moshi.Style.Add("display", "none");
            }

            ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "Init();JSS('1');", true);
        }
        /// <summary>
        /// 移除房间号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {

            roomycid = (txt_id.Value);
            roomsid = roomsid.Replace("" + roomycid + "", "").Replace(",,", ",").Trim();
            if (roomsid != "")
            {
                string a = roomsid.Substring(roomsid.Length - 1, 1);
                string b = roomsid.Substring(0, 1).Trim();
                if (roomsid.Substring(roomsid.Length - 1, 1).Trim() == ",")
                {
                    roomsid = roomsid.TrimEnd(',');

                }
                if (roomsid.Substring(0, 1).Trim() == ",")
                {
                    roomsid = roomsid.Remove(roomsid.IndexOf(","), 1);
                }
            }

            string[] Content = contents.Split('|');
            contents = "";
            for (int i = 0; i < Content.Length - 1; i++)
            {

                if (Content[i].Split('#')[0] == txt_roomid.Value)
                {
                    Content[i] = "";
                }
                if (Content[i] == "")
                {
                   // contents += Content[i];
                }
                else 
                {
                    contents += Content[i] + "|";
                }
              
            }
            txt_roomnumber.Value = roomsid;
            BindYXGV();
            BindKYGV();
            if (DDlKffs.SelectedItem.Text == "月租房")
            {
                moshi.Style.Add("display", "block");
            }
            else
            {
                moshi.Style.Add("display", "none");
            }
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "RemoveRoom();", true);
        }
        /// <summary>
        /// 失去焦点获取值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnbur_Click(object sender, EventArgs e)
        {
            string[] Content = contents.Split('|');
            contents = "";
            for (int i = 0; i < Content.Length - 1; i++)
            {

                if (Content[i].Split('#')[0] == txt_roomid.Value)
                {
                    Content[i] = this.txt_roomid.Value + "#"
                       + this.ddroomtype.SelectedValue + "#"
                       + this.DDlkrly.SelectedValue + "#"
                       + this.DDLfjfa.SelectedValue + "#"
                       + this.txt_money.Value + "#"
                       + "否" + "#" + this.DDlKffs.SelectedValue + "#"
                       + (this.txt_rzdate.Value) + "#"
                       + Convert.ToInt32(this.txt_Day.Value) + "#"
                       + (this.txt_ylDate.Value) + "#"
                       + this.txt_name.Value + "#"
                       + this.ddll_sex.SelectedValue  + "#"
                       + this.txt_Date2.Value + "#"
                       + this.txt_mingzhu.Value + "#"
                       + this.DDlSFz.SelectedValue + "#"
                       + (this.txt_CardId.Value) + "#"
                       + this.txt_hycardId.Value + "#"
                       + this.txt_Remaker.Value + "#"
                       + DDlZffs.SelectedValue + "#"
                       + txt_address.Value + "#"
                       + txt_zfzhanghao.Value + "#" + txt_lxphone.Value + "#" + DDlmoshi.SelectedValue + "#" + txt_sfr.Value + "#" + txt_img.Value + "#" + txtsort.Value + "#" + txt_moneys.Value + "|";
                }
                contents += Content[i] + "|";
                string c = Content[i];
            }

            btn_rooms.Value = "终止开房";
            DivDisHidroom.Style.Add("display", "block");
            if (DDlKffs.SelectedItem.Text == "月租房")
            {
                moshi.Style.Add("display", "block");
                listSfrq.Style.Add("display", "block");
                fangan.Style.Add("display", "none");
            }
            else if (DDlKffs.SelectedItem.Text == "钟点房") {
                moshi.Style.Add("display", "none");
                listSfrq.Style.Add("display", "none");
                fangan.Style.Add("display", "block");
            }
            else
            {
                moshi.Style.Add("display", "none");
                listSfrq.Style.Add("display", "none");
                fangan.Style.Add("display", "none");
            }
            BindYXGV();
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "Init();JSS('1');", true);
        }
        /// <summary>
        /// 绑定要修改的信息
        /// </summary>
        public void BindUpdateInfo()
        {
            DataSet dt = fmmx.GetList(" room_number='" + roomsid + "' and occ_with='否' and state_id=0");
            foreach (DataRow dr in dt.Tables[0].Rows)
            {
                txt_roomid.Value = dr["room_number"].ToString();
                ddroomtype.SelectedValue = Convert.ToInt32(dr["real_type_id"]).ToString();
                DDlkrly.SelectedValue = dr["source_id"].ToString();
                DDLfjfa.SelectedValue = dr["real_scheme_id"].ToString();
                txt_money.Value = Convert.ToDecimal(dr["real_price"]).ToString("0.##");
                DDlKffs.SelectedValue = dr["real_mode_id"].ToString();
                txt_rzdate.Value = dr["occ_time"].ToString();
                txt_Day.Value = dr["stay_day"].ToString();
                txt_ylDate.Value = dr["depar_time"].ToString();
                txt_name.Value = dr["occ_name"].ToString();
                ddll_sex.SelectedValue  = dr["sex"].ToString();
                txt_Date2.Value = dr["brithday"].ToString();
                txt_mingzhu.Value = dr["family_name"].ToString();
                DDlSFz.SelectedValue = dr["card_id"].ToString();
                txt_CardId.Value = dr["card_no"].ToString();
                txt_hycardId.Value = dr["mem_cardno"].ToString();//会员卡号   
                txt_address.Value = dr["address"].ToString();//地址
                txt_lxphone.Value = dr["phonenum"].ToString();//联系电话
                txt_zfzhanghao.Value = dr["lordRoomid"].ToString();//主房账号   
                txt_Remaker.Value = dr["remark"].ToString();
                DDlZffs.SelectedValue = dr["meth_pay_id"].ToString();//支付方式
                txt_yjmoney.Value = dr["deposit"].ToString();//押金～(￣▽￣～)(～￣▽￣)～
                txt_moneys.Value = fhBll.GetModelList("Rn_roomNum='" + roomsid + "' ")[0].Rn_price.ToString();
                if (dr["gzRoom"].ToString() != "")
                {
                    guazhangs.Value = dr["order_id"].ToString();
                    guazhangRoom.Value = dr["gzRoom"].ToString();
                    guazhang.Value = bllloc.GetModel(Convert.ToInt32(guazhangRoom.Value)).occ_name + "的帐户";
                }
                headimg.InnerHtml = "<img width='100px' height='100px' src='" + dr["occ_headerImg"].ToString() + "'>";
                if (DDlKffs.SelectedItem.Text == "月租房")
                {
                    DDlmoshi.SelectedValue = (dr["sale_id"].ToString());
                    txt_moneys.Value = Convert.ToDecimal(dr["real_price"]).ToString("0.##");
                    txt_sfr.Value = dr["occ_StyDate"].ToString();
                }
            }
        }
        public void BindNull()
        {
            ddll_sex.SelectedValue  = "";
            DDlZffs.SelectedIndex = 0;
            txt_address.Value = "";
            txt_CardId.Value = "";
            DDlSFz.SelectedIndex = 0;
            txt_lxphone.Value = "";
            txt_name.Value = "";
        }
        //获得房型名称
        public string GetRealTypeName(int id)
        {

            BLL.room_type rtbll = new BLL.room_type();
            Model.room_type model = rtbll.GetModel(Convert.ToInt32(id.ToString()));
            return model.room_name;


        }
        /// <summary>
        /// 预定计算详情
        /// </summary>
        protected System.Text.StringBuilder sbtable = new System.Text.StringBuilder();
        /// <summary>
        /// 绑定预定信息 生成临时Table并保存 预定天数还没有计算（先搞成1 天）
        /// </summary>
        public void ydBindsInfo()
        {
            /*绑定一些信息*/
            string book_no = Request.QueryString["ydbookno"].ToString();
            string zfzhanghao=Request.QueryString["rooms"].ToString();
            Model.book_room modelbr = bllbr1.GetModelList("book_no='" + book_no + "'")[0];
            int days = Convert.ToDateTime(modelbr.time_from).Day - Convert.ToDateTime(modelbr.time_to).Day;
            if (days < 0) {
                TimeSpan sts = Convert.ToDateTime(modelbr.time_from) - Convert.ToDateTime(modelbr.time_to);
                days = Convert.ToInt32(sts.TotalDays);
            }
            txt_name.Value = modelbr.book_Name;
            txt_roomid.Value = zfzhanghao;
            txt_yjmoney.Value = modelbr.deposit.ToString();//押金
            if (modelbr.Accounts != "" && modelbr.Accounts!=null)
            {
                BLL.customer bllcus = new BLL.customer();
                accounts.Value = modelbr.Accounts;//协议单位编号
                CpId.Value = modelbr.CpID.ToString();
                Model.customer modelcus = bllcus.GetAccounts(modelbr.Accounts);
                customer.Value = modelcus.cName;
            }
            /*绑定信息*/
            string rooms = Request.QueryString["xqid"].ToString();


            if (zfzhanghao.Trim() != "")
            {
                List<Model.Book_Rdetail> listbr = bllbr.GetListModel("Book_no='" + book_no + "' and Room_number!=''");
                Model.Book_Rdetail modelnowbr = null;
                string[] strroom = rooms.Split(',');
                string newstr = string.Empty;
                foreach (string str in strroom)
                {

                    
                        newstr = str.Replace("\'", "");
                        if (newstr != "")
                        {
                            modelnowbr = listbr.Where(b => b.Room_number.Trim() == newstr).First();
                            sbtable.Append("<tr roomnumber=\"" + newstr + "\"><td class=\"txt_roomid\">" + newstr + "</td><td class=\"ddroomtype\">" + GetRealTypeName(modelnowbr.Real_type_Id) + "</td><td class=\"DDlkrly\">" + modelbr.source_id + "</td><td class=\"DDLfjfa\">" + modelnowbr.Real_Scheme_Id + "</td><td class=\"txt_money\">" + modelnowbr.Real_Price.ToString("0.##") + "</td><td class=\"isok\">否</td><td class=\"DDlKffs\">1</td><td class=\"txt_rzdate\">" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "</td><td class=\"txt_Day\"></td><td class=\"txt_ylDate\">" + modelbr.time_from + "</td><td class=\"txt_name\">" + modelbr.book_Name + "</td><td class\"ddll_sex\">男</td><td class=\"txt_Date2\"></td><td class=\"txt_mingzhu\">汉族</td><td class=\"DDlSFz\">1</td><td class=\"txt_CardId\"></td><td class=\"txt_hycardId\">" + modelbr.mem_cardno + "</td><td class=\"txt_Remaker\">" + modelbr.remark + "</td><td class=\"DDlZffs\">" + modelbr.meth_pay_id + "</td><td class=\"txt_address\"></td><td class=\"txt_zfzhanghao\">" + zfzhanghao + "</td><td class=\"txt_lxphone\">" + modelbr.tele_no + "</td><td class=\"DDlmoshi\">1</td><td class=\"txt_sfr\">1</td><td class=\"txt_img\"></td><td class=\"ZD_hourse\">null</td><td class=\"txt_moneys\">" + GetPrice(modelnowbr.Real_type_Id) + "</td></tr>");
                        }
                }
            }
            else {
                IList<Model.book_room> list = brBll.GetBookRoomPager("book_id", "Desc", 1, 1, " WHERE book_id='" + Request.QueryString["id"].ToString() + "'");
                if (list.Count > 0)
                {
                    foreach (Model.book_room item in list)
                    {
                        item.ListBr = fmrdet.GetListModel("Book_no='" + item.book_no + "' and Room_number='" + Request.QueryString["rooms"].ToString() + "' ");
                        txt_roomid.Value = item.ListBr[0].Room_number;
                        ddroomtype.SelectedValue = item.ListBr[0].Real_type_Id.ToString();
                        DDlkrly.SelectedValue = item.source_id.ToString();
                        DDLfjfa.SelectedValue = item.real_scheme_id.ToString();
                        txt_moneys.Value = GetPrice(item.ListBr[0].Real_type_Id);
                        txt_money.Value = item.ListBr[0].Real_Price.ToString("0.##");
                        txt_rzdate.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                       
                        modelsys = bllsys.GetModel(1);
                        TimeSpan dt11 = TimeSpan.Parse(modelsys.DayOutTime.ToString());//得到时间
                        txt_ylDate.Value = Convert.ToDateTime(item.time_from).ToString("yyyy-MM-dd HH:mm:ss");
                        ylDate.Value = Convert.ToDateTime(item.time_from).AddDays(Convert.ToDouble((days - 1) * -1)).ToString();
                        txt_name.Value = item.book_Name;
                        txt_lxphone.Value = item.tele_no;//联系电话
                        txt_zfzhanghao.Value = item.ListBr[0].Room_number;//主房账号   
                        txt_Remaker.Value = item.remark;
                        DDlZffs.SelectedValue = item.meth_pay_id.ToString();//支付方式
                        
                    }
                }
                BindKYGV();
            }
            inpText.Value = sbtable.ToString();
        }
        /// <summary>
        /// 通过房型获得房间原价
        /// </summary>
        /// <returns></returns>
        private string GetPrice(int typeid) {
            Model.room_type modelty = bllrt.GetModel(typeid);
            if (modelty != null) {
                return Convert.ToDecimal(modelty.room_listedmoney).ToString("0.##");
            }
            return "";
        }
        public override void SonLoad()
        {
            txtpath.Value = Request.PhysicalApplicationPath;
            if (!IsPostBack)
            {
                contents = "";
                modelsys = bllsys.GetModel(1);
                count = 0;
                yxcount = 0;
                BindFX();
                BindZFFS();
                BindSFZ();
                BindKFFS();
                BindKRLY();
                BindMoshi();
                BindFJFA();
                string id = Request.QueryString["id"].ToString();

                roomsidcs = "";
                if (Request.QueryString["type"].ToString() == "0")
                {
                    roomsid = (Request.QueryString["id"].ToString());
                    ids = Request.QueryString["id"].ToString();
                    DivDisHidroom.Style.Add("display", "none");
                    bindInfo();
                    //BindKYGV();
                    occno = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace("-", "").Replace(":", "").Replace(" ", "").Replace("/", "");
                    txt_ylDate.Value = System.DateTime.Now.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss:ffff");
                }


                if (Request.QueryString["type"].ToString() == "1")
                {
                    roomsid = fmmx.GetModel(Convert.ToInt32(Request.QueryString["id"].ToString())).room_number;
                    ids = Request.QueryString["id"].ToString();
                    hidSuikeInfo.Value = fmmx.GetModel(Convert.ToInt32(ids.ToString())).room_number;
                    BindUpdateInfo();
                    DivDisHidroom.Style.Add("display", "none");
                    //  DivDisHid.Style.Add("display", "");
                    btn_rooms.Style.Add("display", "none");
                    btn_rooms.Value = "";
                    DivDisHidroom.Style.Add("display", "none");
                    txt_yjmoney.Disabled = true;
                    DDlZffs.Enabled = false;
                    btnAdds.Text = "修改";
                    if (DDlKffs.SelectedItem.Text == "月租房")
                    {
                        moshi.Style.Add("display", "block");
                        listSfrq.Style.Add("display", "block");
                    }
                    txt_zhi.Value = "";
                    DataSet dts = fmmx.GetList(" room_number='" + roomsid + "' and occ_with='是' and state_id=0");
                    foreach (DataRow drs in dts.Tables[0].Rows)
                    {
                        if (txt_zhi.Value == "")
                        {
                            txt_zhi.Value += drs["room_number"].ToString() + "," + drs["occ_name"].ToString() + "," + drs["sex"].ToString() + "," + drs["brithday"].ToString() + "," + fsfBll.GetModel(Convert.ToInt32(drs["card_id"].ToString())).ct_name + "," + drs["card_no"].ToString() + "," + drs["address"].ToString();

                        }
                        else
                        {
                            txt_zhi.Value += "|" + drs["room_number"].ToString() + "," + drs["occ_name"].ToString() + "," + drs["sex"].ToString() + "," + drs["brithday"].ToString() + "," + fsfBll.GetModel(Convert.ToInt32(drs["card_id"].ToString())).ct_name + "," + drs["card_no"].ToString() + "," + drs["address"].ToString();
                        }
                    }
                }
                if (Request["type"] != null)
                {
                    if (Request["type"].ToString() == "yding")//预定转入住
                    {
                        type.Value = "yuding";
                        isZF.Value = "";
                        occno = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff").Replace("-", "").Replace(":", "").Replace(" ", "").Replace("/", "");
                        ids = Request.QueryString["id"].ToString();//预定表的ID号
                        ydBindsInfo();
                        if (txt_yjmoney.Value.ToString()=="")
                        {

                        }
                        else
                        {
                            txt_yjmoney.Disabled = true;
                        }
                        DDlZffs.Enabled = false;
                        //string ydRoomnum = "";
                        DataSet dt = fhBll.GetList(" Rn_roomNum in (" + Request.QueryString["xqid"].ToString() + ")");
                        foreach (DataRow dr in dt.Tables[0].Rows)
                        {
                            if (roomsid == null || roomsid == "")
                            {
                                roomsid = dr["id"].ToString();
                            }
                            else
                            {
                                roomsid += "," + dr["id"].ToString();

                            }
                        }

                        txt_roomnumber.Value = roomsid;
                        DivDisHidroom.Style.Add("display", "");
                        btn_rooms.Value = "终止开房";
                        //bindInfo();
                        //BindYXGV();
                        //BindKYGV();
                    }

                }

                roomycid = "";
                cardnumber = "";
                if (Request.QueryString["type"] == "0")
                {
                    if (IsEraly())
                    {

                        //DDlKffs.SelectedIndex = 4;
                        DDlKffs.SelectedIndex = DDlKffs.Items.IndexOf(DDlKffs.Items.FindByText("凌晨房"));
                        if (Request.QueryString["type"].ToString() == "0")
                        {
                            txt_money.Value = Convert.ToDecimal(bllrt.GetModel(Convert.ToInt32(fhBll.GetModel(Convert.ToInt32(ids)).Rn_room)).Room_ealry_price).ToString("0.##");

                        }
                        else if (Request.QueryString["type"].ToString() == "1")
                        {
                            txt_money.Value = Convert.ToDecimal(bllrt.GetModel(fmmx.GetModel(Convert.ToInt32(ids)).real_type_id).Room_ealry_price).ToString("0.##");
                        }
                        else
                        {
                            txt_money.Value = Convert.ToDecimal(bllrt.GetModel(fmrdet.GetListModel(" Book_no='" + Request.QueryString["ydbookno"].ToString() + "' and Room_number='" + Request.QueryString["rooms"].ToString() + "'")[0].Real_type_Id).Room_ealry_price).ToString("0.##");

                        }
                    }
                    else
                    {
                        DDlKffs.Items.Remove(DDlKffs.Items.FindByText("凌晨房")); //按显示文本删除
                    }
                    TimeSpan dt1 = TimeSpan.Parse(modelsys.DayTime.ToString());//得到时间
                    TimeSpan dt11 = TimeSpan.Parse(modelsys.DayOutTime.ToString());//得到时间
                    DateTime dt2 = DateTime.Now;//得到当前时间

                    DateTime dts = Convert.ToDateTime(Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd")).AddHours(dt1.Hours);//得到今日凌晨房开始时间
                    TimeSpan to1 = dt2 - dts;
                    if (to1.TotalSeconds < 0)
                    {
                        txt_ylDate.Value = Convert.ToDateTime(Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd")).AddHours(12).ToString("yyyy-MM-dd HH:mm:ss");

                    }
                    else
                    {
                        txt_ylDate.Value = Convert.ToDateTime(Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd")).AddDays(1).AddHours(dt11.Hours).ToString("yyyy-MM-dd HH:mm:ss");
                    }

                    /*先判断房号表里有没有1*/
                    List<Model.Book_Rdetail> listrn = bllbr.GetListModel("Room_number='" + txt_roomid.Value + "' and Room_typeid!=2");
                    if (listrn.Count > 0) {
                        string bookno = listrn[0].Book_no;
                        List<Model.book_room> listbr = bllbr1.GetModelList("book_no='" + bookno + "'");
                        if (listbr.Count > 0) {
                            redsp.Style.Add("display", "block");
                            retime.InnerText = listbr[0].time_to.ToString();
                        }
                    }
                }



                if (Request.QueryString["type"] == "jiakai") {
                    string ids = Request.QueryString["id"];
                    Model.occu_infor modelocci = fmmx.GetModel(Convert.ToInt32(ids));
                    txt_zfzhanghao.Value = modelocci.lordRoomid;
                    txt_yjmoney.Disabled = true;
                    txt_zfzhanghao.Disabled = true;
                    kftype.Value = "加开";
                    occno = modelocci.order_id;
                    txt_rzdate.Value = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    TimeSpan dt11 = TimeSpan.Parse(modelsys.DayOutTime.ToString());//得到时间
                    txt_ylDate.Value = Convert.ToDateTime(Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd")).AddDays(1).AddHours(dt11.Hours).ToString("yyyy-MM-dd HH:mm:ss");
                }
            }
            else 
            {
               // ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "click", "reload();", true);

            }
            DDlKffs.Items.Remove(DDlKffs.Items.FindByText("自用房")); //按显示文本删除
        }
        BLL.Book_Rdetail bllbr = new BLL.Book_Rdetail();
        BLL.book_room bllbr1 = new BLL.book_room();
        ///// <summary>
        ///// 折后价
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void DDLfjfa_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    txt_money.Value =(double.Parse( fmfjfa.GetModel(Convert.ToInt32(DDLfjfa.SelectedValue)).hs_Discount )* double.Parse(txt_moneys.Value)).ToString();
        //}
        ///// <summary>
        ///// 开房方式
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void btnkffs_Click(object sender, EventArgs e)
        //{

        //    if (DDlKffs.SelectedItem.Text.Trim() == "月租房")
        //    {
        //        txt_money.Value = fxBll.GetModel(Convert.ToInt32(ddroomtype.SelectedValue)).Room_Moth_price.ToString();
        //        txt_moneys.Value = txt_money.Value;
        //        moshi.Style.Add("display", "block");
        //        listSfrq.Style.Add("display", "block");
        //        fangan.Style.Add("display", "none");
        //        txt_ylDate.Value = Convert.ToDateTime(txt_rzdate.Value).AddMonths(1).ToString();
        //        ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "JSS('1');", true);
        //    }
        //    else if (DDlKffs.SelectedItem.Text.Trim() == "钟点房")
        //    {
        //        txt_Day.Value = "0";
        //     fangan.Style.Add("display","block");
        //     moshi.Style.Add("display", "none");
        //     listSfrq.Style.Add("display", "none");
        //     ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "JSS('1');", true);
        //    }
        //    else if (DDlKffs.SelectedItem.Text.Trim() == "免费房")
        //    {
        //        txt_money.Value = "0.00";
        //        txt_money.Disabled = true;
        //        moshi.Style.Add("display", "none");
        //        ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "JSS('1');", true);
        //    }
        //    else
        //    {
        //        txt_Day.Value = "1"; 
        //        txt_money.Value = fhBll.GetModel(Convert.ToInt32(ids)).Rn_price.ToString();
        //        txt_moneys.Value = fhBll.GetModel(Convert.ToInt32(ids)).Rn_price.ToString();
        //        moshi.Style.Add("display", "none");
        //        listSfrq.Style.Add("display", "none");
        //        fangan.Style.Add("display", "none");
        //        modelsys = bllsys.GetModel(1);
        //        TimeSpan dt11 = TimeSpan.Parse(modelsys.DayOutTime.ToString());//得到时间
        //        txt_ylDate.Value = Convert.ToDateTime(Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd")).AddDays(1).AddHours(dt11.Hours).ToString();
        //        ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "JSS('1');", true);
        //    }
            
        //}
    }
}
