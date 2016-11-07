<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsPrice.aspx.cs" Inherits="CdHotelManage.Web.Admin.Toroom.GoodsPrice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../style/css.css" rel="stylesheet" type="text/css" />
    
    <script src="../../js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../js/jquery.contextmenu.r2.js" type="text/javascript"></script>
    <link href="../../easyui/themes/gray/easyui.css" rel="stylesheet" type="text/css" />
    <script src="../../easyui/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../js/hrjAddGoods.js" type="text/javascript"></script>
    <script type="text/javascript">
        function DisList(zhi) {
            var labcount = document.getElementById("labcount");
            var labMoney = document.getElementById("labMoney");
            var txtcontent = "";
            var Table = document.getElementById("Tabyxfj");
            var Money = 0;
            var count = 0;
            var number = document.getElementById("txt_Sumnum").value;
            //            alert(number);
            var txtContent = zhi.split('|');
            for (var i = 0; i < txtContent.length - 1; i++) {
                var text = txtContent[i].split('#');
                if (txtContent[i].length == 0)
                    return;
                if (number == text[0]) {
                    text[4] = parseInt(text[4]) + parseInt(document.getElementById("txt_Num").value);
                    text[5] = parseInt(text[4]) * parseFloat(text[3]);
                }

                var row = Table.insertRow(Table.rows.length);
                row.insertCell(0).innerText = text[0];
                row.insertCell(1).innerText = text[1];
                row.insertCell(2).innerText = text[2];
                row.insertCell(3).innerText = text[3];
                row.insertCell(4).innerHTML = "<input class='hidcount' style='width:50px' type='text' onkeyup='changeNum(this)' value='" + text[4] + "' />";
                row.insertCell(5).innerText = text[5];
                row.insertCell(6).innerHTML = "<span class='tdkd06'> <a style='color:red;' onclick=\"tableDel('Tabyxfj')\" href='#'>[删除]</a></span>";
                Money += parseFloat(text[5]);
                count += parseInt(text[4])
                labcount.innerText = count;
                labMoney.innerText = Money;
                txtcontent += text[0] + "#" + text[1] + "#" + text[2] + "#" + text[3] + "#" + text[4] + "#" + text[5] + "|";
                document.getElementById("hidcontent").value = txtcontent;
            }
            document.getElementById("txt_Num").value = "1";
        }
        function tableDel(Table) {
            var table = document.getElementById(Table);
            var rowIndex = event.srcElement.parentNode.parentNode.parentNode.rowIndex;
            var number = table.rows[rowIndex].cells[0].innerText;
            document.getElementById("txt_Number").value = document.getElementById("txt_Number").value.replace("" + number + "", "");
            table.deleteRow(rowIndex);
            TableText('Tabyxfj');
        }
        function TableText(tab) {
            var text = "";
            var labcount = document.getElementById("labcount");
            var labMoney = document.getElementById("labMoney");
            var Money = 0;
            var count = 0;
            var table = document.getElementById(tab);
            for (var i = 1; i < table.rows.length; i++) {
                var cellstr = "";
                var str = "";
                Money += parseFloat(table.rows[i].cells[5].innerText);
                count += parseInt(table.rows[i].cells[4].getElementsByTagName("INPUT")[0].value)
                for (var y = 0; y < table.rows[i].cells.length - 1; y++) {
                    if (y == "4") {
                        str += table.rows[i].cells[y].getElementsByTagName("INPUT")[0].value;
                        cellstr += table.rows[i].cells[y].getElementsByTagName("INPUT")[0].value + "#";
                    } else {
                        str += table.rows[i].cells[y].innerText;
                        cellstr += table.rows[i].cells[y].innerText + "#";
                    }
                }
                if (str != "")
                    text += cellstr + "|";
            }
            document.getElementById("txt_Sumnum").value = "";
            document.getElementById("HiddenField1").value = text;
            document.getElementById("hidcontent").value = text;
            labcount.innerText = count;
            labMoney.innerText = Money;
        }
        function changeNum(obj) {
            var labcount = document.getElementById("labcount");
            var labMoney = document.getElementById("labMoney");
            var txtcontent = "";
            var Money = 0;
            var count = 0;
            var table = document.getElementById('Tabyxfj');
            for (var i = 1; i < table.rows.length; i++) {
                if (table.rows[i].cells[4].getElementsByTagName("INPUT")[0].value == "") {
                    table.rows[i].cells[4].getElementsByTagName("INPUT")[0].value = "1";
                }
                var rIndex = obj.parentNode.parentNode.rowIndex;
                if (rIndex == i) {
                    table.rows[i].cells[5].innerText = parseFloat(table.rows[i].cells[3].innerText) * parseInt(obj.value);
                }
                Money += parseFloat(table.rows[i].cells[5].innerText);
                count += parseInt(table.rows[i].cells[4].getElementsByTagName("INPUT")[0].value);
                txtcontent += table.rows[i].cells[0].innerText + "#" + table.rows[i].cells[1].innerText + "#" + table.rows[i].cells[2].innerText + "#" + table.rows[i].cells[3].innerText + "#" + table.rows[i].cells[4].getElementsByTagName("INPUT")[0].value + "#" + table.rows[i].cells[5].innerText + "|";
            }
            document.getElementById("hidcontent").value = txtcontent;
            labcount.innerText = count;
            labMoney.innerText = Money;


        }
        function DivPrice() {
            document.getElementById("DivGoodContent").style.display = "block";
            document.getElementById("DivGoodContent").style.top = "50px;"
            document.getElementById("DivGoodContent").style.left = "200px;"
        }
        $(function () {
            var keyinput = $("input[name='txt_Numbers']").prev();
            keyinput.keyup(function () {
                aa();
            })
            $('html,body').click(function (e) {
                if (e.target.id.indexOf("txt_Numbers") == -1) {
                    $(".dio").css("display", "none");
                }
            });

            $("#txt_Numbers").keyup(function () {
                aa();
            })

            //取得div层 
            var index = 0;
            var b = false;
            $(document).keydown(function (event) {
                //esc键 

                if (event.keyCode == 38) {//shang
                    //                    $autocomplete.empty().hide();
                    //                    event.preventDefault();\

                    index--;
                    if (index < 0) {
                        index = $(".dio ul li").length;
                    }
                    $(".dio ul li").css("background", "#fff");
                    $(".dio ul li").eq(index).css("background", "#ececec");
                }
                if (event.keyCode == 13) {
                    var id = $(".dio ul li").eq(index).attr("id");
                    document.getElementById("txtid").value = id;
                    document.getElementById("btnGetPrice").click();
                    $(".dio").css("display", "none");

                }
                if (event.keyCode == 40) {//xia
                    if (b) { } else { index = -1; b = true; }

                    index++;
                    if (index > $(".dio ul li").length) {
                        index = 0;
                    }

                    $(".dio ul li").css("background", "#fff");
                    $(".dio ul li").eq(index).css("background", "#ececec");

                }
            });
        });

        function aa() {
            $(".dio").css("display", "block");
            var txt_number = $("input[name='txt_Numbers']").prev().val();
            $.post("/admin/ajax/books.ashx", "type=goodsprice&typeid=" + txt_number, function (objs) {
                var listarrjson = eval("(" + objs + ")");
                var tblist = listarrjson.data;
                var html = "";
                for (var i = 0; i < tblist.length; i++) {
                    html += "<li id=" + tblist[i].id + ">" + tblist[i].Goods_number + " &nbsp;&nbsp;&nbsp;" + tblist[i].Goods_name + "  &nbsp;&nbsp;&nbsp;" + tblist[i].Goods_price + " </li>";
                }
                $(".dio ul").html(html);
                $(".dio li").click(function () {
                    var id = $(this).attr("id");
                    document.getelementbyid("txtid").value = id;
                    //document.getelementbyid("btngetprice").click();
                    $(".dio").css("display", "none");
                })
            }, "text");
        }


    </script>
    <style type="text/css">
       
        .bhsl_left002 .dio
        {
            position: absolute;
            left: 62px;
            top: 27px;
            border: 1px solid #000;
            width: 180px;
            height: 170px;
            background-color: #fff;
            display: none;
            z-index:99999999;
        }
        
        .bhsl_left002 .dio ul li
        {
            line-height: 20px;
            margin: 0;
            padding: 0;
            width:100%;
        }
        .bhsl_left002 .dio ul li:hover
        {
            background-color: #ececec;
            cursor: pointer;
        }
        .datagrid-header-inner{ width:100%;}
    </style>
