using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin
{
    public partial class PartHouse : System.Web.UI.Page
    {
        BLL.ZD_hourse bllzd = new BLL.ZD_hourse();
        BLL.hour_room bllhr = new BLL.hour_room();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
                if (Request.QueryString["type"] != null) {
                    if (Request.QueryString["type"] == "del") {
                        Del();
                    }
                }
            }
        }

        private void Del()
        {
            if (Request.QueryString["id"] != null) {
                if (bllhr.Delete(Convert.ToInt32(Request.QueryString["id"])))
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('删除成功');window.location.reload();</script>");
                }
            }
        }

        void Bind() {
            Model.ZD_hourse modelzd = bllzd.GetModel(1);
            begintime.Value = modelzd.beigin.ToString();
            endtime.Value = modelzd.endtime.ToString();
            //latest.Value = modelzd.latest.ToString();
            buffer.Value = modelzd.Buffer.ToString();
            tixing.Value = modelzd.tixing.ToString();

            rp1.DataSource= bllhr.GetModelList("");
            rp1.DataBind();
        }
                    
        protected void Btn_Ok_Click(object s, EventArgs e) {
            Model.ZD_hourse modelzd = bllzd.GetModel(1);
            modelzd.beigin = TimeSpan.Parse(begintime.Value);
            modelzd.endtime = TimeSpan.Parse(endtime.Value);
            //modelzd.latest = TimeSpan.Parse(latest.Value);
            modelzd.Buffer = Convert.ToInt32(buffer.Value);
            modelzd.tixing = Convert.ToInt32(tixing.Value);
            bllzd.Update(modelzd);
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('更新成功');window.location='PartHouse.aspx';</script>");
        }
        BLL.room_type bllrt = new BLL.room_type();
        protected string GetName(int id)
        {
            Model.room_type model = bllrt.GetModel(id);
            if (model != null)
            {
                return model.room_name;
            }
            return "";
        }

        
    }
}