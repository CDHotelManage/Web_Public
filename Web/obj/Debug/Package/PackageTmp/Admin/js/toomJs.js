var time1;
window.onload = function () {
    Init();
    $(".bor").parent().css("border", "1px solid #ffce33");
    time1 = setInterval("Info()", "1000");
    var timessss = setInterval("ShowTime()", "1000");
    NumStatuNum();
}
function Init() {
    $("#DivContent .hidli li").each(function () {
        if ($(this).attr("state") == 2 || $(this).attr("state") == 7) {
            YUE($(this));
        }
    });

}
function ShowTime() {
    var nowli = null;
    $("li").each(function () {
        if ($(this).attr("state") == 2 || $(this).attr("state") == 7) {
            nowli = $(this);
            if ($(this).find(".shengyu").text() != "") {
                if (parseInt($(this).find(".shengyu").text()) >= 0) {
                    $(this).find(".shengyu").text(parseInt($(this).find(".shengyu").text()) - 1);
                    if ($(this).find(".stime").text() != "") {
                        ShowTime1(parseInt($(this).find(".shengyu").text()), nowli);
                    }
                }
                else {//如果已经超时
                    $.get("/Admin/Ajax/SysPara.ashx?r=" + Math.random(), "type=getRoomModel&roomnumber=" + nowli.attr("rooms"), function (obj) {
                        $(".hidli[rooms='" + nowli.attr("rooms") + "']").html("<ul>" + obj + "</ul>");
                        $("#DivContent li").each(function () {
                            if ($(this).attr("state") == 2 && $(this).attr("rooms") == nowli.attr("rooms")) {
                                YUE($(this));
                            }
                            if ($(this).attr("state") == 7 && $(this).attr("rooms") == nowli.attr("rooms")) {
                                YUE($(this));
                            }
                        });
                        $('.content li').unbind('mousedown');
                        $(".main .bgorange").unbind('click');
                        MyClick();
                    }, "text");
                }
            }
        }
    })
}
function checkRate(input) {
    var re = /^[-+]?[0-9]+(\.[0-9]+)?$/;
    var nubmer = document.getElementById(input).value;
    if (!re.test(nubmer)) {
        alert("请输入数字");
        document.getElementById(input).value = "";
        return false;
    }
}
var count = 0;
function SetValue(nowlis, obj) {

    var list = obj.split(",");
    if (list.length <= 2) {
        nowlis.find(".yue1").html(list[0]);
        var dd = list[0].replace(/<\/?.+?>/g, "");
        var dds = dd.replace(/&nbsp;/g, ""); //dds为得到后的内容

        if (dds < 0) {

            nowlis.find(".qianfei").html("<img src='/admin/images/iconqf.png'>");
            count++;
        }
        //Updatestate(nowlis, list[1]);
    }
    else {
        if (list[2] == "tf") {
            nowlis.find(".yue1").html(list[0]);
            nowlis.find(".shengyu").html(list[1]);
            var dd = list[0].replace(/<\/?.+?>/g, "");
            var dds = dd.replace(/&nbsp;/g, ""); //dds为得到后的内容 
            if (dds < 0) {
                nowlis.find(".qianfei").html("<img src='/admin/images/iconqf.png'>");
                count++;
            }
            // Updatestate(nowlis, list[3]);
        }
        else {
            nowlis.find(".yue1").html(list[1]);
            nowlis.find(".stime").text(list[0]);
            nowlis.find(".shengyu").text(list[3]);
            var dd = list[1].replace(/<\/?.+?>/g, "");
            var dds = dd.replace(/&nbsp;/g, ""); //dds为得到后的内容 
            if (dds < 0) {
                nowlis.find(".qianfei").html("<img src='/admin/images/iconqf.png'>");
                count++;
            }
            //Updatestate(nowlis, list[4]);
            ShowTime1(parseInt($(this).find(".shengyu").text()), nowlis);
        }
    }
    $("#spanqianf").html(count);

}

