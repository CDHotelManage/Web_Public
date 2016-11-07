using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.Menus
{
    public partial class GoodsAdds : System.Web.UI.Page
    {
        BLL.Goods fmshif = new BLL.Goods();
        BLL.cost_type fmcost = new BLL.cost_type();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string a = Request.QueryString["id"].ToString();
                string types = (Request.QueryString["type"].ToString());
                if (types == "0")
                {
                    Label1.Text = "商品名称";
                    txt_name.Value = fmshif.GetModel(Convert.ToInt32(Request.QueryString["id"].ToString())).Goods_name;
                }
                else
                {
                    Label1.Text = "费用名称";
                    txt_name.Value = fmcost.GetModel(Convert.ToInt32(Request.QueryString["id"].ToString())).ct_name;
                }

            }
        }
        /// <summary>
        /// 修改类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Model.Goods modl = new Model.Goods();
            Model.cost_type models = new Model.cost_type();
            string types = (Request.QueryString["type"].ToString());
            bool result;
            if (types == "0")
            {
                modl.Goods_name = txt_name.Value;
                modl.id = Convert.ToInt32(Request.QueryString["id"].ToString());
                modl.Goods_number = fmshif.GetModel(Convert.ToInt32(Request.QueryString["id"].ToString())).Goods_number;
                modl.Goods_ifType = 0;
                result=fmshif.Update(modl);
            }
            else 
            {
                models.ct_name = txt_name.Value;
                models.id = Convert.ToInt32(Request.QueryString["id"].ToString());
                models.ct_iftype = 0;
                models.ct_number = fmcost.GetModel(Convert.ToInt32(Request.QueryString["id"].ToString())).ct_number;
                result=fmcost.Update(models);
            }
            if (result)
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('修改成功！');parent.Window_Close();</script>");


            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('修改失败！');</script>");

            }

        }
    }
}