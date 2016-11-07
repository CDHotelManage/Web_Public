using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace CdHotelManage.Web.Admin.Toroom
{
    public partial class FkMoney:BasePage
    {
        BLL.meth_pay fmzffs = new BLL.meth_pay();
        BLL.occu_infor fmrzo = new BLL.occu_infor();
        BLL.goods_account fmrz = new BLL.goods_account();
        public int ids
        {

            get { return (int)ViewState["ids"]; }

            set { ViewState["ids"] = value; }

        }

        /// <summary>
        /// 绑定支付方式
        /// </summary>
        public void BindZFFS()
        {
            DataSet dt = fmzffs.GetAllList();
            DDlZffs.DataSource = fmzffs.GetAllList();
            DDlZffs.DataBind();
            //  DDlZffs.Items.Insert(0, "请选择支付方式");
        }
        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdds_Click(object sender, EventArgs e)
        {
            Model.goods_account model = new Model.goods_account();
            model.ga_people = UserNow.UserID;
            model.ga_zffs_id = Convert.ToInt32(DDlZffs.SelectedValue);
            model.ga_price = Convert.ToDecimal(txt_Money.Value);
            model.ga_sfacount = "是";
            model.ga_name = "预收款";
            model.ga_occuid = fmrzo.GetModel(ids).order_id; ;
            model.ga_sum_price =0;
            model.ga_Type = 4;
            model.Ga_goodNo = fmrzo.GetModel(ids).occ_no;
            //fmrz.GetMaxId();
            model.ga_number = "SK"+System.DateTime.Now.ToString().Replace("-", "").Replace(":", "").Replace(" ", "");
            model.ga_date = System.DateTime.Now;
            model.ga_roomNumber = txt_fh.Value.ToString();
            if (fmrz.Add(model) > 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript'>if(confirm('收款成功，是否打印收款单？')){XZintRZ(this,'" + model.ga_occuid + "')} else{ }</script>");
            }
        }

        public override void SonLoad()
        {
            if (!IsPostBack)
            {
                BindZFFS();
                ids = Convert.ToInt32(Request.QueryString["id"].ToString());
                txt_fh.Value = fmrzo.GetModel(ids).room_number;
                txt_djh.Value = fmrzo.GetModel(ids).occ_no;
            }  
        }
    }
}