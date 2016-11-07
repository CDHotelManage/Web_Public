<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsAcountsMoney.aspx.cs"
    Inherits="CdHotelManage.Web.Admin.Toroom.GoodsAcountsMoney" %>
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="/Admin/js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <link href="../../style/css.css" rel="stylesheet" type="text/css" />
    <link href="../../style/Opendiv.css" rel="stylesheet" type="text/css" />
    <script src="../../js/DivWH.js" type="text/javascript"></script>
    <script src="../js/base.js" type="text/javascript"></script>
    <script type="text/javascript">
        var isType = true;
        function funAddTa(obj) {
            var b = true;
            $("#Tabcs tr").each(function () {
                if ($(this).find("input").val() == 0) {
                    b = false;
                }
            })
            var nowtr = $(obj).parent().parent();
            var htmobj = $("<tr>" + $(nowtr).html() + "</tr>");
            var syprice = JsPrice();
            nowtr.after("<tr>" + htmobj.html() + "</tr>");
            nowtr.next().find(".delspan").css("display", "inline-block");
            if ($("#Tabcs tr").last().find("td").length > 3) {
                $("#Tabcs tr").last().find("td").last().remove();
            }
            PuanD();
        }

        function funDel(obj) {
            $(obj).parent().parent().remove();
            if ($(obj).parent().parent().find("option:selected").text() == "协议单位") {
                $("#idids").val("");
            }
            setTimeout("Result", 1500);
        }

        function Result() {

            if ($("#Tabcs tr").length == 1) {
                $("#Tabcs tr").find(".txt_Money").val($("#txt_bcysMoneys").val());
            }
            PuanD();
        }

        function TxtInp() {
          
            $(".txt_Money").blur(function () {
                $("#Tabcs tr").each(function () {
                    $(this).attr("class","old");
                });
                $(this).parent().parent().attr("class", "nowtrs");
                if ($("#Tabcs tr").length <= 2) {
                    $("#Tabcs tr").each(function () {
                        if ($(this).attr("class") != "nowtrs" && $(this).attr("class") != "xy") {
                            var mo = parseInt($("#txt_bcysMoneys").val()) - parseInt($("#Tabcs").find(".nowtrs").find(".txt_Money").val());
                            $(this).find(".txt_Money").val(mo);
                        }
                    })
                }
                else { //如果有三行了。你还改
                    $("#Tabcs tr").each(function () {
                        if ($(this).attr("class") == "old") {
                            $(this).remove();
                        }
                    });
                }
            })
        }

        function JsPrice() {
            var txt_bcysMoneys = $("#txt_bcysMoneys").val();
            $("#Tabcs tr").each(function () {
                if ($(this).attr("class") != "xy") {
                    txt_bcysMoneys -= parseInt($(this).find(".txt_Money").val());
                }
            })
            if (parseInt(txt_bcysMoneys) < 0) {
                txt_bcysMoneys = 0;
            }
            return txt_bcysMoneys;
        }

        function ZFtext() { 
           
        }

        $(function () {
            if (parseInt($("#txt_bcysMoneys").val())>0) {
                $(".txt_Money").eq(0).val($("#txt_bcysMoneys").val());
            }
        })

        function tableDel(Table) {
            var table = document.getElementById(Table);
            var rowIndex = event.srcElement.parentNode.parentNode.parentNode.rowIndex;
            table.deleteRow(rowIndex);
        }

        function MarkCard(order_id) {
            var objs = document.getElementById("btnAdds");

            var url = "zxCard.aspx?ga_sfacount=" + order_id;
            showMyWindow("注销卡", url, 500, 150, true, true, true, Close);
        }

        function Close() {
            ShowTabs('房态图');
        }
        function ShowTabs(title){
            // 关闭当前
            var url = "/admin/Toroom/ToRoom.aspx";
            clo("房态图");
            AddTabs(title, url);
            clos();
        }

        function clos() {
            // 关闭当前
            clo("结账");
        }

        function lo() {
            var bodyHeight = document.body.clientHeight;
            var bodyWidth = document.body.clientWidth;
            var divMain = document.getElementById("divMain");
            divMain.style.width = (bodyWidth) + "px";
            divMain.style.height = (bodyHeight - 300) + "px";
        }

        function checkAll(isChecked) {//全选单选
            var btn = document.getElementById("btnAdds");
            var Gd = document.getElementById("btngd");
            var txtMoney = document.getElementById("txt_bcysMoneys");
            var bcysMoneys = document.getElementById("bcysMoney");
            var gridView1 = document.getElementById('GrdCostRoom');
            var zffs = document.getElementById("Divzffs");
            for (var i = 1; i < gridView1.rows.length; i++) {
                var rowObj = gridView1.rows[i];
                if (rowObj.cells[0].getElementsByTagName("INPUT")[0].disabled == "") {
                    rowObj.cells[0].getElementsByTagName("INPUT")[0].checked = isChecked;
                }
            }
            if (parseFloat(txtMoney.value) < 0) {
                bcysMoneys.innerHTML = "本次应退";
                txtMoney.value = txtMoney.value.replace("-", "");
            }
            if (isChecked == true) {
                document.getElementById("DivCotent").style.display = "";
                btn.value = "结账";
                Gd.style.display = "";
            } else {
                document.getElementById("DivCotent").style.display = "none";
                btn.value = "退房";
                Gd.style.display = "none";
            }
        }
        //退房结账显示隐藏
        function DivDisHid(type) {
            var btntks = document.getElementById("btntk");
            var btnqks = document.getElementById("btnqk");
            var divT = document.getElementById("DivGZ");
            var divJ = document.getElementById("DivT");
            var btn = document.getElementById("btnAdds");
            var ye = document.getElementById("txt_bcysMoney").value;
            var Gd = document.getElementById("btngd");
            if (type == "1") {
                divJ.style.display = "";
                divT.style.display = "none";
                btn.style.display = "";
                btntks.style.display = "none";
                btnqks.style.display = "none";
                Gd.style.display = "";
                $("#Tabcs tr").each(function () {
                    if ($(this).find("#DDlZffs option:selected").text() == "协议单位") {
                        btn_xy.style.display = "inline-block";
                    }
                })
              
            } else {
                divT.style.display = "";
                divJ.style.display = "none";
                btn.style.display = "none";
                btntks.style.display = "";
                Gd.style.display = "none";
                btnqks.style.display = "";
                btn_xy.style.display = "none";
                if (parseFloat(ye) < 0) {
                    document.getElementById("bcysje").innerHTML = "本次应退";
                    document.getElementById("txt_bcysMoney").value = document.getElementById("txt_bcysMoney").value.replace('-', "");
                }
            }
        }
        function disonoe() {
            var btn = document.getElementById("btnAdds");
            var txtMoney = document.getElementById("txt_bcysMoneys");
            var bcysMoneys = document.getElementById("bcysMoney");
            var Gd = document.getElementById("btngd");
            var zffs = document.getElementById("Divzffs");
            var count = 0;
            var gridView1 = document.getElementById('GrdCostRoom');
            for (var i = 1; i < gridView1.rows.length; i++) {
                var rowObj = gridView1.rows[i];
                if (rowObj.cells[0].getElementsByTagName("INPUT")[0].checked == true) {
                    count++;
                }
            }
            if (parseFloat(txtMoney.value) < 0) {
                bcysMoneys.innerHTML = "本次应退";
                txtMoney.value = txtMoney.value.replace('-', "");
                zffs.style.display = "none";
            }
            if (count == gridView1.rows.length - 1) {
                document.getElementById("DivCotent").style.display = "";
                Gd.style.display = "";
                btn.value = "结账";
            } else {
                document.getElementById("DivCotent").style.display = "none";
                btn.value = "退房";
                Gd.style.display = "none";
            }
        }
        function TableText(tab) {
            var text = "";
            var countMoney = 0;
            var table = document.getElementById(tab);
            for (var i = 0; i < table.rows.length; i++) {
                if (table.rows[i].cells[1].getElementsByTagName("input")[0].value != "") {
                    var cellstr = "";
                    var str = "";
                    str += table.rows[i].cells[0].getElementsByTagName("select")[0].value;
                    cellstr += table.rows[i].cells[0].getElementsByTagName("select")[0].value + "#" + table.rows[i].cells[1].getElementsByTagName("input")[0].value;
                    if (str != "")
                        text += cellstr + "|";
                }
                else {
                    if ($("#bcysMoney").text() == "本次应收") {
                        huruijie = false;
                        alert("请输入金额!");
                    }
                }
            }
            document.getElementById("txt_zhfsMoney").value = text;
            text = "";
        }
        function isflls() {
            var isValid = true;
            var count = 0;
            var table = document.getElementById("GrdCostRoom");
            for (var i = 1; i < table.rows.length; i++) {
                if (table.rows[i].cells[0].getElementsByTagName("INPUT")[0].checked) {
                    count++;
                }
            }
            if (count == 0) {
                alert('请选择要操作的数据');
                isValid = false;
            }
            return isValid;
        }
        var huruijie = true;
        function isFill() {
            var trs = $("#Tabcs tr");
            var summoney = 0;
            trs.each(function () {
                summoney += parseInt($(this).find(".txt_Money").val());
            })
            if ($("#bcysMoney").text() == "本次应收") {
                if ($("#txt_bcysMoneys").val() > parseInt(summoney)) {
                    alert("收款金额不足!");
                    huruijie = false;
                }
            }
            if (parseInt(summoney) > $("#txt_xfMoneys").val()) {
                alert("收款金额不能大于消费金额！！");
                huruijie = false;
            }
            if (huruijie) {
                $("#xfprice").val($("#txt_xfMoneys").val());
                $("#skPrice").val($("#txt_ysMoneys").val());
            }
            return huruijie;
        }
        function TkAdds(obj) {
            var skhj = document.getElementById("txt_ysMoneys").value;
            var ye = document.getElementById("txt_bcysMoney").value;
            var txtid = document.getElementById("txt_id").value;
            if (document.getElementById("bcysje").innerHTML == "本次应收") {
                alert('余额不足，不能退款');
                return;
            } else {
                ye = document.getElementById("txt_bcysMoney").value.replace("-", "");
                var url = "TkMoney.aspx?id=" + txtid + "&skj=" + skhj + "&yue=" + ye;
                showMyWindow("退款", url, 760, 300, true, true, true);
            }
        }
        function FkAdds(obj) {
            var txtid = document.getElementById("txt_id").value;
            var url = "FkMoney.aspx?id=" + txtid;
            showMyWindow("收款", url, 680, 300, true, true, true);
        }

        //补打单据
        function BD(obj) {
            var orderid = $("#orderids").val();
            var url = "ShiftOcc.aspx?orderids=" + orderid;
            showMyWindow("收款", url, 680, 500, true, true, true);
         }

        function Erroc() {
            alert("此房间已经结账！");
            clo("结账");
        }

        $(function () {
            var i = 0;
            $(".tableBlue .cart-data").nextAll("tr").each(function () {
                if ($(this).find(".cbxCheck input").attr("checked") == false) {
                    i++;
                }
            })
            if (i == 1) {
                $("#cbAll").click();
                checkAll(true);
            }
        })

        function CostAdds(obj) {
            var ids = document.getElementById("txt_hidid").value;
            var url = "CostMoney.aspx?id=" + ids;
            showMyWindow("费用入账", url, 1000, 350, true, true, true);
        }

        function GoodsAdds(obj) {
            var ids = document.getElementById("txt_hidid").value;
            var url = "GoodsPrice.aspx?id=" + ids;
            showMyWindow("商品入账", url, 1000, 350, true, true, true);
        }
        function Show() {
            var room = $(".selenumber").val();
            if ($("#orderids").val() != "") {
                $.get("/Admin/Ajax/GoodsAcce.ashx?r=" + Math.random(), "type=GetGoods&orderid=" + $("#orderids").val() + "&readValue=" + readvalue + "&room=" + room , function (obj) {
                    if (obj == "err") {
                        alert("此房间已结账。");
                        clos();
                    }
                    else if (obj != "") {
                        createTable();
                        var strs = obj.split("&");
                        $("#GridView1 .cart-data").after(strs[1]);
                        $("#txt_ysMoney").val(strs[0]);
                        $("#txt_xfMoney").val(strs[2]);
                        $("#txt_xfMoneys").val(strs[2]);
                        $("#txt_ysMoneys").val(strs[0]);
                        if (parseInt($("#txt_ysMoney").val()) > parseInt($("#txt_xfMoney").val())) {
                            $("#txt_bcysMoney").val(parseInt($("#txt_ysMoney").val()) - parseInt($("#txt_xfMoney").val()));
                            $("#txt_bcysMoneys").val(parseInt($("#txt_ysMoney").val()) - parseInt($("#txt_xfMoney").val()));
                            $("#bcysje").text("本次应退");
                            $("#bcysMoney").text("本次应退");
                        }
                        else {
                            $("#txt_bcysMoney").val(parseInt($("#txt_xfMoney").val()) - parseInt($("#txt_ysMoney").val()));
                            $("#txt_bcysMoneys").val(parseInt($("#txt_xfMoney").val()) - parseInt($("#txt_ysMoney").val()));
                            $("#bcysje").text("本次应收");
                            $("#bcysMoney").text("本次应收");
                            $("#hidcs").val("1");
                            if ($("#Tabcs tr").length == 1) {
                                if ($("#Tabcs tr").eq(0).find("#DDlZffs option:selected").text() == "协议单位" && $("#Tabcs tr").eq(0).attr("class") != "old") {
                                    $("#Tabcs").html($("#edittr").html());
                                    $("#Tabcs").find(".txt_Money").val($("#txt_bcysMoneys").val());
                                    $("#btn_xy").css("display", "none");
                                }
                            }
                        }
                    }

                }, "text");
            }
        }

        var readvalue = 0;
        window.onload = function () {
            Show();
            var time = setInterval("Show()", "1000");
            $(".rep").click(function () {
                readvalue = $(this).val();
            })
            $(".yszk").text($("#txt_xfMoneys").val());
            $(".yszk1").text($("#txt_ysMoneys").val());
            $(".ysq").text($("#txt_ysqje").val());
            $(".jy").text($("#txt_bcysMoneys").val());
            $(".lhfh").text($("#roomNumed").text());
            $(".lhfh").attr("title", $(".lhfh").text());
          
        }
        //清空表格
        function createTable() {
            var rowCount = $("#GridView1 tr").length;
            for (var i = rowCount - 1; i >= 1; i--) {
                $("#GridView1 tr").eq(i).remove();
            }
        }
        function PuanD(obj) {
            if ($(obj).find("option:selected").text() == "协议单位") {
                $(obj).parent().parent().attr("id", "xy");
                $("#btn_xy").css("display", "inline-block");
                $(obj).parent().parent().find("td").eq(2).last().after("<td>协议单位：<input type=\"text\" style=\"display:inline-block;\" disabled=\"disabled\" id=\"accnames\" /><img src=\"../Images/search.jpg\" id=\"imgicos\" onclick=\"XyShow(this);\"></td>");
                $(obj).parent().parent().find(".txt_Money").attr("disabled", "disabled");
            }
            else {
                $("#btn_xy").css("display", "none");
                $("#idids").val("");
                $(obj).parent().parent().find(".txt_Money").removeAttr("disabled");
                if ($(obj).parent().parent().find("td").length > 3) {
                    $(obj).parent().parent().find("td").last().remove();
                }
                if ($(obj).find("option:selected").text() == "储值卡") {
                    var objs = document.getElementById("btngd");
                    var url = "/admin/Toroom/CzPay.aspx";
                    $(obj).parent().parent().find(".txt_Money").addClass("memInp");
                    $(obj).parent().parent().find(".txt_Money").attr("disabled", "disabled");
                    showMyWindow("会员储值卡", url, 580, 230, true, true, true);
                }
            }
            trs = $("#Tabcs").find("tr");
            for (var i = 0; i < trs.length; i++) {
                for (var j = i + 1; j < trs.length; j++) {
                    if (trs.eq(i).find("select option:selected").text() == trs.eq(j).find("select option:selected").text()) {
                        trs.eq(i).find("select").css("border", "1px solid red");
                        trs.eq(j).find("select").css("border", "1px solid red");
                        isType = false;
                        return;
                    }
                    else {
                        trs.eq(i).find("select").css("border-color", "rgb(169, 169, 169)");
                        trs.eq(j).find("select").css("border-color", "rgb(169, 169, 169)");
                        isType = true;
                    }
                }
            }
        }

        function cz(obj, id, type) {
            var url = "GoodsCZ.aspx?id=" + id + "&type=" + type;
            showMyWindow("冲帐", url, 345, 350, true, true, true);
        }
        function XyShow(obj) {
            if ($(obj).attr("src") == "../images/clear.jpg") {
                $("#idids").val("");
                $("#accounts").val("");
                $("#accnames").val("");
                $("#imgicos").attr("src", "../Images/search.jpg");
                $(obj).parent()
            }
            else {
                var url = "/admin/Toroom/customerList1.aspx?orderids=" + $("#orderids").val();
                showMyWindow("选择客户", url, 1000, 550, true, true, true);
            }
        }
        function DuiHuan(obj) {
            var id = $("#hycard").val();
            var url = "DuiHuan.aspx?mid=" + id + "&txt_xfMoneys=" + $("#txt_xfMoneys").val() + "&orderid=" + $("#orderids").val();
            showMyWindow("兑换房费", url, 345, 350, true, true, true);
        }
    </script>
    <style type="text/css">
        #form1 table tbody td
        {
            border-right: none;
            border-top: none;
        }
        #GrdCostRoom TR TD, #GridView1 TR TD
        {
            font-size: 14PX;
            text-align: center;
        }
        .tdreamk{ width:200px;}
        .tddate{ width:200px;}
        #tbDesti td{border: 1px solid #333; text-align:center; }
        #tbDesti{ width:100%;  border-collapse: collapse; font-size:12px; margin-bottom:12px;}
        
    </style>
