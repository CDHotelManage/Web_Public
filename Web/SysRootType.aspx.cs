using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web
{
    public partial class SysRootType : System.Web.UI.Page
    {
        BLL.ExceedScheme bllse = new BLL.ExceedScheme();
        BLL.real_mode bllrm = new BLL.real_mode();
        BLL.TypeScheme bllts = new BLL.TypeScheme();
        BLL.room_type bllrt = new BLL.room_type();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                Bind();
            }
        }

        private void Bind()
        {
            rp1.DataSource = bllts.GetModelList("");
            rp1.DataBind();
        }

        protected string GetName(int id) {
            Model.room_type model = bllrt.GetModel(id);
            if (model != null) {
                return model.room_name;
            }
            return "";
        }
    }
}