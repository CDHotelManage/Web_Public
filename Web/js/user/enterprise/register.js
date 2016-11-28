define(function (require, exports, module) {
    var hotelController = require("../../common/hotel");
    var util = require('util');
    var request = util.getRequest();
    if (request['account']) {
        md.global.Account.accountId = request['account'];
    }
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

            var name = $("#txtHotelName").val().trim();
            var phone = $("#txtHotelPhone").val().trim();
            var fax = $("#txtHotelFax").val().trim();
            var address = $("#txtHotelAddress").val().trim();
            var remark = $("#txtHotelRemark").val().trim();
            if (name == '')
            {
                alert("酒店名称不能为空");
            }
            hotelController.createHotel({
                AccountID: md.global.Account.accountId,
                HName: name,
                HPhone: phone,
                HFax: fax,
                HAddress: address,
                Remark: remark
            }).then(function (data) {
                if (data.success == true) {
                    if(data.result)
                    {
                        alert("注册成功");
                        window.location.href = "/Admin/index.aspx";                        
                    }
                    else
                    {
                        alert("注册动作执行失败");
                    }
                } else {
                    alert("申请失败", 2);
                }
            });
        });

        
    };

    return RegisterNet;
});
