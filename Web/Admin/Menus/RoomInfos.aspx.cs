using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CdHotelManage.Model;
using CdHotelManage.BLL;
using System.Data;

namespace CdHotelManage.Web.Admin.Menus
{
    public partial class RoomInfos : System.Web.UI.Page
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
                BindFH();
            }
        }
        /// <summary>
        /// 添加楼层
        /// </summary>
        public void BindLC() 
        { 
            Repeaterlc.DataSource = fmBll.GetAllList();
            Repeaterlc.DataBind();
        }
        /// <summary>
        /// 添加房型
        /// </summary>
        public void BindFX() 
        {

            Repeaterfx.DataSource = fxBll.GetAllList();
            Repeaterfx.DataBind();
        }
        /// <summary>
        /// 添加房号
        /// </summary>
        public void BindFH() 
        {
            Repeaterfh.DataSource = fhBll.GetAllList();
            Repeaterfh.DataBind();

        }
        public string getstyle(string state)
        {

            string style = "";
            if (state == "")
            {
                return "bgblue";
            }
            else 
            {
                return "bgblue";
            }

        }
        /// <summary>
        /// 删除语句
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btndelete_Click(object sender, EventArgs e)
        {
            Model.floor_manage fm=new Model.floor_manage();
            int id=Convert.ToInt32(txt_id.Value);   
            if ( fmBll.Delete(id)) 
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('删除成功');</script>");
                BindLC();
            }
        }
        /// <summary>
        /// 删除房型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btndelete1_Click(object sender, EventArgs e)
        {
            Model.room_type fm = new Model.room_type();
            int id = Convert.ToInt32(txt_fxid.Value);
            if (fxBll.Delete(id))
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('删除成功');</script>");
                BindFX();
            }
        }
        /// <summary>
        /// 删除房间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btndelete2_Click(object sender, EventArgs e)
        {
            Model.room_number fm = new Model.room_number();
            int id = Convert.ToInt32(txt_fj.Value);
            if (fhBll.Delete(id))
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('删除成功');</script>");
                BindFH();
            }
        }
    }
}