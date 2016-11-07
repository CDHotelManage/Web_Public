using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.Toroom
{
    public partial class ChangeRoom : System.Web.UI.Page
    {
        public int ids
        {

            get { return (int)ViewState["ids"]; }

            set { ViewState["ids"] = value; }

        }
        BLL.real_mode fmkffs = new BLL.real_mode();
        BLL.occu_infor fmrzInfo = new BLL.occu_infor();
        BLL.room_type fxBll = new BLL.room_type();
        BLL.room_number fhBll = new BLL.room_number();
        BLL.guest_source fmGust = new BLL.guest_source();
        BLL.goods_account fmGoods = new BLL.goods_account();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ids = Convert.ToInt32(Request.QueryString["id"]);
                Bind();
                BindFX();
            }
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
            labSymoney.Text = fmrzInfo.GetModel(ids).real_price.ToString();
        }
        /// <summary>
        /// 绑定房型
        /// </summary>
        public void BindFX()
        {
            ddroomtype.DataSource = fxBll.GetAllList();
            ddroomtype.DataBind();
            ddroomtype.Items.Insert(0, "请选择房型");
        }
        /// <summary>
        /// 换房
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdds_Click(object sender, EventArgs e)
        {
            Model.occu_infor mode = new Model.occu_infor();
            string SQl = "update room_number set Rn_state=4 where Rn_roomNum='" + labfh.Text + "';update room_number set Rn_state=2 where Rn_roomNum='" + txt_RoomNum.Value + "'"; ;
            Model.occu_infor Ocmodels = new Model.occu_infor();
            Ocmodels.state_id = 2;
            Ocmodels.continuelive = ids;
            Ocmodels.occ_time = System.DateTime.Now;
            Ocmodels.room_number = (txt_RoomNum.Value).ToString();
            Ocmodels.real_price = Convert.ToDecimal(txt_Money.Value);
            Ocmodels.remark = txt_Remaker.Value;
            Ocmodels.state_id = 0;
            Ocmodels.occ_no = fmrzInfo.GetModel(ids).occ_no;
            Ocmodels.occ_name = fmrzInfo.GetModel(ids).occ_name;
            Ocmodels.occ_with = "否";
            Ocmodels.stay_day = fmrzInfo.GetModel(ids).stay_day;
            Ocmodels.depar_time = fmrzInfo.GetModel(ids).depar_time;
            Ocmodels.sex = fmrzInfo.GetModel(ids).sex;
            Ocmodels.card_id = fmrzInfo.GetModel(ids).card_id;
            Ocmodels.brithday = fmrzInfo.GetModel(ids).brithday;
            Ocmodels.family_name = fmrzInfo.GetModel(ids).family_name;
            Ocmodels.address= fmrzInfo.GetModel(ids).address;
            Ocmodels.meth_pay_id = fmrzInfo.GetModel(ids).meth_pay_id;
            Ocmodels.deposit = fmrzInfo.GetModel(ids).deposit;
            Ocmodels.remark = fmrzInfo.GetModel(ids).remark;
            Ocmodels.lordRoomid = (txt_RoomNum.Value).ToString();
            Ocmodels.phonenum = fmrzInfo.GetModel(ids).phonenum;
            Ocmodels.Room_type_model = fmrzInfo.GetModel(ids).Room_type_model;
            Ocmodels.source_id = fmrzInfo.GetModel(ids).source_id;
            Ocmodels.real_mode_id = fmrzInfo.GetModel(ids).real_mode_id;
            Ocmodels.real_scheme_id = fmrzInfo.GetModel(ids).real_scheme_id;
            Ocmodels.real_type_id = fmrzInfo.GetModel(ids).real_type_id;
            Ocmodels.order_id = fmrzInfo.GetModel(ids).order_id;
            Ocmodels.tuifaId = "0";
           string noces= System.DateTime.Now.ToString().Replace("-", "").Replace(":", "").Replace(" ", "");
           string strsql = "";
           if (fmrzInfo.GetRecordCount("where order_id='" + Ocmodels.order_id + "'") == 1)
           {
               strsql = "update occu_infor set state_id=2,tuifaId=2,continuelive=1 ,order_id='" + noces + "' where occ_id='" + ids + "'";


           }
           else
           {

             //  strsql = "update occu_infor set state_id=3,tuifaId=2,continuelive=1 where order_id=" + Ocmodels.order_id + "";
               strsql = "update occu_infor set state_id=2,tuifaId=2,continuelive=1 where occ_id=" + ids + "";

           }
           fmrzInfo.Updates(strsql);
            CdHotelManage.Model.goods_account model = new CdHotelManage.Model.goods_account();
            CdHotelManage.BLL.goods_account bll = new CdHotelManage.BLL.goods_account();
            double money =double.Parse(txt_Money.Value )- double.Parse(labSymoney.Text);
            if (money > 0)
            {
                money = double.Parse(labSymoney.Text) - double.Parse(txt_Money.Value);
            }
            else 
            {
                money = double.Parse(labSymoney.Text);
            }
            string Remaker = labname.Text + "从" + labfh.Text + "换到" + txt_RoomNum.Value + " 从" + labkffs.Text + "(" + labSymoney.Text + ")调整为天房(" + txt_Money.Value + ") 操作时间：" + System.DateTime.Now;
            string beizhu= fmGoods.GetModels(" where ga_Type=8 order by ga_date ").ga_remker+Remaker +",";
            string Date= fmGoods.GetModels(" where ga_Type=8 order by ga_date ").ga_date.ToString();
            string upsql = "update goods_account set ga_sum_price='" + money + "',ga_remker='" + beizhu + "' where ga_Type=8 and  datediff(SS,ga_date,'" + Date + "')=0 and ga_occuid='" + Ocmodels.order_id + "'";
             fmGoods.Updates(upsql);
            if (fhBll.Updates(SQl) && fmrzInfo.Add(Ocmodels)>0)
            {
                Helper.AddRoom(Ocmodels.room_number);
                Helper.AddRoom(Ocmodels.lordRoomid);
                //Maticsoft.Common.MessageBox.ShowAndRedirect(this, "保存成功！", "");
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript'>if(confirm('换房成功，是否打换房单')){Show(" + ids + ");}else{ parent.location.reload(); };</script>");
            }
            else
            {
                Maticsoft.Common.MessageBox.ShowAndRedirect(this, "保存失败！", "");
            }
        }

        /// <summary>
        /// 绑定价格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddroomtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_RoomNum.Value = "";
            if (ddroomtype.SelectedIndex > 0)
            {
                txt_Money.Value = (fxBll.GetModel(Convert.ToInt32(ddroomtype.SelectedValue)).room_listedmoney).ToString();
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
        
    }
}