</head>
<body style="background: #fff" id="mainBody">
    <!--结帐-->
    <form id="form1" runat="server">
    <input type="hidden" id="hycard" value=""  runat="server"/>
    <input type="hidden" id="payHycard" value=""  runat="server"/>
    <input type="hidden" id="zffs_id" value="" runat="server"/>
    <input type="hidden" id="account" value="" runat="server"/>
    <input type="hidden" id="accounts" value="" runat="server"/>
    <input type="hidden" id="idids" runat="server"/>
    <input type="hidden" id="xfprice" runat="server" />
    <input type="hidden" id="skPrice" runat="server" />
    <div class="main">
        <div class="jztop">
            <p class="jzp001" style=" font:14px;">
                房号：<input type="text" style="width: 60px;" id="txt_roomNum" runat="server" />
                结账房间数:<span id="txt_num" runat="server" class="red">1</span>间 <span style="display:none;">房号:<span id="roomNumed"
                    runat="server" class="red">201</span> 姓名：<span id="txt_name" runat="server"></span>
                入住时间：<span id="txtrzDate" runat="server"></span></span></p>
            <p class="jzp002">
                <input type="button" class="orangeBtn midBtn" onclick="DivDisHid(1)" id="spantf"
                    value="退房" />
                <input type="button" class="blueBtn midBtn" onclick="DivDisHid(2)" id="spanjz" value="消费明细" />
                </p>
        </div>
        <table id="tbDesti">
         <tr>
          <td>
           客户姓名
          </td>
          <td>
          <%=prooccmodle.occ_name %>
          </td>
          <td>
           房间类型
          </td>
          <td>
          <%=GetRealTypeName(prooccmodle.real_type_id)%>
          </td>
          <td>当前状态</td>
          <td><%=GetRoomStateName(prooccmodle.state_id)%></td>
          <td>房价</td>
          <td><%=prooccmodle.real_price %></td>
          <td>入住类型</td>
          <td colspan="1"><%=GetRoomReal(prooccmodle.real_mode_id)%></td>
          <td>会员卡号</td>
          <td><%=prooccmodle.mem_cardno %></td>
         </tr>
         <tr>
          <td>入住时间</td>
          <td colspan="2"><%=prooccmodle.occ_time %></td>
          <td>离店时间</td>
          <td colspan="2"><%=prooccmodle.depar_time %></td>
          <td>其它服务</td>
          <td colspan="5"></td>
         </tr>
         <tr>
          <td>联房房号</td>
          <td colspan="7" class="lhfh"></td>
          <td>营销人员</td>
          <td></td>
          <td>客户类别</td>
          <td><%=GetSourceTypeName(prooccmodle.source_id)%></td>
         </tr>
         <tr>
         <td>应收账款</td>
         <td class="yszk"></td>
         <td>预收账款</td>
         <td class="yszk1" colspan="3"></td>
         <td >总费用</td>
         <td class="yszk" colspan="3"></td>
         <td>信用卡预授权</td>
         <td class="ysq"></td>
         </tr>
         <tr>
          <td>结余</td>
          <td class="jy"></td>
          <td>总计优惠</td>
          <td>0.000</td>
          <td>备注</td>
          <td colspan="4"><%=prooccmodle.remark %></td>
          <td>特要说明</td>
          <td colspan="2">1111</td>
         </tr>
        </table>
        <input type="hidden" id="orderids" runat="server" />
        <div id="DivT">
            <asp:GridView ID="GrdCostRoom" CssClass="tableBlue" Width="100%" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <input id="cbAll" onclick="checkAll(this.checked)" type="checkbox" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox CssClass="cbxCheck" onclick="disonoe()" ID="cbxCheck" runat="server" />
                            <asp:HiddenField ID="hidId" Value='<%# Eval("occ_id")%>' runat="server" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="room_number" HeaderText="房号" />
                    <asp:BoundField DataField="occ_name" HeaderText="客户名称" />
                    <asp:BoundField DataField="occ_time" HeaderText="入住时间" />
                    <asp:BoundField DataField="stay_day" HeaderText="天数" />
                    <asp:BoundField DataField="real_price" HeaderText="实际房价" />
                    <asp:BoundField DataField="lordRoomid" HeaderText="主从" />
                    <asp:BoundField DataField="mem_cardno" HeaderText="状态" />
                </Columns>
                <HeaderStyle CssClass="cart-data" />
            </asp:GridView>
            <div id="DivCotent" runat="server" style="display:block;">
                <div class="addyd">
                    <p>
                        消费金额：<input id="txt_xfMoneys" runat="server" type="text" />
                        已收金额：<input id="txt_ysMoneys" runat="server" type="text" />
                        <span id="bcysMoney">本次应收</span>：<input id="txt_bcysMoneys" readonly="readonly" runat="server"
                            type="text" />
                    </p>
                    <p>
                        备 注：<input id="txt_Remaker" style="width: 740px;" runat="server" type="text" />
                    </p>
                </div>
                <div id="Divzffs" class="sprz_grays" style="text-align: left;">
                    <table id="Tabcs" border="0" cellpadding="0" cellspacing="0" style="float: left;
                        padding-left: 0px; border: none;">
                        <tr class="old">
                            <td style="width: 180px; border: none;">
                                &nbsp;支付方式：<asp:DropDownList ID="DDlZffs" onchange="PuanD(this);" DataTextField="meth_pay_name" DataValueField="meth_pay_id"
                                    runat="server">
                                </asp:DropDownList>
                            </td>
                            <td style="border: none;">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 收款金额：<input style='width: 60px;' type="text" class="txt_Money"
                                    runat="server" />&nbsp;
                            </td>
                            <td style="border: none; width:52px;">
                                <span onclick="funAddTa(this)" style="color: Red; cursor: pointer;">增加</span>&nbsp;<span onclick="funDel(this)" style=" display:none;" class="delspan" style="color: Red; cursor: pointer;">删除</span>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div id="DivGZ" style="display: none;">
            <table style=" width:80%;">
             <tr>
              <td><input type="radio" checked="checked" class="rep" name="rep" id="a1" value="0"/><label for="a1">全部</label></td>
              <td><input type="radio" name="rep" class="rep" value="1" id="a2"/><label for="a2">收款明细</label></td>
              <td><input type="radio" name="rep" class="rep" value="2" id="a3"/><label for="a3">消费明细</label></td>
              <td><input type="radio" name="rep" class="rep" value="3" id="a4"/><label for="a4">冲减</label></td>
              <td>房号选择<select class="selenumber"><option value="0">全部</option><%=sboption.ToString() %></select></td>
             </tr>
            </table>
            <div id="divMain" style="overflow: auto;">
                <asp:GridView ID="GridView1" Width="100%" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="ga_roomNumber" HeaderText="房号" />
                        <asp:BoundField DataField="ga_name" HeaderText="项目名称" />
                        <asp:BoundField DataField="ga_price" HeaderText="收款金额 " />
                        <asp:BoundField DataField="ga_sum_price" HeaderText="消费金额" />
                        <%-- <asp:BoundField DataField="ga_zffs_id" HeaderText="支付方式" />--%>
                        <asp:TemplateField HeaderText="支付方式">
                            <ItemTemplate>
                                <%# GetKffsName((Eval("ga_zffs_id")).ToString())%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="操作人">
                            <ItemTemplate>
                                <%# GetUserName((Eval("ga_people")).ToString())%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                      <%--  <asp:BoundField DataField="ga_people" HeaderText="入账人" />--%>
                        <asp:BoundField DataField="ga_date" HeaderText="入账日期" />
                        <asp:BoundField DataField="ga_remker" HeaderText="备注" />
                        <asp:TemplateField HeaderText="冲帐">
                            <ItemTemplate>
                                <input type="button" class="btnOk"  value="冲帐" onclick="cz(this,'<%#Eval("Id") %>','add')"/>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle CssClass="cart-data" />
                </asp:GridView>
            </div>
            <div class="addyd">
                消费金额：<input id="txt_xfMoney" readonly="readonly" runat="server" type="text" />
                已收金额：<input id="txt_ysMoney" readonly="readonly" runat="server" type="text" />
                <span id="bcysje">本次应收</span>：<input id="txt_bcysMoney" readonly="readonly" runat="server"
                    type="text" />
                预授权金额:<input id="txt_ysqje" readonly="readonly" runat="server" value="0.00" type="text" />
                <input type="hidden" id="accname" />
            </div>
        </div>
        <div class="sprz_grays02">
            <div class="rzbtn">
                <input name="商品入账" type="button" value=" 商品入账 " class="greenBtn " onclick="GoodsAdds(this)"
                    style="width: 100px;" />
                <input name="费用入账" type="button" value=" 费用入账 " class="greenBtn " onclick="CostAdds(this)"
                    style="width: 100px;" /></div>
            <div class="kuanBtnRight">
            <%--<input id="btn_xy" runat="server" type="button" value="选择单位" onclick="XyShow(this);" class="button_orange " style="width: 100px; display:none;" />--%>
                <asp:Button ID="btngd" runat="server" Text="挂单" OnClientClick="if(isflls()){}else{return false}"
                    class="button_orange " Style="width: 100px; display: none;" OnClick="btngd_Click" />
                    <input id="btn_duihaun" runat="server" type="button" value="积分兑换" onclick="DuiHuan(this);" class="button_orange " style="width: 100px; display:inline-block;" />
                     
                 <input id="Button1" name="收　款" type="button" value="补打单据" onclick="BD(this)" class="button_orange "
                    style="width: 100px; display:inline-block;" />
                <input id="btnqk" name="收　款" type="button" value="收　款" onclick="FkAdds(this)" class="button_orange "
                    style="width: 100px; display: none;" />
                <input id="btntk" name="退　款" type="button" value="退　款" onclick="TkAdds(this)" class="button_orange "
                    style="width: 100px; display: none;" />
                <asp:Button ID="btnAdds" runat="server" Text="退房" OnClientClick="TableText('Tabcs'); if(isFill()){TableText('Tabcs');}else{return false}"
                    class="button_orange " Style="width: 100px" OnClick="btnAdds_Click" />
                <%--<input name="关　闭" type="button" value=" 关　闭 " class="button_gray " onclick="parent.Window_Close();"
                    style="width: 100px;" />--%>
            </div>
        </div>
        <table id="edittr" style="display:none;">
        <tr class="old">
                            <td style="width: 180px; border: none;">
                                &nbsp;支付方式：<asp:DropDownList ID="DropDownList1" onchange="PuanD(this);" DataTextField="meth_pay_name" DataValueField="meth_pay_id"
                                    runat="server">
                                </asp:DropDownList>
                            </td>
                            <td style="border: none;">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 收款金额：<input id="Text1" style='width: 60px;' type="text" class="txt_Money"
                                    runat="server" />&nbsp;
                            </td>
                            <td style="border: none;">
                                <span onclick="funAddTa(this)" style="color: Red; cursor: pointer;">增加</span>&nbsp;<span onclick="funDel(this)" style=" display:none;" class="delspan" style="color: Red; cursor: pointer;">删除</span>
                            </td>
                        </tr>
                        </table>
        <br />
        <div class="sprz_gray">
        </div>
        <asp:Button ID="btnserch" runat="server" Text="查询" OnClick="btnserch_Click" Style="display: none;" />
        <asp:HiddenField ID="hid_zfName" runat="server" />
        <input type="hidden" id="txt_zhfsMoney" runat="server" />
        <input type="text" id="txt_Number" runat="server" style="display: none;" />
        <input type="hidden" id="txt_id" runat="server" />
        <asp:HiddenField ID="hidcs" runat="server" Value="0" />
        <input type="text" id="txt_hidid" runat="server" style="display: none;" />
    </div>
    <!--main结束-->
    <div class="clearboth">
    </div>
    </form>
</body>
</html>
