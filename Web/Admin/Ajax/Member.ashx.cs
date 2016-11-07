using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace CdHotelManage.Web.Admin.Ajax
{
    /// <summary>
    /// Member 的摘要说明
    /// </summary>
    public class Member : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {
        HttpContext context = null;
        public void ProcessRequest(HttpContext context)
        {
            this.context = context;
            string type = context.Request.QueryString["type"];
            switch (type)
            {
                case "getprice":
                    Getprice();
                    break;
                case "isok":
                    Isok();
                    break;
                case "GetPirceAddJf":
                    GetPirceAddJf();
                    break;
                case "getallm":
                    Ggetallm();
                    break;
                case "getvalue":
                    Getvalue();
                    break;
                case "addFA":
                    AddFA();
                    break;
                case "del":
                    Del();
                    break;
                case "addmt":
                    Addmt();
                    break;
                case "delRow":
                    DelRow();
                    break;
                case "getCard":
                    GetCard();
                    break;
                case "delmt":
                    Delmt();
                    break;
                case "GetTypeName":
                    int id = Convert.ToInt32(context.Request.QueryString["id"]);
                    string str = GetTypeName(id);
                    if (str != "") {
                        context.Response.Write(str);
                    }
                    break;
                case "find":
                    Find();
                    break;
                case "getDuihaun":
                    GetDuihaun();
                    break;
                case "addcp":
                    Addcp();
                    break;
                case "deleteall":
                    deleteall();
                    break;
                case "getPrice":
                    GetPrice();
                    break;
                case "getids":
                    Getids();
                    break;
                case "getsumprice":
                    Getsumprice();
                    break;
                case "getisOk":
                    GetisOk();
                    break;
                case "getpice":
                    Getpice();
                    break;
                case "getinfo":
                    Getinfo();
                       break;
                case "VailPwd":
                       VailPwd();
                       break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 验证密码是否正确
        /// </summary>
        private void VailPwd()
        {
            string pwd = context.Request.QueryString["pwd"];
            string num = context.Request.QueryString["num"];
            Model.member modelmem = bllme.GetModel(num);
            if (modelmem != null && modelmem.Pwd == pwd)
            {
                context.Response.Write("ok");
                context.Response.End();
            }
            else {
                context.Response.Write("err");
                context.Response.End();
            }
            
        }

        /// <summary>
        /// 获得点击后会员的信息
        /// </summary>
        private void Getinfo()
        {
            string account = context.Request.QueryString["memid"];
            Model.member modelmem = bllme.GetModel(account);

            if (modelmem != null) {
                GetSumJf(account);
                context.Response.Write("会员类型:" + GetTypeName( Convert.ToInt32(modelmem.Mtype)) + " 剩余积分:" + shengyu + " 剩余金额:" + czyue);
            }
        }

        
        /// <summary>
        /// 所有价格列表
        /// </summary>
        private void Getpice()
        {
            System.Text.StringBuilder sbtext = new System.Text.StringBuilder();
            int id = Convert.ToInt32(context.Request.QueryString["id"]);
            //判断是不是使用固定折扣值
            BLL.cprotocol bllcp = new BLL.cprotocol();
            Model.cprotocol modelcp = bllcp.GetModel(id);
            if (!modelcp.Isdiscount)
            { //如果使用自定义折扣
                BLL.cprotocolPrice bllcpp = new BLL.cprotocolPrice();
                List<Model.cprotocolPrice> listcpp = bllcpp.GetModelList("cpID=" + id);
                BLL.room_type bllty = new BLL.room_type();
                List<Model.room_type> listrt = bllty.GetModelList("");
                foreach (Model.room_type item in listrt)
                {
                    List<Model.cprotocolPrice> newcpp = listcpp.Where(d => d.RoomType == item.id).ToList();
                    if (newcpp.Count > 0)
                    {
                        sbtext.Append("<tr><td>" + GetFxName(Convert.ToInt32(newcpp[0].RoomType)) + "</td><td>" + Convert.ToDecimal(newcpp[0].Price).ToString("0.##") + "</td><td>" + Convert.ToDecimal(newcpp[0].protoPrice).ToString("0.##") + "</td><td>" + Convert.ToDecimal(newcpp[0].mothPrice).ToString("0.##") + "</td></tr>");
                    }
                    else
                    {
                        sbtext.Append("<tr><td>" + GetFxName(item.id) + "</td><td>" + Convert.ToDecimal(item.room_listedmoney).ToString("0.##") + "</td><td>" + Convert.ToDecimal(item.room_listedmoney).ToString("0.##") + "</td><td>" + Convert.ToDecimal(item.Room_Moth_price).ToString("0.##") + "</td></tr>");
                    }
                }
            }
            else {
                decimal duding = Convert.ToDecimal(modelcp.discount);
                BLL.room_type bllty = new BLL.room_type();
                List<Model.room_type> listrt = bllty.GetModelList("");
                foreach (Model.room_type item in listrt)
                {
                    sbtext.Append("<tr><td>" + GetFxName(item.id) + "</td><td>" + Convert.ToDecimal(item.room_listedmoney).ToString("0.##") + "</td><td>" + Convert.ToDecimal(item.room_listedmoney * duding).ToString("0.##") + "</td><td>" + Convert.ToDecimal(item.Room_Moth_price * duding).ToString("0.##") + "</td></tr>");
                    
                }
            }
           
            context.Response.Write(sbtext.ToString());
        }

        private string GetFxName(int id) {
            BLL.room_type bllrt = new BLL.room_type();
            return bllrt.GetModel(id).room_name;
        }

        BLL.customer bllcus = new BLL.customer();
        private void GetisOk()
        {
            string account = context.Request.QueryString["accout"];
            int ys = 0;
            List<Model.goods_account> listag = bllga.GetModelList1("ga_Account='" + account + "'");
            if (listag.Count > 0)
            {
                foreach (Model.goods_account item in listag)
                {
                   
                    if (item.ga_Type == 204)
                    {
                        ys += Convert.ToInt32(item.ga_sum_price);
                    }
                   
                }

            }
            string d = context.Request.QueryString["price"];
            Model.customer modelcus = bllcus.GetAccounts(account);
            string msg = string.Empty;
            JavaScriptSerializer js = new JavaScriptSerializer();
            if (modelcus.Ischalk)
            {
                 var obj= new { statu = "err", msg = "止单位不允许记帐!" };
                 msg= js.Serialize(obj);
            }
            else {
                if (modelcus.IsXz) {
                    if (Convert.ToDecimal(d) + ys > modelcus.limit)
                    {
                        var obj = new { statu = "err", msg = "已超过最大记帐值!" };
                       msg= js.Serialize(obj);
                    }
                    else {
                        var obj = new { statu = "ok", msg = "成功!" };
                       msg= js.Serialize(obj);
                    }
                }
                else
                {
                    var obj = new { statu = "ok", msg = "成功!" };
                    msg = js.Serialize(obj);
                }
            }
            context.Response.Write(msg);
        }

        private void Getsumprice()
        {
            string ids = context.Request.QueryString["ids"];
            List<Model.goods_account> lsitga = bllga.GetModelList1(" ID in (" + ids + ")");
            decimal d = 0;
            foreach (Model.goods_account ite in lsitga)
            {
                d += Convert.ToDecimal(ite.ga_sum_price);
            }
            context.Response.Write(d);
        }

        private void Getids()
        {
            string ordesr = context.Request.QueryString["orders"].ToString();
            System.Text.StringBuilder sbtext = new System.Text.StringBuilder();
            List<Model.goods_account> lsitga = bllga.GetModelList1("ga_Type in (8,0,1,9,10,101,11) and ga_occuid='" + ordesr + "'");
            foreach (Model.goods_account item in lsitga)
            {
                sbtext.Append(item.id + ",");
            }
            context.Response.Write(sbtext.ToString());
        }
        BLL.goods_account bllga = new BLL.goods_account();
        BLL.room_type bllrt = new BLL.room_type();
        BLL.cprotocol bllcp = new BLL.cprotocol();
        /// <summary>
        /// 通过房型与和协议获得价格
        /// </summary>
        private void GetPrice()
        {
            int cpid = Convert.ToInt32(context.Request.QueryString["cpid"]);
            int typeid = Convert.ToInt32(context.Request.QueryString["typeid"]);
            Model.cprotocol modelcp = bllcp.GetModel(cpid);
            if (!modelcp.Isdiscount)
            { //如果没有使用固定折扣值



                List<Model.cprotocolPrice> listap = bllcprice.GetModelList("cpID=" + cpid + " and RoomType=" + typeid);
                if (listap.Count > 0)
                {
                    string str = js1.Serialize(listap);
                    Common.AjaxMsgHelper.AjaxMsg1("ok", "", str, "");
                }
                else
                {
                    decimal dc = Convert.ToDecimal(bllrt.GetModel(typeid).room_listedmoney);
                    decimal zkz = Convert.ToDecimal(modelcp.discount);
                    var obj = new { Price = dc, protoPrice = (dc * zkz).ToString() };
                    string str = js1.Serialize(obj);
                    Common.AjaxMsgHelper.AjaxMsg1("err", "", str, "");
                }
            }
            else { //如果使用固定折扣值
                decimal dc = Convert.ToDecimal(bllrt.GetModel(typeid).room_listedmoney);
                decimal zkz = Convert.ToDecimal(modelcp.discount);
                var obj=new {Price=dc,protoPrice=(dc * zkz).ToString()};
                string str=js1.Serialize(obj);
                Common.AjaxMsgHelper.AjaxMsg1("err", "", str, "");
            }
        }

        private void deleteall()
        {
            string Account = context.Request.QueryString["Account"];
            int pids = Convert.ToInt32(context.Request.QueryString["pids"]);
            bllcprice.DeleteWhere("delete from cprotocolPrice where Accounts='" + Account + "' and cpID=" + pids);
        }

        private void Addcp()
        {
            string Account = context.Request.QueryString["Account"];
            string RoomType = context.Request.QueryString["RoomType"];
            string Price = context.Request.QueryString["Price"];
            string zdPrice = context.Request.QueryString["zdPrice"];
            string protoPrice = context.Request.QueryString["protoPrice"];
            string mothPrice = context.Request.QueryString["mothPrice"];
            string commission = context.Request.QueryString["commission"];
            int pids = Convert.ToInt32(context.Request.QueryString["pids"]);
            Model.cprotocolPrice modelcp = new Model.cprotocolPrice();
            modelcp.Accounts = Account;
            modelcp.RoomType = Convert.ToInt32(RoomType);
            modelcp.Price =  Convert.ToInt32(Price);
            modelcp.protoPrice = Convert.ToInt32(protoPrice);
            modelcp.mothPrice =Convert.ToInt32( mothPrice);
            modelcp.zdPrice = Convert.ToInt32(zdPrice);
            modelcp.commission = Convert.ToInt32(commission);
            modelcp.Breakfast = 0;
            modelcp.CpID = pids;
            bllcprice.Add(modelcp);
        }

        BLL.cprotocolPrice bllcprice = new BLL.cprotocolPrice();
        /// <summary>
        /// 兑换房间用费
        /// </summary>
        private void GetDuihaun()
        {
            string mtid = context.Request.QueryString["mid"];
            string Amount = context.Request.QueryString["Amount"];
            string syjf = context.Request.QueryString["syjf"];
            Model.member modelmem = bllme.GetModel(mtid);
            Model.memberType modelty = bllmt.GetModel(Convert.ToInt32(modelmem.Mtype));
            if (modelty.IsTx)
            {
                int jf = Convert.ToInt32(modelty.MachJf);
                int sum = jf * Convert.ToInt32(Amount);
                if (sum > Convert.ToInt32(syjf))
                {
                    int je=Convert.ToInt32(syjf)/jf;
                    int ld=Convert.ToInt32(syjf)%jf;
                    int sumjf = je * jf;
                    var obj=new { je=je,sumjf=sumjf };
                    string str=js1.Serialize(obj);
                    Common.AjaxMsgHelper.AjaxMsg1("err", "积分不足", str, "");
                }
                else
                {
                    Common.AjaxMsgHelper.AjaxMsg("ok", "", "" + sum.ToString() + "", "");
                }
            }
            else {
                Common.AjaxMsgHelper.AjaxMsg1("err", "该会员不支持积分兑换!", "", "");
            }
        }

        private void Find()
        {
            string mtid = context.Request.QueryString["mid"];
            Model.member modelmem = bllme.GetModel(mtid);
            modelmem.Statid = 0;
            if (bllme.Update(modelmem)) {
                context.Response.Write("ok");
            }
        }

        private void Delmt()
        {
            string mtid = context.Request.QueryString["id"];
            if (bllme.GetModelList("Mtype='"+mtid+"'").Count > 0)
            {
                context.Response.Write("err");
                context.Response.End();
            }
            if (bllmt.Delete(mtid)) {
                context.Response.Write("ok");
                context.Response.End();
            }
        }

        private void GetCard()
        {
            string card = context.Request.QueryString["cardno"];
            List<Model.member> listmem = bllme.GetModelList("ZjNumber=" + card);
            if (listmem.Count > 0)
            {
                context.Response.Write("err");
            }
            else {
                context.Response.Write("ok");
            }
        }

        private void DelRow()
        {
            BLL.mtPrice bllmt = new BLL.mtPrice();
            int ids = Convert.ToInt32(context.Request.QueryString["id"]);
            if (bllmt.Delete(ids)) {
                context.Response.Write("ok");
            }
        }

        /// <summary>
        /// 添加方案
        /// </summary>
        private void Addmt()
        {
            BLL.mtPrice bllmt = new BLL.mtPrice();
            int RowId = Convert.ToInt32(context.Request.QueryString["RowId"]);
            int MTID = Convert.ToInt32(context.Request.QueryString["MTID"]);
            int rtid = Convert.ToInt32(context.Request.QueryString["rtid"]);
            int Price = Convert.ToInt32(context.Request.QueryString["Price"]);
            float zdPrice = float.Parse(context.Request.QueryString["zdPrice"]);
            int Dayprice = Convert.ToInt32(context.Request.QueryString["Dayprice"]);
            int lcPrice = Convert.ToInt32(context.Request.QueryString["lcPrice"]);

            Model.mtPrice modelmt=new Model.mtPrice(){
                Price = Price,
                lcPrice = lcPrice,
                MTID = MTID,
                Dayprice = Dayprice,
                RoomType = rtid,
                zdPrice = zdPrice
            };
            if (RowId == 0)
            {
                if (bllmt.GetModelList("RoomType=" + rtid + " and MTID=" + MTID).Count > 0)
                {
                    context.Response.Write("不能添加重复的房型");
                }
                else
                {
                    if (bllmt.Add(modelmt) > 0)
                    {
                        context.Response.Write("ok");
                    }
                    else
                    {
                        context.Response.Write("err");
                    }
                }
            }
            else {
                modelmt.ID = RowId;
                bllmt.Update(modelmt);
                context.Response.Write("ok");
            }
        }

        /// <summary>
        /// 方案删除
        /// </summary>
        private void Del()
        {
            int id = Convert.ToInt32(context.Request.QueryString["id"]);
            if (bllap.Delete(id))
            {
                context.Response.Write("ok");
            }
            else {
                context.Response.Write("err");
            }
        }

        /// <summary>
        /// 添加方案
        /// </summary>
        private void AddFA()
        {
            int rowid = Convert.ToInt32(context.Request.QueryString["id"]);
            int RechargeAmount = Convert.ToInt32(context.Request.QueryString["RechargeAmount"]);
            int GivenAmount = Convert.ToInt32(context.Request.QueryString["GivenAmount"]);
            int GivenSorce = Convert.ToInt32(context.Request.QueryString["GivenSorce"]);
            int Status = Convert.ToInt32(context.Request.QueryString["Status"]);
            BLL.AddPrice bllan = new BLL.AddPrice();
            Model.AddPrice modeladd = new Model.AddPrice();
            modeladd.AddPice = RechargeAmount;
            modeladd.ZsPice = GivenAmount;
            modeladd.ZsJf = GivenSorce;
            if (Status == 0)
            {
                Status = 1;
            }
            else {
                Status = 0;
            }
            modeladd.IsOk = Convert.ToBoolean(Status);
            modeladd.Remark = "";
            if (rowid != 0)
            {
                modeladd.MtID = rowid;
                bllan.Update(modeladd);
            }
            else
            {
                bllan.Add(modeladd);
            }
        }

        //根据卡号获得所有的信息
        private void Getvalue()
        {
                string mid =context.Request.QueryString["mid"];
            Model.member model = bllme.GetModel(mid);
            if (model!= null)
            {
                Model.memberType modelty = bllmt.GetModel(Convert.ToInt32(model.Mtype));
                GetSumJf(model.Mid.ToString());
                var obj = new { states = "ok", name = model.Name, zj = GetZJ(Convert.ToInt32(model.Zjtype)), ZjNumber = model.ZjNumber, typename = GetTypeName(Convert.ToInt32(model.Mtype)), Baithday = model.Baithday == null ? "" : Convert.ToDateTime(model.Baithday).ToString("yyyy-MM-dd"), sales = model.sales, Phone = model.Phone, Likes = model.Likes, Address = model.Address, Ramrek = model.Ramrek, sumjf = sumjf, duihua = duihua, shengyu = shengyu, dongjie = dongjie, czsum = czsum, xfsum = xfsum, czyue = czyue, xfnum = xfnum, xfall = xfall, state = GetState(Convert.ToInt32(model.Statid)), date = model.AddDate == null ? "" : Convert.ToDateTime(model.AddDate).ToString("yyyy-MM-dd"), xq = GetQx(modelty), Mtype = model.Mtype, isok = model.IntegraDj, cardPrice = modelty.typePrice, yxtime = Convert.ToDateTime(model.XqTime).ToString("yyyy-MM-dd"), UpLive = GetTypeName(Convert.ToInt32(modelty.UpLive)), IsDeduction = modelty.IsDeduction, ConsumpSum = modelty.ConsumpSum, umtid = modelty.UpLive };
                string str = js1.Serialize(obj);
                context.Response.Write(str);
            }
            else {
                var obj = new { states = "err" };
                string str = js1.Serialize(obj);
                context.Response.Write(str);
                context.Response.End();
            }
        }

        private string GetQx(Model.memberType modelty) {
            if (modelty.Limit)
            {
                return modelty.LimitValue.ToString();
            }
            else
            {
                return "无期限";
            }
        }
        
        private string GetZJ(int id) {
            BLL.card_type bllct = new BLL.card_type();
            return bllct.GetModel(id).ct_name;
        }

        private string GetState(int id)
        {
            BLL.memberState bllms = new BLL.memberState();
            Model.memberState models = bllms.GetModel(id);
            if (models != null)
            {
                return models.title;
            }
            return "";
        }

        private string GetTypeName(int id) {
            BLL.memberType bllmt = new BLL.memberType();
            if (id == 0) {
                return "";
            }
            return bllmt.GetModel(id).TypeName;
        }

        int sumjf = 0;//总积分
        int duihua = 0;//兑换积分
        int shengyu = 0;//剩余积分
        int dongjie = 0;//冻结积分
        int czsum = 0;//总存储值
        int xfsum = 0;//消费储值
        int czyue = 0;//储值谫
        int xfnum = 0;//消费次数
        int xfall = 0;//消费金额
        BLL.mRecords bllmr = new BLL.mRecords();
        #region 获得总积分等等
        /// <summary>
        /// 获得总积分
        /// </summary>
        private void GetSumJf(string mid)
        {
            List<Model.mRecords> listmr = bllmr.GetModelList("mmid='" + mid + "'");
            if (listmr.Count > 0)
            {
                foreach (Model.mRecords model in listmr)
                {
                    if (model.Type == 1) //
                    {
                        czsum += Convert.ToInt32(model.Price);
                    }
                    if (model.Type == 2)
                    {
                        xfsum += Convert.ToInt32(model.Price);
                        xfnum++;
                    }
                    if (model.Type == 3)
                    {
                        sumjf += Convert.ToInt32(model.Price);
                    }
                    if (model.Type == 4)
                    {
                        duihua += Convert.ToInt32(model.Price);
                    }
                }

                czyue = czsum - xfsum;
                shengyu = sumjf - duihua;
            }
        }
        #endregion

        JavaScriptSerializer js1 = new JavaScriptSerializer();
        //获得所有的会员列表
        private void Ggetallm()
        {
            string where = string.Empty;
            
            if (context.Request.QueryString["where"] != null) {
                where = context.Request.QueryString["where"];

            }
            List<Model.member> listme = bllme.GetModelList("Mid like '%" + where + "%' or Name like '%" + where + "%' or Phone like '%" + where + "%' or ZjNumber like '%" + where + "%'");
            listme = listme.Where(d => d.Statid == 0).ToList();
            List<Model.member> listm = listme.Where(d => d.Mid == where).ToList();
            if (listme.Count > 0)
            {

                string str = js1.Serialize(listme);
                Common.AjaxMsgHelper.AjaxMsg1("ok", listm.Count.ToString(), str, "");
                context.Response.End();
            }
            else {
                Common.AjaxMsgHelper.AjaxMsg("err", listm.Count.ToString(), "", "");
                context.Response.End();
            }
        }

        private void GetPirceAddJf() {

            int sk = Convert.ToInt32(context.Request.QueryString["sk"]);
            bool zf = true;
            if (sk < 0) {
                sk = sk * -1;
                zf = false;
            }
            int id = Convert.ToInt32(context.Request.QueryString["id"]);
            if (context.Request.QueryString["id"] != null)
            {
                Model.memberType modelmt = bllmt.GetModel(id);
                string isfee = context.Request.QueryString["NoCardFee"];//是否免卡费
                List<Model.AddPrice> listapp = bllap.GetModelList("AddPice<=" + sk + " order by AddPice desc");
                int cz = 0;
                if (isfee == "not")
                {
                    cz = sk;
                }
                else
                {
                    if (isfee == "1")
                    {
                        cz = sk;
                    }
                    else
                    {
                        cz = sk - Convert.ToInt32(modelmt.typePrice);
                    }
                }
                int zs = 0;
                int zsjf = 0;
                if (listapp.Count > 0)
                {
                    //
                    //zsjf = ;
                    int num = Convert.ToInt32(cz) / Convert.ToInt32(listapp[0].AddPice);
                    for (int i = 0; i < num; i++)
                    {
                        zs = Convert.ToInt32(listapp[0].ZsPice);
                        cz += zs;
                        zsjf += Convert.ToInt32(listapp[0].ZsJf);
                    }
                }
                if (!zf) {
                    cz = cz * -1;
                    zsjf = zsjf * -1;
                }

                JavaScriptSerializer js = new JavaScriptSerializer();
                var obj = new { cz = cz, zsjf = zsjf };
                string str = js.Serialize(obj);
                context.Response.Write(str);
            }
            else { 
                 
            }
        }

        //卡号是否可以用
        private void Isok()
        {
            string num = context.Request.QueryString["num"];
            if (bllme.GetModelList("Mid='" + num + "'").Count > 0)
            {
                context.Response.Write("ok");
            }
            else {
                context.Response.Write("err");
            }
            context.Response.End();
        }

        BLL.member bllme = new BLL.member();
        BLL.memberType bllmt = new BLL.memberType();
        BLL.AddPrice bllap = new BLL.AddPrice();
        private void Getprice()
        {
            int id = Convert.ToInt32(context.Request.QueryString["id"]);
            Model.memberType modelmt = bllmt.GetModel(id);
            int cardPice = Convert.ToInt32(modelmt.typePrice);//卡费用
            int xfprice = Convert.ToInt32(modelmt.XfPrice);//消费多少钱
            int XfConsump = Convert.ToInt32(modelmt.XfConsump);//多少积分
            int defaulprice = Convert.ToInt32(modelmt.StaPrice);
            int sk = cardPice;
            int cz = defaulprice;
            int jf = 0;
            if (modelmt.IsDeaflut) { //开卡时有默认金额
                sk += defaulprice;
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            var obj = new { sk = sk, cz = cz, jf = jf, cardPice = cardPice };
            string str = js.Serialize(obj);
            context.Response.Write(str);
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