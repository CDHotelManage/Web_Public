using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Wap.order_room
{
    public partial class index : System.Web.UI.Page
    {
        CdHotelManage.BLL.room_type typebll = new BLL.room_type();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRoomType();
            }
        }

        private void BindRoomType()
        {
            rptRoomType.DataSource = typebll.GetAllList();
            rptRoomType.DataBind();
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            Maticsoft.Common.MessageBox.ShowAndRedirect(this, "提交成功！", ""); 
        }
    }
}