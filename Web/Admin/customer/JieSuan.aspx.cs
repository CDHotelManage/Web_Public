using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.customer
{
    public partial class JieSuan : BasePage
    {

        BLL.customer bllcon = new BLL.customer();


        BLL.meth_pay fmzffs = new BLL.meth_pay();
        public override void SonLoad()
        {
            if (!IsPostBack)
            {

                string account = Request.QueryString["accounts"];
                AccountName.Value = bllcon.GetAccounts(account).cName;
                ga_Account.Value = account;

                string ids = Request.QueryString["ids"];
                string[] idstr = ids.Split(',');
                if (idstr.Length == 1)
                {
                    idss.Value = "'" + ids + "'";
                }
                else if (idstr.Length>1)
                {
                    foreach (string item in idstr)
                    {
                        ids += "'" + item + "',";
                    }
                    idss.Value = ids.Substring(0, ids.Length - 1);
                }

                List<Model.goods_account> listag = bllga.GetModelList1("ga_goodNo in (" + idss.Value + ") and ga_Account='" + account + "' and ga_Type=204");
                decimal sumprice = 0; 
                if (listag.Count > 0) {
                    foreach (Model.goods_account item in listag)
                    {
                        sumprice += Convert.ToDecimal(item.ga_sum_price);
                    }
                }
                price.Value = sumprice.ToString();
                DDlZffs.DataSource = fmzffs.GetList("meth_is_jie=1");
                DDlZffs.DataBind();
            }
        }
        BLL.goods_account bllga = new BLL.goods_account();
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string account = Request.QueryString["accounts"];
            decimal pri = Convert.ToDecimal(price.Value);
            Model.goods_account modelag = new Model.goods_account();
            modelag.ga_name = "结账收款";
            modelag.Ga_Account = account;
            modelag.ga_zffs_id = Convert.ToInt32(DDlZffs.SelectedValue);
            modelag.ga_date = DateTime.Now;
            modelag.ga_people = UserNow.UserID;
            modelag.ga_remker = "收款结算"; 
            modelag.ga_Type = 202;
            modelag.ga_price = pri;
            if (rad1.Checked)
            {
                modelag.ga_jsfs = 0;
                
            }
            else {
                modelag.ga_jsfs = 1;
                bllga.Add(modelag);
            }
            
            

            List<Model.goods_account> listag = bllga.GetModelList1("ga_goodNo in (" + idss.Value + ")");
            if (listag.Count > 0)
            {
                foreach (Model.goods_account item in listag)
                {
                    item.ga_Type = 203;
                    bllga.Update(item);
                }
            }
            ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('结帐成功');parent.window.location.reload();</script>");
        }

        BLL.account_goods bllag = new BLL.account_goods();
    }
}