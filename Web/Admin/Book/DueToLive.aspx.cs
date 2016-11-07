using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace CdHotelManage.Web.Admin.Book
{
    public partial class DueToLive : BasePage
    {

        BLL.room_type fxBll = new BLL.room_type();
        BLL.room_number fhBll = new BLL.room_number();
        BLL.card_type fsfBll = new BLL.card_type();
        BLL.meth_pay fmzffs = new BLL.meth_pay();
        BLL.hourse_scheme fmfjfa = new BLL.hourse_scheme();
        BLL.real_mode fmkffs = new BLL.real_mode();
        BLL.guest_source fmkrly = new BLL.guest_source();
        BLL.book_room bkBll = new BLL.book_room();
        public int ids
        {

            get { return (int)ViewState["ids"]; }

            set { ViewState["ids"] = value; }

        }
        
        /// <summary>
        /// 绑定房型
        /// </summary>
        public void BindFX()
        {
            ddroomtype.DataSource = fxBll.GetAllList();
            ddroomtype.DataBind();
        }
        /// <summary>
        /// 绑定身份证
        /// </summary>
        public void BindSFZ()
        {
            DataSet dt = fsfBll.GetAllList();
            foreach (DataRow dr in dt.Tables[0].Rows)
            {
                txt_CardesName.Value += dr["id"].ToString() + "," + dr["ct_name"].ToString() + ";";
            }
            DDlSFz.DataSource = fsfBll.GetAllList();
            DDlSFz.DataBind();
        }
        /// 绑定开放方式
        /// </summary>
        public void BindKFFS()
        {
            DDlKffs.DataSource = fmkffs.GetAllList();
            DDlKffs.DataBind();
            DDlKffs.Items.Insert(0, "请选择开房方式");
        }

        /// <summary>
        /// 绑定支付方式
        /// </summary>
        public void BindZFFS()
        {
            DDlZffs.DataSource = fmzffs.GetList("meth_is_ya=1");
            DDlZffs.DataBind();
        }

        /// <summary>
        /// 绑定房价方案
        /// </summary>
        public void BindFJFA()
        {
            DDLfjfa.DataSource = fmfjfa.GetAllList();
            DDLfjfa.DataTextField = "hs_name";
            DDLfjfa.DataValueField = "id";
            DDLfjfa.DataBind();
        }
        /// <summary>
        /// 绑定房价方案
        /// </summary>
        public void BindKRLY()
        {
            DDlkrly.DataSource = fmkrly.GetAllList();
            DDlkrly.DataTextField = "gs_name";
            DDlkrly.DataValueField = "id";
            DDlkrly.DataBind();
        }
        /// <summary>
        /// 绑定房号
        /// </summary>
        public void BindFH()
        {
            Repeaterfj.DataSource = fhBll.GetList("Rn_state=3");
            Repeaterfj.DataBind();

        }

        //把预定的信息绑定到入住信息里面
        public void bindInfo()
        {
            //房型
            Model.book_room bkmodel = bkBll.GetModel(ids);
            Model.room_type rtmodel = fxBll.GetModel( Convert.ToInt32(bkmodel.real_type_id));
            this.ddroomtype.SelectedValue = rtmodel.room_name;          
            //设为不可编辑
            this.ddroomtype.Enabled = false;

            //房价
            this.txt_money.Value = (Convert.ToDouble(bkmodel.real_price)).ToString();

            //姓名
            this.txt_name.Value = bkmodel.book_Name;

            //电话
            this.txt_lxphone.Value = bkmodel.tele_no;

            //预住天数
            this.txt_Day.Value = bkmodel.real_num.ToString();
           
            //时间
            txt_rzdate.Value = System.DateTime.Now.ToString();

        }
        /// <summary>
        ///添加入住信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdds_Click(object sender, EventArgs e)
        {
            CdHotelManage.Model.occu_infor model = new CdHotelManage.Model.occu_infor();
            CdHotelManage.Model.occu_infor models = new CdHotelManage.Model.occu_infor();

            model.occ_no = System.DateTime.Now.ToString().Replace("-", "").Replace(":", "").Replace(" ", "");
            model.room_number = this.txt_roomid.Value;
            model.real_type_id = Convert.ToInt32(this.ddroomtype.SelectedValue);
            model.source_id = Convert.ToInt32(this.DDlkrly.SelectedValue);
            model.real_scheme_id = Convert.ToInt32(this.DDLfjfa.SelectedValue);
            model.real_price = Convert.ToDecimal(this.txt_fjPrice.Value);
            model.occ_with = "否";
            model.real_mode_id = Convert.ToInt32(this.DDlKffs.SelectedValue);
            model.occ_time = Convert.ToDateTime(this.txt_rzdate.Value);
            model.pre_live_day = Convert.ToInt32(this.txt_Day.Value);
            model.depar_time = Convert.ToDateTime(this.txt_ylDate.Value);
            model.occ_name = this.txt_name.Value;
            model.sex = this.txt_Sex.Value;
            model.brithday = this.txt_Date2.Value;
            model.family_name = this.txt_mingzhu.Value;
            model.card_id = Convert.ToInt32(this.DDlSFz.SelectedValue); ;
            model.card_no = (this.txt_CardId.Value);
            model.mem_cardno = this.txt_hycardId.Value;//会员卡号   
            model.remark = this.txt_Remaker.Value;
            model.meth_pay_id = Convert.ToInt32(DDlZffs.SelectedValue);//支付方式
            model.deposit = Convert.ToInt32(txt_yjmoney.Value);
            model.address = txt_address.Value;//地址
            CdHotelManage.BLL.occu_infor bll = new CdHotelManage.BLL.occu_infor();
            CdHotelManage.Model.room_number fh = new CdHotelManage.Model.room_number();
            fh.Rn_state = 2;
            fh.Rn_roomNum = txt_roomid.Value;
            string SQl = "update room_number set Rn_state=2 where Rn_roomNum='" + txt_roomid.Value + "'";
            //  fh.id = fhBll.GetModel(Convert.ToInt32(txt_roomid.Value), "Rn_roomNum"); 
            fhBll.Updates(SQl);

            for (int i = 0; i < hidSchool.Value.Split('|').Length - 1; i++)
            {
                models.occ_name = hidSchool.Value.Split('#')[0];
                models.sex = hidSchool.Value.Split('#')[1];
                models.brithday = hidSchool.Value.Split('#')[2];
                models.card_id = Convert.ToInt32(hidSchool.Value.Split('#')[3]);
                models.card_no = hidSchool.Value.Split('#')[4];
                models.address = hidSchool.Value.Split('#')[5];
                models.occ_time = Convert.ToDateTime(System.DateTime.Now.ToString());
                models.occ_with = "是";
                bll.Add(models);
            }
            if (bll.Add(model) > 0)
            {
                Maticsoft.Common.MessageBox.ShowAndRedirect(this, "保存成功！", "");
            }
            else
            {
                Maticsoft.Common.MessageBox.ShowAndRedirect(this, "保存失败！", "");

            }

        }
        /// <summary>
        /// 多人开房绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBind_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(txt_id.Value);
            Model.room_number mod = new Model.room_number();
            txt_roomid.Value = fhBll.GetModel(id).Rn_roomNum;
            ddroomtype.SelectedValue = (fhBll.GetModel(id).Rn_room).ToString();
            txt_money.Value = (fhBll.GetModel(id).Rn_price).ToString();
            txt_rzdate.Value = System.DateTime.Now.ToString();

        }

        public override void SonLoad()
        {
            if (IsPostBack)
            {
                ids = Convert.ToInt32(Request.QueryString["id"].ToString());
                BindFX();
                bindInfo();
                BindZFFS();
                BindSFZ();
                BindKFFS();
                BindFJFA();
                BindKRLY();
                BindFH();
            }
        }
    }
}