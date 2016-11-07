using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.Toroom
{
    public partial class AdjustPrice : System.Web.UI.Page
    {
        public int ids
        {

            get { return (int)ViewState["ids"]; }

            set { ViewState["ids"] = value; }

        }
        BLL.real_mode fmkffs = new BLL.real_mode();
        BLL.occu_infor fmrzInfo = new BLL.occu_infor();
        BLL.room_type fxBll = new BLL.room_type();
        BLL.guest_source fmkrly = new BLL.guest_source();
        BLL.hourse_scheme fmfjfa = new BLL.hourse_scheme();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ids = 18;
                Bind();
                BindKFFS();
                BindFJFA();
                BindKRLY();
            }
        }
        public void Bind()
        {
            Model.occu_infor mod = new Model.occu_infor();
            labfh.Text = fmrzInfo.GetModel(ids).room_number;
            labfx.Text = (fmrzInfo.GetModel(ids).real_type_id).ToString();
            labkffs.Text = (fmrzInfo.GetModel(ids).meth_pay_id).ToString();
            lably.Text = fmrzInfo.GetModel(ids).real_scheme_id.ToString();
            labname.Text = fmrzInfo.GetModel(ids).occ_name.ToString();
            labrzDate.Text = fmrzInfo.GetModel(ids).occ_time.ToString();
            labfjMoney.Text = fmrzInfo.GetModel(ids).real_scheme_id.ToString();
            labSymoney.Text = fmrzInfo.GetModel(ids).real_price.ToString();
        }
        /// 绑定开放方式
        /// </summary>
        public void BindKFFS()
        {
            DDlKffs.DataSource = fmkffs.GetAllList();
            DDlKffs.DataBind();
            DDlKffs.Items.Insert(0, "请选择开房方式");
        }

       

        /// <summary>
        /// 绑定房价方案
        /// </summary>
        public void BindFJFA()
        {
            DDLfjfa.DataSource = fmfjfa.GetAllList();
            DDLfjfa.DataTextField = "hs_name";
            DDLfjfa.DataValueField = "id";
            DDLfjfa.DataBind();
        }
        /// <summary>
        /// 绑定房价方案
        /// </summary>
        public void BindKRLY()
        {
            DDlkrly.DataSource = fmkrly.GetAllList();
            DDlkrly.DataTextField = "gs_name";
            DDlkrly.DataValueField = "id";
            DDlkrly.DataBind();
        }
        /// <summary>
        /// 房价调整
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdds_Click(object sender, EventArgs e)
        {

        }
    }
}