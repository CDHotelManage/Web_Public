using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.Menus2
{
    public partial class Init : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        BLL.occu_infor blloc = new BLL.occu_infor();
        BLL.room_number bllrn = new BLL.room_number();
        BLL.Book_Rdetail bllrns = new BLL.Book_Rdetail();
        BLL.book_room bllbr = new BLL.book_room();
        BLL.Shift_Exc bllsx = new BLL.Shift_Exc();
        protected void BtnInit_Click(object sender, EventArgs e) {
            try
            {
                blloc.Deletes("delete occu_infor");

                blloc.Deletes("delete goods_account");

                bllrn.Updates("update room_number set Rn_state=3,Rn_Tobe=0,Room_suod='否'");

                bllrns.DeletebyWhere("");


                bllbr.DeletebyWhere("");

                bllsx.DeleteAll();

                Response.Write("<script>alert('成功初始化！')</script>");
            }
            catch (Exception ex)
            {
                
                
            }
        }
        //protected void btn_Click(object sender, EventArgs e)
        //{
        //    Model.goods_account ga = new Model.goods_account()
        //    {
        //        ga_name = "百事可乐",
        //        ga_number = "aaaa",
        //        ga_roomNumber = "101",
        //        ga_date = Convert.ToDateTime("2015-06-30 12:26:41.453"),
        //        ga_Type = 005,
        //        ga_isys = 0
        //    };
        //    for (int i = 0; i < 1000; i++)
        //    {
        //        bllga.Add(ga);
        //    }
        //}
        //BLL.goods_account bllga = new BLL.goods_account();
    }
}