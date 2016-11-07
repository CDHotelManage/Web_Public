using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CdHotelManage.Model;
using CdHotelManage.BLL;
using System.Data;

namespace CdHotelManage.Web.Admin.Menus2
{
    public partial class RoomInfos : System.Web.UI.Page
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
               
            }
        }
        /// <summary>
        /// 添加楼d
        /// </summary>
        public void BindLD() 
        {
            Repeater1.DataSource = fmld.GetAllList();
            Repeater1.DataBind();
        }
        /// <summary>
        /// 添加楼层
        /// </summary>
        public void BindLC()
        {
            Repeaterlc.DataSource =fmBll .GetAllList();
            Repeaterlc.DataBind();
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
            Model.floor_ld fm = new Model.floor_ld();
            int id = Convert.ToInt32(txt_fxid.Value);
            if (fmld.Delete(id))
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('删除成功');</script>");
                BindLD();
            }
        }
    }
}