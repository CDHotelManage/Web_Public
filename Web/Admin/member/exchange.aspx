<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="exchange.aspx.cs" Inherits="CdHotelManage.Web.Admin.member.exchange" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <link href="../css/tch.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../js/base.js" type="text/javascript"></script>
    <script src="../js/exchange.js" type="text/javascript"></script>
   <style type="text/css">
       .ac_results ul li:hover{background-color: Blue;color: #fff;}
       .dio{position: absolute;left: 100px;top: 34px;border: 1px solid #000;width: 300px;height: 170px;background-color: #fff;display: none;z-index: 99999999;}
       .dio ul li{line-height: 25px;margin: 0;padding: 0;width: 100%; color:#333;}
       .dio ul li:hover{background-color: #00F;
color: #FFF;}
.ruzhu_infor ul li span{ color:#333;}
        .gundong tr{ height:25px;}
        .number{ width:25%; display:block; float:left;}
        .name{ width:30%;display:block; float:left;}
        .price{ width:15%;display:block; float:left;}
        .jf{ width:10%;display:block; float:left;}
        .unit{ width:20%;display:block; float:left;height:25px;}
   </style>
    <script type="text/javascript">
        $(function () {
            $('html,body').click(function (e) {
                if (e.target.id.indexOf("txt_Numbers") == -1) {
                    $(".dio").css("display", "none");
                }
            });
        })

        function isFill() {
            if ($("#mid").val() == "") {
                alert("请选择会员");
                return false;
            }
            if (parseInt($("#totalJf").text()) > parseInt($("#TotalScore").text())) {
                alert("积分不足!!");
                return false;
            }
            return true;
        }

        function aa() {

            $("#txt_Numbers").next().css("display", "block");
            var txt_Number = $("#txt_Numbers").val();

            $.post("/Admin/Ajax/Books.ashx", "type=goodsprice&typeid=" + txt_Number+"&isb=1", function (objs) {
                var listArrJson = eval("(" + objs + ")");
                var tbList = listArrJson.data;
                var html = "";
                for (var i = 0; i < tbList.length; i++) {
                    html += "<li id=" + tbList[i].id + "><span class=\"number\">" + tbList[i].Goods_number + "</span><span class=\"name\">" + tbList[i].Goods_name + "</span><span class='unit'>" + tbList[i].Goods_unit + " </span><span class='price'>" + tbList[i].Goods_price + " </span><span class='jf'>" + tbList[i].Goods_jf + " </span></li>";
                }
                $(".dio ul").html(html);
                $(".dio li").click(function () {
                    var row = $(this);
                    var number = row.find(".number").text();
                    var b = true;
                    $(".tbProducts tr").each(function () {
                        if ($(this).attr("number") == number) {
                            var v = parseInt($(this).find("td").eq(5).find(".ProductNumber").val()) + parseInt($("#Number").val());
                            $(this).find("td").eq(5).find(".ProductNumber").val(v);
                            b = false;
                        }
                    })
                    if (b) {
                        var html = "<td width=\"8%\">" + number + "</td><td width=\"18%\">" + row.find(".name").text() + "</td><td width=\"12%\">" + row.find(".unit").text() + "</td><td width=\"10%\" style=\"text-align: right\">" + row.find(".price").text() + "</td><td width=\"10%\" style=\"text-align: right\">" + row.find(".jf").text() + "</td><td width=\"14%\"><input type=\"button\" value=\"-\" onclick='jian(this)' class=\"jia reduceProductNumber\" style=\"margin-right: -1px; height: 26px;float:left; display:inline\"><input type=\"text\" name=\"RowNumber\" class=\"ProductNumber\" onkeyup='Up(this)' style=\"width: 40px; float:left; height:22px\" value=\"1\"><input type=\"button\" value=\"+\" class=\"jia addProductNumber\" onclick='jia(this)' style=\"margin-left: -1px; height: 26px;float:left\"></td><td width=\"8%\" style=\"text-align: right\" class=\"RowAmount\">" + row.find(".price").text() + "</td><td width=\"8%\"></td><td width=\"12%\"><img src=\"../images/010.gif\" width=\"9\" height=\"9\"><span class=\"STYLE1\">[</span><a href=\"javascript:void(0)\" onclick='clo(this)' class=\"btnRowDelete\">删除</a><span class=\"STYLE1\">]</span></td>";
                        var index = 0;
                        if ($(".tbProducts tr").length == 0) {
                            $(".tbProducts").html("<tr class=\"\" number='" + number + "'>" + html + "</tr>");
                        }
                        else {
                            index = $(".tbProducts tr").length - 1;
                            $(".tbProducts tr").eq(index).after("<tr class=\"\" number='" + number + "'>" + html + "</tr>");
                        }
                    }
                    Js();
                    $(".dio").css("display", "none");
                })

            }, "text");
        }
        function Js() {
            var xj = 0;
            var hj = 0;
            var hjnum = 0;
            $(".tbProducts tr").each(function () {
                var num = $(this).find(".ProductNumber").val();
                $(this).find(".RowAmount").text(parseInt(num) * parseFloat($(this).find("td").eq(3).text()));
                $(this).find("td").eq(7).text(parseInt(num) * parseFloat($(this).find("td").eq(4).text()));
                hjnum += parseInt(num);
                hj += parseFloat($(this).find(".RowAmount").text());
                xj += parseFloat($(this).find("td").eq(7).text());
            })
            $("#TotalNumber").text(hjnum);
            $("#totalJf").text(xj);
            $("#hidjf").val(xj);
//            $("#hjprice").html(hj);
//            $("#inputxt").val(hjnum);
//            $("#Hidden1").val(hj);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="ruzhu_infor" style="width: 860px">
    <input type="hidden" id="mid" runat="server" />
        <div class="line">
            <div class="fl">积分兑换</div>
            <div class="errortips" id="divErrorTips"></div>
            <input type="hidden" id="CardId" />
            <input type="hidden" id="CCardNo" />
            <input type="hidden" id="TotalNum" />
            <input type="hidden" id="TotalPrice" />
        </div>
        <div class="types" id="CAdd">
            <ul>
                <li>
                    <label>条件：</label><input type="text" class="txt inps" id="CardNo" autocomplete="off" maxlength="20" /></li>
                <li>
                    <input type="button" class="credit" value="查询" id="btnSearch" />
                    <input type="button" class="credit " value="读卡" id="btnReadCard" style="display:none;"/>
                    <input type="button" class="credit " value="写卡" id="btnWriteCard" style="display:none;"/>
                    <input type="button" class="credit " value="清卡" id="btnClearCard" style="display:none;"/>
                </li>
            </ul>
        </div>
        <div class="types" style="background: #EFEFEF; border: 1px solid #ddd">
            <ul>
                <li style="margin-right: 30px; display: inline">
                    <label>姓&nbsp;&nbsp;&nbsp;名：</label>
                    <span style="width: 136px; float: left; line-height: 24px;" class="txt inps" id="MemberName">&nbsp;</span>
                </li>
                <li style="margin-right: 30px; display: inline">
                    <label style="width: 60px">手机号码：</label>
                    <span style="width: 120px; float: left; line-height: 24px;" class="txt inps" id="Phone">&nbsp;</span>
                </li>
                <li style="margin-right: 30px; display: inline">
                    <label>类&nbsp;&nbsp;&nbsp;型：</label>
                    <span style="width: 120px; float: left; line-height: 24px;" class="txt inps" id="CategoryName">&nbsp;</span>
                </li>
            </ul>
        </div>

        <div class="types" style="background: #EFEFEF; border: 1px solid #ddd">
            <ul>
                <li style="margin-right: 38px; display: inline">
                    <label>总&nbsp;积&nbsp;分：</label><p id="TotalScore">0.00</p>
                </li>
                <li style="margin-right: 38px; display: inline">
                    <label>兑换积分：</label><p id="UsedScore">0.00</p>
                </li>
                <li style="margin-right: 38px; display: inline">
                    <label>剩余积分：</label><p id="UsableScore">0.00</p>
                </li>
                <li style="margin-right: 0px; display: inline">
                    <label>冻结积分：</label><p id="FrozenScore">0.00</p>
                </li>

                <li style="margin-right: 38px; display: inline">
                    <label>总&nbsp;储&nbsp;值：</label><p id="TotalAmount">0.00</p>
                </li>
                <li style="margin-right: 38px; display: inline">
                    <label>消费储值：</label><p id="UsedAmount">0.00</p>
                </li>
                <li style="margin-right: 38px; display: inline">
                    <label>储值余额：</label><p id="UsableAmount">0.00</p>
                </li>
                <li style="margin-right: 0px; display: inline">
                    <label>发卡时间：</label><p id="OpenDate">&nbsp;</p>
                </li>


                <li style="margin-right: 38px; display: inline">
                    <label>消费次数：</label>
                    <p id="ConsumeTimes">0.00</p>
                </li>
                <li style="margin-right: 38px; display: inline">
                    <label>消费金额：</label><p id="ConsumeAmount">0.00</p>
                </li>
                <li style="margin-right: 38px; display: inline">
                    <label>卡片状态：</label><p id="Status">&nbsp;</p>
                </li>
                <li style="margin-right: 0px; display: inline">
                    <label>有效时间：</label><p id="ExprieDate">&nbsp;</p>
                </li>

            </ul>
        </div>

        <div class="types" style="background: #EFEFEF; border: 1px solid #ddd; position: relative;">
            <ul>
                <li style="margin-right: 30px; display: inline">
                    <label style="width: 100px">编号/拼音码：</label><input type="text" id="txt_Numbers" style="width: 260px" placeholder="输入编号/拼音码,直接回车录入"  onfocus="aa();"/><div class="dio">
                    <ul>
                    </ul>
                </div></li>
                <li style="margin-right: 30px; display: inline">
                    <label style="width: 60px">单价：</label><input type="text" id="Price" readonly="readonly" style="width: 80px" /></li>
                <li style="margin-right: 30px; display: inline">
                    <label style="width: 60px">数量：</label><input type="text" id="Number" value="1" style="width: 60px" /></li>
                <li>
                    <input type="hidden" id="ProductId" value="" />
                    <input type="hidden" id="Code" value="" />
                    <input type="hidden" id="Unit" value="" />
                    <input type="hidden" id="Score" value="" />
                    <input type="button" class="qtantj " value="加入" id="btnAdd" />
                </li>
            </ul>
        </div>

        <div class="types">
            <div style="width: 100%; background: #00ADEF; float: left">
                <table cellpadding="0" cellspacing="0" class="ruzhu" style="width: 98%;">
                    <tbody>
                        <th width="8%">编号</th>
                        <th width="18%">商品名称</th>
                        <th width="12%">单位</th>
                        <th width="10%">单价</th>
                        <th width="10%">兑换积分</th>
                        <th width="14%">数量</th>
                        <th width="8%">金额</th>
                        <th width="8%">总积分</th>
                        <th width="12%">操作</th>
                    </tbody>
                </table>
            </div>
            <div class="gundong" style="height: 125px">
                <table cellpadding="0" cellspacing="0" class="ruzhu tbProducts">
                    
                </table>
            </div>
            <table cellpadding="0" cellspacing="0" class="ruzhu">
                <tbody>
                    <tr>
                        <td colspan="9" style="text-align: right"><b id="1">共 <span id="TotalNumber">0</span> 件</b><b></b><b></b>
                            <b id="ZTotalScore">积分：<span id="totalJf" >0</span></b><b></b><b></b><b></b><input type="hidden" id="hidjf" runat="server" /></td>
                    </tr>

                </tbody>
            </table>
        </div>
        <div class="types" style="margin-top: 0px">
            <ul style="float: right; width: 184px">
                <li>
                    <input type="submit" class="bus_add " value="积分兑换" id="btnSubmit" runat="server" onclick="return isFill();" onserverclick="btnSubmit_click" /></li>
                <li style="margin-right: 0px">
                    <input type="button" class="bus_dell " value="关闭" onclick="Close()" id="btnClose" style="margin-right: 0px" /></li>
            </ul>
        </div>
    </div>
    <div class="ac_results" style="position: absolute; width: 420px; top: 67px; left: 70px;">
        <ul style="max-height: 180px; overflow: auto;">  
       </ul>
    </div>
    </form>
</body>
</html>
