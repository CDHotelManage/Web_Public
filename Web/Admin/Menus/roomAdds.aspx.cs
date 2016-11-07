using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.Menus
{
    public partial class roomAdds : System.Web.UI.Page
    {
        BLL.floor_manage fmBll = new BLL.floor_manage();
        BLL.room_type fxBll = new BLL.room_type();
        BLL.room_number fhBll = new BLL.room_number();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
            frmfh.Rn_price = Convert.ToDecimal( txt_money.Value);
            if (id == "")
            {
                int Result = fhBll.Add(frmfh);
                if (Result > 0)
                {
                    Maticsoft.Common.MessageBox.ShowAndRedirect(this, "保存成功！", "");
                }
            }
            else 
            {
                frmfh.id = Convert.ToInt32(id);
                if (fhBll.Update(frmfh))
                {
                    Maticsoft.Common.MessageBox.ShowAndRedirect(this, "更新成功！", "");
                }
            }
            
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
                string a = (fhBll.GetModel(Convert.ToInt32(id)).Rn_floor);
                txt_roomid.Value = fhBll.GetModel(Convert.ToInt32(id)).Rn_roomNum;
                DDlouc.SelectedValue = (fhBll.GetModel(Convert.ToInt32(id)).Rn_floor).ToString();
                ddroomtype.SelectedValue = (fhBll.GetModel(Convert.ToInt32(id)).Rn_room).ToString();
                txt_money.Value = (fhBll.GetModel(Convert.ToInt32(id)).Rn_price).ToString();
                txt_Reamker.Value = (fhBll.GetModel(Convert.ToInt32(id)).Rn_remaker).ToString();
            }
        }
    }
}