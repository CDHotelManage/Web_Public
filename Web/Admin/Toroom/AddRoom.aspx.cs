using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace CdHotelManage.Web.Admin.Toroom
{
    public partial class AddRoom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                Bind();
            }
        }
        BLL.occu_infor blloc = new BLL.occu_infor();
        BLL.room_number bllrn = new BLL.room_number();
        BLL.goods_account bllga = new BLL.goods_account();
        private void Bind() {
            sbroom.Clear();
            int id = Convert.ToInt32(Request.QueryString["id"]);
            string room = blloc.GetModel(id).room_number;
            
            orderid.Value = blloc.GetModel(id).order_id;//得到 点击的OrderID
            loadRoom.Value = blloc.GetModel(id).room_number;
            rep.DataSource = blloc.GetModelList("order_id!='" + orderid.Value + "' and state_id=0");
            rep.DataBind();
        }
        System.Text.StringBuilder sbroom = new System.Text.StringBuilder();
        protected void BtnOk_Click(object a, EventArgs e) {
            for (int i = 0; i < this.rep.Items.Count; i++)
            {
                CheckBox check = (CheckBox)this.rep.Items[i].FindControl("cbk");
                if (check != null)
                {
                    if (check.Checked) {
                        HiddenField hidNewsId = this.rep.Items[i].FindControl("hidId") as HiddenField;
                        Model.occu_infor model = blloc.GetModel( Convert.ToInt32(hidNewsId.Value));
                        List<Model.occu_infor> listiccs = blloc.GetModelList(" order_id='" + model.order_id + "'");
                        if (listiccs.Count > 0) {
                            foreach (Model.occu_infor item in listiccs)
                            {
                                item.order_id = orderid.Value;
                                item.lordRoomid = loadRoom.Value;
                                blloc.Update(item);
                            }
                        }
                        List<Model.goods_account> listga = bllga.GetModelList1(" ga_occuid=" + model.order_id + "");
                        foreach (Model.goods_account modelga in listga)
                        {
                            modelga.ga_occuid = orderid.Value;
                            bllga.Update(modelga);
                        }
                        model.lordRoomid = loadRoom.Value;
                        model.order_id = orderid.Value;
                        blloc.Update(model);
                    }
                }
            }

            List<Model.occu_infor> listicc = blloc.GetModelList("order_id='" + orderid.Value + "'");
            foreach (Model.occu_infor item in listicc)
            {
                sbroom.Append(item.room_number + ",");
            }
            Helper.AddRoom(loadRoom.Value, sbroom.ToString() + loadRoom.Value + ",");
            Response.Write("<script>alert('合并成功！');parent.Window_Close();</script>");
        }

    }
}