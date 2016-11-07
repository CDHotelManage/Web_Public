<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myinfo.aspx.cs" Inherits="CdHotelManage.Web.Wap.center.myinfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" />
	<title>我的资料</title>
	<link rel="stylesheet" href="../css/mobilebone.css">
	<link rel="stylesheet" href="../css/base.css">
</head>
<body>
    <form id="form1" runat="server">
   <header class="header"  data-role="header">
	<div class="l">
		<a href="javascript:history.go(-1)" class="iconfont back">&#xe618;</a>
	</div>
	<h1>我的资料</h1>
	<div class="r"><i class="iconfont menu open-bar">&#xe60b;</i></div>
</header>
<!-- end jdh header -->
<div class="page" data-params="root=$&amp;callback=&amp;fallback=">
	<section class="main">
		<div class="layout">
			<ul class="listb">
				<li class="bo">
					<p>姓&emsp;&emsp;名</p>
					<p class="flex ml30 g9"><asp:Label ID="labname" runat="server"></asp:Label></p>
				</li>
				<li class="bo">
					<p>手&emsp;&emsp;机</p>
					<p class="flex ml30 g9"><asp:Label ID="labphone" runat="server"></asp:Label></p>
				</li>
				<li class="bo">
					<p>性&emsp;&emsp;别</p>
					<p class="flex ml30 g9"><asp:Label ID="labsex" runat="server"></asp:Label></p>
				</li>
				<li class="bo">
					<p>地&emsp;&emsp;址</p>
					<p class="flex ml30 g9"><asp:Label ID="labaddress" runat="server"></asp:Label></p>
				</li>
				<li class="bo">
					<p>用户类型</p>
					<p class="flex ml30 g9"><asp:Label ID="labtype" runat="server"></asp:Label></p>
				</li>
			</ul>
		</div>
	</section>
</div>
    </form>
</body>
</html>
