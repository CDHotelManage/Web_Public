<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToRooms2.aspx.cs" Inherits="CdHotelManage.Web.Admin.Toroom.ToRooms2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<!-- InstanceBegin template="/Templates/index.dwt" codeOutsideHTMLIsLocked="false" -->
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>酒店管理系统</title>
    <script src="../../js/DivWH.js" type="text/javascript"></script>
    <link href="../../style/css.css" type="text/css" rel="Stylesheet" />
    <link href="../../style/Opendiv.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jqueryes.js" type="text/javascript"></script>
    <script src="../../js/jquery.contextmenu.r2.js" type="text/javascript"></script>
    <script src="../../js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <link href="../../style/newhouseview.css" rel="stylesheet" type="text/css" />
    <script src="../js/base.js" type="text/javascript"></script>
    <style type="text/css">
        .SelectedRow{background: yellow;}
        .contextMenu{display: none;}
        .yue1{position: absolute;right: 0;top: 0;}
        .stime{position: absolute;right: 0;bottom: 0;}
        .main li{position: relative;}
    </style>
    <script type="text/javascript">
        function ShowTabs1(title, ids) {

            var url = "/admin/Toroom/ContinuedLive.aspx?id=" + ids;
            var jq = top.jQuery;
            if (jq('#tabs').tabs('exists', title)) {
                jq('#tabs').tabs('select', title);
            }
            else {
                jq('#tabs').tabs('add', {
                    title: title,
                    content: createFrame(url),
                    closable: true
                });
            }
        }

        $(function () {
            var time1 = setInterval("Info()", "1000");

        })
        function JF() {
            $.get("/Admin/Ajax/SysPara.ashx?r=" + Math.random(), "type=Jf", function (obj) {

            }, "text");
        }

        function Info() {
            $.get("/Admin/Ajax/SysPara.ashx?r=" + Math.random(), "type=infos", function (obj) {
                if (obj.statu == "ok") {
                    //alert(obj.data.number);
                    var numbers = obj.data.number;
                    var id = obj.data.id;
                    $.get("/Admin/Ajax/SysPara.ashx?r=" + Math.random(), "type=Jf&roomNum=" + numbers, function (objs) {
                        $("#DivContent li").each(function () {
                            if ($(this).attr("rooms") == numbers) {
                                $(this).find(".yue1").text(objs);
                            }
                        })
                        $.get("/Admin/Ajax/SysPara.ashx?r=" + Math.random(), "type=delinfo&id=" + id, function (dele) {


                        }, "text");

                    }, "text");
                }
            }, "json");
        }
        // alert(objs);

        function YUE() {
            $("#DivContent li").each(function () {
                if ($(this).attr("state") == 2) {
                    var nowli = $(this);
                    var roomNum = $(this).attr("rooms");
                    //                    $.get("/Admin/Toroom/RoomInfo.ashx?r=" + Math.random(), "type=yue&roomNum=" + roomNum, function (obj1) {

                    //                        nowli.find(".yue").text(obj1);
                    //                    }, "text");
                    $.get("/Admin/Ajax/SysPara.ashx?r=" + Math.random(), "type=Jf&roomNum=" + roomNum, function (obj) {
                        if (!isNaN(obj)) {
                            nowli.find(".yue1").text(obj);
                        } else {
                            var list = obj.split(",");
                            nowli.find(".stime").text(list[0]);
                            nowli.find(".stime").css("color", '#' + ('00000' + (Math.random() * 0x1000000 << 0).toString(16)).slice(-6));
                            nowli.find(".yue1").text(list[1]);
                        }

                    }, "text");
                }
            })

        }

        function btnserch(obj, ids) {
            var btn = document.getElementById("btnsercher");
            document.getElementById("txt_ids").value = ids;
            btn.click();


        }
        function Adds(obj, ids, types) {
            var titles = "";
            if (types == 0) {
                titles = "入住信息"
            } else {
                titles = "修改入住信息"
            }

            var url = "PeopleInfoAddsCs.aspx?id=" + ids + "&type=" + types;
            showMyWindow(titles, url, 1000, 620, true, true, true, update);
        }
        function CostAdds(obj, ids) {
            var url = "CostMoney.aspx?id=" + ids;
            showMyWindow("费用入账", url, 1000, 350, true, true, true, update);
        }
        function houseAdds(obj) {
            var url = "SincetheAdds.aspx?";
            showMyWindow("维修原因", url, 1000, 350, true, true, true);
        }
        function LiveDayAdds(obj, ids) {
            var url = "ContinuedLive.aspx?id=" + ids;
            showMyWindow("续住", url, 1000, 350, true, true, true, update);
        }
        function GoodsAdds(obj, ids) {
            var url = "GoodsPrice.aspx?id=" + ids;
            showMyWindow("商品入账", url, 1000, 350, true, true, true, update);
        }
        function replaceAdds(obj, ids) {
            var url = "ChangeRoom.aspx?id=" + ids;
            showMyWindow("换房", url, 1000, 350, true, true, true, update);
        }
        function priceAdds(obj, ids) {
            var url = "AdjustPrice.aspx?id=" + ids;
            showMyWindow("房价调整", url, 1000, 350, true, true, true, update);
        }
        function GustMoneyAdds(obj, ids) {
            var url = "GoodsAcountsMoney.aspx?id=" + ids;
            showMyWindow("结账", url, 1000, 350, true, true, true, update);
        }
        function update() {
            window.location.reload();
        }
        $.ajaxSetup({
            async: false
        });
        //撤销入住判断方法
        function CheXiao(id) {
            $.get("/Admin/Ajax/SysPara.ashx?r=" + Math.random(), "type=chexiao&id=" + id, function (obj) {
                if (obj == "OK") {
                    document.getElementById("txt_ids").value = id;
                    document.getElementById("btncx").click();
                }
                else {
                    alert("不满足撤销入账的条件");
                }
            }, "text");
        }
        function cds(type, rooms) {
            $("#hidNumber").val(type);
            $("#hidRoom").val(rooms);
            $("#Button1").click();

        }
        $(function () {
            //右击事件
            $(document).bind("contextmenu", function (e) {
                return false;
            });
            $('.maincontent li').mousedown(function (e) {
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

                            if ($(".menu").css("display") == "none") {
                                $(".menu").css("display", "block");

                            }
                            $(".menu").html(msg);
                            $(".menu").css("top", e.pageY);
                            $(".menu").css("left", e.pageX);

                        }
                    })
                    $(".deif").hover(function () {
                        var count = $(".men").parent().siblings().length + 1;
                        //alert(count);
                        $(".men").css("top", count * 20);
                        $(".men").css("display", "block");

                    }, function () { $(".men").css("display", "none"); })

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
        })
        function ShowTab(title, ids, types) {

            var url = "/admin/Toroom/PeopleInfoAddsCs.aspx?id=" + ids + "&type=" + types;
            var jq = top.jQuery;
            if (jq('#tabs').tabs('exists', title)) {
                jq('#tabs').tabs('select', title);
            }
            else {
                jq('#tabs').tabs('add', {
                    title: title,
                    content: createFrame(url),
                    closable: true
                });
            }
        }
        function ShowTabs(title, ids) {

            var url = "/admin/Toroom/GoodsAcountsMoney.aspx?id=" + ids;
            var jq = top.jQuery;
            if (jq('#tabs').tabs('exists', title)) {
                jq('#tabs').tabs('select', title);
            }
            else {
                jq('#tabs').tabs('add', {
                    title: title,
                    content: createFrame(url),
                    closable: true
                });
            }
        }
        function ShowweixiuTabs(title, ids, type) {

            var url = "/admin/Toroom/Sincethehousing.aspx?id=" + ids + "&types=" + type;
            var jq = top.jQuery;
            if (jq('#tabs').tabs('exists', title)) {
                jq('#tabs').tabs('select', title);
            }
            else {
                jq('#tabs').tabs('add', {
                    title: title,
                    content: createFrame(url),
                    closable: true
                });
            }
        }
    </script>
    <style type="text/css">
        .menu
        {
            width: 100px;
            position: absolute;
            z-index: 99999;
        }
        .menu li
        {
            width: 100px;
            height: 25px;
            line-height: 25px;
            text-align: center;
            background: #ccc;
            color: #000;
            list-style-type: none;
            border: solid 1px #aaa;
            cursor: pointer;
        }
        .menu li:hover
        {
            background: #f00;
            color: #fff;
        }
        .deif
        {
            position: absolute;
        }
        .men
        {
            width: 100px;
            position: absolute;
            z-index: 999;
            left: 92px;
            display: none;
        }
        .show
        {
            display: block;
        }
        .hide
        {
            display: none;
        }
        .acd
        {
            background-color: Purple;
        }
        .zhang_zf
        {
           background:#336699;
        }
        .pink_zyf
        {
            background: #9932ff;
        }
        #DivContent .leftXiaYou li, .leftXiaZuo li
        {
            width: 100%;
            margin-bottom: 2px;
            height: 40.5px;
        }
        .bcolor23
        {
            border: 2px solid #abce1b;
        }
        /*绿边*/
        #DivContent, .midUL02ll li, #ul6 li, #ul9 li
        {
            border: 2px solid #9e9c5f;
        }
        /*紫边*/
        #DivContent .midUL02rr li, #ul12 li, .midUL02cc li
        {
            border: 2px solid #7b6fae;
        }
        #DivContent #ul14 li, #ul15 li
        {
            border: 2px solid #cd0042;
        }
        #DivContent .mid1part li
        {
            border: 2px solid #e57a00;
        }
        
        /*红边*/
        #DivContent .leftmid li
        {
            width: 100%;
            margin-bottom: 2px;
            height: 44px;
        }
        #DivContent #ul101 li
        {
            height: 45px;
        }
       #DivContent #ul5 li{ border: 2px solid #4486b7;}
    </style>
