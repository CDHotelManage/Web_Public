using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.Menus2
{
    public partial class fjfaAdd : System.Web.UI.Page
    {
        BLL.hourse_scheme fmshif = new BLL.hourse_scheme();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                Bind();
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Model.hourse_scheme modl = new Model.hourse_scheme();
            modl.hs_name = txt_name.Value;
            modl.hs_Discount = txt_zkfa.Value;
            modl.id = Convert.ToInt32(Request.QueryString["id"].ToString());
            if (fmshif.Update(modl))
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('修改成功！');parent.Window_Close();</script>");


            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('修改失败！');</script>");

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
                txt_name.Value = fmshif.GetModel(Convert.ToInt32(id)).hs_name;
                txt_zkfa.Value = fmshif.GetModel(Convert.ToInt32(id)).hs_Discount;
            }
        }
    }
}