using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.Menus2
{
    public partial class GoodsPrices : BasePage
    {
        int pageSize = 10;
        int pageindex = 1;
        public override void SonLoad()
        {
            
           
            if (!IsPostBack) {
                Bind(pageSize, pageindex, "where ga_Type=110 and ga_isjz=0");
            }
        }

        BLL.goods_account gaBll = new BLL.goods_account();

        /// <summary>
        ///查询事件
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object s, EventArgs e) {
            string statr = StartDate.Value;
            string end = EndDate.Value;
            string sort = "ga_zffs_id";
            string order = "DESC";
            int currentPage = Pager.CurrentPageIndex;
            string where = "where 1=1 ";

            if (statr != "")
            {
                where += " and ga_Type=110 and  datediff (second,ga_date,'" + statr + "')<0 ";
            }
            if (end != "") {
                where += " and datediff(second,ga_date,'" + end + "')>0 ";
            }
            if (OrderNo.Value != "") {
                where += " and ga_number like '%" + OrderNo.Value + "%'";
            }
            this.rep1.DataSource = gaBll.GetMethPayMoneyPage1(sort, order, currentPage, pageSize, where);
            this.rep1.DataBind();
        }

        /// <summary>
        /// 绑定信息
        /// </summary>
        private void Bind(int pageSize, int pageindex,string where)
        {
            string sort = "ga_zffs_id";
            string order = "DESC";
            int currentPage = Pager.CurrentPageIndex;
            this.rep1.DataSource = gaBll.GetMethPayMoneyPage(sort, order, currentPage, pageSize, where);
            this.rep1.DataBind();

            //Pager.RecordCount = gaBll.GetRecordCount(where);
            //Pager.ShowCustomInfoSection = Wuqi.Webdiyer.ShowCustomInfoSection.Right;
            //Pager.PageSize = pageSize;
            //Pager.CurrentPageIndex = pageindex;
            //if (Pager != null)
            //{
            //    if (Pager.RecordCount != 0)
            //    {
            //        Pager.ShowPageIndex = true;
            //        Pager.ShowDisabledButtons = true;
            //        Pager.CustomInfoSectionWidth = new System.Web.UI.WebControls.Unit("40%");
            //        Pager.ShowPageIndexBox = Wuqi.Webdiyer.ShowPageIndexBox.Always;
            //        Pager.CustomInfoHTML = "&nbsp;记录总数：<b>" + Pager.RecordCount.ToString() + "</b>";
            //        Pager.CustomInfoHTML += " 总页数：<b>" + Pager.PageCount.ToString() + "</b>";
            //        Pager.CustomInfoHTML += " 当前页：<font color=\"red\"><b>" + Pager.CurrentPageIndex.ToString() + "</b></font>";
            //    }
            //    else
            //    {
            //        Pager.ShowPageIndex = false;
            //        Pager.ShowDisabledButtons = false;
            //        Pager.ShowPageIndexBox = Wuqi.Webdiyer.ShowPageIndexBox.Never;
            //        Pager.CustomInfoSectionWidth = new System.Web.UI.WebControls.Unit("100%");
            //    }
            //}
        }

        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            Bind(pageSize, Pager.CurrentPageIndex, "where ga_Type=110 and ga_isjz=0");
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

        //获取支付方式中文名称
        public string GetRealTypeName1(object id)
        {
            if (id.ToString() == "")
            {
                return "";
            }
            BLL.AccountsUsersBLL mpBll1 = new BLL.AccountsUsersBLL();
            Model.AccountsUsers model = mpBll1.GetModel(id.ToString());
            return model.UserName;
        }

      
    }
}