using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.member
{
    public partial class typeEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                if (Request["type"] != null)
                {
                    if (Request["type"] == "edit")
                    {
                        if (Request["typeid"] != null)
                        {
                            Bind(Convert.ToInt32(Request["typeid"]));
                        }
                    }
                    else {
                        hidtypeid.Value = "";
                    }
                }
            }
        }
        BLL.userType bllut = new BLL.userType();
        void Bind(int typeid) {
            List<Model.userType> listut = bllut.GetModelList("typeid=" + typeid);
            if (listut.Count > 0) {
                Model.userType modeluts = listut[0];
                Name.Value = modeluts.typename;
                CardFee.Value = modeluts.typeprice.ToString();
                remark.Value = modeluts.remark;
                hidtypeid.Value = modeluts.typeid.ToString();
            }
        }

        protected void btn_Sub_Click(object sender, EventArgs e) {
            Model.userType modelut = new Model.userType();
            modelut.typename = Name.Value;
            modelut.typeprice = Convert.ToDecimal(CardFee.Value);
            modelut.remark = remark.Value;
            if (hidtypeid.Value != "")
            {
                modelut.typeid = Convert.ToInt32(hidtypeid.Value);
                if (bllut.Update(modelut))
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('更新成功');parent.Window_Close();</script>");
                }
            }
            else {
                modelut.typeid = bllut.GetModelList("")[bllut.GetModelList("").Count - 1].typeid + 1;
                if (bllut.Add(modelut)>0)
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('新增成功');parent.Window_Close();</script>");
                }
            }
        }
    }
}