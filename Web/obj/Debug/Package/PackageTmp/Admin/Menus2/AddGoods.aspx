<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddGoods.aspx.cs" Inherits="CdHotelManage.Web.Admin.Menus2.AddGoods" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../style/css.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <style type="text/css">
   .types {
  width: 100%;
  float: left;
  margin-top: 10px;
  padding-bottom: 5px; color:#333
}
.types ul li {
  width: auto;
  float: left;
  margin-top: 10px;
  margin-right: 10px;
}
.mains{ width:99%; margin:0 auto;}
table {
  width: 100%;
  border-top: 0px #ddd solid;
  border-left: 1px #ddd solid;
  float: left;
}
table td
{
     text-align:center;
    }
table th {
  font-size: 14px;
  border-bottom: 1px #0789BE solid;
  border-right: 1px #66D5FF solid;
  height: 32px;
  background: #00ADEF;
  color: #FFF;
}
.gundong {
  height: 202px;
  overflow-y: scroll;
  position: relative;
  width: 100%;
}
 .dio{
            position: absolute;
            left: 77px;
            top: 25px;
            border: 1px solid #000;
            width: 300px;
            height: 170px;
            background-color: #fff;
            display: none;
            z-index:99999999;
        }
        
         .dio ul li
        {
            line-height: 25px;
            margin: 0;
            padding: 0;
            width:100%;
        }
         .dio ul li:hover
        {
            background-color: #ececec;
        }
