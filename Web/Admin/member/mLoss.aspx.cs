using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.member
{
    public partial class mLoss : BasePageVaile
    {
       

        /// <summary>
        /// 会员升级
        /// </summary>
        private void Lvup()
        {
            lal.InnerText = "会员升级";
            BtnSave.Value = "会员升级";
            hyck.Style.Add("display", "none");
            btnReadCard.Style.Add("display", "none");
            jftz.Style.Add("display", "none");
            xucard.Style.Add("display", "none");
            upCard.Style.Add("display", "none");
            lvup.Style.Add("display", "block");
        }

        /// <summary>
        /// 密码重新
        /// </summary>
        private void PwdResl()
        {
            lal.InnerText = "修改密码";
            BtnSave.Value = "修改密码";
            hyck.Style.Add("display", "none");
            btnReadCard.Style.Add("display", "none");
            jftz.Style.Add("display", "none");
            xucard.Style.Add("display", "none");
            upCard.Style.Add("display", "none");
            pwdResl.Style.Add("display", "block");
        }

        private void Tuicard()
        {
            lal.InnerText = "会员退卡";
            BtnSave.Value = "会员退卡";
            hyck.Style.Add("display", "none");
            btnReadCard.Style.Add("display", "none");
            jftz.Style.Add("display", "none");
            xucard.Style.Add("display", "none");
            upCard.Style.Add("display", "none");
            tuicard.Style.Add("display", "block");
        }

        /// <summary>
        /// 会员续卡
        /// </summary>
        private void Xucard()
        {
            lal.InnerText = "会员续卡";
            BtnSave.Value = "会员续卡";
            hyck.Style.Add("display", "none");
            btnReadCard.Style.Add("display", "none");
            jftz.Style.Add("display", "none");
            xucard.Style.Add("display", "block");
            upCard.Style.Add("display", "none");
        }


        /// <summary>
        /// 会员换卡
        /// </summary>
        private void CardUp()
        {
            lal.InnerText = "会员换卡";
            BtnSave.Value = "会员换卡";
            hyck.Style.Add("display", "none");
            btnReadCard.Style.Add("display", "none");
            jftz.Style.Add("display", "none");
            upCard.Style.Add("display", "block");
        }

        /// <summary>
        /// 挂失
        /// </summary>
        private void GuaShi()
        {
            lal.InnerText = "会员挂失";
            BtnSave.Value = "会员挂失";
            hyck.Style.Add("display", "none");
            btnReadCard.Style.Add("display", "none");
            jftz.Style.Add("display", "none");
            upCard.Style.Add("display", "none");
        }

        /// <summary>
        /// 积分调整
        /// </summary>
        private void jftz1()
        {
            hyck.Style.Add("display", "none");
            btnReadCard.Style.Add("display", "none");
            jftz.Style.Add("display", "block");
            upCard.Style.Add("display", "none");
            BtnSave.Value = "积分调整";
            lal.InnerText = "积分调整";
        }

        /// <summary>
        /// 会员冲值
        /// </summary>
        private void AddPrice()
        {
            upCard.Style.Add("display", "none");
            btnReadCard.Style.Add("display", "none");
            jftz.Style.Add("display", "none");
        }

        BLL.meth_pay bllmp = new BLL.meth_pay();
        private void BindMethPay()
        {
            PayMethod.DataSource = bllmp.GetAllList();
            PayMethod.DataTextField = "meth_pay_name";
            PayMethod.DataValueField = "meth_pay_id";
            PayMethod.DataBind();


            Paymethed1.DataSource = bllmp.GetAllList();
            Paymethed1.DataTextField = "meth_pay_name";
            Paymethed1.DataValueField = "meth_pay_id";
            Paymethed1.DataBind();

            DropDownList1.DataSource = bllmp.GetAllList();
            DropDownList1.DataTextField = "meth_pay_name";
            DropDownList1.DataValueField = "meth_pay_id";
            DropDownList1.DataBind();

            DropDownList2.DataSource = bllmp.GetAllList();
            DropDownList2.DataTextField = "meth_pay_name";
            DropDownList2.DataValueField = "meth_pay_id";
            DropDownList2.DataBind();
        }
        BLL.goods_account bllga = new BLL.goods_account();
        private void BC(decimal dce,string str,string paymath,int type)
        {
            Model.goods_account modelga = new Model.goods_account();
            modelga.ga_name = str;
            modelga.ga_price = dce;
            modelga.ga_zffs_id = Convert.ToInt32(paymath);
            modelga.ga_date = DateTime.Now;
            modelga.ga_people = UserNow.UserID;
            modelga.ga_Type = type;
            modelga.ga_isjz = 0;
            modelga.ga_isys = 0;
            bllga.Add(modelga);
        }
        //冲值保存
        protected void BtnSaveClick(object sender, EventArgs e) {
            if (Request.Form["mid"].ToString()!="")
            {
                if (BtnSave.Value == "会员充值")
                {
                    if (Request.Form["PaymentAmount"].ToString() != "")
                    {
                        int PaymentAmount = Convert.ToInt32(Request.Form["PaymentAmount"]);
                        int TopAmount = Convert.ToInt32(Request.Form["TopAmount"]);
                        int GiveScore = Convert.ToInt32(Request.Form["GiveScore"]);
                        Model.mRecords modelmr = new Model.mRecords();
                        modelmr.mmid = Request.Form["mid"];
                        modelmr.Price = TopAmount;
                        modelmr.Remark = "";
                        modelmr.Type = 1;
                        bllmr.Add(modelmr);
                        Model.mRecords modelmr1 = new Model.mRecords();
                        modelmr1.mmid = Request.Form["mid"];
                        modelmr1.Price = GiveScore;
                        modelmr1.Remark = "";
                        modelmr1.Type = 3;
                        bllmr.Add(modelmr1);
                        BC(TopAmount, "会员冲值收款", PayMethod.SelectedValue, 21);
                        ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('成功');parent.window.location.reload();</script>");
                    }
                    else {
                        ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('请输入正确的收款金额！！');</script>");
                    }
                }
                else if (BtnSave.Value == "积分调整")
                {
                    if (Request.Form["AdjustScore"].ToString() != "")
                    {
                        int AdjustScore = Convert.ToInt32(Request.Form["AdjustScore"]);
                        Model.mRecords modelmr = new Model.mRecords();
                        modelmr.mmid = Request.Form["mid"];
                        modelmr.Price = AdjustScore;
                        modelmr.Remark = "";
                        if (modelmr.Price > 0)
                        {
                            modelmr.Type = 3;
                        }
                        else
                        {
                            modelmr.Type = 4;
                            modelmr.Price = modelmr.Price * -1;
                        }

                        bllmr.Add(modelmr);
                        ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('成功');parent.window.location.reload();</script>");
                    }
                    else {
                        ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('请输入正确的积分!');</script>");
                    }
                }
                else if (BtnSave.Value == "会员挂失")
                {
                    string mid = Request.Form["mid"];
                    Model.member modelmen = bllmen.GetModel(mid);
                    modelmen.Statid = 2;
                    bllmen.Update(modelmen);
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('挂失成功');parent.window.location.reload();</script>");
                }
                else if (BtnSave.Value == "会员换卡")
                {
                    if (Request.Form["NewCard"].ToString() != "")
                    {
                        string mid = Request.Form["mid"];
                        string NewCard =Request.Form["NewCard"];
                        Model.member modelmen = bllmen.GetModel(NewCard);
                        if (modelmen != null)
                        {
                            ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('新卡号已经被使用！');parent.window.location.reload();</script>");
                        }
                        else
                        {
                            try
                            {
                                bllmen.Updates("update member set Mid=" + NewCard + " where Mid=" + mid + "");
                                List<Model.mRecords> listmr = bllmr.GetModelList("mmid='" + mid + "'");
                                if (listmr.Count > 0)
                                {
                                    foreach (Model.mRecords item in listmr)
                                    {
                                        item.mmid = NewCard;
                                        bllmr.Update(item);
                                    }
                                }
                                string pirc = Request.Form["CardPrice"];
                                if (pirc != "")
                                {
                                    BC(Convert.ToDecimal(pirc), "换卡收款", Paymethed1.SelectedValue, 21);
                                }
                                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('换卡成功！！');parent.window.location.reload();</script>");
                            }
                            catch (Exception)
                            {

                            }
                        }
                    }
                    else {
                        ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('请输入正确的卡号!');</script>");
                    }
                }
                else if (BtnSave.Value == "会员续卡")
                {
                    string mid = Request.Form["mid"];
                    Model.member modelmen = bllmen.GetModel(mid);
                    Model.memberType modelty = bllmt.GetModel(Convert.ToInt32(modelmen.Mtype));
                    string s = GetQx(modelty);
                    if (s == "无期限")
                    {
                        ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('此卡是无期限的！！');parent.window.location.reload();</script>");
                    }
                    else
                    {
                        DateTime day = Convert.ToDateTime(Request.Form["PeriodDay"]);
                        modelmen.XqTime = day;
                        bllmen.Update(modelmen);
                        string pirc = Request.Form["PeriodPrice"];
                        if (pirc != "")
                        {
                            BC(Convert.ToDecimal(pirc), "续卡收款", DropDownList1.SelectedValue, 21);
                        }
                        ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('续卡成功！！');parent.window.location.reload();</script>");
                    }
                }
                else if (BtnSave.Value == "会员退卡")
                {
                    string mid = Request.Form["mid"];
                    Model.member modelmen = bllmen.GetModel(mid);
                    modelmen.Statid = 4;
                    bllmen.Update(modelmen);
                    string pirc = Request.Form["OutPrice"];
                    if (pirc != "")
                    {
                        BC(Convert.ToDecimal(pirc) * -1, "退卡退款", DropDownList1.SelectedValue, 22);
                    }
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('退卡成功！！');parent.window.location.reload();</script>");
                }
                else if (BtnSave.Value == "修改密码")
                {
                    string mid = Request.Form["mid"];
                    string newpwd = Request.Form["NewPwd"];
                    string savpwd = Request.Form["SavePwd"];
                    if (newpwd != savpwd)
                    {
                        ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('两个输入密码不一样！！');parent.window.location.reload();</script>");
                    }
                    else
                    {
                        Model.member model = bllmen.GetModel(mid);
                        model.Pwd = savpwd;
                        bllmen.Update(model);
                        ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('密码修改成功！！');parent.window.location.reload();</script>");
                    }
                }
                else if (BtnSave.Value == "会员升级")
                {
                    int CategorgId = Convert.ToInt32(Request.Form["CategorgId"]);
                    int DeductScore = Convert.ToInt32(Request.Form["DeductScore"]);
                    if (DeductScore > 0) {
                        Model.mRecords modelmr = new Model.mRecords();
                        modelmr.mmid = Request.Form["mid"];
                        modelmr.Price = DeductScore;
                        modelmr.Type = 4;
                        modelmr.Remark = "";
                        bllmr.Add(modelmr);
                    }
                    bllmen.Updates("update member set Mtype=" + CategorgId + " where Mid=" + mid.Value + "");
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('升级成功！！');parent.window.location.reload();</script>");
                }
            }
            else {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('请选择需要操作的会员！！');</script>");
            }
        }
        BLL.member bllmen = new BLL.member();
        BLL.mRecords bllmr = new BLL.mRecords();
        BLL.memberType bllmt = new BLL.memberType();
        private string GetQx(Model.memberType modelty)
        {
            if (modelty.Limit)
            {
                return modelty.LimitValue.ToString();
            }
            else
            {
                return "无期限";
            }
        }

        public override void SonLoad()
        {
            BindMethPay();
            string type = Request.QueryString["type"];
            switch (type)
            {
                case "addPrice":
                    AddPrice();
                    break;
                case "jftz":
                    jftz1();
                    break;
                case "gua":
                    GuaShi();
                    break;
                case "cardUp":
                    CardUp();
                    break;
                case "xucard":
                    Xucard();
                    break;
                case "tuicard":
                    Tuicard();
                    break;
                case "pwdResl":
                    PwdResl();
                    break;
                case "lvup":
                    Lvup();
                    break;
                default:
                    break;
            }
        }
    }
}