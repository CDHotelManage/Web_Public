using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.Menus
{
    public partial class GoodsPriceAdds : System.Web.UI.Page
    {
        BLL.Goods fmcost = new BLL.Goods();
        public string ids
        {

            get { return (string)ViewState["ids"]; }

            set { ViewState["ids"] = value; }

        }
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                ids = Request.QueryString["id"].ToString();
                BindFYLB();
                if (Request.QueryString["type"].ToString() == "1") 
                {
                    BindEdit();
                }
            }
        }
        /// <summary>
        /// 绑定费用类别
        /// </summary>
        public void BindFYLB()
        {
            // DataSet dt = fmcost.GetList(" Goods_ifType=0");
            DDlfylb.DataSource = fmcost.GetList(" Goods_ifType=0");
            DDlfylb.DataValueField = "id";
            DDlfylb.DataTextField = "Goods_name";
            DDlfylb.DataBind();
            DDlfylb.Items.Insert(0, "请选择费用类别");

        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"].ToString();
            Model.Goods frmtype = new Model.Goods();
            frmtype.Goods_number = txtBH.Value;
            frmtype.Goods_name = txtName.Value;
            frmtype.Goods_ifType = 1;
            frmtype.Goods_unit = txt_unit.Value;
            if (txt_Jf.Value == "")
            {
                frmtype.Goods_jf = 0;
            }
            else
            {
                frmtype.Goods_jf = Convert.ToInt32(txt_Jf.Value);
            }
            frmtype.Goods_categories = Convert.ToInt32( DDlfylb.SelectedValue);
            frmtype.Goods_price = Convert.ToDecimal(txtPrice.Value);
            if (radStatu.Checked == true)
            {
                frmtype.Goods_state = radStatu.Value;
            }
            else 
            {
                frmtype.Goods_state = radStatus.Value;
            }
            // frmtype.Goods_categories = Convert.ToInt32(DDlfylb.SelectedValue);
            if (id == "")
            {
                int Result = fmcost.Add(frmtype);
                if (Result > 0)
                {
                    //Maticsoft.Common.MessageBox.ShowAndRedirect(this, "保存成功！", "");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "click", "alert('保存成功');parent.Window_Close();", true);

                }
            }
            else
            {
                frmtype.id = Convert.ToInt32(id);
                if (fmcost.Update(frmtype))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "click", "alert('更新成功');parent.Window_Close();", true);
                }
            }
        }

        public void BindEdit()
        {
            txtName.Value = fmcost.GetModel(Convert.ToInt32(ids)).Goods_name;
            txtBH.Value = fmcost.GetModel(Convert.ToInt32(ids)).Goods_number;
            txtPrice.Value = Convert.ToDecimal(fmcost.GetModel(Convert.ToInt32(ids)).Goods_price).ToString("0.##");
            txtRemark.Value = fmcost.GetModel(Convert.ToInt32(ids)).Goods_Remaker;
            txt_unit.Value = fmcost.GetModel(Convert.ToInt32(ids)).Goods_unit;
            txt_Jf.Value = fmcost.GetModel(Convert.ToInt32(ids)).Goods_jf.ToString();
            DDlfylb.SelectedValue = fmcost.GetModel(Convert.ToInt32(ids)).Goods_categories.ToString();
            if (fmcost.GetModel(Convert.ToInt32(ids)).Goods_state == "使用")
            {
                radStatus.Checked = true;
            }
            else 
            {
                radStatu.Checked = true;
            }
        }
        public void BindNumber()
        {
            string MaxNumber = fmcost.GetMaxNumber(" where Goods_categories=" + DDlfylb.SelectedValue + " and Goods_ifType=1").ToString().Trim();
            //string numbers = fmcost.GetModels(" where Goods_categories=" + DDlfylb.SelectedValue + " and Goods_ifType=1 ").Goods_number;
            string number = fmcost.GetModel(Convert.ToInt32(DDlfylb.SelectedValue)).Goods_number;
            if (MaxNumber == "1")
            {
                txtBH.Value = number + "001";
            }
            else
            {

                txtBH.Value = "000" + (Convert.ToInt32(MaxNumber) + 1).ToString();
            }
        }

        protected void DDlfylb_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindNumber();
        }
    }
}