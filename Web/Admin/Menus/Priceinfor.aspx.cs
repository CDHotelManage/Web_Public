using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace CdHotelManage.Web.Admin.Menus
{
    public partial class Priceinfor : System.Web.UI.Page
    {
        BLL.cost_type fmcost = new BLL.cost_type();
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
           // DataSet dt = fmcost.GetList(" ct_iftype=0");
            DDlfylb.DataSource = fmcost.GetList(" ct_iftype=0");
            DDlfylb.DataValueField = "id";
            DDlfylb.DataTextField = "ct_name";
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
            Model.cost_type frmtype = new Model.cost_type();
            frmtype.ct_number = txtBH.Value;
            frmtype.ct_name = txtName.Value;
            frmtype.ct_iftype = 1;
            frmtype.ct_money = Convert.ToDecimal(txtPrice.Value);
            frmtype.ct_categories=  Convert.ToInt32( DDlfylb.SelectedValue);
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
            txtName.Value = fmcost.GetModel(Convert.ToInt32(ids)).ct_name;
            txtBH.Value = fmcost.GetModel(Convert.ToInt32(ids)).ct_number;
            txtPrice.Value = Convert.ToDecimal(fmcost.GetModel(Convert.ToInt32(ids)).ct_money).ToString("0.##");
            txtRemark.Value = fmcost.GetModel(Convert.ToInt32(ids)).ct_remark;
             

        }
        public void BindNumber() 
        {
            string MaxNumber = fmcost.GetMaxNumber(" where ct_categories="+DDlfylb.SelectedValue+" and ct_iftype=1").ToString().Trim();
            string numbers = fmcost.GetModels(" where ct_categories=" + DDlfylb.SelectedValue + " and ct_iftype=1 ").ct_number;
            string number = fmcost.GetModel( Convert.ToInt32(DDlfylb.SelectedValue)).ct_number;
            if (MaxNumber == "1")
            {
                txtBH.Value = number + "001";
            }
            else 
            {

                txtBH.Value = "000"+(Convert.ToInt32(MaxNumber) + 1).ToString();
            }
        }

        protected void DDlfylb_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindNumber();
        }
    }
}