using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.customer
{
    public partial class CzAdd : BasePage
    {
        BLL.customer bllcon = new BLL.customer();
        BLL.meth_pay fmzffs = new BLL.meth_pay();

        BLL.goods_account bllga = new BLL.goods_account();
        private void Bind() { 
          
        }

        protected void btnSave_Click(object sender,EventArgs e) {
            Model.goods_account modelag = new Model.goods_account();
            modelag.ga_name = "冲帐";
            modelag.Ga_Account = hidaccount.Value;
            //modelag.ga_zffs_id = Convert.ToInt32(DDlZffs.SelectedValue);
            modelag.ga_date = DateTime.Now;
            modelag.ga_people = UserNow.UserID;
            modelag.ga_remker = "冲帐";
            modelag.ga_Type = 204;
            modelag.Ga_goodNo = "CZ" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace("-","").Replace(":", "").Replace(" ", "").Replace("/", "");
            modelag.ga_sum_price = Convert.ToDecimal(price.Value) * -1;
            modelag.ga_occuid = orderid.Value;
            if (bllga.Add(modelag) > 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('冲帐成功');parent.window.location.reload();</script>");
            }
        }

        public override void SonLoad()
        {
            if (!IsPostBack)
            {
                string account = Request.QueryString["account"];
                AccountName.Value = bllcon.GetAccounts(account).cName;
                ga_Account.Value = account;
                hidaccount.Value = account;
                orderid.Value = Request.QueryString["orderid"];
            }
        }
    }
}