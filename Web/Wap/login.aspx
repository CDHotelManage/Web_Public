<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="CdHotelManage.Web.Wap.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta charset="UTF-8" />
   <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" />
	<title>会员登录</title>
	<link rel="stylesheet" href="css/mobilebone.css" />
	<link rel="stylesheet" href="css/base.css" />
</head>
<body>
    <form id="loginForm" runat="server" class="form">
    <header class="header"  data-role="header">
	<div class="l">
		<a href="javascript:history.go(-1)" class="iconfont back">&#xe618;</a>
	</div>
	<h1>登录</h1>
</header>
<!-- end jdh header -->
<div class="page">
	<section class="main bgwhite">
			<ul style="padding-top:40px;">
				<li class="item input">
					<i class="iconfont bz">&#xe607;</i>
					<label for="moblieLogin">
						<span class="dn">用户名</span>
                        <asp:TextBox ID="txtname" runat="server" CssClass="text-b" placeholder="请输入用户名"></asp:TextBox>
                        </label>
				</li>
				<li class="item input">
					<i class="iconfont bz">&#xe620;</i>
					<label for="pwdLogin">
						<span class="dn">登陆密码</span>
                        <asp:TextBox ID="txtpwd" runat="server"  CssClass="text-b" placeholder="请输入登陆密码" data-min="6" data-max="16" TextMode="Password"></asp:TextBox>
                         <asp:Label ID="lblMessage" runat="server"></asp:Label>
                        </label>
				</li>
				<li class="item button">
                     <asp:Button ID="btnLogin" runat="server" Text="登录" onclick="btnLogin_Click" CssClass="btn-a" />
					<p class="mt10">
						<a href="reg.aspx" class="f16 red">注册新会员</a>
					</p>
				</li>
			</ul>
	</section>
</div>

<div class="bg"></div>
    </form>
</body>
</html>
