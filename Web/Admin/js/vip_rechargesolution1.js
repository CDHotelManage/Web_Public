
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
        $.get("/admin/ajax/GoodsAcce.ashx", "type=getyuan&typeid=" + trobj.find("#roomType").val(), function (obj) {
            trobj.find("#Price").val(obj);
        }, "text");
        BindChange();
    });
    //提交表单
    $("#btnSubmit").click(function () {

    });


})



function BindChange() {
    $("#roomType").change(function () {
        var htd = $(this).parent().next();
        $.get("/admin/ajax/GoodsAcce.ashx", "type=getyuan&typeid=" + $(this).val(), function (obj) {
            htd.find("#Price").val(obj);
        }, "text")
    })

    $("#zdPrice").change(function () {
        var htd = $(this).parent().next();
        var Hs_yuan = $(this).parent().prev().find("#Price").val();
        var zk = $(this).val();
        if (zk != "" && (!/^\d+(\.\d+)?$/.test(zk) || parseFloat(zk) <= 0)) {
            alert("请输入正确格式!");
        }
        else {
            htd.find("#Dayprice").val(parseFloat(Hs_yuan) * parseFloat(zk));
        }
    })

    $("#Dayprice").change(function () {
        var nowtr = $(this).parent().parent();
        var Hs_yuan = nowtr.find("#Price").val();
        var Hs_zdr = $(this).val();
        if (Hs_zdr != "" && (!/^\d+(\.\d+)?$/.test(Hs_zdr) || parseFloat(Hs_zdr) <= 0)) {
            alert("请输入正确格式!");
        }
        else {
            nowtr.find("#zdPrice").val(parseFloat(Hs_zdr) / parseFloat(Hs_yuan));
        }
    })
}

function RowDelete(btn) {
    var nowtr = $(btn).parent().parent();
    var RowId = nowtr.find("#ids").val();
    if (confirm("是否确定删除?")) {
        if (RowId!= undefined) {
            $.get("/admin/ajax/Member.ashx", "type=delRow&id=" + RowId, function (obj) {
                if (obj == "ok") {
                    window.location.reload();
                }
            }, "text");
        }
        else {

            nowtr.remove();
        }
    }
}

function RowSave(btn) {
    var nowtr = $(btn).parent().parent();
    var RowId = nowtr.find("#RowId").val();
    var mtid=$("#memtypeid").val();
    var rtid = nowtr.find("#roomType").val();
    var Price = nowtr.find("#Price").val();
    var zdPrice = nowtr.find("#zdPrice").val();
    var Dayprice = nowtr.find("#Dayprice").val();
    var lcPrice = nowtr.find("#lcPrice").val();
    var txt=nowtr.find("#roomType").find("option:selected").text();
    $(".ruzhu tr").each(function () {
        if ($(this).find(".roomType").text() == txt) {
            nowtr.find("#roomType").css("border", "1px solid red");
        }
   })
    $.get("/admin/ajax/Member.ashx", "type=addmt&RowId=" + RowId + "&MTID=" + mtid + "&rtid=" + rtid + "&Price=" + Price + "&zdPrice=" + zdPrice + "&Dayprice=" + Dayprice + "&lcPrice=" + lcPrice, function (obj) {
        if (obj == "ok") {
            window.location.reload();
        }
        else {
            alert(obj);
        }
    }, "text");
}

function RowEdit(obj) {
    var trobj = $(obj).parent().parent();
    var editRow = $($("#divEditRow tbody").html());
    //$(editRow).find("#roomType").val(trobj.find(".roomType").text());
    $(editRow).find("#roomType option").each(function () {
        if ($(this).text() == trobj.find(".roomType").text()) {
            $(editRow).find("#roomType").val($(this).val());
        }
    })
    $(editRow).find("#Price").val(trobj.find(".Price").text());
    $(editRow).find("#zdPrice").val(trobj.find(".zdPrice").text());
    $(editRow).find("#Dayprice").val(trobj.find(".Dayprice").text());
    $(editRow).find("#lcPrice").val(trobj.find(".lcPrice").text());
    $(editRow).find("#RowId").val(trobj.find("#ids").val());
    $(trobj).before(editRow);
    $(trobj).remove();
}
