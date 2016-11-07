using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LTP.Accounts.Bus;
using System.Text;
using Maticsoft.Common;
namespace CdHotelManage.Web.Admin.Book
{

    public partial class DepositAdd : System.Web.UI.Page
    {

        Model.book_room brModel = new Model.book_room();
        BLL.book_room brBll = new BLL.book_room();
        BLL.guest_source gsBll = new BLL.guest_source();
        BLL.Book_Rdetail bllbr = new BLL.Book_Rdetail();
        BLL.room_type rtBll = new BLL.room_type();
        BLL.meth_pay mpBll = new BLL.meth_pay();
        BLL.goods_account gabll = new BLL.goods_account();
        int id = 2;
        protected void Page_Load(object sender, EventArgs e)
        {
            
                if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
                {
                    id = Convert.ToInt32(Request.Params["id"]);

                    BookShow();
                    MethPayData();
                }
            
        }

        //加载显示
        public void BookShow()
        {
            brModel = brBll.GetModel(Convert.ToInt32(id));
            if (brModel != null) {
                List<Model.Book_Rdetail> list = bllbr.GetListModel("Book_no='" + brModel.book_no + "'");
                if (list != null) {
                    //房型
                    Model.room_type rtModel = rtBll.GetModel(Convert.ToInt32(list[0].Real_type_Id));
                    this.lbroomtype.Text = rtModel.room_name;
                    //订单编号
                    this.lbbookno.Text = list[0].Book_no;

                    //预定人
                    this.lbname.Text = brModel.book_Name;
                    //号码
                    this.lbtele.Text = brModel.tele_no;

                    //客人来源
                    Model.guest_source gsModel = gsBll.GetModel(Convert.ToInt32(brModel.source_id));
                    this.lbsource.Text = gsModel.gs_name;



                    //房数
                   //  = brModel.real_num.ToString();
                    this.lbrealnum.Text = bllbr.GetAllNum("Book_no='" + brModel.book_no + "'").ToString();
                    //已交订金
                    this.lbdeposit.Text = (Convert.ToDouble(brModel.deposit)).ToString();
                }
               
            }
           


            //卡号和余额先不考虑

        }


        //绑定支付方式下拉框
        public void MethPayData()
        {
            meth_payDdl.DataSource = mpBll.GetAllList();
            meth_payDdl.DataValueField = "meth_pay_id";
            meth_payDdl.DataTextField = "meth_pay_name";
            meth_payDdl.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
            brModel = brBll.GetModel(Convert.ToInt32(id));
            //判断退订金不能大于可退订金
            if (Convert.ToDecimal(adddeposit.Value) < 0)
            {
                MessageBox.Show(this, "补交订金请输入大于0的数字");
                return;
            }
            brModel.meth_pay_id = Convert.ToInt16(meth_payDdl.SelectedValue);
            brModel.remark = this.txtremark.Value;
            brModel.deposit = brModel.deposit + Convert.ToDecimal(this.adddeposit.Value);
             

            //写入入账表
            Model.goods_account gaModel = new Model.goods_account();
            gaModel.ga_name = "补交订金";
            //gaModel.ga_roomNumber = Convert.ToInt32(brModel.room_number);
            gaModel.ga_zffs_id = Convert.ToInt16(meth_payDdl.SelectedValue);
            gaModel.ga_date = System.DateTime.Now;
            gaModel.ga_sum_price = brModel.deposit;
            //gaModel.ga_people = Session["UserId"].ToString();
            gabll.Add(gaModel);
            
            bool Result = brBll.Update(brModel);

            if (Result == true)
            {
                //Page.ClientScript.RegisterStartupScript(GetType(), "info", "<script>(\"补订金成功\", \"info\",'../','');</script>");
               // Response.Redirect("BookList.aspx");
                //待修改
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language=\"javascript\">if(confirm('补交定金成功!是否打印收款单？')){ ShowDivs('" + brModel.book_no + "') }else{ ShowTabs('预定管理');}</script>");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "info", "<script>(\"系统繁忙，请稍后再试！\", \"info\",'../','');</script>");
                Response.Redirect("BookList.aspx");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookList.aspx");
        }
    }
}