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
    public partial class FloorAdd : System.Web.UI.Page
    {
        BLL.floor_manage fmBll = new BLL.floor_manage();
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
            Model.floor_manage fm = new Model.floor_manage();
            fm.floor_name = a;
           
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
                fm.floor_id = Convert.ToInt32(id);
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
                txt_Flooer.Value = fmBll.GetModel(Convert.ToInt32(id)).floor_name;
            }
        }
    }
}