using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CdHotelManage.Web.Admin.customer
{
    public partial class CostMoney : BasePage
    {

        BLL.room_type fxBll = new BLL.room_type();
        BLL.room_number fhBll = new BLL.room_number();
        BLL.cost_type fmcf = new BLL.cost_type();
        BLL.meth_pay fmzffs = new BLL.meth_pay();
        BLL.real_mode fmkffs = new BLL.real_mode();
        BLL.occu_infor fmrzInfo = new BLL.occu_infor();
        BLL.Goods fmgoods = new BLL.Goods();
        BLL.guest_source fmGust = new BLL.guest_source();
        BLL.goods_account fmgoodvount = new BLL.goods_account();
        public int ids
        {

            get { return (int)ViewState["ids"]; }

            set { ViewState["ids"] = value; }

        }

        //public void Bind()
        //{
        //    Model.occu_infor mod = new Model.occu_infor();
        //    labfh.Text = fmrzInfo.GetModel(ids).room_number;
        //    labfx.Text = GetRealTypeName((fmrzInfo.GetModel(ids).real_type_id));
        //    labkffs.Text = GetKffsName(fmrzInfo.GetModel(ids).real_mode_id);
        //    lably.Text = GetLYName(fmrzInfo.GetModel(ids).source_id);
        //    labname.Text = fmrzInfo.GetModel(ids).occ_name.ToString();
        //    labrzDate.Text = fmrzInfo.GetModel(ids).occ_time.ToString();
        //    labfjMoney.Text = fmrzInfo.GetModel(ids).real_price.ToString();
        //    labSymoney.Text = fmrzInfo.GetModel(ids).amount_money.ToString();
        //    double ysMoney = 0;
        //    DataSet dt = fmgoodvount.GetList(" ga_occuid in ('" + fmrzInfo.GetModel(ids).order_id + "')");
        //    foreach (DataRow dr in dt.Tables[0].Rows)
        //    {
        //        try
        //        {
        //            ysMoney += double.Parse(dr["ga_sum_price"].ToString());
        //        }
        //        catch { }
        //    }
        //    labSymoney.Text = ysMoney.ToString();
        //}
        /// <summary>
        /// 费用绑定
        /// </summary>
        public void BindFY()
        {
            DDlfyType.DataSource = fmcf.GetList(" ct_iftype=0");
            DDlfyType.DataBind();
            DDlfyType.Items.Insert(0, "请选择费用类别");
            DDlName.Items.Insert(0, "请选择费用名称");
        }
        /// <summary>
        /// 绑定费用名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DDlfyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDlfyType.SelectedIndex > 0)
            {
                DDlName.DataSource = fmcf.GetList(" ct_iftype=1 and ct_categories=" + DDlfyType.SelectedValue + "");
                DDlName.DataBind();
                try
                {
                    txt_Money.Value = fmcf.GetModel(Convert.ToInt32(DDlName.SelectedValue)).ct_money.ToString();
                }
                catch
                {
                    DDlName.Items.Insert(0, "请选择费用名称");
                    txt_Money.Value = "";
                }
            }
        }
        /// <summary>
        /// 保存
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdds_Click(object sender, EventArgs e)
        {
            string no = "CZ" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace("-", "").Replace(":", "").Replace(" ", "").Replace("/", "");
            CdHotelManage.Model.goods_account model = new CdHotelManage.Model.goods_account();
            CdHotelManage.BLL.goods_account bll = new CdHotelManage.BLL.goods_account();
            model.ga_number = DDlName.SelectedValue;
            model.ga_name = DDlName.SelectedItem.Text;
            model.ga_Type = 204;
            model.ga_price = 0;
            model.ga_sum_price = Convert.ToDecimal(txt_Money.Value);
            model.ga_date = Convert.ToDateTime(System.DateTime.Now);
            model.ga_people = UserNow.UserID;
            model.ga_sfacount = "否";
            model.ga_remker = txt_Remaker.Value;
            model.Ga_Account = ga_Account.Text;
            model.Ga_goodNo = no;
            int Result = bll.Add(model);
            if (Result > 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('保存成功');parent.window.location.href='account_goods.aspx?readValue=204&accounts=" + ga_Account.Text + "';</script>");

            }
            else
            {
                Maticsoft.Common.MessageBox.ShowAndRedirect(this, "保存失败！", "");
            }
        }

        BLL.infos bllin = new BLL.infos();

        //获得房型名称
        public string GetRealTypeName(int id)
        {

            BLL.room_type rtbll = new BLL.room_type();
            Model.room_type model = rtbll.GetModel(Convert.ToInt32(id.ToString()));
            return model.room_name;


        }
        //获得开房方式
        public string GetKffsName(int id)
        {
            Model.real_mode model = fmkffs.GetModel(Convert.ToInt32(id.ToString()));
            return model.real_mode_name;


        }
        //获得来源
        public string GetLYName(int id)
        {
            Model.guest_source model = fmGust.GetModel(Convert.ToInt32(id.ToString()));
            return model.gs_name;


        }

        public override void SonLoad()
        {
            if (!IsPostBack)
            {
                //ids = Convert.ToInt32(Request.QueryString["id"]);
                //Bind();
                BindFY();
                string account = Request.QueryString["accounts"];
                accounts.Text = bllcon.GetAccounts(account).cName;
                ga_Account.Text = account;
            }
        }
        BLL.customer bllcon = new BLL.customer();
    }
}