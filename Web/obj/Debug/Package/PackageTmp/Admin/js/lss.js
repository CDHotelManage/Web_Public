$(function () {
    $('html,body').click(function (e) {
        if (e.target.id.indexOf("CardNo") == -1) {
            $(".ac_results").css("display", "none");
        }
    });
    //GetListNum(); //获得会员列表
    GetCZ();

    $("#btnQuery").click(function () {
        var mids = $("#CardNo").val();
        Selcect(mids);
    })

    $("#CardNo").keyup(function () {
        var where = $("#CardNo").val();
        GetListNum(where);
    })
})


function GetCZ() {
    $("#PaymentAmount").change(function () {
        var sk = $("#PaymentAmount").val();
        var id = $("#CategoryId").val();
        //var NoCardFee = getSelectedByName("NoCardFee");
        $.get("/Admin/Ajax/Member.ashx", "type=GetPirceAddJf&sk=" + sk + "&id=" + id + "&NoCardFee=not", function (obj) {
            $("#TopAmount").val(obj.cz);
            $("#GiveScore").val(obj.zsjf);
        }, "json");
    })
}
$.ajaxSetup({
    async: false
});
function GetListNum(where) {
    $(".ac_results").css("display", "block");
    $.get("/admin/ajax/Member.ashx", "type=getallm&where=" + where, function (obj) {
        if (obj.statu == "err") {
            $(".ac_results").css("display", "none");
        }
        else if (obj.statu == "ok") {

            var tblist = obj.data;
            var html = ""
            for (var i = 0; i < tblist.length; i++) {
                html += "<li ><span style=\"width: 150px; display: inline-block\">卡号：<span class='mid'>" + tblist[i].Mid + "</span></span><span style=\"width: 150px; display: inline-block\">手机：" + tblist[i].Phone + "</span><span style=\"width: 70px;display: inline-block\">" + GetTypeName(tblist[i].Mtype) + "<strong></strong></li>";
            }
            $(".ac_results ul").html(html);
            $(".ac_results").css("border", "1px solid black");
            BindValue();
        }
    }, "json")
}

function BindValue() {
    $(".ac_results ul li").click(function () {
        var mids = $(this).find(".mid").text();
        $("#CardNo").val(mids);
        Selcect(mids);
    })
}


function GetTypeName(id) {
    var str = "";
    $.get("/admin/ajax/Member.ashx", "type=GetTypeName&id=" + id, function (obj) {
        str = obj;
    }, "text");
    return str;
}

function Selcect(mids) {
    var mid = mids;
    $("#mid").val(mid);
    $.get("/admin/ajax/Member.ashx", "type=getvalue&mid=" + mid, function (obj) {
        if (obj.states == "err") {
            alert("没有该会员!");
            window.location.reload();
        }
        else {
            $("#Name").text(obj.name);
            $("#MemberType").text(obj.zj);
            $("#MemberCardNo").text(obj.ZjNumber);
            $("#CategoryName").text(obj.typename);
            if (obj.Baithday != "") {
                $("#BirthDay").text(obj.Baithday);
            }
            $("#SalerMan").text(obj.sales);
            $("#Phone").text(obj.Phone);
            $("#Love").text(obj.Likes);
            $("#Address").text(obj.Address);
            $("#Remark").text(obj.Ramrek);
            $("#TotalScore").text(obj.sumjf);
            $("#UsedScore").text(obj.duihua);
            $("#UsableScore").text(obj.shengyu);
            $("#FrozenScore").text(obj.dongjie);
            $("#TotalAmount").text(obj.czsum);
            $("#UsedAmount").text(obj.xfsum);
            $("#UsableAmount").text(obj.czyue);
            $("#ConsumeTimes").text(obj.xfnum);
            $("#ConsumeAmount").text(obj.xfall);
            //$("#UsableAmount").text(obj.xfsum);//所有消费
            $("#StatusName").text(obj.state);
            if (obj.date != "") {
                $("#OpenDate").text(obj.date);
            }
            $("#ExprieDate").text(obj.yxtime);
            $("#CategoryId").val(obj.Mtype);
            if ($("#BtnSave").val() == "会员退卡") {
                if (obj.isok == 1) {
                    $("#OutPrice").val("0");
                }
                else {
                    $("#OutPrice").val(obj.cardPrice);
                }
            }
            if ($("#BtnSave").val() == "会员升级") {
                if (obj.umtid == 0) {
                    alert("已是最高级，不能升级");
                    window.location.reload();
                }
                else {
                    $("#CategorgName").val(obj.UpLive);
                    $("#CategorgId").val(obj.umtid);
                    if (parseInt(obj.shengyu) < parseInt(obj.ConsumpSum)) {
                        alert("积分不足，不能升级");
                        window.location.reload();
                    }
                    else {
                        if (obj.IsDeduction == 1) {
                            $("#DeductScore").val(obj.ConsumpSum);

                        }
                        else {
                            $("#DeductScore").val("0");
                        }
                    }
                }
            }
        }
    }, "json");
    $(".ac_results").css("display", "none");
}

function jsonDateFormat(cellval) {
    var date = new Date(parseInt(cellval.replace("/Date(", "").replace(")/", ""), 10));
    var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
    var currentDate = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
   
    return date.getFullYear() + "/" + month + "/" + currentDate;
}