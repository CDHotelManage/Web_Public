using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Maticsoft.Common;
using LTP.Accounts.Bus;

namespace CdHotelManage.Web.Admin.ShiftExc
{
    public partial class ShiftExc : BasePage
    {
        BLL.goods_account gaBll = new BLL.goods_account();
        BLL.Shift sBll = new BLL.Shift();
        BLL.Shift_Exc seBll = new BLL.Shift_Exc();
        BLL.AccountsUsersBLL auBll = new BLL.AccountsUsersBLL();
        private int pageSize = 5;
        private int pageIndex = 1;
       
        public double Sum = 0;

        public string styid
        {

            get { return (string)ViewState["styid"]; }
            set { ViewState["styid"] = value; }
        }

        public string strWheres
        {

            get { return (string)ViewState["strWheres"]; }

            set { ViewState["strWheres"] = value; }

        }
    
        public void MethPaySumDataBind()
        {
            //根据用户登录ID 查询
            //string strWhere = Session["UserID"].ToString();
            string strWhere = UserNow.UserID;
            //先写死测试
            GridView1.DataSource = gaBll.GeMethPaySumMoney(strWhere, 0);
            GridView1.DataBind();

            DataSet ds = gaBll.GeMethPaySumMoney(strWhere, 0);

            foreach (DataRow row in ds.Tables[0].Rows)
            {

                Sum += Convert.ToDouble(row["ga_sum_price"].ToString());
                Session["Sum"] = Sum;
            }

        }


