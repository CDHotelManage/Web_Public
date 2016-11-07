<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="updatepwd.aspx.cs" Inherits="CdHotelManage.Web.Wap.center.updatepwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" />
	<title>重置密码</title>
	<link rel="stylesheet" href="../css/mobilebone.css" />
	<link rel="stylesheet" href="../css/base.css" />
</head>
<body>
    <form id="form1" runat="server" class="form">
   <header class="header"  data-role="header">
	<div class="l">
		<a href="javascript:history.go(-1)" class="iconfont back">&#xe618;</a>
	</div>
	<h1>重置密码</h1>
</header>

<div class="page" data-params="root=$&amp;callback=resetpwd&amp;fallback=resetpwdOut">
	<section class="main bgwhite">
			<ul class="" style="padding-top:40px;">
				<li class="item input">
					<i class="iconfont bz">&#xe607;</i>
					<label for="moblieReset">
						<span class="dn">原密码</span>
                        <asp:TextBox ID="txtpwd1" runat="server" placeholder="请输入原密码" CssClass="text-b" type="tel"></asp:TextBox> 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtpwd1">
                        </asp:RequiredFieldValidator>
                        <asp:Label ID="labname" runat="server" ForeColor="Red"></asp:Label>     
                        </label>
				</li>
				<li class="item input">
					<i class="iconfont bz">&#xe620;</i>
					<label for="pwdRest">
						<span class="dn">新密码</span>
                        <asp:TextBox ID="pwd" runat="server" placeholder="请输入新密码" data-min="6" data-max="16" CssClass="text-b" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="pwd"></asp:RequiredFieldValidator>
                        </label>
				</li>
				<li class="item input">
					<i class="iconfont bz">&#xe620;</i>
					<label for="pwdrestCheck">
						
                        <span class="dn">确认新密码</span>
                        <asp:TextBox ID="pwdCheck" runat="server" CssClass="text-b" placeholder="确认新密码" data-min="6" data-max="16" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="pwdCheck"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="两次密码不一样" ControlToValidate="pwdCheck" ControlToCompare="pwd"></asp:CompareValidator>
                        
                        </label>
				</li>
				<li class="item button">
					<asp:Button ID="btnSave" runat="server" Text="确认重置" onclick="btnSave_Click" CssClass="btn-a"/>
				</li>
			</ul>
	</section>
</div>

    </form>
</body>
</html>
