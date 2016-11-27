<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="CdHotelManage.Web.Admin.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>欢迎登陆酒店系统</title>
    <link href="/style/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery-1.9.1.min.js"></script>
<script type="text/javascript">
    $(function () {
        $('.bglogin').height($(document).height() - 155);
    })
     </script>
<style type="text/css">
body {
	background: #4486b7 
}

.bglogin2 li.inputK1 input
{
    width:138px;
	margin: 5px 0;
	line-height: 26px;
	height: 26px;
	border: 1px solid #0068b8;
}
    .bglogin2 li.inputK1 img
    {
       margin-left:-5px; 
    }
</style>
</head>
<body>
    <form id="form1" runat="server">
<div class="bglogin">
  <ul class="bglogin2">
  <li><img src="/images/loginText.png" /></li>
     <li class="inputK">
        用户名：<asp:TextBox ID="txtName" runat="server" Text="admin"></asp:TextBox>
        <font color="red">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                            ControlToValidate="txtName"></asp:RequiredFieldValidator></font>
        </li>
	  <li class="inputK">
      密　码：<asp:TextBox ID="txtPwd" runat="server" TextMode="Password" Text="1"></asp:TextBox>
      <font color="red">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtPwd"></asp:RequiredFieldValidator></font>
      
      </li>
      <li class="inputK1" style="width:420px;position:relative;">
        验证码：
        <asp:TextBox ID="txtSN" runat="server" Width="65px"></asp:TextBox><font
          color="red"><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtSN"></asp:RequiredFieldValidator></font>
        <img id="validatacode" src="/validateCode/validateCode.aspx" width="65px" height="26px"
                                alt="验证码" onclick="javascript:document.getElementById('validatacode').src='../validateCode/validateCode.aspx?id='+Math.random(10);"
                                style="cursor: hand;position:absolute;top:6px;" />
      </li>
	   <li class="BtnK" >　　
       <asp:Button ID="btnLogin" CssClass="button01" runat="server" Text="登陆" OnClick="btnLogin_Click" style="width:60px" />
       <asp:Button ID="btnNull" CssClass="button01" CausesValidation="false" runat="server"
                            Text="注 册" OnClick="btnNull_Click" style="width:60px" />
       </li>

       <li class="BtnK" style="margin-top:5px;color:#f00;"><asp:Label ID="lblMessage" runat="server"></asp:Label></li>
  </ul>
</div>
    </form>
</body>
</html>