        public void stwhere()
        {
            strWheres = "where 1 = 1";
            
            if (styid != ""  && styid != null)
            {
                strWheres += " and ga_zffs_id=" + styid + "";
            }
            //Session[UserId]

            strWheres += "and ga_people = '" + UserNow.UserID + "'";
           
        }


        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "m_over(this);");
                e.Row.Attributes.Add("onmouseout", "m_out(this);");
            }
                        
            }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            styid = (GridView1.DataKeys[e.NewSelectedIndex].Value.ToString());
            //string strWhere = " WHERE 1=1 ";
            //strWhere += " AND ga_zffs_id = '" +id + "'";
            ////待修改 admin 替换成Session["UserID"]
            //strWhere += " AND ga_people  = '1'";
            //GridView2.DataSource = gaBll.GeMethPayMoney(strWhere);
            //GridView2.DataBind();
            GridView2DataBind(pageSize, Pager.CurrentPageIndex);
            MethPaySumDataBind();
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

        //绑定支付方式下拉框
        public void ShiftData()
        {
            ShiftDdl.DataSource = sBll.GetAllList();
            ShiftDdl.DataValueField = "shift_id";
            ShiftDdl.DataTextField = "shfit_name";
            ShiftDdl.DataBind();
            ShiftDdl.Items.Insert(0, "请选择班次");
            //意思就是说。下拉框的东西可以在后台添加。。然后每选择其中一个就跳到第二个页面。。。第二个页面展示的就是对应他的二维码图片。。
            // ID   银行名称  二维码图片路径   类型（int） 二维码图片跳转路径
        }

        //确认交班
        protected void Button1_Click(object sender, EventArgs e)
        {
         
            //将数据写入交班表里面
            Model.Shift_Exc model = new Model.Shift_Exc();
           // model.UserId = "";  登陆UserId
            if (ShiftDdl.SelectedIndex == 0)
            {
                MessageBox.Show(this, "请先选择交班班次");
                return;
            }

            //判断该天班次是否提交

            //string str = "where shift_id = '"+Convert.ToInt32(ShiftDdl.SelectedValue)+"'";
            
            string data = System.DateTime.Now.ToString("yyyy-MM-dd");

            /*and CONVERT(VARCHAR(100), shift_dateTime, 23) = '" + data + "'*/

            //userid 先写死
            string str = "where UserId = '"+UserNow.UserID+"' and shift_id = '" + Convert.ToInt32(ShiftDdl.SelectedValue) + "'";

            int count = seBll.GetRecordCount(str);

            if (count > 0)
            {
                MessageBox.Show(this, "当日班次已提交，请重新选择");
                return;
            }

        
            //从入账表里面获取该用户的所有收账记录，然后将记录循环新增到交班历史表中
            //获取Session["UserId"],先写死
            string strWhere = UserNow.UserID;
            //更新所有的账的是否交班状态
            DataSet ds = gaBll.GetSumInfo(strWhere);
            gaBll.Updatesis(strWhere);
            int Result = 0;
            foreach (DataRow row in ds.Tables[0].Rows)
            {

                model.shift_id = Convert.ToInt32(ShiftDdl.SelectedValue);
                //model.shift_money = Convert.ToDecimal((Session["Sum"]));
                model.shift_state = "已确认";
                model.shift_dateTime = System.DateTime.Now;
                model.ga_name = row["ga_name"].ToString();
                model.ga_number = row["ga_number"].ToString();
                model.ga_unit = row["ga_unit"].ToString();
                if (row["ga_num"].ToString().Trim() == null || row["ga_num"].ToString().Trim() == "" || row["ga_num"].ToString().Trim() == " ")
                {
                    model.ga_num = 0;
                }
                else
                {
                    model.ga_num = Convert.ToInt32(row["ga_num"]);
                }
                if (row["ga_sum_price"] == null)
                {
                    model.ga_price = 0;
                }
                else
                {
                    model.ga_price = Convert.ToDecimal(row["ga_price"]);
                }
                model.ga_zffs_id = Convert.ToInt32(row["ga_zffs_id"]);  
                model.ga_date = Convert.ToDateTime(row["ga_date"]);
                model.ga_Type = Convert.ToInt32(row["ga_Type"]);
                if (row["ga_sum_price"] == null)
                {
                    model.ga_sum_price = 0;
                }
                else
                {
                    model.ga_sum_price = Convert.ToDecimal(row["ga_sum_price"]);
                }
                model.ga_roomNumber = row["ga_roomNumber"].ToString();
                model.UserId = Convert.ToInt32(UserNow.UserID);
                Result = seBll.Add(model);

                //修改是否交班状态
                int userid = Convert.ToInt32(Session["UserID"]);
                gaBll.Updatesis(userid.ToString());

                ////再删除入账表数据，再插入到历史表中
                
                //gaBll.ShiftDelete("1");

            }
            if (Result > 0)
            {
               // MessageBox.Show(this, "确认交班报表成功");
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript'>alert('确认交班报表成功');</script>");
                isdis = 1;
            }

            MethPaySumDataBind();
            GridView2DataBind(pageSize, pageIndex);
            
        }

        protected int isdis = 0;

        //获取操作员中文名称
        public string GetUserName(object id)
        {
            Model.AccountsUsers model = auBll.GetModel(id.ToString());
            return model.UserName;
        }


        //明细数据分页
        public void GridView2DataBind(int pageSize, int pageindex)
        {
            string sort = "ga_zffs_id";
            string order = "DESC";
            stwhere();
            int currentPage = Pager.CurrentPageIndex;
            IList<Model.goods_account> listga = gaBll.GetMethPayMoneyPage(sort, order, currentPage, pageSize, strWheres + " and ga_zffs_id!=10");
            foreach (Model.goods_account item in listga)
            {
                if (item.ga_roomNumber == null || item.ga_roomNumber == "")
                {
                    if(item.Ga_Account!=null && item.Ga_Account!="")
                    {
                        BLL.customer bllcus=new BLL.customer();
                        item.ga_roomNumber = bllcus.GetAccounts(item.Ga_Account).cName;
                    }
                    
                }
            }
            GridView2.DataSource = listga;
            GridView2.DataBind();

            Pager.RecordCount = gaBll.GetRecordCount(strWheres + " and ga_price!='0' and ga_isjz=0 and ga_Type!=111 and ga_zffs_id!=11  and ga_zffs_id!=10");
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
                }
            }

            return;
        }

        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            GridView2DataBind(pageSize, Pager.CurrentPageIndex);
        }


        private void BindDG3() {
            GridView3.DataSource = gaBll.GetList("ga_zffs_id=10 and ga_isjz=0");
            GridView3.DataBind();
        }

        public override void SonLoad()
        {
            BindDG3();
            if (!IsPostBack)
            {
                ShiftData();
                MethPaySumDataBind();
            }
            GridView2DataBind(pageSize, pageIndex);
        }
    }
}