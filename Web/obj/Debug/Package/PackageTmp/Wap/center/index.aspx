<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CdHotelManage.Web.Wap.center.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>个人中心</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" />
	<link rel="stylesheet" href="../css/mobilebone.css">
	<link rel="stylesheet" href="../css/base.css">
</head>
<body>
    <form id="form1" runat="server">
   <header class="header"  data-role="header">
	<div class="l">
		<a href="javascript:history.go(-1)" class="iconfont back">&#xe618;</a>
	</div>
	<h1>个人中心</h1>
</header>
<!-- end jdh header -->
<div class="page" data-params="root=$&amp;callback=my&amp;fallback=myOut">
	<section class="main">
		<div class="layout mc">
			<div class="mc-head">
				<div class="pic"><img src="../images/delete/ueer_pic.jpg" alt=""></div>
				<p class="name">陈晓晓</p>
				<div class="info co">
					<div class="flex center">
						<span class="f16">积分</span> <span class="f21">888</span>
					</div>
					<div class="flex center">
						<span class="f16">优惠券</span> <span class="f21">0</span>
					</div>
				</div>
			</div>
			<ul class="mc-item">
				<li class="bo" data-href="#myorder.aspx">
					<div>
						<p class="f16">我的订单</p>
					</div>
					<div class="center"><i class="bol_r"></i></div>
				</li>
				<li class="bo" data-href="#updatepwd.aspx">
					<div>
						<p class="f16">修改密码</p>
					</div>
					<div class="center"><i class="bol_r"></i></div>
				</li>
				<li class="bo" data-href="#myinfo.aspx">
					<div>
						<p class="f16">我的资料</p>
					</div>
					<div class="center"><i class="bol_r"></i></div>
				</li>
                <li class="bo" data-href="#updateinfo.aspx">
					<div>
						<p class="f16">修改资料</p>
					</div>
					<div class="center"><i class="bol_r"></i></div>
				</li>
			</ul>
		</div>
	</section>
</div>
    </form>
</body>
</html>
