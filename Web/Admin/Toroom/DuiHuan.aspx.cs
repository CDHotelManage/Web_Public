using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.Toroom
{
    public partial class DuiHuan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string mid = Request.QueryString["mid"];
                Bind(mid);
                txt_xfMoneys.Value = Request.QueryString["txt_xfMoneys"];
                if(Request.QueryString["orderid"]!=null){
                    orderid.Value = Request.QueryString["orderid"].ToString(); 
                }
            }
        }
        BLL.member bllme = new BLL.member();
        void Bind(string id)
        {
            Model.member model = bllme.GetModel(id);
            GetSumJf(id.ToString());
            CardNo.Value = model.Mid.ToString();
            CategoryName.Value = GetTypeName(Convert.ToInt32(model.Mtype));
            MemberName.Value = model.Name;
            //UsableAmount.Value = czyue.ToString();
            //Amount.Value = Request.QueryString["desp"];
            zjf.Value = sumjf.ToString();
            xyjf.Value = duihua.ToString();
            syjf.Value = shengyu.ToString();
        }


        BLL.mRecords bllrm = new BLL.mRecords();
        BLL.mRecords bllmr = new BLL.mRecords();
        private string GetTypeName(int id)
        {
            BLL.memberType bllmt = new BLL.memberType();
            if (id == 0)
            {
                return "";
            }
            return bllmt.GetModel(id).TypeName;
        }

        int sumjf = 0;//总积分
        int duihua = 0;//兑换积分
        int shengyu = 0;//剩余积分
        int dongjie = 0;//冻结积分
        int czsum = 0;//总存储值
        int xfsum = 0;//消费储值
        int czyue = 0;//储值谫
        int xfnum = 0;//消费次数
        int xfall = 0;//消费金额
        #region 获得总积分等等
        /// <summary>
        /// 获得总积分
        /// </summary>
        private void GetSumJf(string mid)
        {
            List<Model.mRecords> listmr = bllmr.GetModelList("mmid='" + mid + "'");
            if (listmr.Count > 0)
            {
                foreach (Model.mRecords model in listmr)
                {
                    if (model.Type == 1) //
                    {
                        czsum += Convert.ToInt32(model.Price);
                    }
                    if (model.Type == 2)
                    {
                        xfsum += Convert.ToInt32(model.Price);
                        xfnum++;
                    }
                    if (model.Type == 3)
                    {
                        sumjf += Convert.ToInt32(model.Price);
                    }
                    if (model.Type == 4)
                    {
                        duihua += Convert.ToInt32(model.Price);
                    }
                }

                czyue = czsum - xfsum;
                shengyu = sumjf - duihua;
            }
        }
        #endregion

        protected void bus_add_Click(object sender, EventArgs e) {
            string order = orderid.Value;
            List<Model.goods_account> listga = bllga.GetModelList1("ga_occuid='" + order + "'");
            if (listga.Count > 0) {
                Model.goods_account gamodel = listga[0];
                string Amount = Request["Amount"];
                gamodel.ga_price = Convert.ToDecimal(Amount) * -1;
                gamodel.ga_sum_price = 0;
                gamodel.ga_Type = 12;
                gamodel.ga_name = "积分优惠";
                gamodel.ga_isys = 0;
                gamodel.ga_date = DateTime.Now;
                gamodel.ga_remker = "积分抵换" + Amount;
                if (bllga.Add(gamodel)>0) { 
                   Model.mRecords modelmr=new Model.mRecords();
                   string mid=Request["CardNo"];
                   modelmr.mmid=mid;
                   modelmr.Price = Convert.ToInt32(Amount);
                   modelmr.Type = 4;
                   bllmr.Add(modelmr);
                }
                Response.Write("<script>alert('兑换成功');parent.Window_Close();</script>");
            }
        }
        BLL.goods_account bllga = new BLL.goods_account();
    }
}