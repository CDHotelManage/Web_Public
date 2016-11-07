using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CdHotelManage.Model;
using CdHotelManage.BLL;


namespace CdHotelManage.Web.Admin.Menus
{
    public partial class RoomTypeAdd : System.Web.UI.Page
    {
        BLL.room_type fmBll = new BLL.room_type();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                Bind();
            }
        }
        /// <summary>
        /// 添加房型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"].ToString();
            Model.room_type fm = new Model.room_type();
            fm.room_name = this.txt_roomName.Value;
            fm.room_listedmoney =Convert.ToDecimal( this.txt_room_listedmoney.Value);
            fm.room_zmmoney =Convert.ToDecimal( this.txt_room_zmmoney.Value);
            fm.room_reamker = this.txt_Reamker.Value;
          
            fm.room_number = "1";
            if (this.raddyes.Checked)
            {
                fm.room_hour = raddyes.Text;
            }
            else 
            {
                fm.room_hour = raddno.Text;
            }
            if (id == "")
            {
                int b = fmBll.Add(fm);
                if (b > 0)
                {
                    Maticsoft.Common.MessageBox.ShowAndRedirect(this, "保存成功！", "");
                }
            }
            else 
            {
                fm.id = Convert.ToInt32(id);
                if (fmBll.Update(fm))
                {
                    Maticsoft.Common.MessageBox.ShowAndRedirect(this, "更新成功！", "");
                }
            }

        }
        public void Bind()
        {
            string id = Request.QueryString["id"].ToString();
            if (id == "")
            {
                return;
            }
            else
            {
                txt_roomName.Value = fmBll.GetModel(Convert.ToInt32(id)).room_name;
                txt_room_listedmoney.Value = ( fmBll.GetModel(Convert.ToInt32(id)).room_listedmoney).ToString();
                txt_room_zmmoney.Value = (fmBll.GetModel(Convert.ToInt32(id)).room_zmmoney).ToString();
                txt_Reamker.Value = (fmBll.GetModel(Convert.ToInt32(id)).room_reamker).ToString();
            }
        }
    }
}