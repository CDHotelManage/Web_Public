using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Data;
namespace CdHotelManage.Web.Admin.Ajax
{
    /// <summary>
    /// customer 的摘要说明
    /// </summary>
    public class customer : IHttpHandler
    {

        HttpContext context = null;
        public void ProcessRequest(HttpContext context)
        {
            this.context = context;
            string type = context.Request.QueryString["type"];
            switch (type)
            {
                case "scusto":
                    Scusto();
                    break;
                case "IsChild":
                    IsChild();
                    break;
                case "getpice":
                    Getpice();
                    break;
                case "GetAccount":
                    AccountS();
                    break;
                case "chexiao":
                    Chexiao();
                    break;
                case "upYaj":
                    UpYaj();
                    break;
                case "upJie":
                    UpJie();
                    break;
                case "uptr":
                    Uptr();
                    break;
                case "iscz":
                    iscz();
                    break;
                case "isDel":
                    isDel();
                    break;
                default:
                    break;
            }
        }

        private void isDel()
        {
            int id = Convert.ToInt32(context.Request.QueryString["id"]);
            BLL.goods_account bllga = new BLL.goods_account();
            List<Model.goods_account> listga = bllga.GetModelList1("ga_zffs_id=" + id);
            if (listga.Count > 0)
            {
                context.Response.Write("err");

            }
            else {
                bllmp.Delete(id);
                context.Response.Write("ok");
            }
        }

        private void iscz()
        {
            string txt = context.Request.QueryString["txt"];
            List<Model.meth_pay> listme = bllmp.GetModelList("meth_pay_name='" + txt + "'");
            if (listme.Count > 0)
            {
                context.Response.Write("err");
             }
            else {
                context.Response.Write("ok");
            }
        }
        BLL.meth_pay bllmp = new BLL.meth_pay();
        /// <summary>
        /// 更新支付方式整行
        /// </summary>
        private void Uptr()
        {
            
            int id = Convert.ToInt32(context.Request.QueryString["id"]);
            string txt = context.Request.QueryString["txt"];
            int sort = Convert.ToInt32(context.Request.QueryString["sort"]);
            string remark = context.Request.QueryString["remark"];
            Model.meth_pay modelmp = new Model.meth_pay();
            if (id!= 0) {
                modelmp.meth_pay_id = id;
            }
            modelmp.meth_sort = sort;
            modelmp.remark = remark;
            modelmp.meth_pay_name = txt;
            if (id == 0) {
                int rel=bllmp.Add(modelmp);
                if (rel > 0)
                {
                    context.Response.Write(rel);
                    context.Response.End();
                }
            }
            else if (!bllmp.Update(modelmp))
            {
                context.Response.Write("err");
            }
        }

        private void UpJie()
        {
            BLL.meth_pay bllmp = new BLL.meth_pay();
            int id = Convert.ToInt32(context.Request.QueryString["id"]);
            Model.meth_pay modelmp = bllmp.GetModel(id);
            if (modelmp.meth_is_jie)
            {
                modelmp.meth_is_jie = false;
            }
            else
            {
                modelmp.meth_is_jie = true;
            }
            if (!bllmp.Update(modelmp))
            {
                context.Response.Write("err");
            }
        }

        private void UpYaj()
        {
            BLL.meth_pay bllmp = new BLL.meth_pay();
            int id = Convert.ToInt32(context.Request.QueryString["id"]);
            Model.meth_pay modelmp = bllmp.GetModel(id);
            if (modelmp.meth_is_ya)
            {
                modelmp.meth_is_ya = false;
            }
            else {
                modelmp.meth_is_ya = true;
            }
            if (!bllmp.Update(modelmp)) {
                context.Response.Write("err");
            }
        }

        private void Chexiao()
        {
            try
            {
                string ids = context.Request.QueryString["ids"];
                string account = context.Request.QueryString["account"];
                string[] idstr = ids.Split(',');
                string idss = string.Empty;
                if (idstr.Length == 1)
                {
                    idss = "'" + ids + "'";
                }
                else if (idstr.Length > 1)
                {
                    foreach (string item in idstr)
                    {
                        ids += "'" + item + "',";
                    }
                    idss = ids.Substring(0, ids.Length - 1);
                }

                List<Model.goods_account> listag = bllga.GetModelList1("ga_goodNo in (" + idss + ") and ga_Account='" + account + "' and ga_Type=203");
                if (listag.Count > 0)
                {
                    foreach (Model.goods_account item in listag)
                    {
                        item.ga_Type = 204;
                        bllga.Update(item);
                    }
                }
                context.Response.Write("ok");
                context.Response.End();
            }
            catch (Exception ex)
            {
                context.Response.Write("err");
                context.Response.End();
            }
        }

