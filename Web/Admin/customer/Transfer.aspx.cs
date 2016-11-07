using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CdHotelManage.Web.Admin.customer
{
    public partial class Transfer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                string accoun = Request.QueryString["accounts"];
                account.Value = accoun;
                Bind(accoun);
            }

        }
       protected  System.Text.StringBuilder sbtext = new System.Text.StringBuilder();

        private void Bind(string account) {
            Dictionary<string, string> dic = new Dictionary<string, string>();
           
            string sql = "select ga_goodNo from goods_account where ga_Type=204 and ga_Account='" + account + "' group by ga_goodNo";
            DataTable dt = bllga.GetDsBySql(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string goodNo = dr[0].ToString();
                    if (!dic.ContainsKey(goodNo))
                    {
                        dic.Add(goodNo, "ok");

                        List<Model.goods_account> listga = bllga.GetModelList1("ga_goodNo='" + goodNo + "' and ga_Account='" + account + "'");
                        sbtext.Append("<tr><td width=\"5%\" style='display:none;'><input type=\"hidden\" value=" + goodNo + " class=\"ids\"/></td><td width=\"7%\">" + Convert.ToDateTime(listga[0].ga_date).ToString("yyyy-MM-dd") + "</td><td width=\"7%\">" + listga[0].Ga_Account + "</td><td width=\"10%\">" + GetName(listga[0].Ga_Account) + "</td><td width=\"7%\">" + listga[0].ga_roomNumber + "</td><td width=\"8%\">" + GetSumPrice(goodNo, account, 204) + "</td><td width=\"7%\">" + listga[0].ga_remker + "</td></tr>");
                    }
                }
            }

        }

        

        private string GetSumPrice(string Goodno, string account, int type)
        {
            decimal sum = 0;
            List<Model.goods_account> listga = bllga.GetModelList1("ga_goodNo='" + Goodno + "' and ga_Account='" + account + "' and ga_Type='" + type + "'");
            if (listga.Count > 0)
            {
                foreach (Model.goods_account model in listga)
                {
                    sum += Convert.ToDecimal(model.ga_sum_price);
                }
            }
            return sum.ToString();
        }

        BLL.goods_account bllga = new BLL.goods_account();
        private string GetUserName(string id)
        {
            BLL.AccountsUsersBLL blluser = new BLL.AccountsUsersBLL();
            return blluser.GetModel(id).UserName;
        }

        private string GetMethPay(int id)
        {
            BLL.meth_pay bllmp = new BLL.meth_pay();
            Model.meth_pay modelmp = bllmp.GetModel(id);
            return modelmp.meth_pay_name;
        }

        BLL.customer bllcon = new BLL.customer();
        protected string GetName(string acc)
        {
            return bllcon.GetAccounts(acc).cName;
        }


        protected void MemberCard_Click(object sender, EventArgs e) {
            string accountY = account.Value;
            string accountS = accounts.Value;
            if (accountS == accountY) {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('目标客户不能为自己！');</script>");
            }
            else
            {
                string goodno = goodnos.Value;
                List<Model.goods_account> listga = bllga.GetModelList1("ga_goodNo in (" + goodno + ") and ga_Account='" + accountY + "' and ga_Type=204");
                if (listga.Count > 0)
                {
                    foreach (Model.goods_account modelga in listga)
                    {
                        modelga.Ga_Account = accountS;
                        bllga.Update(modelga);
                    }
                }
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('转帐成功！');</script>");
            }
        }
    }
}