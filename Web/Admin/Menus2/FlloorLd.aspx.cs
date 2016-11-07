using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.Menus2
{
    public partial class FlloorLd : System.Web.UI.Page
    {
        BLL.floor_ld fmBll = new BLL.floor_ld();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                Bind();
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"].ToString();
            string a = this.txt_Flooer.Value;
            Model.floor_ld fm = new Model.floor_ld();
            fm.ld_Name = a;

            if (id == "")
            {
                int b = fmBll.Add(fm);
                if (b > 0)
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('保存成功');parent.Window_Close();</script>");
                }
            }
            else
            {
                fm.id = Convert.ToInt32(id);
                if (fmBll.Update(fm))
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('更新成功');parent.Window_Close();</script>");
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
                txt_Flooer.Value = fmBll.GetModel(Convert.ToInt32(id)).ld_Name;
            }
        }
    }
}