<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="custromerDestic.aspx.cs" Inherits="CdHotelManage.Web.Admin.customer.custromerDestic" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <link href="../css/tch.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <style type="text/css">
       .fram{ width:100%; border:none; height:100%;}
       .vip_member li a{ display:block;}
    </style>
    <script type="text/javascript">
        $(function () {
            document.getElementById("Leftdiv").style.height = document.documentElement.clientHeight + "px";
            var accounts = $("#accounts").val();
            $(".fram").attr("src", "protocol.aspx?accounts=" + accounts);
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" id="accounts"  runat="server"/>
    <div style="width:8%; float: left; margin-left:10px; margin-top:20px;">
        <ul class="vip_member" id="Ul1" style="width: 100%">
            <li class=""><a href="protocol.aspx?accounts=<%=proaccid %>" target="if1">客户协议</a></li>
            <li class=""><a href="contactsList.aspx?accounts=<%=proaccid %>" target="if1">联系人</a></li>
            <li class=""><a href="CommissionList.aspx?accounts=<%=proaccid %>" target="if1">佣金</a></li>
            <li class=""><a href="account_goods.aspx?accounts=<%=proaccid %>&readValue=204" target="if1">当前帐务</a></li>
            <li class=""><a href="Transfer.aspx?accounts=<%=proaccid %>" target="if1">转账</a></li>
            <li class=""><a href="../RoomGustkr/RoomkrSelect.aspx?accounts=<%=proaccid %>" target="if1">入住记录</a></li>
        </ul>
    </div>
    <div style=" width:90%; float:left;" id="Leftdiv">
       <iframe name="if1" class="fram"></iframe>
    </div>
    </form>
</body>
</html>
