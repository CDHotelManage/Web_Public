using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Script.Serialization;
using System.Threading;

namespace CdHotelManage.Web.Admin.Ajax
{
    /// <summary>
    /// SysPara 的摘要说明
    /// </summary>
    public class SysPara : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {   
        HttpContext context = null;
        BLL.ExceedScheme blles = new BLL.ExceedScheme();
        BLL.SysParameter blls = new BLL.SysParameter();
        BLL.occu_infor blloi = new BLL.occu_infor();
        BLL.room_type bllrt = new BLL.room_type();
        BLL.real_mode bllrm = new BLL.real_mode();
        BLL.TypeScheme bllts = new BLL.TypeScheme();
        BLL.room_number bllrn = new BLL.room_number();
        BLL.hour_room bllhr = new BLL.hour_room();
        Model.SysParamter modelsys = new Model.SysParamter();
        Model.ExceedScheme model1 = new Model.ExceedScheme();
        Model.ExceedScheme model2 = new Model.ExceedScheme();
        BLL.goods_account bllga = new BLL.goods_account();
        BLL.ZD_hourse bllzd = new BLL.ZD_hourse();
        BLL.AccountsUsersBLL bllu = new BLL.AccountsUsersBLL();


        Model.AccountsUsers userNow = null;
        public Model.AccountsUsers UserNow
        {
            get
            {
                if (context.Request.Cookies["User"]!= null)
                {
                    userNow = bllu.GetModel(context.Request.Cookies["User"].Value);
                }
                return userNow;
            }
        }


        public void ProcessRequest(HttpContext context)
        {
            this.context = context;
            string type = context.Request["type"];
            modelsys = blls.GetModel(1);
            model1 = blles.GetModelList("TypeRoom=1")[0];
            model2 = blles.GetModelList("TypeRoom=5")[0];
            switch (type)
            {
                case "GetYJ":
                    GetYJ();
                    break;
                case "chexiao":
                    Chexiao();
                    break;
                case "Jf":
                    Thread s = new Thread(new ThreadStart(Jf));
                    s.Start();
                    s.Join();
                    break;
                case "upd":
                    Upd();
                    break;
                case "add":
                    Add();
                    break;
                case "add1":
                    Add1();
                    break;
                case "getfa":
                    Getfa();
                    break;
                case "gettime":
                    gettime();
                    break;
                case "editprint":
                    Editprint();
                    break;
                case "infos":
                    Infos();
                    break;
                case "delinfo":
                    Delinfo();
                    break;
                //case "gettime1":
                //    GetShengyuTime();
                //    break;
                case "getyzf":
                    GetYuzuf();
                    break;
                case "getoccid":
                    Getoccid();
                    break;
                case "getroomid":
                    Getroomid();
                    break;
                case "getRoomModel":
                    Thread s1 = new Thread(new ThreadStart(GetRoomModel));
                    s1.Start();
                    s1.Join();
                    //GetRoomModel();
                    break;
                case "gettf":
                    Gettf();
                    break;
                case "getlcf":
                    Getlcf();
                    break;
                case "getyl":
                    Getyl();
                    break;
                case "uproom":
                    uproom();
                    break;
            }
        }

        /// <summary>
        /// 更新锁号
        /// </summary>
        private void uproom()
        {
            string txt = context.Request.QueryString["txt"];
            string room = context.Request.QueryString["room"];
            string typeroom = context.Request.QueryString["typeroom"];
            BLL.SuoRoom bllrn = new BLL.SuoRoom();
            List<Model.SuoRoom> listroom = bllrn.GetModelList("RoomNumber='" + room.Trim() + "' and SuoType='" + typeroom + "'");
            if (listroom.Count > 0)
            {
                Model.SuoRoom modelrn = listroom[0];
                modelrn.SuoMa = txt;
                bllrn.Update(modelrn);
            }
            else {
                Model.SuoRoom modelrn = new Model.SuoRoom();
                modelrn.RoomNumber = room;
                modelrn.SuoType = typeroom;
                modelrn.SuoMa = txt;
                bllrn.Add(modelrn);
            }
        }

        /// <summary>
        /// 获得离时
        /// </summary>
        private void Getyl()
        {
            string roomType = context.Request.QueryString["roomType"];
            string day = context.Request.QueryString["day"];
            string txt = context.Request.QueryString["txt"];
            DateTime rztime = Convert.ToDateTime(context.Request.QueryString["rztime"]);
            Model.SysParamter modelsys = blls.GetModel(1);
            DateTime yl = new DateTime();
            switch (txt)
            {
                case "天房":
                    yl = Convert.ToDateTime(rztime.ToString("yyyy-MM-dd")).AddDays(Convert.ToInt32(day)).AddHours(TimeSpan.Parse(modelsys.DayOutTime.ToString()).Hours);
                    break;
                case "免费房":
                    yl = Convert.ToDateTime(rztime.ToString("yyyy-MM-dd")).AddDays(Convert.ToInt32(day)).AddHours(TimeSpan.Parse(modelsys.DayOutTime.ToString()).Hours);
                    break;
                case "凌晨房":
                    yl = Convert.ToDateTime(rztime.ToString("yyyy-MM-dd")).AddDays(Convert.ToInt32(day)).AddHours(TimeSpan.Parse(modelsys.EarlyOutTime.ToString()).Hours);
                    break;
                case "月租房":
                    yl = Convert.ToDateTime(rztime.ToString("yyyy-MM-dd")).AddDays(Convert.ToInt32(day));
                    break;
                default:
                    break;
            }
            context.Response.Write(yl.ToString());
        }

        /// <summary>
        /// 获得凌晨房的价格
        /// </summary>
        private void Getlcf()
        {
            GetMennber();
            string typeid = context.Request.QueryString["typeid"];
            Model.room_type modelrt = bllrt.GetModel(Convert.ToInt32(typeid));
            if (modelrt != null)
            {
                context.Response.Write(modelrt.Room_ealry_price);
            }
        }

        /// <summary>
        /// 获得天房的房价
        /// </summary>
        private void Gettf()
        {
            GetMennber();
            string typeid = context.Request.QueryString["typeid"];
            Model.room_type modelrt = bllrt.GetModel(Convert.ToInt32(typeid));
            if (modelrt != null) {
                context.Response.Write(modelrt.room_listedmoney);
            }
        }

        private void GetMennber() {
            BLL.member bllmem = new BLL.member();
            BLL.mtPrice bllmt = new BLL.mtPrice();
            int id = Convert.ToInt32(context.Request.QueryString["typeid"]);
            if (context.Request.QueryString["memid"] != null && context.Request.QueryString["kffs"] != null)
            {
                if (context.Request.QueryString["memid"].ToString() != "" && context.Request.QueryString["kffs"].ToString() != "")
                {

                    int kffs= Convert.ToInt32(context.Request.QueryString["kffs"]);
                    string memid =context.Request.QueryString["memid"];
                    Model.member modelmem = bllmem.GetModel(memid);
                    if (modelmem != null)
                    {
                        int mtid = Convert.ToInt32(modelmem.Mtype);
                        List<Model.mtPrice> modelmt = bllmt.GetModelList("RoomType=" + id + " and MTID=" + mtid);
                        if (modelmt.Count > 0)
                        {
                            Model.mtPrice model = modelmt[0];
                            switch (kffs)
                            {
                                case 1:
                                    context.Response.Write(model.Dayprice);
                                    context.Response.End();
                                    break;
                                case 5:
                                    context.Response.Write(model.lcPrice);
                                    context.Response.End();
                                    break;

                            }
                        }
                    }
                }
            }
        }

