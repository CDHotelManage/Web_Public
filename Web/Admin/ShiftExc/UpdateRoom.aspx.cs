using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.ShiftExc
{
    public partial class UpdateRoom : BasePage
    {
        int hfID = 0;//要换的房间的ID
        protected Model.occu_infor modelafter = new Model.occu_infor();//换房间之前的实体
        protected Model.occu_infor modelh = new Model.occu_infor();//换房间之后的实体
        BLL.occu_infor blloi = new BLL.occu_infor();
       
        public override void SonLoad()
        {
            if (Request["hfID"] != null)
            {
                hfID = Convert.ToInt32(Request["hfID"]);
            }
            modelafter = blloi.GetModel(hfID);
            List<Model.occu_infor> list = blloi.GetModelList("continuelive=" + hfID + " and occ_with='否' and state_id=0");
            if (list != null)
            {
                modelh = list[0];
            }
        }
    }
}