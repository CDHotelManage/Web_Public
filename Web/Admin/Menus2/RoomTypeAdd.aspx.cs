using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CdHotelManage.Model;
using CdHotelManage.BLL;


namespace CdHotelManage.Web.Admin.Menus2
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
            fm.Room_ealry_price = Convert.ToDecimal(txt_lcPrice.Value);
            fm.Room_Moth_price = Convert.ToDecimal(txt_yzprice.Value);
            fm.room_number = "1";
            fm.Room_Bfb = Convert.ToInt32(txt_iscy.Value);
            if (this.raddyes.Checked)
            {
                fm.room_hour = raddyes.Value;
            }
            else 
            {
                fm.room_hour = raddno.Value;
            }
            if (id == "")
            {
                int b = fmBll.Add(fm);
                if (b > 0)
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('保存成功！');parent.Window_Close();</script>");

                }
            }
            else 
            {
                fm.id = Convert.ToInt32(id);
                if (fmBll.Update(fm))
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('修改成功！');parent.Window_Close();</script>");
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
                txt_room_listedmoney.Value = Convert.ToDecimal(fmBll.GetModel(Convert.ToInt32(id)).room_listedmoney).ToString("0.##");
                txt_room_zmmoney.Value = Convert.ToDecimal(fmBll.GetModel(Convert.ToInt32(id)).room_zmmoney).ToString("0.##");
                txt_Reamker.Value = (fmBll.GetModel(Convert.ToInt32(id)).room_reamker).ToString();
                txt_lcPrice.Value = Convert.ToDecimal(fmBll.GetModel(Convert.ToInt32(id)).Room_ealry_price).ToString("0.##");
                txt_yzprice.Value = Convert.ToDecimal(fmBll.GetModel(Convert.ToInt32(id)).Room_Moth_price).ToString("0.##");
                txt_iscy.Value = (fmBll.GetModel(Convert.ToInt32(id)).Room_Bfb).ToString();
                if ((fmBll.GetModel(Convert.ToInt32(id)).room_hour == "允许"))
                {
                    raddyes.Checked = true;
                }
                else {
                    raddno.Checked = true;
                }
            }
        }
    }
}