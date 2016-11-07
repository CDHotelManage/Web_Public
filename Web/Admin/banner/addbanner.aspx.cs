using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;

namespace CdHotelManage.Web.Admin.banner
{
    public partial class addbanner : System.Web.UI.Page
    {
        string guid = Guid.NewGuid().ToString();
        BLL.bannerBLL bannerbll = new BLL.bannerBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GetSortID();
            }
        }
        private void GetSortID()
        {
            int count = 0;
            count = bannerbll.GetRecordCount("");
            if (count > 0)
            {
                this.txtsort.Text = (count + 1).ToString();
            }
            else
            {
                this.txtsort.Text = "1";
            }
        }


        protected void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                Model.banner model = new Model.banner();
                model.banner_id = guid;
                model.title = this.txttitle.Text.Trim();
                model.sortId = Convert.ToInt32(this.txtsort.Text);
                model.pubdate = DateTime.Now;
                if (this.UpFile.PostedFile.FileName != "")
                {
                    if (Upload("Banner", "filetype", UpFile, labimg))
                    {
                        model.imgurl = "/Upload/Banner/" + guid + Path.GetExtension(this.UpFile.PostedFile.FileName);
                    }
                    else
                    {
                        this.labimg.Text = "图片上传失败，请重试！";
                        return;
                    }
                }
                else
                {
                    this.labimg.Text = "请选择图片！";
                    return;
                }
                bannerbll.Add(model);
                Maticsoft.Common.MessageBox.ShowAndRedirect(this, "提交成功！", ""); 
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