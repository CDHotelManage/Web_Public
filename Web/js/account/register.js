define(function (require, exports, module) {
    var accountController = require("./account");


    var RegisterNet = {};
    /*
     * 可选参数
     */
    RegisterNet.options = {
        
    };
    RegisterNet.init = function () {
        RegisterNet.bindEvent();
    };

    RegisterNet.bindEvent = function () {
        
        $("#btnSubmitAccountVerify").click(function () {

            var $this = $(this);

            var acount = $("#txtAccount").val().trim();
            var verifyCode = $("#txtVerifyCode").val().trim();
            var userName = $("#txtUserName").val().trim();
            var password = $("#txtPassword").val().trim();

            accountController.registerAccount({
                Account: acount,
                VerifyCode: verifyCode,
                Password: password,
                UserName: userName
            }).then(function (data) {
                if (data.success == true) {
                    switch(data.result)
                    {
                        case 0:
                            alert("注册成功，请登录");
                            window.location.href = "./Admin/login.aspx";
                            break;
                        case 1:
                            alert("验证码错误");
                            break;
                        case 3:
                            alert("用户已注册过");
                            break;
                        case 4:
                            alert("认证码失效");
                            break;
                        case 5:
                            alert("密码格式错误");
                            break;
                        case 6:
                            alert("帐号修改前后一样");
                            break;
                        case 7:
                            alert("注册账号格式错误");
                            break;
                        default:
                            alert("注册动作执行失败");
                            break;
                    }                    
                } else {
                    alert("申请失败", 2);
                }
            });
        });

        
    };

    return RegisterNet;
});
