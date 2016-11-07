using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.Menus2
{
    public partial class roomAdds : System.Web.UI.Page
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
                
               string id = Request.QueryString["id"].ToString();
               if (id != "")
               {
                   Bind();
                  
               }  
             
            }
        }
        /// <summary>
        /// 绑定楼层
        /// </summary>
        public void BindLC() 
        {
            DDlouc.DataSource = fmBll.GetList("floor_sorting=" + DDlLD.SelectedValue);
            DDlouc.DataBind();
           // DDlouc.Items.Insert(0, "请选择楼层");
        }



        public void BindLD()
        {
            DDlLD.DataSource = fmld.GetAllList();
            DDlLD.DataBind();
        }

        protected void ddlldSelect(object sender,EventArgs e) {
            BindLC();
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
        /// 添加房号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"].ToString();
            Model.room_number frmfh = new Model.room_number();
            frmfh.Rn_roomNum = txt_roomid.Value;
            frmfh.Rn_floor = DDlouc.SelectedValue;
            frmfh.Rn_room = ddroomtype.SelectedValue;
            frmfh.Rn_remaker = txt_Reamker.Value;
            frmfh.Rn_Type = 1;
            frmfh.Rn_flloeld = DDlLD.SelectedValue;
            frmfh.Rn_state = 3;
            frmfh.Rn_price = Convert.ToDecimal( txt_money.Value);
            if (id == "")
            {
                if (!IsCuzai(frmfh.Rn_roomNum))
                {
                    int Result = fhBll.Add(frmfh);
                    if (Result > 0)
                    {
                        ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('保存成功');parent.Window_Close();</script>");

                    }

                }
                else {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('该房号已经存在！');</script>");
                }
               
            }
            else 
            {
                frmfh.id = Convert.ToInt32(id);
                if (fhBll.Update(frmfh))
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('更新成功');parent.Window_Close();</script>");
                }
            }
            
        }

        private bool IsCuzai(string roomnumber)
        {
            List<Model.room_number> listroom = fhBll.GetModelList("Rn_roomNum='" + roomnumber + "'");
            if (listroom.Count > 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 绑定房型数据
        /// </summary>
        public void Bind()
        {
            string id = Request.QueryString["id"].ToString();
            if (id == "")
            {
                return;
            }
            else
            {
                string b = (fhBll.GetModel(Convert.ToInt32(id)).Rn_flloeld);
                string a = (fhBll.GetModel(Convert.ToInt32(id)).Rn_floor);
                txt_roomid.Value = fhBll.GetModel(Convert.ToInt32(id)).Rn_roomNum;
                DDlouc.SelectedValue = (fhBll.GetModel(Convert.ToInt32(id)).Rn_floor).ToString();
                ddroomtype.SelectedValue = (fhBll.GetModel(Convert.ToInt32(id)).Rn_room).ToString();
                txt_money.Value = (fhBll.GetModel(Convert.ToInt32(id)).Rn_price).ToString();
                txt_Reamker.Value = (fhBll.GetModel(Convert.ToInt32(id)).Rn_remaker).ToString();
                DDlLD.SelectedValue = (fhBll.GetModel(Convert.ToInt32(id)).Rn_flloeld);
            }
        }
        /// <summary>
        /// 绑定价格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddroomtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_money.Value = fxBll.GetModel(Convert.ToInt32(ddroomtype.SelectedValue)).room_listedmoney.ToString();

        }
    }
}