using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.Menus
{
    public partial class shoppingInfo : System.Web.UI.Page
    {
        BLL.shopInfo fmshop = new BLL.shopInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();

            }
        }

        private void Bind() {
            List<Model.shopInfo> shopmodel = fmshop.GetModelList("");
            if (shopmodel.Count > 0) {
                string[] strs = Request.Form.GetValues("s_province");
                string[] strs1 = Request.Form.GetValues("s_city");
                string[] strs2 = Request.Form.GetValues("s_county");
                Model.shopInfo modelinfo = shopmodel[0];
                txtName.Value = modelinfo.shop_Name;
                txtContactName.Value = modelinfo.shop_LxMan;
                txtPhone.Value = modelinfo.Shop_Telphone;
                txtFax.Value = modelinfo.Shop_chuanzen;
                sc.Value = modelinfo.Shop_City;
                sp.Value = modelinfo.Shop_Province;
                sc1.Value = modelinfo.Shop_Area;
                txtAddress.Value = modelinfo.Shop_Address;
                txtMapX.Value = modelinfo.Shop_x;
                txtMapY.Value = modelinfo.Shop_y;
                Discription.Value = modelinfo.Shop_Remaker;
                txtid.Value = modelinfo.id.ToString();
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnsave_Click(object sender, EventArgs e)
        {
            
            Model.shopInfo fmInfo = new Model.shopInfo();
            fmInfo.id = txtid.Value;
            fmInfo.shop_Name = txtName.Value;
            fmInfo.shop_LxMan = txtContactName.Value;
            fmInfo.Shop_Telphone = txtPhone.Value;
            fmInfo.Shop_chuanzen = txtFax.Value;
            fmInfo.Shop_City = sc.Value;
            fmInfo.Shop_Province = sp.Value;
            fmInfo.Shop_Address = txtAddress.Value;
            fmInfo.Shop_Area = sc1.Value;
            fmInfo.Shop_x = txtMapX.Value;
            fmInfo.Shop_y = txtMapY.Value;
            fmInfo.Shop_Remaker = Discription.Value;
            if (fmshop.Update(fmInfo))
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('保存成功！系统刷新后生效！');</script>");

            }
            else 
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('保存失败！');</script>");
            }
        }
    }
}