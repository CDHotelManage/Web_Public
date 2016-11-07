using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.Menus
{
    public partial class RoommoshiAdd : System.Web.UI.Page
    {
        BLL.modes fmshif = new BLL.modes();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
               
                txt_name.Value = fmshif.GetModel(Convert.ToInt32(Request.QueryString["id"].ToString())).moshi_name;
            }
        }
        /// <summary>
        /// 修改班次
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Model.modes modl = new Model.modes();
            modl.moshi_name = txt_name.Value;
            modl.id = Convert.ToInt32(Request.QueryString["id"].ToString());
            if (fmshif.Update(modl))
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('修改成功！');parent.document.getElementById('btnSeach').click();parent.Window_Close();</script>");


            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('修改失败！');</script>");

            }

        }
    }
}