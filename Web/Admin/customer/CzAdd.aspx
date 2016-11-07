<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CzAdd.aspx.cs" Inherits="CdHotelManage.Web.Admin.customer.CzAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>客户冲帐</title>
    <link href="../css/tch.css" rel="stylesheet" type="text/css" />
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="vip_infor" style="width: 306px">
    <input type="hidden" class=" inps" id="hidaccount" maxlength="20" runat="server" />
    <input type="hidden" class=" inps" id="orderid" maxlength="20" runat="server" />
        <div class="line">
            <div class="fl">冲帐</div>
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
                    <label style="width:60px">金额：</label>
                    <input type="text" class=" inps" id="price" runat="server" maxlength="20"/>&nbsp;元
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
