using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Wap.order_room
{
    public partial class roomType : System.Web.UI.Page
    {
        CdHotelManage.BLL.room_type typebll = new BLL.room_type();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["typeid"].ToString()))
                {
                    int id = Convert.ToInt32(Request.QueryString["typeid"].ToString());
                    Response.Write(BindData(id));
                }
            }
        }

        private string BindData(int id)
        {
            string html = "";
            if (id != 0)
            {
                Model.room_type model = typebll.GetModel(id);
                if (model != null)
                {
                    html += "<div class=\"typeimg\"><img src=\"../images/home-slider10.jpg\"/></div><div class=\"content\">";
                    html += "<span>房型名称</span>：" + model.room_name + "<br /><span>挂牌价</span>：" + model.room_listedmoney.ToString() + "<br /><span>周末挂牌价</span>：" + model.room_zmmoney.ToString() + "<br /><span>允许钟点房</span>：" + model.room_hour + "<br /><span>钟点房价格</span>：标准间<br /><span>备注</span>：" + model.room_reamker + "<br />";
                    html += "</div>";
                }
            }
            return html;
        }
    }
}