function ShowTime1(EndTimeMsg, nowli) {
    var h = Math.floor(EndTimeMsg / 60 / 60);   //得到小时
    var m = Math.floor((EndTimeMsg - h * 60 * 60) / 60); //得到分钟
    var s = Math.floor(EndTimeMsg - h * 60 * 60 - m * 60); //秒
    var d = parseInt(h / 24);
    //alert(h + "小时," + m + "分钟");
    nowli.find(".stime").text(h + ":" + m + ":" + s);
}
$.ajaxSetup({
    async: false
});
function Info() {

    $.get("/Admin/Ajax/SysPara.ashx?inti=" + Math.random(), "type=infos", function (obj) {
        if (obj.statu == "ok") {
            clearInterval(time1);
            var numbers = obj.data.number;
            var id = obj.data.id;

            var reamrk = obj.data.type;
            var imgsrc = $(".hidli[rooms='" + numbers + "']").find(".lfico").html();
            if (imgsrc != "" || reamrk != "") {
                if (reamrk != "") {
                    var s = reamrk.substring(0, reamrk.length - 1);
                }
                else {
                    var s = LianFan(imgsrc);
                }
                $.get("/Admin/Ajax/Books.ashx?up=" + Math.random(), "type=updateSeesion", function (obj) { }, "text");
                var slist = s.split(",");
                for (var i = 0; i < slist.length; i++) {
                    $.get("/Admin/Ajax/SysPara.ashx?model1=" + Math.random(), "type=getRoomModel&roomnumber=" + slist[i], function (obj) {
                        $(".hidli[rooms='" + slist[i] + "']").html("<ul>" + obj + "</ul>");
                        $("#DivContent li").each(function () {
                            if ($(this).attr("state") == 2 && $(this).attr("rooms") == slist[i]) {
                                YUE($(this));
                            }
                            if ($(this).attr("state") == 7 && $(this).attr("rooms") == slist[i]) {
                                YUE($(this));
                            }
                        });
                        $('.content li').unbind('mousedown');
                        $(".main .bgorange").unbind('click');
                        MyClick();

                    }, "text");
                }

            }
            else {
                $.get("/Admin/Ajax/SysPara.ashx?model1=" + Math.random(), "type=getRoomModel&roomnumber=" + numbers, function (obj) {
                    $(".hidli[rooms='" + numbers + "']").html("<ul>" + obj + "</ul>");
                    $("#DivContent li").each(function () {
                        if ($(this).attr("state") == 2 && $(this).attr("rooms") == numbers) {
                            YUE($(this));
                        }
                        if ($(this).attr("state") == 7 && $(this).attr("rooms") == numbers) {
                            YUE($(this));
                        }

                    });
                    $('.content li').unbind('mousedown');
                    $(".main .bgorange").unbind('click');
                    MyClick();
                }, "text");
            }
            NumStatuNum();
            setTimeout("DelInfo(" + id + ")", "1500");

        }
    }, "json");
}

function LianFan(txt) {
    var s = "";
    $(".hidli").each(function () {
        if ($(this).find(".lfico").html() == txt) {
            s += $(this).attr("rooms") + ",";
        }
    })
    return s.substring(0, s.length - 1);
}

function DelInfo(id) {
    $.get("/Admin/Ajax/SysPara.ashx?r=" + Math.random(), "type=delinfo&id=" + id, function (dele) {
        time1 = setInterval("Info()", "1000");
    }, "text");
}

function Updatestate(thisli, statid) {
    thisli.attr("state", statid);
    var clas = "";
    switch (statid) {
        case "2":
            clas = "bgorange";
            //thisli.find(".icospan").text("");
            thisli.find(".jzfimg").text("");
            var id = thisli.attr("id");
            $.get("/Admin/Ajax/SysPara.ashx?r=" + Math.random(), "type=getoccid&id=" + id, function (obj) {
                thisli.attr("id", obj);
            }, "text");
            break;
        case "3":
            var occid = thisli.attr("id");
            clas = "bggray_q";
            thisli.find(".shengyu").text("");
            thisli.find(".yue1").text("");
            $.get("/Admin/Ajax/SysPara.ashx?r=" + Math.random(), "type=getroomid&id=" + id, function (obj) {
                thisli.attr("id", obj);
            }, "text");
            break;

    }
    thisli.attr("class", clas);
}

