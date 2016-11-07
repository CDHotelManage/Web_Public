using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Threading;

namespace CdHotelManage.Web.Admin.Toroom
{

    public partial class ToRoom : BasePageVaile
    {
        //public string stwhere
        //{

        //    get { return (string)ViewState["stwhere"]; }

        //    set { ViewState["stwhere"] = value; }

        //}
        public int  ids
        {

            get { return (int)ViewState["ids"]; }

            set { ViewState["ids"] = value; }

        }
        
        string FtNames = string.Empty;
        string a = string.Empty;
        int real_mode_id = 0;
        string str1 = string.Empty;
        DateTime date1;
        DateTime date2;
        int cc;
        int countxuzhu;
        int countLF;
        string SQLlf = string.Empty;
        BLL.room_number brBll = new BLL.room_number();
        BLL.floor_manage fmlc = new BLL.floor_manage();
        BLL.room_type fxBll = new BLL.room_type();
        BLL.room_state fmft = new BLL.room_state();
        BLL.occu_infor fmmx = new BLL.occu_infor();
        System.Text.StringBuilder stwhere = new System.Text.StringBuilder();
        
        BLL.goods_account bllga = new BLL.goods_account();
        public override void SonLoad()
        {
            fxdic.Clear();
            DataSet fxds = fxBll.GetAllList();
            foreach (DataRow item in fxds.Tables[0].Rows)
            {
                fxdic.Add(Convert.ToInt32(item["id"]), item["room_name"].ToString());
            }
           
            modelfs = bllft.GetModel(1);
            if (!IsPostBack)
            {
                /*绑定房型ID和对应的房型名称*/




                ids = 0;
                BindFX();
                //  Bind();
                BindLC();

                BindFT();
                BindFTCX();

                //btnsercher_Click(null, null);
                //System.Timers.Timer time = new System.Timers.Timer(1);
                //time.Elapsed += new System.Timers.ElapsedEventHandler(time_Elapsed);
                //time.AutoReset = false;

                Bind();

            }
            else
            {
                // clien.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "click", "clo();", true);
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript'>clo();</script>");

            }
        }
        string numDay = string.Empty;
        string totime = string.Empty;
        string LFimg = string.Empty;
        string jzfimg = string.Empty;
        string xuzhu = string.Empty;
        string Names = string.Empty;
        string price = string.Empty;
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
        public int czCount = 0;
        public string czico = "";
        string yustr = string.Empty;
        string yudao = string.Empty;
        string Room_suods = string.Empty;
        string b = string.Empty;
        BLL.FtSet bllft = new BLL.FtSet();
        Model.FtSet modelfs = new Model.FtSet();
        protected System.Text.StringBuilder sbhtml = new System.Text.StringBuilder();
        protected System.Text.StringBuilder sbhtml1 = new System.Text.StringBuilder();
        System.Text.StringBuilder drqfsb = new System.Text.StringBuilder();
        Model.occu_infor modelocc = new Model.occu_infor();
        DataSet dtQX = null;
        public void Bind() 
        {
            
            sbhtml.Clear();
            Dictionary<string, string> dicstr = new Dictionary<string, string>();

            Dictionary<string, string> dicCz = new Dictionary<string, string>();
            /*计算边房对应的图标*/
            List<Model.occu_infor> listocc = fmmx.GetModelList("occ_with='否' and state_id=0");
            dicstr = Session["dic"] as Dictionary<string, string>;
            dicCz = Session["iscz"] as Dictionary<string, string>;
            StrWheres();
            DivContent.InnerHtml = "";
            string sjsj = "";
            string img = "";
            string GoodNo = "";
         
            Model.room_number frmfh  = new Model.room_number();
            Model.floor_manage frmlc = new Model.floor_manage();
            DataTable dt = fmlc.GetListYou();
            List<Model.room_number> listrn = bllrn.GetModelList("");
            if (listrn.Count > 0) {
                allroom = listrn.Count;
            }
            DataSet dts=null;
            foreach (DataRow dr in dt.Rows)
            {
                dts = brBll.GetList(stwhere + " and  Rn_floor=" + dr["floor_id"].ToString() + "");

                //if (txt_Namesp.Value == "")
                //{
                //    dts = brBll.GetList(stwhere + " and  Rn_floor=" + dr["floor_id"].ToString() + "");
                //}
                //else if (txt_Namesp.Value == "欠费") 
                //{
                    
                //    string SQL = "select (SUM(ga_price)-SUM(ga_sum_price)) as c,ga_occuid from dbo.goods_account where ga_occuid in (select order_id from dbo.occu_infor where state_id=0) group by ga_occuid";
                //    spanqianf.Attributes.Add("class", "bor");
                //    dtQX = fmgood.GoodsQX(SQL);
                //    foreach (DataRow drqf in dtQX.Tables[0].Rows) 
                //    {
                //        if (Convert.ToDouble(drqf["c"]) < 0) 
                //        {
                //            if (GoodNo == "")
                //            {
                //                drqfsb.Append("'" + drqf["ga_occuid"].ToString() + "'");
                            
                //            }
                //            else { drqfsb.Append("," + "'" + drqf["ga_occuid"].ToString() + "'"); }
                //        }
                //    }
                //    if (drqfsb.ToString() == "") //如果没有欠费
                //    {
                //        dts = brBll.GetList("1!=1");
                //    }
                //    else//查询出来所有的欠费房间
                //    {
                //        dts = brBll.GetListed(stwhere + " and Rn_floor=" + dr["floor_id"].ToString() + " and b.order_id in(" + drqfsb.ToString() + ")", " left join  occu_infor as b on a.Rn_roomNum=b.room_number left join real_mode as c on b.real_mode_id=c.real_mode_id ");
                //    }

                //}
                //else if (txt_Namesp.Value == "催帐") {
                //    dts = brBll.GetListed("", "inner join( select * from occu_infor as oi inner join (select SUM(ga_price)-SUM(ga_sum_price) as sa,ga_occuid as t from goods_account where ga_isys=1  group by ga_occuid) as u on u.t =oi.order_id where u.sa<oi.real_price and datediff(D,[depar_time],'"+DateTime.Now.ToString()+"')=0) as uio on uio.room_number=a.Rn_roomNum and  Rn_floor=" + dr["floor_id"].ToString() + "");
                //}
                //else if (txt_Namesp.Value == "将走房") {
                //    dts = brBll.GetList("Rn_floor=" + dr["floor_id"].ToString() + "");
                //}
                //else
                //{
                //    dts = brBll.GetListed(stwhere + " and Rn_floor=" + dr["floor_id"].ToString() + "", " left join  occu_infor as b on a.Rn_roomNum=b.room_number left join real_mode as c on b.real_mode_id=c.real_mode_id ");
                //}
                if (dts.Tables[0].Rows.Count>0)
                {
                    sbhtml.Append("<ul class='main'>");
                    foreach (DataRow drs in dts.Tables[0].Rows)
                    {
                        price = "";
                        Names = "";
                        xuzhu = "";
                        jzfimg = "";
                        LFimg = "";
                        totime = "";
                        numDay="";
                        if ((drs["Rn_state"]) == null || drs["Rn_state"].ToString()=="") 
                        {
                            drs["Rn_state"] = "0";
                        }
                        FtNames = fmft.GetModel(Convert.ToInt32(drs["Rn_state"])).room_state_name;
                        GetClass( Convert.ToInt32(drs["Rn_state"]));
                        if (FtNames == "干净房")
                        {

                            sjsj = "ondblclick=\"ShowTabt('在住房信息'," + drs["id"].ToString() + ",0,this)\"";

                        }
                        else
                        {
                            sjsj = "";
                        }
                        if (txt_Namesp.Value == "催帐")
                        {
                            czico = "<img src='/admin/images/iconcuizhang.png' />";
                            czCount++;
                        }
                        if (FtNames == "在住房" || FtNames == "脏住房")
                        {
                            try
                            {
                                a = drs["Rn_roomNum"].ToString();
                                lfcounts = 0;
                                modelocc = fmmx.GetModels(" where occ_with='否' and state_id=0 and room_number='" + a + "'");
                                Names = modelocc.occ_name;
                                totime = modelocc.occ_time.ToString("g");
                                real_mode_id = modelocc.real_mode_id;
                                drs["id"] = modelocc.occ_id;

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
                                //str1 = "u.sa < " + modelocc.real_price + " and";
                                //if (modelfs.showday)
                                //{
                                //    str1 = "u.sa < " + Convert.ToInt32(modelfs.daynum) * modelocc.real_price + " and";
                                //}
                                //else
                                //{
                                //    str1 = "";
                                //}
                                //if (modelfs.showyue)
                                //{
                                //    str1 += " u.sa<" + modelfs.moneyNum + " and";
                                //}
                                //dstable = brBll.GetProc(str1, Convert.ToInt32(dr["floor_id"]), a, DateTime.Now.ToString());
                                //dstable = brBll.GetListed("", "inner join( select * from occu_infor as oi inner join (select SUM(ga_price)-SUM(ga_sum_price) as sa,ga_occuid as t from goods_account where ga_isys=1  group by ga_occuid) as u on u.t =oi.order_id where " + str1 + " datediff(D,[depar_time],'" + DateTime.Now.ToString() + "')=0) as uio on uio.room_number=a.Rn_roomNum and  Rn_floor=" + dr["floor_id"].ToString() + " and room_number='" + a + "'");
                                //if (dstable.Tables[0].Rows.Count > 0)
                                //{
                                //    if (modelfs.showyjb)
                                //    {
                                //        czico = "<img src='/admin/images/iconcuizhang.png'/>";
                                //    }
                                //    czCount++;
                                //}
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
                                if (cc < 0) {
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
                                        if (Convert.ToInt32(cc) == 0 || cc<0)
                                        {
                                            numDay = "<span class=\"numday\"> </span>";
                                        }
                                        else
                                        {
                                            numDay = "<span class=\"numday\">"+cc+"</span>";
                                        }
                                        if (modelfs.showYuli)
                                        {
                                            //jzfimg = "<img src=\"/admin/images/iconjiangzou.png\">";
                                        }
                                        jzhouf++;
                                    }
                                    }
                                countxuzhu = fmmx.GetRecordCount(" where continuelive=" + modelocc.occ_id + "");
                                if (countxuzhu > 0)
                                {
                                    xuzhu = "<img src=\"/admin/images/iconxz.png\">";
                                    xuzhufang++;
                                }

                                countLF = fmmx.GetRecordCount(" where order_id='" + modelocc.order_id + "'");
                                if (listocc.Count > 1)
                                {
                                    LFimg = dicstr[a.ToString()];
                                    LFcount++;
                                }
                                //SQLlf = "select order_id  from  occu_infor where order_id in (select  order_id  from  occu_infor  group  by  order_id  having  count(order_id) > 1) group by order_id";
                                //DtLF = fmgood.GoodsQX(SQLlf);

                                //LFcount = DtLF.Tables[0].Rows.Count;


                            }
                            catch { }
                        }
                        b = drs["Rn_roomNum"].ToString();
                        if (drs["Room_suod"].ToString().Trim() == "是")//是否为锁房间
                        {
                            img = "<img src='/admin/images/iconsuofang.png' class=\"suofang\">";
                            sjsj = "";
                            suofang++;
                        }
                        else
                        {
                            img = "";
                        }
                        yudao = string.Empty;
                        string yustr = string.Empty;
                        string yudaoDay = string.Empty;
                        if(drs["Rn_Tobe"] !=null)//是否为预定房间
                        {
                            if (Convert.ToInt32(drs["Rn_Tobe"]) == 1)
                            {
                                yudao = GetYuDao(b);
                                yustr = "yuding";
                                DateTime datestr = Convert.ToDateTime(yudao);
                                DateTime dataend = Convert.ToDateTime(DateTime.Now);
                                int days = datestr.Day - dataend.Day;
                                if (days < 0)
                                {
                                    TimeSpan tss = (Convert.ToDateTime(datestr.ToString("yyyy-MM-dd")) - Convert.ToDateTime(dataend.ToString("yyyy-MM-dd")));
                                    
                                    days = tss.Days;
                                }
                                if (days <= 0) {
                                    yudaoDay = "<div class=\"yuding hrj\">  </div>";
                                    yudao = Convert.ToDateTime(yudao).ToString("hh:mm");
                                }
                                else
                                {
                                    yudao = "";
                                    yudaoDay = "<div class=\"yuding hrj\">" + days + "</div>";
                                }
                            }
                            
                        }
                        sbhtml.Append("<li class=\"hidli\" rooms=" + b + "><ul><li rooms=" + b + " id=" + Convert.ToInt32(drs["id"].ToString()) + " state=" + Convert.ToInt32(drs["Rn_state"]) + " " + sjsj + " class='" + yustr + " " + Style + "'><a href='#'><span class='span01'>" + b + "</span>" + numDay + "<span style='color:yellow'>" + ZC(drs["Rn_roomNum"].ToString()) + "</span><br /><span class=\"fxhrj\">" + fxdic[Convert.ToInt32(drs["Rn_room"])] + "</span>&nbsp;&nbsp; <p>" + img + "<span class=\"icospan\">" + price + "</span><span class=\"lfico\">" + LFimg + "</span><span class=\"qianfei\"></span> <span class=\"xuzhu\">" + xuzhu + "</span><span class=\"czimg\">" + czico + "</span><span class=\"jzfimg\">" + jzfimg + "</span><span class='totime'>" + totime + "</span></p><br /><span class='zuofu'>" + Names + "</span><span class='youfu'>" + Convert.ToDecimal(drs["Rn_price"].ToString()).ToString("0.##") + "</span><span class=\"yue1\"></span><span class=\"stime\"></span><span class=\"shengyu\"></span></a><span class=\"yudao\">" + yudao + "</span></span>" + yudaoDay + "</li></ul></li>");
                        czico = "";
                        bs = false;
                    }
                    sbhtml.Append("</ul>");
                }
            }
           DivContent.InnerHtml = sbhtml.ToString();
        }

