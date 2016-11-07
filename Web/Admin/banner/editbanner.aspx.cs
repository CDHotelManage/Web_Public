using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;

namespace CdHotelManage.Web.Admin.banner
{
    public partial class editbanner : System.Web.UI.Page
    {
        string guid = Guid.NewGuid().ToString();
        BLL.bannerBLL bannerbll = new BLL.bannerBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["banner_id"].ToString()))
                {
                    string banner_id = Request.QueryString["banner_id"].ToString();
                    BindData(banner_id);
                } 
            }
        }


        private void BindData(string banner_id)
        {
            if (banner_id != "")
            {
                Model.banner model = bannerbll.GetModel(banner_id);
                if (model != null)
                {
                    this.txttitle.Text = model.title;
                    this.txtsort.Text = model.sortId.ToString();
                    ViewState["imgurl"] = model.imgurl;
                }
            }

        }


        protected void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                Model.banner model = new Model.banner();
                if (!string.IsNullOrEmpty(Request.QueryString["banner_id"].ToString()))
                {
                    string banner_id = Request.QueryString["banner_id"].ToString();
                    model.banner_id = banner_id;
                    model.title = this.txttitle.Text.Trim();
                    model.sortId = Convert.ToInt32(this.txtsort.Text);
                    model.pubdate = DateTime.Now;
                    if (this.UpFile.PostedFile.FileName != "")
                    {
                        if (Upload("Banner", "filetype", UpFile, labimg))
                        {
                            File.Delete(Server.MapPath(ViewState["imgurl"].ToString()));
                            model.imgurl = "/Upload/Banner/" + guid + Path.GetExtension(this.UpFile.PostedFile.FileName);
                            ViewState["imgurl"] = model.imgurl;
                        }
                        else
                        {
                            this.labimg.Text = "图片上传失败，请重试！";
                            return;
                        }
                    }
                    else
                    {
                        model.imgurl = ViewState["imgurl"].ToString();
                    }
                    bannerbll.Update(model);
                    Maticsoft.Common.MessageBox.ShowAndRedirect(this, "提交成功！", "");
                }
            }
            catch
            {

            }
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
        protected void btn_cancel_Click(object sender, EventArgs e)
        {

        }
    }
}