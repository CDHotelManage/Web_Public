using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CdHotelManage.Web.Wap.about
{
    public partial class index : System.Web.UI.Page
    {
        CdHotelManage.BLL.shopInfo infobll = new BLL.shopInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindInfo();
            }
        }

        public string Shop_Remaker = "";
        private void BindInfo()
        {
            try
            {
                DataTable dt = infobll.GetList(1, "", "id desc").Tables[0];
                if (dt != null)
                {
                    this.labname.Text = dt.Rows[0]["shop_Name"].ToString();
                    this.labaddress.Text = dt.Rows[0]["Shop_Address"].ToString();
                    this.labphone.Text = dt.Rows[0]["Shop_Telphone"].ToString();
                    Shop_Remaker = dt.Rows[0]["Shop_Remaker"].ToString();
                }
            }
            catch
            { 
            
            }
        }

    }
}