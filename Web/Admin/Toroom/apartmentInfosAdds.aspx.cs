using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace CdHotelManage.Web.Admin.Toroom
{
    public partial class apartmentInfosAdds : BasePage
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
            modelsys = bllsys.GetModel(1);
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
      

        /// <summary>
        /// 绑定支付方式
        /// </summary>
        public void BindZFFS()
        {
            DDlZffs.DataSource = fmzffs.GetAllList();
            DDlZffs.DataBind();
            int count = fmzffs.GetRecordCount(" 1=1");
           // count = count - 2;
            DDlZffs.Items.Insert(count, "信用预授权");
           // DDlZffs.Items.RemoveAt(0);
        }

        
        public void bindInfo()
        {
            Model.room_number mod = new Model.room_number();

            BindYXGV();
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
                          + "否" + "#"
                          + (item.real_time.ToString()) + "#"
                          + 1 + "#"
                          + (item.time_from.ToString()) + "#"
                          + item.book_Name + "#"
                          + this.txt_Sex.Value + "#"
                          + this.txt_Date2.Value + "#"
                          + this.txt_mingzhu.Value + "#"
                          + (this.DDlSFz.SelectedValue) + "#"
                          + (this.txt_CardId.Value) + "#"
                        
                          + item.remark + "#"
                          + (item.meth_pay_id.ToString()) + "#"
                          + txt_address.Value + "#"
                          + item.ListBr[0].Room_number + "#" + item.tele_no + "|";
                        }

                    }

                }

            }
            if (Request.QueryString["type"].ToString() == "0")
            {
                txt_roomid.Value = fhBll.GetModel(Convert.ToInt32(ids)).Rn_roomNum;
                ddroomtype.SelectedValue = fhBll.GetModel(Convert.ToInt32(ids)).Rn_room.ToString();
                txt_money.Value = fhBll.GetModel(Convert.ToInt32(ids)).Rn_price.ToString();
                txt_rzdate.Value = System.DateTime.Now.ToString();
                txt_roomnumber.Value = ids.ToString();
                txt_zfzhanghao.Value = txt_roomid.Value;
              
                contents += this.txt_roomid.Value + "#"
                          + (this.ddroomtype.SelectedValue) + "#"
                         
                        
                          + "否" + "#" 
                          + (this.txt_rzdate.Value) + "#"
                          + (this.txt_Day.Value) + "#"
                          + (this.txt_ylDate.Value) + "#"
                          + this.txt_name.Value + "#"
                          + this.txt_Sex.Value + "#"
                          + this.txt_Date2.Value + "#"
                          + this.txt_mingzhu.Value + "#"
                          + (this.DDlSFz.SelectedValue) + "#"
                          + (this.txt_CardId.Value) + "#"
                        
                          + this.txt_Remaker.Value + "#"
                          + (DDlZffs.SelectedValue) + "#"
                          + txt_address.Value + "#"
                          + txt_zfzhanghao.Value + "#" + txt_lxphone.Value + "|";
            }
           
        }
        /// <summary>
        ///添加入住信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdds_Click(object sender, EventArgs e)
        {
           
            try
            {
                Model.order_infor ordermodel = new Model.order_infor();
                Model.goods_account goodmodles = new Model.goods_account();
                Model.goods_account goodmodlfz = new Model.goods_account();
                CdHotelManage.Model.occu_infor model = new CdHotelManage.Model.occu_infor();
                CdHotelManage.Model.occu_infor models = new CdHotelManage.Model.occu_infor();
                CdHotelManage.BLL.occu_infor bll = new CdHotelManage.BLL.occu_infor();
                model.order_id = occno;
                model.occ_no = "RZ"+System.DateTime.Now.ToString().Replace("-", "").Replace(":", "").Replace(" ", "").Replace("/", "");
                model.room_number = this.txt_roomid.Value;
                model.real_type_id = Convert.ToInt32(this.ddroomtype.SelectedValue);
            
                model.real_price = Convert.ToDecimal(this.txt_money.Value);
                model.occ_with = "否";
              
                model.occ_time = Convert.ToDateTime(this.txt_rzdate.Value);
                model.stay_day = Convert.ToInt32(this.txt_Day.Value);
                model.depar_time = Convert.ToDateTime(this.txt_ylDate.Value);
                model.occ_name = this.txt_name.Value;
                model.sex = this.txt_Sex.Value;
                model.brithday = this.txt_Date2.Value;
                model.family_name = this.txt_mingzhu.Value;
                model.card_id = Convert.ToInt32(this.DDlSFz.SelectedValue); ;
                model.card_no = (this.txt_CardId.Value);
      
                model.remark = this.txt_Remaker.Value;//备注
              
                if (DDlZffs.SelectedValue == "信用预授权")
                {
                   // model.meth_pay_id = 0;
                }
                else
                {
                    model.meth_pay_id = Convert.ToInt32(DDlZffs.SelectedValue);//支付方式
                }
                model.deposit = Convert.ToDecimal(txt_yjmoney.Value);
                model.address = txt_address.Value;//地址
                model.lordRoomid = txt_zfzhanghao.Value;//主房账号
                model.phonenum = txt_lxphone.Value;//联系电话
                model.tuifaId = "0";
                model.continuelive = 0;
                model.sort = txtsort.Value;
                string[] hidAdd = contents.Split('|');
                if (Request.QueryString["type"].ToString() == "0" || Request.QueryString["type"].ToString() == "yding")
                {
                    if (hidAdd.Length > 2)
                    {
                        for (int i = 0; i < hidAdd.Length-1; i++)
                        {
                            try
                            {
                                string NumNo = "000" + i;
                                string a = hidAdd[i].Split('#')[0].Trim();

                                model.order_id = occno.ToString();
                                model.occ_no = "RZ" + System.DateTime.Now.ToString().Replace("-", "").Replace(":", "").Replace(" ", "").Replace("/", "") + NumNo;
                                model.room_number = hidAdd[i].Split('#')[0];
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
                                if (a != "")
                                {

                                    if (model.lordRoomid == model.room_number)
                                    {
                                        model.deposit = Convert.ToDecimal(txt_yjmoney.Value);
                                        model.remark = txt_Remaker.Value;
                                    }
                                    else
                                    {
                                        model.deposit = 0;
                                        txt_Remaker.Value = "";
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
                                    goodmodlfz.ga_sum_price = Convert.ToDecimal(hidAdd[i].Split('#')[4]);
                                    goodmodlfz.ga_number = "FZ" + System.DateTime.Now.ToString().Replace("-", "").Replace(":", "").Replace(" ", "").Replace("/", "");
                                    goodmodlfz.ga_price = 0;
                                    goodmodlfz.ga_date = Convert.ToDateTime(System.DateTime.Now);
                                    goodmodlfz.ga_people = UserNow.UserID;
                                    goodmodlfz.ga_sfacount = "否";
                                    goodmodlfz.ga_Type = 8;
                                    goodmodlfz.ga_isjz = 0;
                                    goodmodles.Ga_goodNo = bll.GetModels(" where occ_with='否' and room_number='" + txt_roomid.Value + "' and state_id=0").occ_no;

                                   // goodmodlfz.ga_zffs_id = Convert.ToInt32(DDlZffs.SelectedValue);
                                    goodmodlfz.ga_remker = txt_Remaker.Value;
                                    goodmodlfz.ga_roomNumber = model.room_number;
                                    goodmodlfz.ga_occuid = occno;
                                    fmzj.Add(goodmodlfz);
                                    string str2 = "update room_number set Rn_state=2 where Rn_roomNum='" + model.room_number + "'";
                                    fhBll.Updates(str2);
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
                            goodmodlfz.ga_number = "FZ" + System.DateTime.Now.ToString().Replace("-", "").Replace(":", "").Replace(" ", "").Replace("/", "");
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
                            fmzj.Add(goodmodlfz);
                            string SQl = "update room_number set Rn_state=2 where Rn_roomNum='" + txt_roomid.Value + "'";
                            fhBll.Updates(SQl);
                        }
                    }

                }
                if (Request.QueryString["type"].ToString() == "1")
                {
                    model.order_id = fmmx.GetModels(" where occ_with='否' and state_id=0 and room_number='" + roomsid + "'").order_id;
                    model.occ_id = Convert.ToInt32(ids);

                    if (bll.Update(model))
                    {
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
                        goodmodles.ga_number = "YZYJ" + System.DateTime.Now.ToString().Replace("-", "").Replace(":", "").Replace(" ", ""); ;
                        goodmodles.ga_price = Convert.ToDecimal(txt_yjmoney.Value);
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
                            goodmodles.ga_occuid = occno;
                           // goodmodles.ga_zffs_id = Convert.ToInt32(DDlZffs.SelectedValue);
                        }
                        fmzj.Add(goodmodles);

                        ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "click", "if(confirm('开房成功，是否打印入住单')){PrintRZ(this," + model.order_id + ");}else{ShowTabs('房态图');}", true);
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
                    models.order_id = fmmx.GetModels(" where occ_with='否' and state_id=0 and room_number='" + roomsid + "'").order_id;
                    models.room_number = content[i].Split(',')[0];
                    models.occ_name = content[i].Split(',')[1];
                    models.sex = content[i].Split(',')[2];
                    models.brithday = content[i].Split(',')[3];
                    models.card_id = fsfBll.GetModelList(" ct_name='" +content[i].Split(',')[4] + "'")[0].id;
                    models.card_no = content[i].Split(',')[5];
                    models.address = content[i].Split(',')[6];
                    models.occ_time = Convert.ToDateTime(System.DateTime.Now.ToString());
                    models.occ_with = "是";
                    //  models.room_number = this.txt_roomid.Value;
                    bll.Add(models);
                }
            }
            catch { }

        }
        /// <summary>
        /// 绑定可选可选房间
        /// </summary>
        public void BindKYGV()
        {
            DivKXRoom.InnerHtml = "";
            DataSet dt = null;
            string Table = "<table width='40%' border='0' cellspacing='0' cellpadding='0'><tr> <thead><td>房号</td><td>房间类型</td><td>房价</td> </thead></tr> <tbody>";

            if (roomsid == "" || roomsid == null)
            {
                dt = fhBll.GetList(" Rn_state=3  ");
            }
            else
            {
                dt = fhBll.GetList("Rn_state=3 and id not in (" + roomsid + ") ");
            }

            foreach (DataRow dr in dt.Tables[0].Rows)
            {
                Table += "<tr class='tr1' onclick='BTncher(" + dr["id"] + ",1)'><td style='width:70px;'>" + dr["Rn_roomNum"].ToString() + "</td><td style='width:260px;'>" + GetRealTypeName( Convert.ToInt32( dr["Rn_room"].ToString())) + "</td><td style='width:70px;'>" + dr["Rn_price"].ToString() + "</td></tr>";

            }
            Table += " </tbody></table>";
            DivKXRoom.InnerHtml = Table;
        }
        /// <summary>
        /// 绑定已选房间
        /// </summary>
        public void BindYXGV()
        {
            DivKXRoom.InnerHtml = "";
            DataSet dt = null;
            string Table = "<table width='400px' border='0' cellspacing='0' cellpadding='0'><tr> <thead><td>房号</td><td>房间类型</td><td>房价</td> </thead></tr> <tbody>";
            if (roomsid == "" || roomsid == null)
            {
                dt = fhBll.GetList(" 1 !=1 ");
            }
            else
            { 
                dt = fhBll.GetList(" id in (" + roomsid + ") ");      
            }
            foreach (DataRow dr in dt.Tables[0].Rows)
            {
                Table += "<tr class='tr1' onclick='BTncher(" + dr["id"] + ",0)'><td style='width:70px;'>" + dr["Rn_roomNum"].ToString() + "</td><td style='width:260px;'>" + GetRealTypeName(Convert.ToInt32(dr["Rn_room"].ToString())) + "</td><td style='width:70px;'>" + dr["Rn_price"].ToString() + "</td></tr>";

            }
            Table += " </tbody></table>";
            DivYXRoom.InnerHtml = Table;
        }
        /// <summary>
        /// 多人开房绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBind_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(txt_id.Value);

            Model.room_number mod = new Model.room_number();
            txt_roomid.Value = fhBll.GetModel(id).Rn_roomNum;
            ddroomtype.SelectedValue = (fhBll.GetModel(id).Rn_room).ToString();
            txt_money.Value = (fhBll.GetModel(id).Rn_price).ToString();
            txt_rzdate.Value = System.DateTime.Now.ToString();
            string a = hidSchool.Value;
            if (txt_type.Value == "0")
            {
                string[] Content = contents.Split('|');

                for (int i = 0; i < Content.Length - 1; i++)
                {
                    if (Content[i].Split('#')[0] == txt_roomid.Value)
                    {
                        string b = Content[i].Split('#')[3].ToString();
                        txt_name.Value = Content[i].Split('#')[10];
                        txt_Sex.Value = Content[i].Split('#')[11];
                        txt_CardId.Value = Content[i].Split('#')[15];
                        txt_ylDate.Value = Content[i].Split('#')[7];
                        txt_zfzhanghao.Value = Content[i].Split('#')[20];
                        txt_Day.Value = Content[i].Split('#')[8];
                        txt_Date2.Value = Content[i].Split('#')[12];
                        txt_CardId.Value = Content[i].Split('#')[15];
                        DDlSFz.SelectedValue = Content[i].Split('#')[14];
                      //  txt_address.Value = Content[i].Split('#')[20];
                        txt_mingzhu.Value = Content[i].Split('#')[13];
                  
                        txt_address.Value = Content[i].Split('#')[19];
                    }
                }
            }
           
            btn_rooms.Value = "终止开房";
            DivDisHidroom.Style.Add("display", "block");

        }

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
                            + Convert.ToInt32(this.ddroomtype.SelectedValue) + "#"
                           
                         
                            + this.txt_money.Value + "#"
                            + "否" + "#" 
                            + (this.txt_rzdate.Value) + "#"
                            + Convert.ToInt32(this.txt_Day.Value) + "#"
                            + (this.txt_ylDate.Value) + "#"
                            + this.txt_name.Value + "#"
                            + this.txt_Sex.Value + "#"
                            + this.txt_Date2.Value + "#"
                            + this.txt_mingzhu.Value + "#"
                            + Convert.ToInt32(this.DDlSFz.SelectedValue) + "#"
                            + (this.txt_CardId.Value) + "#"
                         
                            + this.txt_Remaker.Value + "#"
                            + Convert.ToInt32(DDlZffs.SelectedValue) + "#"
                            + txt_address.Value + "#"
                            + txt_zfzhanghao.Value + "#" + txt_lxphone.Value + "|";
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
                       + Convert.ToInt32(this.ddroomtype.SelectedValue) + "#"
                     
                       + this.txt_money.Value + "#"
                       + "否" + "#" 
                       + (this.txt_rzdate.Value) + "#"
                       + Convert.ToInt32(this.txt_Day.Value) + "#"
                       + (this.txt_ylDate.Value) + "#"
                       + this.txt_name.Value + "#"
                       + this.txt_Sex.Value + "#"
                       + this.txt_Date2.Value + "#"
                       + this.txt_mingzhu.Value + "#"
                       + Convert.ToInt32(this.DDlSFz.SelectedValue) + "#"
                       + (this.txt_CardId.Value) + "#"
                     
                       + this.txt_Remaker.Value + "#"
                       + Convert.ToInt32(DDlZffs.SelectedValue) + "#"
                       + txt_address.Value + "#"
                       + txt_zfzhanghao.Value + "#" + txt_lxphone.Value;
                }
                contents += Content[i] + "|";
                string c = Content[i];

            }
            
            btn_rooms.Value = "终止开房";
            DivDisHidroom.Style.Add("display", "block");

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
              
                txt_money.Value = dr["real_price"].ToString();
              
                txt_rzdate.Value = dr["occ_time"].ToString();
                txt_Day.Value = dr["stay_day"].ToString();
                txt_ylDate.Value = dr["depar_time"].ToString();
                txt_name.Value = dr["occ_name"].ToString();
                txt_Sex.Value = dr["sex"].ToString();
                txt_Date2.Value = dr["brithday"].ToString();
                txt_mingzhu.Value = dr["family_name"].ToString();
                DDlSFz.SelectedValue = dr["card_id"].ToString();
                txt_CardId.Value = dr["card_no"].ToString();
              
                txt_address.Value = dr["address"].ToString();//地址
                txt_lxphone.Value = dr["phonenum"].ToString();//联系电话
                txt_zfzhanghao.Value = dr["lordRoomid"].ToString();//主房账号   
                txt_Remaker.Value = dr["remark"].ToString();
                DDlZffs.SelectedValue = dr["meth_pay_id"].ToString();//支付方式
                txt_yjmoney.Value = dr["deposit"].ToString();//押金
            }
        }
        public void BindNull()
        {
            txt_Sex.Value = "";
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
        /// 
        /// </summary>
 
        public void ydBindsInfo()
        {

            IList<Model.book_room> list = brBll.GetBookRoomPager("book_id", "Desc", 1, 1, " WHERE book_id='"+Request.QueryString["id"].ToString()+"'");
            if (list.Count > 0)
            {
                foreach (Model.book_room item in list)
                {
                    item.ListBr = fmrdet.GetListModel("Book_no='" + item.book_no + "' and Room_number='" + Request.QueryString["rooms"].ToString() + "' ");
                    txt_roomid.Value = item.ListBr[0].Room_number;
                    ddroomtype.SelectedValue = item.ListBr[0].Real_type_Id.ToString();
                  
                    txt_money.Value = item.ListBr[0].Real_Price.ToString();
                    txt_rzdate.Value = item.real_time.ToString();
                    txt_Day.Value = "1";
                    txt_ylDate.Value = item.time_from.ToString();
                    txt_name.Value = item.book_Name;
                    txt_lxphone.Value =item.tele_no;//联系电话
                    txt_zfzhanghao.Value = item.ListBr[0].Room_number;//主房账号   
                    txt_Remaker.Value = item.remark;
                    DDlZffs.SelectedValue = item.meth_pay_id.ToString();//支付方式
                    txt_yjmoney.Value = item.deposit.ToString();//押金
                }
               
            }

        }

        public override void SonLoad()
        {
            if (!IsPostBack)
            {
              
                contents = "";

                count = 0;
                yxcount = 0;
                BindFX();
                BindZFFS();
                BindSFZ();
               
                string id = Request.QueryString["id"].ToString();

                roomsidcs = "";
                if (Request.QueryString["type"].ToString() == "0")
                {
                    roomsid = (Request.QueryString["id"].ToString());
                    ids = Request.QueryString["id"].ToString();
                    DivDisHidroom.Style.Add("display", "none");
                    bindInfo();
                    BindKYGV();
                    occno = System.DateTime.Now.ToString().Replace("-", "").Replace(":", "").Replace(" ", "").Replace("/", "");
                    txt_ylDate.Value = System.DateTime.Now.AddDays(1).ToString();
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
                }
                if (Request["type"] != null)
                {
                    if (Request["type"].ToString() == "yding")
                    {
                        occno = System.DateTime.Now.ToString().Replace("-", "").Replace(":", "").Replace(" ", "").Replace("/", "");
                        ids = Request.QueryString["id"].ToString();
                        ydBindsInfo();
                        txt_yjmoney.Disabled = true;
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
                        bindInfo();
                        BindYXGV();
                        BindKYGV();
                    }

                }

                roomycid = "";
                cardnumber = "";
                if (Request.QueryString["type"] == "0")
                {
                    if (IsEraly())
                    {

                        //DDlKffs.SelectedIndex = 4;
                      
                        if (Request.QueryString["type"].ToString() == "0")
                        {
                            txt_money.Value = bllrt.GetModel(Convert.ToInt32(fhBll.GetModel(Convert.ToInt32(ids)).Rn_room)).Room_ealry_price.ToString();

                        }
                        else if (Request.QueryString["type"].ToString() == "1")
                        {
                            txt_money.Value = bllrt.GetModel(fmmx.GetModel(Convert.ToInt32(ids)).real_type_id).Room_ealry_price.ToString();
                        }
                        else
                        {
                            txt_money.Value = bllrt.GetModel(fmrdet.GetListModel(" Book_no='" + Request.QueryString["ydbookno"].ToString() + "' and Room_number='" + Request.QueryString["rooms"].ToString() + "'")[0].Real_type_Id).Room_ealry_price.ToString();

                        }
                    }
                  
                    TimeSpan dt1 = TimeSpan.Parse(modelsys.DayTime.ToString());//得到时间
                    TimeSpan dt11 = TimeSpan.Parse(modelsys.DayOutTime.ToString());//得到时间
                    DateTime dt2 = DateTime.Now;//得到当前时间

                    DateTime dts = Convert.ToDateTime(Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd")).AddHours(dt1.Hours);//得到今日凌晨房开始时间
                    TimeSpan to1 = dt2 - dts;
                    if (to1.TotalSeconds < 0)
                    {
                        txt_ylDate.Value = Convert.ToDateTime(Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd")).AddHours(12).ToString();

                    }
                    else
                    {
                        txt_ylDate.Value = Convert.ToDateTime(Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd")).AddDays(1).AddHours(dt11.Hours).ToString();
                    }
                }
            }
        }
       
    }
}