.gundong tr{ height:25px;}
.number{ width:25%; display:block; float:left;}
.name{ width:30%;display:block; float:left;}
.price{ width:25%;display:block; float:left;}
.unit{ width:20%;display:block; float:left;height:25px;}
    </style>
    <script type="text/javascript">
        $(function () {
            $('html,body').click(function (e) {
                if (e.target.id.indexOf("txt_Numbers") == -1) {
                    $(".dio").css("display", "none");
                }
            });
            Js();
            if ($("#Hidden2").val() == "edit") {
                $(".gundong tr").each(function () {
                    $(this).find("td").eq(4).find("input").attr("disabled", "disabled");
                    $(this).find("td").eq(6).find("a").css("display", "none");
                })

            }
        })
        function Close() {
            parent.Window_Close();
        }
        function jia(obj) {
            var i = parseInt($(obj).prev().val())
            $(obj).prev().val(i + 1);
            Js();
        }
        function jian(obj) {
            var i = $(obj).next().val();
            if (i == 1) {
                if (confirm("是否删除此商品?")) {
                    $(obj).parent().parent().remove();
                }
            }
            else {
                $(obj).next().val(i - 1);
            }
            Js();
        }
        function clo(obj) {
            $(obj).parent().parent().remove();
            Js();
        }
        function Up(obj) {
            Js();
        }
        function aa() {
            $("#txt_Numbers").next().css("display", "block");
            var txt_Number = $("#txt_Numbers").val();
            $.post("/Admin/Ajax/Books.ashx", "type=goodsprice&typeid=" + txt_Number, function (objs) {
                var listArrJson = eval("(" + objs + ")");
                var tbList = listArrJson.data;
                var html = "";
                for (var i = 0; i < tbList.length; i++) {
                    html += "<li id=" + tbList[i].id + "><span class=\"number\">" + tbList[i].Goods_number + "</span><span class=\"name\">" + tbList[i].Goods_name + "</span><span class='unit'>" + tbList[i].Goods_unit + " </span><span class='price'>" + tbList[i].Goods_price + " </span></li>";
                }
                $(".dio ul").html(html);
                $(".dio li").click(function () {
                    var row = $(this);
                    var number = row.find(".number").text();
                    var b = true;
                    $(".tbProducts tr").each(function () {
                        if ($(this).attr("number") == number) {
                            var v = parseInt($(this).find("td").eq(4).find(".ProductNumber").val()) + parseInt($("#Number").val());
                            $(this).find("td").eq(4).find(".ProductNumber").val(v);
                            b = false;
                        }
                    })
                    if (b) {
                        var html = "<td width=\"8%\">" + number + "</td><td width=\"28%\">" + row.find(".name").text() + "</td><td width=\"12%\">" + row.find(".unit").text() + "</td><td width=\"12%\" style=\"text-align: right\">" + row.find(".price").text() + "</td><td width=\"16%\"><input type=\"button\" value=\"-\" onclick='jian(this)' class=\"jia reduceProductNumber\" style=\"margin-right: -1px; height: 26px;float:left; margin-left:12px; display:inline\"><input type=\"text\" name=\"RowNumber\" class=\"ProductNumber\" onkeyup='Up(this)' style=\"width: 40px; float:left; height:22px\" value=\"1\"><input type=\"button\" value=\"+\" class=\"jia a    ddProductNumber\" onclick='jia(this)' style=\"margin-left: -1px; height: 26px;float:left\"></td><td width=\"12%\" style=\"text-align: right\" class=\"RowAmount\">" + row.find(".price").text() + "</td><td width=\"12%\"><img src=\"../images/010.gif\" width=\"9\" height=\"9\"><span class=\"STYLE1\">[</span><a href=\"javascript:void(0)\" onclick='clo(this)' class=\"btnRowDelete\">删除</a><span class=\"STYLE1\">]</span></td>";
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
        function Ok_btn() {
            var txt = "";
            if ($(".tbProducts tr").length > 0) {
                $(".tbProducts tr").each(function () {
                    txt += $(this).find("td").eq(0).text() + "#" + $(this).find("td").eq(1).text() + "#" + $(this).find("td").eq(2).text() + "#" + $(this).find("td").eq(3).text() + "#" + $(this).find(".ProductNumber").val() + "#" + $(this).find("td").eq(5).text() + ",";
                })
                txt = txt.substring(0, txt.length - 1);
                $("#xq").val(txt);
                return true;
            }
            else {
                alert("请添加商品!!!");
                return false;
            }
        }

        function Js() {
            var xj = 0;
            var hj = 0;
            var hjnum = 0;
            $(".tbProducts tr").each(function () {
                var num = $(this).find(".ProductNumber").val();
                $(this).find(".RowAmount").text(parseInt(num) * parseFloat($(this).find("td").eq(3).text()));
                hjnum += parseInt(num);
                hj += parseFloat($(this).find(".RowAmount").text());
            })
            $("#hjsum").text(hjnum);
            $("#hjprice").html(hj);
            $("#inputxt").val(hjnum);
            $("#Hidden1").val(hj);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" runat="server"  id="xq"/>
    <input type="hidden" runat="server" id="inputxt" />
    <input type="hidden" runat="server" id="Hidden1" />
    <input type="hidden" runat="server" id="Hidden2" />
    <div class="mains">
    <div class="types" style="background: #EFEFEF; border: 1px solid #ddd;float:left">
            <ul>
                <li style="margin-right: 30px; display: inline;   position: relative;">
                    <label style="width: 100px">编号/拼音码：</label><input type="text" id="txt_Numbers" style="width: 260px" placeholder="输入编号/拼音码,直接回车录入" autocomplete="off" class="ac_input" runat="server" onfocus="aa();">
                    <div class="dio">
                    <ul>
                    </ul>
                </div>
                    </li>
                <li style="margin-right: 30px; display: inline;display:none;">
                    <label style="width: 60px">单价：</label><input type="text" id="Price" readonly="readonly" style="width: 80px"></li>
                <li style="margin-right: 30px; display: inline">
                    <label style="width: 60px">数量：</label><input type="text" runat="server" id="Number" value="1" style="width: 60px"></li>
                <li>
                    <input type="hidden" id="ProductId" value="">
                    <input type="hidden" id="Code" value="">
                    <input type="hidden" id="Unit" value="">
                    <input type="button" class="qtantj " value="加入" id="btnAdd" style="display: none;"></li>
            </ul>
        </div>
        <div class="types" style=" border-bottom: 1px solid #cdcdcd; padding-bottom:0;">
            <div style="width: 100%; background: #00ADEF;float:left">
                <table cellpadding="0" cellspacing="0" class="ruzhu" style="width: 98%;">
                    <tbody>
                        <tr>
                            <th width="8%">编号</th>
                            <th width="28%">商品名称</th>
                            <th width="12%">单位</th>
                            <th width="12%">单价</th>
                            <th width="16%">数量</th>
                            <th width="12%">金额</th>
                            <th width="12%">操作</th>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="gundong">
                <table cellpadding="0" cellspacing="0" class="ruzhu tbProducts">
                   <%=sb.ToString() %>
                </table>
            </div>
            <table cellpadding="0" cellspacing="0" class="ruzhu">
                <tbody>
                    <tr>
                        <td colspan="4" width="60%" style="border-right:0px"></td>
                        <td width="16%" style="border-right:0px;"><b id="TotalNumber">共 <span runat="server" id="hjsum">0</span> 件</b></td>
                        <td style="border-right:0px; text-align:left" width="22%"> <b id="TotalAmount">合计：<span runat="server" id="hjprice">0</span> 元</b></td>
                        <td width="2%"></td>
                    </tr>
                </tbody>
            </table>
        </div>

        <div class="types" style="margin-top: 0px">
            <ul style="float: left; width: 650px">
                <li style="margin-right: 20px; display: inline">
                    <label>支付方式：</label>
                    <asp:DropDownList ID="DDlZffs" DataTextField="meth_pay_name" DataValueField="meth_pay_id"
                    runat="server">
                </asp:DropDownList>
                       
                    </li>
                <li>
                    <label>备注：</label><input type="text" runat="server" id="Remark" runat="server" style="width: 300px"></li>
            </ul>
            <ul style="float: right; width: 184px">
                <li>
                    <input type="submit" class="orangeBtn midBtn" onclick="return Ok_btn();" runat="server" onserverclick="okClick"  id="btnSubmit" value="确认"></li>
                <li style="margin-right: 0px">
                    <input type="button" class="orangeBtn midBtn" id="btnClose" value="关闭" onclick="Close()" style="margin-right: 0px"></li>
            </ul>
        </div>
        </div>
    </form>
</body>
</html>
