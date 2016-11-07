<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DailySheet.aspx.cs" Inherits="CdHotelManage.Web.Admin.ShiftExc.DailySheet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>日报表</title>
    <link href="../../style/css.css" rel="stylesheet" type="text/css" />
    <script src="../../calendar/WdatePicker.js" type="text/javascript"></script>
    <script src="../../js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../js/printy.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="../../style/Sheet.css" />
    <script type="text/javascript">
        $(function () {
            var sff = 0;
            var sfy = 0;
            var ssum = 0;
            $(".sj").each(function () {
                var ff = $(this).find(".ff").text();
                var fy = $(this).find(".fy").text();
                ff = parseFloat(ff);
                fy = parseFloat(fy);
                sff += ff;
                sfy += fy;
                $(this).find(".hj").text(fy + ff);
                ssum += parseFloat($(this).find(".hj").text());
            })
            $("#sumtd").text($(".sj").length);
            $(".sumff").text(sff.toFixed(2));
            $(".goodsum").text(sfy.toFixed(2));
            $(".sumz").text(ssum.toFixed(2));
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="topSheet">
      <span>营业日:</span><input type="text" name="txttf" class="input001" id="time_from" runat="server" onclick="WdatePicker()" />
      <input type="submit" name="btnQuery" value="查询" id="btnQuery" class="qtantj" runat="server" onserverclick="btnQuery_Click" />
      <input  class="greenBtn midBtn" type="button" value="打印预览" id="btnPrint" onclick="printWork('contextbody')" />
    </div>
    <br />
    <div class="clearboth"></div>
    <div id="contextbody" >
        <div class="report_h2">
            <b>营业日报表</b>
            <p>
                营业日：<%= Convert.ToDateTime(day).ToString("yyyy-MM-dd") %>
            </p>
        </div>
        <table border="1" cellpadding="0" cellspacing="0" class="report_table">
        <tr>
         <th>
         房号
         </th>
         <th>
         名称
         </th>
         <th>
         入住类型
         </th>
         <th>
         状态
         </th>
         <th>
         标准价格
         </th>
         <th>
         实际价格
         </th>
         <th>
         来店日期
         </th>
         <th>
         离店日期
         </th>
         <th>
         房费
         </th>
         <th>
         商品费
         </th>
         <th>
         费用合计
         </th>
        </tr>
        <%=sbtext.ToString() %>
        <tr>
          <td colspan="8">合&nbsp;&nbsp;&nbsp;计&nbsp;&nbsp;&nbsp;记录数:<span id="sumtd"></span></td>
          <td class="sumff"></td>
          <td class="goodsum"></td>
          <td class="sumz"></td>
        </tr>
        </table>
        
    </div>
    </form>
</body>
</html>