        private string ZC(string roomNum) {
            List<Model.occu_infor> listocc = bllic.GetModelList("state_id=0 and  lordRoomid='" + roomNum + "'");
            if (listocc.Count > 1) {
                return "主";
            }
            return "";
        }

        protected System.Text.StringBuilder sbtext1 = new System.Text.StringBuilder();
        bool bs = false;
        protected TimeSpan ts;
        int lfcounts;
        BLL.book_room bllr = new BLL.book_room();
        /// <summary>
        /// 获得预到时间
        /// </summary>
        /// <returns></returns>
        private string GetYuDao(string nummber) {
            List<Model.Book_Rdetail> listbr = bllbr.GetListModel("Room_number='" + nummber + "' and Room_typeid in(1,6)");
            string bookno = string.Empty;
            if (listbr.Count > 0) {
                bookno = listbr[0].Book_no;
                List<Model.book_room> listb = bllr.GetModelList("book_no='" + bookno + "'");
                if (listb.Count > 0) {
                    return listb[0].time_to.ToString();
                }
            }
            return "";
        }
        BLL.Book_Rdetail bllbr = new BLL.Book_Rdetail();
        /// <summary>
        /// 获得是否为预定房间
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private string GetYuding(string number) {
            List<Model.room_number> listrn = bllrn.GetModelList("Rn_roomNum='" + number + "'");
            if (listrn.Count > 0) {
                if (listrn[0].Rn_Tobe == 1) {
                    return "yuding";
                }
            }
            return "";
        }
        /// <summary>
        /// 绑定楼层
        /// </summary>
        public void BindLC()
        {
            DDlouc.DataSource = fmlc.GetAllList();
            DDlouc.DataBind();
            DDlouc.Items.Insert(0, "全部");
        }
        Dictionary<int, string> fxdic = new Dictionary<int, string>();
        /// <summary>
        /// 绑定房型
        /// </summary>
        public void BindFX()
        {
            
            DataSet fxds = fxBll.GetAllList();
            ddroomtype.DataSource = fxds;
            ddroomtype.DataBind();
             ddroomtype.Items.Insert(0, "全部");
             
        }
        /// <summary>
        /// 绑定房态
        /// </summary>
        public void BindFT() 
        {
            ddlState.DataSource = fmft.GetAllList();
            ddlState.DataBind();
            ddlState.Items.Insert(0, "全部");
        }
        /// <summary>
        /// 房态方法显示
        /// </summary>
        public void BindFTCX() 
        {
            DataSet dt = fmft.GetList(" room_state_id not in(6) order by room_state_id desc");
           
            foreach (DataRow dr in dt.Tables[0].Rows)
            {
              
                dr["remark"] = brBll.GetRecordCount(" Rn_state=" + dr["room_state_id"] + "").ToString();   
            }
            Repeaterft.DataSource = dt;
            Repeaterft.DataBind();
        }
        /// <summary>
        /// 设置样式方法
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public string GetClassList(int state,int id,string Roomid) 
        {
            string FtName="";
            if (state != 0) 
            {
                FtName = fmft.GetModel(state).room_state_name;

            }
            ListYJ = "<li onclick='GoodsAdds(this," + Roomid + ")'>商品入账</li><li onclick='CostAdds(this," + Roomid + ")'>费用入账</li><li onclick='LiveDayAdds(this," + Roomid + ")'>续住</li><li  onclick='replaceAdds(this," + Roomid + ")'>换房</li><li onclick='Adds(this," + Roomid + ",1)'>修改在住房信息</li><li>修改房态</li>";
            #region
            //if (FtName == "在住房")
            //{
            //    ListYJ = "<li  onclick='Adds(this," + id + ")'>开房</li><li>结账</li><li onclick='GoodsAdds(this," + Roomid + ")'>商品入账</li><li onclick='CostAdds(this," + Roomid + ")'>费用入账</li><li onclick='LiveDayAdds(this," + Roomid + ")'>续住</li><li onclick='replaceAdds(this," + Roomid + ")'>换房</li><li>房价调整</li><li>修改主人信息</li><li>修改主账房号</li><li>修改房态</li>";
            //}
            //else if (FtName == "干净房" || state == 0)
            //{
            //   // ListYJ = "<li onclick='Adds(this,"+id+")'>开房</li><li>修改房态</li>";
            //    ListYJ = "<li  onclick='Adds(this," + id + ")'>开房</li><li>结账</li><li onclick='GoodsAdds(this," + Roomid + ")'>商品入账</li><li onclick='CostAdds(this," + Roomid + ")'>费用入账</li><li onclick='LiveDayAdds(this," + Roomid + ")'>续住</li><li  onclick='replaceAdds(this," + Roomid + ")'>换房</li><li>房价调整</li><li>修改主人信息</li><li>修改主账房号</li><li>修改房态</li>";

            //}
            //else if (FtName == "将到房")
            //{
            //    ListYJ = "<li  onclick='Adds(this," + id + ")'>开房</li><li>结账</li><li onclick='GoodsAdds(this," + Roomid + ")'>商品入账</li><li onclick='CostAdds(this," + Roomid + ")'>费用入账</li><li onclick='LiveDayAdds(this," + Roomid + ")'>续住</li><li  onclick='replaceAdds(this," + Roomid + ")'>换房</li><li>房价调整</li><li>修改主人信息</li><li>修改主账房号</li><li>修改房态</li>";

            //}
            //else if (FtName == "脏房")
            //{
            //   // ListYJ = "<li  onclick='Adds(this," + id + ")'>开房</li><li>修改房态</li>";
            //    ListYJ = "<li  onclick='Adds(this," + id + ")'>开房</li><li>结账</li><li onclick='GoodsAdds(this," + Roomid + ")'>商品入账</li><li onclick='CostAdds(this," + Roomid + ")'>费用入账</li><li onclick='LiveDayAdds(this," + Roomid + ")'>续住</li><li  onclick='replaceAdds(this," + Roomid + ")'>换房</li><li>房价调整</li><li>修改主人信息</li><li>修改主账房号</li><li>修改房态</li>";

            //}
            //else 
            //{
            //   // ListYJ = "<li  onclick='Adds(this," + id + ")'>开房</li><li>修改房态</li>";
            //    ListYJ = "<li  onclick='Adds(this," + id + ")'>开房</li><li>结账</li><li onclick='GoodsAdds(this," + Roomid + ")'>商品入账</li><li onclick='CostAdds(this," + Roomid + ")'>费用入账</li><li onclick='LiveDayAdds(this," + Roomid + ")'>续住</li><li  onclick='replaceAdds(this," + Roomid + ")'>换房</li><li>房价调整</li><li>修改主人信息</li><li>修改主账房号</li><li>修改房态</li>";


            //}
            #endregion
            return ListYJ;
        }
        BLL.room_number bllrn = new BLL.room_number();
        BLL.occu_infor bllic = new BLL.occu_infor();
        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            string SQl = "";
            string roomNum = hidRoom.Value;
            string a = hidNumber.Value;
            if (bllic.GetModel(Convert.ToInt32(roomNum)) != null)
            {
                string num=bllic.GetModel(Convert.ToInt32(roomNum)).room_number;
                Helper.AddRoom(num);
                roomNum = bllrn.GetModelList("Rn_roomNum='" + num + "'")[0].id.ToString();
            }
            else
            {
                Helper.AddRoom(bllrn.GetModel(Convert.ToInt32(roomNum)).Rn_roomNum);
            }
            if (hidNumber.Value == "0")
            {
                //脏房
                SQl = "update room_number set Rn_state=4 where id=" + roomNum + "";

            }
            //if (hidNumber.Value == "1")
            //{
            //    //维修
            //    SQl = "update room_number set Rn_state=5 where id=" + roomNum + "";

