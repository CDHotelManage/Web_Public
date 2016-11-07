<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JsComm.aspx.cs" Inherits="CdHotelManage.Web.Admin.customer.JsComm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/Admin/css/tch.css" rel="stylesheet" type="text/css" />
    <link href="/Admin/css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" id="idshid" runat="server"/>
    <div class="vip_infor" style="width: 270px">
        <div class="line">
            <div class="fl">佣金结算</div>
            <div class="errortips" id="divErrTips"></div>
        </div>
        <div class="types" style="margin:0px">
            <ul>
                <li>
                    <label style="width:60px">卡号：</label>
                    <input type="text" class=" inps" id="CardNo" maxlength="20" disabled="disabled" runat="server" style="margin-right:8px"/>
                </li></ul>
            <ul>
                <li>
                    <label style="width:60px">客户名称：</label>
                    <input type="text" class="txt inps" id="MemberName" runat="server" maxlength="20" disabled="disabled"  value="许诺"/>
                </li></ul>
            <ul>
                <li>
                    <label style="width:60px">支付方式：</label>
                    <asp:DropDownList ID="DDlZffs" DataTextField="meth_pay_name" DataValueField="meth_pay_id"
                    runat="server">
                </asp:DropDownList>
                </li></ul>
            <ul>
                <li>
                    <label style="width:60px">本次支付：</label>
                    <input type="text" class=" inps" id="Amount" runat="server" maxlength="20" disabled="disabled"  value="213"/>&nbsp;元
                </li></ul>
        </div>
        <!--储值卡支付-->
        <div class="types">
            <ul style="float: right; width: 240px">
                <li style="">
                    <input type="button" class="bus_add " value="确定" id="btnSave" onserverclick="btnSave_Click" runat="server"/></li>
                <li style="margin-right: 0px">
                    <input type="button" class="bus_dell " id="btnClose" value="关闭" onclick="Close()" style="margin-right: 0px" />
                </li>
            </ul>
        </div>
    </div>
    </form>
</body>
</html>
