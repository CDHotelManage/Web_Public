using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.Menus2
{
    public partial class InteSyS : System.Web.UI.Page
    {
        BLL.SysParameter bllsys = new BLL.SysParameter();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack) {
               Model.SysParamter modelsyts=  bllsys.GetModel(1);
               txt.Value = modelsyts.MarkSuo;
            }
        }


        protected void BtnSave_Click(object sender, EventArgs e) {
            Model.SysParamter modelsyts = bllsys.GetModel(1);
            modelsyts.MarkSuo = LockType.SelectedValue;
            bllsys.Update(modelsyts);
            ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('结帐成功');parent.window.location.reload();</script>");
        }

    }
}