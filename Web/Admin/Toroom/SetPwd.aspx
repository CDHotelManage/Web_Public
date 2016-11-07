<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetPwd.aspx.cs" Inherits="CdHotelManage.Web.Admin.Toroom.SetPwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/tch.css" rel="stylesheet" type="text/css" />
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <script src="../js/base.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" id="accout" runat="server" />
    <div class="vip_infor" style="width: 306px">
        <div class="types" style="margin: 0px">
            <ul>
                <li>
                    <label style="width: 120px">
                        请输入密码：</label>
                    <input type="text" class=" inps" id="pwds" maxlength="20" runat="server" style="margin-right: 8px" />
                </li>
            </ul>
            <ul>
            </ul>
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
