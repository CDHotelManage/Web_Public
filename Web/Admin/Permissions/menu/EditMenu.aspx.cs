using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;

namespace CdHotelManage.Web.Admin.Permissions.menu
{
    public partial class EditMenu : System.Web.UI.Page
    {
        BLL.MenuBLL menubll = new BLL.MenuBLL();
        string guid = Guid.NewGuid().ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["menu_id"]))
                {
                    int menu_id = Convert.ToInt32(Request.QueryString["menu_id"].ToString());
                    BindMenu();
                    BindMenu(menu_id);
                }
            }
        }

        //判断是否为数字
        private bool fornumber(TextBox tbox)
        {
            bool flag = false;
            Regex reg = new Regex("^[0-9]+$");
            Match ma = reg.Match(tbox.Text.Trim().Replace(".", ""));
            if (ma.Success)
            {
                flag = true;
            }
            return flag;
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                Model.Menu model = new Model.Menu();
                if (!string.IsNullOrEmpty(Request.QueryString["menu_id"]))
                {
                    int menu_id = Convert.ToInt32(Request.QueryString["menu_id"].ToString());
                    model.menu_id = menu_id;
                    model.title = this.txttitle.Text.Trim();
                    model.parent_id = Convert.ToInt32(this.drpMenu.SelectedValue);
                    model.url = this.txturl.Text.Trim();
                    if (this.UpIcon.PostedFile.FileName != "")
                    {
                        if (Upload("MenuIcon", "filetype", UpIcon, labmenuname))
                        {
                            if (ViewState["imgurl"] != null&&ViewState["imgurl"]!="")
                            {
                                File.Delete(Server.MapPath(ViewState["imgurl"].ToString()));
                            }
                            model.imgurl = "/Upload/MenuIcon/" + guid + Path.GetExtension(UpIcon.PostedFile.FileName).ToLower();
                            ViewState["imgurl"] = model.imgurl;
                        }
                        else
                        {
                            this.labmenuname.Text = "文件上传失败！";
                            return;
                        }
                    }
                    else
                    {
                        if (ViewState["imgurl"].ToString() != "" && ViewState["imgurl"] != null)
                        {
                            model.imgurl = ViewState["imgurl"].ToString();
                        }
                        else
                        {
                            model.imgurl = "";
                        }
                    }
                    if (this.txtsort.Text.Trim() != null && this.txtsort.Text.Trim() != "")
                    {
                        if (fornumber(this.txtsort))
                        {
                            model.sortId = Convert.ToInt32(this.txtsort.Text.Trim());
                        }
                        else
                        {
                            this.labsort.Text = "请输入有效的信息！";
                            return;
                        }
                    }
                    else
                    {
                        model.sortId = 0;
                    }
                    model.isable = this.radable.SelectedValue == "1" ? true : false;

                    if (menubll.Update(model))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('提交成功');parent.Window_Close();</script>");

                    }
                }
            }
            catch
            {
                Maticsoft.Common.MessageBox.ShowAndRedirect(this, "系统繁忙，请稍后再试!", "");
            }
        
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {

        }

        private void BindMenu(int menu_id)
        {
            if (menu_id != 0)
            {
                Model.Menu model = menubll.GetModel(menu_id);
                if (model != null)
                {
                    this.txttitle.Text = model.title;
                    this.txtsort.Text = model.sortId.ToString();
                    this.txturl.Text = model.url;
                    this.drpMenu.SelectedValue = model.parent_id.ToString();
                    ViewState["imgurl"] = model.imgurl;
                    this.radable.SelectedValue = model.isable == true ? "1" : "0";
                }
            }
        }

        private void BindMenu()
        {
            drpMenu.DataSource = menubll.GetList(" parent_id=0 ");
            drpMenu.DataValueField = "menu_id";
            drpMenu.DataTextField = "title";
            drpMenu.DataBind();

            drpMenu.Items.Insert(0, new ListItem("----请选择----", "0"));
        }

        //上传图片

        private bool Upload(string path, string type, FileUpload control, Label lab)
        {
            bool flag = false;
            string allowtype = ConfigurationManager.AppSettings[type];
            string[] types = allowtype.Split(',');

            FileInfo info = new FileInfo(control.PostedFile.FileName);
            if (control.HasFile)
            {
                foreach (string item in types)
                {
                    if (item == info.Extension.ToLower())
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    control.SaveAs(Server.MapPath("/Upload/" + path + "/") + guid + info.Extension.ToLower());
                }
            }
            return flag;
        }
    }
}