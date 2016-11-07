using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.customer
{
    public partial class addCustomer : BasePage
    {
        public override void SonLoad()
        {
            if (!IsPostBack)
            {
                BindsysType();
                BindcusType();
                BindState();
                BindIndustry();
                Bindsource();
                if (Request.QueryString["type"] == "edit")
                {
                    accoes.Style.Add("display", "block");
                    BtnSave.Value = "更新";
                    acc.Value = Request.QueryString["accounts"];
                    string accounts = Request.QueryString["accounts"];
                    Bind(acc.Value);
                }
            }
            else {
            }
        }


        decimal ys = 0;
        decimal yus = 0;
        decimal yjs = 0;
        decimal njxf = 0;
        int rzts = 0;
        int notshow = 0;
        int qxyd = 0;
        int pm = 0;
        decimal wjs = 0;
        decimal yjsyyj = 0;


        protected int commy = 0;
        protected int commw = 0;

        protected Model.customer modelcus = new Model.customer();
        BLL.customer bllcon = new BLL.customer();
        BLL.goods_account bllga = new BLL.goods_account();
        /// <summary>
        /// 帐号
        /// </summary>
        /// <param name="acconut"></param>
        private void Js(string acconut1)
        {
            modelcus = bllcon.GetAccounts(acconut1);


            List<Model.goods_account> listag = bllga.GetModelList1("ga_Account='" + acconut1 + "'");
            if (listag.Count > 0)
            {
                foreach (Model.goods_account item in listag)
                {
                    if (item.ga_Type == 201)
                    {
                        yus += Convert.ToDecimal(item.ga_price);
                    }
                    else if (item.ga_Type == 202)
                    {

                    }
                    else if (item.ga_Type == 203)
                    {
                        yjs += Convert.ToInt32(item.ga_sum_price);
                    }
                    else if (item.ga_Type == 204)
                    {
                        ys += Convert.ToInt32(item.ga_sum_price);
                    }
                    njxf += Convert.ToDecimal(item.ga_sum_price);
                }

            }

            BLL.Commission bllcpp = new BLL.Commission();
            List<Model.Commission> listapp = bllcpp.GetModelList("Accounts='" + acconut1 + "'");
            if (listapp.Count > 0)
            {
                foreach (Model.Commission cp in listapp)
                {
                    if (cp.IsBack)
                    {
                        commy += Convert.ToInt32(cp.CommSum);
                    }
                    else
                    {
                        commw += Convert.ToInt32(cp.CommSum);
                    }
                }
            }
            ysh.InnerText = ys.ToString(); ;
            yush.InnerText = yus.ToString();
            yjsh.InnerText = yjs.ToString();

            njxfs.InnerText = njxf.ToString();
        }
        private void Bind(string accounts) {
            Js(accounts);
            List<Model.customer> list = bllcus.GetModelList("accounts='" + accounts + "'");
            if (list.Count > 0) {
                Model.customer modelcus = list[0];
                cName.Value = modelcus.cName;
                sysType.SelectedValue = modelcus.sysType.ToString();
                cusType.SelectedValue = modelcus.cusType.ToString();
                cusDesy.Value = modelcus.cusDesy;
                cusNumber.Value = modelcus.cusNumber;
                contacts.Value = modelcus.contacts;
                cPhone.Value = modelcus.cPhone;
                Cstate.SelectedValue = modelcus.Cstate.ToString();
                area.Value = modelcus.area;
                ybNum.Value = modelcus.ybNum;
                Address.Value = modelcus.Address;
                companyPhone.Value = modelcus.companyPhone;
                Fax.Value = modelcus.Fax;
                homepage.Value = modelcus.homepage;
                Csource.SelectedValue = modelcus.Csource.ToString();
                cIndustry.SelectedValue = modelcus.cindustry.ToString();
                Remark.Value = modelcus.Remark;
                Ischalk.Checked = modelcus.Ischalk;
                limit.Value = modelcus.limit.ToString();
                prosceniumIss.Checked = modelcus.prosceniumIss;
                Ishire.Checked = modelcus.Ishire;
                isXz.Checked = modelcus.IsXz;
            }
        }

        #region 绑定所有下拉框
        /// <summary>
        /// 绑定系统类型
        /// </summary>
        private void BindsysType()
        {
            BLL.csysType bllct = new BLL.csysType();
            sysType.DataSource = bllct.GetAllList();
            sysType.DataTextField = "stName";
            sysType.DataValueField = "ID";
            sysType.DataBind();
        }

        /// <summary>
        /// 绑定客户类型
        /// </summary>
        private void BindcusType()
        {
            BLL.customerType bllct = new BLL.customerType();
            cusType.DataSource = bllct.GetAllList();
            cusType.DataTextField = "ctName";
            cusType.DataValueField = "ID";
            cusType.DataBind();
        }

        /// <summary>
        /// 绑定客户状态
        /// </summary>
        private void BindState()
        {
            BLL.customerState bllct = new BLL.customerState();
            Cstate.DataSource = bllct.GetAllList();
            Cstate.DataTextField = "csName";
            Cstate.DataValueField = "ID";
            Cstate.DataBind();
        }

        /// <summary>
        /// 绑定客户状态
        /// </summary>
        private void BindIndustry()
        {
            BLL.cIndustry bllct = new BLL.cIndustry();
            cIndustry.DataSource = bllct.GetAllList();
            cIndustry.DataTextField = "csName";
            cIndustry.DataValueField = "ID";
            cIndustry.DataBind();
        }
        /// <summary>
        /// 绑定客户来源
        /// </summary>
        private void Bindsource()
        {
            BLL.guest_source bllct = new BLL.guest_source();
            Csource.DataSource = bllct.GetAllList();
            Csource.DataTextField = "gs_name";
            Csource.DataValueField = "ID";
            Csource.DataBind();
        } 
        #endregion

        Random r = new Random();
        /// <summary>
        /// 保存和修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSave_Click(object sender ,EventArgs e) {
             Model.customer modelcus = new Model.customer();
            double i = r.NextDouble();
            string str = i.ToString().Substring(2, 5);
            modelcus.accounts = "A" + str;
            modelcus.cName = cName.Value;
            modelcus.sysType = Convert.ToInt32(sysType.SelectedValue);
            modelcus.cusType = Convert.ToInt32(cusType.SelectedValue);
            modelcus.cusDesy = cusDesy.Value;
            modelcus.cusNumber = cusNumber.Value;
            modelcus.contacts = contacts.Value;
            modelcus.cPhone = cPhone.Value;
            modelcus.Cstate = Convert.ToInt32(Cstate.SelectedValue);
            modelcus.sales = 1;
            modelcus.prosceniumIss = prosceniumIss.Checked;
            modelcus.Ishire = Ishire.Checked;
            modelcus.area = area.Value;
            modelcus.ybNum = ybNum.Value;
            modelcus.Email = Email.Value;
            modelcus.Address = Address.Value;
            modelcus.companyPhone = companyPhone.Value;
            modelcus.Fax = Fax.Value;
            modelcus.homepage = homepage.Value;
            modelcus.Csource = Convert.ToInt32(Csource.SelectedValue);
            modelcus.cindustry = Convert.ToInt32(cIndustry.SelectedValue);
            modelcus.Ischalk = Ischalk.Checked;
            if (limit.Value == "") {
                modelcus.limit = null;
            }
            else
            {
                modelcus.limit = Convert.ToInt32(limit.Value);
            }
            modelcus.Remark = Remark.Value;
            modelcus.AddDate = DateTime.Now;
            modelcus.editUser = UserNow.UserID;
            modelcus.verifyUser = null;
            modelcus.isVerify = false;
            modelcus.Details = "";
            modelcus.IsXz = isXz.Checked;
            if (Request.QueryString["type"] == "edit") {
                modelcus.accounts = acc.Value;
                if (bllcus.Update(modelcus)) {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript'>alert('更新成功');parent.window.location.reload();</script>");  
                }
            }
            else
            {
                modelcus.occNum = 0;
                modelcus.NoShow = 0;
                modelcus.xqBook = 0;
                modelcus.Pming = 0;
                if (bllcus.Add(modelcus) > 0)
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript'>alert('新增成功');parent.window.location.reload();</script>");
                }
            }
        }
        BLL.customer bllcus = new BLL.customer();
    }
}