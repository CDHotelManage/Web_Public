<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CdHotelManage.Web.Wap.about.index" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">	<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" />	<title>酒店介绍</title>	<link href="../css/layout.css" type="text/css" rel="stylesheet" />	<link href="../css/base.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">  
  <header class="header">	<div class="l"><a href="javascript:history.go(-1)" class="iconfont back">&#xe618;</a></div>	<h1>酒店介绍</h1> </header><div class="hotelBanner"></div><section class="mainHotel">	<div class="layout form hotel-ds">		<ul class="bohotel">		<li class="li001 namecolor"><asp:Label ID="labname" runat="server"></asp:Label></li>			<li class="li001">			 <div class="iconAdress" ><a href="map.aspx"><asp:Label ID="labaddress" runat="server"></asp:Label></a></div>			 <div class="iconPhone"><asp:Label ID="labphone" runat="server"></asp:Label></div>			 </li>			<li class="li002">酒店服务：<img src="../images/serviceicon.png" /></li>			<li class="li001">酒店介绍：<span>            <%=Shop_Remaker%>            </span></li>		</ul>			</div></section>
    </form>
</body>
</html>
