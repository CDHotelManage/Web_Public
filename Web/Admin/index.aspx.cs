using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.MobileControls;
using System.Data;
using System.Collections;


namespace CdHotelManage.Web.Admin
{
    public partial class index : BasePage, System.Web.SessionState.IRequiresSessionState
    {
        BLL.MenuBLL menubll = new BLL.MenuBLL();
        BLL.AccountsUserRolesBLL userrolebll = new BLL.AccountsUserRolesBLL();
        BLL.RoleMenuBLL rolemenubll = new BLL.RoleMenuBLL();
        BLL.shopInfo bllsi = new BLL.shopInfo();
        protected Model.shopInfo modelsi = new Model.shopInfo();
        //protected void Page_Load(object sender, EventArgs e)
        //{


        //}
        string hotelID = string.Empty;
        
        string[] menu_pid = null;
        
        private void BindMenu()
        {
            try
            {
                //Model.AccountsUsers User = (Model.AccountsUsers)Session["User"];
                Model.AccountsUsers User = UserNow;
                if (User != null)
                {
                    Model.AccountsUserRoles UserRoles = userrolebll.GetModel(User.UserID, hotelID);
                    if (UserRoles != null)
                    {
                        string roleid = UserRoles.RoleID;
                        ViewState["roleid"] = roleid;
                        //获取菜单
                        DataTable dt = rolemenubll.GetList(roleid).Tables[0];
                        //获取一级菜单ID
                        List<string> menu_pidlist = new List<string>();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            menu_pidlist.Add(dt.Rows[i]["menu_pid"].ToString());  
                        }

                        menu_pid = GetString(menu_pidlist);
                        if (menu_pid.Length>0)
                        {
                            string html = "{";
                            for (int i = 0; i < menu_pid.Length; i++)
                            {
                                html += "name";
                                html += menu_pid[i] + ":[{";
                                html += "\"menuid\":\"" + menu_pid[i] + "\",";
                                html += "\"menuname\":\"" + GetMenuData(Convert.ToInt32(menu_pid[i])).title + "\",";
                                html += "\"menus\":[";

                                DataTable dtchild = rolemenubll.GetList(menu_pid[i], roleid).Tables[0];
                                if (dtchild != null)
                                {
                                    for (int j = 0; j < dtchild.Rows.Count; j++)
                                    {
                                        html += "{\"menuid\":\"" + dtchild.Rows[j]["Menu_id"].ToString() + "\",";
                                        html += "\"menuname\":\"" + GetMenuData(Convert.ToInt32(dtchild.Rows[j]["Menu_id"].ToString())).title + "\",";
                                        if (GetMenuData(Convert.ToInt32(dtchild.Rows[j]["Menu_id"].ToString())).imgurl != "")
                                        {
                                            html += "\"icon\":\"" + GetMenuData(Convert.ToInt32(dtchild.Rows[j]["Menu_id"].ToString())).imgurl + "\",";
                                        }
                                        html += "\"url\":\"" + GetMenuData(Convert.ToInt32(dtchild.Rows[j]["Menu_id"].ToString())).url + "\"";
                                        html += "},";
                                    }
                                    html = html.Substring(0, html.Length - 1);
                                    html += "]";
                                }
                                html += "}],";
                            }
                            html = html.Substring(0, html.Length - 1);
                            html += "}";
                            this.pp.InnerHtml = html;
                        }
                    }
                }
            }
            catch
            { 
            
            }

        }


        //过滤数据

        public static string[] GetString(List<string> values)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < values.Count; i++)
            {
                if (list.IndexOf(values[i]) == -1)
                    list.Add(values[i]);
            }

            return list.ToArray();
        }

        protected Model.Menu GetMenuData(int menu_id)
        {

            Model.Menu model = new Model.Menu();
            model = menubll.GetModel(menu_id);
            return model;
        }

        //绑定导航
        private void BindNav()
        {
            try
            {
                if (menu_pid != null)
                {
                    string menu_id = "";
                    for (int i = 0; i < menu_pid.Length; i++)
                    {
                        menu_id += menu_pid[i] + ",";
                    }
                    menu_id = menu_id.Substring(0, menu_id.Length - 1);
                    rptNav.DataSource = menubll.GetMenulist(menu_id);
                    rptNav.DataBind();
                }
                else
                {
                    rptNav.DataSource = null;
                    rptNav.DataBind();
                }
            }
            catch
            {
                rptNav.DataSource = null;
                rptNav.DataBind();
            }
        }


        //获取第一个子菜单

        public string[] GetChildMenu(string menu_id)
        { 
            string [] childinfo=new string[2];
            if (menu_id != "0")
            {
                DataTable dt = rolemenubll.GetSingleOrderByMenuId(menu_id ,ViewState["roleid"].ToString()).Tables[0];
                if (dt != null)
                {
                    int mid = Convert.ToInt32(dt.Rows[0]["Menu_id"].ToString());
                    Model.Menu model = menubll.GetModel(mid);
                    childinfo[0] = model.title;
                    childinfo[1] = model.url;
                }
                else
                {
                    childinfo[0] = "";
                    childinfo[1] = "";
                }    
            }
            return childinfo;
        }
        //public void BindFllor() 
        //{
        //  DataSet dt=
        //}

        public override void SonLoad()
        {
            if (!IsPostBack)
            {
                if (Session["User"] != null)
                {
                    hotelID = Request.QueryString["hid"];
                    BindMenu();
                    BindNav();
                }
                //if (Request.Cookies["User"] != null)
                //{
                //    BindMenu();
                //    BindNav();
                //}
                //else
                //{
                //    Response.Redirect("login.aspx");
                //}
            }
            modelsi = bllsi.GetModel(hotelID);
            
        }
    }
}
