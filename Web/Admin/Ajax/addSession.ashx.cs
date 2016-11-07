using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CdHotelManage.Web.Admin.Ajax
{
    /// <summary>
    /// addSession 的摘要说明
    /// </summary>
    public class addSession : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Session["User"] != null)
            {
                context.Session["User"] = context.Session["User"] as Model.Users;
                context.Response.Write("保存Session");
            }
            else {
                context.Response.Write("失败");
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