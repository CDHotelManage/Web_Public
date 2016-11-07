<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="CdHotelManage.Web.Admin.ShiftExc.Checkout" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../js/printy.js" type="text/javascript"></script>
    <link href="../../style/Sheet.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            var sff = 0;
            var sfy = 0;
            $(".trs").each(function () {
                var ff = $(this).find(".ff").text();
                var fy = $(this).find(".fy").text();
                ff = parseFloat(ff);
                fy = parseFloat(fy);
                sff += ff;
                sfy += fy;
            })
            $(".sff").text(sff.toFixed(2));
            $(".sfy").text(sfy.toFixed(2));
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input width="300px" type="button" value="打印预览" id="btnPrint" onclick="printWork('checkOut')">
    <div id="checkOut">
      <h3><%=Modelsi.shop_Name %>结账单</h3>
      <p><lable class="w80">姓名:<%=modelocc.occ_name %></lable> <lable>单号:<%=modelocc.occ_no %></lable></p>
      <p><lable class="w80">房号:<%=modelocc.room_number %></lable><lable>来时:<%=modelocc.occ_time %></lable></p>
      <p><lable class="w80">天数:<%=shijian %></lable><lable>离时:<%=modelocc.depar_time %></lable></p>
      <p><lable class="w80">会员:<%=modelocc.mem_cardno %></lable><lable>积分:0</lable></p>
      <p><lable class="w80">余额:<%=tuikuan %></lable><lable>协议单位:<%=GetXieYi(modelocc.Accounts)%></lable></p>
      <table>
       <tr>
        <th>房号</th>
        <th>科目</th>
        <th>押金</th>
        <th>费用</th>
        <th>付款方式</th>
       </tr>
       <%=sbtext.ToString() %>
       <tr>
         <td colspan="2">合计</td>
         <td class="sff">415</td>
         <td class="sfy" colspan="2">415</td>
       </tr>
      </table>
      <p>友情提示:<%=ListPrint.Where(d => d.id == 2).First().priContent %></p>
      <p>现金退款:<%=tuikuan %> 退信用卡:0</p>

    </div>
    </form>
</body>
</html>
