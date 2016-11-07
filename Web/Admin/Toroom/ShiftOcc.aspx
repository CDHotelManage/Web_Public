<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShiftOcc.aspx.cs" Inherits="CdHotelManage.Web.Admin.Toroom.ShiftOcc" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../style/css.css" rel="stylesheet" type="text/css" />
    <script src="../../js/DivWH.js" type="text/javascript"></script>
    <link href="../../style/Opendiv.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="../js/base.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $(".tableBlue").css("display", "none");
            $(".tableBlue").eq(0).css("display", "inline-table");
            $("#btnqk").click(function () {
                $(".tableBlue").css("display", "none");
                $(".tableBlue").eq(0).css("display", "inline-table");
            })
            $("#Button1").click(function () {
                $(".tableBlue").css("display", "none");
                $(".tableBlue").eq(1).css("display", "inline-table");
            })
        })

        function Print(obj) {
            var order_id = $("#orderids").val();
            var radio = $('input[name="radi"]:checked');
            if (radio.length <= 0) {
                alert("您没有选择");
            }
            else {
                var desp = radio.parent().next().next().text();
                var ti = "打印收款单";
                if (radio.parent().next().next().attr("class") == "tk") {
                    desp = desp * -1;
                    ti = "打印退款单";
                }
                var url = "/Admin/ShiftExc/OccupancySingle.aspx?orrderID=" + order_id + "&desp=" + desp;
                showMyWindow(ti, url, 400, 600, true, true, true);
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" id="orderids" runat="server" />
     <input id="btnqk" name="收款详情" type="button" value="收 款 详 情" class="button_orange " style=" width:100px;"/>
     <input id="Button1" name="退款详情" type="button" value="退 款 详 情" class="button_orange "  style=" width:100px;"/>
     <table class="tableBlue" style="border-collapse:collapse;">
       <tr class="cart-data">
        <th></th>
        <th>房号</th>
        <th>金额</th>
        <th>支付方式</th>
        <th>操作人</th>
        <th>时间</th>
        <th>备注</th>
       </tr>
       <%=sbtext.ToString() %>
     </table>
     <table class="tableBlue" style="border-collapse:collapse;">
       <tr class="cart-data">
        <th></th>
        <th>房号</th>
        <th>金额</th>
        <th>支付方式</th>
        <th>操作人</th>
        <th>时间</th>
        <th>备注</th>
       </tr>
       <%=sbtext1.ToString() %>
     </table>
      <input id="Button2" name="收款详情" type="button" value="打印单据" onclick="Print(this)" class="button_orange " style=" width:100px;"/>
    </form>
</body>
</html>
