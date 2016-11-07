using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Wap.order_room
{
    public partial class order : System.Web.UI.Page
    {
        CdHotelManage.BLL.shopInfo infobll = new BLL.shopInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetValue();
                this.labname.Text = infobll.GetList(1, "", "id desc").Tables[0].Rows[0]["shop_Name"].ToString();
            }
        }

        int typeid = 0;
        private void GetValue()
        {
            try
            {
                if (!string.IsNullOrEmpty(Request.QueryString["datein"]))
                {
                    this.startDate.Text = Request.QueryString["datein"].ToString();
                }
                if (!string.IsNullOrEmpty(Request.QueryString["dateout"]))
                {
                    this.endDate.Text = Request.QueryString["dateout"].ToString();
                }
                if (!string.IsNullOrEmpty(Request.QueryString["days"]))
                {
                    this.labdays.Text = Request.QueryString["days"].ToString();
                }
                if (!string.IsNullOrEmpty(Request.QueryString["roomtype"]))
                {
                    typeid = Convert.ToInt32(Request.QueryString["roomtype"].ToString());
                    this.labroomType.Text = GetTypeName(typeid);
                }
                
            }
            catch
            {
                this.startDate.Text = "请选择";
                this.endDate.Text = "请选择";
                this.labdays.Text = "住0晚";

            }
        }

        CdHotelManage.BLL.room_type typebll = new BLL.room_type();
        private string GetTypeName(int id)
        {
            string roomtype = "";
            if (id != 0)
            {
                Model.room_type model = typebll.GetModel(id);
                if (model != null)
                {
                    roomtype = model.room_name;
                }
            }
            return roomtype;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}