using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace CdHotelManage.Web.Admin.Toroom
{
    public partial class ContinuedLive :BasePage
    {
        BLL.room_type fxBll = new BLL.room_type();
        BLL.room_number fhBll = new BLL.room_number();
        BLL.cost_type fmcf = new BLL.cost_type();
        BLL.meth_pay fmzffs = new BLL.meth_pay();
        BLL.real_mode fmkffs = new BLL.real_mode();
        BLL.occu_infor fmrzInfo = new BLL.occu_infor();
        BLL.guest_source fmGust = new BLL.guest_source();
        public int ids
        {

            get { return (int)ViewState["ids"]; }

            set { ViewState["ids"] = value; }

        }
   
        public void Bind()
        {
            Model.occu_infor mod = new Model.occu_infor();
            labfh.Text = fmrzInfo.GetModel(ids).room_number;
            labfx.Text = GetRealTypeName(fmrzInfo.GetModel(ids).real_type_id);
            labkffs.Text = GetKffsName(fmrzInfo.GetModel(ids).real_mode_id);
            lably.Text = GetLYName(fmrzInfo.GetModel(ids).source_id);
            labname.Text = fmrzInfo.GetModel(ids).occ_name.ToString();
            labrzDate.Text = fmrzInfo.GetModel(ids).occ_time.ToString();
            labfjMoney.Text = fmrzInfo.GetModel(ids).real_scheme_id.ToString();
            labSymoney.Text = fmrzInfo.GetModel(ids).deposit.ToString();
            txt_ydDate.Value = fmrzInfo.GetModel(ids).depar_time.ToString();
            txt_xdDate.Value =  Convert.ToDateTime( fmrzInfo.GetModel(ids).depar_time).AddDays(Convert.ToInt32( txt_liveDay.Value)).ToString();
        }
        /// <summary>
        /// 绑定支付方式
        /// </summary>
        public void BindZFFS()
        {
            DDlZffs.DataSource = fmzffs.GetModelList("meth_is_ya=1");
            DDlZffs.DataBind();
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdds_Click(object sender, EventArgs e)
        {
            try
            {
                CdHotelManage.Model.goods_account model = new CdHotelManage.Model.goods_account();
                CdHotelManage.BLL.goods_account bll = new CdHotelManage.BLL.goods_account();
                Model.occu_infor Ocmodels = new Model.occu_infor();
                Ocmodels.state_id = 1;
                Ocmodels.continuelive = ids;
                Ocmodels.brithday = Convert.ToDateTime(fmrzInfo.GetModel(ids).brithday).ToString();
                Ocmodels.occ_time = System.DateTime.Now;
                Ocmodels.depar_time = Convert.ToDateTime(txt_ydDate.Value);
                Ocmodels.pha_sched = Convert.ToDateTime(txt_xdDate.Value);
                Ocmodels.deposit = Convert.ToDecimal(txt_yjMoney.Value);
                Ocmodels.stay_day = Convert.ToInt32(txt_liveDay.Value);
                Ocmodels.meth_pay_id = Convert.ToInt32(DDlZffs.SelectedValue);
                model.ga_number = ids.ToString();
                model.ga_Type = 3;
                model.ga_name = "续住收款";
                model.ga_number = ids.ToString();
                model.ga_price = Convert.ToDecimal(txt_yjMoney.Value);
                model.ga_sum_price = 0;
                model.ga_date = Convert.ToDateTime(System.DateTime.Now);
                model.ga_occuid = fmrzInfo.GetModel(ids).order_id;
                model.ga_people =UserNow.UserID;
                model.ga_sfacount="否";
                model.ga_remker = txt_Remaker.Value;
                model.Ga_goodNo = fmrzInfo.GetModel(ids).occ_no;
                model.ga_zffs_id = Convert.ToInt32(DDlZffs.SelectedValue);
                model.ga_roomNumber = fmrzInfo.GetModel(ids).room_number; 
                int Result = bll.Add(model);
                int day = Convert.ToInt32(fmrzInfo.GetModel(ids).stay_day) +Convert.ToInt32(txt_liveDay.Value);

                string sql = "update occu_infor set stay_day='" + day + "',depar_time='" + txt_xdDate.Value + "' where occ_id=" + fmrzInfo.GetModel(ids).occ_id+ " ";
                fmrzInfo.Updates(sql);
                if (Result > 0 && fmrzInfo.Add(Ocmodels) > 0)
                {
                    Helper.AddRoom(model.ga_roomNumber);
                //  Maticsoft.Common.MessageBox.ShowAndRedirect(this, "保存成功！", "");
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript'>if(confirm('续住成功，是否打印收款单？')){XZintRZ(this," + fmrzInfo.GetModel(ids).order_id + ") }else{Close('房态图'); }; parent.Window_Close();</script>");

                }
                else
                {
                    Maticsoft.Common.MessageBox.ShowAndRedirect(this, "续住失败！", "");
                }
            }
            catch { }
           
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
            if (model != null)
            {
                return model.real_mode_name;
            }
            else {
                return "";
            }


        }
        //获得来源
        public string GetLYName(int id)
        {
            Model.guest_source model = fmGust.GetModel(Convert.ToInt32(id.ToString()));
            if (model != null)
            {
                return model.gs_name;
            }
            else {
                return "";
            }


        }

        public override void SonLoad()
        {
            if (!IsPostBack)
            {
                BindZFFS();
                ids = Convert.ToInt32(Request.QueryString["id"]);
                Bind();
            }
        }
    }
   
}