using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Account
{
    /// <summary>
    /// 保存临时用户信息操作结果枚举
    /// </summary>
    public enum RegisterActionResult
    {
        /// <summary>
        /// 动作执行失败
        /// </summary>
        Failed = -1,

        /// <summary>
        /// 动作执行成功
        /// </summary>
        Success = 0,

        /// <summary>
        /// 验证码错误
        /// </summary>
        FieldInvalidVerifyCode = 1,

        /// <summary>
        /// 字段缺失
        /// </summary>
        FieldRequired = 2,

        /// <summary>
        /// 用户已注册过
        /// </summary>
        IsRegisted = 3,

        /// <summary>
        /// 认证码失效
        /// </summary>
        VerifyCodeExpired = 4,

        /// <summary>
        /// 密码格式错误
        /// </summary>
        PasswordRuleError = 5,

        /// <summary>
        /// 帐号修改前后一样
        /// </summary>
        AccountIsSame = 6,
        /// <summary>
        /// 注册账号格式错误
        /// </summary>
        AccountRuleError = 7

    }
}