        string Style = "";
        string ListYJ = "";
        public int suofang = 0;
        public int yzf = 0;
        public int jzhouf = 0;
        public int zdfang = 0;
        public int count = 0;
        public int lingcfang = 0;
        public int xuzhufang = 0;
        public int qianfei = 0;
        public int LFcount = 0;
        public int mfcount = 0;
        public string czico = string.Empty;
        public int czCount = 0;
        BLL.room_number brBll = new BLL.room_number();
        BLL.floor_manage fmlc = new BLL.floor_manage();
        BLL.room_type fxBll = new BLL.room_type();
        BLL.room_state fmft = new BLL.room_state();
        BLL.goods_account fmgood = new BLL.goods_account();
        BLL.occu_infor fmmx = new BLL.occu_infor();
        BLL.FtSet bllft = new BLL.FtSet();
        /// <summary>
        /// 设置右键菜单
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public string GetClass(int state)
        {
            string FtName = "";
            if (state != 0)
            {
                FtName = fmft.GetModel(state).room_state_name;

            }

            if (FtName == "在住房")
            {
                Style = "bgorange";
            }
            else if (FtName == "干净房" || state == 0)
            {
                Style = "bgblue";
            }
            else if (FtName == "将到房")
            {
                Style = "bggreen";
            }
            else if (FtName == "脏房")
            {
                Style = "bggray_q";
            }
            else if (FtName == "脏住房")
            {
                Style = "zhang_zf";
            }
            else if (FtName == "自用房")
            {
                Style = "pink_zyf";
            }
            else
            {
                Style = "bggray_s";
            }
            return Style;
        }
        Model.room_number modelNowRoom = new Model.room_number();
        string FtNames = string.Empty;
        Dictionary<string, string> dicCz = new Dictionary<string, string>();
        int real_mode_id;
        //直接获得一个实体
        private void GetRoomModel()
        {
            Dictionary<string, string> dicstr = new Dictionary<string, string>();
            System.Text.StringBuilder sbtext = null;
            List<Model.occu_infor> listocc = fmmx.GetModelList("occ_with='否' and state_id=0");
            dicstr = context.Session["dic"] as Dictionary<string, string>;
            dicCz = context.Session["iscz"] as Dictionary<string, string>;
            string roomNum = context.Request.QueryString["roomnumber"];
            string sjsj = "";
            string img = "";
            Model.FtSet modelfs = null;
            modelfs = bllft.GetModel(1);
            Model.occu_infor modeloccinfo = null;
            List<Model.room_number> listroom = brBll.GetModelList("Rn_roomNum='" + roomNum + "'");
            if (listroom.Count > 0) {
                modelNowRoom = listroom[0];
                sbtext = new System.Text.StringBuilder();
                string price = "";
                string Names = "";
                string xuzhu = "";
                string jzfimg = "";
                string LFimg = "";
                string numDay = "";
                string totime = "";
                if (modelNowRoom.Rn_state == null || modelNowRoom.Rn_state.ToString() == "")
                {
                    modelNowRoom.Rn_state = 0;
                }
                FtNames = fmft.GetModel(Convert.ToInt32(modelNowRoom.Rn_state)).room_state_name;
                GetClass(Convert.ToInt32(modelNowRoom.Rn_state));
                if (FtNames == "干净房")
                {

                    sjsj = "ondblclick=\"ShowTab('在住房信息'," + modelNowRoom.id + ",0)\"";
                }
                else
                {
                    sjsj = "";
                }
                if (FtNames == "在住房" || FtNames == "脏住房")
                {
                    try
                    {
                        string a = modelNowRoom.Rn_roomNum.ToString();
                        int lfcounts = 0;
                        modeloccinfo = fmmx.GetModels(" where occ_with='否' and state_id=0 and room_number='" + modelNowRoom.Rn_roomNum.ToString() + "'");
                        totime = modeloccinfo.occ_time.ToString("g");
                        Names = modeloccinfo.occ_name;
                        //int id = modeloccinfo.occ_id;
                        modelNowRoom.id= modeloccinfo.occ_id;
                        real_mode_id = modeloccinfo.real_mode_id;
                        switch (real_mode_id)
                        {
                            case 2:
                                price = "<img src='../../images/sicon04.png' class=\"zdf\"/>";
                                zdfang++;
                                break;
                            case 19:
                                price = "<img src='../../images/sicon01.png' class=\"yuezhu\"/>";
                                yzf++;
                                break;
                            case 5:
                                price = "<img src='../../images/sicon03.png' class=\"lccio\" />";
                                lingcfang++;
                                break;
                            case 20:
                                price = "<img src='/admin/images/iconfree.png' class=\"free\"/>";
                                mfcount++;
                                break;
                            default:
                                break;
                        }


                        if (dicCz.ContainsKey(a.ToString()))
                        {
                            if (dicCz[a.ToString()].ToString() == "1")
                            {
                                if (modelfs.showyjb)
                                {
                                    czico = "<img src='/admin/images/iconcuizhang.png'/>";
                                }
                                czCount++;
                                bs = true;
                            }
                        }

                        date1 = Convert.ToDateTime(fmmx.GetModels(" where occ_with='否' and state_id=0 and real_mode_Id!=2 and real_mode_Id!=19 and room_number='" + a.ToString() + "'").depar_time.ToString());
                        date2 = System.DateTime.Now;
                        cc = date1.Day - date2.Day;
                        if (cc < 0)
                        {
                            cc = (Convert.ToDateTime(date1.ToString("yyyy-MM-dd")) - Convert.ToDateTime(date2.ToString("yyyy-MM-dd"))).Days;
                        }
                        if (modelfs.yuliDay)
                        {//只是当日预离
                            if (cc == 0)
                            {
                                if (modelfs.showYuli)
                                {
                                    //jzfimg = "<img src=\"/admin/images/iconjiangzou.png\">";
                                }
                                jzhouf++;
                            }
                        }
                        else if (modelfs.showDayTime)
                        { //多少天内预离显示

                            if (Convert.ToInt32(cc) <= Convert.ToInt32(modelfs.dayNumYl))
                            {
                                if (Convert.ToInt32(cc) == 0 || cc < 0)
                                {
                                    numDay = "<span class=\"numday\"> </span>";
                                }
                                else
                                {
                                    numDay = "<span class=\"numday\">" + cc + "</span>";
                                }
                                if (modelfs.showYuli)
                                {
                                    //jzfimg = "<img src=\"/admin/images/iconjiangzou.png\">";
                                }
                                jzhouf++;
                            }
                        }


                        int count = fmmx.GetRecordCount(" where continuelive=" + modelNowRoom.id + "");
                        if (count > 0)
                        {

                            xuzhu = "<img src=\"/admin/images/iconxz.png\">";
                            xuzhufang++;
                        }

                        countLF = fmmx.GetRecordCount(" where order_id='" + modeloccinfo.order_id + "'");
                        if (listocc.Count > 1)
                        {
                            LFimg = dicstr[roomNum];
                            LFcount++;
                        }
                        //string SQLlf = "select order_id  from  occu_infor where order_id in (select  order_id  from  occu_infor  group  by  order_id  having  count(order_id) > 1) group by order_id";
                        //DataSet DtLF = fmgood.GoodsQX(SQLlf);
                        //foreach (DataRow drLF in DtLF.Tables[0].Rows)
                        //{

                        //    lfcounts++;
                        //}
                        //LFcount = lfcounts;


                    }
                    catch { }
                }
                b = modelNowRoom.Rn_roomNum.ToString();
                if (modelNowRoom.Room_suod.ToString().Trim() == "是")//是否为锁房间
                {
                    img = "<img src='/admin/images/iconsuofang.png' class=\"suofang\">";
                    sjsj = "";
                    suofang++;
                }
                else
                {
                    img = "";
                }

                string yustr = string.Empty;
                yudao = string.Empty;
                if (Convert.ToInt32(modelNowRoom.Rn_Tobe) == 1)
                {
                    yudao = GetYuDao(b);
                    yustr = "yuding";
                    yudao = GetYuDao(b);
                    yustr = "yuding";
                    DateTime datestr = Convert.ToDateTime(yudao);
                    DateTime dataend = Convert.ToDateTime(DateTime.Now);
                    int days = datestr.Day - dataend.Day;
                    if (days < 0)
                    {
                        TimeSpan tss = datestr - dataend;
                        days = tss.Days;
                    }
                    if (days < 0)
                    {
                        yudaoDay = "<div class=\"yuding hrj\"> </div>";
                        yudao = Convert.ToDateTime(yudao).ToString("hh:mm");
                    }
                    else
                    {
                        yudao = "";
                        yudaoDay = "<div class=\"yuding hrj\">" + days + "</div>";
                    }
                }
                sbtext.Append("<li rooms=" + modelNowRoom.Rn_roomNum.ToString() + " id=" + Convert.ToInt32(modelNowRoom.id.ToString()) + " state=" + Convert.ToInt32(modelNowRoom.Rn_state) + " " + sjsj + " class='" + yustr + " " + Style + "'><a href='#'><span class='span01'>" + modelNowRoom.Rn_roomNum.ToString() + "</span>" + numDay + "<span style='color:yellow'>" + ZC(modelNowRoom.Rn_roomNum.ToString()) + "</span><br /><span class=\"fxhrj\">" + GetFX(Convert.ToInt32(modelNowRoom.Rn_room.ToString())) + "</span>&nbsp;&nbsp; <p>" + img + "<span class=\"icospan\">" + price + "</span><span class=\"lfico\">" + LFimg + "</span><span class=\"qianfei\"></span> <span class=\"xuzhu\">" + xuzhu + "</span><span class=\"czimg\">" + czico + "</span><span class=\"jzfimg\">" + jzfimg + "</span><span class='totime'>" + totime + "</span></p><br /><span class='zuofu'>" + Names + "</span><span class='youfu'>" + Convert.ToDecimal(modelNowRoom.Rn_price.ToString()).ToString("0.##") + "</span><span class=\"yue1\"></span><span class=\"stime\"></span><span class=\"shengyu\"></span></a><span class=\"yudao\">" + yudao + "</span>" + yudaoDay + "</li>");
                bs = false;
            }
                context.Response.Write(sbtext.ToString());
        }

