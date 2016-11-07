using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.customer
{
   
    public partial class account_goods : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                BindRep();
                account.Value = Request.QueryString["accounts"].ToString();
                Js(account.Value);
                if (Request.QueryString["readValue"] != null)
                {
                    readValue.Value = Request.QueryString["readValue"];
                }
                else {
                    readValue.Value = "204";
                }
            }
        }
        BLL.account_goods bllag = new BLL.account_goods();
        BLL.goods_account bllga = new BLL.goods_account();
        private void BindRep() {
            //string account = Request.QueryString["accounts"].ToString();
            //rep1.DataSource = bllga.GetModelList1("ga_Account='" + account + "' and ga_Type=204");
            //rep1.DataBind();
        }

        BLL.customer bllcon = new BLL.customer();
        protected string GetName(string acc) {
            return bllcon.GetAccounts(acc).cName;
        }

        decimal ys = 0;
        decimal yus = 0;
        decimal yjs = 0;
        decimal njxf = 0;
        int rzts = 0;
        int notshow = 0;
        int qxyd = 0;
        int pm = 0;
        decimal wjs = 0;
        decimal yjsyyj = 0;

        int kkjs = 0;
       protected  int commy = 0;
        protected int commw = 0;

        protected Model.customer modelcus = null;
        /// <summary>
        /// 帐号
        /// </summary>
        /// <param name="acconut"></param>
        private void Js(string acconut1) {
            modelcus = bllcon.GetAccounts(acconut1);


            List<Model.goods_account> listag = bllga.GetModelList1("ga_Account='" + acconut1 + "'");
            if (listag.Count > 0) {
                foreach (Model.goods_account item in listag)
                {
                    if (item.ga_Type == 201) {
                        yus += Convert.ToDecimal(item.ga_price);
                    }
                    else if (item.ga_Type == 202) {
                       
                    }
                    else if (item.ga_Type == 203)
                    {
                        yjs += Convert.ToInt32(item.ga_sum_price);
                        if (item.ga_jsfs == 0) {
                            kkjs += Convert.ToInt32(item.ga_sum_price);
                        }
                    }
                    else if (item.ga_Type == 204)
                    {
                        ys += Convert.ToInt32(item.ga_sum_price);
                    }
                    njxf += Convert.ToDecimal(item.ga_sum_price);
                }
                
            }

            BLL.Commission bllcpp = new BLL.Commission();
            List<Model.Commission> listapp = bllcpp.GetModelList("Accounts='" + acconut1 + "'");
            if (listapp.Count > 0) {
                foreach (Model.Commission cp in listapp)
                {
                    if (cp.IsBack)
                    {
                        commy += Convert.ToInt32(cp.CommSum);
                    }
                    else {
                        commw += Convert.ToInt32(cp.CommSum);
                    }
                }
            }
            ysh.InnerText = ys.ToString(); ;
            yush.InnerText = (yus - kkjs).ToString();
            yjsh.InnerText = yjs.ToString();

            njxfs.InnerText = njxf.ToString();
        }
    }
}