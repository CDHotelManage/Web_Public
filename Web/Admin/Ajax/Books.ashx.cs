using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Data;

namespace CdHotelManage.Web.Admin.Ajax
{
    /// <summary>
    /// Books 的摘要说明
    /// </summary>
    public class Books : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        HttpContext context;
        BLL.book_room bllbr = new BLL.book_room();
        BLL.room_type bllrt = new BLL.room_type();
        BLL.Book_Rdetail bllrd = new BLL.Book_Rdetail();
        BLL.room_number bllrn = new BLL.room_number();
        BLL.occu_infor fmoc = new BLL.occu_infor();
        BLL.Goods fmgood = new BLL.Goods();
        Model.AccountsUsers userNow = null;
        public Model.AccountsUsers UserNow
        {
            get
            {
                if (userNow == null)
                {
                    string uid = context.Request.Cookies["User"].Value;
                    userNow = bllu.GetModel(uid);
                    //userNow = context.Session["User"] as Model.AccountsUsers;
                }
                return userNow;
            }
        }
        BLL.AccountsUsersBLL bllu = new BLL.AccountsUsersBLL();

        public void ProcessRequest(HttpContext context)
        {
            this.context = context;
            string type = context.Request["type"].ToString();
            switch (type)   
            {
                case "AddZ":
                    AddBook();
                    break;
                case "updatePrice":
                    UpdatePrice();
                    break;
                case "getdel":
                    Getdel();
                    break;
                case "UpdateRd":
                    UpdateRd();
                    break;
                case "delids":
                    Delids();
                    break;
                case "goodsprice":
                    Getprice();
                    break;
                case "getname":
                    GetName();
                    break;
                case "getBind":
                    getbind();
                    break;
                case "getRoom":
                    GetRoom();
                    break;
                case "getCost":
                    GetCost();
                    break;
                case "getGoods":
                    GetGoods();
                    break;
                case "getNames":
                    GetNames();
                    break;
                case "getNames1":
                    GetNames1();
                    break;
                case "getFx":
                    GetFx();
                    break;
                case "getYLTIME":
                    GetYLTIME();
                    break;
                case "getOkNum":
                    GetOkNum();
                    break;
                case "getmaxNum":
                    GetmaxNum();
                    break;
                case "ucolor":
                    Ucolor();
                    break;
                case "updateSeesion":
                    UpdateSeesion();
                    break;
                case "UpState":
                    UpSate();
                    break;
                case "delga":
                    Delga();
                    break;
                case "chafeng":
                    Chafeng();
                    break;
                case "isdel":
                    Isdel();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 是否可以删除房价方案
        /// </summary>
        private void Isdel()
        {
            string id=context.Request.QueryString["id"];
            List<Model.occu_infor> listoc = blloc.GetModelList("real_scheme_id=" + id);
            if (listoc.Count > 0)
            {
                context.Response.Write("err");
            }
            else {
                BLL.hourse_scheme bllhs = new BLL.hourse_scheme();
                if (bllhs.Delete( Convert.ToInt32(id))) { 
                context.Response.Write("ok");
                }
            }
        }


        BLL.occu_infor blloc = new BLL.occu_infor();
        private void Chafeng()
        {
            try
            {
                System.Text.StringBuilder sbtext = new System.Text.StringBuilder();
                string occno = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace("-", "").Replace(":", "").Replace(" ", "").Replace("/", "");
                int id = Convert.ToInt32(context.Request.QueryString["id"]);
                Model.occu_infor modelocc = blloc.GetModel(id);
                if (modelocc.room_number == modelocc.lordRoomid) {
                    context.Response.Write("err");
                    context.Response.End();
                }
                else
                {
                    List<Model.occu_infor> listicc = blloc.GetModelList("order_id='" + modelocc.order_id + "'");
                    foreach (Model.occu_infor item in listicc)
                    {
                        sbtext.Append(item.room_number + ",");
                    }
                    List<Model.goods_account> listga = bllga.GetModelList1("ga_occuid='" + modelocc.order_id + "' and ga_roomNumber='" + modelocc.room_number + "'");
                    if (listga.Count > 0)
                    {
                        foreach (Model.goods_account item in listga)
                        {
                            item.ga_occuid = occno;
                            bllga.Update(item);
                        }
                    }
                    Helper.AddRoom(modelocc.room_number, sbtext.ToString());
                    modelocc.order_id = occno;
                    modelocc.GzRoom = "";
                    modelocc.lordRoomid = modelocc.room_number;
                    blloc.Update(modelocc);
                    context.Response.Write("ok");
                    context.Response.End();
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }

        }

        private void Delga()
        {
            int id = Convert.ToInt32(context.Request.QueryString["id"]);
            Model.goods_account modelga = bllga.GetModel(id);
            if (modelga.ga_isjz == 1 || modelga.ga_isys == 1) {
                context.Response.Write("err");
                context.Response.End();
            }
            if (bllga.Delete(id)) {
                context.Response.Write("ok");
                context.Response.End();
            }
        }
        BLL.occu_infor bllic = new BLL.occu_infor();
        /// <summary>
        /// 修改房态
        /// </summary>
        private void UpSate()
        {
            try
            {
                string SQl = "";
                string roomNum = context.Request.QueryString["hidRoom"];
                string a = context.Request.QueryString["hidNumber"];
                if (bllic.GetModel(Convert.ToInt32(roomNum)) != null)
                {
                    string num = bllic.GetModel(Convert.ToInt32(roomNum)).room_number;
                    Helper.AddRoom(num);
                    roomNum = bllrn.GetModelList("Rn_roomNum='" + num + "'")[0].id.ToString();
                }
                else
                {
                    Helper.AddRoom(bllrn.GetModel(Convert.ToInt32(roomNum)).Rn_roomNum);
                }
                if (a == "0")
                {
                    //脏房
                    SQl = "update room_number set Rn_state=4 where id=" + roomNum + "";

                }
                //if (hidNumber.Value == "1")
                //{
                //    //维修
                //    SQl = "update room_number set Rn_state=5 where id=" + roomNum + "";

                //}
                if (a == "2")
                {
                    //干净房
                    SQl = "update room_number set Rn_state=3 where id=" + roomNum + "";

                }

                if (a == "3")
                {
                    //锁定
                    SQl = "update room_number set Room_suod='是' where id=" + roomNum + "";
                }
                if (a == "4")
                {
                    //没有锁定
                    SQl = "update room_number set Room_suod='否' where id=" + roomNum + "";
                }
                if (a == "5")
                {
                    //脏住房
                    SQl = "update room_number set Rn_state=7 where id='" + roomNum + "'";
                }
                if (a == "6")
                {
                    //干净房
                    SQl = "update room_number set Rn_state=2 where id=" + roomNum + "";
                }
                if (a == "7")
                {
                    //自用房
                    SQl = "update room_number set Rn_state=8 where id=" + roomNum + "";
                }
                brBll.Updates(SQl);
                context.Response.Write("更新成功!");
            }
            catch (Exception ex)
            {
                context.Response.Write("更新失败!");
            }
        }

        BLL.room_number brBll = new BLL.room_number();
        public List<Model.occu_infor> ListOcc { get; set; }
        Dictionary<string, string> dicstr = new Dictionary<string, string>();
        BLL.occu_infor fmmx = new BLL.occu_infor();
        //更新连房ICOSession
        private void UpdateSeesion()
        {
            int index = 0;
            ListOcc = fmmx.GetModelList("occ_with='否' and state_id=0");
            if (ListOcc.Count > 1)
            {


                foreach (Model.occu_infor item in ListOcc)
                {
                    List<Model.occu_infor> listocc1 = fmmx.GetModelList("order_id='" + fmmx.GetModels(" where occ_with='否' and occ_no!='' and state_id=0 and room_number='" + item.room_number + "'").order_id + "' and occ_no!='' and state_id=0");
                    if (listocc1.Count > 1)
                    {
                        if (dicstr.ContainsKey(item.room_number.ToString()))
                        { //如果包含
                            //LFimg = dicstr[drs["Rn_roomNum"].ToString()];
                        }
                        else
                        {
                            index++;

                            foreach (Model.occu_infor i1 in listocc1)
                            {
                                if (!dicstr.ContainsKey(i1.room_number))
                                {
                                    dicstr.Add(i1.room_number, "<img src='/admin/images/" + index + ".png' />");
                                }
                            }
                        }
                    }
                }
            }
            context.Session["dic"] = dicstr;
        }

        private void Ucolor()
        {
            string id = context.Request.QueryString["id"];
            string color = context.Request.QueryString["color"];
            Model.room_state modelrs = new Model.room_state();
            modelrs= bllrs.GetModel( Convert.ToInt32(id));
            modelrs.Room_color = color;
            bllrs.Update(modelrs);
        }

        BLL.room_state bllrs = new BLL.room_state();

        private void GetmaxNum()
        {
            string room_type_Id = context.Request.QueryString["typeid"];
            //List<Model.room_number> list = bllrn.GetModelList("Rn_room=" + room_type_Id + " and Rn_state=3 and Rn_ToBe!=1");
            double oknum = Convert.ToDouble(context.Request.QueryString["txtOkNum"]);
            double bfb = bllrt.GetModel(Convert.ToInt32(room_type_Id)).Room_Bfb;
            int maxNums = Convert.ToInt32(oknum + (oknum * bfb * 0.01));
            context.Response.Write(maxNums);
        }

        private void GetOkNum()
        {
            string room_type_Id = context.Request.QueryString["typeid"];
            string real_time = context.Request.QueryString["real_time"];
            List<Model.room_number> list = bllrn.GetModelList("Rn_room=" + room_type_Id + " and Rn_state=3");
            List<Model.book_room> listbook = bllbr.GetModelList("DateDiff(s,'" + real_time + "',time_from)>0 and state_id in (1,6)");
            int sumint = 0;
            if (listbook.Count > 0)
            {
                foreach (Model.book_room item in listbook)
                {
                    List<Model.Book_Rdetail> listbrs = bllbrs.GetListModel("Book_no='" + item.book_no + "'");
                    sumint += listbrs.Count;
                }
            }
            context.Response.Write(list.Count - sumint);
        }
        BLL.Book_Rdetail bllbrs = new BLL.Book_Rdetail();
        BLL.SysParameter bllsys = new BLL.SysParameter();
        /// <summary>
        /// 获得离开时间
        /// </summary>
        private void GetYLTIME()
        {
            Model.SysParamter modelsys = new Model.SysParamter();
            modelsys = bllsys.GetModel(1);
            string txt = context.Request.QueryString["txt"];
            string days = context.Request.QueryString["days"];
            string rztime = context.Request.QueryString["rztime"];
            string str = "";
            if (txt == "天房" || txt=="免费房") {
                //TimeSpan dt1 = TimeSpan.Parse(modelsys.DayTime.ToString());//得到时间
                TimeSpan dt11 = TimeSpan.Parse(modelsys.DayOutTime.ToString());//得到时间
                //DateTime dt2 = DateTime.Now;//得到当前时间

                //DateTime dts = Convert.ToDateTime(Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd")).AddHours(dt1.Hours);//得到今日凌晨房开始时间
                str = Convert.ToDateTime(Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd")).AddDays(Convert.ToInt32(days)).AddHours(dt11.Hours).ToString();
            }
            else if (txt == "凌晨房") {
                TimeSpan dt11 = TimeSpan.Parse(modelsys.EarlyOutTime.ToString());
                str = Convert.ToDateTime(Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd")).AddDays(Convert.ToInt32(days)).AddHours(dt11.Hours).ToString();
            }
            else if (txt == "月租房") {
                str = Convert.ToDateTime(Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd")).AddMonths(1).ToString();
            }
            context.Response.Write(str);
        }
        //获得房型名称
        public string GetRealTypeName(int id)
        {

            BLL.room_type rtbll = new BLL.room_type();
            Model.room_type model = rtbll.GetModel(Convert.ToInt32(id.ToString()));
            return model.room_name;


        }
        BLL.hour_room bllhr = new BLL.hour_room();
        BLL.room_number fhBll = new BLL.room_number(); 
        /// <summary>
        /// 通过开房方式获得房价
        /// </summary>
        private void GetFx()
        {string Table="";
            string txt = context.Request.QueryString["txt"];
            string yk = context.Request.QueryString["yk"];
            if (txt == "天房" || txt == "免费房")
            {

                Table = "";
                DataSet dt = fhBll.GetList(" Rn_state=3  and Room_suod!='是' and Rn_roomNum not in(" + yk + ")");
                Table += "<table border='0' width='100%' cellspacing='0' cellpadding='0'>";
                foreach (DataRow dr in dt.Tables[0].Rows)
                {
                    Table += "<tr ids='" + dr["id"] + "' ondblclick='dbToAdd(this)'  onclick='BTncher(" + dr["id"] + ",1,this)'><td style='width:70px;'>" + dr["Rn_roomNum"].ToString() + "</td><td style='width:260px;'>" + GetRealTypeName(Convert.ToInt32(dr["Rn_room"].ToString())) + "</td><td style='width:70px;'>" + Convert.ToDecimal(dr["Rn_price"]).ToString("0.##") + "</td></tr>";
                }
                Table += "</table>";
            }
            else if(txt=="钟点房") {
                Table = "";
                DataSet dt = fhBll.GetList(" Rn_state=3  and Room_suod!='是' and Rn_roomNum not in(" + yk + ")");
                Table += "<table border='0' width='100%' cellspacing='0' cellpadding='0'>";
                foreach (DataRow dr in dt.Tables[0].Rows)
                {
                    int price = 0;
                    List<Model.hour_room> listhr = bllhr.GetModelList("hs_type_id=" + dr["Rn_room"].ToString());
                    if (listhr.Count > 0) {
                        price = (int)listhr[0].hs_start_price;
                        Table += "<tr ids='" + dr["id"] + "' ondblclick='dbToAdd(this)'  onclick='BTncher(" + dr["id"] + ",1,this)'><td style='width:70px;'>" + dr["Rn_roomNum"].ToString() + "</td><td style='width:260px;'>" + GetRealTypeName(Convert.ToInt32(dr["Rn_room"].ToString())) + "</td><td style='width:70px;'>" + Convert.ToDecimal(price).ToString("0.##") + "</td></tr>";
                    }
                }
                Table += "</table>";
            }
            else if (txt == "月租房")
            {
                Table = "";
                DataSet dt = fhBll.GetList(" Rn_state=3  and Room_suod!='是' and Rn_roomNum not in(" + yk + ")");
                Table += "<table border='0' width='100%' cellspacing='0' cellpadding='0'>";
                foreach (DataRow dr in dt.Tables[0].Rows)
                {
                    int price = 0;
                    Model.room_type listhr = bllrt.GetModel(Convert.ToInt32(dr["Rn_room"]));
                    if (listhr!=null)
                    {
                        price = (int)listhr.Room_Moth_price;
                        Table += "<tr ids='" + dr["id"] + "' ondblclick='dbToAdd(this)' onclick='BTncher(" + dr["id"] + ",1,this)'><td style='width:70px;'>" + dr["Rn_roomNum"].ToString() + "</td><td style='width:260px;'>" + GetRealTypeName(Convert.ToInt32(dr["Rn_room"].ToString())) + "</td><td style='width:70px;'>" + Convert.ToDecimal(price).ToString("0.##") + "</td></tr>";
                    }
                }
                Table += "</table>";
            }
            else if (txt == "凌晨房")
            {
                Table = "";
                DataSet dt = fhBll.GetList(" Rn_state=3  and Room_suod!='是' and Rn_roomNum not in(" + yk + ")");
                Table += "<table border='0' width='100%' cellspacing='0' cellpadding='0'>";
                foreach (DataRow dr in dt.Tables[0].Rows)
                {
                    int price = 0;
                    Model.room_type listhr = bllrt.GetModel(Convert.ToInt32(dr["Rn_room"]));
                    if (listhr != null)
                    {
                        price = (int)listhr.Room_Moth_price;
                        Table += "<tr ids='" + dr["id"] + "' ondblclick='dbToAdd(this)'  onclick='BTncher(" + dr["id"] + ",1,this)'><td style='width:70px;'>" + dr["Rn_roomNum"].ToString() + "</td><td style='width:260px;'>" + GetRealTypeName(Convert.ToInt32(dr["Rn_room"].ToString())) + "</td><td style='width:70px;'>" + GetLCFPirce(Convert.ToInt32(dr["Rn_room"])) + "</td></tr>";
                    }
                }
                Table += "</table>";
            }
            context.Response.Write(Table);
        }

        private string GetLCFPirce(int typeid) {
            Model.room_type modelrt = bllrt.GetModel(typeid);
            if (modelrt != null) {
                return Convert.ToDecimal(modelrt.Room_ealry_price).ToString("0.##");
            }
            return "";
        }
        private void GetNames()
        {
            int cid = Convert.ToInt32(context.Request.QueryString["id"]);
            context.Response.Write(bllg.GetModel(cid).Goods_name);
        }

        private void GetNames1()
        {
            int cid = Convert.ToInt32(context.Request.QueryString["id"]);
            context.Response.Write( bllct.GetModel(cid).ct_name);
        }

        private void GetGoods()
        {
            string cid = context.Request.QueryString["cid"];
            List<Model.Goods> list;
            if (cid == "0")
            {
                list = bllg.GetModelList("Goods_categories is not null");
            }
            else
            {
                list = bllg.GetModelList("Goods_categories=" + cid);
            }
            if (list.Count > 0)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                string str = js.Serialize(list);
                Common.AjaxMsgHelper.AjaxMsg1("ok", "成功", str, "");
            }
            else
            {
                Common.AjaxMsgHelper.AjaxMsg2("err", "无记录", "", "");
            }
        }

        BLL.Goods bllg = new BLL.Goods();
        BLL.cost_type bllct = new BLL.cost_type();
        private void GetCost()
        {
            string cid = context.Request.QueryString["cid"];
            List<Model.cost_type> list;
            if (cid == "0")
            {
                list = bllct.GetModelList("ct_categories is not null");
            }
            else
            {
               list = bllct.GetModelList("ct_categories=" + cid);
            }
            if (list.Count > 0)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                string str = js.Serialize(list);
                Common.AjaxMsgHelper.AjaxMsg1("ok", "成功", str,"");
            }
            else {
                Common.AjaxMsgHelper.AjaxMsg2("err", "无记录","","");
            }
        }

        private void GetRoom()
        {
            string bookno = string.Empty;
            int ids = 0;
            string roomNumber = context.Request.QueryString["roomNumber"];
            string xqids = string.Empty;
            List<Model.Book_Rdetail> listrb = bllrd.GetListModel("Room_number='" + roomNumber + "'");
            if (listrb.Count > 0)
            {
                bookno = listrb[0].Book_no;
                List<Model.Book_Rdetail> lists = bllrd.GetListModel("Book_no='" + bookno + "'");
                foreach (Model.Book_Rdetail modelbr in lists)
                {
                    if (xqids == "")
                    {
                        xqids += "'" + modelbr.Room_number + "'";
                    }
                    else
                    {
                        xqids += "," + "'" + modelbr.Room_number + "'";
                    }
                }
                List<Model.book_room> listbm = bllbr.GetModelList("book_no='" + bookno + "'");
                if (listbm.Count > 0)
                {
                    ids = listbm[0].book_id;
                }
                context.Response.Write("/Admin/Toroom/PeopleInfoAddsCs.aspx?type=yding&id=" + ids + "&rooms=" + roomNumber + "&ydbookno=" + bookno + "&xqid=" + xqids);
            }
            else {
                context.Response.Write("");
            }
        }
        /// <summary>
        /// 通过
        /// </summary>
        private void GetTypeName()
        {
            
        }
        BLL.UsersBLL blluser = new BLL.UsersBLL();
        private void Delids()
        {
            BLL.userType bllut = new BLL.userType();
            if (context.Request["typeid"] != null)
            {
                int id = Convert.ToInt32(context.Request["typeid"]);
                if (blluser.GetModelList("user_type=" + id).Count > 0) {
                    context.Response.Write("err");
                    context.Response.End();
                }
                if (bllut.DeleteList("typeid="+id)) {
                    context.Response.Write("删除成功");
                    context.Response.End();
                }
            }

        }
        BLL.hourse_scheme bllhs = new BLL.hourse_scheme();
        /// <summary>
        /// 改变价格方法
        /// </summary>
        private void UpdatePrice()
        {
            string typeid = context.Request.QueryString["typeid"];
            string fa = context.Request.QueryString["fa"];
            Model.room_type modelrt = bllrt.GetModel(Convert.ToInt32(typeid));
            Model.hourse_scheme modelhs = bllhs.GetModel(Convert.ToInt32(fa));
            double d=0;
            if (modelrt != null && modelhs != null)
            {
                d = Convert.ToDouble(modelrt.room_listedmoney) * Convert.ToDouble(modelhs.hs_Discount);
            }
            var obj=new{d=d,price=modelrt.room_listedmoney};
            
            string str=js.Serialize(obj);
            context.Response.Write(str);
        }
        JavaScriptSerializer js = new JavaScriptSerializer();
        private void Getdel() {
            string typeid = context.Request.Form["typeid"];
            List<Model.room_number> list = bllrn.GetModelList("Rn_room=" + typeid + " and Rn_state=3 and Rn_ToBe!=1");
            JavaScriptSerializer js = new JavaScriptSerializer();
            string str = js.Serialize(list);
            string finalStr = "{data:" + str + "}";
            context.Response.Write(finalStr);
        }
        private void Getprice()
        {
            string txt_number = context.Request.Form["typeid"];
             List<Model.Goods> list=null;
             if (context.Request.Form["isb"] != null)
            {
                list = fmgood.GetModelList("(Goods_number like '%" + txt_number + "%' or Goods_name like '%" + txt_number + "%' or Goods_spell like '%" + txt_number + "%') and Goods_ifType=1 and Goods_jf!=0");
            }
            else {
                list = fmgood.GetModelList("(Goods_number like '%" + txt_number + "%' or Goods_name like '%" + txt_number + "%' or Goods_spell like '%" + txt_number + "%') and Goods_ifType=1");
            }
            
            JavaScriptSerializer js = new JavaScriptSerializer();
            string str = js.Serialize(list);
            string finalStr = "{data:" + str + "}";
            context.Response.Write(finalStr);
        }
        private void GetName()
        {
            string txt_number = context.Request.Form["typeid"];
            List<Model.occu_infor> list = fmoc.GetModelListNamecard("(occ_name like '%" + txt_number + "%' or card_no like '%" + txt_number + "%') group by occ_name,card_no ");
            if (list.Count > 0)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                string str = js.Serialize(list);
                string finalStr = "{data:" + str + "}";
                context.Response.Write(finalStr);
            }
            else {
                context.Response.Write("err");
            }
        }
        private void getbind() 
        {
            string txtname = context.Request.Form["typeName"];
            string cardNo = context.Request.Form["carno"];
            List<Model.occu_infor> list = fmoc.GetModelList("occ_name='" + txtname + "' and card_no='" + cardNo + "' ");
            JavaScriptSerializer js = new JavaScriptSerializer();
            string str = js.Serialize(list);
            string finalStr = "{data:" + str + "}";
            context.Response.Write(finalStr);
        }
        /// <summary>
        /// 新增与修改
        /// </summary>
        private void AddBook()
        {
            try
            {
                bool isb = true;
                System.Text.StringBuilder sbText = new System.Text.StringBuilder();
                string book_no = string.Empty;
                string isUpdate = context.Request.Form["isUpdate"].ToString();
                if (isUpdate == "true")
                {
                    book_no = context.Request.Form["book_no"].ToString();
                    List<Model.Book_Rdetail> listbr = bllrd.GetListModel("Book_no='" + book_no + "'");
                    if (listbr.Count > 0) {
                        Model.room_number modelrt = new Model.room_number();
                        foreach (Model.Book_Rdetail item in listbr)
                        {
                            if (item.Room_number!=null) {
                                if (item.Room_number.Trim() != "")
                                {
                                    modelrt = bllrn.GetModelList("Rn_roomNum='" + item.Room_number + "'")[0];
                                    modelrt.Rn_Tobe = 0;
                                    Helper.AddRoom(item.Room_number);
                                    bllrn.Update(modelrt);
                                }
                            }
                        }
                    }
                    bool rels = bllrd.DeletebyWhere("Book_no='" + book_no + "'");
                    if (rels)
                    {
                        bllbr.DeletebyWhere("Book_no='" + book_no + "'");
                    }
                }
                else
                {
                    book_no = "Y" + System.DateTime.Now.ToString().Replace("-", "").Replace(":", "").Replace(" ", "");
                }
                string txtname = context.Request.Form["txtname"].ToString();
                string txtPhone = context.Request.Form["txtPhone"].ToString();
                string txtDh = context.Request.Form["txtDh"].ToString();
                string txtrz = context.Request.Form["txtrz"].ToString();
                string txttf = context.Request.Form["txttf"].ToString();
                string txtyd = context.Request.Form["txtyd"].ToString();
                string txtmCard = context.Request.Form["txtmCard"].ToString();
                string guarWayDll = context.Request.Form["guarWayDll"].ToString();
                string guestSourceDdl = context.Request.Form["guestSourceDdl"].ToString();
                string methPayDdl = context.Request.Form["methPayDdl"].ToString();
                string txtdj = context.Request.Form["txtdj"].ToString();
                string textRemaker = context.Request.Form["textRemaker"].ToString();
                string accounts = context.Request.Form["accounts"].ToString();
                string CpId = context.Request.Form["CpId"].ToString();
                string strs = context.Request.Form["sjs"].ToString();
                int? cid = null;
                if (CpId!= "") {
                    cid = Convert.ToInt32(CpId);
                }
                strs = strs.Remove(strs.Length - 1, 1);
                Model.book_room model = new Model.book_room()
                {
                    book_no = book_no,
                    book_Name = txtname,
                    tele_no = txtPhone,
                    onli_no = txtDh,
                    guar_way = guarWayDll,
                    mem_cardno = txtmCard,
                    time_to = Convert.ToDateTime(txtrz),
                    time_from = Convert.ToDateTime(txttf),
                    real_time = Convert.ToDateTime(txtyd),
                    source_id = Convert.ToInt32(guestSourceDdl),
                    meth_pay_id = Convert.ToInt32(methPayDdl),
                    deposit = Convert.ToDecimal(txtdj),
                    remark = textRemaker,
                    Userid=UserNow.UserID,
                    Accounts=accounts,
                    CpID = cid
                };
                if (Math.Floor(Convert.ToDouble(txtdj))==0)
                {
                    model.state_id = 6;
                }
                else {
                    model.state_id = 1;
                }
                int rel = bllbr.Add(model);
                if (rel > 0)
                {
                    string[] strlist = strs.Split(new char[1] { '*' }, StringSplitOptions.RemoveEmptyEntries);
                    Dictionary<string, string> dic = new Dictionary<string, string>();
                    foreach (string str in strlist)
                    {
                        dic.Clear();
                        string[] strdelt = str.Split(new char[1] { ',' });
                        foreach (string s in strdelt)
                        {
                            string[] strval = s.Split(new char[1] { ':' });
                            dic.Add(strval[0], strval[1]);
                        }
                        Model.Book_Rdetail modelbr = new Model.Book_Rdetail()
                        {
                            Book_no = model.book_no,
                            Real_type_Id = Convert.ToInt32(dic["typeid"]),
                            Room_number = dic["roomnumber"],
                            Real_num = Convert.ToInt32(dic["number"]),
                            Ok_num = 0,
                            Real_Price = Convert.ToDecimal(dic["price"]),
                            Real_Scheme_Id = Convert.ToInt32(dic["fangan"]),
                            RoomTypeID = Convert.ToInt32(model.state_id)
                        };
                        if (!IsBook(modelbr.Room_number))
                        {
                            isb = false;
                            List<Model.room_number> list = bllrn.GetModelList("Rn_roomNum='" + modelbr.Room_number + "'");
                            if (list.Count > 0)
                            {
                                Model.room_number modelrn = list[0];
                                modelrn.Rn_Tobe = 1;
                                bllrn.Update(modelrn);
                            }
                            if (modelbr.Room_number.Trim() != "")
                            {
                                Helper.AddRoom(modelbr.Room_number);
                            }
                            bllrd.Add(modelbr);
                        }
                        else {
                            sbText.Append(modelbr.Room_number + ",");
                        }
                    }
                }
                if (isUpdate == "true")
                {

                    context.Response.Write("更新成功!,' '");
                }
                else
                {
                    if (isb) {
                        bllbr.Delete(rel);
                        context.Response.Write("房间已被预定!," + book_no + "");
                    }
                    else { 
                    string finalStr = "{book_no:" + book_no + "}";
                    Model.goods_account modelga = new Model.goods_account()
                    {
                        ga_name = "预定收款",
                        ga_number = model.book_no,
                        ga_price = Convert.ToDecimal(model.deposit),
                        ga_zffs_id = Convert.ToInt32(methPayDdl),
                        ga_date = DateTime.Now,
                        ga_people = UserNow.UserID,
                        ga_Type = 8,
                        ga_occuid = "",
                        ga_remker = "",
                        ga_sum_price = Convert.ToDecimal("0.0000"),
                        ga_sfacount = "是",
                        ga_isjz = 0,
                        ga_roomNumber = "0",
                        ga_num = 0,
                        ga_unit = ""
                    };
                    bllga.Add(modelga);
                    if (sbText.ToString() != "")
                    {
                        context.Response.Write("新增成功" + sbText.ToString() + "已被预定!," + book_no + "");
                    }
                    else { 
                    context.Response.Write("新增成功!," + book_no + "");
                    }
                    }
                }
                context.Response.End();

            }
            catch (Exception ex)
            {
                context.Response.End();
            }
        }

        /// <summary>
        /// 根据房号来判断是否预定
        /// </summary>
        /// <returns></returns>
        private bool IsBook(string roomNumber) {
            List<Model.room_number> list = bllrn.GetModelList("Rn_roomNum='" + roomNumber + "'");
            if (list.Count > 0)
            {
                Model.room_number modelrn = list[0];
                if (modelrn.Rn_Tobe == 1) {
                    return true;
                }
            }
            return false;
        }

        BLL.goods_account bllga = new BLL.goods_account();
        private void UpdateRd() {
            try
            {
                string book_no = context.Request.Form["book_no"].ToString();
                bool rels = bllrd.DeletebyWhere("Book_no='" + book_no + "'");
                if (rels)
                {
                   // bllbr.DeletebyWhere("Book_no='" + book_no + "'");
                }
                string strs = context.Request.Form["sjs"].ToString();
                strs = strs.Remove(strs.Length - 1, 1);


                string[] strlist = strs.Split(new char[1] { '*' }, StringSplitOptions.RemoveEmptyEntries);
                Dictionary<string, string> dic = new Dictionary<string, string>();
                foreach (string str in strlist)
                {
                    dic.Clear();
                    string[] strdelt = str.Split(new char[1] { ',' });
                    foreach (string s in strdelt)
                    {
                        string[] strval = s.Split(new char[1] { ':' });
                        dic.Add(strval[0], strval[1]);
                    }
                    Model.Book_Rdetail modelbr = new Model.Book_Rdetail()
                    {
                        Book_no = book_no,
                        Real_type_Id = Convert.ToInt32(dic["typeid"]),
                        Room_number = dic["roomnumber"],
                        Real_num = Convert.ToInt32(dic["number"]),
                        Ok_num = 0,
                        Real_Price = Convert.ToDecimal(dic["price"]),
                        Real_Scheme_Id = Convert.ToInt32(dic["fangan"]),
                        RoomTypeID = 1
                    };
                    bllrd.Add(modelbr);
                }

                context.Response.Write("分房成功!");
            }
            catch (Exception)
            {
                
                throw;
            }
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}