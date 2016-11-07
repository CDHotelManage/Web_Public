using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace CdHotelManage.Web.Admin.customer
{
    public partial class addProtocol : BasePage
    {
       
        private void BindPtype() {
            BLL.cpType bllct = new BLL.cpType();
            pType.DataSource = bllct.GetModelList("");
            pType.DataTextField = "ptName";
            pType.DataValueField = "ID";
            pType.DataBind();
        }
        BLL.cprotocol bllcp = new BLL.cprotocol();
        BLL.customer bllcus = new BLL.customer();
        private void Bind(string account)
        {
            Accounts.InnerText = account;
            Model.customer model = bllcus.GetAccounts(account);
            if (model != null) {
                cusDesy.InnerText = model.cusDesy;
            }
        }

        protected void bus_add_Click(object sender,EventArgs e) {
            Model.cprotocol modelcp = new Model.cprotocol();
            modelcp.Accounts = accountst.Value;
            modelcp.Ptheme = Ptheme.Value;
            modelcp.pType = Convert.ToInt32(pType.SelectedValue);
            modelcp.PNumber = PNumber.Value;
            modelcp.ishire = ishire.Checked;
            modelcp.term = Convert.ToDateTime(term.Value);
            modelcp.companysignatory = companysignatory.Value;
            if (period.Value == "") {
                modelcp.period = Convert.ToDateTime(DateTime.Now);
            }
            else
            {
                modelcp.period = Convert.ToDateTime(period.Value);
            }
            if (breakfast.Value == "")
            {
                modelcp.breakfast = 0;
            }
            else
            {
                modelcp.breakfast = Convert.ToInt32(breakfast.Value);
            }
            if (Commission.Value == "") {
                modelcp.Commission = 0;
            }
            else
            {
                modelcp.Commission = Convert.ToInt32(Commission.Value);
            }
            modelcp.discount = Convert.ToDecimal(discount.Value);
            modelcp.Dayhire = Dayhire.Checked;
            modelcp.prohire = prohire.Checked;
            modelcp.signatory = signatory.Value;
            modelcp.roomNumber = roomNumber.Value;
            modelcp.Isdiscount = Isdiscount.Checked;
            modelcp.Remark = Remark.Value;
            modelcp.editUser =UserNow.UserID;
            modelcp.Details = Details.Value;
            if (Request.QueryString["type"] == "add") {
                int resl=bllcp.Add(modelcp);
                if (resl > 0) {
                    AddPrice(modelcp.Accounts, resl);
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('新增成功');parent.window.location.reload();</script>");
                }
            }
            else if (Request.QueryString["type"] == "edit") { 
                int id = Convert.ToInt32(Request.QueryString["id"]);
                modelcp.ID = id;
                if (bllcp.Update(modelcp)) {
                    AddPrice(modelcp.Accounts, id);
                    
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript'>alert('更新成功');parent.window.location.reload();</script>");
                }
            }
        }

        private void AddPrice(string acc,int pid) {
            if (Request["Isdiscount"] != null)
            {

            }
            else { 
            bllcprice.DeleteWhere("delete from cprotocolPrice where Accounts='" + acc + "' and cpID=" + pid);
            }
            string html = htmls.Value;
            string[] strs = html.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in strs)
            {
                string[] slist = s.Split(new char[1] { '#' }, StringSplitOptions.RemoveEmptyEntries);
                string RoomType = slist[0];
                string Price = slist[1];
                string zdPrice = slist[2];
                string protoPrice = slist[3];
                string mothPrice = slist[4];
                string commission = slist[5];
                Model.cprotocolPrice modelcp1 = new Model.cprotocolPrice();
                modelcp1.Accounts = acc;
                modelcp1.RoomType = Convert.ToInt32(RoomType);
                modelcp1.Price = Convert.ToInt32(Price);
                modelcp1.protoPrice = Convert.ToInt32(protoPrice);
                modelcp1.mothPrice = Convert.ToInt32(mothPrice);
                modelcp1.zdPrice = float.Parse(zdPrice);
                modelcp1.commission = Convert.ToInt32(commission);
                modelcp1.Breakfast = 0;
                modelcp1.CpID = pid;
                bllcprice.Add(modelcp1);
            }
        }

        BLL.cprotocolPrice bllcprice = new BLL.cprotocolPrice();
        protected System.Text.StringBuilder sbPrice = new System.Text.StringBuilder();

        public override void SonLoad()
        {
            if (!IsPostBack)
            {
                string accounts = Request.QueryString["accounts"];
                term.Value = DateTime.Now.ToString();
                accountst.Value = accounts;
                Bind(accounts);
                BindPtype();
                BLL.room_type bllrt = new BLL.room_type();
                if (Request.QueryString["type"] == "edit")//编辑
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    BindInfo(id);
                    BLL.cprotocolPrice bllcprice=new BLL.cprotocolPrice();
                    rep1.DataSource = bllcprice.GetModelList("Accounts='" + accounts + "' and cpID=" + id);
                    rep1.DataBind();
                }
                else { //添加
                    List<Model.room_type> listrt1 = bllrt.GetModelList("");
                    foreach (Model.room_type item in listrt1)
                    {
                        sbPrice.Append("<tr>");
                        sbPrice.Append("<td width=\"15%\" typeid='" + item.id + "' class=\"roomType\">" + item.room_name + "</td>");
                        sbPrice.Append("<td width=\"15%\" class=\"Price\">" + Convert.ToDecimal(item.room_listedmoney).ToString("0.##") + "</td>");
                        sbPrice.Append("<td width=\"15%\" class=\"zdPrice\">1</td>");
                        sbPrice.Append("<td width=\"15%\" class=\"protoPrice\">" + Convert.ToDecimal(item.room_listedmoney).ToString("0.##") + "</td>");
                        sbPrice.Append("<td width=\"15%\" class=\"mothPrice\">" + Convert.ToDecimal(item.Room_Moth_price).ToString("0.##") + "</td>");
                        sbPrice.Append("<td width=\"15%\" class=\"commission\">0</td>");
                        sbPrice.Append("<td width=\"16%\" ><a href=\"#\" onclick=\"RowEdit(this)\"><img src=\"../images/037.gif\" width=\"10\" height=\"10\" ></a><a href=\"#\"onclick=\"RowDelete(this)\"><img src=\"../images/010.gif\" width=\"10\" height=\"10\" ></a></td>");
                        sbPrice.Append("</tr>");
                    }
                }

                
                List<Model.room_type> listrt = bllrt.GetModelList("");
                foreach (Model.room_type item in listrt)
                {
                    sbtext.Append("<option value='" + item.id + "'>" + item.room_name + "</option>");


                    //Model.mtPrice modelmt = new Model.mtPrice();
                    //modelmt.RoomType = item.id;
                    //modelmt.zdPrice = 1;
                    //modelmt.Price = Convert.ToInt32(item.room_listedmoney);
                    //modelmt.Dayprice = Convert.ToInt32(item.room_listedmoney);
                    //modelmt.lcPrice = Convert.ToInt32(item.room_listedmoney);
                    //BLL.mtPrice bllm = new BLL.mtPrice();
                    //bllm.Add(modelmt);



                }

            }
        }

        protected System.Text.StringBuilder sbtext = new System.Text.StringBuilder();
        private void BindInfo(int id) {
            Model.cprotocol modelcp = bllcp.GetModel(id);
            Ptheme.Value = modelcp.Ptheme;
            pType.SelectedValue = modelcp.pType.ToString();
            PNumber.Value = modelcp.PNumber;
            term.Value = modelcp.term.ToString();
            period.Value = modelcp.period.ToString();
            breakfast.Value = modelcp.breakfast.ToString();
            Commission.Value = modelcp.Commission.ToString();
            signatory.Value = modelcp.signatory;
            companysignatory.Value = modelcp.companysignatory;
            roomNumber.Value = modelcp.roomNumber;
            discount.Value = modelcp.discount.ToString();
            Remark.Value = modelcp.Remark;
            ishire.Checked = modelcp.ishire;
            Dayhire.Checked = modelcp.Dayhire;
            prohire.Checked = modelcp.prohire;
            Isdiscount.Checked = modelcp.Isdiscount;
            Details.Value = modelcp.Details;
        }

        protected string Getyuan(int id) {
            BLL.room_type bllrt = new BLL.room_type();
            return bllrt.GetModel(id).room_name;
        }
    }
}