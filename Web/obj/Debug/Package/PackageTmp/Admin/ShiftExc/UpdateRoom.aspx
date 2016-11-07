<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateRoom.aspx.cs" Inherits="CdHotelManage.Web.Admin.ShiftExc.UpdateRoom" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../js/printy.js" type="text/javascript"></script>
    <script src="../../js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <link href="../../style/Sheet.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $(".imgclose").click(function () {
                parent.parent.location.reload();
            })
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="button" value="打印预览" id="btnPrint" onclick="printWork('updateRoom')" />
    <img src="../Images/20150506043824760_easyicon_net_21.6720554273.png" class="imgclose" style=" position:fixed; right:0; top:0;"/>
    <div id="updateRoom">
    <h3><%=Modelsi.shop_Name %>换房确定单</h3>
    <table>
     <tr>
       <td>客户姓名</td>
       <td colspan="3"><%=modelafter.occ_name %></td>
     </tr>
     <tr>
       <td>换房前房号</td>
       <td><%=modelafter.room_number %></td>
       <td>房价</td>
       <td><%=modelafter.real_price %></td>
     </tr>
     <tr>
       <td>入住时间</td>
       <td colspan="3"><%=modelafter.occ_time %></td>
     </tr>
     <tr>
       <td>换房时间</td>
       <td colspan="3"><%=DateTime.Now.ToString() %></td>
     </tr>
     <tr>
       <td>换房后房号</td>
       <td><%=modelh.room_number %></td>
       <td>房价</td>
       <td><%=modelh.real_price %></td>
     </tr>
     <tr>
      <td class="4" colspan="4">换房原因</td>
     </tr>
     <tr style="height:40px;">
       <%=modelafter.remark %>
     </tr>
    </table>
    <p>客户签名:</p>
    <p>操作员:System</p>
    </div>
    </form>
</body>
</html>