</head>
<body class="bgIndex">
    <form id="form1" runat="server">
    <div class="menu" id="menu">
    </div>
    <div class="f_l_left">
        <!-- InstanceBeginEditable name="EditRegion1" -->
        新的房态图<!-- InstanceEndEditable -->
        <ul id="ulss" class=" zhuangtais">
            <asp:Repeater ID="Repeaterft" runat="server">
                <ItemTemplate>
                    <li><span class="<%# GetClassDiv(Convert.ToInt32( Eval("room_state_id"))) %>">
                        <%# Eval("room_state_name")%></span><span class="ztspan02"><%# Eval("remark")%></span><span></span>间</li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
    <!-- InstanceBeginEditable name="EditRegion2" -->
    <div id="DivContent" runat="server" class="maincontent">
        <div class="circle001">
            <img height= "180px;" src="../images/bgcircle.png" /></div>
        <div class="mainleft">
            <div class="left1part">
                <div class="leftStair zuofu">
                    楼梯</div>
                <div>
                    <ul id="ul101" class="bgblue left01roomb youfu" runat="server">
                        <li>F-101</li>
                    </ul>
                </div>
            </div>
            <div class="left2part">
                <div class="zuofu djhuoti">
                    <div class="ti1">
                        强电间</div>
                    <div class="ti1">
                        弱电间</div>
                    <div class="ti2">
                        电梯</div>
                    <div class="ti2">
                        电梯</div>
                    <div class="ti2">
                        货梯</div>
                </div>
                <ul class="zuofu jiedai">
                    <li class="jdli">办公区域</li>
                    <li class="jdli">接待大厅</li>
                    <li class="jdli2">接待前台</li>
                    <li class="circle"><span></span><span></span></li>
                </ul>
                <ul id="ul1" runat="server" class="leftmid">
                </ul>
            </div>
            <!--left2part结束缚-->
            <div class="leftXia zuofu">
                <ul id="ulLeft" runat="server" class="leftXiaZuo">
                    <li class="bgblue left01roomb">物业办公室</li>
                    <li class="bgblue left01roomb ">102</li>
                    <li class="bgblue left01roomb ">101</li>
                </ul>
                <div class="leftStairb">
                    楼梯</div>
            </div>
            <ul id="ul2" runat="server" class="youfu leftXiaYou">
            </ul>
        </div>
        <!--mainleft第一部分:左结束-->
        <!--第2部分中间上面开始-->
        <div class="mainmid">
            <ul id="ul3" runat="server" class="mm1ul">
            </ul>
            <!--中部最上面-->
            <div class="midul">
                <ul id="ul4" runat="server" class="midUL01 " style="margin-left: 0; margin-right: 2px">
                </ul>
                <!--中左-->
                <ul id="ul6" runat="server" class="midUL02">
                </ul>
                <!--中部中间-->
                <ul id="ul7" runat="server" class="midUL02ll">
                </ul>
                <ul id="ul8" runat="server" class="midUL02rr">
                </ul>
                <!--中右-->
                <ul id="ul12" runat="server" class="midUL02">
                </ul>
                <!--中部中间-->
                <div style="float: left; width: 8px; background: yellow;">
                </div>
                <ul id="ul15" runat="server" class="midUL01 ">
                </ul>
                <!--中左-->
            </div>
            <!--中部中下三排ul开始-->
            <div class="midul">
                <ul id="ul5" runat="server" class="downUL01 " style="margin-left: 0; margin-right: 2px;">
                </ul>
                <!--中左-->
                <ul id="ul9" runat="server" class="midUL02">
                </ul>
                <!--中部中间-->
                <ul id="ul10" runat="server" class="midUL02ll">
                </ul>
                <ul id="ul11" runat="server" class="midUL02rr">
                </ul>
                <ul id="ul13" runat="server" class="midUL02cc">
                </ul>
                <ul id="ul14" runat="server" class="downUL01 ">
                </ul>
                <!--中左-->
                <!--中部中间-->
                <!--中部下面-->
            </div>
            <ul id="ul16" runat="server" class="mid1part" style="margin-bottom: 0px;">
            </ul>
            <!--9room-->
            <!--中部最最下面-->
        </div>
        <!--第二部分中间部分-->
        <!--右边开始-->
        <div class="mainright">
            <div class="yoyoup">
                <div class="yoyoup1">
                    <ul id="ul17" runat="server" class="rr0">
                    </ul>
                    <!--右面最最上面-->
                    <ul id="ul18" runat="server" class="rr2ul " style="width: 100%">
                    </ul>
                    <!--右面最最上面-->
                    <ul id="ul19" runat="server" class="rr1ul">
                        <!-- <li class="bgblue left01roomc2">101</li>-->
                    </ul>
                    <!--右面最最上面-->
                </div>
                <!--yoyoup1-->
                <div class="yoyoup2">
                    <div class="leftStairc">
                        楼梯</div>
                    <ul id="ul28" runat="server" class="bgblue rr9li">
                        <li>F-28</li></ul>
                </div>
            </div>
            <!--yoyoup-->
            <div style="width: 100%; overflow: hidden; margin-bottom: 20px;">
                <ul id="ul20" runat="server" class="rr4ul">
                </ul>
                <ul id="ul21" runat="server" class="rr5ul">
                </ul>
                <!--右面最最上面-->
            </div>
            <div class="yoyodown">
                <div class="yoyodown1">
                    <ul id="ul22" runat="server" class="rr6ul " style="width: 100%">
                    </ul>
                    <!--右面最最上面-->
                    <ul id="ul23" runat="server" class="rr7ul">
                    </ul>
                    <!--右面最底8个room-->
                </div>
                <!--yoyodown1-->
                <div class="yoyodown2">
                    <%--<div class="bgblue rr10li">
                        E-25</div>--%>
                    <ul id="ul25" runat="server" class="bgblue rr10li">
                        <li>E-25</li>
                    </ul>
                    <div class="leftStaird">
                        楼梯</div>
                </div>
                <!--yoyodown2-->
            </div>
            <!--yoyodown-->
        </div>
        <!--右边部分mainright-->
        <input type="hidden" id="txt_ids" runat="server" />
        <input type="hidden" id="hidxq" runat="server" />
        <asp:Button ID="Button1" runat="server" Text="修改状态" Style="display: none;" OnClick="Button1_Click" />
        <asp:Button ID="btncx" runat="server" Text="撤销入单" OnClick="btncx_Click" Style="display: none;" />
        <asp:HiddenField ID="hidNumber" runat="server" />
        <asp:HiddenField ID="hidRoom" runat="server" />
    </div>
    <!--主体部分maincontent-->
    <!-- InstanceEndEditable -->
    </form>
</body>
<!-- InstanceEnd -->
</html>
