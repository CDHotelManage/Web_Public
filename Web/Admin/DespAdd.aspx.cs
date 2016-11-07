using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin
{
    public partial class DespAdd : System.Web.UI.Page
    {
        BLL.hour_room bllhr = new BLL.hour_room();
        BLL.room_type bllry = new BLL.room_type();
        string type = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Binds();
                
                if (Request.QueryString["type"] != null)
                {
                    type = Request.QueryString["type"].ToString();
                }
                if (type == "xg")
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    Bind(id);
                }
                else if (type == "add")
                {
                    btnOk.Value = "添加";
                }
                
            }
            
        }

        void Binds() {
            ddllist.DataSource = bllry.GetAllList();
            ddllist.DataTextField = "room_name";
            ddllist.DataValueField = "id";
            ddllist.DataBind();


            mttype.DataSource = bllmt.GetAllList();
            mttype.DataTextField = "TypeName";
            mttype.DataValueField = "MtID";
            mttype.DataBind();
            mttype.Items.Insert(0, new ListItem("全部适用", "0"));
        }

        BLL.memberType bllmt = new BLL.memberType();

        void Bind(int id) {
            Model.hour_room modelhr = bllhr.GetModel(id);
            hidtxt.Value = modelhr.id.ToString();
            hs_name.Value = modelhr.hs_name;
            hs_start_long.Value = modelhr.hs_start_long;
            hs_start_price.Value = Convert.ToDecimal(modelhr.hs_start_price).ToString("0.##");
            hs_add_time.Value = modelhr.hs_add_time;
            hs_add_price.Value = Convert.ToDecimal(modelhr.hs_add_price).ToString("0.##");
            hs_min_time.Value = modelhr.hs_min_time;
            hs_min_price.Value =Convert.ToDecimal(modelhr.hs_min_price).ToString("0.##");
            hs_max_time.Value = modelhr.hs_max_time;
            ddllist.SelectedValue = modelhr.hs_type_id.ToString();
            mttype.SelectedValue = modelhr.MtID.ToString();
            
        }

        protected void btn_ok_click(object sender, EventArgs e) {
            Model.hour_room modelhrs = new Model.hour_room();
            if (hidtxt.Value != "")
            {
                modelhrs.id = Convert.ToInt32(hidtxt.Value);
            }
         
            modelhrs.hs_type_id = Convert.ToInt32(ddllist.SelectedValue);
            modelhrs.hs_name = hs_name.Value;
            modelhrs.hs_start_long = hs_start_long.Value;
            modelhrs.hs_start_price = Convert.ToDecimal(hs_start_price.Value);
            modelhrs.hs_add_time = hs_add_time.Value;
            modelhrs.hs_add_price =Convert.ToDecimal(hs_add_price.Value);
            modelhrs.hs_min_time = hs_min_time.Value;
            modelhrs.hs_min_price = Convert.ToDecimal(hs_min_price.Value);
            modelhrs.hs_max_time = hs_max_time.Value;
            modelhrs.MtID = Convert.ToInt32(mttype.SelectedValue);
            if (hidtxt.Value != "")
            {
                if (bllhr.Update(modelhrs))
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('更新成功');parent.Window_Close();</script>");
                }
            }
            else {
                bllhr.Add(modelhrs);
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('添加成功');parent.Window_Close();</script>");
            }
        }
    }
}