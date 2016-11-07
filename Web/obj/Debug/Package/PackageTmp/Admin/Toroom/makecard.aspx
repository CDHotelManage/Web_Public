<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="makecard.aspx.cs" Inherits="CdHotelManage.Web.Admin.Toroom.makecard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>制作房卡</title>
    <link href="../css/tch.css" rel="stylesheet" type="text/css" />
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <link href="../../style/Opendiv.css" rel="stylesheet" type="text/css" />
    <script src="../../js/DivWH.js" type="text/javascript"></script>
    <script src="../../js/AppendHtml.js" type="text/javascript"></script>
    <script src="../js/base.js" type="text/javascript"></script>
        <style type="text/css">
       body{ margin:0; padding:0;}
       li,ul{ margin:0; padding:0; list-style:none;}
      .type{  background: #EFEFEF;margin-top: 0px;}
      .vip_infor{  float: left;
  background: #fff;  width: 450px;}
  .vip_infor ul li input{ margin:0;}
  .vip_infor ul li .txt{ margin:0;}
    </style>
    <script type="text/javascript">
        function PrintRZ(order_id) {
            $("#div_Window", window.parent.document).css("display", "none");
            Open(order_id);
        }

        function Open(order_id) {
            var url = "/Admin/ShiftExc/OccupancySingle.aspx?orrderID=" + order_id + "&type=rz";
            AppendHTML("350px", "550px", url);
        }

        function Close() {
            ShowTabs('房态图');
        }
        function ShowTabs(title) {
            // 关闭当前

            var jq = top.jQuery;
            var url = "/admin/Toroom/ToRoom.aspx";

            AddTabs(title, url);
            if (jq('#tabs').tabs('exists', "房态图")) {
                var jq = top.jQuery;
                var a = "房态图";
                jq("#tabs").tabs("close", a);
                jq('#tabs').tabs('add', {
                    title: title,
                    content: createFrame(url),
                    closable: true
                });

            }
            clos();
        }
        function clos() {
            // 关闭当前
            clo("入住信息");
        }
        $.ajaxSetup({
            async: false
        });
        var ocx;
        window.onload = function () {
              ocx=document.getElementById("ocxs");
        }
        var carddata;
        ///读取卡数据 
        function ReadCard() {
            var str = ocx.ReadCard(1);
            var strlist = str.split(",");
            if (strlist[0] == "1") {
                alert("读取卡数据失败！");
                return false;
            }
            else {
                var datastr = "";
                carddata = strlist[1];
                for (var i = 0; i < 6; i++) {
                    datastr += carddata[i];
                }
                if (datastr != "551501") {
                    alert("发卡器感应区没有读到有效卡：" + datastr);
                    return false;
                }
                return true;
            }
        }

        ///获得酒店标识
        function GetHotelBs() {
            var tr;
            var i = 0;
            var datastr = "";
            var coid = "";
            tr = ReadCard();
            if (tr) {
                var datastr = "";
                for (var i = 0; i < 38; i++) {
                    datastr += carddata[i];
                }
                $.get("/admin/ajax/calculate.ashx", "type=GetHotelBs&datastr=" + datastr, function (obj) {
                    coid = obj.coid;
                    i = obj.i;
                    datastr = obj.datastr;
                }, "json");
//                if (datastr == "FFFFFFFF") {
//                    alert("此卡为空白卡，请换一张能够开门的卡！");
//                }
            }
            else {
                alert("没有读取到卡数据!");
            }
            return i;
        }

        ///制卡
        function MarkCard() {
           
            var tr; //是否有卡数据
            var dlsCoID = GetHotelBs(); //获得酒店标识
            var CardNo = 0; //同一分钟内发卡最多16张，每发一张卡加1
            var Dai = 0; //客人代，0--255，用于后卡覆盖前卡，一般情况下固定为0
            var LLock = $("#LLockHid").val(); //反锁标志，1能开反锁，0不能开反锁
            var pdoors = $("#pdoorsHid").val(); //公共门标志，1能开公共门，0不能开
            var BDate = $("#BDate").val(); //开卡时间
            var EDate = $("#EDate").val(); //结束时间
            var LockNo = $("#LockNo").val(); //锁号
            var cardbuf = ""; //最后输出
            tr = ReadCard();
            if (tr) {
                var str = ocx.GuestCard(1, dlsCoID, CardNo, Dai, LLock, pdoors, BDate, EDate, LockNo);  //0,卡数据
                var stlist = str.split(",");
                var st = stlist[0];
                if (st == 0) { //如果返回0，就成功
                    ocx.Buzzer(1, 50); //发卡器叫一声
                    alert("制卡成功！");
                    if (confirm('开房成功，是否打印入住单')) { PrintRZ($("#hidorder").val()); } else { ShowTabs('房态图'); }
                }
                else {
                    alert("制卡失败！");
                    if (confirm('开房成功，是否打印入住单')) { PrintRZ($("#hidorder").val()); } else { ShowTabs('房态图'); }
                }
            }
            else {
                alert("没有读取到卡数据！");
            }
        }

        //注销卡片
        function CardErase() {
            var tr; //是否有卡数据
            var dlsCoID = GetHotelBs(); //获得酒店标识
            tr = ReadCard();
            if (tr) {
                var str = ocx.CardErase(1, dlsCoID);
                var stlist = str.split(",");
                var st = stlist[0];
                if (st == 0) { //如果返回0，就成功
                    ocx.Buzzer(1, 50); //发卡器叫一声
                    alert("注销卡片成功！");
                }
                else {
                    alert("注销卡片失败！");
                }
            }
            else {
                alert("没有读取到卡数据！");
            }
        }

        function ShowInfo() {
            if (confirm('开房成功，是否打印入住单')) { PrintRZ($("#hidorder").val()); } else { ShowTabs('房态图'); }
        }
        //读取客人卡的锁号
        function GetGuestLockNoByCardDataStr() {
            var tr;
            var sou = "";
            var dlsCoID = GetHotelBs(); //获得酒店标识
            tr = ReadCard();
            if (tr) {
                var str = ocx.GetGuestLockNoByCardDataStr(dlsCoID, carddata);
                var stlist = str.split(",");
                var st = stlist[0];
                if (st == 0) { //成功
                    //alert("锁号为:" + stlist[1]);
                    sou = stlist[1];
                }
                else if (st == 1) {
                    alert("卡数据串无效");
                }
                else if (st == 1) {
                    alert("非本酒店卡");
                }
                else if (st == 1) {
                    alert("不是客人卡");
                }
            }
            else {
                alert("获得卡数据失败！");
            }
            return sou;
        }
        //读取卡信息。分别读取姓名 开房方式，开房时间，和离开时间
        function ReadCardInfo() {
            var sou = "212213";
            //读取锁号
            var sou = GetGuestLockNoByCardDataStr();
            if (sou == "") {
                alert("没有设置锁号！");
            }
            else {
                //通过锁号找到房间号，开房方式，房型，开房时间，离开时间
            $.get("/admin/ajax/calculate.ashx", "type=GetInfoBySuo&SuoMa=" + sou, function (obj) {
                if (obj.state = "0") {
                    $("#name").text(obj.occ_name);
                    $("#Span1").text(obj.fxxs);
                    $("#markTime").text(obj.occ_time);
                    $("#ydTime").text(obj.depar_time);
                }
                else {
                    $("#name").text("");
                    $("#Span1").text("");
                    $("#markTime").text("");
                    $("#ydTime").text(""); 
                }
            }, "json");
           }
        }
    </script>
</head>
<body>
     <OBJECT ID="ocxs" CLSID="{ACD0EB0D-284B-40D5-B49F-2107AF2F112A}" TYPE="application/x-itst-activex" width="0" height="0"></OBJECT>
    <form id="form1" runat="server">
    <input type="hidden" id="hidorder" runat="server"/>
    <input type="hidden" id="hidroom" runat="server"/>
    <input type="hidden" id="BDate" runat="server"/><!--开始时间-->
    <input type="hidden" id="EDate" runat="server"/><!--结束时间-->
    <input type="hidden" id="LockNo" runat="server"/><!--锁号-->
    <input type="hidden"  id="LLockHid" runat="server" /><!--反锁标志-->
    <input type="hidden" id="pdoorsHid" runat="server" /><!--公共门标志-->
    <div class="vip_infor" style=" margin-left:20px; width:400px;">
    <div class="type">
            <ul>
                 <li>
                    <label style="width: 60px">姓名：</label>
                    <span id="name" runat="server" style="width: 120px" class="txt inps">1003</span>
                    <%--<input type="text" class="txt inps" style="width: 130px" id="name" runat="server" maxlength="20">--%>
                </li>
                 <li>
                    <label style="width: 60px">开房方式：</label>
                    <span id="Span1" runat="server" style="width: 120px" class="txt inps">1003</span>
                </li>
                 <li>
                    <label style="width: 60px">开房时间：</label>
                    <span id="markTime" runat="server" style="width: 120px" class="txt inps">1003</span>
                    <%--<input type="text" class="txt inps" style="width: 130px" id="markTime" runat="server" maxlength="20">--%>
                </li>
                 <li>
                    <label style="width: 60px">离店时间：</label>
                    <span id="ydTime" runat="server" style="width: 120px" class="txt inps">1003</span>
                    <%--<input type="text" class="txt inps" style="width: 130px" id="ydTime" runat="server" maxlength="20">--%>
                </li>
            </ul>
    </div>
    <div class="types">
            <ul style="float: right; width: 100%">
                <li style="">
                    <input type="button" class="bus_add " value="开卡" id="btnSave" onclick="MarkCard();" runat="server" style=" margin-right:10px;"/></li>
                    <li style="margin-right: 10px">
                    <input type="button" class="bus_add " id="Button1" value="注销门卡" onclick="CardErase()" style="margin-right: 0px" />
                </li>
                <li style="margin-right: 10px">
                    <input type="button" class="bus_add " id="Button2" value="读卡" onclick="ReadCardInfo()" style="margin-right: 0px" />
                </li>
                <li style="margin-right: 0px">
                    <input type="button" class="bus_dell " id="btnClose" value="关闭" onclick="ShowInfo()" style="margin-right: 0px" />
                </li>
            </ul>
        </div>
    </div>
    </form>
</body>
</html>
