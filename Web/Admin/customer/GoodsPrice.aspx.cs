using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CdHotelManage.Web.Admin.customer
{
    public partial class GoodsPrice : BasePage
    {
        BLL.room_type fxBll = new BLL.room_type();
        BLL.room_number fhBll = new BLL.room_number();
        BLL.card_type fsfBll = new BLL.card_type();
        BLL.meth_pay fmzffs = new BLL.meth_pay();
        BLL.real_mode fmkffs = new BLL.real_mode();
        BLL.occu_infor fmrzInfo = new BLL.occu_infor();
        BLL.Goods fmgoods = new BLL.Goods();
        BLL.guest_source fmGust = new BLL.guest_source();
        BLL.goods_account fmgoodvount = new BLL.goods_account();
        public string contents
        {

            get { return (string)ViewState["contents"]; }

            set { ViewState["contents"] = value; }

        }
        public string number
        {

            get { return (string)ViewState["number"]; }

            set { ViewState["number"] = value; }

        }
        public int ids
        {

            get { return (int)ViewState["ids"]; }

            set { ViewState["ids"] = value; }

        }

        /// <summary>
        /// 绑定支付方式
        /// </summary>
        //public void BindZFFS()
        //{
        //    DDlZffs.DataSource = fmzffs.GetAllList();
        //    DDlZffs.DataBind();
        //}
        /// <summary>
        /// 绑定商品价格
        /// </summary>
        public void BindSP()
        {
            //DDLGoodNumber.DataSource = fmgoods.GetList(" Goods_ifType=1");
            //DDLGoodNumber.DataBind();
            //DDLGoodNumber.Items.Insert(0, "请选择商品价格");
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
        /// 确认添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdds_Click(object sender, EventArgs e)
        {
            string no = "CZ" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace("-", "").Replace(":", "").Replace(" ", "").Replace("/", "");
            int Result = 0;
            CdHotelManage.Model.goods_account model = new CdHotelManage.Model.goods_account();
            CdHotelManage.BLL.goods_account bll = new CdHotelManage.BLL.goods_account();
            int b = hidcontent.Value.Split('|').Length;
            string[] hidcon = hidcontent.Value.Split('|');
            for (int i = 0; i < hidcon.Length - 1; i++)
            {
                try
                {

                    model.ga_number = hidcon[i].Split('#')[0];
                    model.ga_name = hidcon[i].Split('#')[1];
                    model.ga_unit = hidcon[i].Split('#')[2];
                    model.ga_Type = 204;
                    model.ga_price = 0;
                    model.ga_num = Convert.ToInt32(hidcon[i].Split('#')[4]);
                    string a = hidcon[i].Split('#')[5];
                    model.ga_sum_price = Convert.ToDecimal(hidcon[i].Split('#')[5]);
                    model.ga_date = Convert.ToDateTime(System.DateTime.Now);
                    model.ga_people = UserNow.UserID;
                    model.ga_sfacount = "否";
                    model.Ga_Account = ga_Account.Text;
                    // model.ga_zffs_id = Convert.ToInt32(DDlZffs.SelectedValue);
                    model.ga_remker = txt_Remaker.Value;
                    model.Ga_goodNo = no;

                    Result = bll.Add(model);

                    //if (DDlZffs.SelectedValue != "入账")
                    //{
                    //    model.ga_number = hidcon[i].Split('#')[0];
                    //    model.ga_name = "商品收款";
                    //    model.ga_unit = hidcon[i].Split('#')[2];
                    //    model.ga_Type = 0;
                    //    model.ga_price = Convert.ToDecimal(hidcon[i].Split('#')[5]);
                    //    model.ga_num = Convert.ToInt32(hidcon[i].Split('#')[4]);
                    //    model.ga_sum_price = 0;
                    //    model.ga_date = Convert.ToDateTime(System.DateTime.Now);
                    //    model.ga_people = UserNow.UserID;
                    //    model.ga_sfacount = "否";
                    //    model.ga_zffs_id = Convert.ToInt32(DDlZffs.SelectedValue);
                    //    model.ga_remker = txt_Remaker.Value;
                    //    model.ga_roomNumber = fmrzInfo.GetModel(ids).room_number;
                    //    model.ga_occuid = fmrzInfo.GetModel(ids).order_id;
                    //    model.Ga_goodNo = fmrzInfo.GetModel(ids).occ_no;
                    //    Result = bll.Add(model);
                    //}
                }

                catch
                {

                }
            }
            if (Result > 0)
            {
                // ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('保存成功');parent.document.getElementById('btnsercher').click();parent.Window_Close();</script>");
                // ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "alert('保存成功');parent.document.getElementById('btnsercher').click();parent.Window_Close();", "", true);
                //Helper.AddRoom(model.ga_roomNumber);
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "click", "alert('保存成功');parent.window.location.href='account_goods.aspx?readValue=204&accounts=" + ga_Account.Text + "';", true);

            }
        }
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
        BLL.customer bllcon = new BLL.customer();
        public override void SonLoad()
        {
            if (!IsPostBack)
            {
               // BindZFFS();
                string account = Request.QueryString["accounts"];
                accounts.Text = bllcon.GetAccounts(account).cName;
                ga_Account.Text = account;
            }
        }

        protected void btnGetPrice_Click(object sender, EventArgs e)
        {


            DataSet dt = fmgoods.GetList(" id=" + txtid.Value + "");
            foreach (DataRow dr in dt.Tables[0].Rows)
            {
                double money = Convert.ToDouble(txt_Num.Value) * Convert.ToDouble(dr["Goods_price"]);
                string a = dr["Goods_number"].ToString().Trim();
                if (txt_Number.Value.Trim().Contains(dr["Goods_number"].ToString()))
                {
                    txt_Sumnum.Value = dr["Goods_number"].ToString();
                }
                else
                {
                    hidcontent.Value += dr["Goods_number"].ToString() + "#" + dr["Goods_name"].ToString() + "#" + dr["Goods_unit"].ToString() + "#" + dr["Goods_price"].ToString() + "#" + txt_Num.Value + "#" + money + "|";
                    txt_Number.Value += dr["Goods_number"].ToString() + ",";
                }
            }

            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "qwwqwq", "DisList('" + hidcontent.Value + "');", true);

        }
    }
}
