using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
namespace CdHotelManage.Web.Admin.Toroom
{
    /// <summary>
    /// RoomInfo 的摘要说明
    /// </summary>
    public class RoomInfo : IHttpHandler
    {
        BLL.occu_infor fmoc = new BLL.occu_infor();
        string id = string.Empty;
        string roomNum = string.Empty;
        BLL.goods_account gmGood = new BLL.goods_account();
       
        public string content;
        HttpContext context = null;
        public void ProcessRequest(HttpContext context)
        {
            this.context = context;
            string type = context.Request["type"];
            switch (type)
            {
                case "yue":
                    Yue();
                    break;
                case "tangjian":
                    id = context.Request.QueryString["id"].ToString();
            roomNum = context.Request.QueryString["room"].ToString();
            BindGvInfo();
            context.Response.Write(content);
                    break;
                default:
                    break;
            }


            
        }



        void Yue() {
            double xiaofei = 0;//消费
            double shoukuan = 0;//收款
            double yue = 0;//余额
            string room1 = context.Request.QueryString["roomNum"].ToString();
            int id = fmoc.GetModels(" where room_number='" + room1 + "' and state_id=0 and occ_with='否'").occ_id;
            string orderid = fmoc.GetModels(" where room_number='" + room1 + "' and state_id=0 and occ_with='否'").order_id;
            IList<Model.goods_account> list = gmGood.GetModelList1(" ga_occuid='" + orderid + "'");
            for (int i = 0; i < list.Count; i++)
            {
                xiaofei += Convert.ToDouble((list[i].ga_price));
                shoukuan += Convert.ToDouble((list[i].ga_sum_price));

            }
            yue = shoukuan-xiaofei ;
            context.Response.Write(yue);
        }


        /// <summary>
        /// 获取在住客人详细详细
        /// </summary>
      
        public void BindGvInfo() 
        {
           string RoomNum = "";
           double xiaofei = 0;//消费
           double shoukuan = 0;//收款
           double yue = 0;//余额
           string sukeName = "";
           double ysk = 0;
           int id=fmoc.GetModels(" where room_number='"+roomNum+"' and state_id=0 and occ_with='否'").occ_id;
           string orderid = fmoc.GetModels(" where room_number='" + roomNum + "' and state_id=0 and occ_with='否'").order_id;
           string Ocnono = fmoc.GetModels(" where room_number='" + roomNum + "' and state_id=0 and occ_with='否'").occ_no;

           IList<Model.goods_account> list = gmGood.GetModelList1(" ga_occuid='" + orderid + "'");
           for (int i = 0; i < list.Count; i++)
           {
               xiaofei +=Convert.ToDouble(( list[i].ga_price));
               shoukuan += Convert.ToDouble((list[i].ga_sum_price));
               
           }
           IList<Model.occu_infor> lists = fmoc.GetModelList(" order_id='" + orderid + "' and occ_with='是'");
           for (int i = 0; i < lists.Count; i++)
           {
               if (sukeName == "")
               {
                   sukeName += (lists[i].occ_name);

               }
               else 
               {
                   sukeName += ";" + (lists[i].occ_name).ToString();
               }

           }
           yue = xiaofei-shoukuan;
           try
           {
               ysk = Convert.ToDouble(gmGood.GetModels(" where ga_occuid='" + Ocnono + "'").ga_price.ToString());
           }
           catch 
           {
               ysk = 0;
           }
           DataSet dts = fmoc.GetList(" order_id='" + orderid + "' and occ_with='否'");
           foreach (DataRow dr1 in dts.Tables[0].Rows) 
           {
               if (RoomNum == "")
               {
                   RoomNum += dr1["room_number"].ToString();

               }
               else { RoomNum += ";" + dr1["room_number"].ToString(); }
           }
           string a = RoomNum;
           DataSet dt=fmoc.GetList("  room_number='"+roomNum+"' and state_id=0 and occ_with='否'");
            foreach (DataRow dr in dt.Tables[0].Rows) 
            {
                content = dr["occ_name"].ToString() + "," + dr["room_number"].ToString() + "," + dr["sex"].ToString() + "," + GetRealTypeName(Convert.ToInt32(dr["real_type_id"].ToString())) + ","
                    + dr["occ_time"].ToString() + "," + dr["depar_time"].ToString() + "," + GetzjName(Convert.ToInt32(dr["card_id"].ToString())) + "," + dr["card_no"].ToString() + "," +
                    dr["state_id"].ToString() + "," + dr["address"].ToString() + "," + dr["remark"].ToString() + "," + GetKffsName(Convert.ToInt32(dr["real_mode_id"].ToString())) + "," + RoomNum + "," + shoukuan + "," + xiaofei + "," + yue + "," + sukeName + "," + ysk + "," + Convert.ToDecimal(dr["real_price"]).ToString("0.##") + "," + GetRealTypeNamePrice(Convert.ToInt32(dr["real_type_id"])) + "," + dr["mem_cardno"].ToString() + "," + GetXieYi(dr["accounts"].ToString());
            }
        }

        /// <summary>
        /// 获得协议单位名称 
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        private string GetXieYi(string account) {
            BLL.customer bllcus = new BLL.customer();
            Model.customer modelcus = bllcus.GetAccounts(account);
            if (modelcus != null) {
                return modelcus.cName;
            }
            return "";
        }

        //获得房型名称
        public string GetRealTypeNamePrice(int id)
        {

            BLL.room_type rtbll = new BLL.room_type();
            Model.room_type model = rtbll.GetModel(Convert.ToInt32(id.ToString()));
            return  Convert.ToDecimal(model.room_listedmoney).ToString("0.##");


        }

        //获得房型名称
        public string GetRealTypeName(int id)
        {

            BLL.room_type rtbll = new BLL.room_type();
            Model.room_type model = rtbll.GetModel(Convert.ToInt32(id.ToString()));
            return model.room_name;


        }
        //获得开房方式
        public string GetKffsName(int id)
        {
            BLL.real_mode fmkffs = new BLL.real_mode();
            Model.real_mode model = fmkffs.GetModel(Convert.ToInt32(id.ToString()));
            return model.real_mode_name;


        }
        //获得证件类型
        public string GetzjName(int id)
        {
            BLL.card_type fmtype = new BLL.card_type();
            Model.card_type model = fmtype.GetModel(Convert.ToInt32(id.ToString()));
            return model.ct_name;


        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}