</head>
<body style="background: #fff">
    <!--商品入帐ok-->
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="true" runat="server">
    </asp:ScriptManager>
    <div class="sprzul s1">
        <ul>
            <li>房 号：<asp:Label ID="labfh" runat="server" Text="Label"></asp:Label></li>
            <li>房 型：<asp:Label ID="labfx" runat="server" Text="Label"></asp:Label></li>
            <li>开房方式：<asp:Label ID="labkffs" runat="server" Text="Label"></asp:Label></li>
            <li>来 源：<asp:Label ID="lably" runat="server" Text="Label"></asp:Label></li>
            <li>姓 名：<asp:Label ID="labname" runat="server" Text="Label"></asp:Label></li>
            <li>入住时间：<asp:Label ID="labrzDate" runat="server" Text="Label"></asp:Label></li>
            <li>房 价：<asp:Label ID="labfjMoney" runat="server" Text="Label"></asp:Label></li>
            <li>消费金额：<asp:Label ID="labSymoney" runat="server" Text="Label"></asp:Label></li>
        </ul>
    </div>
    <div class="bhsl_left002">
        <ul class="sprzul" style=" overflow:visible;">
            <li style=" position:relative;">编 号：
                &nbsp;&nbsp;<input type="text" runat="server" class="easyui-textbox" id="txt_Numbers"  onfocus="aa();" />
                <div class="dio">
                    <ul>
                    </ul>
                </div>
            </li>
            <li>数 量：<input style="width: 50px;" type="text" class="easyui-textbox" name="textfield" missingMessage="数量不能为空！" data-options="required:true" id="txt_Num" value='1'
                runat="server" />
            </li>
        </ul>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
           <table class="easyui-datagrid" style="width:98%;height:250px"
			data-options="singleSelect:true,collapsible:true,url:'datagrid_data1.json',method:'get'">
		<thead>
			<tr>
				<th data-options="field:'itemid',width:100,align:'center'">编号</th>
				<th data-options="field:'productid',width:200,align:'center'">商品名称</th>
				<th data-options="field:'listprice',width:100,align:'center'">单位</th>
				<th data-options="field:'unitcost',width:100,align:'center'">数量</th>
				<th data-options="field:'attr1',width:250,align:'center'">消费金额</th>
				<th data-options="field:'status',width:200,align:'center'">操作</th>
			</tr>
		</thead>
	</table>
            <div style="text-align: right;">
                合计：共<asp:Label ID="labcount" runat="server" Text="0" CssClass="red"></asp:Label>件
                金额：<asp:Label ID="labMoney" runat="server" Text="0.00" CssClass="red"></asp:Label>
                <!--结束-->
            </div>
            <div class="sprz_gray">
                支付方式：<asp:DropDownList ID="DDlZffs" DataTextField="meth_pay_name" DataValueField="meth_pay_id"
                    runat="server">
                </asp:DropDownList>
                备 注：<input type="text" id="txt_Remaker" runat="server" name="textfield" />
                <!--结束-->
                <asp:Button ID="btnAdds" runat="server" Text="确认" class="orangeBtn" Style="width: 100px"
                    OnClick="btnAdds_Click" />
                <input name="关　闭" type="button" value=" 关闭 " class="grayBtn" onclick="parent.Window_Close();"
                    style="width: 100px" /></div>
            <br />
            <input type="hidden" id="txt_Sumnum" runat="server" />
            <input type="text" id="txt_Number" runat="server" style="display: none;" />
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnGetPrice" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:HiddenField ID="hidcontent" runat="server" />
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <input type="hidden" runat="server" id="txtid" />
    <asp:Button ID="btnGetPrice" runat="server" Text="绑定" Style="display: none;" OnClick="btnGetPrice_Click" />
    <!--main结束-->
    <div class="clearboth">
    </div>
    </form>
</body>
</html>
