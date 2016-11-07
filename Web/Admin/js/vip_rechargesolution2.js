
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
    BindChange();

})


function AddHtml() {
    $.ajaxSetup({
        async: false
    });
    if ($("#RoomType").css("display") != "none") {
        var html = "";
        $(".ruzhu tr").each(function () {
            var RoomType = $(this).find(".roomType").attr("typeid");
            var Price = $(this).find(".Price").text();
            var zdPrice = $(this).find(".zdPrice").text();
            var protoPrice = $(this).find(".protoPrice").text();
            var mothPrice = $(this).find(".mothPrice").text();
            var commission = $(this).find(".commission").text();
            html += RoomType + "#" + Price + "#" + zdPrice + "#" + protoPrice + "#" + mothPrice + "#" + commission + ",";
        })
        $("#htmls").val(html);
    }
}




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
            htd.find("#protoPrice").val(parseFloat(Hs_yuan) * parseFloat(zk));
        }
    })

    $("#protoPrice").change(function () {
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
    var rtid = nowtr.find("#roomType").val();
    var Price = nowtr.find("#Price").val();
    var zdPrice = nowtr.find("#zdPrice").val();
    var Dayprice = nowtr.find("#protoPrice").val();
    var lcPrice = nowtr.find("#mothPrice").val();
    var commission = nowtr.find("#commission").val();
    var txt = nowtr.find("#roomType").find("option:selected").text();
    var trhtml = "<tr><td width=\"15%\" typeid='" + rtid + "' class=\"roomType\">" + txt + "</td><td width=\"15%\" class=\"Price\">" + Price + "</td><td width=\"15%\" class=\"zdPrice\">" + zdPrice + "</td><td width=\"15%\"class=\"protoPrice\">" + Dayprice + "</td><td width=\"15%\" class=\"mothPrice\">" + lcPrice + "</td><td width=\"15%\" class=\"commission\">" + commission + "</td><td width=\"16%\"><a href=\"#\" onclick=\"RowEdit(this)\"><img src=\"../images/037.gif\" width=\"10\"height=\"10\"></a><a href=\"#\" onclick=\"RowDelete(this)\"><img src=\"../images/010.gif\" width=\"10\" height=\"10\"></a></td></tr>";
    var b = true;
    $(".ruzhu tr").each(function () {
        var typeid = $(this).find(".roomType").attr("typeid");
        if (typeid == rtid) {
            b = false;
        }
    })
    if (b == false) {
        alert("不能选择一样的房型!");
    }
    else {
        nowtr.before(trhtml);
        nowtr.remove();
    }
    BindChange();
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
    $(editRow).find("#commission").val(trobj.find(".commission").text());
    $(editRow).find("#Price").val(trobj.find(".Price").text());
    $(editRow).find("#zdPrice").val(trobj.find(".zdPrice").text());
    $(editRow).find("#protoPrice").val(trobj.find(".protoPrice").text());
    $(editRow).find("#mothPrice").val(trobj.find(".mothPrice").text());
    $(trobj).before(editRow);
    $(trobj).remove();
    BindChange();
}