function YUE(nowli1) {
    var roomNum = nowli1.attr("rooms");
    $.ajax({
        type: 'get',
        cache: false,
        async: true,
        url: "/Admin/Ajax/SysPara.ashx?js2=" + Math.random(),
        data: "type=Jf&roomNum=" + roomNum,
        success: function (obj) {
            SetValue(nowli1, obj);
        },
        dataType: 'text'
    });


    var roomNum = nowli1.attr("rooms");
    //            $.get("/Admin/Ajax/SysPara.ashx?js2=" + Math.random(), "type=Jf&roomNum=" + roomNum, function (obj) {
    //                SetValue(nowli1, obj);
    //            }, "text");
    // ShowGreen();
}



function Adds(obj, ids, types) {
    var titles = "";
    if (types == 0) {
        titles = "入住信息"
    } else {
        titles = "修改入住信息"
    }

    var url = "PeopleInfoAddsCs.aspx?id=" + ids + "&type=" + types;
    showMyWindow(titles, url, "1000", "630", true, true, true, update);
}
function CostAdds(obj, ids) {
    showMyWindow("费用入账","CostMoney.aspx?id=" + ids, "1000", "250", true, true, true);
}
function houseAdds(obj) {
    showMyWindow("维修原因", "SincetheAdds.aspx?", "1000", "350", true, true, true);
}
function LiveDayAdds(obj, ids) {
    showMyWindow("续住", "ContinuedLive.aspx?id=" + ids, "1000", "350", true, true, true);
}
function GoodsAdds(obj, ids) {
    showMyWindow("商品入帐", "GoodsPrice.aspx?id=" + ids, "1000", "550", true, true, true);
}
function replaceAdds(obj, ids) {
    showMyWindow("换房", "ChangeRoom.aspx?id=" + ids, "1000", "350", true, true, true);
}
function priceAdds(obj, ids) {
    showMyWindow("房价调整", "AdjustPrice.aspx?id=" + ids, "1000", "350", true, true, true);
}
function GustMoneyAdds(obj, ids) {
    showMyWindow("结账", "GoodsAcountsMoney.aspx?id=" + ids, "1000", "350", true, true, true);
}
function update() {
    window.location.reload();
}


//撤销入住判断方法
function CheXiao(id) {
    $.get("/Admin/Ajax/SysPara.ashx?r=" + Math.random(), "type=chexiao&id=" + id, function (obj) {
        if (obj == "OK") {
            document.getElementById("txt_ids").value = id;
            document.getElementById("btncx").click();
        }
        else {
            alert("不满足撤销入账的条件!");
        }
    }, "text");
}
function cds(type, rooms) {
    //$("#hidNumber").val(type);
    //$("#hidRoom").val(rooms);
    //$("#Button1").click();
    $.get("/Admin/Ajax/Books.ashx", "type=UpState&hidNumber=" + type + "&hidRoom=" + rooms, function (jg) {

    }, "text");

}

