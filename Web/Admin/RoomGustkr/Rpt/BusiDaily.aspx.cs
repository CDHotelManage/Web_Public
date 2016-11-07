using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Text;
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace CdHotelManage.Web.Admin.Rpt
{
    public partial class BusiDay1 : System.Web.UI.Page
    {
        BLL.goods_account gsBll = new BLL.goods_account();
        BLL.occu_infor oiBll = new BLL.occu_infor();
        BLL.real_mode rmBll = new BLL.real_mode();
        BLL.guest_source guestBll = new BLL.guest_source();
        BLL.room_state rsBll = new BLL.room_state();

        //房租合计栏
        public double fz = 0;
        public double xh = 0;
        public double xj = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                try
                {
                    if (Request.QueryString["date"].ToString() != "")
                    {
                        date1.Value = Request.QueryString["date"].ToString();
                        date2.Value = Request.QueryString["date"].ToString();
                    }
                    else
                    {
                        Today();
                    }
                    RepeaterDataBind();
                }
                catch { }
            }
        }
         
        public override void VerifyRenderingInServerForm(Control control)
        { }

        protected void Button1_Click(object sender, EventArgs e)
        {
            RepeaterDataBind();
            this.lbstarttime.Text = this.date1.Value;
            this.lbendtime.Text = this.date2.Value;
        }

        //营业日默认今天
        public void Today()
        {
            this.date1.Value = System.DateTime.Now.ToString("yyyy-MM-dd");
            this.date2.Value = System.DateTime.Now.ToString("yyyy-MM-dd");
            this.lbstarttime.Text = this.date1.Value;
            this.lbendtime.Text = this.date2.Value;
            this.lbtoday.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
        }
        public void RepeaterDataBind()
        {
            string strwhere = "where 1=1 ";

            if (date1.Value.Length > 0 && date2.Value.Length > 0)
            {
                strwhere += "and  convert(varchar(100), occ_time, 23)   >= '" + this.date1.Value.Trim() + "' and convert(varchar(100), occ_time, 23)   <= '" + this.date2.Value.Trim() + "' ";
            }
          //if(date1.Value.ToString() == "" && date2.Value.ToString() =="")
          //  {
          //      MessageBox.Show(this, "请选择开始日期和结束日期");
          //      return;
          //  }

            Repeater1.DataSource = oiBll.BusiDaily(strwhere);
            Repeater1.DataBind();

            DataSet ds = oiBll.BusiDaily(strwhere);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (row["fangzu"].ToString() == "")
                {
                    row["fangzu"] = 0;
                }
                fz += Convert.ToDouble(row["fangzu"]);

                if (row["xiaofei"].ToString() == "")
                {
                    row["xiaofei"] = 0;
                }
                xh += Convert.ToDouble(row["xiaofei"]);

                if (row["MoneySum"].ToString() == "")
                {
                    row["MoneySum"] = 0;
                }
                xj += Convert.ToDouble(row["MoneySum"]);
              
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
          
            System.IO.StringWriter sw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(sw);
            this.Repeater1.RenderControl(hw);

            //charset=UTF-8
            Response.Clear();
            Response.ContentType = "application/vnd.ms-excel";
            Response.Charset = "";
            Repeater1.Page.EnableViewState = true;
            Response.AppendHeader("Content-Disposition", "attachment;filename=\"" + System.Web.HttpUtility.UrlEncode(DateTime.Now.ToString("yyyy-MM-dd"), System.Text.Encoding.UTF8) + "营业日报"+".xls\"");
            Response.Write("<html><head><meta http-equiv=Content-Type content=\"text/html; charset=auto\"><title></title></head><body><table style='border:2'>");
            Response.Write("<tr><td style='text-algin:center;' colspan='14'>营业日报</td></tr>");
            Response.Write(sw.ToString());
            Response.Write("</table ></body></html>");
            Response.End();

        }

        public string GetRealModelName(object id)
        {
            Model.real_mode model = new Model.real_mode();
            try
            {
                 model = rmBll.GetModel(Convert.ToInt32(id));               
            }
            catch
            {
            }
            return model.real_mode_name;
           
        }

        public string GetSourceName(object id)
        {
            Model.guest_source model = new Model.guest_source();
            try
            {
                model = guestBll.GetModel(Convert.ToInt32(id));
            }
            catch
            {

            }
            return model.gs_name;
        }

        public string GetStateName(object id)
        {
            int Id = Convert.ToInt32(id);
            string StateName = "";
            if(Id == 0)
            {
                StateName = "入住";
            }
            if (Id == 1)
            {
                StateName = "续住";
            }

            if (Id == 2)
            {
                StateName = "换房";
            }
            if (Id == 3)
            {
                StateName = "退房";
            }
            return StateName;

        }


    }
}