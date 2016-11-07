<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AcountInfos.aspx.cs" Inherits="CdHotelManage.Web.Admin.customer.AcountInfos" %>

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
        function funAddTa(ta) {
            var syMoney = 0;
            var money = 0;
            var txtName = document.getElementById("hid_zfName").value;
            var table = document.getElementById(ta);
            if (table.rows.length < txtName.split(';').length - 1) {
                var txt_sumMoney = document.getElementById("txt_bcysMoney").value;
                for (var i = 0; i < table.rows.length; i++) {
                    money += parseFloat(table.rows[i].cells[1].getElementsByTagName("INPUT")[0].value);

                }

                var row = table.insertRow(table.rows.length);

                var bindcs = "&nbsp;支付方式：<select id='DDlZffs' onchange='PuanD();'>";
                var vcel = row.insertCell(0);
                vcel = row.insertCell(0);

                for (var i = 1; i < txtName.split(';').length - 1; i++) {

                    bindcs += "<option value='" + txtName.split(';')[i].split(',')[0] + "'>" + txtName.split(';')[i].split(',')[1] + "</option>";
                }
                syMoney = parseFloat(txt_sumMoney) - parseFloat(money);
                row.insertCell(0).innerHTML = bindcs + "</select>";
                row.insertCell(1).innerHTML = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;收款金额：<input class='tdkd01' name='textfield' style='width:60px;' value='" + syMoney + "' type='text' />";
                row.insertCell(2).innerHTML = "<span class='tdkd06'> <span onclick=\"funAddTa('Tabcs');\" style='cursor:pointer;color:red'>增加</span>&nbsp;&nbsp;&nbsp;<span onclick=\"tableDel('Tabcs')\" href='#' style='cursor:pointer;color:red'>删除</span></span>";
                PuanD();
            } else {
                alert('不能增加更多');
            }
        }
        function tableDel(Table) {

            var table = document.getElementById(Table);
            var rowIndex = event.srcElement.parentNode.parentNode.parentNode.rowIndex;
            table.deleteRow(rowIndex);


        }

        function PrintJz(obj, order_id) {
            var url = "/Admin/ShiftExc/Checkout.aspx?ga_sfacount=" + order_id;
           
            showMyWindow("结账单", url, 400, 610, true, true, true, Close);
        }

        function Close() {
            ShowTabs('房态图');
        }
        function ShowTabs(title) {
            // 关闭当前
            clo("房态图");
            AddTabs(title,  "/admin/Toroom/ToRoom.aspx");
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
                zffs.style.display = "none";
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
            } else {
                divT.style.display = "";
                divJ.style.display = "none";
                btn.style.display = "none";
                btntks.style.display = "";
                Gd.style.display = "none";
                btnqks.style.display = "";
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
                var cellstr = "";
                var str = "";
                str += table.rows[i].cells[0].getElementsByTagName("select")[0].value;
                // alert(table.rows[i].cells[0].getElementsByTagName("select")[0].value);
                countMoney += parseFloat(table.rows[i].cells[1].getElementsByTagName("input")[0].value);
                cellstr += table.rows[i].cells[0].getElementsByTagName("select")[0].value + "#" + table.rows[i].cells[1].getElementsByTagName("input")[0].value;
                if (str != "")
                    text += cellstr + "|";

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
        function isFill() {

            var btn = document.getElementById("btnAdds");
            var countMoney = 0;
            var count = 0
            var table = document.getElementById("Tabcs");
            for (var i = 0; i < table.rows.length; i++) {
                countMoney += parseFloat(table.rows[i].cells[1].getElementsByTagName("input")[0].value);
            }
            var count = 0;
            var table = document.getElementById("GrdCostRoom");
            for (var i = 1; i < table.rows.length; i++) {
                if (table.rows[i].cells[0].getElementsByTagName("INPUT")[0].checked) {
                    if (!$("#GrdCostRoom tr").eq(i).find("input").attr("disabled")) {
                        count++;
                    }

                }
            }
            if (count > 0) {
                var yfMoney = document.getElementById("txt_bcysMoneys");
                var money = document.getElementById("txt_Money");
                var isValid = true;
                if (document.getElementById("bcysMoney").innerHTML == "本次应收") {
                    document.getElementById("hidcs").value = 1;
                    if (btn.value == "结账") {
                        if (parseFloat(money.value) <= 0) {
                            alert('收款金额不能为零');
                            isValid = false;
                        }
                        else if (countMoney != parseFloat(yfMoney.value)) {
                            alert('收款金额与本次应收金额不符');
                            isValid = false;
                        } else if (!isType) {
                            alert('支付方式不能一样');
                            isValid = false;
                        }
                    }
                }
            } else {
                alert('请选择要操作的数据');
                isValid = false;
            }
            return isValid;

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

        function Erroc() {
            alert("此房间已经结账！");
            clo("结账");
        }

        function CostAdds(obj) {
            var ids = document.getElementById("txt_hidid").value;
            var url = "CostMoney.aspx?id=" + ids;
           
            showMyWindow("费用入账", url, 1000, 360, true, true, true);
        }

        function GoodsAdds(obj) {
            var ids = document.getElementById("txt_hidid").value;
            var url = "GoodsPrice.aspx?id=" + ids;
          
            showMyWindow("商品入账", url, 1000, 360, true, true, true);
        }
        function Show() {
            var room = $(".selenumber").val();
            if ($("#orderids").val() != "") {
                $.get("/Admin/Ajax/GoodsAcce.ashx?r=" + Math.random(), "type=GetGoods&orderid=" + $("#orderids").val() + "&readValue=" + readvalue + "&room=" + room, function (obj) {
                    if (obj != "") {
                        createTable();
                        var strs = obj.split("&");
                        $("#GridView1 .cart-data").after(strs[1]);
                        $("#txt_ysMoney").val(strs[0]);
                        $("#txt_xfMoney").val(strs[2]);
                        if (parseInt($("#txt_ysMoney").val()) > parseInt($("#txt_xfMoney").val())) {
                            $("#txt_bcysMoney").val(parseInt($("#txt_ysMoney").val()) - parseInt($("#txt_xfMoney").val()));
                            $("#bcysje").text("本次应退");
                        }
                        else {
                            $("#txt_bcysMoney").val(parseInt($("#txt_xfMoney").val()) - parseInt($("#txt_ysMoney").val()));
                            $("#bcysje").text("本次应收");
                        }
                    }

                }, "text");
            }
        }
        var readvalue = 0;
        window.onload = function () {
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
        function PuanD() {
            trs = $("#Tabcs").find("tr");
            for (var i = 0; i < trs.length; i++) {
                for (var j = i + 1; j < trs.length; j++) {
                    if (trs.eq(i).find("#DDlZffs option:selected").text() == trs.eq(j).find("#DDlZffs option:selected").text()) {
                        trs.eq(i).find("#DDlZffs").css("border", "1px solid red");
                        trs.eq(j).find("#DDlZffs").css("border", "1px solid red");
                        isType = false;
                        return;
                    }
                    else {
                        trs.eq(i).find("#DDlZffs").css("border-color", "rgb(169, 169, 169)");
                        trs.eq(j).find("#DDlZffs").css("border-color", "rgb(169, 169, 169)");
                        isType = true;
                    }
                }
            }
        }
        function cz(obj, id, type) {
            var url = "GoodsCZ.aspx?id=" + id + "&type=" + type;

            showMyWindow("冲帐", url, 345, 360, true, true, true);
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
        .btnOk{ display:none;}
        
    </style>
</head>
<body style="background: #fff">
    <!--结帐-->
    <form id="form1" runat="server">
    <div class="main">
        <div class="jztop">
            <p class="jzp001" style=" font:14px;">
                房号：<input type="text" style="width: 60px;" id="txt_roomNum" runat="server" />
                结账房间数:<span id="txt_num" runat="server" class="red">1</span>间 <span style="display:none;">房号:<span id="roomNumed"
                    runat="server" class="red">201</span> 姓名：<span id="txt_name" runat="server"></span>
                入住时间：<span id="txtrzDate" runat="server"></span></span></p>
            <%--<p class="jzp002" style="display:none;">
                <input type="button" class="orangeBtn midBtn" onclick="DivDisHid(1)" id="spantf"
                    value="退房" />
                <input type="button" class="blueBtn midBtn" onclick="DivDisHid(2)" id="spanjz" value="消费明细" />
                </p>--%>
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
          <td colspan="3"><%=GetRoomReal(prooccmodle.real_mode_id)%></td>
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
        <div id="DivT" style=" display:none;">
            <asp:GridView ID="GrdCostRoom" CssClass="tableBlue" Width="100%" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <%--<asp:CheckBox ID="cbselect" runat="server" onclick="checkAll(this.checked)" />--%>
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
            <div id="DivCotent" style="display: none;">
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
                        <tr>
                            <td style="width: 180px; border: none;">
                                &nbsp;支付方式：<asp:DropDownList ID="DDlZffs" onchange="PuanD();" DataTextField="meth_pay_name" DataValueField="meth_pay_id"
                                    runat="server">
                                </asp:DropDownList>
                            </td>
                            <td style="border: none;">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 收款金额：<input style='width: 60px;' type="text" id="txt_Money"
                                    value="0" runat="server" />&nbsp;
                            </td>
                            <td style="border: none;">
                                <span onclick="funAddTa('Tabcs')" style="color: Red; cursor: pointer;">增加</span>&nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div id="DivGZ">
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
            </div>
        </div>
        <div class="sprz_grays02" style=" display:none;">
            <div class="rzbtn">
                <input name="商品入账" type="button" value=" 商品入账 " class="greenBtn " onclick="GoodsAdds(this)"
                    style="width: 100px;" />
                <input name="费用入账" type="button" value=" 费用入账 " class="greenBtn " onclick="CostAdds(this)"
                    style="width: 100px;" /></div>
            <div class="kuanBtnRight">
                <asp:Button ID="btngd" runat="server" Text="挂单" OnClientClick="if(isflls()){}else{return false}"
                    class="button_orange " Style="width: 100px; display: none;" OnClick="btngd_Click" />
                <input id="btnqk" name="收　款" type="button" value="收　款" onclick="FkAdds(this)" class="button_orange "
                    style="width: 100px; display: none;" />
                <input id="btntk" name="退　款" type="button" value="退　款" onclick="TkAdds(this)" class="button_orange "
                    style="width: 100px; display: none;" />
                <asp:Button ID="btnAdds" runat="server" Text="退房" OnClientClick="if(isFill()){TableText('Tabcs');}else{return false}"
                    class="button_orange " Style="width: 100px" OnClick="btnAdds_Click" />
                <%--<input name="关　闭" type="button" value=" 关　闭 " class="button_gray " onclick="parent.Window_Close();"
                    style="width: 100px;" />--%>
            </div>
        </div>
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