function CHo() {
    $(".divFv").hover(function () { $(".divFv").addClass("yinying"); }, function () { $(".divFv").removeClass("yinying"); });
}
var TimeFn = null;
function MyClick() {
    $(".close").click(function () {
        $(".divFv").css("display", "none");
    })
    $(".main .hidli li").dblclick(function () {
        clearTimeout(TimeFn);
        if ($(this).attr("class").trim() == "bgorange" || $(this).attr("class").trim() == "zhang_zf") {
            ShowTabs('结账', $(this).attr("id"));
        }
        if ($(this).attr("class").trim() == "bggray_q") {
            cds(2, $(this).attr("id"));
        }
    })
    var nowli = null;
    $(".main .hidli li").click(function (e) {
        clearTimeout(TimeFn);
        nowli = $(this);
        TimeFn = setTimeout(function () {
            if (nowli.attr("class").trim() == "bgorange" || nowli.attr("class").trim()=="zhang_zf") {
                $(".divFv").css("display", "block");
                var w = $("#DivContent").width();
                var y = $("#DivContent").height();
                var ws = $(".divFv").width();
                var ys = $(".divFv").height();
                if (e.pageX >= parseInt(w) - parseInt(ws)) {
                    e.pageX = e.pageX - ws;
                }
                if (e.pageY >= parseInt($(".ycan").height()) - parseInt(ys)) {
                    e.pageY = e.pageY - ys;
                    if (e.pageY < 0) {
                        e.pageY = 0;
                    }
                }
                $(".divFv").css("top", e.pageY);
                $(".divFv").css("left", e.pageX);
                CHo();
                //var li = $(this);
                var value = nowli.attr("id");
                var rom = nowli.attr("rooms");
                var sta = nowli.attr("state");
                $.ajax({

                    type: "post",
                    url: "RoomInfo.ashx?type=tangjian&id=" + value + "&state=" + sta + "&room=" + rom,
                    cache: 'false',
                    async: false,
                    success: function (msg) {
                        $(".spanSpn").css("display", "none");
                        $(".spanSpn1").css("display", "none");
                        $(".hidXie").css("display", "none");
                        $(".hidmember").css("display", "none");
                        var a = msg.split(',');
                        $("#labName").text(a[0]);
                        $(".roomnums").text(a[1]);
                        $(".sex").text(a[2]);
                        $(".types").text(a[3]);
                        $("#staytime").text(a[4]);
                        $("#endtime").text(a[5]);
                        $("#cardid").text(a[6]);
                        $("#cardidNumber").text(a[7]);
                        $("#txt_remaker").text(a[10]);
                        $("#txt_address").text(a[9]);
                        $(".tjs").text(a[11]);
                        $(".lfkf").text(a[12]);
                        $(".xiaof").text(a[13]);
                        $(".shouk").text(a[14]);
                        $("#spansk").text(a[16]);
                        $(".xyysk").text(a[17]);
                        if (a[17] != "0") {
                            a[15] = parseFloat(a[17]) + parseFloat(a[14]) - parseFloat(a[13]);
                        }
                        $(".yue").text(a[15]);
                        if (parseFloat(a[15]) < 0) {
                            $("#divye").css("background", "red")
                        }
                        else {
                            $("#divye").css("background", "purple")
                        }
                        $("#YuJia").text(a[19]);
                        $("#zhj").text(a[18]);
                        if (a[20] != "") {
                            $(".hidmember").css("display", "inline-block");
                            $(".spanSpn1").css("display", "inline-block");
                            $(".spanSpn").css("display", "inline-block");
                            $(".spanSpn").html(a[20]);
                            $.get("/admin/ajax/Member.ashx", "type=getinfo&memid=" + a[20], function (obj) {
                                $(".spanSpn1").html(obj);
                            }, "text");
                        }
                        else {

                        }

                        if (a[21] != "") {
                            $(".hidXie").css("display", "inline-block");
                            $(".spanXie").text(a[21]);
                        }
                        else {

                        }
                    }

                })
            }

        }, 200);

    });
    //,function(){  $(".divFv").css("display", "none"); }
    //右击事件
    $(document).bind("contextmenu", function (e) {
        return false;
    });

    $('.content li').mousedown(function (e) {
        $("#menu .menu-item").unbind("hover");
        $(".divFv").css("display", "none");
        if (3 == e.which) {
            e.preventDefault();
            e.stopPropagation();
            var li = $(this);
            var value = li.attr("id");
            var rom = li.attr("rooms");
            var sta = li.attr("state");
            $.ajax({
                type: "post",
                url: "ajax.aspx?id=" + value + "&state=" + sta + "&room=" + rom,
                cache: 'false',
                async: false,
                success: function (msg) {

                    $("#menu").html("<div class=\"menu-line\" style=\"height: 122px;\"></div>" + msg);
                    $('#menu').menu('show', {
                        left: e.pageX,
                        top: e.pageY
                    });
                    $("#menu").css("overflow", "initial");
                    $("#menu").find(".menu-item").css("overflow", "inherit");
                    funHover();
                    $(".menu-shadow").css("display", "none");
                    $(".deif").find(".menu").css("display", "none");
                                        var w = $("#DivContent").width();
                                        var y = $("#DivContent").height();
                                        var ws = $("#menu").width();
                                        var ys = $("#menu").height();
                                        if (e.pageX >= parseInt(w) - parseInt(ws)) {
                                            e.pageX = e.pageX - ws;

                                        }
                                        if (e.pageY >= parseInt($(".ycan").height()) - parseInt(ys)) {
                                            e.pageY = e.pageY - ys - 28;
                                        }
                                        $("#menu").css("top", e.pageY);
                                        $("#menu").css("left", e.pageX);
                }
            })
            $(".deif").hover(function () {
                var w = $("#menu").width();
                                if ($("#menu").offset().left + w * 2 >= $("#DivContent").width()) {
                                    $(".deif").find(".menu").css("left", "0px");
                                    $(".deif").find(".menu").css("margin-left", w * (-1) + "px");
                                }
                var count = $(".deif").find(".menu").parent().siblings().length + 1;
                //alert(count);
                $(".deif").find(".menu").css("left", "110px");
                $(".deif").find(".menu").css("top", "0px");
                $(".deif").find(".menu").css("margin-top", "-1px");
                $(".deif").find(".menu").css("display", "block");

            }, function () { $(".deif").find(".menu").css("display", "none"); })

            $('.menu li').click(function () {
                if ($(".menu").css("display") == "none") {
                    $(".menu").css("display", "block");

                }
                else {
                    $(".menu").css("display", "none");
                }


            })
            $("html").click(function () {
                $(".menu").css("display", "none");


            })



        }
    })
}
function funHover() {
    $("#menu .menu-item").hover(function () {
        $(this).addClass("menu-active");

    }, function () {
        $(this).removeClass("menu-active");
    })
}
function btnserch(obj, ids) {
    RemoClass();
    if (ids == 999) {
        //$('iframe', window.parent.document).eq(1).attr("src","/admin/Toroom/ToRoom.aspx");

        $(".ulright li").removeClass("bor");

        $("#DivContent .hidli li").each(function () {
            $(this).css("display", "block");
        })
    }
    else {
        var c = $(obj).find("span").eq(0).attr("class");
        var clist = c.split(' ');
        var cla = clist[0];
        if ($(obj).attr("i") == "true") {
            $("#DivContent li").css("display", "block");
            $(obj).attr("i", "false");
        }
        else {
            $("#ulss li").attr("i", "false");
            $(obj).attr("i", "true");
            $("#DivContent .hidli li").each(function () {
                $(this).css("display", "none");
                if ($(this).attr("class").indexOf(cla) >= 0) {
                    $(this).css("display", "block");
                }
            })
        }
    }
    Co();
    NumStatuNum();
}
function Co() {
    $("#ulss li").each(function () {
        if ($(this).attr("i") == "true") {
            $(this).css("background", $(this).find("span").eq(0).css("background"));
        }
        else {
            $(this).css("background", "");
        }
    })
}
$(function () {
    $(".main li").hover(function () {
    }, function () {
    })
    MyClick();

    $(".ycan").height(document.documentElement.clientHeight - 60);
    $(".ycan").css("overflow-x", "hidden");
    NumStatuNum()

    /*筛选点击*/
    $(".libgicon02").click(function () {//将走房
        $("#ulss li").attr("i", "false");
        if ($(this).attr("class").indexOf('bor') > 0) {
            $(this).removeClass("bor");
            $("#DivContent .hidli li").css("display", "block");
        }
        else {
            RemoClass();
            $(this).addClass("bor");
            $("#DivContent .hidli li").each(function () {
                $(this).css("display", "none");
                if ($(this).find(".numday").text() == " " && $(this).find(".numday").length > 0) {
                    $(this).css("display", "block");
                }
            })
        }
        NumStatuNum();
        Co();
    })

    $(".libgicon11").click(function () {//将走房
        $("#ulss li").attr("i", "false");
        if ($(this).attr("class").indexOf('bor') > 0) {
            $(this).removeClass("bor");
            $("#DivContent .hidli li").css("display", "block");
        }
        else {
            RemoClass();
            $(this).addClass("bor");
            $("#DivContent .hidli li").each(function () {
                $(this).css("display", "block");
                if ($(this).find(".xuzhu").text() == "") {
                    $(this).css("display", "none");
                }
            })
        }
        NumStatuNum();
        Co();
    })

    $(".libgicon08").click(function () {//欠费
        $("#ulss li").attr("i", "false");
        if ($(this).attr("class").indexOf('bor') > 0) {
            $(this).removeClass("bor");
            $("#DivContent .hidli li").css("display", "block");
        }
        else {
            RemoClass();
            $(this).addClass("bor");
            $("#DivContent .hidli li").each(function () {
                $(this).css("display", "block");
                if ($(this).find(".qianfei").html() == "") {
                    $(this).css("display", "none");
                }
            })
        }
        NumStatuNum();
        Co();
    })

    $(".libgicon10").click(function () {//锁房
        $("#ulss li").attr("i", "false");
        if ($(this).attr("class").indexOf('bor') > 0) {
            $(this).removeClass("bor");
            $("#DivContent .hidli li").css("display", "block");
        }
        else {
            RemoClass();
            $(this).addClass("bor");
            $("#DivContent .hidli li").each(function () {
                $(this).css("display", "block");
                if ($(this).find(".suofang").length < 1) {
                    $(this).css("display", "none");
                }
            })
        }
        NumStatuNum();
        Co();
    })

    $(".libgicon09").click(function () {//月租房
        $("#ulss li").attr("i", "false");
        if ($(this).attr("class").indexOf('bor') > 0) {
            $(this).removeClass("bor");
            $("#DivContent .hidli li").css("display", "block");
        }
        else {
            RemoClass();
            $(this).addClass("bor");
            $("#DivContent .hidli li").each(function () {
                $(this).css("display", "block");
                if ($(this).find(".yuezhu").length < 1) {
                    $(this).css("display", "none");
                }
            })
        }
        NumStatuNum();
        Co();
    })

    $(".libgicon03").click(function () {//凌晨房
        $("#ulss li").attr("i", "false");
        if ($(this).attr("class").indexOf('bor') > 0) {
            $(this).removeClass("bor");
            $("#DivContent .hidli li").css("display", "block");
        }
        else {
            RemoClass();
            $(this).addClass("bor");
            $("#DivContent .hidli li").each(function () {
                $(this).css("display", "block");
                if ($(this).find(".lccio").length < 1) {
                    $(this).css("display", "none");
                }
            })
        }
        NumStatuNum();
        Co();
    })

    $(".libgicon04").click(function () {//钟点房
        $("#ulss li").attr("i", "false");
        if ($(this).attr("class").indexOf('bor') > 0) {
            $(this).removeClass("bor");
            $("#DivContent .hidli li").css("display", "block");
        }
        else {
            RemoClass();
            $(this).addClass("bor");
            $("#DivContent .hidli li").each(function () {
                $(this).css("display", "block");
                if ($(this).find(".zdf").length < 1) {
                    $(this).css("display", "none");
                }
            })
        }
        NumStatuNum();
        Co();
    })

    //libgicon05
    $(".libgicon05").click(function () {//联房
        $("#ulss li").attr("i", "false");
        if ($(this).attr("class").indexOf('bor') > 0) {
            $(this).removeClass("bor");
            $("#DivContent .hidli li").css("display", "block");
        }
        else {
            RemoClass();
            $(this).addClass("bor");
            $("#DivContent .hidli li").each(function () {
                $(this).css("display", "block");
                if ($(this).find(".lfico").html() == "") {
                    $(this).css("display", "none");
                }
            })
        }
        NumStatuNum();
        Co();
    })

    //
    $(".libgicon12").click(function () {//催帐
        $("#ulss li").attr("i", "false");
        if ($(this).attr("class").indexOf('bor') > 0) {
            $(this).removeClass("bor");
            $("#DivContent .hidli li").css("display", "block");
        }
        else {
            RemoClass();
            $(this).addClass("bor");
            $("#DivContent .hidli li").each(function () {
                $(this).css("display", "block");
                if ($(this).find(".czimg").html() == "") {
                    $(this).css("display", "none");
                }
            })
        }
        NumStatuNum();
        Co();
    })

    //
    $(".libgicon13").click(function () {//免费
        $("#ulss li").attr("i", "false");
        if ($(this).attr("class").indexOf('bor') > 0) {
            $(this).removeClass("bor");
            $("#DivContent .hidli li").css("display", "block");
        }
        else {
            RemoClass();
            $(this).addClass("bor");
            $("#DivContent .hidli li").each(function () {
                $(this).css("display", "block");
                if ($(this).find(".free").length < 1) {
                    $(this).css("display", "none");
                }
            })
        }
        NumStatuNum();
        Co();
    })
})

