using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CdHotelManage.Web.Admin
{
    public abstract class BasePageVaile : System.Web.UI.Page, System.Web.SessionState.IRequiresSessionState
    {
        Model.AccountsUsers userNow = null;
        public Model.AccountsUsers UserNow
        {
            get
            {
                //if (userNow == null)
                //{
                //    userNow = Session["User"] as Model.AccountsUsers;
                //}
                return userNow;
            }
            set { userNow = value; }
        }
        private List<Model.print> listPrint = null;
        public List<Model.print> ListPrint
        {
            get { return bllp.GetModelList(""); }
        }
        BLL.infos bllif = new BLL.infos();
        BLL.shopInfo bllsi = new BLL.shopInfo();
        Model.shopInfo modelsi = new Model.shopInfo();

        BLL.print bllp = new BLL.print();
        public Model.shopInfo Modelsi
        {
            get { return modelsi; }
            set { modelsi = value; }
        }

        public Model.SysParamter SysModel { get; set; }
        BLL.SysParameter bllsys = new BLL.SysParameter();
        /// <summary>
        /// 验证方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            SysModel = bllsys.GetModel(1);
            List<Model.shopInfo> listif = bllsi.GetModelList("");
            if (listif.Count > 0)
            {
                modelsi = listif[0];
            }
            if (Request.Cookies["User"] == null)
            {
                //Page.ClientScript.RegisterStartupScript(GetType(), "info", "<script>alert('您还没有登录！');window.location='/Admin/login.aspx';</script>");
                Response.Write("<script>alert('您还没有登录!');window.location='/Admin/login.aspx';</script>");
                Response.End();
            }
            else
            {
                //Session["User"] = UserNow;
                string uid = Request.Cookies["User"].Value;
                UserNow = bllu.GetModel(uid);
            }
            SonLoad();
        }

        BLL.AccountsUsersBLL bllu = new BLL.AccountsUsersBLL();
        public abstract void SonLoad();
    }
}