<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="account_goods.aspx.cs" Inherits="CdHotelManage.Web.Admin.customer.account_goods" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/tch.css" rel="stylesheet" type="text/css" />
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <link href="../../style/Opendiv.css" rel="stylesheet" type="text/css" />
    <script src="../../js/DivWH.js" type="text/javascript"></script>
    <script src="/Admin/js/base.js" type="text/javascript"></script>
    <style type="text/css">
        .div_win_center iframe{ border:none}
    table tr td{  border-left: 1px #ddd solid;}
    .vip_member a{ cursor:pointer;}
    </style>
    <script type="text/javascript">
        function Shows() {
            if (readvalue == 201) {
                $("#MemberCard").css("display", "inline-block");
                $("#Button1").css("display", "inline-block");
            }
            else if (readvalue == 204) {
                $("#Button4").css("display", "inline-block");
                $("#Button6").css("display", "inline-block");
                $("#Button7").css("display", "inline-block");
            }
            else if (readvalue == 203) {
                $("#Button5").css("display", "inline-block");
            }
        }
        var readvalue =204;
        $(function () {
            readvalue = $("#readValue").val();
            $(".rep").each(function () {
                if ($(this).val() == readvalue) {
                    $(this).attr("checked", "checked");
                }
            })
            $(".fl input").css("display", "none");
            Shows();
            $(".rep").click(function () {
                readvalue = $(this).val();
                $(".fl input").css("display", "none");
                Shows();
                Show();
            })
            Show();
            // var time = setInterval("Show()", "1000");
        })

        function Show() {
            $.get("/admin/ajax/customer.ashx", "type=GetAccount&account=" + $("#account").val() + "&readValue=" + readvalue, function (obj) {
                //$(".vip_member").find("tbody").eq(1).html(obj);
                $(".htmltable").html(obj);
            }, "text");
        }

        function ListBook(obj, occoid,goodno) {
            if (occoid == "") {
                var url = "/Admin/customer/GoodsList.aspx?id=" + goodno;
               
                showMyWindow("明细", url, 1000, 460, true, true, true);
            }
            else {
                var url = "/Admin/customer/AcountInfos.aspx?id=" + occoid;
               
                showMyWindow("明细", url, 1000, 460, true, true, true);
            }
         }

        function Addcustomer(obj,t) {
            var url = "skAcccount.aspx?accounts=" + $("#account").val() + "&t=" + t;
           
            showMyWindow("收款", url, 310, 360, true, true, true);
        }

        function AddGoods(obj) {
            var url = "GoodsPrice.aspx?accounts=" + $("#account").val();
           
            showMyWindow("商品入帐", url, 1000, 360, true, true, true);
        }
        function AddAccecs(obj) {
            var url = "CostMoney.aspx?accounts=" + $("#account").val();
            
            showMyWindow("费用入帐", url, 1000, 360, true, true, true);
        }
        function JieSuan(obj) {
            var ids = "";
            $("#tblgood").find("tbody").find("tr").each(function () {
                if ($(this).find(".chk").attr("checked")) {
                    ids += $(this).find(".ids").val() + ",";
                }
            })
            if (ids == "") {
                alert("请选择明细!!");
            }
            else {
                ids = ids.substring(0, ids.length - 1);
                var url = "JieSuan.aspx?accounts=" + $("#account").val() + "&ids=" + ids;
               
                showMyWindow("结算", url, 310, 360, true, true, true);
            }
        }

        function CxJieSuan(obj) {
            var ids = "";
            $("#tblgood").find("tbody").find("tr").each(function () {
                if ($(this).find(".chk").attr("checked")) {
                    ids += $(this).find(".ids").val() + ",";
                }
            })
            if (ids == "") {
                alert("请选择明细!!");
            }
            else {
                if (confirm("是否确认撤销?")) {
                    ids = ids.substring(0, ids.length - 1);
                    var url = "JieSuan.aspx?accounts=" + $("#account").val() + "&ids=" + ids;
                    showMyWindow("结算", url, 310, 350, true, true, true);
                    $.get("/admin/ajax/customer.ashx", "type=chexiao&ids=" + ids + "&account=" + $("#account").val(), function (obj) {
                        if (obj == "ok") {
                            alert("撤销成功！");
                        }
                        else {
                            alert("撤销失败！");

                        }
                        window.location.href = "account_goods.aspx?readValue=203&accounts=" + $("#account").val();
                    }, "text");
                }
            }
         }

        ///冲帐弹出
        function Cz(goodNo, account, orderid) {
            var obj = document.getElementById("Button5");
            var url = "CzAdd.aspx?goodNo=" + goodNo + "&account=" + account + "&orderid=" + orderid;
           
            showMyWindow("冲帐", url, 310, 360, true, true, true);
        }
        
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" id="account" runat="server"/>
    <input type="hidden" id="readValue" runat="server" />
    <div class="main" style="width: 98%; margin-left: 1%;">
    <div class="vip_infor" style="width: 100%">
    <div class="types" style="background: #EFEFEF; border: 1px solid #ddd; margin-top: 10px; display:block;" id="accoes" runat="server">
        <ul>
           <li>
                <label style="width: 100px">
                    应收帐款：</label>
              <span class="inps w80" id="ysh" runat="server"></span>
            </li>
            <li>
                <label style="width: 100px">
                    帐户余额：</label>
              <span class="inps w80" id="yush" runat="server"></span>
            </li>
            <li>
                <label style="width: 100px">
                    已结算：</label>
              <span class="inps w80" id="yjsh" runat="server"></span>
            </li>
            <li>
                <label style="width: 100px">
                    累计消费总额：</label>
              <span class="inps w80" id="njxfs" runat="server" ></span>
            </li>
            <li>
                <label style="width: 100px">
                    累计入住天数：</label>
              <span class="inps w80" id="Span4"><%=modelcus.occNum %></span>
            </li>
            <li>
                <label style="width: 100px">
                    累计NoShow次数：</label>
              <span class="inps w80" id="Span5"><%=modelcus.NoShow %></span>
            </li>
            <li>
                <label style="width: 100px">
                    累计取消预定：</label>
              <span class="inps w80" id="Span6"><%=modelcus.xqBook %></span>
            </li>
            <li>
                <label style="width: 100px">
                    同类客户排名：</label>
              <span class="inps w80" id="Span7"><%=modelcus.Pming %></span>
            </li>
            <li>
                <label style="width: 100px">
                    未结算佣金：</label>
              <span class="inps w80" id="Span8"><%=commw %></span>
            </li>
            <li>
                <label style="width: 100px">
                    已结算佣金：</label>
              <span class="inps w80" id="Span9"><%=commy %></span>
            </li>
        </ul>
     </div>
     </div>
    <div style="width: 100%; float: left; height:100%; margin-top:20px;">
    <div> 
     <input type="radio" class="rep" value="201" name="a1"/>预收款明细 <input type="radio" class="rep" name="a1" value="202"/>结账收款明细  <input type="radio" class="rep" name="a1" value="203"/>已结算明细 <input type="radio" class="rep" name="a1" value="204" checked="checked"/>未结算明细
    </div>
    <div class="htmltable">
      
    </div>
         </div>
         <div class="vip_db" style="margin-left: 0px; width: 100%">
                <div class="fl">
                    <input type="button" value="收款" class="bus_add" id="MemberCard" style=" display:none;" onclick="Addcustomer(this,0)">
                    <input type="button" value="退款" class="bus_add" id="Button1" style=" display:none;" onclick="Addcustomer(this,1)">
                    <input type="button" value="加收费用" class="bus_add" id="Button2"  style=" display:none;" onclick="Addcustomer(this)">
                    <input type="button" value="冲费" class="bus_add" id="Button3" style=" display:none;" onclick="Addcustomer(this)">
                    <input type="button" value="结算" class="bus_add" id="Button4" style=" display:none;" onclick="JieSuan(this)">
                    <input type="button" value="撤销结帐" class="bus_add" id="Button5" style=" display:none;" onclick="CxJieSuan(this)">
                     <input type="button" value="商品入帐" class="bus_add" id="Button6" style=" display:none;" onclick="AddGoods(this)">
                     <input type="button" value="费用入帐" class="bus_add" id="Button7" style=" display:none;" onclick="AddAccecs(this)">
                </div>
            </div>
         </div>
    </form>
</body>
</html>