        private string ZC(string roomNum)
        {
            List<Model.occu_infor> listocc =  blloi.GetModelList("state_id=0 and lordRoomid='" + roomNum + "'");
            if (listocc.Count > 1)
            {
                return "主";
            }
            return "";
        }
        string yudaoDay = string.Empty;
        string yudao = string.Empty;
        bool bs = false;
        DateTime date1;
        DateTime date2;
        int cc;
        int countLF;
        string b = string.Empty;
        BLL.book_room bllr = new BLL.book_room();
        /// <summary>
        /// 获得预到时间
        /// </summary>
        /// <returns></returns>
        private string GetYuDao(string nummber)
        {
            List<Model.Book_Rdetail> listbr = bllbr.GetListModel("Room_number='" + nummber + "' and Room_typeid in(1,6)");
            string bookno = string.Empty;
            if (listbr.Count > 0)
            {
                bookno = listbr[0].Book_no;
                List<Model.book_room> listb = bllr.GetModelList("book_no='" + bookno + "'");
                if (listb.Count > 0)
                {
                    return listb[0].time_to.ToString();
                }
            }
            return "";
        }
        BLL.Book_Rdetail bllbr = new BLL.Book_Rdetail();
        private string GetYuding(string number)
        {
            List<Model.room_number> listrn = bllrn.GetModelList("Rn_roomNum='" + number + "'");
            if (listrn.Count > 0)
            {
                if (listrn[0].Rn_Tobe == 1)
                {
                    return "yuding";
                }
            }
            return "";
        }

        public string GetFX(int id)
        {
            BLL.room_type rtbll = new BLL.room_type();

            Model.room_type model = rtbll.GetModel(Convert.ToInt32(id.ToString()));

            return model.room_name;
        }

        private void Getroomid()
        {
            int ids = Convert.ToInt32(context.Request.QueryString["id"]);
            if (bllrn.GetModel(ids) != null) {
                context.Response.Write(ids);
            }
            else
            {
                Model.occu_infor modelocc = blloi.GetModel(ids);
                Model.room_number modelrn = bllrn.GetModelList("Rn_roomNum='" + modelocc.room_number + "'")[0];
                context.Response.Write(modelrn.id);
            }
        }

        private void Getoccid()
        {
            int ids = Convert.ToInt32(context.Request.QueryString["id"]);
            if (blloi.GetModel(ids) != null) {
                context.Response.Write(ids);
            }
            else
            {
                Model.room_number modelrn = bllrn.GetModel(ids);
                Model.occu_infor modelocc = blloi.GetModelList("room_number='" + modelrn.Rn_roomNum + "' and state_id=0")[0];
                context.Response.Write(modelocc.occ_id);
            }
        }

        private void GetYuzuf()
        {
            double price = 0;
            int ids = Convert.ToInt32(context.Request.QueryString["typeid"]);
            price = Convert.ToDouble(bllrt.GetModel(ids).Room_Moth_price.ToString());
            context.Response.Write(price);
        }

        private void Delinfo()
        {
            int id = Convert.ToInt32(context.Request.QueryString["id"]);
            bllin.Delete(id);
        }

        BLL.infos bllin = new BLL.infos();
        private void Infos()
        {
            Model.infos modelin = bllin.GetModel(1);
            if (modelin != null)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                string str = js.Serialize(modelin);
                Common.AjaxMsgHelper.AjaxMsg1("ok", "成功", str, "");
            }
            else {
                Common.AjaxMsgHelper.AjaxMsg1("err", "成功", "", "");
            }
        }

        private void Editprint()
        {
            string id = context.Request.Form["id"];
            string pritName = context.Request.Form["pritName"];
            string priContent = context.Request.Form["priContent"];
            BLL.print bllp = new BLL.print();
            Model.print modelp = new Model.print() {
               id= Convert.ToInt32(id),
               priContent=priContent,
               pritName=pritName
            };
            if (bllp.Update(modelp)) {
                context.Response.Write("ok");
            }
        }

        private void gettime()
        {
            string time = context.Request.QueryString["time"];
            DateTime dt1 = DateTime.Now.AddMinutes(Convert.ToInt32(time));
            context.Response.Write(dt1.ToString());
        }
        //BLL.room_type bllrt = new BLL.room_type();
       
