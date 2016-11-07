using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CdHotelManage.Web.Admin.Ajax
{
    /// <summary>
    /// IsDel 的摘要说明
    /// </summary>
    public class IsDel : IHttpHandler
    {
        HttpContext context = null;
        public void ProcessRequest(HttpContext context)
        {
            this.context = context;
            string type = context.Request["type"].ToString();
            switch (type)
            {
                case "loudong":
                    Loudong();
                    break;
                case "loucheng":
                    Loucheng();
                    break;
                case "fx":
                    Fx();
                    break;
                case "isroom":
                    Isroom();
                    break;
                case "goodsCate":
                    GoodsCate();
                    break;
                case "price":
                    Price();
                    break;
                case "isrz":
                    Isrz();
                    break;
                case "qingchu":
                    Qingchu();
                    break;
                default:
                    break;
            }
        }

        private void Qingchu()
        {
            HttpCookie cok = context.Request.Cookies["User"];
            cok.Expires = DateTime.Now.AddDays(-1);
            context.Response.AppendCookie(cok);
            context.Response.Write("ok");
            context.Response.End();
        }

        BLL.SysParameter bllsys = new BLL.SysParameter();

        /// <summary>
        /// 测试是否能入住
        /// </summary>
        private void Isrz()
        {
            Model.SysParamter modelsys = bllsys.GetModel(1);
            int ids = Convert.ToInt32(context.Request.QueryString["id"]);
            List<Model.room_number> list = bllrn.GetModelList("Rn_state=4 and id=" + ids); 
            if (modelsys.IsOcczf == false && list.Count>0)
            {
                context.Response.Write("ok");
                context.Response.End();
            }
            else {
                context.Response.Write("err");
                context.Response.End();
            }
        }
        BLL.room_state bllrs = new BLL.room_state();


        BLL.cost_type bllct = new BLL.cost_type();
        private void Price()
        {
            string id = context.Request.QueryString["id"];
            List<Model.cost_type> listg = bllct.GetModelList("ct_categories=" + id);
            if (listg.Count > 0)
            {
                context.Response.Write("ok");
            }
            else
            {
                context.Response.Write("err");
            }
        }
        BLL.Goods BLLG = new BLL.Goods();
        private void GoodsCate()
        {
            string id=context.Request.QueryString["id"];
            List<Model.Goods> listg = BLLG.GetModelList("Goods_categories=" + id);
            if (listg.Count > 0)
            {
                context.Response.Write("ok");
            }
            else
            {
                context.Response.Write("err");
            }
        }
        BLL.occu_infor blloi = new BLL.occu_infor();
        private void Isroom()
        {
            string id = context.Request.QueryString["id"];
            Model.room_number modelrn = bllrn.GetModel( Convert.ToInt32(id));
            List<Model.occu_infor> listoc = blloi.GetModelList("state_id=0 and room_number='" + modelrn.Rn_roomNum + "'");
            if (listoc.Count > 0)
            {
                context.Response.Write("ok");
            }
            else {
                context.Response.Write("err");
            }
        }

        private void Fx()
        {
            string id = context.Request.QueryString["id"];
            if (bllrn.GetModelList("Rn_room=" + id).Count > 0)
            {
                context.Response.Write("err");
            }
            else
            {
                context.Response.Write("ok");
            }  
        }
        BLL.room_number bllrn = new BLL.room_number();
        private void Loucheng()
        {
            string id = context.Request.QueryString["id"];
            if (bllrn.GetModelList("Rn_floor=" + id).Count > 0)
            {
                context.Response.Write("err");
            }
            else
            {
                context.Response.Write("ok");
            }
        }
        BLL.floor_manage bllfm = new BLL.floor_manage();
        private void Loudong()
        {
            string id = context.Request.QueryString["id"];
            if (bllfm.GetModelList("floor_sorting=" + id).Count > 0)
            {
                context.Response.Write("err");
            }
            else {
                context.Response.Write("ok");
            }
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