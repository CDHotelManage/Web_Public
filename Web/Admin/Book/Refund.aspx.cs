using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.Book
{
    public partial class Refund : BasePage
    {
        BLL.meth_pay mpBll = new BLL.meth_pay();
        BLL.book_room bllbr = new BLL.book_room();
        BLL.goods_account bllga = new BLL.goods_account();
        string bookno = "Y2015420104129";
        

        protected void Button1_Click(object sender, EventArgs e) {
            Model.goods_account modelga = new Model.goods_account();
            modelga.ga_name = "退订金";
            modelga.ga_number = lbbookno.Text;
            modelga.ga_price = Convert.ToDecimal(tdeposit.Value) * -1;
            modelga.ga_zffs_id = Convert.ToInt32(meth_payDdl.SelectedValue);
            modelga.ga_date = DateTime.Now;
            modelga.ga_people = UserNow.UserID;
            modelga.ga_remker = txtremark.Value;
            modelga.ga_isjz = 0;
            if (bllga.Add(modelga) > 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language=\"javascript\">if(confirm('取消预定成功!是否打印退款单？')){ ShowDivs(this,'" + modelga.ga_number+ "') }else{ ShowTabs('预定管理');}</script>");
            }
        }

        /// <summary>
        /// 绑定
        /// </summary> 
        private void Bind() {
            decimal sumpri = 0.00M;
          List<Model.book_room> list = bllbr.GetModelList("Book_no='" + bookno + "'");
          if (list.Count > 0) {
              lbname.Text = list[0].book_Name;
              lbtele.Text = list[0].tele_no;
              lbdeposit.Text = list[0].deposit.ToString();
          }
          List<Model.goods_account> listga = bllga.GetModelList1("ga_number='" + bookno + "' and ga_name='退订金'");
          if (listga != null) {
              foreach (Model.goods_account model in listga)
              {
                  sumpri += Convert.ToDecimal(model.ga_price);
              }
          }
          ytuiqian.Text = sumpri.ToString();
        }

        //绑定支付方式下拉框
        public void MethPayData()
        {
            meth_payDdl.DataSource = mpBll.GetAllList();
            meth_payDdl.DataValueField = "meth_pay_id";
            meth_payDdl.DataTextField = "meth_pay_name";
            meth_payDdl.DataBind();
        }

        public override void SonLoad()
        {
            MethPayData();
            if (!IsPostBack)
            {
                if (Request["bookno"] != null)
                {
                    bookno = Request["bookno"].ToString();
                    lbbookno.Text = bookno;
                    Bind();
                }
            }
           
        }
    }
}