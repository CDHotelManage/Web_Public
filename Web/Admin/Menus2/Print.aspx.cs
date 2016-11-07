using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace CdHotelManage.Web.Admin.Menus2
{
    public partial class Print : System.Web.UI.Page
    {
        BLL.print bllp = new BLL.print();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                Bind();
            }
        }

        /// <summary>
        /// 绑定信息
        /// </summary>
        void Bind() {
            rep1.DataSource = bllp.GetModelList("");
            rep1.DataBind();
        }

        
    }
}