using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CdHotelManage.Web.Admin.Ajax
{
    public abstract class BaseHandler:IHttpHandler,System.Web.SessionState.IReadOnlySessionState
    {
        Model.AccountsUsers userNow = null;
        #region 1.0 统一的访问 当前登录用户 对象 的属性 + MODEL.Users UserNow
        /// <summary>
        /// 统一的访问 当前登录用户 对象 的属性
        /// </summary>
        public Model.AccountsUsers UserNow
        {
            get
            {
                if (userNow == null)
                {
                    userNow = context.Session["uinfo"] as Model.AccountsUsers;
                }
                return userNow;
            }
        }
        #endregion

        public bool IsReusable
        {
            get { throw new NotImplementedException(); }
        }
        HttpContext context = null;
        public void ProcessRequest(HttpContext context)
        {
            this.context = context;

        }

        /// <summary>
        /// 3.提供给子类 必须 重写的 一个 方法
        /// </summary>
        public abstract void SonLoad();
    }
}