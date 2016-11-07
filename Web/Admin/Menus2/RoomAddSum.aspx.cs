using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.Menus2
{
    public partial class RoomAddSum : System.Web.UI.Page
    {
        BLL.floor_manage fmBll = new BLL.floor_manage();
        BLL.room_type fxBll = new BLL.room_type();
        BLL.room_number fhBll = new BLL.room_number();
        BLL.floor_ld fmld = new BLL.floor_ld();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindLD();
                BindLC();
                BindFX();
                
                txt_modth.Value = fxBll.GetModel(Convert.ToInt32(ddroomtype.SelectedValue)).Room_Moth_price.ToString();
                txt_lc.Value = fxBll.GetModel(Convert.ToInt32(ddroomtype.SelectedValue)).Room_ealry_price.ToString();
            }
        }
        protected void ddlldSelect(object sender, EventArgs e)
        {
            BindLC();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Model.room_number model = new Model.room_number();
          
            //string stayroomNum = txt_stay.Value.Substring(txt_stay.Value.Length - 1, 1);
            //string endnum = txt_end.Value.Substring(txt_end.Value.Length - 1, 1);
            int count = 0;
            int number = Convert.ToInt32(txt_stay.Value);
            int Addlength = Convert.ToInt32(txt_end.Value) - Convert.ToInt32(txt_stay.Value);
            for (int i = 0; i <= Addlength; i++)
            {
                model.Rn_price = Convert.ToDecimal(txt_money.Value);
                model.Rn_flloeld = DDlLD.SelectedValue;
                model.Rn_floor = DDlouc.SelectedValue;
                model.Rn_room = ddroomtype.SelectedValue;
                model.Rn_Type = 1;
                model.Rn_state = 3;
                model.Rn_remaker = "";
                model.Rn_Tobe = 0;
                if (i == 0)
                {
                    model.Rn_roomNum =txt_A.Value+ txt_stay.Value;
                }
                else
                {
                    number++;
                    if (number < 10)
                    {
                        model.Rn_roomNum = txt_A.Value + "0" + (number).ToString();
                    }
                    else {
                        model.Rn_roomNum = txt_A.Value + (number).ToString();
                    }
                    
                }
                string endnum = model.Rn_roomNum.Substring(model.Rn_roomNum.Length - 1, 1);
                if (txt_roomws.Value.Trim().Contains(endnum))
                {

                }
                else
                {
                    if (!IsCuzai(model.Rn_roomNum))
                    {
                        fhBll.Add(model);
                    }
                }   
                  
                count++;
            }
            if (count > 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('保存成功');parent.Window_Close();</script>");
            }
            else 
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('保存失败');</script>");

            }
        }


        private bool IsCuzai(string roomnumber) {
            List<Model.room_number> listroom = fhBll.GetModelList("Rn_roomNum='" + roomnumber + "'");
            if (listroom.Count > 0) {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 绑定楼层
        /// </summary>
        public void BindLC()
        {
            DDlouc.DataSource = fmBll.GetAllList();
            DDlouc.DataBind();
            // DDlouc.Items.Insert(0, "请选择楼层");
        }
        /// <summary>
        /// 绑定房型
        /// </summary>
        public void BindFX()
        {
            ddroomtype.DataSource = fxBll.GetAllList();
            ddroomtype.DataBind();
            txt_money.Value = fxBll.GetModel(Convert.ToInt32(ddroomtype.SelectedValue)).room_listedmoney.ToString();
            // ddroomtype.Items.Insert(0, "请选择房型");
        }
        /// <summary>
        /// 绑定楼栋
        /// </su
        public void BindLD()
        {
            DDlLD.DataSource = fmld.GetAllList();
            DDlLD.DataBind();
        }
        /// <summary>
        /// 房型绑定价格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddroomtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_money.Value = fxBll.GetModel(Convert.ToInt32(ddroomtype.SelectedValue)).room_listedmoney.ToString();
            txt_modth.Value = fxBll.GetModel(Convert.ToInt32(ddroomtype.SelectedValue)).Room_Moth_price.ToString();
            txt_lc.Value = fxBll.GetModel(Convert.ToInt32(ddroomtype.SelectedValue)).Room_ealry_price.ToString();
        }
    }
}