using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.Toroom
{
    public partial class GoodsCZ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { 
              if(Request.QueryString["id"]!=null){
                  txtid.Value = Request.QueryString["id"].ToString();
                  Model.goods_account gamodel = new Model.goods_account();
                  gamodel = bllga.GetModels1(Convert.ToInt32(Request.QueryString["id"]));
                  txtorderid.Value = gamodel.Ga_goodNo;
                  if (Request.QueryString["type"] == "edit") {
                      if (gamodel.ga_sum_price != 0)
                      {
                          czprice.Value = gamodel.ga_sum_price.ToString();
                      }
                      else {
                          czprice.Value = gamodel.ga_price.ToString();
                      }
                      czprice.Attributes.Add("disabled", "disabled");
                      //yying.Attributes.Add("disabled", "disabled");
                      yying.Value = gamodel.ga_remker;
                      btnok.Text = "确定";
                  }
              }
              
            }
        }

        BLL.goods_account bllga = new BLL.goods_account();
        protected void btnOk_Click(object sender, EventArgs e) {
            if (btnok.Text == "确定") {
                Model.goods_account gamodel = new Model.goods_account();
                gamodel = bllga.GetModels1(Convert.ToInt32(txtid.Value));
                gamodel.ga_remker = yying.Value;
                bllga.Update(gamodel);
                Response.Write("<script>parent.Window_Close();</script>");  
            }
            else
            {
                Model.goods_account gamodel = new Model.goods_account();
                gamodel = bllga.GetModels1(Convert.ToInt32(txtid.Value));
                if (gamodel.ga_price != 0)
                {
                    gamodel.ga_price = Convert.ToDecimal(czprice.Value) * -1;
                    gamodel.ga_sum_price = 0;
                    gamodel.ga_Type = 12;
                    gamodel.ga_remker = "冲减入帐日期为" + gamodel.ga_date + "的" + gamodel.ga_name + "" + gamodel.ga_price + "元!/n原因为:" + yying.Value;
                }
                if (gamodel.ga_sum_price != 0)
                {
                    gamodel.ga_price = Convert.ToDecimal(czprice.Value) * -1;
                    gamodel.ga_sum_price = 0;
                    gamodel.ga_Type = 12;
                    gamodel.ga_remker = "冲减入帐日期为" + gamodel.ga_date + "的" + gamodel.ga_name + "" + gamodel.ga_sum_price + "元!/n原因为:" + yying.Value;
                }
                gamodel.ga_name = "冲减";
                gamodel.ga_isys = 0;

                gamodel.ga_date = DateTime.Now;

                if (bllga.Add(gamodel) > 0)
                {
                    Response.Write("<script>alert('冲减成功');parent.Window_Close();</script>");
                }
                Helper.AddRoom(gamodel.ga_roomNumber);
            }
        }
    }
}