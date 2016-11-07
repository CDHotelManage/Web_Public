/*充值方案*/
$(function () {
    //关闭
   
    var index = 0;
    
    //添加充值方案
    $(".btnAddOtherCustomer").click(function () {

        index++;
        var trobj = $($("#divEditRow tbody").html());
        trobj.find("input[type='radio']").attr("name", "Status" + index);
        trobj.find(".btnSave").attr("data-id", index);
        $(".ruzhu tbody").append(trobj);
    });
    //提交表单
    $("#btnSubmit").click(function () {
        var postData = preSave();
        if (!postData) {
            return false;
        }
        alert("充值方案修改成功");
        closeWin();
    });
})
//删除
function RowDelete(obj) {
    if (!confirm("是否要删除该充值方案？")) {
        return false;
    }
    var trobj = $(obj).parent().parent();
    var rowData = $(trobj).find("input[name='RowData']").val();
    var arrData = rowData.split('|');
    if (arrData[0] != "" && arrData[0] != null && arrData[0] != undefined) {
        $.get("/admin/ajax/Member.ashx", { type: "del", id: arrData[0] }, function (obj) {
            if (obj == "ok") {
                window.location.reload();
            }
        }, "text");
    } 
    else {
        $(trobj).remove();
    }
}
//编辑
function RowEdit(obj) {
    var trobj = $(obj).parent().parent();
    var rowData = $(trobj).find("input[name='RowData']").val();
    var arrData = rowData.split('|');
    var editRow = $($("#divEditRow tbody").html());
    var Status = "Status" + arrData[0];
    $(editRow).find("input[type='radio']").attr("name", Status)
    $(editRow).find("input[name='RowData']").val('');
    $(editRow).find("input[name='RowId']").val(arrData[0]);
    $(editRow).find("input[name='RechargeAmount']").val(arrData[1]);
    $(editRow).find("input[name='GivenAmount']").val(arrData[2]);
    $(editRow).find("input[name='GivenSorce']").val(arrData[3]);
    $(editRow).find("input[name='" + Status + "']").each(function () {
        if ($(this).val() == arrData[4]) {
            $(this).attr("checked", "checked")
            return false;
        }
    });
    $(trobj).before(editRow);
    $(trobj).remove();
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
//保存
function RowSave(obj) {

    var trobj = $(obj).parent().parent();
    var rowId = $(trobj).find("input[name='RowId']").val();
    //充值金额
    var RechargeAmount = $(trobj).find("input[name='RechargeAmount']").val();
    if (RechargeAmount == "") {
        showTipsCollect(3, 'btnRead', '请输入充值金额', $(trobj).find("input[name='RechargeAmount']"));

        return false;
    }
    if (RechargeAmount != "" && (!/^\d+(\.\d+)?$/.test(RechargeAmount) || parseFloat(RechargeAmount) <= 0)) {
        showTipsCollect(3, 'btnRead', '充值金额请输入正整数', $(trobj).find("input[name='RechargeAmount']"));
        return false;
    }
   
    //赠送金额
    var GivenAmount = $(trobj).find("input[name='GivenAmount']").val();
    //赠送积分
    var GivenSorce = $(trobj).find("input[name='GivenSorce']").val();
    if (GivenAmount == "" && GivenSorce == "") {
        showTipsCollect(3, 'btnRead', '赠送金额跟赠送积分必须填一个', $(trobj).find("input[name='GivenAmount']"));
        showTipsCollect(3, 'btnRead', '', $(trobj).find("input[name='GivenSorce']"));
        return false;
    }
    if (GivenAmount != "" && (!/^\d+(\.\d+)?$/.test(GivenAmount) || parseFloat(GivenAmount) < 0)) {
        showTipsCollect(3, 'btnRead', '赠送金额请输入正整数', $(trobj).find("input[name='GivenAmount']"));
        return false;
    }
    if (GivenSorce != "" && (!/^\d+$/.test(GivenSorce) || parseInt(GivenSorce) < 0)) {
        showTipsCollect(3, 'btnRead', '赠送积分请输入正整数', $(trobj).find("input[name='GivenSorce']"));
        return false;
    }

    
    var Status = "";
    if (rowId != "0") {
        Status = getRadioValue("Status" + rowId);
        Status = $(trobj).find("input[name='Status" + rowId + "']:checked").val();

    } else {
        var rowIndex = $(obj).attr("data-id");
        if (rowIndex == undefined || rowIndex == "" || rowIndex == null) {
            Status = $(trobj).find("input[name='Status" + rowId + "']:checked").val();
        } else {
            Status = $(trobj).find("input[name='Status" + rowIndex + "']:checked").val();
        }
    }
    var rowData = rowId + "|" + RechargeAmount + "|" + GivenAmount + "|" + GivenSorce + "|" + Status;
    var StatusName = "";
    if (Status == "0") {
        StatusName = "开启";
    } else {
        
        StatusName = "关闭";
    }
    var sowData = rowId + "|" + RechargeAmount + "|" + GivenAmount + "|" + GivenSorce + "|" + StatusName;
    var arrData = sowData.split('|');
    var detailRow = $($("#divDetailRow tbody").html());
    $(detailRow).find("td").each(function (i) {
        if (i < arrData.length) {
            $(this).html(arrData[i + 1]);
        }
    });
   
    $.get("/admin/ajax/Member.ashx", { type:"addFA", id: rowId, RechargeAmount: RechargeAmount, GivenAmount: GivenAmount, GivenSorce: GivenSorce, Status: Status }, function (obj) {
        $(detailRow).find("input[name='RowData']").val(rowData);
        $(trobj).before(detailRow);
        $(trobj).remove();
        window.location.reload();
    }, "json");
}
function preSave() {
    //检查用户资料
    $(".note_no").remove();
    $(".errorborder").removeClass('errorborder');
    var isOk = true;
    $(".ruzhu tbody tr").each(function () {
        var isEdit = $(this).find("input[name='RowState']").val();
        if (isEdit == "0") return true;
        if (!RowSave($(this).find(".btnSave"))) {
            isOk = false;
        }
    });
    if (!isOk) return false;
    var Recharge = "";
    $(".ruzhu tbody tr").each(function () {
        if (Recharge != "") Recharge += "&";
        var rowData = $(this).find("input[name='RowData']").val();
        Recharge += rowData;
    });
    if (!isOk) return false;
    return {
        Recharge: Recharge
    };
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

