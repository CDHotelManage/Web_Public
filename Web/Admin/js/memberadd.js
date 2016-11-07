$(function () {

    BindEvent(); //类型改变事件
    CardVail(); //验证卡号
    Cha(); //手动改变收款金额
    /**/
    $("#CardNo").change(function () {
        var txt = $(this).val();
        $.get("/admin/ajax/Member.ashx", "type=getCard&cardno=" + txt, function (obj) {
            if (obj == "err") {
                Ts("<span class=\"formTips note_no\">该身份证号码已经存在!</span>");
            }
            else {
                $("#btnRead").html("");
            }
        }, "text");
    });
})

//是否免除卡费
function BtnCardFee() {
    var NoCardFee = getSelectedByName("NoCardFee");
    if (NoCardFee == "1") {
        if ($("#cardPice").val() != "") {
            $("#Amount").val(parseInt($("#Amount").val()) - parseInt($("#cardPice").val()));
            GetPriceAddjf();
        }

    }
    else {
        $("#Amount").val(parseInt($("#Amount").val()) + parseInt($("#cardPice").val()));
        GetPriceAddjf();
    }
}

var isok = false;
function CardVail() {
    //查询卡号是否可以用
    if ($("#CAdd").css("display") != "none") {
        $("#btnSearch").click(function () {
            var num = $("#MemberCardNo").val();
            if (num == "") {
                Ts("<span class=\"formTips note_no\">请输入正确卡号</span>");
            }
            else {
                $.get("/Admin/Ajax/Member.ashx", "type=isok&num=" + num, function (obj) {
                    if (obj == "err") {
                        isok = true;
                        Ts("<span class=\"formTips note\">该卡号可用</span>");
                    }
                    else if (obj == "ok") {
                        Ts("<span class=\"formTips note_no\">该卡号已存在</span>");
                    }
                }, "text");
            }
        })
    }
}

function Cha() {
    $("#Amount").change(function () {
        GetPriceAddjf();
    })
}

//类型事件事件
function BindEvent() {
    $("#CategoryId").change(function () {
        $("#NoCardFee").removeAttr("checked");
        var id = $(this).val();
        GetPrice(id);
    })
}
//通过类型ID获得收款金额和充值金额以及赠送积分
function GetPrice(id) {
    $.get("/Admin/Ajax/Member.ashx", "type=getprice&id=" + id, function (obj) {
        $("#Amount").val(obj.sk);
        $("#TopAmount").val(obj.cz);
        $("#GiveScore").val(obj.jf);
        $("#cardPice").val(obj.cardPice);
        GetPriceAddjf(); //重新计算赠送积分和金额
    }, "json");
   
}
//通过金额获赠送的金额和积分
function GetPriceAddjf() {
    var sk = $("#Amount").val();
    var id = $("#CategoryId").val();
    var NoCardFee = getSelectedByName("NoCardFee");
    $.get("/Admin/Ajax/Member.ashx", "type=GetPirceAddJf&sk=" + sk + "&id=" + id + "&NoCardFee="+NoCardFee, function (obj) {
        $("#TopAmount").val(obj.cz);
        $("#GiveScore").val(obj.zsjf);
    }, "json");
}

function IsFill() {
    if ($("#CAdd").css("display") != "none") {
        if (!isok) {
            Ts("<span class=\"formTips note_no\">请验证卡号是否可用</span>");
            return false;
        }
        else if ($("#Name").val() == "") {
            Ts("<span class=\"formTips note_no\">姓名不能为空</span>");
            return false;
        }
        else if ($("#CategoryId").val() == "0") {
            Ts("<span class=\"formTips note_no\">请选择会员类型</span>");
            return false;
        } 
    }
    return true;
}

function Ts(str) {
    $("#btnRead").html(str);
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