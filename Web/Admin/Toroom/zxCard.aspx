<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zxCard.aspx.cs" Inherits="CdHotelManage.Web.Admin.Toroom.zxCard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="../css/tch.css" rel="stylesheet" type="text/css" />
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <link href="../../style/Opendiv.css" rel="stylesheet" type="text/css" />
    <script src="../../js/DivWH.js" type="text/javascript"></script>
    <script src="../../js/AppendHtml.js" type="text/javascript"></script>
    <script src="../js/base.js" type="text/javascript"></script>
    <script type="text/javascript">
        function PrintRZ(order_id) {
            $("#div_Window", window.parent.document).css("display", "none");
            Open(order_id);
        }

        function Open(order_id) {
            var url = "/Admin/ShiftExc/Checkout.aspx?ga_sfacount=" + order_id;
            AppendHTML("350px", "550px", url);
        }

        function Close() {
            ShowTabs('房态图');
        }
        function ShowTabs(title) {
            // 关闭当前

            var jq = top.jQuery;
            var url = "/admin/Toroom/ToRoom.aspx";

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
            var jq = top.jQuery;
            var a = "入住信息";
            jq("#tabs").tabs("close", a);

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
                if (datastr == "FFFFFFFF") {
                    alert("此卡为空白卡，请换一张能够开门的卡！");
                }
            }
            else {
                alert("没有读取到卡数据!");
            }
            return i;
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
                    if (confirm('结账成功，是否打结账单？')) { PrintRZ($("#hidorder").val()); } else { ShowTabs('房态图'); }
                }
                else {
                    alert("注销卡片失败！");
                    if (confirm('结账成功，是否打结账单？')) { PrintRZ($("#hidorder").val()); } else { ShowTabs('房态图'); }
                }
            }
            else {
                alert("没有读取到卡数据！");
            }
        }

        function ShowInfo() {
            if (confirm('结账成功，是否打结账单？')) { PrintRZ($("#hidorder").val()); } else { ShowTabs('房态图'); }
        }
    </script>
</head>
<body>
  <OBJECT ID="ocxs" CLSID="{ACD0EB0D-284B-40D5-B49F-2107AF2F112A}" TYPE="application/x-itst-activex" width="0" height="0"></OBJECT>
    <form id="form1" runat="server">
   <input type="hidden" id="hidorder" runat="server"/>
<input type="hidden" id="hidroom" runat="server"/>

      <div class="vip_infor">
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
                    <input type="button" class="bus_add " value="注销卡" id="btnSave" onclick="CardErase();" style=" margin-right:10px;"/></li>
                 <%--   <li style="margin-right: 10px">
                    <input type="button" class="bus_add " id="Button1" value="注销门卡" onserverclick="Zx" style="margin-right: 0px" />
                </li>--%>
                <%--<li style="margin-right: 10px">
                    <input type="button" class="bus_add " id="Button2" value="读卡" onclick="Close()" style="margin-right: 0px" />
                </li>--%>
                <li style="margin-right: 0px">
                    <input type="button" class="bus_dell " id="btnClose" value="关闭" onclick="ShowInfo()" style="margin-right: 0px" />
                </li>
                <%--<li style="margin-right: 0px">
                    <input type="button" class="bus_dell " id="Button3" value="打开User" runat="server"  onserverclick="Button3_Click" style="margin-right: 0px" />
                </li>--%>
            </ul>
        </div>
    </div>
    </form>
</body>
</html>