        BLL.account_goods bllag = new BLL.account_goods();
        BLL.goods_account bllga = new BLL.goods_account();
        /// <summary>
        /// 获得所有的帐单信息
        /// </summary>
        private void AccountS()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            string account = context.Request.QueryString["account"];
            int readvalue = Convert.ToInt32(context.Request.QueryString["readValue"]);
            string where = string.Empty;
            List<Model.goods_account> listag = bllga.GetModelList1("ga_Account='" + account + "' and ga_Type=" + readvalue);
            System.Text.StringBuilder sbtext = new System.Text.StringBuilder();
            sbtext.Append("<table cellpadding=\"0\" cellspacing=\"0\" class=\"vip_member\" id=\"tblgood\" style=\"width: 100%\">");
            if (readvalue == 201)
            {
                sbtext.Append("<tr><th width=\"5%\">选择</th><th width=\"7%\">发生时间</th><th width=\"7%\">帐号</th><th width=\"10%\">客户名称</th><th width=\"7%\">房间号</th><th width=\"8%\">费用名称</th><th width=\"8%\">金额</th><th width=\"8%\">支付方式</th><th width=\"5%\">单据号</th><th width=\"7%\">备注</th><th width=\"7%\">操作人</th></tr>");
            }
            else if (readvalue == 202)
            {
                sbtext.Append("<tr><th width=\"5%\">选择</th><th width=\"7%\">发生时间</th><th width=\"7%\">帐号</th><th width=\"10%\">客户名称</th><th width=\"7%\">房间号</th><th width=\"8%\">费用名称</th><th width=\"8%\">支付方式</th><th width=\"8%\">金额</th><th width=\"5%\">单据号</th><th width=\"7%\">备注</th><th width=\"7%\">操作人</th></tr>");
            }
            //else if (readvalue == 203)
            //{
            //    sbtext.Append("<tr><th width=\"5%\">选择</th><th width=\"7%\">发生时间</th><th width=\"7%\">帐号</th><th width=\"10%\">客户名称</th><th width=\"7%\">房间号</th><th width=\"8%\">费用名称</th><th width=\"8%\">金额</th><th width=\"5%\">单据号</th><th width=\"7%\">备注</th><th width=\"7%\">操作人</th></tr>");
            //}
            else if (readvalue == 203)
            {
                sbtext.Append("<tr><th width=\"5%\">选择</th><th width=\"7%\">发生时间</th><th width=\"7%\">帐号</th><th width=\"10%\">客户名称</th><th width=\"7%\">房间号</th><th width=\"8%\">结算方式</th><th width=\"8%\">金额</th><th width=\"5%\">单据号</th><th width=\"7%\">备注</th><th width=\"7%\">操作人</th></tr>");
                string sql = "select ga_goodNo from goods_account where ga_Type=" + readvalue + " and ga_Account='" + account + "' group by ga_goodNo";
                DataTable dt = bllga.GetDsBySql(sql);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        string goodNo = dr[0].ToString();
                        if (!dic.ContainsKey(goodNo))
                        {
                            dic.Add(goodNo, "ok");

                            List<Model.goods_account> listga = bllga.GetModelList1("ga_goodNo='" + goodNo + "' and ga_Account='" + account + "'");
                            sbtext.Append("<tr><td width=\"5%\"><input type=\"checkbox\" class=\"chk\"/><input type=\"hidden\" value=" + goodNo + " class=\"ids\"/></td><td width=\"7%\">" + listga[0].ga_date + "</td><td width=\"7%\">" + listga[0].Ga_Account + "</td><td width=\"10%\">" + GetName(listga[0].Ga_Account) + "</td><td width=\"7%\">" + listga[0].ga_roomNumber + "</td><td width=\"8%\">" + GetJsfs(listga[0].ga_jsfs) + "</td><td width=\"8%\">" + GetSumPrice(goodNo, account, readvalue) + "</td><td width=\"5%\"><a onclick=\"ListBook(this,'" + listga[0].ga_occuid + "','" + goodNo + "')\">" + goodNo + "</a></td><td width=\"7%\">" + listga[0].ga_remker + "</td><td width=\"7%\">" + GetUserName(listga[0].ga_people) + "</td></tr>");
                        }
                    }
                }
            }
            else if (readvalue == 204)
            {
                sbtext.Append("<tr><th width=\"5%\">选择</th><th width=\"7%\">发生时间</th><th width=\"7%\">帐号</th><th width=\"10%\">客户名称</th><th width=\"7%\">房间号</th><th width=\"8%\">金额</th><th width=\"5%\">单据号</th><th width=\"7%\">备注</th><th width=\"7%\">操作人</th><th width=\"7%\">操作</th></tr>");
                string sql = "select ga_goodNo from goods_account where ga_Type=" + readvalue + " and ga_Account='" + account + "' group by ga_goodNo";
                DataTable dt = bllga.GetDsBySql(sql);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        string goodNo = dr[0].ToString();
                        if (!dic.ContainsKey(goodNo))
                        {
                            dic.Add(goodNo, "ok");

                            List<Model.goods_account> listga = bllga.GetModelList1("ga_goodNo='" + goodNo + "' and ga_Account='" + account + "'");
                            string sumprice=GetSumPrice(goodNo, account, readvalue);
                            sbtext.Append("<tr><td width=\"5%\"><input type=\"checkbox\" class=\"chk\"/><input type=\"hidden\" value=" + goodNo + " class=\"ids\"/></td><td width=\"7%\">" + listga[0].ga_date + "</td><td width=\"7%\">" + listga[0].Ga_Account + "</td><td width=\"10%\">" + GetName(listga[0].Ga_Account) + "</td><td width=\"7%\">" + listga[0].ga_roomNumber + "</td><td width=\"8%\">" + sumprice + "</td><td width=\"5%\"><a onclick=\"ListBook(this,'" + listga[0].ga_occuid + "','" + goodNo + "')\">" + goodNo + "</a></td><td width=\"7%\">" + listga[0].ga_remker + "</td><td width=\"7%\">" + GetUserName(listga[0].ga_people) + "</td>" + GetStr(Convert.ToDecimal(sumprice), goodNo, listga[0].Ga_Account, listga[0].ga_occuid) + "</tr>");
                        }
                    }
                }
            }
            if (listag.Count > 0)
            {
                foreach (Model.goods_account item in listag)
                {
                    if (readvalue == 201)
                    {
                        sbtext.Append("<tr><td width=\"5%\"><input type=\"checkbox\" class=\"chk\"/><input type=\"hidden\" value=" + item.id + " class=\"ids\"/></td><td width=\"7%\">" + item.ga_date.ToString() + "</td><td width=\"7%\">" + item.Ga_Account + "</td><td width=\"10%\">" + GetName(item.Ga_Account) + "</td><td width=\"7%\">" + item.ga_roomNumber + "</td><td width=\"8%\">" + item.ga_name + "</td><td width=\"8%\">" + item.ga_price + "</td><td width=\"8%\">" + GetMethPay(Convert.ToInt32(item.ga_zffs_id)) + "</td><td width=\"5%\">" + item.ga_number + "</td><td width=\"7%\">" + item.ga_remker + "</td><td width=\"7%\">" + GetUserName(item.ga_people) + "</td></tr>");
                    }
                    else if (readvalue == 202)
                    {
                        sbtext.Append("<tr><td width=\"5%\"><input type=\"checkbox\" class=\"chk\"/><input type=\"hidden\" value=" + item.id + " class=\"ids\"/></td><td width=\"7%\">" + item.ga_date.ToString() + "</td><td width=\"7%\">" + item.Ga_Account + "</td><td width=\"10%\">" + GetName(item.Ga_Account) + "</td><td width=\"7%\">" + item.ga_roomNumber + "</td><td width=\"8%\">" + item.ga_name + "</td><td width=\"8%\">" + GetMethPay(Convert.ToInt32(item.ga_zffs_id)) + "</td><td width=\"8%\">" + item.ga_price + "</td><td width=\"5%\">" + item.ga_number + "</td><td width=\"7%\">" + item.ga_remker + "</td><td width=\"7%\">" + GetUserName(item.ga_people) + "</td></tr>");
                    }
                    //else if ( readvalue == 203)
                    //{
                    //    sbtext.Append("<tr><td width=\"5%\"><input type=\"checkbox\" class=\"chk\"/><input type=\"hidden\" value=" + item.id + " class=\"ids\"/></td><td width=\"7%\">" + item.ga_date.ToString() + "</td><td width=\"7%\">" + item.Ga_Account + "</td><td width=\"10%\">" + GetName(item.Ga_Account) + "</td><td width=\"7%\">" + item.ga_roomNumber + "</td><td width=\"8%\">" + item.ga_name + "</td><td width=\"8%\">" + item.ga_sum_price + "</td><td width=\"5%\">" + item.ga_number + "</td><td width=\"7%\">" + item.ga_remker + "</td><td width=\"7%\">" + GetUserName(item.ga_people) + "</td></tr>");
                    //}
                }
            }
            sbtext.Append("</table>");
            if (listag.Count <= 0)
            {
                sbtext.Append("<table><tr><td><span style=\"color:red\">暂无记录！</span></td></tr></table>");
            }
            context.Response.Write(sbtext.ToString());
            context.Response.End();
        }

        private string GetStr(decimal price,string goodNo, string Ga_Account, string ga_occuid)
        {
            if (price > 0)
            {
                return "<td><a onclick='Cz(\"" + goodNo + "\",\"" + Ga_Account + "\",\"" + ga_occuid + "\")'>冲帐</a></td>";
            }
            else {
                return "<td></td>";
            }
        }

        private string GetSumPrice(string Goodno,string account,int type) {
            decimal sum = 0;
            List<Model.goods_account> listga = bllga.GetModelList1("ga_goodNo='" + Goodno + "' and ga_Account='" + account + "' and ga_Type='" + type + "'");
            if (listga.Count > 0)
            {
                foreach (Model.goods_account model in listga)
                {
                    sum += Convert.ToDecimal(model.ga_sum_price);
                }
            }
            return sum.ToString();
        }

        private string GetJsfs(int id) {
            if (id == 0) {

                return "扣款结算";
            }
            return "收款结算";
        }

        private string GetUserName(string id) {
            BLL.AccountsUsersBLL blluser = new BLL.AccountsUsersBLL();
            return blluser.GetModel(id).UserName;
        }

        private string GetMethPay(int id) {
            BLL.meth_pay bllmp = new BLL.meth_pay();
            Model.meth_pay modelmp = bllmp.GetModel(id);
            return modelmp.meth_pay_name;
        }

        BLL.customer bllcon = new BLL.customer();
        protected string GetName(string acc)
        {
            return bllcon.GetAccounts(acc).cName;
        }
        /// <summary>
        /// 通过方案获得各房型价格
        /// </summary>
        private void Getpice()
        {
            //int ids = Convert.ToInt32(context.Request.QueryString["ids"]);
            //Model.cprotocol modelcp = bllcp.GetModel(ids);
            //if (!modelcp.Isdiscount) { 
               
            //}
        }

        BLL.cprotocol bllcp = new BLL.cprotocol();

        /// <summary>
        /// 查询是否有多个
        /// </summary>
        private void IsChild()
        {
            string accounts = context.Request.QueryString["accounts"];
            List<Model.cprotocol> listcpo = bllcpo.GetModelList("Accounts='" + accounts + "'");
            if (listcpo.Count > 0)
            {
                string str = js.Serialize(listcpo);
                Common.AjaxMsgHelper.AjaxMsg1("ok", "", str, "");
            }
            else {
                Model.customer modelcus = bllcus.GetAccounts(accounts);
                string str = js.Serialize(modelcus);
                Common.AjaxMsgHelper.AjaxMsg1("err", "", str, "");
            }   

        }
        BLL.cprotocol bllcpo = new BLL.cprotocol();

        BLL.customer bllcus = new BLL.customer();
        JavaScriptSerializer js = new JavaScriptSerializer();
        /// <summary>
        /// 查询客户信息
        /// </summary>
        private void Scusto()
        {
            string txt = context.Request.QueryString["txt"];
            List<Model.customer> listcus = bllcus.GetModelList("accounts like '%" + txt + "%' or cName like '%" + txt + "%'");
            if (listcus.Count > 0)
            {
                string strs = js.Serialize(listcus);
                Common.AjaxMsgHelper.AjaxMsg1("ok", "", strs, "");
            }
            else { 
            
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