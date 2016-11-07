<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="order.aspx.cs" Inherits="CdHotelManage.Web.Wap.order_room.order" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>提交预定</title>
    <link rel="stylesheet" href="../css/mobilebone.css" />
	<link rel="stylesheet" href="../css/base.css" />
    <script src="../js/jquery-1.4.4.min.js" type="text/javascript"></script>
    <script src="../../calendar/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript">
      //点击退房日历激发
            function getday() {
                var startTime = $("#startDate").text();
                var endTime = $("#endDate").text(); 
                if (startTime == "" || endTime == "") {
                    $(".days").html("住1晚");
                }
                else {
                    if (startTime >= endTime) {
                        alert("日期选择有误，请重新选择！");
                        return;
                    }
                    var num = DateDiff(startTime, endTime);
                    $(".days").html("住" + num + "晚");
                }
            }

            //获取日期差
            function DateDiff(sDate1, sDate2) {
             
                var aDate, oDate1, oDate2, iDays;
                aDate = sDate1.split("-");
                oDate1 = new Date(aDate[1] + '-' + aDate[2] + '-' + aDate[0]);
                aDate = sDate2.split("-");
                oDate2 = new Date(aDate[1] + '-' + aDate[2] + '-' + aDate[0]);
                iDays = parseInt(Math.abs(oDate1 - oDate2) / 1000 / 60 / 60 / 24);

                return iDays;
            }


            $(function () {
                 
            })
    </script>                                                         
</head>
<body> 
    <form id="form1" runat="server">
    <header class="header"  data-role="header">
	<div class="l">
		<a href="javascript:history.go(-1)" class="iconfont back">&#xe618;</a>	</div>
	<h1>订单填写</h1>
    </header>
<div class="page" data-params="root=$&amp;callback=&amp;fallback=">
	<section class="main">
		<div class="layout form fill-order">
			<div class="info">
				<h2 class="f16 mb5"><asp:Label ID="labname" runat="server"></asp:Label></h2>
				<div class="co f14 g9">
					<div class="flex"><asp:Label ID="startDate" runat="server" onclick="WdatePicker({minDate:'%y-%M-%d',onpicked:function() {getday()}})" ></asp:Label>入住——
                    <asp:Label ID="endDate" runat="server" onclick="WdatePicker({minDate:'%y-%M-{%d+1}',onpicked:function() {getday()}})"></asp:Label>离店</div>
					<p class="days"><asp:Label ID="labdays" runat="server"></asp:Label></p>
				</div>
			</div>
			<ul class="listb">
				<li class="bo">
					<p><asp:Label ID="labroomType" runat="server"></asp:Label></p>
					<div class="flex tr mr10">1间</div>
					<p><i class="bol_r"></i></p>
				</li>
				<li class="bo">
					<p>到店时间</p>
					<div class="flex tr mr10" onclick="WdatePicker({minDate:'%y-%M-%d'})" id="livein">请选择</div>
					<p><i class="bol_r"></i></p>
				</li>
				<li class="bo">
					<p>入住人</p>
					<div class="flex tr mr10 g9">请选择1个入住人</div>
					<p><i class="bol_r"></i></p>
				</li>
				<li class="bo rel">
					<p>手机号码</p>
					<div class="flex tr mr30 g9">15012341234</div>
					<p class="phonebook"><i class="iconfont ">&#xe601;</i></p>
				</li>
			</ul>
			
			<div class="sub-bar">
				<div class="new">发现</div>
				<div class="co center bd">
					<div class="flex cont"><span class="f16">￥</span><span class="f23">3980</span>&emsp;<span class="f16">返</span><span class="f23">248</span></div>
                     <asp:Button ID="btnSave" runat="server" Text="提交订单" onclick="btnSave_Click" CssClass="btn-e" />
				</div>
			</div>
		</div>
	</section>
</div>
    </form>
</body>
</html>
