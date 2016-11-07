using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.customer
{
    public partial class addContact :BasePage
    {
        BLL.Contacts bllcon = new BLL.Contacts();
        protected void BtnSave_Click(object sender, EventArgs e) {
            Model.Contacts modelcon = new Model.Contacts();
            modelcon.Accounts = Accounts.Value;
            modelcon.cName = cName.Value;
            modelcon.Sex = Convert.ToBoolean(Convert.ToInt32(Sex.SelectedValue));
            if (Bearthday.Value == "")
            {
                modelcon.Bearthday = null;
            }
            else
            {
                modelcon.Bearthday = Convert.ToDateTime(Bearthday.Value);
            }
            modelcon.editUser = UserNow.UserID;
            modelcon.addDatetime = DateTime.Now;
            modelcon.Appellation = Convert.ToInt32(Appellation.SelectedValue);
            modelcon.department = Convert.ToInt32(department.SelectedValue);
            modelcon.Post = Convert.ToInt32(Post.SelectedValue);
            modelcon.officPhone = officPhone.Value;
            modelcon.Phone = Phone.Value;
            modelcon.Address = Address.Value;
            modelcon.zipcode = zipcode.Value;
            modelcon.Mail = Mail.Value;
            modelcon.familyPhone = familyPhone.Value;
            modelcon.Likes = Likes.Value;
            modelcon.Remark = Remark.Value;
            if (Request.QueryString["type"] == "add") {
                if (bllcon.Add(modelcon) > 0)
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('新增成功');parent.window.location.reload();</script>");
                }
            }
            else if (Request.QueryString["type"] == "edit") {
                modelcon.ID = Convert.ToInt32(Request.QueryString["id"]);
                if (bllcon.Update(modelcon))
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('更新成功');parent.window.location.reload();</script>");
                }
            }
        }

        BLL.customer bllcus = new BLL.customer();
        public override void SonLoad()
        {
            if (!IsPostBack)
            {
                BindCall();
                BindcDepartment();
                BindcPost();
                Accounts.Value = Request.QueryString["accounts"];
                Model.customer model = bllcus.GetAccounts(Accounts.Value);
                if (model != null)
                {
                    cusDesy.InnerText = model.cusDesy;
                }
                if (Request.QueryString["type"] == "edit") {
                    BtnSave.Value = "更新客户";
                    BindInfo();
                }
            }
        }


        private void BindCall() {
            BLL.cCall blllcc = new BLL.cCall();
            Appellation.DataSource = blllcc.GetAllList();
            Appellation.DataTextField = "callName";
            Appellation.DataValueField = "ID";
            Appellation.DataBind();
        }

        private void BindcDepartment() {
            BLL.cDepartment BLLCD = new BLL.cDepartment();
            department.DataSource = BLLCD.GetAllList();
            department.DataTextField = "cDName";
            department.DataValueField = "ID";
            department.DataBind();
        }

        private void BindcPost()
        {
            BLL.cPost BLLCD = new BLL.cPost();
            Post.DataSource = BLLCD.GetAllList();
            Post.DataTextField = "cpName";
            Post.DataValueField = "ID";
            Post.DataBind();
        }

        private void BindInfo() { 
            int id= Convert.ToInt32(Request.QueryString["id"]);
            Model.Contacts modelcon = bllcon.GetModel(id);
            cName.Value = modelcon.cName;
            Sex.SelectedValue = Convert.ToInt32(modelcon.Sex).ToString();
            Bearthday.Value = modelcon.Bearthday.ToString();
            Appellation.SelectedValue = Convert.ToInt32(modelcon.Appellation).ToString();
            department.SelectedValue = Convert.ToInt32(modelcon.department).ToString();
            officPhone.Value = modelcon.officPhone;
            Phone.Value = modelcon.Phone;
            Address.Value = modelcon.Address;
            zipcode.Value = modelcon.zipcode;
            Mail.Value = modelcon.Mail;
            Post.SelectedValue = modelcon.Post.ToString();
            familyPhone.Value = modelcon.familyPhone;
            Likes.Value = modelcon.Likes;
            Remark.Value = modelcon.Remark;
        }
    }
}