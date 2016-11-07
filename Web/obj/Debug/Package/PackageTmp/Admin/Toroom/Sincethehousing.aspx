<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sincethehousing.aspx.cs"
    Inherits="CdHotelManage.Web.Admin.Toroom.Sincethehousing" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../js/jquery.js" type="text/javascript"></script>
    <script src="../../js/hDate.js" type="text/javascript"></script>
    <link href="../../style/css.css" rel="stylesheet" type="text/css" />
    <link href="../../style/hDate.css" rel="stylesheet" type="text/css" />
    <link href="../../style/Opendiv.css" rel="stylesheet" type="text/css" />
    <script src="../../js/DivWH.js" type="text/javascript"></script>
    <script src="../../calendar/WdatePicker.js" type="text/javascript"></script>
    <script src="../js/base.js" type="text/javascript"></script>
    <style type="text/css">
        ul
        {
            width: 60%;
            line-height: 40px;
        }
        ul li
        {
            float: left;
            padding-left: 10px;
        }
    </style>
    <script type="text/javascript">
        function houseAdds(obj, types) {
            var a = document.getElementById("ziyong").innerText; 
            var title = "";
            if (a == "维修原因:") {
                title = "维修原因";
            } else {
                title = "自用房";
            }
            var url = "SincetheAdds.aspx?type=" + $("#hidtype").val();
            //indow_Open(obj, 4, url, 300, 300, title);
            showMyWindow(title, url, 300, 300, true, true, true);
        }
        function clos(state) {
            var a = "";
          
            if (state == 0) {
                a = "维修原因";
            }
            if (state == 1) {
                a = "自用房";
            }
            if (state == 2) {
                a = "查看维修房";
            } 
            if (state == 3) {
                a = "查看自用房"
                // 关闭当前
            }
            var jq = top.jQuery;
    
            jq("#tabs").tabs("close", a);

        }
        function isFills() {
            var date1 = document.getElementById("txt_ksDate").value;
            var date2 = document.getElementById("txt_jsdate").value;
            if (date1 == "") {
                alert('起始日期不能为空');
                return false;
            } else if (date2 == "") {
                alert('结束日期不能为空');
                return false;
            } else {
                return true;
            }
        }
        function ShowTabs(title, state) {
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
            window.location.reload(true);
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
            clos(state);
        }
        function AddDay() {
            var yltime = document.getElementById("txt_ksDate").value;
            var list = yltime.split(' ');
            var ydtime = document.getElementById("txt_jsdate").value;
            var list1 = ydtime.split(' ');
            DateDiff(list[0], list1[0]);
        }
        //两日期计算天数
        function DateDiff(sDate1, sDate2) {    //sDate1和sDate2是2006-12-18格式  
            var aDate, oDate1, oDate2, iDays
            aDate = sDate1.split("-")
            oDate1 = new Date(aDate[1] + '-' + aDate[2] + '-' + aDate[0])    //转换为12-18-2006格式
            aDate = sDate2.split("-")
            oDate2 = new Date(aDate[1] + '-' + aDate[2] + '-' + aDate[0])
            if (oDate1 >= oDate2) {
                alert("结束时间不能大于开始时间!!");
                $("#txt_jsdate").val("");
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" id="hidtype" runat="server" />
    <div style="padding-top: 10px; width: 100%;" class="bx">
        <ul>
            <li>房 间 号 ：<input type="text" name="textfield" disabled="disabled" id="txt_roomnum"
                runat="server" />
            </li>
            <li><span id="ziyong" runat="server">维修原因：</span><input type="text" style="width: 300px;"
                name="textfield" id="txt_wxyying" runat="server" />
                <span onclick="houseAdds(this)" class="greenBtn" style="cursor: pointer; color: Red;">弹出</span>
            </li>
        </ul>
        <ul>
            <li>起始日期：<input type="text" name="textfield" id="txt_ksDate" onclick="WdatePicker()"
                runat="server" />
                &nbsp;&nbsp;结束日期：<input type="text" name="textfield" id="txt_jsdate" onclick="WdatePicker({onpicked:function() {AddDay()}})"
                    runat="server" />
            </li>
            <li>单据 号：<input type="text" name="textfield" id="txt_docNo" disabled="disabled" runat="server" />
            </li>
        </ul>
        <ul id="ul3" runat="server">
            <li>报&nbsp; 修 人：<input type="text" name="textfield" id="txt_Name" runat="server" />
            </li>
            <li>维修结果：<input type="text" style="width: 370px;" name="textfield" id="txt_result"
                runat="server" />
            </li>
        </ul>
        <ul>
            <li>备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 注：<input type="text" name="textfield" id="txt_remaker"
                style="width:595px;" runat="server" />
            </li>
        </ul>
    </div>
    <div style="width: 100%; float: left; padding-left:20px;">
        <asp:Button ID="btnupdate" runat="server" Text="新增" CssClass="greenBtn"  OnClientClick="if(isFills()){}else{ return false;}"
            OnClick="btnupdate_Click" />&nbsp;
        <asp:Button ID="btndelete" runat="server" Text="删除" style=" display:none;" OnClick="btndelete_Click" />&nbsp;
    </div>
    </form>
</body>
</html>