        /// <summary>
        /// 通过房型获得方案
        /// </summary>
        private void Getfa()
        {
            BLL.member bllmem = new BLL.member();
            BLL.mtPrice bllmt = new BLL.mtPrice();
            int mtid = 0;
            int id = Convert.ToInt32(context.Request.QueryString["typeid"]);
            if (context.Request.QueryString["memid"] != null && context.Request.QueryString["kffs"] != null)
            {
                if (context.Request.QueryString["memid"].ToString() != "" && context.Request.QueryString["kffs"].ToString() != "")
                {

                    string memid =context.Request.QueryString["memid"];
                    Model.member modelmem = bllmem.GetModel(memid);
                    if (modelmem != null)
                    {
                        mtid = Convert.ToInt32(modelmem.Mtype);
                        //List<Model.mtPrice> modelmt = bllmt.GetModelList("RoomType=" + id + " and MTID=" + mtid);
                        //if (modelmt.Count > 0)
                        //{
                        //    // context
                        //}
                    }
                }
            }

            Model.ZD_hourse zdmodel = bllzd.GetModel(1);
            TimeSpan dt4 = TimeSpan.Parse(zdmodel.beigin.ToString());
            TimeSpan dt5 = TimeSpan.Parse(zdmodel.endtime.ToString());
            DateTime dts1 = Convert.ToDateTime(Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd")).AddHours(dt4.Hours);//得到最晚计费时间
            DateTime dts2 = Convert.ToDateTime(Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd")).AddHours(dt5.Hours);//得到最晚计费时间
            DateTime dt2 = DateTime.Now;//得到当前时间
            TimeSpan to1 = dt2 - dts1;
            TimeSpan to2 = dt2 - dts2;
            
            
            if (to1.TotalSeconds < 0)
            {
                Common.AjaxMsgHelper.AjaxMsg("err", "还没有到开钟点房时间", "", "");
                context.Response.End();
            }
            else if (to2.TotalSeconds > 0)
            {
                Common.AjaxMsgHelper.AjaxMsg("err", "今天开钟点房时间已过！", "", "");
                context.Response.End();
            }
            if (bllrt.GetModel(id).room_hour == "不允许") {
                Common.AjaxMsgHelper.AjaxMsg("err", "些房型不允许开钟点房！", "", "");
                context.Response.End();
            }
            List<Model.hour_room> listzd =null;
            if (mtid != 0)
            {
                listzd = bllhr.GetModelList("hs_type_id=" + id + " and MtID=" + mtid);
            }
            else {
                listzd = bllhr.GetModelList("hs_type_id=" + id + " and MtID=" + mtid);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            if (listzd.Count > 0)
            {
                string str = js.Serialize(listzd);
                Common.AjaxMsgHelper.AjaxMsg1("ok", "加载成功", str, "");
            }
            else {
                Common.AjaxMsgHelper.AjaxMsg("err", "止房型没有钟点房方案！", "", "");
                context.Response.End();
            }
        }
        BLL.goods_account gmGood = new BLL.goods_account();
        BLL.occu_infor fmoc = new BLL.occu_infor();
        void Yue(string room1,int real_model, TimeSpan zdffz,TimeSpan tf,TimeSpan lincheng,string shengyumiao,string state)
        {
            double xiaofei = 0;//消费
            double shoukuan = 0;//收款
            double yue = 0;//余额
            //string room1 = context.Request.QueryString["roomNum"].ToString();
            int id = fmoc.GetModels(" where room_number='" + room1 + "' and state_id=0 and occ_with='否'").occ_id;
            string orderid = fmoc.GetModels(" where room_number='" + room1 + "' and state_id=0 and occ_with='否'").order_id;
            IList<Model.goods_account> list = gmGood.GetModelList1(" ga_occuid='" + orderid + "'");
            for (int i = 0; i < list.Count; i++)
            {
                xiaofei += Convert.ToDouble((list[i].ga_price));
                shoukuan += Convert.ToDouble((list[i].ga_sum_price));
            }
            yue = (shoukuan - xiaofei) * -1;
            string yues=string.Empty;
            if (yue > 0)
            {
                yues = "<span class=\"dayu\">" + yue + "</span>";
            }
            else{
                yues = "<span class=\"dayu\">" + yue + "</span>";
            }
            if (real_model == 2)
            {
                string time = zdffz.Hours + "小时，" + zdffz.Minutes + "分钟";
                context.Response.Write(time + "," + yues + ",zd," + shengyumiao + "," + state);
                context.Response.End();
            }
            else if (real_model == 5 || real_model==7) {
                context.Response.Write(yues + "," + shengyumiao + ",tf," + state);
                context.Response.End();
            }
            else if (real_model == 19) {

                context.Response.Write(yues + "," + state);
            }
            else
            {
                string miao = zdffz.TotalSeconds.ToString();
                context.Response.Write(yues + "," + shengyumiao + ",tf," + state);
                context.Response.End();
            }
        }

        #region Add1
        private void Add1()
        {
            string RoomType = context.Request.QueryString["TypeRoom"];
            Model.real_mode modelrm = new Model.real_mode()
            {
                real_mode_name = RoomType,
                remark = ""
            };
            int a = bllrm.Add(modelrm);
            if (a > 0)
            {
                Common.AjaxMsgHelper.AjaxMsg("ok", "新增成功!", a.ToString());
            }
        } 
        #endregion

        #region Add
        private void Add()
        {
            string RoomType = context.Request.QueryString["TypeRoom"];
            string Earlyapart = context.Request.QueryString["Earlyapart"];
            string EarlyapartAddP = context.Request.QueryString["EarlyapartAddP"];
            string EarlyInExceed = context.Request.QueryString["EarlyInExceed"];
            string EarlyInAddPri = context.Request.QueryString["EarlyInAddPri"];
            Model.ExceedScheme models = new Model.ExceedScheme();
            models.TypeRoom = Convert.ToInt32(RoomType);
            models.Earlyapart = Convert.ToInt32(Earlyapart);
            models.EarlyapartAddP = Convert.ToInt32(EarlyapartAddP);
            models.EarlyInExceed = Convert.ToInt32(EarlyInExceed);
            models.EarlyInAddPri = Convert.ToInt32(EarlyInAddPri);
            if (blles.Add(models))
            {
                Common.AjaxMsgHelper.AjaxMsg("ok", "新增成功!");
            }
        }
        
        #endregion

        #region Upd

        private void Upd()
        {
            try
            {
                string typeroom = context.Request.QueryString["typeroom"];
                string Earlyapart = context.Request.QueryString["Earlyapart"];
                string EarlyapartAddP = context.Request.QueryString["EarlyapartAddP"];
                string EarlyInExceed = context.Request.QueryString["EarlyInExceed"];
                string EarlyInAddPri = context.Request.QueryString["EarlyInAddPri"];
                Model.TypeScheme models = bllts.GetModel(Convert.ToInt32(typeroom));
                models.Earlyapart = Convert.ToInt32(Earlyapart);
                models.EarlyapartAddP = Convert.ToInt32(EarlyapartAddP);
                models.EarlyInExceed = Convert.ToInt32(EarlyInExceed);
                models.EarlyInAddPri = Convert.ToInt32(EarlyInAddPri);
                bllts.Update(models);
                context.Response.Write("ok");
                context.Response.End();
            }
            catch (Exception ex)
            {
                context.Response.Write("err");
                context.Response.End();
            }
        } 
        #endregion

        #region MyRegion
        ///// <summary>
        ///// 根据房号获得下一次超时所需要的时间
        ///// </summary>
        //void GetShengyuTime()
        //{
        //    string roomNub = context.Request.QueryString["roomNum"].ToString();//房号
        //    List<Model.occu_infor> listOci = blloi.GetModelList("room_number='" + roomNub + "' and state_id=0 and occ_with='否'");
        //    if (listOci.Count > 0)
        //    {
        //        Model.occu_infor modelocc = listOci[0];
        //        if (modelocc.real_mode_id == 2)
        //        { //如果是钟点房间

        //        }
        //        else if (modelocc.real_mode_id != 5)//如果是天房
        //        {
        //            int daymeng = Convert.ToInt32(model1.GraceTime);
        //            int ealmeng = Convert.ToInt32(model2.GraceTime);
        //            TimeSpan dt1 = TimeSpan.Parse(modelsys.DayOutTime.ToString());//得到系统设置的天房退房时间
        //            DateTime dt2 = DateTime.Now;//得到当前时间
        //            DateTime dt3 = Convert.ToDateTime(Convert.ToDateTime(modelocc.depar_time).ToString("yyyy-MM-dd")).AddHours(dt1.Hours).AddMinutes(daymeng);//得到退房日期

        //            TimeSpan ts = dt2 - dt3;//已经超时多少 
        //            /**/
        //            TimeSpan dt4 = TimeSpan.Parse(modelsys.DayFeeTwo.ToString());//得到系统设置的天房退房时间
        //            DateTime maxdt = Convert.ToDateTime(Convert.ToDateTime(modelocc.depar_time).ToString("yyyy-MM-dd")).AddHours(dt4.Hours);//得到系统设置最大期限
        //            DateTime dts = Convert.ToDateTime(Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd")).AddHours(dt1.Hours);//得到今日开始计费时间
        //            DateTime dts1 = Convert.ToDateTime(Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd")).AddHours(dt4.Hours);//得到最晚计费时间
        //            TimeSpan ts1 = dt2 - maxdt;//已经超时最大期限多少
        //            if (ts1.TotalSeconds > 0) //如果已经超过最大时间
        //            {
        //                if (modelsys.DayFee == 1)//如果按时间收费
        //                {
        //                    TimeSpan to1 = dt2 - dts;
        //                    TimeSpan to2 = dt2 - dts1;
        //                }
        //                else if (modelsys.DayFee == 0)//如果加收半天房租
        //                {

        //                }
        //            }
        //            else { 

        //            }
        //        }
        //        else if (modelocc.real_mode_id == 5)//如果是凌晨房
        //        {

        //        }
        //    }
        //} 
        #endregion

        private void AddGoods() { 
         
        }




        /// <summary>
        /// 时时计费.计算每个已开房间的房费
        /// </summary>
        private void Jf()
        {
            TimeSpan zdfts = new TimeSpan();
            TimeSpan tf = new TimeSpan();
            TimeSpan lincheng = new TimeSpan();
            string shengyumiao = string.Empty;
            string room1 = context.Request.QueryString["roomNum"].ToString();
            //找出所有正在入住的房间
            List<Model.occu_infor> listOci = blloi.GetModelList("room_number='" + room1 + "' and state_id=0 and occ_with='否'");
            TimeSpan yetime = TimeSpan.Parse(modelsys.YsTime.ToString());//得到系统设置的夜审时间
            DateTime yeDateTime = Convert.ToDateTime(Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd")).AddHours(yetime.Hours);//得到最晚计费时间
            if (listOci.Count > 0)
            {
                //遍历所有正在入住的房间
                foreach (Model.occu_infor item in listOci)
                {
                    string jiafangsh = string.Empty;
                    bllga.DeleteList("ga_Type in(10) and ga_roomNumber='" + item.room_number + "' and ga_occuid='" + item.order_id + "'");
                    int daymeng = Convert.ToInt32(model1.GraceTime);
                    int ealmeng = Convert.ToInt32(model2.GraceTime);
                    double price = 0.0;
                    //double pirce1 = Convert.ToDouble(bllrt.GetModel(item.real_type_id).room_listedmoney);//原来价格
                    double pirce1 = Convert.ToDouble(bllrn.GetModelList("Rn_roomNum='" + item.room_number + "'")[0].Rn_price);
                    if (item.real_mode_id == 2)
                    {   //如果是钟点房间
                        Model.hour_room modelhr = bllhr.GetModel(Convert.ToInt32(item.sort));//得到钟点房的方案
                        price = 0.0;
                        DateTime dt1 = Convert.ToDateTime(item.depar_time);//得到钟点房退房时间
                        DateTime startTime = item.occ_time;
                        DateTime dtmax = Convert.ToDateTime(item.occ_time.AddMinutes(Convert.ToDouble(modelhr.hs_max_time)));
                        DateTime dt2 = DateTime.Now;//得到当前时间
                        TimeSpan ts = dt2 - dt1;//已经超时多少 如果大于0就超时
                        TimeSpan tsok = dtmax - dt2;
                        /**/
                        DateTime dta1 = startTime.AddMinutes(Convert.ToInt32(modelhr.hs_min_time));
                        TimeSpan to1 = dt2 - dta1;
                        /**/
                        DateTime dta2 = startTime.AddMinutes(Convert.ToInt32(modelhr.hs_max_time));
                        TimeSpan to2 = dt2 - dta2;
                        /**/
                        if (ts.TotalSeconds > 0)//如果超时
                        {
                            bllga.DeleteList("ga_Type in(11) and ga_roomNumber='" + item.room_number + "' and ga_occuid='" + item.order_id + "'");
                            if (to1.TotalSeconds>0)
                            { //如果超过的时候已经过了 最小时长
                                if (to1.TotalSeconds > 0 && to2.TotalSeconds < 0)
                                { //如果大于最小时长 并小于最大时长
                                    jiafangsh = "钟点房超时收费";
                                    price = Convert.ToDouble(modelhr.hs_add_price);
                                    shengyumiao = (to2.TotalSeconds*-1).ToString();
                                    AddPric(item,Convert.ToDecimal(price), jiafangsh);
                                }
                                if (to1.TotalSeconds > 0 && to2.TotalSeconds > 0)
                                {  //如果大于最小时长也大于最大时长
                                    item.real_mode_id = 1;
                                    item.real_price = Convert.ToDecimal(pirce1);
                                    TimeSpan dts = TimeSpan.Parse(modelsys.DayOutTime.ToString());//得到系统设置的天房退房时间
                                    DateTime dtd = Convert.ToDateTime(Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd")).AddHours(dts.Hours);//得到退房日期
                                    //item.depar_time = dtd;
                                    blloi.Update(item);
                                    Model.goods_account gamodel= bllga.GetModelList1("ga_roomNumber='" + item.room_number + "' and ga_occuid='" + item.order_id + "' and ga_Type=8")[0];
                                    gamodel.ga_sum_price = Convert.ToDecimal(pirce1);
                                    bllga.Update(gamodel);
                                    Helper.AddRoom(item.room_number);
                                    context.Response.End();
                                }
                            }
                            else
                            {//没有过 不算钱 
                                zdfts = ts;
                                shengyumiao = (zdfts.Hours * 60 * 60 + zdfts.Minutes * 60 + zdfts.Seconds).ToString();
                            }
                        }
                        else
                        {
                            zdfts = dt1 - dt2;
                            shengyumiao = (zdfts.Hours * 60 * 60 + zdfts.Minutes * 60 + zdfts.Seconds).ToString();
                        }
                    }
                    //如果是月租房
                    else if (item.real_mode_id == 19)
                    {
                        int days = item.Occ_StyDate;
                        DateTime dt1 = Convert.ToDateTime(Convert.ToDateTime(item.depar_time).ToString("yyyy-MM-dd"));//得到到期时间
                        DateTime dt2 = DateTime.Now;//得到当前时间
                        TimeSpan ts = dt2 - dt1;
                        if (ts.TotalSeconds > 0)
                        {
                            if (DateTime.Now.Day >= days)
                            {
                                //bllga.DeleteList("ga_Type=9 and ga_roomNumber='" + item.room_number + "' and ga_occuid=" + item.order_id);
                                item.depar_time = Convert.ToDateTime(item.depar_time).AddMonths(1);
                                blloi.Update(item);
                                Model.goods_account modega = new Model.goods_account() ;
                                modega.ga_name = "房租";
                                modega.ga_roomNumber = item.room_number;
                                modega.ga_number = "CSFZ" + DateTime.Now.ToString();
                                modega.ga_price = Convert.ToDecimal(0.0);
                                modega.ga_date = DateTime.Now;
                                modega.ga_people = UserNow.UserID;
                                modega.ga_Type = 101;
                                modega.ga_sum_price = Convert.ToDecimal(item.real_price);
                                modega.ga_remker = "加收整月房费";
                                modega.ga_occuid = item.order_id;
                                modega.ga_sfacount = "否";
                                modega.Ga_goodNo = item.occ_no;
                                modega.ga_isjz = 0;
                                int rel = bllga.Add(modega);
                            }
                        }
                    }
                    else if (item.real_mode_id != 5 && item.real_mode_id != 20)//如果是天房
                    {

                        TimeSpan dt1 = TimeSpan.Parse(modelsys.DayOutTime.ToString());//得到系统设置的天房退房时间
                        DateTime dt3 = DateTime.Now;
                        DateTime dt2 = DateTime.Now;//得到当前时间 5 31
                        if (item.mem_cardno != "")
                        { //如果是会员
                            BLL.member bllmem = new BLL.member();
                            BLL.memberType bllmt = new BLL.memberType();
                            Model.member model = bllmem.GetModel(item.mem_cardno);
                            if (model != null)
                            {
                                Model.memberType modelmt = bllmt.GetModel(Convert.ToInt32(model.Mtype));
                                if (modelmt.Isout)
                                {
                                    dt3 = Convert.ToDateTime(Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd")).AddHours(dt1.Hours).AddHours(Convert.ToDouble(modelmt.OutHour));
                                }
                                else
                                {
                                    dt3 = Convert.ToDateTime(Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd")).AddHours(dt1.Hours).AddMinutes(ealmeng);//得到退房日期
                                }
                            }
                            else
                            {
                                dt3 = Convert.ToDateTime(Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd")).AddHours(dt1.Hours).AddMinutes(ealmeng);//得到退房日期
                            }
                        }
                        else
                        {
                            dt3 = Convert.ToDateTime(Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd")).AddHours(dt1.Hours).AddMinutes(ealmeng);//得到退房日期
                        }
                        //6 1
                        tf = dt3 - dt2;
                        TimeSpan ts = dt2 - dt3;//已经超时多少 
                        /**/
                        TimeSpan dt4 = TimeSpan.Parse(modelsys.DayFeeTwo.ToString());//得到系统设置的天房退房时间
                        DateTime maxdt = Convert.ToDateTime(Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd")).AddHours(dt4.Hours);//得到系统设置最大期限
                        DateTime dts = Convert.ToDateTime(Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd")).AddHours(dt1.Hours);//得到今日开始计费时间
                        DateTime dts1 = Convert.ToDateTime(Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd")).AddHours(dt4.Hours);//得到最晚计费时间
                        TimeSpan ts1 = dt2 - maxdt;//已经超时最大期限多少

                        bllga.DeleteList("ga_Type=10 and ga_roomNumber='" + item.room_number + "' and ga_occuid='" + item.order_id + "' and ga_isys=0 "); //执行删除
                        /**/
                        int days1=0;
                        //if (dt2.Year >= dt3.Year && dt2.Month >= dt3.Month)
                        //{
                        //    days1 = dt2.Day - dt3.Day; //计算天数（重要）
                        //}
                        //else {
                        //    days1 = ts.Days;
                        //}
                        //查看这几天的房费有没有入帐
                        

                        /*******************************************************************************分水线*/
                        DateTime occKf = Convert.ToDateTime(Convert.ToDateTime(item.occ_time).ToString("yyyy-MM-dd")).AddHours(dt4.Hours);//得到退房日期
                          int ykjs = DateTime.Now.Day - item.occ_time.Day;
                          if (ykjs < 0) {
                              TimeSpan tss = dt2 - item.occ_time;//已经超时多少
                              ykjs = tss.Days;
                          }

                          int cunt = IsAddPrice(item, days1);//已经夜审了几天
                          int xiangcha = ykjs - cunt - 1;//剩下几天没有夜审
                          if (xiangcha > 0)
                          {
                              for (int i = 0; i < xiangcha; i++)
                              {
                                  Model.goods_account modega = new Model.goods_account();
                                  modega.ga_name = "房费";
                                  modega.ga_roomNumber = item.room_number;
                                  modega.ga_number = "CSFZ" + DateTime.Now.ToString();
                                  modega.ga_price = Convert.ToDecimal(0.0);
                                  modega.ga_date = occKf.AddDays(cunt+1+i);
                                  modega.ga_people = UserNow.UserID;
                                  modega.ga_Type = 9;
                                  modega.ga_sum_price = Convert.ToDecimal(item.real_price);
                                  modega.ga_remker = "已夜审";
                                  modega.ga_occuid = item.order_id;
                                  modega.ga_sfacount = "否";
                                  modega.ga_isjz = 0;
                                  modega.Ga_goodNo = item.occ_no;
                                  modega.ga_isys = 1;
                                  bllga.Add(modega);

                                  //price += Convert.ToDouble(item.real_price);
                              }
                              DateTime dtli = Convert.ToDateTime(item.depar_time);
                              DateTime dtnow = DateTime.Now;
                              int days = dtnow.Day - dtli.Day;
                              item.depar_time = dtli.AddDays(days);
                              blloi.Update(item);
                          }


                          if (ykjs > 0)
                          {
                              if (modelsys.DayFee == 1)//如果按时间收费
                              {
                                  if (ts.TotalSeconds > 0)//如果已经超时
                                  {
                                      TimeSpan to1 = dt2 - dts;
                                      TimeSpan to2 = dt2 - dts1;

                                      if (to1.TotalMinutes > 0 && to2.TotalMinutes < 0)
                                      {
                                          if (modelsys.Istype)
                                          {
                                              //如果按房间类型计费
                                              Model.TypeScheme modelts = bllts.GetModel(item.real_type_id);
                                              model1.Earlyapart = modelts.Earlyapart;
                                              model1.EarlyapartAddP = modelts.EarlyapartAddP;
                                              model1.EarlyInExceed = modelts.EarlyInExceed;
                                              model1.EarlyInAddPri = modelts.EarlyInAddPri;
                                          }
                                          int Dayapart = Convert.ToInt32(model1.Earlyapart);
                                          double DayapartAddP = Convert.ToDouble(model1.EarlyapartAddP);
                                          int DayInExceed = Convert.ToInt32(model1.EarlyInExceed);
                                          double DayInAddPri = Convert.ToDouble(model1.EarlyInAddPri);
                                          //int minutes = Convert.ToInt32(ts.TotalSeconds);//得到超过秒
                                          //int day = minutes / (3600 * 24);
                                          //int hour = minutes % (3600 * 24) / 3600;
                                          //int min = minutes % 3600 / 60;
                                          int minutes = to1.Hours * 60 + to1.Minutes;
                                          int num = minutes / Dayapart;
                                          if (num > 0)
                                          {
                                              for (int i = 0; i < num; i++)
                                              {
                                                  price += DayapartAddP;
                                              }
                                          }
                                          int shengyu = minutes % Dayapart;
                                          if (shengyu >= DayInExceed)
                                          {
                                              price += DayInAddPri;
                                              shengyumiao = (((Dayapart - shengyu) * 60) - to1.Seconds).ToString();


                                          }
                                          else
                                          {
                                              shengyumiao = (((DayInExceed - shengyu) * 60) - to1.Seconds).ToString();
                                          }
                                          if (price > 0)
                                          {
                                              jiafangsh = "超时" + to1.Hours + "小时" + to1.Minutes + "分钟房费";
                                              AddPric(item, Convert.ToDecimal(price), jiafangsh);
                                          }

                                      }
                                      else if (to1.TotalMinutes > 0 && to2.TotalMinutes > 0)
                                      {
                                          Model.goods_account modega = new Model.goods_account();
                                          modega.ga_name = "房费";
                                          modega.ga_roomNumber = item.room_number;
                                          modega.ga_number = "CSFZ" + DateTime.Now.ToString();
                                          modega.ga_price = Convert.ToDecimal(0.0);
                                          modega.ga_date = DateTime.Now;
                                          modega.ga_people = UserNow.UserID;
                                          modega.ga_Type = 10;
                                          modega.ga_sum_price = Convert.ToDecimal(item.real_price);
                                          modega.ga_remker = "加收整天房费";
                                          modega.ga_occuid = item.order_id;
                                          modega.ga_sfacount = "否";
                                          modega.ga_isjz = 0;
                                          modega.Ga_goodNo = item.occ_no;
                                          modega.ga_isys = 0;
                                          bllga.Add(modega);
                                          TimeSpan t1 = dts.AddDays(1) - dt2;
                                          shengyumiao = (t1.Hours * 60 * 60 + t1.Minutes * 60 + t1.Seconds).ToString();
                                      }
                                      else if (to1.TotalMinutes < 0 && to2.TotalMinutes < 0)
                                      {
                                          shengyumiao = (to1.TotalSeconds * -1).ToString();
                                      }
                                  }
                                  else
                                  { //如果没有超时
                                      shengyumiao = (tf.TotalSeconds).ToString();
                                  }
                              }
                              else if (modelsys.DayFee == 0)
                              {
                                  int min = ts.Hours * 60 + ts.Minutes;//把天除去。计算总的超过分钟数
                                  int maxmin = (int)ts1.TotalMinutes - (ts.Days * 24 * 60);
                                  if (min > 0 && maxmin < 0)
                                  { //达到了加半天 没有到一天
                                      price += Convert.ToDouble(item.real_price) / Convert.ToDouble(2);
                                      jiafangsh = "加收半天房费";
                                      TimeSpan to2 = dts1 - dt2;
                                      shengyumiao = (to2.Hours * 60 * 60 + to2.Minutes * 60 + to2.Seconds).ToString();
                                      AddPric(item, Convert.ToDecimal(price), jiafangsh);
                                  }
                                  else if (maxmin > 0)
                                  {
                                      Model.goods_account modega = new Model.goods_account();
                                      modega.ga_name = "房费";
                                      modega.ga_roomNumber = item.room_number;
                                      modega.ga_number = "CSFZ" + DateTime.Now.ToString();
                                      modega.ga_price = Convert.ToDecimal(0.0);
                                      modega.ga_date = DateTime.Now;
                                      modega.ga_people = UserNow.UserID;
                                      modega.ga_Type = 10;
                                      modega.ga_sum_price = Convert.ToDecimal(pirce1);
                                      modega.ga_remker = "加收整天房费";
                                      modega.ga_occuid = item.order_id;
                                      modega.ga_sfacount = "否";
                                      modega.ga_isjz = 0;
                                      modega.Ga_goodNo = item.occ_no;
                                      modega.ga_isys = 0;
                                      bllga.Add(modega);
                                      TimeSpan t1 = dts.AddDays(1) - dt2;
                                      shengyumiao = (t1.Hours * 60 * 60 + t1.Minutes * 60 + t1.Seconds).ToString();
                                  }
                              }
                          }
                          else
                          {
                              tf = dt3.AddDays(1) - dt2;
                              shengyumiao = (tf.TotalSeconds).ToString();
                          }
                        }
                    

                    else if (item.real_mode_id == 5)//如果是凌晨房
                    {
                        price = 0.0;
                        TimeSpan dt1 = TimeSpan.Parse(modelsys.EarlyOutTime.ToString());//得到系统设置的凌晨房退房时间
                        TimeSpan dt11 = TimeSpan.Parse(modelsys.EarlyOutTimes.ToString());//得到系统设置的凌晨房退房最多时间
                        DateTime dt2 = DateTime.Now;//得到当前时间
                        DateTime dt3 = Convert.ToDateTime(Convert.ToDateTime(item.occ_time.AddDays(1)).ToString("yyyy-MM-dd")).AddHours(dt1.Hours);//得到退房日期
                        TimeSpan ts = dt2 - dt3;//已经超时多少


                        DateTime dts = Convert.ToDateTime(Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd")).AddHours(dt1.Hours).AddMinutes(daymeng);//得到今日开始计费时间
                        if (modelsys.EarlyFeeSel == 1)
                        { //设置次日
                            dts = Convert.ToDateTime(Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd")).AddDays(1).AddHours(dt1.Hours).AddMinutes(daymeng);//得到今日开始计费时间
                        }
                        else if (modelsys.EarlyFeeSel == 2)
                        { //设置当日

                        }
                        DateTime dts1 = Convert.ToDateTime(Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd")).AddHours(dt11.Hours);//得到最晚计费时间

                        TimeSpan to1 = dt2 - dts;
                        TimeSpan to2 = dt2 - dts1;
                        bllga.DeleteList("ga_Type=10 and ga_roomNumber='" + item.room_number + "' and ga_occuid='" + item.order_id + "' and ga_isys=0 "); //执行删除
                        int day = ts.Days;
                        int days1 = 0;
                        if (dt2.Year >= dt3.Year && dt2.Month >= dt3.Month)
                        {
                            days1 = dt2.Day - dt3.Day; //计算天数（重要）
                        }
                        else
                        {
                            days1 = ts.Days;
                        }
                        //int cunt = IsAddPrice(item, days1);//已经夜审了几天
                        //int xiangcha = days1 - cunt;//剩下几天没有夜审
                        if (days1 > 0)
                        {
                            if (modelsys.EarlyFeeTwo == 0)
                            {
                                Model.goods_account modega = new Model.goods_account();
                                modega.ga_name = "房费";
                                modega.ga_roomNumber = item.room_number;
                                modega.ga_number = "CSFZ" + DateTime.Now.ToString();
                                modega.ga_price = Convert.ToDecimal(0.0);
                                modega.ga_date = dts1.AddDays(1);
                                modega.ga_people = UserNow.UserID;
                                modega.ga_Type = 9;
                                modega.ga_sum_price = Convert.ToDecimal(pirce1);
                                modega.ga_remker = "已夜审";
                                modega.ga_occuid = item.order_id;
                                modega.ga_sfacount = "否";
                                modega.ga_isjz = 0;
                                modega.Ga_goodNo = item.occ_no;
                                modega.ga_isys = 1;
                                bllga.Add(modega);
                            }
                            else {
                                item.real_price = Convert.ToDecimal(pirce1);
                                Model.goods_account model = bllga.GetModelList1("ga_roomNumber='" + item.room_number + "' and ga_Type=8 and ga_occuid='" + item.order_id + "' and ga_isys=0")[0];
                                model.ga_sum_price = Convert.ToDecimal(pirce1);
                                model.ga_remker = "已夜审";
                                model.ga_Type=9;
                                model.ga_isys = 1;
                                bllga.Update(model);
                            }
                            item.real_mode_id = 1;
                            item.depar_time = dts.AddDays(days1).AddMinutes(ealmeng * -1);
                            blloi.Update(item);
                            Helper.AddRoom(item.room_number);
                            context.Response.End();
                        }
                        if (ts.TotalSeconds > 0)//如果已经超时
                        {
                            int fee = Convert.ToInt32(modelsys.EarlyFee);
                            if (fee == 1)
                            { //加收半天房费
                                if (to1.TotalSeconds > 0 && to2.TotalSeconds < 0)
                                { //时间在最小与最大之前
                                    price += Convert.ToDouble(item.real_price) / Convert.ToDouble(2);
                                    jiafangsh = "加收半天房费";
                                    shengyumiao = (to2.TotalSeconds * -1).ToString();
                                }
                                else if (to1.TotalSeconds > 0 && to2.TotalSeconds > 0)
                                { //时间已经超过最大时间
                                    if (modelsys.EarlyFeeTwo == 0)
                                    {
                                        //price += Convert.ToDouble(pirce1);//加收全天房价
                                        AddPric(item, Convert.ToDecimal(pirce1));
                                    }
                                    else
                                    { //转为全天房价
                                        // price += pirce1;？？原来的费用怎么办
                                        item.real_mode_id = 1;
                                        blloi.Update(item);
                                        price = pirce1;
                                    }
                                    TimeSpan ts1 = dts.AddDays(1) - dt2;
                                    shengyumiao = ts1.TotalSeconds.ToString();
                                }
                                else if (to1.TotalSeconds < 0 && to2.TotalSeconds < 0)
                                { //时间没有过开始计费时间
                                    shengyumiao = (to1.TotalSeconds * -1).ToString();
                                }
                            }
                            else if (fee == 2)//按分钟收房费
                            {
                                if (to1.TotalSeconds > 0 && to2.TotalSeconds < 0)
                                { //时间在最小与最大之前
                                    int Dayapart = Convert.ToInt32(model2.Earlyapart);
                                    double DayapartAddP = Convert.ToDouble(model2.EarlyapartAddP);
                                    int DayInExceed = Convert.ToInt32(model2.EarlyInExceed);
                                    double DayInAddPri = Convert.ToDouble(model2.EarlyInAddPri);
                                    //int minutes = Convert.ToInt32(ts.TotalSeconds);//得到超过秒
                                    //int day = minutes / (3600 * 24);
                                    //int hour = minutes % (3600 * 24) / 3600;
                                    //int min = minutes % 3600 / 60;
                                    int minutes = ts.Hours * 60 + ts.Minutes;
                                    int num = minutes / Dayapart;
                                    if (num > 0)
                                    {
                                        for (int i = 0; i < num; i++)
                                        {
                                            price += DayapartAddP;
                                        }
                                    }
                                    int shengyu = minutes % Dayapart;
                                    if (shengyu > DayInExceed)
                                    {
                                        price += DayInAddPri;
                                        shengyumiao = (((Dayapart - shengyu) * 60) - to1.Seconds).ToString();
                                    }
                                    else
                                    {
                                        shengyumiao = (((DayInExceed - shengyu) * 60) - to1.Seconds).ToString();
                                    }
                                    jiafangsh = "超时" + to1.Hours + "小时" + to1.Minutes + "分钟房费";
                                    AddPric(item, Convert.ToDecimal(price), jiafangsh);
                                }
                                else if (to1.TotalSeconds > 0 && to2.TotalSeconds > 0)
                                { //时间已经超过最大时间
                                    if (modelsys.EarlyFeeTwo == 0)
                                    { //加收全天房价
                                        //price += (pirce1);
                                        AddPric(item, Convert.ToDecimal(pirce1));
                                    }
                                    else
                                    { //转为全天房价
                                        item.real_mode_id = 1;
                                        blloi.Update(item);
                                        price = pirce1;
                                    }
                                    TimeSpan ts1 = dts.AddDays(1) - dt2;
                                    shengyumiao = ts1.TotalSeconds.ToString();
                                }
                                else if (to1.TotalSeconds < 0 && to2.TotalSeconds < 0)
                                { //时间没有过开始计费时间
                                    shengyumiao = (to1.TotalSeconds * -1).ToString();
                                }
                            }
                            else if (fee == 3)//不加收房费
                            {
                                if (to1.TotalSeconds > 0 && to2.TotalSeconds < 0)
                                { }
                                else if (to1.TotalSeconds > 0 && to2.TotalSeconds > 0)
                                {
                                    if (modelsys.EarlyFeeTwo == 0)
                                    { //加收全天房价
                                        // price += (pirce1);
                                        AddPric(item, Convert.ToDecimal(pirce1));
                                    }
                                    else
                                    { //转为全天房价
                                        item.real_mode_id = 1;
                                        blloi.Update(item);
                                        price = pirce1;
                                    }
                                    TimeSpan ts1 = dts.AddDays(1) - dt2;
                                    shengyumiao = ts1.TotalSeconds.ToString();
                                }
                                else if (to1.TotalSeconds < 0 && to2.TotalSeconds < 0)
                                { //时间没有过开始计费时间
                                    shengyumiao = (to1.TotalSeconds * -1).ToString();
                                }
                            }
                            //如果今天已经超过了最大时间
                            if (to1.TotalSeconds > 0 && to2.TotalSeconds > 0)
                            {
                                if (modelsys.EarlyFeeTwo == 0)
                                { //加收全天房价

                                }
                                else
                                { //转为全天房价
                                    List<Model.goods_account> listfy = bllga.GetModelList1("Ga_Type=8 and ga_roomNumber='" + item.room_number + "' and ga_occuid=" + item.order_id);
                                    if (listfy.Count > 0)
                                    {
                                        Model.goods_account modelga = listfy[0];
                                        modelga.ga_sum_price = Convert.ToDecimal(pirce1);
                                        bllga.Update(modelga);
                                        //context.Response.End();
                                    }
                                }
                            }
                        }
                        else
                        {
                            lincheng = dt3 - dt2;
                            shengyumiao = lincheng.TotalSeconds.ToString();
                        }
                    }

                    //List<Model.goods_account> list = bllga.GetModelList1("Ga_Type=10 and ga_roomNumber='" + item.room_number + "' and  ga_occuid=" + item.order_id);
                    //if (list.Count > 0)//更新
                    //{
                    //    if (price != 0.00)
                    //    {
                    //        Model.goods_account modega = list[0];
                    //        modega.ga_sum_price = Convert.ToDecimal(price);
                    //        bllga.Update(modega);
                    //    }
                    //}
                    //else
                    //{ //添加
                    //    if (price != 0.00)
                    //    {
                    //        Model.goods_account modega = new Model.goods_account();
                    //        modega.ga_name = "房费";
                    //        modega.ga_roomNumber = item.room_number;
                    //        modega.ga_number = "CSFZ" + DateTime.Now.ToString();
                    //        modega.ga_price = Convert.ToDecimal(0.0);
                    //        modega.ga_date = DateTime.Now;
                    //        modega.ga_people = UserNow.UserID;
                    //        modega.ga_Type = 10;
                    //        modega.ga_sum_price = Convert.ToDecimal(price);
                    //        modega.ga_remker = jiafangsh;
                    //        modega.ga_occuid = item.order_id;
                    //        modega.ga_sfacount = "否";
                    //        modega.ga_isjz = 0;
                    //        modega.Ga_goodNo = item.occ_no;
                    //        bllga.Add(modega);
                    //    }
                    //}
                    Yue(item.room_number, item.real_mode_id, zdfts, tf, lincheng, shengyumiao, bllrn.GetModelList("Rn_roomNum='" + item.room_number + "'")[0].Rn_state.ToString());
                }
            }
            else {
                List<Model.occu_infor> listOci1 = blloi.GetModelList("room_number='" + room1 + "' and state_id!=0 and occ_with='否'");
                if (listOci1.Count > 0) {
                    context.Response.Write(listOci1[0].state_id);
                }
            }
        }


        private int IsAddPrice(Model.occu_infor modelui, int days)
        {
            List<Model.goods_account> listga = bllga.GetModelList1("ga_occuid='" + modelui.order_id + "' and ga_Type=9 and ga_roomNumber='" + modelui.room_number + "' and ga_isys=1");
            return listga.Count;
        }

        /// <summary>
        /// 加收整天房费的
        /// </summary>
        /// <param name="item"></param>
        /// <param name="price1"></param>
        private void AddPric(Model.occu_infor item,decimal price1) {
            Model.goods_account modega = new Model.goods_account();
            modega.ga_name = "房费";
            modega.ga_roomNumber = item.room_number;
            modega.ga_number = "CSFZ" + DateTime.Now.ToString();
            modega.ga_price = Convert.ToDecimal(0.0);
            modega.ga_date = DateTime.Now;
            modega.ga_people = UserNow.UserID;
            modega.ga_Type = 10;
            modega.ga_sum_price = price1;
            modega.ga_remker = "加收整天房费";
            modega.ga_occuid = item.order_id;
            modega.ga_sfacount = "否";
            modega.ga_isjz = 0;
            modega.ga_isys=0;
            modega.Ga_goodNo = item.occ_no;
            bllga.Add(modega);
        }


        /// <summary>
        /// 加收不足一天的房费
        /// </summary>
        /// <param name="item"></param>
        /// <param name="price1"></param>
        private void AddPric(Model.occu_infor item, decimal price1,string remak)
        {
            Model.goods_account modega = new Model.goods_account();
            modega.ga_name = "房费";
            modega.ga_roomNumber = item.room_number;
            modega.ga_number = "CSFZ" + DateTime.Now.ToString();
            modega.ga_price = Convert.ToDecimal(0.0);
            modega.ga_date = DateTime.Now;
            modega.ga_people = UserNow.UserID;
            if (item.real_mode_id == 2)
            {
                modega.ga_Type = 11;
            }
            else
            {
                modega.ga_Type = 10;
            }
            modega.ga_sum_price = price1;
            modega.ga_remker = remak;
            modega.ga_occuid = item.order_id;
            modega.ga_sfacount = "否";
            modega.ga_isjz = 0;
            modega.ga_isys = 0;
            modega.Ga_goodNo = item.occ_no;
            bllga.Add(modega);
        }

        /// <summary>
        /// 是否能撤销入住
        /// </summary>
        private void Chexiao()
        {
            string occid = context.Request.QueryString["id"];
            Model.occu_infor modeloci = blloi.GetModel(Convert.ToInt32(occid));
            DateTime dt1 = modeloci.occ_time;
            DateTime dt2 = DateTime.Now;
            TimeSpan ts = dt2 - dt1;
            if (modelsys.CancellMin >= ts.Minutes) {
                context.Response.Write("OK");
            }
        }


        /// <summary>
        /// 是否需要押金，
        /// </summary>
        private void GetYJ()
        {
            Common.AjaxMsgHelper.AjaxMsg(""+modelsys.IsDeposit+"", modelsys.Deposit.ToString(), "aa", "");
            //context.Response.Write("[{\"isb\":" + modelsys.IsDeposit + ",\"Deposit\":\"" + modelsys.Deposit + "\"}]");
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
