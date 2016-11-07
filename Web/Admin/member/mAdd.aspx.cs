using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.member
{
    public partial class mAdd : BasePageVaile
    {
        BLL.memberType bllmt = new BLL.memberType();
        BLL.member bll = new BLL.member();
        public override void SonLoad()
        {
            if (!IsPostBack)
            {
                Hide();
                Bindzj();
                BindCategoryId();
                BindMethPay();
                string type = Request.QueryString["type"];
                switch (type)
                {
                    case "add":
                        Add();
                        break;
                    case "edit":
                        Edit();
                        break;
                    default:
                        break;
                }
            }
      }

        private void Edit()
        {
            ShowFee.Style.Add("display", "none");
            CAdd.Style.Add("display", "none");
            ShowMd.Style.Add("display", "none");
            divfa.InnerText = "编辑会员";
            BtnSave.Value = "更新会员";
            string id=Request.QueryString["id"];
            Model.member modelmen= bll.GetModel(id);
            CCardNo.InnerText = modelmen.Mid.ToString();
            MemberCardNo.Value = modelmen.Mid.ToString();
            GetSumJf(modelmen.Mid.ToString());
            Name.Value = modelmen.Name;
            Sex.SelectedValue = modelmen.Sex == true ? "1" : "0";
            CardType.SelectedValue = modelmen.Zjtype.ToString();
            CardNo.Value = modelmen.ZjNumber;
            CategoryId.SelectedValue = modelmen.Mtype.ToString();
            Phone.Value = modelmen.Phone;
            BirthDay.Value = modelmen.Baithday.ToString();
            Password.Attributes.Add("value",modelmen.Pwd);
            Love.Value = modelmen.Likes;
            Address.Value = modelmen.Address;
            Remark.Value = modelmen.Ramrek;
            OpenDate.InnerText = Convert.ToDateTime(modelmen.AddDate).ToString("yyyy-MM-dd");
            Model.memberType modelty = bllmt.GetModel(Convert.ToInt32(modelmen.Mtype));
            ExprieDate.InnerText = Convert.ToDateTime(modelmen.XqTime).ToString("yyyy-MM-dd");
            StatusName.InnerText = GetState(Convert.ToInt32(modelmen.Statid));
            TotalScore.InnerText = sumjf.ToString();
            UsedScore.InnerHtml = duihua.ToString();
            UsableScore.InnerHtml = shengyu.ToString();
            FrozenScore.InnerHtml = dongjie.ToString();
            TotalAmount.InnerHtml = czsum.ToString();
            UsedAmount.InnerHtml = xfsum.ToString();
            UsableAmount.InnerHtml = czyue.ToString();
            ConsumeTimes.InnerHtml = xfnum.ToString();
            ConsumeAmount.InnerHtml = xfall.ToString();
        }

        BLL.meth_pay bllmp = new BLL.meth_pay();
        private void BindMethPay() {
            PayMethod.DataSource = bllmp.GetAllList();
            PayMethod.DataTextField = "meth_pay_name";
            PayMethod.DataValueField = "meth_pay_id";
            PayMethod.DataBind();
        }

        private string GetState(int id) {
            BLL.memberState bllms = new BLL.memberState();
            Model.memberState models= bllms.GetModel(id);
            if (models != null) {
                return models.title;
            }
            return "";
        }

        private void BindCategoryId() {
            
            CategoryId.DataSource = bllmt.GetAllList();
            CategoryId.DataTextField = "TypeName";
            CategoryId.DataValueField = "MtID";
            CategoryId.DataBind();
            CategoryId.Items.Insert(0, new ListItem("请选择", "0"));
        }

        private void Bindzj() {
            BLL.card_type bllct = new BLL.card_type();
            CardType.DataSource = bllct.GetAllList();
            CardType.DataTextField = "ct_name";
            CardType.DataValueField = "id";
            CardType.DataBind();
        }

        private void Hide() {
            btnSearch.Style.Add("display", "none");
            btnReadCard.Style.Add("display", "none");
            btnWriteCard.Style.Add("display", "none");
            btnClearCard.Style.Add("display", "none");
        }

        private void Add() {
            btnSearch.Style.Add("display", "block");
            showDiv.Style.Add("display", "none");
            CEdit.Style.Add("display", "none");
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
                    if(model.Type==2)
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


        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSave_Click(object sender, EventArgs e) {
            Model.member bllmem = new Model.member();
            bllmem.Mid = MemberCardNo.Value;
            bllmem.Name = Name.Value;
            bllmem.Mtype = Convert.ToInt32(CategoryId.SelectedValue);
            bllmem.Sex = Convert.ToBoolean( Convert.ToInt32(Sex.SelectedValue));
            bllmem.Zjtype = Convert.ToInt32(CardType.SelectedValue);
            bllmem.ZjNumber = CardNo.Value;
            bllmem.sales = 0;
            bllmem.Phone = Phone.Value;
            if (BirthDay.Value == "")
            {
                bllmem.Baithday = null;
            }
            else
            {
                bllmem.Baithday = Convert.ToDateTime(BirthDay.Value);
            }
            bllmem.Pwd = Password.Text;
            bllmem.Likes = Love.Value;
            bllmem.Address = Address.Value;
            bllmem.Ramrek = Remark.Value;
            bllmem.AddUser = UserNow.UserID;
            if (Request.Form["GiveScore"] == "")
            {
                bllmem.Integration = 0;
            }
            else {
                bllmem.Integration = Convert.ToInt32(Request.Form["GiveScore"]);
            }
            bllmem.Statid = 0;
            
            if (Request.QueryString["type"] == "edit") {
                bllmem.Mid = Request.QueryString["id"];
                bllmem.AddDate = bll.GetModel(bllmem.Mid).AddDate;
                bllmem.XqTime = bll.GetModel(bllmem.Mid).XqTime;
                if (bll.Update(bllmem)) {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('更新成功');parent.window.location.reload();</script>");
                }
            }
            else
            {
                bllmem.IntegraDj = Convert.ToInt32(NoCardFee.Checked);
                bllmem.AddDate = DateTime.Now;
                if (bll.Add(bllmem))
                {
                    Model.memberType modelmt = bllmt.GetModel(Convert.ToInt32(bllmem.Mtype));
                    bllmem.XqTime = modelmt.XqTime;
                    bll.Update(bllmem);
                    Model.mRecords modemr = new Model.mRecords();
                    modemr.mmid = bllmem.Mid;
                    modemr.Price = Convert.ToInt32(Request.Form["TopAmount"].ToString());
                    modemr.Type = 1;
                    modemr.Remark = "";
                    bllmr.Add(modemr);
                    Model.mRecords modemrjf = new Model.mRecords();
                    modemrjf.mmid = bllmem.Mid;
                    if (Request.Form["GiveScore"] == "")
                    {
                        modemrjf.Price = 0;
                    }
                    else
                    {
                        modemrjf.Price = Convert.ToInt32(Request.Form["GiveScore"]);
                    }
                    modemrjf.Type = 3;
                    modemrjf.Remark = "";
                    bllmr.Add(modemrjf);
                    int Amount = Convert.ToInt32(Request.Form["Amount"]);
                    BC(Amount);
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('保存成功');parent.window.location.reload();</script>");
                }
            }

           
        }
        BLL.mRecords bllmr = new BLL.mRecords();


        private void BC(decimal dce) {
            Model.goods_account modelga = new Model.goods_account();
            modelga.ga_name = "会员收款";
            modelga.ga_price = dce;
            modelga.ga_zffs_id = Convert.ToInt32(PayMethod.SelectedValue);
            modelga.ga_date = DateTime.Now;
            modelga.ga_people = UserNow.UserID;
            modelga.ga_Type = 21;
            modelga.ga_isjz = 0;
            modelga.ga_isys = 0;
            bllga.Add(modelga);
        }
        BLL.goods_account bllga = new BLL.goods_account();
    }
}