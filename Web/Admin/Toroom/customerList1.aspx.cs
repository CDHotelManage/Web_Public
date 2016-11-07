using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.Toroom
{
    public partial class customerList1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {

                if (Request.QueryString["orderids"] != null)
                {
                    orderids.Value = Request.QueryString["orderids"].ToString();
                }
                if (Request.QueryString["type"] != null) {
                    if (Request.QueryString["type"] == "selectCou")
                    {
                        type.Value = "selectCou";
                    }
                }

                BindcusType();
                BindState();
                BindIndustry();
                Bindsource();
                Bind();
            }
        }

        protected void cusTypechange(object sender, EventArgs e){
            Bind();
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            Bind();
        }

        BLL.customer bllcus = new BLL.customer();
        private void Bind()
        { string where=string.Empty;
            if (Request.QueryString["not"] != null)//如果是转帐进去
            {
                where = "accounts not in('" + Request.QueryString["not"] + "') ";
            }
            else
            {
                where = "1 = 1 ";
            }
            if (Word.Value != "")
            {
                where += "and accounts like '%" + Word.Value + "%' or cName like '%" + Word.Value + "%' or cPhone like '%" + Word.Value + "%' or companyPhone like '%" + Word.Value + "%'";
            }
            List<Model.customer> list = bllcus.GetModelList(where);
            if (cusType.SelectedValue != "0")
            {
                list = list.Where(d => Convert.ToInt32(d.cusType) == Convert.ToInt32(cusType.SelectedValue)).ToList();
            }
            if (Cstate.SelectedValue != "0")
            {
                list = list.Where(d => Convert.ToInt32(d.Cstate) == Convert.ToInt32(Cstate.SelectedValue)).ToList();
            }
            if (cIndustry.SelectedValue != "0")
            {
                list = list.Where(d => Convert.ToInt32(d.cindustry) == Convert.ToInt32(cIndustry.SelectedValue)).ToList();
            }
            if (Csource.SelectedValue != "0")
            {
                list = list.Where(d => Convert.ToInt32(d.Csource) == Convert.ToInt32(Csource.SelectedValue)).ToList();
            }
            rep1.DataSource = list;
            rep1.DataBind();
        }

        #region 绑定所有下拉框
       
        
        /// <summary>
        /// 绑定客户类型
        /// </summary>
        private void BindcusType()
        {
            BLL.customerType bllct = new BLL.customerType();
            cusType.DataSource = bllct.GetAllList();
            cusType.DataTextField = "ctName";
            cusType.DataValueField = "ID";
            cusType.DataBind();
            cusType.Items.Insert(0, new ListItem("全部", "0"));
        }

        /// <summary>
        /// 绑定客户状态
        /// </summary>
        private void BindState()
        {
            BLL.customerState bllct = new BLL.customerState();
            Cstate.DataSource = bllct.GetAllList();
            Cstate.DataTextField = "csName";
            Cstate.DataValueField = "ID";
            Cstate.DataBind();
            Cstate.Items.Insert(0, new ListItem("全部", "0"));
        }

        /// <summary>
        /// 绑定客户状态
        /// </summary>
        private void BindIndustry()
        {
            BLL.cIndustry bllct = new BLL.cIndustry();
            cIndustry.DataSource = bllct.GetAllList();
            cIndustry.DataTextField = "csName";
            cIndustry.DataValueField = "ID";
            cIndustry.DataBind();
            cIndustry.Items.Insert(0, new ListItem("全部", "0"));
        }
        /// <summary>
        /// 绑定客户来源
        /// </summary>
        private void Bindsource()
        {
            BLL.guest_source bllct = new BLL.guest_source();
            Csource.DataSource = bllct.GetAllList();
            Csource.DataTextField = "gs_name";
            Csource.DataValueField = "ID";
            Csource.DataBind();
            Csource.Items.Insert(0, new ListItem("全部", "0"));
        }
        #endregion
        #region 获得数据

        protected string GetState(int id)
        {
            BLL.customerState bllcs = new BLL.customerState();
            return bllcs.GetModel(id).csName;
        }

        protected string GetCtName(int id)
        {
            BLL.customerType bllcs = new BLL.customerType();
            return bllcs.GetModel(id).ctName;
        }

        protected string GetIdName(int id)
        {
            BLL.cIndustry bllcs = new BLL.cIndustry();
            return bllcs.GetModel(id).csName;
        }
        #endregion
    }
}