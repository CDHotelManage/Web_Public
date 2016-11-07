using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.Menus2
{
    public partial class RommSuo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                txt.Value = Request.QueryString["txt"];
                
                Bind();
            }
        }
        BLL.room_number bllrn = new BLL.room_number();
        private void Bind() {
            List<Model.room_number> listroom = bllrn.GetModelList("");
            rep1.DataSource = listroom;
            rep1.DataBind();

            List<Model.SuoSys> list = bllss.GetModelList("SuoTypeName='" + txt.Value + "'");
            if (list.Count > 0)
            {
                Model.SuoSys modelss = list[0];
                IsBackSuo.Checked = modelss.IsBackSuo;
                IsComm.Checked = modelss.IsComm;
            }
        }

        BLL.SuoRoom bllsrom = new BLL.SuoRoom();

        protected string GetSuoma(string room) {
            List<Model.SuoRoom> listsroom = bllsrom.GetModelList("SuoType='" + txt.Value + "' and RoomNumber='" + room + "'");
            if (listsroom.Count > 0) {
                //return listsroom[0].SuoMa;
                return "<input type='text' class=\"suonumber\" value='" + listsroom[0].SuoMa + "'>";
            }
            return "<input type='text' class=\"suonumber\" value=''>";
        }

        BLL.SuoSys bllss = new BLL.SuoSys();
        protected void BtnSave_Click(object sender, EventArgs e) {
            List<Model.SuoSys> list = bllss.GetModelList("SuoTypeName='" + txt.Value + "'");
            if (list.Count > 0)
            {
                Model.SuoSys modelss = list[0];
                modelss.IsBackSuo = IsBackSuo.Checked;
                modelss.IsComm = IsComm.Checked;
                bllss.Update(modelss);
            }
        }

    }
}