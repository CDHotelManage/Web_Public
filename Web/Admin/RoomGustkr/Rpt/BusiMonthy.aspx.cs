using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.Rpt
{
    public partial class BusiMonthy : System.Web.UI.Page
    {
        BLL.room_number rnBll = new BLL.room_number();
        BLL.occu_infor oiBll = new BLL.occu_infor();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //默认当月
                this.Month.Value = System.DateTime.Now.ToString("yyyy-MM");
                RepeaterDataBind();
            }
        }

        public void RepeaterDataBind()
        {
            string strWhere = "where 1 = 1";
            if (this.Month.Value != "")
            {
                strWhere += "and CONVERT(VARCHAR(100), occ_time, 23) like '%"+this.Month.Value+"%'";
            }
            Repeater1.DataSource = oiBll.BusiMonth(strWhere);
            Repeater1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            System.IO.StringWriter sw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(sw);
            this.Repeater1.RenderControl(hw);

            //charset=UTF-8
            Response.Clear();
            Response.ContentType = "application/vnd.ms-excel";
            Response.Charset = "";
            Repeater1.Page.EnableViewState = true;
            Response.AppendHeader("Content-Disposition", "attachment;filename=\"" + System.Web.HttpUtility.UrlEncode(DateTime.Now.ToString("yyyy-MM-dd"), System.Text.Encoding.UTF8) + "营业月报" + ".xls\"");
            Response.Write("<html><head><meta http-equiv=Content-Type content=\"text/html; charset=auto\"><title></title></head><body><table style='border:2'>");
            Response.Write("<tr><td style='text-algin:center;' colspan='14'>营业月报</td></tr>");
            Response.Write(sw.ToString());
            Response.Write("</table ></body></html>");
            Response.End();
        }


      //  public void GetRuzhushu(


    }
}