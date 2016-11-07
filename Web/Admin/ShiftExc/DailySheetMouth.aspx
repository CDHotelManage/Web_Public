<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DailySheetMouth.aspx.cs" Inherits="CdHotelManage.Web.Admin.ShiftExc.DailySheetMouth" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../style/css.css" rel="stylesheet" type="text/css" />
    <script src="../../calendar/WdatePicker.js" type="text/javascript"></script>
    <script src="../../js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../js/printy.js" type="text/javascript"></script>
    <link href="../../style/Sheet.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery.easyui.min-1.2.0.js" type="text/javascript"></script>
    <script src="../js/base.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            var sff = 0;
            var sfy = 0;
            var ssum = 0;
            var rz1s = 0; //入住和
            var zf1s = 0; //总房和
            var pj1s = 0; //平均房价和
            var fzs = 0; //房租和
            var xfs = 0; //消费和
            $(".sj").each(function () {
                var fz = $(this).find(".fz").text();
                var xf = $(this).find(".xf").text();
                fz = parseFloat(fz);
                xf = parseFloat(xf);
                $(this).find(".xj").text(fz + xf);
                rz1s += parseFloat($(this).find(".rz1").text());
                zf1s += parseFloat($(this).find(".zf1").text());
                pj1s += parseFloat($(this).find(".pj1").text());
                fzs += parseFloat($(this).find(".fz").text());
                xfs += parseFloat($(this).find(".xf").text());
            })
            $(".rzsum").text(rz1s);
            $(".zfsum").text(zf1s);
            $(".rzn").text(parseFloat(rz1s) / parseFloat(zf1s) * 100 + "%");
            $(".pjprice").text(parseFloat(pj1s) / parseFloat($(".sj").length));
            $(".fzsum").text(fzs);
            $(".xfsum").text(xfs);
            $(".xjsum").text(fzs + xfs);
        })
        function selectMonth() {
            WdatePicker({ dateFmt: 'yyyy-MM', isShowToday: false, isShowClear: false });
        }
        function ShowTab(title, url) {
            AddTabs(title, url);
      }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="topSheet">
      <span>营业日月:</span><input type="text" name="txttf" class="input001" id="time_from" runat="server" onclick="selectMonth()"/><span style="float:left;">到</span><input type="text" name="txttf" class="time_fromend" id="time_fromend" runat="server" onclick="selectMonth()"  />
      <input type="submit" name="btnQuery" value="查询" id="btnQuery" class="qtantj" runat="server" onserverclick="btnQuery_Click" />
      <input width="300px" type="button" value="打印预览" id="btnPrint" onclick="printWork('contextbody')">
    </div>
    <div class="clearboth"></div>
    <div id="contextbody">
        <div class="report_h2">
            <b>营业月报表</b>
            <p>
                <span>营业月：<%=sbtr.ToString() %></span>
            </p>
        </div>
        <table border="1" cellpadding="0" cellspacing="0" class="report_table">
        <tr class="tis">
                        <td rowspan="2">营业日</td>
                        <td colspan="4">入住情况</td>
                        <td colspan="3">营业情况</td>
                    </tr>
                    <tr class="tis">
                        <td>入住数</td>
                        <td>总房数</td>
                        <td>入住率</td>
                        <td>平均房价</td>
                        <td>房租</td>
                        <td>消费</td>
                        <td>小计</td>
                    </tr>
        <%=sbtext.ToString()%>
        <tr class="hj">
         <td>合计:</td>
         <td class="rzsum"></td>
         <td class="zfsum"></td>
         <td class="rzn"></td>
         <td class="pjprice"></td>
         <td class="fzsum"></td>
         <td class="xfsum"></td>
         <td class="xjsum"></td>
        </tr>
        </table>
        
    </div>
    </form>

</body>
</html>
