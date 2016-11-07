<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reg.aspx.cs" Inherits="CdHotelManage.Web.Wap.reg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>会员注册</title>
    <meta charset="UTF-8" />
	<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" />
	<link rel="stylesheet" href="css/mobilebone.css" />
	<link rel="stylesheet" href="css/base.css" />
</head>
<body>
<form id="regForm" runat="server" class="form">
<header class="header"  data-role="header">
	<div class="l">
		<a href="javascript:history.go(-1)" class="iconfont back">&#xe618;</a>
	</div>
	<h1>注册会员</h1>
</header>
<div class="page">
	<section class="main bgwhite">
			<ul class=""  style="padding-top:40px;">
				<li class="item input">
					<i class="iconfont bz">&#xe607;</i>
					<label for="moblieReg">
						<span class="dn">用户名</span>
                        <asp:TextBox ID="moblieReg" runat="server" placeholder="请输入有效的用户名" CssClass="text-b" type="tel"></asp:TextBox> 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="moblieReg">
                        </asp:RequiredFieldValidator>
                        <asp:Label ID="labname" runat="server" ForeColor="Red"></asp:Label>   
                        </label>
				</li>
				<li class="item input">
					<i class="iconfont bz">&#xe620;</i>
					<label for="pwd">
						<span class="dn">登陆密码</span>
                        <asp:TextBox ID="pwd" runat="server" placeholder="6-16为登陆密码" data-min="6" data-max="16" CssClass="text-b" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="pwd"></asp:RequiredFieldValidator>
                        </label>
				</li>
				<li class="item input">
					<i class="iconfont bz">&#xe620;</i>
					<label for="pwdCheck">
						<span class="dn">确认登陆密码</span>
                        <asp:TextBox ID="pwdCheck" runat="server" CssClass="text-b" placeholder="确认登陆密码" data-min="6" data-max="16" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="pwdCheck"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="两次密码不一样" ControlToValidate="pwdCheck" ControlToCompare="pwd"></asp:CompareValidator>
                        </label>
				</li>
				<li class="item button">
					<asp:Button ID="btnSave" runat="server" Text="提交" onclick="btnSave_Click" CssClass="btn-a"/>
                    <p class="mt10">
						<a href="login.aspx" class="f16 red">已是会员，直接登录</a>
					</p>
				</li>
                
			</ul>

	</section>
</div>


<!-- end jdh menu -->
<div class="bg"></div>

    </form>
</body>
</html>
