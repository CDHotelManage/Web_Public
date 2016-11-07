using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.member
{
    public partial class exchange : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        BLL.mRecords bllmr = new BLL.mRecords();
        protected void btnSubmit_click(object sender, EventArgs e) {
            if (Request.Form["mid"].ToString() != "")
            {
                if (Request.Form["hidjf"].ToString() != "") {
                    Model.mRecords modemr = new Model.mRecords();
                    modemr.mmid = Request.Form["mid"];
                    modemr.Price = Convert.ToInt32(Request.Form["hidjf"]);
                    modemr.Type = 4;
                    modemr.Remark = "";
                    bllmr.Add(modemr); ;
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('兑换成功！！');parent.window.location.reload()</script>");
                }
                else {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('请选择商品！！');</script>");
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('请选择需要操作的会员！！');</script>");
            }
        }
    }
}