function RemoClass() {
    $(".ulright li").removeClass("bor");
}

//重新计算数量
function NumStatuNum() {
    var arrayObj = new Array(); //创建一个数组
    var jdf = 0; //将到房  数量
    var zzf = 0; //在住房  数量
    var gjf = 0; //干净房  数量
    var zf = 0; //脏房  数量
    var wxf = 0; //维修房  数量
    var zhf = 0; //脏住房  数量
    var zyf = 0; //自用房  数量
    var jzf = 0; //将走房  数量
    var xzf = 0; //续住房  数量
    var qff = 0; //欠费房  数量
    var sf = 0; //锁房  数量
    var yzf = 0; //月租房  数量
    var lcf = 0; //凌晨房  数量
    var zdf = 0; //钟点房  数量
    var lf = 0; //联防房  数量
    var czf = 0; //催帐房  数量
    var mff = 0; //免费房  数量
    $("#DivContent .hidli li").each(function () {
        if ($(this).css("display") != "none") {
            if ($(this).attr("class").indexOf("yuding") >= 0) {
                jdf++;
            }
            if ($(this).attr("class").indexOf("bgorange") >= 0) {
                zzf++;
            }
            if ($(this).attr("class").indexOf("bgblue") >= 0) {
                gjf++;
            }
            if ($(this).attr("class").indexOf("bggray_q") >= 0) {
                zf++;
            }
            if ($(this).attr("class").indexOf("bggray_s") >= 0) {
                wxf++;
            }
            if ($(this).attr("class").indexOf("zhang_zf") >= 0) {
                zhf++;
            }
            if ($(this).attr("class").indexOf("pink_zyf") >= 0) {
                zyf++;
            }
            if ($(this).find(".numday").text() == " " && $(this).find(".numday").length > 0) {
                jzf++;
            }
            if ($(this).find(".xuzhu").text() != "") {
                xzf++;
            }
            if ($(this).find(".qianfei").html() != "") {
                qff++;
            }
            if ($(this).find(".suofang").length == 1) {
                sf++;
            }
            if ($(this).find(".yuezhu").length == 1) {
                yzf++;
            }
            if ($(this).find(".lccio").length == 1) {

                lcf++;
            }
            if ($(this).find(".zdf").length == 1) {
                zdf++;
            }
            var t = $(this).find(".lfico").html();
            if (t.trim() != "") {
                if (arrayFindString(arrayObj, t) >= 0) {

                }
                else {
                    arrayObj.push(t);
                    lf++;
                }
            }

            if ($(this).find(".czimg").html() != "") {
                czf++;
            }
            if ($(this).find(".free").length == 1) {
                mff++;
            }
        }
    })
    $("#ulss").find(".yuding").next().text(jdf); //将到房
    $("#ulss").find(".bgorange").next().text(zzf); //在住房
    $("#ulss").find(".bgblue").next().text(gjf); //干净房
    $("#ulss").find(".bggray_q").next().text(zf); //长房
    $("#ulss").find(".bggray_s").next().text(wxf); //维修房
    $("#ulss").find(".zhang_zf").next().text(zhf); //长住房
    $("#ulss").find(".pink_zyf").next().text(zyf); //自用房间


    $("#spanjiangz").text(jzf); //将走房
    $("#spanxuzhu").text(xzf); //续住
    $("#spanqianf").text(qff); //欠费房
    $("#spansuofang").text(sf); //锁房
    $("#spanyzf").text(yzf); //月租房
    $("#spanlingc").text(lcf); //凌晨房
    $("#spanzdf").text(zdf); //钟点房

    $("#spanlf").text(lf); //联房
    $("#span1").text(czf); //催帐
    $("#span2").text(mff); //免费
}

