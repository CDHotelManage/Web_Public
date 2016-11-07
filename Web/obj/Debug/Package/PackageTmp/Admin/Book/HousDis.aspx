<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HousDis.aspx.cs" Inherits="CdHotelManage.Web.Admin.Book.HousDis" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../style/css.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.9.1.min.js" type="text/javascript"></script>
     <style type="text/css">
        .addyd li {
              height: inherit;
        }
        
        .bg_gray {
             overflow: initial;
        }
       .addyd span{ display:block; float:left; margin:0 3px;}
       
       .oknumber a{ padding:0px 5px; margin:0 10px; display:block; width:50px; float:left;background:url(/Admin/Images/edit.png) no-repeat right center #0e95cc; color:#fff; background-position: 40px -10px;border-radius:5px;
}
         .oknumber a:hover{background:url(/Admin/Images/edit.png) no-repeat right center #999; background-position: 40px -10px;}
       .rnumdiv {
           position:relative; float:left;
           width:67px;
           height:24px;
        }
         .rnumdiv a{ margin:0 10px;}
        .rnumdiv input {
            position:absolute;
            left:0px;
            top:0px;
            width:67px;
           height:24px;
        }
        .rnumdiv .rnumlist {
            position:absolute;
            left:0px;
            top:24px;
            background-color:#fff;
            display:none;
            z-index:9999;
            width:80px;
            height:80px;
            overflow:scroll;
            display:none;  overflow-x: hidden;
            border:1px solid #333;
        }
            .rnumdiv .rnumlist ul li {
                height:20px; line-height:20px; margin:2px 0;
            }
             .rnumdiv .rnumlist ul li:hover
             {
                   background-color: #1d31ac; color:#fff;
                 }

    </style>
    <script type="text/javascript">
        $(function () {
            var oks = $(".oknumber a");
            oks.click(function () {
                $(this).css("display", "none");
                $(this).attr("class", "noa");
            })


            $(".rnumlist ul li").click(function () {
                var b = true;
                var numa = $(this).parents(".rnumdiv").prev(".oknumber");
                var num = numa.find(".oka").length;
                var maxnum = $(this).parents(".rnumdiv").prevAll(".fs").text();
                if (parseInt(num) >= parseInt(maxnum)) {
                    alert("您只预定了" + maxnum + "个房间!");
                }
                else {

                    if (numa.find(".oka").length > 0) {
                        var cnum = $(this).text();
                        numa.find(".oka").each(function () {
                            if (cnum == $(this).text()) {
                                alert("这个已经选择过了!");
                                b = false;
                            }
                        })
                        if (b) {
                            numa.find(".oka").eq(parseInt(numa.find(".oka").length) - 1).after("<a class=\"oka\">" + cnum + "</a>");
                        }
                    }
                    else if (b) {//如果一个都没有
                        numa.html("<a class=\"oka\">" + $(this).text() + "</a>");
                    }

                }
                $(".oknumber a").click(function () {
                    $(this).css("display", "none");
                    $(this).attr("class", "noa");
                })
                $(".rnumlist").css("display", "none");
            })
            $(".txtFh").focus(function () {
                $(this).next().css("display", "block");
            })
            $("#okff").click(function () {
                var lis = $(".paddingdi");
                var book_no = lis.eq(0).attr("book_no");
                var delits = "";
                lis.each(function () {
                    var typeid = $(this).find(".fx").attr("typeid");
                    var fangan = $(this).attr("fangan");
                    var price = $(this).attr("price");
                    //var roomnumber = $(this).find(".fs").attr("room_number");
                    //var number = $(this).find(".number").val();
                    if ($(this).find(".oknumber .oka").length > 0) {
                        $(this).find(".oknumber .oka").each(function () {
                            var roomnumber = $(this).text();
                            delits += "typeid:" + typeid + ",fangan:" + fangan + ",price:" + price + ",roomnumber:" + roomnumber + ",number:1*";
                        })
                    }
                    else {
                        delits += "typeid:" + typeid + ",fangan:" + fangan + ",price:" + price + ",roomnumber:,number:1*";
                    }
                })
                /*向服务器*/

                $.post("/Admin/Ajax/Books.ashx", "book_no=" + book_no + "&type=UpdateRd&sjs=" + delits, function (obj) {
                    alert(obj);
                    parent.Window_Close();
                    parent.location.reload();
                }, "text");
            })

            $(".button_green").click(function () {
                var numa = $(this).prev().prev();
                var alla = numa.find(".oka");
                var num = numa.find(".oka").length;
                var maxnum = $(this).prevAll(".fs").text();
                var rnumdiv = $(this).prev();
                var as = rnumdiv.find("li");
                if (parseInt(num) >= parseInt(maxnum)) {
                    alert("您只预定了" + maxnum + "个房间!");
                }
                else if (num > 0) {
                    var s = "";
                    //numa.find(".oka").after("<a class=\"oka\">" + $(this).text() + "</a>");
                    var cha = parseInt(maxnum) - parseInt(num);

                    for (var i = 0; i < cha; i++) {
                        for (var j = 0; j < as.length; j++) {
                            var nowtext = as.eq(j).text();
                            var index = 0;
                            alla.each(function () {
                                if ($(this).text() == nowtext) {}
                                else {
                                    if (numa.find(".oka").length < maxnum) {
                                        if (numa.find(".oka").length <= 0) {
                                            $(this).parent().html("<a class=\"oka\">" + $(this).text() + "</a>"); //如果删除到一个都没有
                                        }
                                        numa.find(".oka").eq(parseInt(numa.find(".oka").length) - 1).after("<a class=\"oka\">" + nowtext + "</a>");
                                    }
                                }

                            })
                        }
                    }
                }
                else {//如果一个都没有选择
                    var cha = parseInt(maxnum) - parseInt(num);
                    var s = "";
                    for (var i = 0; i < cha; i++) {
                        s += "<a class=\"oka\">" + as.eq(i).text() + "</a>";
                    }
                    numa.html(s);
                }
                $(".oknumber a").click(function () {
                    $(this).css("display", "none");
                    $(this).attr("class", "noa");
                })
            })
        })
    </script>
</head>
<body style="background:#fff">
<!--预订分房-->



					<div class="titleDB">
				  <span style="color:#4486b7">预订分房</span>
				  <span style="float:right;color:red">单号：01020235321546</span>
				</div>
				
				<ul class="sprzul03" >
					<li >姓　　名：<asp:Label ID="lbname" runat="server" Text="Label"></asp:Label></li>
					<li >电　　话：<asp:Label ID="lbtele" runat="server" Text="Label"></asp:Label></li>
					<li >来　　源：<asp:Label ID="lbsource" runat="server" Text="Label"></asp:Label></li>
					<li >已交订金：<asp:Label ID="lbdeposit" runat="server" Text="Label"></asp:Label></li>
					<li >来店时间：<asp:Label ID="lbtimeto" runat="server" Text="Label"></asp:Label></li>					
					<li >离店时间：<asp:Label ID="lbtimefrom" runat="server" Text="Label"></asp:Label></li>
				</ul>
					
		<%=sbtext.ToString() %>
		<div class="btnWrap">
			<input name="　分 房　"  type="button" value="分房"  class="greenBtn bigBtn" id="okff"/>
					<input name="关　闭"  type="button" value=" 关　闭 " class="grayBtn bigBtn" />
		 </div>	<!--按纽结束-->
	
	

<div class="clearboth"></div>
<!-- InstanceEndEditable -->
</body>
</html>
