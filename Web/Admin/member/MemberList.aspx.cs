using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.member
{
    public partial class MemberList : System.Web.UI.Page
    {
        BLL.UsersBLL user = new BLL.UsersBLL();
        BLL.AccountsUsersBLL bllau = new BLL.AccountsUsersBLL();
        protected  System.Text.StringBuilder sbtext = new System.Text.StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                Bind();
                if (Request["types"] != null)
                {
                    if (Request["types"] == "all") { Bind1(""); }
                    else
                    {
                        Bind1("user_type=" + Request["types"]);
                    }
                }
                else {
                    Bind1("");
                }
            }
        }
        BLL.userType bllut = new BLL.userType();
        private void Bind()
        {
            List<Model.userType> listut = bllut.GetModelList("");
            foreach (Model.userType item in listut)
            {
                sbtext.Append("<li ><span class=\"spancli\" onclick=\"selectWhere(" + item.typeid + ")\">" + item.typename + "</span><em class=\"edit\" onclick=\"ShowEdit(this," + item.typeid + ")\"></em><em class=\"dell\" onclick=\"Delete(" + item.typeid + ",this)\"></em></li>");
            }

            
        }

        private void Bind1(string where)
        {
            rep1.DataSource = user.GetModelList(where);
            rep1.DataBind();
            int pageSize = 1;
            int pageindex = 1;
            
        }


        

        protected string GetManageName(string id) {
            Model.AccountsUsers modelma = bllau.GetModel(id);
            if (modelma != null)
            {
                return modelma.UserName;
            }
            else {
                return "";
            }
        }

        protected string GetSex(bool b)
        {
            if (b)
            {
                return "女";
            }
            else
            {
                return "男";
            }
        }
    }
}