using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.customer
{
    public partial class JsComm : BasePage
    {

        BLL.customer bllcon = new BLL.customer();
        BLL.meth_pay fmzffs = new BLL.meth_pay();
        BLL.Commission bllcomm = new BLL.Commission();
        BLL.goods_account bllga = new BLL.goods_account();
        protected void btnSave_Click(object sender, EventArgs e) {
            Model.goods_account modelgs = new Model.goods_account();
            modelgs.Ga_Account = CardNo.Value;
            modelgs.ga_date = DateTime.Now;
            modelgs.ga_isjz = 0;
            modelgs.ga_isys = 0;
            modelgs.ga_name = "佣金结账";
            modelgs.ga_Type = 205;
            modelgs.ga_people = UserNow.UserID;
            modelgs.ga_price = Convert.ToDecimal(Amount.Value);
            modelgs.ga_zffs_id = Convert.ToInt32(DDlZffs.SelectedValue);
            bllga.Add(modelgs);

            List<Model.Commission> listcomm = bllcomm.GetModelList("ID  in(" + idshid.Value + ")");
            if (listcomm.Count > 0) {
                foreach (Model.Commission item in listcomm)
                {
                    item.IsBack = true;
                    bllcomm.Update(item);

                }
            }
            ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('结算成功');parent.window.location.reload();</script>");
        }

        public override void SonLoad()
        {
            if (!IsPostBack)
            {
                string account = Request.QueryString["account"];
                CardNo.Value = account;
                MemberName.Value = bllcon.GetAccounts(account).cName;
                DDlZffs.DataSource = fmzffs.GetList("meth_is_jie=1");
                DDlZffs.DataBind();
                string ids = Request.QueryString["ids"];
                List<Model.Commission> listcomm = bllcomm.GetModelList("ID in (" + ids + ")");
                int sum = 0;
                foreach (Model.Commission mode in listcomm)
                {
                    sum += Convert.ToInt32(mode.CommSum);
                }
                Amount.Value = sum.ToString();
                idshid.Value = ids;
            }
        }
    }
}