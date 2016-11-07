using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.Toroom
{
    public partial class Remaker : System.Web.UI.Page
    {
        BLL.Remaker fmremaker = new BLL.Remaker();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                if (Request.QueryString["type"] != null)
                {
                    hidtype.Value = Request.QueryString["type"];
                }
                try {
                    string id = Request.QueryString["id"].ToString();
                    txt_remaker.Value = fmremaker.GetModel(Convert.ToInt32(id)).remaker;
                    
                }
                catch { }
            }
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdds_Click(object sender, EventArgs e)
        {
            Model.Remaker model = new Model.Remaker();
            model.remaker = txt_remaker.Value;
            model.type = Convert.ToInt32(hidtype.Value);
            try
            {
                string id = Request.QueryString["id"].ToString();
                model.id =Convert.ToInt32(id);
                
                if (fmremaker.Update(model))
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript'>alert('更新成功');parent.document.getElementById('btnsercher').click();parent.Window_Close();</script>");
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript'>alert('更新失败');</script>");

                }
            }
            catch
            {
                if (fmremaker.Add(model) > 0)
                {

                    ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript'>alert('保存成功');parent.document.getElementById('btnsercher').click();parent.Window_Close();</script>");

                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript'>alert('保存失败');</script>");

                }
            }
        }
    }
}