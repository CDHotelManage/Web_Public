/*会员类型*/
$(function () {
    Init();
})

function Init() {
    SEnables();
    SEnables1();
}
function BtnClick() {
    $("#btnRead").html("");
    $(".errorborder").removeClass("errorborder");
    var pro = preSave();
    return pro;
}
function SEnables() {
    var b = $("#SEnable1").attr("checked");
    if (b == false) {
        $("#ScoreType_x").attr("disabled", "disabled");
        $("#ScoreType_y").attr("disabled", "disabled");
        $("#Score_1").attr("disabled", "disabled");
        $("#Score_2").attr("disabled", "disabled");
    }
    else if (b == true) {
        $("#ScoreType_x").removeAttr("disabled");
        $("#ScoreType_y").removeAttr("disabled");
        $("#Score_1").removeAttr("disabled");
        $("#Score_2").removeAttr("disabled");
    }
}

function SEnables1() {
    var b = $("#SEnable2").attr("checked");
    if (b == false) {
        $("#Rule_x").attr("disabled", "disabled");
        $("#Rule_y").attr("disabled", "disabled");
    }
    else if (b == true) {
        $("#Rule_x").removeAttr("disabled");
        $("#Rule_y").removeAttr("disabled");
    }
}

function preSave() {
    var b_result = true;
    var Name = $("#Name").val();
    if (Name == "") {
        showTipsCollect(3, 'btnRead', '请输入会员类别名称', 'Name');
        b_result = false;
    }
    if (Name != "" && !/^[a-z\d\u4E00-\u9FA5]+$/i.test(Name)) {
        showTipsCollect(3, 'btnRead', '会员类别名称包含特殊字符', 'Name');
        b_result = false;
    }
//    var result = postSynRequest("/Services/BasicService.aspx", { id: id, Name: Name }, "MemberCategoryUsl", "CheckIsMemberCategory");
//    if (result.State.Success) {
//        showTipsCollect(3, 'btnRead', '该会员类别名称已存在', 'Name');
//        b_result = false;
//    }
    //检查卡费
    var CardFee = $("#CardFee").val();
    if (CardFee == "") {
        showTipsCollect(3, 'btnRead', '请输入卡费', 'CardFee');
        b_result = false;
    }
    if (CardFee != "" && !/^\-?\d+(\.\d+)?$/.test(CardFee)) {
        showTipsCollect(3, 'btnRead', '卡费请输入数字', 'CardFee');
        b_result = false;
    }
    if (parseInt(CardFee) < 0) {
        showTipsCollect(3, 'btnRead', '卡费不能小于0', 'CardFee');
        b_result = false;
    }
    //储值卡
    var TheCARDS = getSelectedByName("TheCARDS");
    var ThePrice = $("#ThePrice").val();
    if (TheCARDS == "0") {
        if (ThePrice == "") {
            showTipsCollect(3, 'btnRead', '请输入开卡时默认金额', 'ThePrice');
            b_result = false;
        }
    }
    if (ThePrice != "" && !/^\d+(\.\d+)?$/.test(ThePrice)) {
        showTipsCollect(3, 'btnRead', '开卡时默认金额请输入正数', 'ThePrice');
        b_result = false;
    }
    //会员升级
    var UpScore = $("#UpScore").val();;
    var MCategory = $("#MCategory").val();
    var MCategoryName = $("#MCategory option:selected").text();
    if (getSelectedByName("UpEnable") == "0") {
        if (UpScore == "") {
            showTipsCollect(3, 'btnRead', '请输入升级积分', 'UpScore');
            b_result = false;
        }
        if (MCategory == "" || MCategory == undefined || MCategory == null) {
            showTipsCollect(3, 'btnRead', '请选择升级会员类型', 'MCategory');
            b_result = false;
        }
        if (MCategoryName == Name) {
            showTipsCollect(3, 'btnRead', Name + "不允许再升级为" + MCategoryName, 'MCategory');
            b_result = false;
        }
    }
    if (UpScore != "" && (!/^\d+$/.test(UpScore) || parseInt(UpScore) < 0)) {
        showTipsCollect(3, 'btnRead', '升级积分请输入正整数', 'UpScore');
        b_result = false;
    }
    if (parseInt(UpScore) == 0)
    {
        UpScore = "";
    }
    var DayRoomHour = $("#DayRoomHour").val();;
    var HourRoomMin = $("#HourRoomMin").val();
    if (getSelectedByName("RoomMin") == "0") {
        if (DayRoomHour == "") {
            showTipsCollect(3, 'btnRead', '请输入天房退房延迟小时', 'DayRoomHour');
            b_result = false;
        }
        if (HourRoomMin == "") {
            showTipsCollect(3, 'btnRead', '请输入钟点房退房延迟小时', 'HourRoomMin');
            b_result = false;
        }
    }
    if (DayRoomHour != "" && !/^\d+$/.test(DayRoomHour)) {
        showTipsCollect(3, 'btnRead', '天房退房延迟小时请输入正整数', 'DayRoomHour');
        b_result = false;
    }
    if (HourRoomMin != "" && !/^\d+$/.test(HourRoomMin)) {
        showTipsCollect(3, 'btnRead', '钟点房退房延迟小时请输入正整数', 'HourRoomMin');
        b_result = false;
    }
    //if (parseInt(DayRoomHour) < 0) {
    //    showTipsCollect(3, 'btnRead', '天房退房延迟小时不能小于0', 'DayRoomHour');
    //    b_result = false;
    //}
    //if (parseInt(HourRoomMin) < 0) {
    //    showTipsCollect(3, 'btnRead', '钟点房退房延迟小时不能小于0', 'HourRoomMin');
    //    b_result = false;
    //}
    //提成设置
    var Setup = getSelectedByName("Setup");
    var SellCard = $("#SellCard").val(); //售卡提成

    var SellPrice = $("#SellPrice").val();

    var TopCard = $("#TopCard").val();   //充值提成
    var TopPrice = $("#TopPrice").val();
    if (Setup == "0") {
        if (SellCard == "" && TopCard == "") {
            showTipsCollect(3, 'btnRead', '售卡提成跟充值提成必须选一个', 'SellCard');
            showTipsCollect(3, 'btnRead', '', 'TopCard');
            b_result = false;

        }
    }
    if (SellCard == "2") {
        if (SellPrice == "") {
            showTipsCollect(3, 'btnRead', '请输入售卡提成比率', 'SellPrice');
            b_result = false;
        }
        if (SellPrice != "" && (!/^\d+(\.\d+)?$/.test(SellPrice) || parseFloat(SellPrice) < 0)) {
            showTipsCollect(3, 'btnRead', '售卡提成比率请输入正数', 'SellPrice');
            b_result = false;
        }
    }
    if (SellCard == "1") {
        if (SellPrice == "") {
            showTipsCollect(3, 'btnRead', '请输入售卡提成固额', 'SellPrice');
            b_result = false;
        }
        if (SellPrice != "" && (!/^\d+(\.\d+)?$/.test(SellPrice) || parseFloat(SellPrice) < 0)) {
            showTipsCollect(3, 'btnRead', '售卡提成固额请输入正数', 'SellPrice');
            b_result = false;
        }
    }

    if (TopCard == "2") {
        if (TopPrice == "") {
            showTipsCollect(3, 'btnRead', '请输入充值提成比率', 'TopPrice');
            b_result = false;
        }
        if (TopPrice != "" && (!/^\d+(\.\d+)?$/.test(TopPrice) || parseFloat(TopPrice) < 0)) {
            showTipsCollect(3, 'btnRead', '充值提成比率请输入正数', 'TopPrice');
            b_result = false;
        }
    }
    if (TopCard == "1") {
        if (TopPrice == "") {
            showTipsCollect(3, 'btnRead', '请输入充值提成固额', 'TopPrice');
            b_result = false;
        }
        if (TopPrice != "" && (!/^\d+(\.\d+)?$/.test(TopPrice) || parseFloat(TopPrice) < 0)) {
            showTipsCollect(3, 'btnRead', '充值提成固额请输入正数', 'TopPrice');
            b_result = false;
        }
    }

    //首次开房价
    var FirstPrice = $("#FirstPrice").val();
    if (FirstPrice == "") {
        showTipsCollect(3, 'btnRead', '请输入会员首次入住价', 'FirstPrice');
        b_result = false;
    }
    if (FirstPrice != "" && !/^\d+(\.\d+)?$/.test(FirstPrice)) {
        showTipsCollect(3, 'btnRead', '会员首次入住价请输入整数', 'FirstPrice');
        b_result = false;
    }
    //if (parseInt(FirstPrice) < 0) {
    //    showTipsCollect(3, 'btnRead', '会员首次入住价不能小于0', 'FirstPrice');
    //    b_result = false;
    //}

    return b_result;

}

