using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace CdHotelManage.Web.Admin.Menus
{
    public partial class ShopBanc : System.Web.UI.Page
    {
        BLL.Shift fmshif = new BLL.Shift();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                BindGV();
            }
        }
         /// <summary>
        /// 添加班次
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Model.Shift modl = new Model.Shift();
            modl.shfit_name = txt_name.Value;
            if (fmshif.Add(modl) > 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('保存成功！');</script>");


            }
            else 
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('保存失败！');</script>");

            }
            btnSeach_Click(null, null);
        
        }
        public void BindGV() 
        {
            DivHtml.InnerHtml = "";
            string Div = "";

              DataSet dt  = fmshif.GetAllList();
              foreach (DataRow dr in dt.Tables[0].Rows)
              {
                  Div += "<div class='lin'><span>" + dr["shfit_name"] + "<span onclick=\"OpenBc(this," + dr["shift_id"].ToString() + ")\" style='padding-top:3px;padding-left:5px;'><img style='width:15px;height:15px;' src=\"../../images/iconbj.png\" /></span> <em onclick=\"BookEancel(" + dr["shift_id"].ToString() + ",0)\">x</em></div>";
              }
              DivHtml.InnerHtml = Div;
           
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btndelete_Click(object sender, EventArgs e)
        {
            bool Result= fmshif.Delete(Convert.ToInt32(txt_id.Value));
           
            if (Result)
            {
                txt_name.Value = "";
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('删除成功！');</script>");

            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('删除失败！');</script>");
            }
            btnSeach_Click(null,null);
        }

        protected void btnSeach_Click(object sender, EventArgs e)
        {
            BindGV();
        }
    }
}