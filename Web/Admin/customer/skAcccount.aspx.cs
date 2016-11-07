using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.customer
{
    public partial class skAcccount : BasePage
    {
        BLL.customer bllcon = new BLL.customer();
        BLL.goods_account bllga = new BLL.goods_account();

        BLL.meth_pay fmzffs = new BLL.meth_pay();
        protected void btnSave_Click(object sender, EventArgs e) {
            string account = Request.QueryString["accounts"];
            decimal pri = Convert.ToDecimal(price.Value);
            Model.goods_account modelag = new Model.goods_account();
            modelag.ga_name = "预收款";
            modelag.Ga_Account = account;
            modelag.ga_zffs_id = Convert.ToInt32(DDlZffs.SelectedValue);
            modelag.ga_date = DateTime.Now;
            modelag.ga_people = UserNow.UserID;
            modelag.ga_remker = "预收款";
            modelag.ga_Type = 201;
            if (tvalue.Value == "0")
            {
                modelag.ga_price = pri;
            }
            else {
                modelag.ga_price = pri * -1;
            }
            if (bllga.Add(modelag) > 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('入帐成功');parent.window.location.href='account_goods.aspx?readValue=201&accounts=" + account + "';</script>");
            }
         }

        BLL.account_goods bllag = new BLL.account_goods();



        public override void SonLoad()
        {
            if (!IsPostBack)
            {
                tvalue.Value = Request.QueryString["t"];
                string account = Request.QueryString["accounts"];
                AccountName.Value = bllcon.GetAccounts(account).cName;
                ga_Account.Value=account;
                DDlZffs.DataSource = fmzffs.GetList("meth_is_ya=1");
                DDlZffs.DataBind();
            }
        }
    }
}