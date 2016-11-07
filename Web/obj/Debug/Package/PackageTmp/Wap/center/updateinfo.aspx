<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="updateinfo.aspx.cs" Inherits="CdHotelManage.Web.Wap.center.updateinfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" />
	<title>修改资料</title>
	<link rel="stylesheet" href="../css/mobilebone.css" />
	<link rel="stylesheet" href="../css/base.css" />
    <script src="../../calendar/WdatePicker.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server" class="form">
    <header class="header"  data-role="header">
	<div class="l">
		<a href="javascript:history.go(-1)" class="iconfont back">&#xe618;</a>
	</div>
	<h1>修改资料</h1>
</header>

<div class="page" data-params="root=$&amp;callback=resetpwd&amp;fallback=resetpwdOut">
	<section class="main bgwhite">
			<ul class="" style="padding-top:40px;">
				<li class="item input">
					<i class="iconfont bz">&#xe620;</i>
					<label>
						<span class="dn">用户名</span>
                        <asp:TextBox ID="username" runat="server" placeholder="用户名" CssClass="text-b" type="tel"></asp:TextBox> 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="username">
                        </asp:RequiredFieldValidator>
                        <asp:Label ID="labname" runat="server" ForeColor="Red"></asp:Label>     
                        </label>
				</li>
				<li class="item input">
					<i class="iconfont bz">&#xe620;</i>
					<label>
						<span class="dn">真实姓名</span>
                        <asp:TextBox ID="truename" runat="server" placeholder="真实姓名"  CssClass="text-b"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="truename"></asp:RequiredFieldValidator>
                        </label>
				</li>
				<li class="item input">
					<i class="iconfont bz">&#xe620;</i>
					<label>
						
                        <span class="dn">手机号</span>
                        <asp:TextBox ID="phonenum" runat="server" CssClass="text-b" placeholder="手机号" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="phonenum"></asp:RequiredFieldValidator>
                        </label>
				</li>
                <li class="item input">
					<i class="iconfont bz">&#xe620;</i>
					<label>
                        <span class="dn">出生日期</span>
                        <asp:TextBox ID="birthday" runat="server" CssClass="text-b" placeholder="出生日期" onclick="WdatePicker()"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="birthday"></asp:RequiredFieldValidator>
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