//集中在div中显示提示
function showTipsCollect(type, divId, message, inputId) {
    $("#" + divId).html("");
    if (type == 1) {//正确提示
        $("#" + divId).append('<span class="formTips note">' + message + '</span>');
    }
    else if (type == 2) {//输入提示
        $("#" + divId).append('<span class="formTips prompt">' + message + '</span>');
    }
    else if (type == 3) {//错误提示
        $("#" + divId).append('<span class="formTips note_no">' + message + '</span>');
        //alert($.type(inputId));
        if ($.type(inputId) == 'string') {
            $("#" + inputId).addClass('errorborder');
        }
        else {
            $(inputId).addClass('errorborder');
        }
    }
}

function getRadioValue(name) {
    var res = "";
    $("input[name='" + name + "']").each(function () {
        if ($(this).attr("checked") == "checked") {
            res = $(this).val();
            return false;
        }
    });
    return res;
}


//期限
function bTimelimit() {
    var v = getSelectedByName("Limitcke");
    if (v == "0") {
        $(".Expire").removeAttr("disabled");
        $("#Expire").val("365");
    } else {
        $(".Expire").attr("disabled", "disabled");
    }
}
//积分卡
function bScoreEnable() {
    var v = getSelectedByName("ScoreChk");
    if (v == "0") {
        $(".disabled").removeAttr("disabled");
        $(".Enable").removeAttr("disabled");
        $(".stype").removeAttr("disabled", "disabled");
    } else {
        $(".disabled").attr("disabled", "disabled");
        $(".Enable").attr("disabled", "disabled");
        $(".stype").attr("disabled", "disabled");
    }
}
//积分超过
function bUpEnable() {
    var v = getSelectedByName("UpEnable");
    if (v == "0") {
        $(".upable").removeAttr("disabled");
        $("#MCategory").removeAttr("style");
    } else {
        $(".upable").attr("disabled", "disabled");
        $("#MCategory").attr("style", "background:#eee");
    }
}
//储值卡
function bTheCARDS() {
    var v = getSelectedByName("defaultPrice");
    if (v == "0") {
        $(".TheCARDS").removeAttr("disabled");
    } else {
        $(".TheCARDS").attr("disabled", "disabled");
    }
}
//提成设置
function bSetup() {
    var v = getSelectedByName("Setup");
    if (v == "0") {
        $(".Setup").removeAttr("disabled");
        $("#SellCard").removeAttr("style");
        $("#TopCard").removeAttr("style");
    } else {
        $(".Setup").attr("disabled", "disabled");
        $("#SellCard").attr("style", "background:#eee");
        $("#TopCard").attr("style", "background:#eee");
    }
}
//退房延时
function bRoomMin() {
    var v = getSelectedByName("RoomMin");
    if (v == "0") {
        $(".Hour").removeAttr("disabled");
    } else {
        $(".Hour").attr("disabled", "disabled");
    }
}
//按消费金额积分 按入住天数积分
function SEnable() {
    var v = getRadioValue("SEnable");
    if (v == "1") {
        $(".stype").removeAttr("disabled");
        $(".Enable").attr("disabled", "disabled");
        $("#IsAddScore").removeAttr("disabled");
    } else if (v == "2") {
        $(".stype").attr("disabled", "disabled");
        $(".Enable").removeAttr("disabled");
        setRadioValue("ScoreInclude", "1");
    } else {
        $(".stype").attr("disabled", "disabled");
        $(".Enable").attr("disabled", "disabled");
        $("#IsAddScore").removeAttr("disabled");
    }
}
//售卡提成
function bSellCard() {
    var v = $("#SellCard").val();
    if (v == "1") {
        $("#sell").html("&nbsp;元&nbsp;");
    } else if (v == "2") {
        $("#sell").html("&nbsp;%&nbsp;");
    }
}
//充值提成
function bTopCard() {
    var v = $("#TopCard").val();
    if (v == "1") {
        $("#top").html("&nbsp;元&nbsp;");
    } else if (v == "2") {
        $("#top").html("&nbsp;%&nbsp;");
    }
}
function getSelectedByName(name) {
    var ids = "";
    $("input[name='" + name + "']").each(function (e) {
        if (this.checked == true) {
            ids += this.value + ",";
        }
    });
    if (ids != "") {
        ids = ids.substring(0, ids.length - 1);
    }
    return ids;
}