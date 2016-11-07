using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.member
{
    public partial class memberEdit : BasePage
    {
        BLL.UsersBLL blluser = new BLL.UsersBLL();
        

        private void Bind(string id) {
            List<Model.Users> listuser = blluser.GetModelList("u.userid='" + id + "'");
            if (listuser.Count > 0) {
               
                Model.Users mode = listuser[0];
                hiduid.Value = mode.userid;
                card.Value = mode.UserInfoModel.cardID;
                Name.Value = mode.username;
                Sex.Value = Convert.ToInt32(mode.UserInfoModel.sex).ToString();
                CardType.SelectedValue = mode.UserInfoModel.cardTypeID.ToString();
                CardNo.Value = mode.UserInfoModel.cardValue;
                CategoryId.SelectedValue = mode.user_type.ToString();
                Phone.Value = mode.UserInfoModel.phone;
                BirthDay.Value = mode.UserInfoModel.bairthday.ToString();
                Love.Value = mode.UserInfoModel.xihao;
                Address.Value = mode.UserInfoModel.address;
                Remark.Value = mode.UserInfoModel.meark;
            }
        }

       

        BLL.card_type bllct = new BLL.card_type();
        private void Bind1() {
            CardType.DataSource = bllct.GetList("");
            CardType.DataTextField = "ct_name";
            CardType.DataValueField = "id";
            CardType.DataBind();
        }

        BLL.userType bllut = new BLL.userType();
        private void Bind2()
        {
            CategoryId.DataSource = bllut.GetList("");
            CategoryId.DataTextField = "typename";
            CategoryId.DataValueField = "typeid";
            CategoryId.DataBind();
        }

        BLL.UserInfo bllui = new BLL.UserInfo();
        protected void btn_Sub_Click(object sender, EventArgs e)
        {
            Model.Users modeluser = new Model.Users();
            modeluser.username = Name.Value;
            if (hiduid.Value != "")
            {
                blluser.Update(modeluser);
                Model.UserInfo modelinfo = new Model.UserInfo();
                modelinfo.cardID = card.Value;
                modelinfo.userID = hiduid.Value;
                modelinfo.sex = Convert.ToBoolean( Convert.ToInt32(Sex.Value));
                modelinfo.cardTypeID = Convert.ToInt32(CardType.SelectedValue);
                modelinfo.cardValue = CardNo.Value;
                modelinfo.typeid = Convert.ToInt32(CategoryId.SelectedValue);
                modelinfo.phone = Phone.Value;
                modelinfo.bairthday = Convert.ToDateTime(BirthDay.Value);
                modelinfo.xihao = Love.Value;
                modelinfo.address = Address.Value;
                modelinfo.meark = Remark.Value;
                modelinfo.manageID = Convert.ToInt32(UserNow.UserID);
                if (bllui.Update(modelinfo))
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('更新成功');parent.Window_Close();</script>");
                }
            }
        }

        public override void SonLoad()
        {
           
            if (!IsPostBack)
            {
                Bind1();
                Bind2();
                if (Request.QueryString["type"] != null)
                {
                    string type = Request.QueryString["type"];
                    if (type == "edit")
                    {
                        card.Attributes.Add("disabled", "disabled");
                        CategoryId.Enabled = false;
                        if (Request.QueryString["id"] != null)
                        {
                            string id = Request.QueryString["id"].ToString();
                            Bind(id);
                        }
                    }
                    else if (type == "add")
                    {

                    }
                }
            }
        }
    }
}