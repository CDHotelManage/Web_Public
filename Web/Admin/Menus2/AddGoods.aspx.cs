using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.Menus2
{
    public partial class AddGoods : BasePage
    {
        
        BLL.meth_pay fmzffs = new BLL.meth_pay();
        /// <summary>
        /// 绑定支付方式
        /// </summary>
        public void BindZFFS()
        {
            DDlZffs.DataSource = fmzffs.GetList("meth_is_ya=1");
            DDlZffs.DataBind();
        }
        BLL.goods_account gabll = new BLL.goods_account();
        protected void okClick(object sender, EventArgs e) {
            try
            {
                if (Request.QueryString["type"] == "edit")
                {

                }
                else {
                    Model.goods_account modelga = new Model.goods_account();
                    modelga.ga_name = "非住客帐";
                    modelga.ga_number = "J" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace("-", "").Replace(":", "").Replace(" ", "").Replace("/", "");
                    modelga.ga_num = Convert.ToInt32(inputxt.Value);
                    modelga.ga_price = Convert.ToDecimal(Hidden1.Value);
                    modelga.ga_zffs_id = Convert.ToInt32(DDlZffs.SelectedValue);
                    modelga.ga_date = Convert.ToDateTime(DateTime.Now);
                    modelga.ga_people = UserNow.UserID;
                    modelga.ga_sum_price = 0;
                    modelga.ga_Type = 110;
                    modelga.ga_sfacount = "是";
                    modelga.ga_isys = 0;
                    modelga.ga_remker = Remark.Value;
                    int occid = gabll.Add(modelga);
                    if (occid > 0)
                    {
                        string str = xq.Value;
                        string[] strlist = str.Split(',');
                        foreach (string item in strlist)
                        {
                            Model.goods_account modelga1 = new Model.goods_account();
                            modelga1.ga_name = item.Split('#')[1];
                            modelga1.ga_number = item.Split('#')[0];
                            modelga1.ga_unit = item.Split('#')[2];
                            modelga1.ga_num = Convert.ToInt32(item.Split('#')[4]);
                            modelga1.ga_price = Convert.ToDecimal(item.Split('#')[3]);
                            modelga1.ga_sum_price = Convert.ToDecimal(item.Split('#')[5]);
                            modelga1.ga_zffs_id = Convert.ToInt32(DDlZffs.SelectedValue);
                            modelga1.ga_date = Convert.ToDateTime(DateTime.Now);
                            modelga1.ga_people = UserNow.UserID;
                            modelga1.ga_Type = 111;
                            modelga1.ga_sfacount = "是";
                            modelga1.ga_isys = 0;
                            modelga1.ga_remker = Remark.Value;
                            modelga1.ga_occuid = occid.ToString();
                            gabll.Add(modelga1);
                        }
                    }
                    Response.Write("<script>alert('入账成功!!');parent.window.location.reload();</script>");
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
            

        }
        protected System.Text.StringBuilder sb = new System.Text.StringBuilder();
        /// <summary>
        /// 绑定详情
        /// </summary>
        private void BindXq(int occid) {
            List<Model.goods_account> list = gabll.GetModelList1("ga_occuid=" + occid+" and ga_Type=111");
            if (list != null) {
                foreach (Model.goods_account item in list)
                {
                    sb.Append("<tr><td width=\"8%\">" + item.ga_number + "</td><td width=\"28%\">" + item.ga_name + "</td><td width=\"12%\">" + item.ga_unit + "</td><td width=\"12%\" style=\"text-align: right\">" + item.ga_price + "</td><td width=\"16%\"><input type=\"button\" value=\"-\" onclick='jian(this)' class=\"jia reduceProductNumber\" style=\"margin-right: -1px; height: 26px;float:left; margin-left:12px; display:inline\"><input type=\"text\" name=\"RowNumber\" class=\"ProductNumber\" onkeyup='Up(this)' style=\"width: 40px; float:left; height:22px\" value=\"" + item.ga_num + "\"><input type=\"button\" value=\"+\" class=\"jia addProductNumber\" onclick='jia(this)' style=\"margin-left: -1px; height: 26px;float:left\"></td><td width=\"12%\" style=\"text-align: right\" class=\"RowAmount\">" + item.ga_sum_price + "</td><td width=\"12%\"><img src=\"../images/010.gif\" width=\"9\" height=\"9\"><span class=\"STYLE1\">[</span><a href=\"javascript:void(0)\" onclick='clo(this)' class=\"btnRowDelete\">删除</a><span class=\"STYLE1\">]</span></td></tr>");
                }
            }
        }

        

        public override void SonLoad()
        {
            if (!IsPostBack) {
                if (Request.QueryString["type"] == "edit")
                {
                    Hidden2.Value = "edit";
                    btnSubmit.Style.Add("display", "none");
                    int occid= Convert.ToInt32(Request.QueryString["occid"]);
                    txt_Numbers.Attributes.Add("disabled", "disabled");
                    Number.Attributes.Add("disabled", "disabled");
                    DDlZffs.Attributes.Add("disabled", "disabled");
                    Remark.Attributes.Add("disabled", "disabled");
                    BindXq(occid);

                }
                BindZFFS();
            }
            
        }
    }
}