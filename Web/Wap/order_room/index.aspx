<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CdHotelManage.Web.Wap.order_room.index" %>

<%@ Register src="../control/banner.ascx" tagname="banner" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>酒店预定</title>
    <link href="../css/layout.css" type="text/css" rel="stylesheet" />
	<link href="../css/base.css" type="text/css" rel="stylesheet" />
    <script src="../js/jquery-1.4.4.min.js" type="text/javascript"></script>
    <script src="../js/roomtype.js" type="text/javascript"></script>
    <script src="../../calendar/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $(".clicktype").click(function () {
                $("#hideid").val($(this).attr("id"));
                $.ajax({
                    type: "post",
                    url: "roomType.aspx?typeid=" + $("#hideid").val(),
                    cache: 'false',
                    async: false,
                    success: function (msg) {
                        $(".index_menu_item div:eq(1)").html(msg);
                        $(".index_menu_item div:eq(1) img").attr('width', $(document).width() - 14);
                    }
                })
            })

            $(".index_menu_item").width($(document).width());
            $(".deleteicon").width($(document).width() - 4);

            var mydate = new Date();
            var str = "" + mydate.getFullYear() + "-";
            var month = mydate.getMonth() + 1;
            if (month < 10) {
                month = "0" + month;
            }
            str += month + "-";
            var today = str + mydate.getDate();
            var tomorrow = str + (mydate.getDate() + 1);

            $("#livein").html(today);
            $("#liveout").html(tomorrow);
            $("#hidein").val(0);
            $("#hideout").val(0);
            $(".howdays").html("住1晚");


            $(".btn-book").click(function () {
                $("#hidetype").val($(this).attr("rel"));
                $.ajax({
                    type: "post",
                    url: "order.aspx?value=123",
                    cache: 'false',
                    async: false,
                    success: function (msg) {
                        window.location = "order.aspx?datein=" + $("#livein").html() + "&dateout=" + $("#liveout").html() + "&days=" + $(".howdays").html() + "&roomtype=" + $("#hidetype").val();
                    }
                })
            })
        })
    </script>

    <script type="text/javascript">

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

        //点击退房日历激发
        function getday(id) {
            if (id == 1) {
                $("#hidein").val(parseInt($("#hidein").val()) + 1);
            }
            if(id==2) {
                $("#hideout").val(parseInt($("#hideout").val()) + 1);
            }
            var startTime = $("#livein").text();
            var endTime = $("#liveout").text(); 
            if (startTime == "" || endTime == "") {
                $(".howdays").html("住1晚");
            }
            else {
                alert($("#hidein").val());
                if (id == 1&&$("#hidein").val()!=0) {
                    if (startTime >= endTime) {
                        alert("日期选择有误，请重新选择123！");
                        return;
                    }
                }
                if (id == 2) {
                    if (startTime >= endTime) {
                        alert("日期选择有误，请重新选择！");
                        return;
                    }
                }

                var num = DateDiff(startTime, endTime);
                $(".howdays").html("住" + num + "晚");
            }
            }
    </script>
  
    
    <style type="text/css">
        .typeimg img{height:200px;margin:0px 10px;}
        .content{width:400px;}
        .content span{width:120px;height:30px;line-height:30px;padding-left:20px;}
        
        .index_menu {position:absolute; bottom:0px; left:0;z-index:101;}
        .index_menu_item {background-color:#efefef;}
        .deleteicon{text-align:right;padding-right:10px;margin-top:-15px;margin-bottom:10px;}

        .date02{color:#fff;}
    </style>
</head>
<body class="_kmain ui-mobile-viewport ui-overlay-a">
    <form id="form1" runat="server">
    <asp:HiddenField ID="hideid" runat="server" />
    <asp:HiddenField ID="hidetype" runat="server" />
    <asp:HiddenField ID="hidein" runat="server" />
    <asp:HiddenField ID="hideout" runat="server" />
        <uc1:banner ID="banner1" runat="server" />
        <section class="mainHotel">
	<div class="layout form hotel-ds">
		<div class="bo" style="margin-top:15px;">
			<div><h2>上海猫身一号泰唔士小镇奢华别墅</h2></div>
			<div><i class="bol_r"></i></div>
		</div>
		<div class="bo">
			<div class="iconAdress">上海松江区三新北路900弄935号</div>
			
		</div>
		
		<div class="bo" style="border:none;">
			<div class="iconPhone">13916388660</div>
			
		</div>
		

		
		<div  style="height:10px;background:#aaa;border:solid 1px #888;">

        </div>
		
		<div class="bo">
		
				<div class="reriod02">
				<img src="../images/iconDate.png">
					<div class="date02" onclick="WdatePicker({minDate:'%y-%M-%d',onpicked:function() {getday(1)}})" id="livein"></div>
					<div class="howdays"></div>
					<div class="date02" id="liveout" onclick="WdatePicker({minDate:'%y-%M-{%d+1}',onpicked:function() {getday(2)}})"></div>
				</div>
		
			
		</div>


        <asp:Repeater ID="rptRoomType" runat="server">
            <ItemTemplate>
                <div class="bo">
			        <div class="clicktype" id='<%#Eval("id") %>'>
				        <p class="p1"><%#Eval("room_name") %></p>
				        <p class="p1 gb0"><%#Eval("room_hour") %>钟点房</p>	
			        </div>
			    <div>
				    <div class="tc">
					    <a href="javascript:void(0)" class="btn-book" rel="<%#Eval("id") %>" >
						预定
					    </a>
					<p class="price">￥<span class="num"><%#Eval("room_zmmoney") %></span></p>
				    </div>
			    </div>
		        </div>
            </ItemTemplate>
        </asp:Repeater>
	</div>
     <div class="index_menu">
        <div class="index_menu_item">
        <div class="deleteicon"><img src="/images/scicon.png" /></div>
        <div></div>
        </div>
      </div>
</section>
    </form>
</body>
</html>

  