using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.Common;
using LTP.Accounts.Bus;

namespace CdHotelManage.Web.Admin.ShiftExc
{
    public partial class HistoryShiftExc :BasePage
    {
        BLL.goods_account gaBll = new BLL.goods_account();
        BLL.Shift sBll = new BLL.Shift();
        BLL.Shift_Exc seBll = new BLL.Shift_Exc();
        BLL.AccountsUsersBLL auBll = new BLL.AccountsUsersBLL();
        public double Sum = 0;
        private int pageSize = 10;
        private int pageIndex = 1;
        public string strWhere
        {

            get { return (string)ViewState["strWhere"]; }

            set { ViewState["strWhere"] = value; }

        }
        public string strWheres
        {

            get { return (string)ViewState["strWheres"]; }

            set { ViewState["strWheres"] = value; }

        }
        public string styid
        {

            get { return (string)ViewState["styid"]; }

            set { ViewState["styid"] = value; }

        }
        public void MethPaySumDataBind()
        {
            //根据用户登录ID 查询
            //string strWhere = Session["UserID"].ToString();
            
          
            Strwheres();
            //绑定GridView1数据源
            GridView1.DataSource = seBll.GeMethPaySumMoney(strWhere + "  and a.ga_price!='0'");
            GridView1.DataBind();

            //根据查询条件算总合计
            DataSet ds = seBll.GeMethPaySumMoney(strWhere + " and a.ga_price!='0'");
            foreach (DataRow row in ds.Tables[0].Rows)
            {

                Sum += Convert.ToDouble(row["ga_sum_price"].ToString());
                Session["Sum"] = Sum;
            }

            ////明细的数据显示出当前用户所有
            //string strWhere2 = " WHERE 1=1 ";
            //strWhere2 += " AND  ga_people = '" + strWhere + "'";
            //GridView2.DataSource = gaBll.GeMethPayMoney(strWhere2);
            //GridView2.DataBind();
          


        }

