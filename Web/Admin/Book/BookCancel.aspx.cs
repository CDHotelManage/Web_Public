using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CdHotelManage.Model;
using CdHotelManage.BLL;
using System.Text;
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace CdHotelManage.Web.Admin.Book
{
    public partial class BookCancel : BasePage
    {
        Model.book_room brModel = new Model.book_room();
        BLL.book_room brBll = new BLL.book_room();
        BLL.guest_source gsBll = new BLL.guest_source();
        BLL.room_type rtBll = new BLL.room_type();
        BLL.meth_pay mpBll = new BLL.meth_pay();
        BLL.goods_account gabll = new BLL.goods_account();
        int id;
       
        BLL.Book_Rdetail bllbr = new BLL.Book_Rdetail();
        public void BookShow()
        {
            brModel = brBll.GetModel(Convert.ToInt32(id));
            if (brModel != null)
            {
                List<Model.Book_Rdetail> list = bllbr.GetListModel("Book_no='" + brModel.book_no + "'");
                if (list != null)
                {
                    //预定人
                    this.lbname.Text = brModel.book_Name;
                    //号码
                    this.lbtele.Text = brModel.tele_no;

                    //客人来源
                    Model.guest_source gsModel = gsBll.GetModel(Convert.ToInt32(brModel.source_id));
                    this.lbsource.Text = gsModel.gs_name;

                    //房型
                    Model.room_type rtModel = rtBll.GetModel(Convert.ToInt32(list[0].Real_type_Id));
                    this.lbroomtype.Text = rtModel.room_name;

                    //房数
                    this.lbrealnum.Text = list.Count.ToString();

                    //可退订金
                    this.lbdeposit.Text = (Convert.ToDouble(brModel.deposit)).ToString();
                }
            }

        }

        //绑定支付方式下拉框
        public void MethPayData()
        {
            meth_payDdl.DataSource = mpBll.GetAllList();
            meth_payDdl.DataValueField = "meth_pay_id";
            meth_payDdl.DataTextField = "meth_pay_name";
            meth_payDdl.DataBind();
        }

        //取消按钮不做物理删除，改变状态
        protected void Button1_Click(object sender, EventArgs e)
        {
         
            
            //改变状态,先写死，到时候再具体看。
            
            brModel = brBll.GetModel(Convert.ToInt32(id));
            brModel.state_id = 5;
            brModel.back_deposit = Convert.ToDecimal(this.txtdeposit.Value);
            //判断退订金不能大于可退订金
            if (Convert.ToDecimal(txtdeposit.Value) > brModel.deposit)
            {
                MessageBox.Show(this,"退订金"+txtdeposit.Value +"不能大于" +brModel.deposit +"可退订金");
                return;
            }
            brModel.meth_pay_id = Convert.ToInt16(meth_payDdl.SelectedValue);
            brModel.remark = this.txtremark.Value;
            if (brModel.Accounts!="")//如果是单位被取消  增加取消次数
            {
                BLL.customer bllcuns = new BLL.customer();
                Model.customer modelcus = bllcuns.GetAccounts(brModel.Accounts);
                if (modelcus != null)
                {
                    modelcus.xqBook += 1;
                    bllcuns.Update(modelcus);
                }
            }
            else { 
               
            }
            //写入入账表
            Model.goods_account gaModel = new Model.goods_account();
            gaModel.ga_name = "退订金";
            //gaModel.ga_roomNumber = Convert.ToInt32(brModel.room_number);
            gaModel.ga_zffs_id = Convert.ToInt16(meth_payDdl.SelectedValue);
            gaModel.ga_number = brModel.book_no;
            gaModel.ga_date = System.DateTime.Now;
            gaModel.ga_price = Convert.ToDecimal(txtdeposit.Value) * -1;
            gaModel.ga_people = UserNow.UserID;
            //gaModel.ga_people = Session["UserId"].ToString();
            gabll.Add(gaModel);

            bool Result = brBll.Update(brModel);
            List<Model.Book_Rdetail> listbr = bllbr.GetListModel("book_no='" + brModel.book_no + "'");
            foreach (Model.Book_Rdetail item in listbr)
            {
                item.RoomTypeID = 5;
                bllbr.Update(item);
            }
            if (Result == true)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "info", "<script language=\"javascript\">if(confirm('取消预定成功!是否打印退款单？')){ ShowDivs(this,'" + brModel.book_no + "') }else{ ShowTabs('预定管理');}</script>");
                //Response.Redirect("BookList.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "info", "<script>alert('取消失败！');parent.Window_Close();</script>");
                //Response.Redirect("BookList.aspx");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "info", "<script> parent.Window_Close();</script>");
        }

        public override void SonLoad()
        {
            if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
            {
                id = Convert.ToInt32(Request.Params["id"]);
                BookShow();
                MethPayData();
            }
        }
    }
}