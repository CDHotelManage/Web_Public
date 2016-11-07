using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.ShiftExc
{
    public partial class OccupancySingle : BasePage
    {
        string orrderID = "2015417154829";
        BLL.occu_infor blloi = new BLL.occu_infor();
        protected System.Text.StringBuilder sbtext = new System.Text.StringBuilder();
        protected Model.occu_infor nowmodel = new Model.occu_infor();
        protected string strstrs = string.Empty;
        protected string tishi = string.Empty;
        protected string fangshi = "收款";
        protected string prices = string.Empty;
        BLL.SysParameter bllsys = new BLL.SysParameter();
        /// <summary>
        /// 通过ID日查询出来开的所有房间
        /// </summary>
        /// <param name="orrderID"></param>
        private void Bind(string orrderID) {
            List<Model.occu_infor> lisiico = blloi.GetDaySheetByOrderID(" order_id='" + orrderID + "'");
            if (lisiico != null) {
                nowmodel = lisiico[0];
                if (nowmodel.meth_pay_id == null) {
                    nowmodel.Meth_pay_model = new Model.meth_pay();
                    nowmodel.Meth_pay_model.meth_pay_name = "信用卡预授权";
                }
                foreach (Model.occu_infor model in lisiico)
                {
                    sbtext.Append("<tr><td>" + model.room_number + "</td><td>" + model.Real_mode_mode.real_mode_name + "</td><td>" + GetRoomStatu(model) + "</td><td>" + model.real_price + "</td></tr>");
                }
            }
            if (Request.QueryString["desp"] != null) {
                if (Convert.ToInt32(Request.QueryString["desp"]) < 0)
                {
                    fangshi = "退款";
                   
                }
                
                    nowmodel.deposit = Convert.ToDecimal(Request.QueryString["desp"]);
                
            }
            Model.SysParamter modelsys=bllsys.GetModel(1);
            if (nowmodel.real_mode_id == 2) { //如果是钟点房
            
            }
            else if (nowmodel.real_mode_id != 5)//如果是天房
            {
                if (modelsys.DayFee == 1)
                {
                    strstrs = "住宿时间超过次日" + modelsys.DayTime + "-" + modelsys.DayFeeTwo + "时按分钟收费，超过" + modelsys.DayFeeTwo + "时按一天结账。";
                }
                else {
                    strstrs = "住宿时间超过次日" + modelsys.DayTime + "-" + modelsys.DayFeeTwo + "时加收半费，超过" + modelsys.DayFeeTwo + "时按一天结账。";
                }
            }

            else if (nowmodel.real_mode_id == 5)//如果是凌晨房
            {
                string fee=string.Empty;
                string fangan=string.Empty;
                string sel=string.Empty;
                string EarlyOutTime = modelsys.EarlyOutTime.ToString();//凌晨房计费开始时间
                if (modelsys.EarlyFee == 1) {
                     fee = "加收半天房费";
                }
                else if (modelsys.EarlyFee == 2) {
                     fee = "按分钟收费";
                }
                else if (modelsys.EarlyFee == 3) {
                    fee = "不加收房费";
                }
                if (modelsys.EarlyFeeSel == 1) {
                    sel = "次日";
                }
                else if (modelsys.EarlyFeeSel == 2) {
                    sel = "当日";
                }
                string EarlyOutTimes = modelsys.EarlyOutTimes.ToString();//凌晨房结束时间
                if (modelsys.EarlyFeeTwo == 0) {
                    fangan = "加收全天房价";
                }
                else if (modelsys.EarlyFeeTwo == 1) {
                    fangan = "转为全天房价";
                }
                strstrs = "住宿时间超过" + sel + "" + EarlyOutTime + "-" + EarlyOutTimes + "时" + fee + "，超过" + EarlyOutTimes + "时" + fangan + "。";
            }
        }

        /// <summary>
        /// 获得实际费用
        /// </summary>
        /// <param name="statuid"></param>
        /// <returns></returns>
        public string GetRoomStatu(Model.occu_infor model)
        {
            //double price = Convert.ToDouble(model.real_price);
            //double zk = Convert.ToDouble(model.Hourse_scheme_model.hs_Discount) * Convert.ToDouble(0.1);
            //return (price * zk).ToString();
            string txt = GetRealName(model.real_mode_id);
            if (txt == "天房" || txt == "自用房" || txt == "免费房")
            {
                return bllty.GetModel(model.real_type_id).room_listedmoney.ToString();
            }
            if (txt == "钟点房")
            {
                return bllhr.GetModel( Convert.ToInt32(model.sort)).hs_start_price.ToString();
            }
            if (txt == "凌晨房")
            {
                return bllty.GetModel(model.real_type_id).Room_ealry_price.ToString();
            }
            if (txt == "月租房")
            {
                return bllty.GetModel(model.real_type_id).Room_Moth_price.ToString();
            }
            return "";
        }

        private string GetRealName(int id) {
            Model.real_mode modelrm = bllrm.GetModel(id);
            if (modelrm != null) {
                return modelrm.real_mode_name;
            }
            return "";
        }

        BLL.hour_room bllhr = new BLL.hour_room();

        BLL.real_mode bllrm = new BLL.real_mode();

        BLL.room_type bllty = new BLL.room_type();

        public override void SonLoad()
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["type"] != null)
                {
                    if (Request.QueryString["type"].ToString() == "rz")
                    {
                        tishi = "入住单";
                    }
                    else
                    {
                        tishi = "收款单";
                    }
                }
                if (Request.QueryString["orrderID"] != null)
                {

                    orrderID = Request.QueryString["orrderID"].ToString();
                    Bind(orrderID);
                }
            }
            

        }

        protected string GetXieYi(string account) { 
           BLL.customer bllcus = new BLL.customer();
            Model.customer modelcus = bllcus.GetAccounts(account);
            if (modelcus != null) {
                return modelcus.cName;
            }
            return "";
        }
    }
}