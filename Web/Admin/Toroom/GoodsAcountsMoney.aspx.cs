using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace CdHotelManage.Web.Admin.Toroom
{
    public partial class GoodsAcountsMoney :BasePage
    {
        public int ids
        {

            get { return (int)ViewState["ids"]; }

            set { ViewState["ids"] = value; }

        }
        public string hidids
        {

            get { return (string)ViewState["hidids"]; }

            set { ViewState["hidids"] = value; }

        }
        public string hidid
        {

            get { return (string)ViewState["hidid"]; }

            set { ViewState["hidid"] = value; }

        }
        public string occno
        {

            get { return (string)ViewState["occno"]; }

            set { ViewState["occno"] = value; }

        }
        public string orderid
        {

            get { return (string)ViewState["orderid"]; }

            set { ViewState["orderid"] = value; }

        }
        public string occid
        {

            get { return (string)ViewState["occid"]; }

            set { ViewState["occid"] = value; }

        }
        BLL.meth_pay fmzffs = new BLL.meth_pay();
        BLL.goods_account fmrz = new BLL.goods_account();
        BLL.occu_infor fmOc = new BLL.occu_infor();
        BLL.room_number fmroom = new BLL.room_number();
        BLL.AccountsUsersBLL fmuser = new BLL.AccountsUsersBLL();


        /// <summary>
        /// 根据消费金额添加一定的积分
        /// </summary>
        private void AddJf() {
            int pric = Convert.ToInt32(txt_xfMoney.Value);
            string cardid = hycard.Value;
            Model.member modelmem = bllmem.GetModel(cardid);
            if (modelmem != null) {
                Model.memberType modelmt = bllmt.GetModel(Convert.ToInt32(modelmem.Mtype));
                if (modelmt.IntegraIs) { //如果是积分卡
                    if (modelmt.IsConsump) { //如果是按消费积分
                        if (modelmt.XfPrice.ToString() != "" && modelmt.XfConsump.ToString() != "")
                        {
                            int sumzj = 0;
                            int xfPrice = Convert.ToInt32(modelmt.XfPrice);
                            int XfConsump = Convert.ToInt32(modelmt.XfConsump);
                            int ds = pric / xfPrice;
                            for (int i = 0; i < ds; i++)
                            {
                                sumzj += XfConsump;
                            }
                            Model.mRecords modelmr = new Model.mRecords();
                            modelmr.mmid = cardid;
                            modelmr.Price = sumzj;
                            modelmr.Type = 3;
                            modelmr.Remark = "赠送消费积分";
                            bllmr.Add(modelmr);
                        }
                    }
                }
                if (modelmt.IsLive) { //如果按入住天数计算
                    DateTime date1 = Convert.ToDateTime(fmOc.GetModel(ids).occ_time.ToString());
                   DateTime date2 = System.DateTime.Now;
                    int cc = date2.Day - date1.Day;
                    if (cc < 0)
                    {
                        cc = (Convert.ToDateTime(date2.ToString("yyyy-MM-dd")) - Convert.ToDateTime(date1.ToString("yyyy-MM-dd"))).Days;
                    }
                    int sumzj = 0;
                    int m = Convert.ToInt32(modelmt.LiveNum);
                    int lp = Convert.ToInt32(modelmt.LiveConsump);
                    int ds = cc / m;
                    for (int i = 0; i < ds; i++)
                    {
                        sumzj += lp;
                    }
                    Model.mRecords modelmr = new Model.mRecords();
                    modelmr.mmid = cardid;
                    modelmr.Price = sumzj;
                    modelmr.Type = 3;
                    modelmr.Remark = "赠送入住天数积分";
                    bllmr.Add(modelmr);
                }
            }
        }
        BLL.memberType bllmt = new BLL.memberType();
        BLL.member bllmem = new BLL.member();
        BLL.mRecords bllmr = new BLL.mRecords();
        /// <summary>
        /// 确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdds_Click(object sender, EventArgs e)
        {
            string strSQL = "";
            string sql = "";
            string Strsql = "";
            int count = 0;
            for (int i = 0; i < GrdCostRoom.Rows.Count; i++)
            {
                CheckBox cbxCheck = GrdCostRoom.Rows[i].FindControl("cbxCheck") as CheckBox;
                if (cbxCheck.Checked)
                {
                    if (cbxCheck.Enabled == true)
                    {
                        HiddenField hidNewsId = GrdCostRoom.Rows[i].FindControl("hidId") as HiddenField;
                        if (occid == "")
                        {
                            occid = hidNewsId.Value;
                        }
                        else
                        {
                            occid += "," + hidNewsId.Value;
                        }

                        sql = " update room_number set Rn_state=4 where Rn_roomNum='" + fmOc.GetModel(Convert.ToInt32(hidNewsId.Value)).room_number + "' ";
                        Helper.AddRoom(fmOc.GetModel(Convert.ToInt32(hidNewsId.Value)).room_number);
                        fmroom.Updates(sql);
                    }
                    count++;
                }
            }

            strSQL = "update occu_infor set state_id=3,occ_TfTime='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where occ_id in (" + occid + ")";
            fmOc.Updates(strSQL);
          
            if (GrdCostRoom.Rows.Count == count)
            {
                Strsql = "update goods_account set ga_sfacount='是' where ga_occuid ='" + fmOc.GetModel(ids).order_id + "' ";
                if (!Helper.IsJz(fmOc.GetModel(ids).order_id))
                {
                string[] txtzffs = txt_zhfsMoney.Value.Split('|');
                decimal sumprice = 0;
                for (int j = 0; j < txtzffs.Length-1; j++)
                {
                    Model.goods_account model = new Model.goods_account();
                    model.ga_people = UserNow.UserID;
                    if (txtzffs[j].Split('#')[0] == "10") {
                        MemberAddPrice(Convert.ToInt32(txtzffs[j].Split('#')[1]));
                    }
                    model.ga_zffs_id = Convert.ToInt32(txtzffs[j].Split('#')[0]);
                    model.ga_price = Convert.ToDecimal(txtzffs[j].Split('#')[1]);
                    sumprice += Convert.ToDecimal(model.ga_price);
                    model.ga_sfacount = "是";
                    model.ga_name = "结账收款";
                    model.ga_occuid = fmOc.GetModel(ids).order_id;
                    model.ga_sum_price = 0;
                    model.ga_Type = 4;
                    model.ga_number = System.DateTime.Now.ToString().Replace("-", "").Replace(":", "").Replace(" ", "");
                    model.ga_date = System.DateTime.Now;
                    model.ga_roomNumber = fmOc.GetModel(ids).room_number.ToString();
                    fmrz.Add(model);
                }
                if (Convert.ToDecimal(xfprice.Value) < sumprice + Convert.ToDecimal(skPrice.Value))
                {
                    Model.goods_account model = new Model.goods_account();
                    model.ga_people = UserNow.UserID;
                    model.ga_price = (sumprice + Convert.ToDecimal(skPrice.Value) - Convert.ToDecimal(xfprice.Value)) * -1;
                    model.ga_sfacount = "是";
                    model.ga_name = "结账退款";
                    model.ga_occuid = fmOc.GetModel(ids).order_id;
                    model.ga_sum_price = 0;
                    model.ga_Type = 6;
                    model.ga_zffs_id = 2;
                    model.ga_number = System.DateTime.Now.ToString().Replace("-", "").Replace(":", "").Replace(" ", "");
                    model.ga_date = System.DateTime.Now;
                    model.ga_roomNumber = fmOc.GetModel(ids).room_number.ToString();
                    if (fmrz.Add(model) > 0)
                    {
                        Model.mRecords modelmr = new Model.mRecords();
                        modelmr.mmid = fmOc.GetModel(ids).mem_cardno;
                        modelmr.Price = Convert.ToInt32(model.ga_price);
                        modelmr.Type = 1;
                        modelmr.Remark = "";
                        bllmr.Add(modelmr);
                    }
                }
                    if (fmrz.Updates(Strsql))
                    {
                        XieYi();
                        // Maticsoft.Common.MessageBox.ShowAndRedirect(this, "！", "");
                        string strqwl = "update occu_infor set tuifaId=2 where occ_id in (" + occid + ")";
                        fmOc.Updates(strqwl);
                        Helper.AddRoom(fmOc.GetModel(ids).room_number);
                        AddJf();
                        ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript'> MarkCard(" + orderid + ");</script>");
                    }
                }
                else {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript'>Erroc();</script>");
                }
            }
            else
            {
             

                Maticsoft.Common.MessageBox.ShowAndRedirect(this, "退房成功！", "");
                string strqwl = "update occu_infor set tuifaId=1,continuelive=1 where occ_id in (" + ids + ")";
                fmOc.Updates(strqwl);
                //ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('退房成功');parent.Window_Close();</script>");

              
            }
        }

        /// <summary>
        /// 储值卡支付。要扣除该会员相应的金额
        /// </summary>
        private void MemberAddPrice(int price) {
            Model.mRecords modelmr = new Model.mRecords();
            modelmr.mmid = payHycard.Value;
            modelmr.Price = price;
            modelmr.Remark = "";
            modelmr.Type = 3;
            bllmr.Add(modelmr);
        }

        BLL.customer bllcus = new BLL.customer();
        BLL.cprotocol bllcp = new BLL.cprotocol();
        /// <summary>
        /// 协议入住费用转
        /// </summary>
        private void XieYi() {
            if (accounts.Value != "") { //如果是协议单位入住，更新入住天数    并要把设置计算佣金
                Model.occu_infor modelocc = fmOc.GetModel(ids);
                TimeSpan ts = Convert.ToDateTime(modelocc.depar_time) - Convert.ToDateTime(modelocc.occ_time);
                int mydays = ts.Days;
                if (mydays <= 0) {
                    mydays = 1;
                }
                Model.customer modelcus = bllcus.GetAccounts(accounts.Value);
                modelcus.occNum += mydays;
                bllcus.Update(modelcus);
                /*计算佣金*/
                string accou = account.Value;
                if (modelocc.CpID != null) {
                    Model.cprotocol modelcp = bllcp.GetModel(Convert.ToInt32(modelocc.CpID));
                    if (modelcp != null) {
                        bool dayhire = modelcp.Dayhire;//是否每日计佣
                        int Commission = Convert.ToInt32(modelcp.Commission);//佣金
                        bool ishire = modelcp.ishire;//是否按房类计佣
                        int day = ts.Days;
                        int sum = 0;//总佣金
                        if (ishire) { //如果 是按房类记算佣金
                            BLL.cprotocolPrice bllcpp = new BLL.cprotocolPrice();
                            List<Model.cprotocolPrice> listcpp = bllcpp.GetModelList("cpID=" + modelcp.ID + " and RoomType=" + modelocc.real_type_id);
                            if (listcpp.Count > 0) {
                                Commission = Convert.ToInt32(listcpp[0].commission);
                            }
                        }
                        if (dayhire)
                        {
                            sum = Commission * day;
                        }
                        else {
                            sum = Commission;
                        }
                        BLL.Commission bllcomm = new BLL.Commission();
                        Model.Commission modelcomm = new Model.Commission();
                        modelcomm.Accounts = accounts.Value;
                        modelcomm.CommDesp = "";
                        modelcomm.CommDate = DateTime.Now;
                        modelcomm.CommSum = sum;
                        modelcomm.IsBack = false;
                        modelcomm.GoodNumber = modelocc.occ_no;
                        modelcomm.IsEveryDay = modelcp.Dayhire;
                        modelcomm.DayComm = modelcp.Commission;
                        modelcomm.CommRemark = "";
                        bllcomm.Add(modelcomm);
                    }
                }
            }
            if (idids.Value != "") { //如果是协议单位
                List<Model.goods_account> listga = bllga.GetModelList1("ID in (" + idids.Value + ")");
                if (listga.Count > 0) {
                    foreach (Model.goods_account item in listga)
                    {
                        item.Ga_Account = account.Value;
                        item.ga_Type = 204; 
                        bllga.Update(item);
                    }
                }
            }
        }

        BLL.account_goods bllag = new BLL.account_goods();

        BLL.goods_account bllga = new BLL.goods_account();

        /// <summary>
        /// 绑定支付方式
        /// </summary>
        public void BindZFFS()
        {
            DataSet dt = fmzffs.GetAllList();
            foreach (DataRow dr in dt.Tables[0].Rows)
            {
                hid_zfName.Value += dr["meth_pay_id"].ToString() + "," + dr["meth_pay_name"].ToString() + ";";
            }
            DDlZffs.DataSource = fmzffs.GetModelList("meth_is_jie=1");

            DDlZffs.DataBind();
            DropDownList1.DataSource = fmzffs.GetAllList();
            DropDownList1.DataBind();
        }
        public void BindInfo()
        {
            Model.occu_infor mod = new Model.occu_infor();
            txt_roomNum.Value = fmOc.GetModel(ids).room_number;
            txtrzDate.InnerText = (fmOc.GetModel(ids).occ_time).ToString();
            txt_name.InnerText = (fmOc.GetModel(ids).occ_name).ToString();
            // txt_rzdate.Value = System.DateTime.Now.ToString();
        }
        /// <summary>
        /// 绑定入账信息
        /// </summary>
        public void BindGv()
        {
            int count = 0;
            double Money = 0;
            double ysMoney = 0;
            DataSet dt = fmrz.GetList(" ga_occuid in ('" + orderid + "')");
            foreach (DataRow dr in dt.Tables[0].Rows)
            {
               
                if (dr["ga_Type"].ToString() == "0")
                {
                    dr["ga_remker"] = "消费（商品入账）";
                }
                if (dr["ga_Type"].ToString() == "1")
                {
                    dr["ga_remker"] = "消费（费用入账）" + "," + dr["ga_remker"].ToString();
                }
                if (dr["ga_Type"].ToString() == "3")
                {
                    dr["ga_remker"] = "续住押金";
                }
                if (dr["ga_Type"].ToString() == "4")
                {
                    dr["ga_remker"] = "结账（入账）";
                }
                if (dr["ga_Type"].ToString() == "5")
                {
                    dr["ga_remker"] = "退款（入账）";
                }
                try
                {
                    Money += double.Parse(dr["ga_price"].ToString());

                    ysMoney += double.Parse(dr["ga_sum_price"].ToString());
                }
                catch { }
                count++;
            }

            txt_xfMoneys.Value = txt_xfMoney.Value = ysMoney.ToString();
            txt_ysMoneys.Value = txt_ysMoney.Value = Money.ToString();
            txt_bcysMoneys.Value =(double.Parse(txt_xfMoney.Value) - double.Parse(txt_ysMoney.Value)).ToString();
            GridView1.DataSource = dt;
            GridView1.DataBind();
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
            try
            {
                if (id.ToString() == "")
                {
                    return "";
                }
                BLL.guest_source gsbll = new BLL.guest_source();
                Model.guest_source model = gsbll.GetModel(Convert.ToInt32(id.ToString()));
                return model.gs_name;
            }
            catch (Exception)
            {
                return "";
            }


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
                switch ( Convert.ToInt32(id))
                {
                    case 0:
                        return "在住客人";
                    case 3:
                        return "已退房";
                    case 4:
                        return "挂单客人";
                    default:
                        return "";
                }
            }

        }

        public string GetRoomReal(object id)
        {
            try
            {
                if (id.ToString() == " ")
                {
                    return "";
                }
                else
                {

                    BLL.real_mode rsbll = new BLL.real_mode();
                    Model.real_mode model = rsbll.GetModel(Convert.ToInt32(id.ToString()));
                    return model.real_mode_name;
                }
            }
            catch (Exception ex)
            {
                return "";
            }
            
        }

        #endregion
        /// <summary>
        /// 退房绑定
        /// </summary>
        public void BandTF()
        {
            int count = 0;
            string roomsName = "";
            //and tuifaId in(" + hidid + ") 
            //and tuifaId in(0,1)
            string a = fmOc.GetModel(ids).lordRoomid;
            DataSet dt = fmOc.GetList(" occ_with='否' and order_id='" + orderid + "'  ");
            foreach (DataRow dr in dt.Tables[0].Rows)
            {
                if (dr["lordRoomid"].ToString() == dr["room_number"].ToString())
                {
                    dr["lordRoomid"] = "主";
                }
                else 
                {
                    dr["lordRoomid"] = "从";
                }

                if (dr["state_id"].ToString() == "3")
                {
                    dr["mem_cardno"] = "已退房";
                }
                if (dr["state_id"].ToString() == "0")
                {
                    dr["mem_cardno"] = "在住";
                }
                count++;
                //if (hidids == "" ||hidids==null)
                //{
                //    hidids = dr["order_id"].ToString();
                //    //hidid = dr["occ_id"].ToString();
                //}
                //else 
                //{
                //    hidids += "," + dr["order_id"].ToString();
                //   // hidid =","+ dr["occ_id"].ToString();
                //}
                txt_num.InnerText = count.ToString();
                if (roomsName == "")
                {
                    roomsName = dr["room_number"].ToString();
                }
                else 
                {
                    roomsName += "," + dr["room_number"].ToString();
                    
                }
                sboption.Append("<option value='" + dr["room_number"] + "'>" + dr["room_number"] + "</option>");
                roomNumed.InnerText = roomsName;
            }
            if (count > 2)
            {
                btngd.Attributes.Add("display", "block");
               
            }
            GrdCostRoom.DataSource = dt;
            GrdCostRoom.DataBind();
            
            
            for (int i = 0; i < GrdCostRoom.Rows.Count; i++)
            {
                
                CheckBox cbxCheck = GrdCostRoom.Rows[i].FindControl("cbxCheck") as CheckBox;
                HiddenField hidNewsId = GrdCostRoom.Rows[i].FindControl("hidId") as HiddenField;
                if (fmOc.GetModel(Convert.ToInt32(hidNewsId.Value)).state_id == 3 || fmOc.GetModel(Convert.ToInt32(hidNewsId.Value)).state_id == 2 || fmOc.GetModel(Convert.ToInt32(hidNewsId.Value)).state_id == 4)
                {
                    cbxCheck.Enabled = false;
                    cbxCheck.Checked = true;
                    
                }

            }
        }
        protected System.Text.StringBuilder sboption = new System.Text.StringBuilder();
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnserch_Click(object sender, EventArgs e)
        {
            BandTF();
            BindGv();
           
        }
        /// <summary>
        /// 挂单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btngd_Click(object sender, EventArgs e)
        {
            System.Text.StringBuilder sbtext = new System.Text.StringBuilder();
            System.Text.StringBuilder sbtextRoom = new System.Text.StringBuilder();
            List<Model.occu_infor> listocc = blloc.GetModelList("order_id='" + blloc.GetModel(ids).order_id + "'");
            if (listocc.Count > 0) {
                foreach (Model.occu_infor occi in listocc)
                {
                    sbtext.Append("'" + occi.room_number + "',");
                    sbtextRoom.Append(occi.room_number + ",");
                }
            }
            string str = sbtext.ToString();
            string rooms = str.Substring(0, str.Length - 1);
            string sql = " update room_number set Rn_state=4 where Rn_roomNum in(" + rooms + ")";
            string strSQL = "update occu_infor set state_id=4,remark='已退房',occ_TfTime='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where order_id = '" + blloc.GetModel(ids).order_id + "'";
          //  fmroom.Updates(sql);
            if (fmOc.Updates(strSQL)&& fmroom.Updates(sql)) 
            {
                Helper.AddRoom("", sbtextRoom.ToString());
                //Maticsoft.Common.MessageBox.ShowAndRedirect(this, "挂单成功！", "");
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('挂帐成功');ShowTabs('房态图');</script>");

            }
        }
        //获得支付方式
        public string GetKffsName(string id)
        {
            try
            {
                Model.meth_pay model = fmzffs.GetModel(Convert.ToInt32(id.ToString()));
                return model.meth_pay_name;
            }
            catch 
            {
                return "";
            }

        }
        public string GetUserName(string ides) 
        {
            Model.AccountsUsers modes = fmuser.GetModel(ides.ToString());
            return modes.UserName;
        }


        /// <summary>
        /// 积分兑换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_duihaun_click(object sender,EventArgs e) { 
          
        }

        BLL.occu_infor blloc = new BLL.occu_infor();
        BLL.room_number bllrn = new BLL.room_number();
        protected Model.occu_infor prooccmodle = new Model.occu_infor();
        public override void SonLoad()
        {
            if (!IsPostBack)
            {
                ids = Convert.ToInt32(Request.QueryString["id"]);
                txt_hidid.Value = ids.ToString();
                Model.occu_infor modelocc=fmOc.GetModel(Convert.ToInt32(Request.QueryString["id"]));
                if (modelocc == null)
                {
                    Model.room_number modelrn = bllrn.GetModel(ids);
                    modelocc = blloc.GetModelList("room_number='" + modelrn.Rn_roomNum + "' and state_id=0")[0];
                }
                prooccmodle = modelocc;
                if (modelocc.mem_cardno != "" && modelocc.mem_cardno!=null)
                {
                    btn_duihaun.Style.Add("display", "inline-block");
                    hycard.Value = modelocc.mem_cardno;
                }
                else {
                    btn_duihaun.Style.Add("display", "none");
                    hycard.Value ="";
                }
                zffs_id.Value = modelocc.meth_pay_id.ToString();
                occno = modelocc.occ_no.ToString();
                orderid = modelocc.order_id.ToString();
                orderids.Value = orderid;
                accounts.Value = modelocc.Accounts;
                btnserch_Click(null, null);
                BindZFFS();
                BindInfo();
                occid = "";
                hidids = "";
                txt_id.Value = ids.ToString();
                try
                {
                    txt_ysqje.Value = fmrz.GetModels(" where ga_occuid='" + occno + "'").ga_price.ToString();
                }
                catch
                {
                    txt_ysqje.Value = "0.00";
                }
            }
        }
    }
}
