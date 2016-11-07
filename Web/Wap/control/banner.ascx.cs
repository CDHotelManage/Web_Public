using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CdHotelManage.Web.Wap.control
{
    public partial class banner : System.Web.UI.UserControl
    {
        CdHotelManage.BLL.bannerBLL bannerbll = new BLL.bannerBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBanner();
            }
        }


        private void BindBanner()
        {
            DataTable dt = bannerbll.GetAllList().Tables[0];
            if (dt.Rows.Count > 0)
            {
                rptBanner.DataSource = dt;
                rptBanner.DataBind();
            }
            else
            {
                DataTable dt2 = new DataTable();
                DataColumn dc = new DataColumn("imgurl");
                dt2.Columns.Add(dc);
                DataRow dr1 = dt2.NewRow();
                DataRow dr2 = dt2.NewRow();
                DataRow dr3 = dt2.NewRow();
                dr1["imgurl"] = "/images/home-slider2.jpg";
                dr2["imgurl"] = "/images/home-slider3.jpg";
                dr3["imgurl"] = "/images/home-slider10.jpg";
                dt2.Rows.Add(dr1);
                dt2.Rows.Add(dr2);
                dt2.Rows.Add(dr3);

                rptBanner.DataSource = dt2;
                rptBanner.DataBind();
            }
        }
    }
}