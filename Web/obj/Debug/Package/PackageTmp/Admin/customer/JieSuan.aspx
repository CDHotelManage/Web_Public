<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JieSuan.aspx.cs" Inherits="CdHotelManage.Web.Admin.customer.JieSuan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../css/tch.css" rel="stylesheet" type="text/css" />
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function Show() {
            $("#ul1").css("display", "block");
        }
        function Hide() {
            $("#ul1").css("display", "none");
        }
        function Isfill() {
            if ($("#rad1").attr("checked")) {
                var d = parent.document.getElementById("yush").innerHTML;
                if (parseInt(d) < parseInt($("#price").val())) {
                    alert("预收款不足!");
                    return false;
                }
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" runat="server" id="idss"/>
     <div class="vip_infor" style="width: 306px">
        <div class="line">
            <div class="fl">结算</div>
            <div class="errortips" id="divErrTips"></div>
        </div>
        <div class="types" style="margin:0px">
            <ul>
                <li>
                    <label style="width:60px">帐号：</label>
                    <input type="text" class=" inps" id="ga_Account" maxlength="20" runat="server"  disabled="disabled"  style="margin-right:8px"/>
                </li></ul>
            <ul>
                <li><label style="width:60px">客户名称：</label>
                    <input type="text" class="txt inps" id="AccountName" runat="server" maxlength="20" disabled="disabled"/>
                </li></ul>
            <ul>
                <li>
                    <label style="width:60px">结算金额：</label>
                    <input type="text" class=" inps" id="price" runat="server" maxlength="20"/>&nbsp;元
                </li></ul>
                <ul>
                <li>
                    <label style="width:60px">结算模式：</label>
                    <label><input type="radio" runat="server" id="rad1" name="a1" onclick="Hide()"/>扣款结算</label>  <label><input type="radio" runat="server" id="rad2" name="a1" onclick="Show()"/>收款结算</label>
                </li></ul>
            <ul id="ul1" style=" display:none;">
                <li>
                    <label style="width:60px">支付方式：</label>
                    <asp:DropDownList ID="DDlZffs" DataTextField="meth_pay_name" DataValueField="meth_pay_id"
                    runat="server">
                </asp:DropDownList>
                </li></ul>
            <ul>
                <li>
                    <label style="width:60px">备注：</label>
                    <input type="password" class="txt inps" id="ga_remker" runat="server" maxlength="20" />
                </li></ul>
        </div>
        <!--储值卡支付-->
        <div class="types">
            <ul style="float: right; width: 240px">
                <li style="">
                    <input type="submit" class="bus_add " value="确定" id="btnSave" onclick="return Isfill();" onserverclick="btnSave_Click" runat="server"/></li>
                <li style="margin-right: 0px">
                    <input type="button" class="bus_dell " id="btnClose" value="关闭" onclick="Close()" style="margin-right: 0px" />
                </li>
            </ul>
        </div>
    </div>
    </form>
</body>
</html>