        //明细数据分页
        public void GridView2DataBind(int pageSize, int pageindex)
        {
            string sort = "ga_zffs_id";
            string order = "DESC";
            stwhere();
            int currentPage = Pager.CurrentPageIndex;

            this.GridView2.DataSource = seBll.GeMethPayMoneyPage(sort, order, currentPage, pageSize, strWheres + " and ga_price!='0'");
            GridView2.DataBind();

            Pager.RecordCount = seBll.GetRecordCount(strWheres + " and ga_price!='0'");
            Pager.ShowCustomInfoSection = Wuqi.Webdiyer.ShowCustomInfoSection.Right;
            Pager.PageSize = pageSize;
            Pager.CurrentPageIndex = pageindex;
            if (Pager != null)
            {
                if (Pager.RecordCount != 0)
                {
                    Pager.ShowPageIndex = true;
                    Pager.ShowDisabledButtons = true;
                    Pager.CustomInfoSectionWidth = new System.Web.UI.WebControls.Unit("40%");
                    Pager.ShowPageIndexBox = Wuqi.Webdiyer.ShowPageIndexBox.Always;
                    Pager.CustomInfoHTML = "&nbsp;记录总数：<b>" + Pager.RecordCount.ToString() + "</b>";
                    Pager.CustomInfoHTML += " 总页数：<b>" + Pager.PageCount.ToString() + "</b>";
                    Pager.CustomInfoHTML += " 当前页：<font color=\"red\"><b>" + Pager.CurrentPageIndex.ToString() + "</b></font>";
                }
                else
                {
                    Pager.ShowPageIndex = false;
                    Pager.ShowDisabledButtons = false;
                    Pager.ShowPageIndexBox = Wuqi.Webdiyer.ShowPageIndexBox.Never;
                    Pager.CustomInfoSectionWidth = new System.Web.UI.WebControls.Unit("100%");
                    Pager.CustomInfoHTML = "<div class='norecord'><span>当前无记录</span></div>";

                }
            }

            return;
        }

        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            GridView2DataBind(pageSize, Pager.CurrentPageIndex);
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "m_over(this);");
                e.Row.Attributes.Add("onmouseout", "m_out(this);");
            }

        }
        public void Strwheres() 
        {
            strWhere = "where 1 = 1";

            if (this.UserDdl.SelectedIndex != 0)
            {
                strWhere += "and a.UserId = '" + Convert.ToInt32(this.UserDdl.SelectedValue) + "'";
            }

            if (this.ShiftDdl.SelectedIndex != 0)
            {
                strWhere += "and a.shift_id = '" + Convert.ToInt32(this.ShiftDdl.SelectedValue) + "'";
            }
            if (this.date.Value.Trim().Length > 0)
            {
                strWhere += "and  convert(varchar(100), a.shift_dateTime, 23) = '" + this.date.Value.Trim() + "'";
            }    

        }
        public void stwhere() 
        {
            strWheres = "where 1 = 1";
            if (this.UserDdl.SelectedIndex != 0)
            {
                strWheres += "and UserId = '" + Convert.ToInt32(this.UserDdl.SelectedValue) + "'";
            }

            if (this.ShiftDdl.SelectedIndex != 0)
            {
                strWheres += "and shift_id = '" + Convert.ToInt32(this.ShiftDdl.SelectedValue) + "'";
            }
            if (this.date.Value.Trim().Length > 0)
            {
                strWheres += "and  convert(varchar(100), shift_dateTime, 23) = '" + this.date.Value.Trim() + "'";
            }
            if (styid != "")
            {
                strWheres += " and ga_zffs_id=" + styid + "";
            }
        }
        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            styid = (GridView1.DataKeys[e.NewSelectedIndex].Value.ToString());
            GridView2DataBind(pageSize, Pager.CurrentPageIndex);
            MethPaySumDataBind();
            //string strWhere = " WHERE 1=1 ";
            //strWhere += " AND ga_zffs_id = '" + id + "'";
            ////待修改 admin 替换成Session["UserID"]
            //strWhere += " AND ga_people  = '8'";
            //GridView2.DataSource = gaBll.GeMethPayMoney(strWhere);
            //GridView2.DataBind();
        }

        //获取支付方式中文名称
        public string GetRealTypeName(object id)
        {
            if (id.ToString() == "")
            {
                return "";
            }
            BLL.meth_pay mpBll = new BLL.meth_pay();
            Model.meth_pay model = mpBll.GetModel(Convert.ToInt32(id.ToString()));
            return model.meth_pay_name;

        }

        //绑定班次下拉框
        public void ShiftData()
        {
            ShiftDdl.DataSource = sBll.GetAllList();
            ShiftDdl.DataValueField = "shift_id";
            ShiftDdl.DataTextField = "shfit_name";
            ShiftDdl.DataBind();
            ShiftDdl.Items.Insert(0, "请选择班次");
        }

        //查询按钮
        protected void Button1_Click(object sender, EventArgs e)
        {

            MethPaySumDataBind();
            GridView2DataBind(pageSize, pageIndex);
        }

        //获取操作员中文名称
        public string GetUserName(object id)
        {
            Model.AccountsUsers model = auBll.GetModel(id.ToString());
            return model.UserName;
        }

        //绑定操作员
        public void UserNameData()
        {
            UserDdl.DataSource = auBll.GetAllList();
            UserDdl.DataValueField = "UserID";
            UserDdl.DataTextField = "UserName";
            UserDdl.DataBind();
            UserDdl.Items.Insert(0, "请选择操作员");
        }



        public override void SonLoad()
        {
            if (!IsPostBack)
            {
                styid = "";
                //班次下拉
                ShiftData();
                //操作员下拉
                UserNameData();
                MethPaySumDataBind();
                GridView2DataBind(pageSize, pageIndex);
            }
        }
    }
}