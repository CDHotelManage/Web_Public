using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.member
{
    public partial class mtPrice : System.Web.UI.Page
    {
        protected System.Text.StringBuilder sbtext = new System.Text.StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                Bind();  
            }
        }

        BLL.mtPrice bllmt = new BLL.mtPrice();
        private void Bind() {

            BLL.room_type bllrt = new BLL.room_type();
            List<Model.room_type> listrt = bllrt.GetModelList("");
            foreach (Model.room_type item in listrt)
            {
                sbtext.Append("<option value='" + item.id + "'>" + item.room_name + "</option>");
            }

            if (Request.QueryString["mtid"] != null) {
                int mtid = Convert.ToInt32(Request.QueryString["mtid"]);
                memtypeid.Value = mtid.ToString();
                List<Model.mtPrice> listmt = bllmt.GetModelList("MTID=" + mtid);
                rep1.DataSource = listmt;
                rep1.DataBind();
            }
        }

        /// <summary>
        /// 获得原价
        /// </summary>
        protected string Getyuan(int typeid)
        {
            Model.room_type modelty = bllrt.GetModel(typeid);
            if (modelty != null)
            {
                return modelty.room_name;
            }
            return "";
        }
        BLL.room_type bllrt = new BLL.room_type();
    }
}