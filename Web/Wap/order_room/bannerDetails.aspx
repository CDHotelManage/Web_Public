<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bannerDetails.aspx.cs" Inherits="CdHotelManage.Web.Wap.order_room.bannerDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>图片展示</title>
      <link href="../css/layout.css" type="text/css" rel="stylesheet" />	<link href="../css/base.css" type="text/css" rel="stylesheet" />
    <script src="../js/jquery-1.4.4.min.js" type="text/javascript"></script>
   <script type="text/javascript">
       $(function () {
           $("li").css("width", $(document).width() - 10);
           $("li img").attr('width', $(document).width() - 20);
       }) 

    </script>
    <style type="text/css">
         body,ul,li{margin:0;padding:0;}
         li{list-style-type:none;margin:5px 10px;font-size:14px;}
         ul li img{height:200px;margin:0 auto;}
         
    </style>
</head>
<body>
    <form id="form1" runat="server">
      <header class="header"  data-role="header">	<div class="l">		<a href="javascript:history.go(-1)" class="iconfont back">&#xe618;</a>	</div>	<h1>酒店图片</h1>    </header>
    <div class="page" data-params="root=$&amp;callback=&amp;fallback=">	<section class="main">
    <ul>
        <asp:Repeater ID="rptBanner" runat="server">
            <ItemTemplate>
                <li><%#Eval("title") %></li>
                <li><img src='<%#Eval("imgurl") %>' /></li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
    </section>
    </div>
    </form>
</body>
</html>

 