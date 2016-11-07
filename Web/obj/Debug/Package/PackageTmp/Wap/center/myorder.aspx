<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myorder.aspx.cs" Inherits="CdHotelManage.Web.Wap.center.myorder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" />
	<title>我的订单</title>
	<link rel="stylesheet" href="../css/mobilebone.css">
	<link rel="stylesheet" href="../css/base.css">
    <script src="../js/jquery.mobile-1.4.2.min.js" type="text/javascript"></script>
    <script src="../js/jquery-1.4.4.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#tabul").width($(document.body).width());
            $("#tabul li").width($(document.body).width() * 0.48);
        })

        function tabmenu(id) {
            for (var i = 1; i <= 2; i++) {
                document.getElementById("list" + i).style.display = "none";
                document.getElementById("tabli" + i).className = "";
            }
            document.getElementById("list" + id).style.display = "block";
            document.getElementById("tabli" + id).className = "selected";
        }
    </script>
    <style type="text/css">
      #tabul li{height:30px;line-height:30px;float:left;text-align:center;font-weight:bold;}
      .selected{background:#ffac4c;color:#fff;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
   <header class="header" data-role="header">
	<div class="l"><a href="javascript:history.go(-1)" class="iconfont back">&#xe618;</a></div>
	<h1>我的订单</h1>
</header>
<div class="page" data-params="root=$&amp;callback=myOrder">
	<section class="main">
		<div class="form layout my-order">
                 <ul id="tabul">
					<li class="selected" id="tabli1" onclick="tabmenu(1)">我的预定</li>
					<li id="tabli2" onclick="tabmenu(2)">历史订单</li>
				 </ul>
                 <div style="clear:both;"></div>

			<ul class="hotels-ul" id="list1">
            <asp:Repeater ID="rptMyOrder" runat="server">
                <ItemTemplate>
                    <li class="end co">
					<div class="pic"><a href="#"><img src="../images/delete/pic1.jpg" alt=""></a></div>
					<div class="info" data-href="">
						<div class="name">
							<p>
								<a href="#">11111111</a>
							</p>
							
						</div>
						<p class="type">休闲淑女房</p>
						<div class="fd">
							<p><time>2014-09-17</time>入住</p>
							<span class="code">验证码：9120</span>
						</div>
					</div>
				</li>
                </ItemTemplate>
            </asp:Repeater>
			</ul>

            <ul class="hotels-ul" id="list2" style="display:none;">
            <asp:Repeater ID="rptMyHistory" runat="server">
                <ItemTemplate>
                    <li class="end co">
					<div class="pic"><a href="#"><img src="../images/delete/pic1.jpg" alt=""></a></div>
					<div class="info" data-href="">
						<div class="name">
							<p>
								<a href="#">2222222</a>
							</p>
						</div>
						<p class="type">休闲淑女房</p>
						<div class="fd">
							<p><time>2014-09-17</time>入住</p>
							<span class="code">验证码：9120</span>
						</div>
					</div>
				</li>
                </ItemTemplate>
            </asp:Repeater>
            </ul>
		</div>
	</section>
</div>
    </form>
</body>
</html>
