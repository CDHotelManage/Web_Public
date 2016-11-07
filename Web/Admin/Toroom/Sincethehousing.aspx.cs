using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.Toroom
{
    public partial class Sincethehousing : System.Web.UI.Page
    {
        BLL.Sincethehous fmhous = new BLL.Sincethehous();
        BLL.room_number fmroom = new BLL.room_number();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {

                string type = Request.QueryString["types"].ToString();
                hidtype.Value = type;
                txt_docNo.Value = System.DateTime.Now.ToString().Replace("-", "").Replace(":", "").Replace("/","").Replace(" ","");
                txt_roomnum.Value = fmroom.GetModel(Convert.ToInt32(Request.QueryString["id"].ToString())).Rn_roomNum;
                txt_ksDate.Value = DateTime.Now.ToString();
               // txt_Name.Value = (Session["User"] as Model.Users).username;
                if (type == "1" || type == "3") 
                {
                    ul3.Style.Add("display", "none");
                    ziyong.InnerHtml = "自用原因:";
                }
                if (type == "2" || type == "3") 
                {
                    btnupdate.Text = "更新";
                    Bind();
                }
              
            }
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            string type = Request.QueryString["types"].ToString();

            string SQL = "";
            Model.Sincethehous modle = new Model.Sincethehous();
            modle.hs_date = System.DateTime.Now;
            modle.hs_ylDate = txt_jsdate.Value;
            modle.hs_ksDate = Convert.ToDateTime( txt_ksDate.Value);
            modle.hs_room = txt_roomnum.Value;
            modle.hs_yuany = txt_wxyying.Value;
            modle.hs_Documentno = txt_docNo.Value;
            modle.hs_people = txt_Name.Value;
            modle.hs_Result = txt_result.Value;
            modle.hs_remaker = txt_remaker.Value;
            if (type == "1")
            {
                modle.hs_type = 1;
            }else{
            modle.hs_type = 0;}
            if (type == "2" || type == "3")
            {
                string roomnum = fmroom.GetModel(Convert.ToInt32(Request.QueryString["id"].ToString())).Rn_roomNum;
                modle.id = fmhous.GetModelList(" hs_room='" + roomnum + "' order by hs_date desc ")[0].id;
                if (fmhous.Update(modle))
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript'>alert('更新成功');ShowTabs('房态图'," + type + ");</script>");

                }
                else {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript'>alert('更新失败');</script>");

                }
            }
            else
            {
                if (fmhous.Add(modle) > 0)
                {
                    if (type == "1")
                    {
                        SQL = "update room_number set Rn_state=8 where id=" + Request.QueryString["id"].ToString() + "";

                    }
                    else
                    {
                        SQL = "update room_number set Rn_state=5 where id=" + Request.QueryString["id"].ToString() + "";
                    }
                    fmhous.Update2(SQL);
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript'>alert('保存成功');ShowTabs('房态图',"+type+");</script>");

                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript'>alert('保存失败');</script>");

                }
            }
        }
        public void Bind() 
        {
            string roomnum = fmroom.GetModel(Convert.ToInt32(Request.QueryString["id"].ToString())).Rn_roomNum;
            txt_roomnum.Value = fmhous.GetModelList(" hs_room='" + roomnum + "' order by hs_date desc ")[0].hs_room;
            txt_wxyying.Value = fmhous.GetModelList(" hs_room='" + roomnum + "' order by hs_date desc ")[0].hs_yuany;
            txt_jsdate.Value = fmhous.GetModelList(" hs_room='" + roomnum + "' order by hs_date desc ")[0].hs_ylDate.ToString();
            txt_ksDate.Value = fmhous.GetModelList(" hs_room='" + roomnum + "' order by hs_date desc ")[0].hs_ksDate.ToString();
            txt_docNo.Value = fmhous.GetModelList(" hs_room='" + roomnum + "' order by hs_date desc ")[0].hs_Documentno;
            txt_remaker.Value = fmhous.GetModelList(" hs_room='" + roomnum + "' order by hs_date desc ")[0].hs_remaker;
            string a = Request.QueryString["types"].ToString();
            if (Request.QueryString["types"].ToString() == "2") 
            {
                txt_Name.Value = fmhous.GetModelList(" hs_room='" + roomnum + "' order by hs_date desc ")[0].hs_people;
                txt_result.Value = fmhous.GetModelList(" hs_room='" + roomnum + "' order by hs_date desc ")[0].hs_Result;
            }
        }

        
        protected void btndelete_Click(object sender, EventArgs e)
        {

        }
    }
}