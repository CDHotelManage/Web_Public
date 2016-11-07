using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace CdHotelManage.Web.Admin.Toroom
{
    public partial class PeopleInfosk : System.Web.UI.Page
    {
        BLL.card_type fsfBll = new BLL.card_type();
        BLL.room_number fmnumber = new BLL.room_number();
        BLL.occu_infor fmmx = new BLL.occu_infor();
        BLL.room_number fmroom = new BLL.room_number();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack) 
            {
               
                BindSFZ();
                Bindfh();
                BindGV();
            }
        }
        /// <summary>
        /// 绑定身份证
        /// </summary>
        public void BindSFZ()
        {
            DataSet dt = fsfBll.GetAllList();
            foreach (DataRow dr in dt.Tables[0].Rows)
            {
                txt_CardesName.Value += dr["id"].ToString() + "," + dr["ct_name"].ToString() + ";";
            }
            DDlSFz.DataSource = fsfBll.GetAllList();
            DDlSFz.DataBind();
        }

        /// <summary>
        /// 绑定房号
        /// </summary>
        public void Bindfh()
        {
            string ids=Request.QueryString["id"].ToString();
             DataSet dt=null;
            string roomsid = Request.QueryString["rooms"].ToString();
            if (ids.Trim() == "")
            {
               dt = fmnumber.GetList(" Rn_roomNum ='" + roomsid + "'");
            }
            else
            {
                dt = fmnumber.GetList(" Rn_roomNum in (" + ids + ")");
            }
            DDlFh.DataSource = dt;
            DDlFh.DataBind();
        }
        public void BindGV()
        {
            string roomsid =  Request.QueryString["rooms"].ToString();
            DataSet dts = fmmx.GetList(" room_number='" + roomsid + "' and occ_with='是' and state_id=0");
            foreach (DataRow drs in dts.Tables[0].Rows)
            {
                if (txt_Info.Value == "")
                {
                    txt_Info.Value += drs["room_number"].ToString() + "," + drs["occ_name"].ToString() + "," + drs["sex"].ToString() + "," + drs["brithday"].ToString() + "," + fsfBll.GetModel(Convert.ToInt32(drs["card_id"].ToString())).ct_name + "," + drs["card_no"].ToString() + "," + drs["address"].ToString();

                }
                else
                {
                    txt_Info.Value += "|" + drs["room_number"].ToString() + "," + drs["occ_name"].ToString() + "," + drs["sex"].ToString() + "," + drs["brithday"].ToString() + "," + fsfBll.GetModel(Convert.ToInt32(drs["card_id"].ToString())).ct_name + "," + drs["card_no"].ToString() + "," + drs["address"].ToString();
                }
            }
            
            //string conteent = "";

            // ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "qwwqwq", "GetBind('" + txt_Info.Value + "');", true);

        }
    }
}