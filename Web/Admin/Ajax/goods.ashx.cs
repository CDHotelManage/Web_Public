using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;


namespace CdHotelManage.Web.Admin.Ajax
{
    /// <summary>
    /// goods 的摘要说明
    /// </summary>
    public class goods : IHttpHandler
    {
        HttpContext context = null;
        JavaScriptSerializer js = new JavaScriptSerializer();
        public void ProcessRequest(HttpContext context)
        {
            this.context = context;
            string type = context.Request.QueryString["type"];
            switch (type)
            {
                case "GetGoodsInfo":
                    GetGoodsInfo();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 获得商品详情信息
        /// </summary>
        private void GetGoodsInfo()
        {
            BLL.Goods bllgood = new BLL.Goods();
            int id = Convert.ToInt32(context.Request.QueryString["id"]);
            Model.Goods modelgood = bllgood.GetModel(id);
            string res = string.Empty;
            if (modelgood != null)
            {
                res = js.Serialize(modelgood);
            }
            context.Response.Write(res);
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