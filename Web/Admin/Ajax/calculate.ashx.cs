using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace CdHotelManage.Web.Admin.Ajax
{
    /// <summary>
    /// calculate 的摘要说明
    /// </summary>
    public class calculate : IHttpHandler
    {
        HttpContext context = null;
        public void ProcessRequest(HttpContext context)
        {
            this.context = context;
            string type = context.Request.QueryString["type"];
            switch (type)
            {
                case "GetHotelBs":
                    GetHotelBs();
                    break;
                case "gettime":
                    gettime();
                    break;
                case "GetInfoBySuo":
                    GetInfoBySuo();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 通过锁号找到房间号，开房方式，房型，开房时间，离开时间
        /// </summary>
        private void GetInfoBySuo()
        {
            string SuoMa = context.Request.QueryString["SuoMa"];
            BLL.SysParameter bllsys = new BLL.SysParameter();
            Model.SysParamter modelsyts = bllsys.GetModel(1);
            string suo = modelsyts.MarkSuo;
            BLL.SuoRoom bllss = new BLL.SuoRoom();
            List<Model.SuoRoom> listss = bllss.GetModelList("SuoType='" + suo + "' and SuoMa='" + SuoMa + "'");
            string roomNumber = "";
            string res = string.Empty;
            if (listss.Count > 0) {
                Model.SuoRoom modelss = listss[0];
                roomNumber = modelss.RoomNumber;
                BLL.occu_infor blloc = new BLL.occu_infor();
                List<Model.occu_infor> listocc = blloc.GetModelList("state_id=0 and room_number='" + roomNumber + "'");
                if (listocc.Count > 0)
                {
                    Model.occu_infor modelocc = listocc[0];
                    var obj = new { state = "0", occ_name = modelocc.occ_name.ToString(), occ_time = modelocc.occ_time.ToString(), depar_time = modelocc.depar_time.ToString(), fxxs = RealModel(modelocc.real_mode_id) };
                    res = js.Serialize(obj);
                }
                else {
                    var obj = new { state = "1" };
                }
            }
            context.Response.Write(res);
        }

        private string RealModel(int id) {
            BLL.real_mode bllrem = new BLL.real_mode();
            return bllrem.GetModel(id).real_mode_name;
        }

        private void gettime()
        {
            string BDatestr = DateTime.Now.ToString("yyMMddHHmm");//发卡时间必须取当前时间
            string EDatestr = DateTime.Now.AddDays(1).ToString("yyMMddHHmm");
            var obj = new { BDatestr = BDatestr, EDatestr = EDatestr };
            string res = js.Serialize(obj);
            context.Response.Write(res);
        }
        JavaScriptSerializer js = new JavaScriptSerializer();
        private void GetHotelBs()
        {
            string coid = "";
            int i;
            string datastr = context.Request.QueryString["datastr"];
            coid = datastr.Substring(8, 6);
            i = Convert.ToInt32(coid.Substring(0, 2), 16) * 65536 + Convert.ToInt32(coid.Substring(2, 4), 16) % 16383;
            datastr = datastr.Substring(24, 8);
            var obj = new { i = i, coid = coid, datastr = datastr };
            string res = js.Serialize(obj);
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