/**
* 查找数组包含的字符串
*/
function arrayFindString(arr, string) {
    var str = arr.join("");
    return str.indexOf(string);
}

function ShowTabt(title, ids, types, obj) {
    var txt = $(obj).text();
    if (txt.indexOf('锁定') > 0) {
        alert("已经锁定");
    }
    else {
        clos();
        var url = "/admin/Toroom/PeopleInfoAddsCs1.aspx?id=" + ids + "&type=" + types;
        AddTabs(title, url);
    }
}

//拆分房间
function ChaFeng(ids) {
    $.get("/admin/ajax/Books.ashx", "type=chafeng&id=" + ids, function (obj) {
        if (obj == "err") {
            alert("主房不能拆分！请折分其从房！");
        }
    }, "text");
}

//合并房间
function AddRoom(title, ids) {
    showMyWindow("合并房间", "/admin/Toroom/AddRoom.aspx?id=" + ids, "1000", "350", true, true, true);
}

//加开房间
function ShowAddRoom(title, ids) {
    var types = "jiakai";
    var url = "/admin/Toroom/PeopleInfoAddsCs1.aspx?id=" + ids + "&type=" + types;
    AddTabs(title, url);
}

function ShowTab(title, ids, types) {
    if (types == 0) {
        $.get("/admin/ajax/IsDel.ashx", "type=isrz&id=" + ids, function (obj) {
            if (obj == "ok") {
                alert("脏房不允许入住!");
            }
            else if (obj == "err") {
                clos();
                var url = "/admin/Toroom/PeopleInfoAddsCs1.aspx?id=" + ids + "&type=" + types;
                AddTabs(title, url);
            }
        }, "text");
    }
    else {

        clos();
        var url = "/admin/Toroom/PeopleInfoAddsCs1.aspx?id=" + ids + "&type=" + types;
        AddTabs(title, url);
    }
}
function ShowTabs(title, ids) {
    // 关闭当前
    clo("结账");
    var url = "/admin/Toroom/GoodsAcountsMoney.aspx?id=" + ids;
    AddTabs(title, url);
}
function clos() {
    // 关闭当前
    clo("在住房信息");
}
function ShowTabs1(title, ids) {
    showMyWindow("续住", "ContinuedLive.aspx?id=" + ids, "1000", "350", true, true, true);
}

function ShowweixiuTabs(title, ids, type) {

    var url = "/admin/Toroom/Sincethehousing.aspx?id=" + ids + "&types=" + type;
    AddTabs(title, url);
}

function clo() {

    var heights = document.body.scrollHeight;
    var width = document.body.offsetWidth;
    var divGv = document.getElementById("DivContent");
    //divGv.style.height = 800 + "px";
}