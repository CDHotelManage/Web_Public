using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.ShiftExc
{
    public partial class Checkout : BasePage
    {
        string roomnum = string.Empty;
        protected System.Text.StringBuilder sbtext = new System.Text.StringBuilder();
        Model.occu_infor modeloi = new Model.occu_infor();
        BLL.occu_infor blloc = new BLL.occu_infor();
        protected string tuikuan = "0";
        protected Model.occu_infor modelocc = new Model.occu_infor();
        protected string shijian = "1";
       
        BLL.goods_account bllga = new BLL.goods_account();
        /// <summary>
        /// 通过房号查询账单
        /// </summary>
        private void Bind() {
            List<Model.goods_account> list = bllga.GetListOut("ga_occuid='" + roomnum + "'");
            //List<Model.goods_account> listmode = bllga.GetModelList("ga_occuid='" + roomnum + "' and ga_Type=6");
            List<Model.goods_account> listmode = list.Where(d => d.ga_Type == 6).ToList();
            if (listmode.Count>0)
            {
                tuikuan = listmode[0].ga_price.ToString();
            }
            if (list != null) {
                foreach (Model.goods_account model in list)
                {
                    if (model.ga_zffs_id == null)
                    {
                        sbtext.Append("<tr class=\"trs\"><td>" + model.ga_roomNumber + "</td><td>" + model.ga_name + "</td><td class=\"ff\">" + model.ga_price + "</td><td class=\"fy\">" + model.ga_sum_price + "</td><td></td></tr>");
                    }
                    else
                    {
                        sbtext.Append("<tr class=\"trs\"><td>" + model.ga_roomNumber + "</td><td>" + model.ga_name + "</td><td class=\"ff\">" + model.ga_price + "</td><td class=\"fy\">" + model.ga_sum_price + "</td><td>" + model.Meth_pay_model.meth_pay_name + "</td></tr>");
                    }
                }
            }
        }
        protected string GetXieYi(string account)
        {
            BLL.customer bllcus = new BLL.customer();
            Model.customer modelcus = bllcus.GetAccounts(account);
            if (modelcus != null)
            {
                return modelcus.cName;
            }
            return "";
        }

        /// <summary>
        /// 绑定入住人的信息
        /// </summary>
        private void BindOcc() {
            List<Model.occu_infor> list = blloc.GetModelList("order_id='" + roomnum + "'");
            if (list.Count > 0) {
                modelocc = list[0];
                //string s1 = modelocc.depar_time;
                DateTime dtone = Convert.ToDateTime(Convert.ToDateTime(modelocc.depar_time).ToString("yyyy-MM-dd"));
                DateTime dtwo = Convert.ToDateTime(Convert.ToDateTime(modelocc.occ_time).ToString("yyyy-MM-dd"));
                TimeSpan span = dtone.Subtract(dtwo); 
                //TimeSpan ts = Convert.ToDateTime(modelocc.depar_time) - Convert.ToDateTime(modeloi.occ_time);
                shijian = span.Days.ToString();
            }
        }

        public override void SonLoad()
        {
            if (Request["ga_sfacount"] != null)
            {
                roomnum = Request["ga_sfacount"].ToString();
                Bind();
                BindOcc();
            }
        }
    }
}