            //}
            if (hidNumber.Value == "2")
                
            {
                //干净房
                SQl = "update room_number set Rn_state=3 where id=" + roomNum + "";

            }

            if (hidNumber.Value == "3") 
            {
                //锁定
                SQl = "update room_number set Room_suod='是' where id=" + roomNum + "";
            }
            if (hidNumber.Value == "4")
            {
                //没有锁定
                SQl = "update room_number set Room_suod='否' where id=" + roomNum + "";
            }
            if (hidNumber.Value == "5")
            {
                //脏住房
                SQl = "update room_number set Rn_state=7 where id='" + roomNum + "'";
            }
            if (hidNumber.Value == "6")
            {
                //干净房
                SQl = "update room_number set Rn_state=2 where id=" + roomNum + "";
            }
            if (hidNumber.Value == "7")
            {
                //自用房
                SQl = "update room_number set Rn_state=8 where id=" + roomNum + "";
            }
            brBll.Updates(SQl);
            Bind();
            
        }
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
        /// <summary>
        /// 设置样式方法2
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public string GetClassDiv(int state)
        {
            string FtName = "";
            
            if (state != 0)
            {
                FtName = fmft.GetModel(state).room_state_name;

            }
            
            if (FtName == "在住房")
            {
                Style = "bgorange ztspan01";
            }
            else if (FtName == "干净房" || state == 0)
            {
                Style = "bgblue ztspan01";
            }
            else if (FtName == "将到房")
            {
                Style = "yuding ztspan01";
            }
            else if (FtName == "脏房")
            {
                Style = "bggray_q ztspan01";
            }
            else if (FtName == "维修房")
            {
                Style = "bggray_s ztspan01";
            }
            else if (FtName == "脏住房")
            {
                Style = "zhang_zf ztspan01";
            }
            else if (FtName == "自用房")
            {
                Style = "pink_zyf ztspan01";
            }
            else
            {
                Style = "bggray_s ztspan01";
            }
            return Style;
        }
        public string GetFX( int id)
        {
            BLL.room_type rtbll = new BLL.room_type();

            Model.room_type model = rtbll.GetModel(Convert.ToInt32(id.ToString()));

            return model.room_name;
        }
        public int allroom = 0;
        /// <summary>
        /// 查询条件
        /// </summary>
        public void StrWheres()
        {

            string a = txt_Namesp.Value;
            spanyzf.Attributes.Remove("class");
            spanzdf.Attributes.Remove("class");
            spanlingc.Attributes.Remove("class");
            spanxuzhu.Attributes.Remove("class");
            spansuofang.Attributes.Remove("class");
            span1.Attributes.Remove("class");
            span2.Attributes.Remove("class");
            spanlf.Attributes.Remove("class");
            spanjiangz.Attributes.Remove("class");
            spanqianf.Attributes.Remove("class");
            string s= ddroomtype.SelectedValue;
            if (a == "")
            {
                stwhere.Append("1=1 ");
            }
            else 
            {
                stwhere.Append( "1=1 and (b.state_id is null or b.state_id !=3 )");

            }
            if (DDlouc.SelectedIndex > 0) 
            {
                stwhere.Append(" and Rn_floor='" + DDlouc.SelectedValue + "'");
            }
            if (ddroomtype.SelectedIndex > 0)
            {
                stwhere.Append(" and Rn_room=" + ddroomtype.SelectedValue + "");
            }
            if (ddlState.SelectedIndex > 0)
            {
                stwhere.Append(" and Rn_state=" + ddlState.SelectedValue + "");
            }
            if (sstext.Value != "") {
                List<Model.occu_infor> lio = bllic.GetModelList("occ_name like '%" + sstext.Value + "%'");
                System.Text.StringBuilder sbroom = new System.Text.StringBuilder();
                string r=string.Empty;
                if (lio.Count > 0)
                {
                    foreach (Model.occu_infor item in lio)
                    {
                        sbroom.Append("'" + item.room_number + "',");
                    }
                    r = sbroom.ToString().Remove(sbroom.Length - 1, 1);
                }
                else {
                    r = "''";
                }
                stwhere.Append(" and  Rn_roomNum like '%" + sstext.Value + "%' or Rn_roomNum in(" + r + ")");
            }
            if (ids != 0) 
            {
                stwhere.Append(" and Rn_state=" + ids + "");
            }
            if (ids == 999)
            {
                stwhere.Append(" 1=1 ");
            }
            if (a=="月租房") 
            {
                stwhere.Append(" and b.real_mode_id=19 and state_id=0 ");
                spanyzf.Attributes.Add("class", "bor");
            }
            if (a == "钟点房")
            {
                stwhere.Append(" and b.real_mode_id=2 and state_id=0 ");
                spanzdf.Attributes.Add("class", "bor");
            }
            if (a == "凌晨房")
            {
                stwhere.Append(" and b.real_mode_id=5 and state_id=0 ");
                spanlingc.Attributes.Add("class", "bor");
            }
            if (a == "续住")
            {
                stwhere.Append(" and  occ_id  in(select continuelive  from occu_infor) and state_id=0 ");
                spanxuzhu.Attributes.Add("class", "bor");
            }
            if (a == "锁房")
            {
               stwhere.Append(" and Room_suod='是'");
                spansuofang.Attributes.Add("class", "bor");
            }
            if (a == "催帐")
            {
                stwhere.Append(" and Room_suod='是'and state_id=0 ");
                span1.Attributes.Add("class", "bor"); 
            }
            if (a == "免房")
            {
                stwhere.Append(" and b.real_mode_id=20  and state_id=0 ");
                span2.Attributes.Add("class", "bor"); 
            }
            if (a == "联房")
            {
                stwhere.Append(" and  order_id in (select  order_id  from  occu_infor  group  by  order_id  having  count(order_id) > 1) and state_id=0 ");
                spanlf.Attributes.Add("class", "bor"); 
            }
            if (a == "将走房")
            {
              // stwhere += " and  CONVERT(varchar(100), DATEADD (DAY,1,GETDATE()),20)=CONVERT(varchar(100), depar_time,20) and state_id=0 ";
                stwhere.Append(" and  (datediff(HH,GETDATE(),depar_time))<=24 and state_id=0 and real_mode_id!=2");
               spanjiangz.Attributes.Add("class", "bor"); 
            }
            
        }
        /// <summary>
        /// 按楼层查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DDlouc_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bind();

        }
        /// <summary>
        /// 按房型查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddroomtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bind();
        }
        /// <summary>
        /// 按房态查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bind();
        }
        /// <summary>
        /// 定位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void czbutton_Click(object sender, EventArgs e)
        {
            Bind();
        }
        /// <summary>
        /// 触发查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnsercher_Click(object sender, EventArgs e)
        {
            try
            {
                ids = Convert.ToInt32(txt_ids.Value);
            }
              
            catch { }
            Bind();
        }
        /// <summary>
        /// 显示值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGetzhi_Click(object sender, EventArgs e)
        {
            string a = "";
          //  divFv.Style.Add("display", "block");
        }
        public int BindXZ(int id) 
        {
            int count = fmmx.GetRecordCount(" continuelive="+id+"");
            return count;
        }
        /// <summary>
        /// 撤销入主
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        BLL.goods_account fmgood = new BLL.goods_account();
        protected void btncx_Click(object sender, EventArgs e)
        {
            string a = txt_ids.Value;
            string orderby = fmmx.GetModel( Convert.ToInt32(a)).order_id;
            string Sql = "update goods_account set ga_sfacount='是' where ga_occuid='" + orderby + "'";
            string str2 = "update room_number set Rn_state=3 where Rn_roomNum='" + fmmx.GetModel(Convert.ToInt32(a)).room_number +"'";
            string STRSQL = " update occu_infor set state_id=10 where occ_id='" + a + "'";
            if (brBll.Updates(str2) && fmmx.Updates(STRSQL) && fmgood.Updates(Sql))
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('撤销入账成功');</script>");

                Bind();
            }
            else 
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('撤销入账失败');</script>");

            }
        }

        
    }
}
