<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="apartmentInfosAdds.aspx.cs"
    Inherits="CdHotelManage.Web.Admin.Toroom.apartmentInfosAdds" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="../../js/jquery.js" type="text/javascript"></script>
    <script src="../../js/hDate.js" type="text/javascript"></script>
    <link href="../../style/css.css" rel="stylesheet" type="text/css" />
    <link href="../../style/hDate.css" rel="stylesheet" type="text/css" />
    <link href="../../style/Opendiv.css" rel="stylesheet" type="text/css" />
    <script src="../../js/DivWH.js" type="text/javascript"></script>
    <script src="../../calendar/WdatePicker.js" type="text/javascript"></script>
    <script src="../js/base.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#fangan").css("display", "none");
            var zqqian = $("#txt_money").val();
            var zqtime = $("#txt_ylDate").val();
            $("#DDlKffs").change(function () {
                var txt = $("#DDlKffs option:checked").text();
                if (txt == "钟点房") {
                    var id = $("#ddroomtype").val();
                    $.get("/Admin/Ajax/SysPara.ashx?r=" + Math.random(), "type=getfa&typeid=" + id, function (obj) {
                        if (obj.statu == "ok") {
                            $("#fangan").css("display", "block");
                            var data = obj.data;
                            var options = "";
                            for (var i = 0; i < data.length; i++) {
                                options += "<option hs_start_long=\"" + data[i].hs_start_long + "\"  hs_start_price=\"" + data[i].hs_start_price + "\" value=\"" + data[i].id + "\">" + data[i].hs_name + "</option>";
                            }
                            $("#fangan #ZD_hourse").html(options);
                            JS1();
                            $("#ZD_hourse").change(function () {
                                JS1();
                            })
                        }
                        else if (obj.statu == "err") {
                            alert(obj.msg);
                            $("#DDlKffs option").eq(0).attr("selected", "selected");
                        }
                    }, "json");
                }
                else {
                    $("#fangan").css("display", "none");
                    $("#txt_money").val(zqqian);
                    $("#txt_ylDate").val(zqtime);
                }

            })

            function JS1() {
                var hs_start_long = $("#ZD_hourse").find("option:checked").attr("hs_start_long");
                var hs_start_price = $("#ZD_hourse").find("option:checked").attr("hs_start_price");
                $("#txtsort").val($("#ZD_hourse").find("option:checked").attr("value"));
                $("#txt_money").val(hs_start_price);
                $.get("/Admin/Ajax/SysPara.ashx?r=" + Math.random(), "type=gettime&time=" + hs_start_long, function (obj) {
                    $("#txt_ylDate").val(obj);
                }, "text");
            }
        })

        function clos() {
            clo("入住信息");
        }

        function CostAdds(obj) {
            var ids = document.getElementById("txt_roomnumber").value;
            var roomid = document.getElementById("hidSuikeInfo").value;
            var url = "PeopleInfosk.aspx?id=" + ids + "&rooms=" + roomid;
            showMyWindow("客人信息", url, 1000, 350, true, true, true);
        }
        function DivDis() {
            var Div = document.getElementById("DivDisHid");
            var hidd = document.getElementById("zhankai");
            if (hidd.innerHTML == "展开") {
                hidd.innerHTML = "隐藏";
            } else {
                hidd.innerHTML = "展开";
            }


            if (hidd.innerHTML == "隐藏") {
                Div.style.display = "block";

            } else {
                Div.style.display = "none";
            }
        }
        function DivDisRoom() {
            var Div = document.getElementById("DivDisHidroom");
            var hidd = document.getElementById("btn_rooms");

            if (hidd.value == "联房开房") {
                hidd.value = "终止开房";
                Div.style.display = "block";
                document.getElementById("btnbur").click();
                var txt = $("#DDlKffs option:checked").text();
            } else {
                hidd.value = "联房开房";
                Div.style.display = "none";
            }
        }
        function addsDate() {
            var txtNum = document.getElementById("txt_Day").value;
            AddDays(txtNum);
        }


        function AddDays(Num) {
            var ydDate = document.getElementById("txt_rzdate").value;
            var LSTR_ndate = new Date(ydDate);
            var MHS = " " + LSTR_ndate.getHours() + ":" + LSTR_ndate.getMinutes() + ":" + LSTR_ndate.getSeconds();
            var LSTR_Year = LSTR_ndate.getFullYear();
            var LSTR_Month = LSTR_ndate.getMonth();
            var LSTR_Date = LSTR_ndate.getDate();
            //处理 
            var uom = new Date(LSTR_Year, LSTR_Month, LSTR_Date);
            uom.setDate(uom.getDate() + parseInt(Num)); //取得系统时间的前一天,重点在这里,负数是前几天,正数是后几天
            var LINT_MM = uom.getMonth();
            LINT_MM++;
            var LSTR_MM = LINT_MM > 10 ? LINT_MM : ("0" + LINT_MM)
            var LINT_DD = uom.getDate();
            var LSTR_DD = LINT_DD > 10 ? LINT_DD : ("0" + LINT_DD)
            //得到最终结果 
            uom = LSTR_Year + "-" + LSTR_MM + "-" + LSTR_DD + MHS;
            document.getElementById("txt_ylDate").value = uom;
        }
        function funAddTa(ta) {
            var txtName = document.getElementById("txt_CardesName").value;
            var table = document.getElementById(ta);
            var row = table.insertRow(table.rows.length);
            $(row).addClass("tr3");
            var bindcs = "<select><option>请选择</option>";
            var vcel = row.insertCell(0);
            vcel = row.insertCell(0);

            row.insertCell(0).innerHTML = "<input class='tdkd01' name='textfield' style='width:60px;' type='text' />";
            row.insertCell(1).innerHTML = "<input class='tdkd01'  name='textfield' style='width:60px;' type='text' />";
            row.insertCell(2).innerHTML = "<input class='tdkd01'  name='textfield' style='width:70px;' type='text' onclick=\"calendar.show({ id: this })\" />";
            for (var i = 0; i < txtName.split(';').length - 1; i++) {

                bindcs += "<option value='" + txtName.split(';')[i].split(',')[0] + "'>" + txtName.split(';')[i].split(',')[1] + "</option>";
            }
            row.insertCell(3).innerHTML = bindcs + "</select>";
            row.insertCell(4).innerHTML = " <input class='tdkd01'  name='textfield' style='width:90px;' type='text' />";
            row.insertCell(5).innerHTML = " <input class='tdkd01'  name='textfield' style='width:350px;' type='text' />";
            row.insertCell(6).innerHTML = "<span class=''> <a onclick=\"tableDel('Tabcs')\" href='#'>[删]</a></span>";
            var index = 0;
            $(".tdkd01").change(function () {
                TableText(ta);
                //document.getElementById("txt_CardesName").value = document.getElementById("txt_CardesName").value;

            })

        }

        function PrintRZ(obj, order_id) {
            var url = "/Admin/ShiftExc/OccupancySingle.aspx?orrderID=" + order_id + "&type=rz";
            showMyWindow("打印开房单", url, 400, 600, true, true, true, Close);
        }

        function Close() {
            ShowTabs('房态图');
        }

        function GetBind(zhi, txtfh) {
            var txtName = document.getElementById("txt_CardesName").value;
            var Table = document.getElementById("Tabcs");
            var txtContent = zhi.split('|');
            for (var i = 0; i < txtContent.length - 1; i++) {
                alert(txtContent.length - 1);
                if (txtContent[i].length == 0)
                    return;
                var text = txtContent[i].split('#');
                alert(text);
                if (text[0] == txtfh) {
                    alert(text[0]);
                    var row = Table.insertRow(Table.rows.length);
                    var bindcs = "<select><option>请选择</option>";
                    var vcel = row.insertCell(0);
                    vcel = row.insertCell(0);
                    row.insertCell(0).innerHTML = "<input value='" + text[1] + "' class='tdkd01' name='textfield' style='width:60px;' type='text' />";
                    row.insertCell(1).innerHTML = "<input value='" + text[2] + "' class='tdkd01'  name='textfield' style='width:60px;' type='text' />";
                    row.insertCell(2).innerHTML = "<input value='" + text[3] + "' class='tdkd01'  name='textfield' style='width:70px;' type='text' onclick=\"calendar.show({ id: this })\" />";
                    for (var i = 0; i < txtName.split(';').length - 1; i++) {
                        if (txtName.split(';')[i].split(',')[0] == text[4]) {
                            bindcs += "<option selected='selected' value='" + txtName.split(';')[i].split(',')[0] + "'>" + txtName.split(';')[i].split(',')[1] + "</option>";
                        } else {
                            bindcs += "<option value='" + txtName.split(';')[i].split(',')[0] + "'>" + txtName.split(';')[i].split(',')[1] + "</option>";
                        }
                    }
                    row.insertCell(3).innerHTML = bindcs + "</select>";
                    row.insertCell(4).innerHTML = " <input value='" + text[5] + "' class='tdkd01'  name='textfield' style='width:90px;' type='text' />";
                    row.insertCell(5).innerHTML = " <input value='" + text[6] + "' class='tdkd01'  name='textfield' style='width:350px;' type='text' />";
                    row.insertCell(6).innerHTML = "<span class='tdkd06'> <a onclick=\"tableDel('Tabcs')\" href='#'>[删]</a></span>";
                }
            }
        }
        function tableDel(Table) {

            var table = document.getElementById(Table);
            var rowIndex = event.srcElement.parentNode.parentNode.parentNode.rowIndex;
            table.deleteRow(rowIndex);
            TableText(Table);

        }
        function TableText(tab) {
            var text = "";
            var hidsk = document.getElementById("hidsk2").value;
            var table = document.getElementById(tab);
            for (var i = 1; i < table.rows.length; i++) {
                var cellstr = "";
                var str = "";
                cellstr += document.getElementById("txt_roomid").value + "#";
                for (var y = 0; y < table.rows[i].cells.length - 3; y++) {

                    if (y == "3") {
                        str += table.rows[i].cells[y].getElementsByTagName("select")[0].value;
                        cellstr += table.rows[i].cells[y].getElementsByTagName("select")[0].value + "#";
                    }
                    else if (y == "5") {

                        str += table.rows[i].cells[y].getElementsByTagName("INPUT")[0].value;
                        cellstr += table.rows[i].cells[y].getElementsByTagName("INPUT")[0].value;
                    }
                    else {

                        str += table.rows[i].cells[y].getElementsByTagName("INPUT")[0].value;
                        cellstr += table.rows[i].cells[y].getElementsByTagName("INPUT")[0].value + "#";

                    }

                }

                if (str != "")
                    text += cellstr + "|";

            }
            document.getElementById("hidSchool").value = text;
            text = "";

        }

        function BTncher(ids, type) {
            var btn = document.getElementById("btnBind")
            document.getElementById("txt_id").value = ids;
            document.getElementById("txt_type").value = type;
            btn.click();
        }
        $.ajaxSetup({
            async: false
        });
        function isFill() {
            var isb = true;
            var desp = 0;
            /*获得是否需要押金,需要多少*/
            $.get("/Admin/Ajax/SysPara.ashx?r=" + Math.random(), "type=GetYJ", function (obj) {
                isb = obj.statu;
                desp = obj.msg;
                var isValid = true;
                var title = document.getElementById("txt_name");
                var kffs = document.getElementById("DDlKffs");
                var yjMoney = document.getElementById("txt_yjmoney");
                if (title.value == "") {
                    alert('姓名不能为空');
                    isb = false;
                }
                if (isb) {
                    if (yjMoney.value == "") {
                        isb = false;
                        alert('押金不能为空');

                    }
                    else if (parseInt(yjMoney.value) < desp) {
                        isb = false;
                        alert("押金不能低于" + desp);

                    }
                }
            }, "json");
            return isb;
        }
        function isFills() {

            var isValid = true;
            var txtName = document.getElementById("txt_name");
            if (txtName.value == "") {
                alert('姓名不能为空');
                isValid = false;
            }

            return isValid;

        }
        function TAbles(obj) {
            var btnName = document.getElementById("btn_rooms").value;
            if (btnName == "终止开房") {
                document.getElementById("btnbur").click();
            }

        }
        function addRealNum(obj) {
            var parw = $(".numbers");
            parw.val(parseInt(parw.val()) + 1);

            addsDate();
        }

        function SaleRealNum(obj) {
            var parw = $(".numbers");
            parw.val(parseInt(parw.val()) - 1);
            if (parw.val() < 1) {
                alert("预定房数不能小于1");
                parw.val(1);
                return;
            }
            addsDate();
        }
        function ShowTabs(title) {
            // 关闭当前

            var jq = top.jQuery;
            var url = "/admin/Toroom/ToRoom.aspx";
            AddTabs(title, url);
            window.location.reload(true);
            if (jq('#tabs').tabs('exists', "房态图")) {
                var jq = top.jQuery;
                clo("房态图")
                jq('#tabs').tabs('add', {
                    title: title,
                    content: createFrame(url),
                    closable: true
                });
            }
            clos();
        }
        $(function () {

            $(".tr1").hover(function () {
                $(this).addClass("chover");

            }, function () {
                $(this).removeClass("chover");
            })

            $(".tr1").click(function () {
                $(".tr1").each(function () {
                    if ($(this).attr("bookno") == $("#hidid").val()) {
                        $(this).addClass("ches");
                    } else {
                        $(this).removeClass("ches");
                    }
                })

            })

        })
    </script>
    <style type="text/css">
        body .addyd
        {
            border: none;
            width: 100%;
            overflow: hidden;
        }
        .lr_box1 TR TD, #DivYXRoom TR TD
        {
            font-size: 12PX;
        }
         .chover
        {
            background: #4486b7;
        .ches{ background:Yellow;}
    </style>
    <script type="text/javascript">
       
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" runat="server" id="txtsort" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <ul class="addyd">
                <li>房 号：<input type="text" name="textfield" id="txt_roomid" onchange="TAbles(this)"
                    runat="server" /></li>
                <li>房&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 型：<asp:DropDownList ID="ddroomtype" DataTextField="room_name"
                    DataValueField="id" onchange="TAbles(this)" runat="server">
                </asp:DropDownList>
                </li>
                <li>房屋租金：<input type="text" name="textfield" id="txt_money"  runat="server" />
                </li>
                <li>收费周期：<asp:DropDownList ID="DDlsfzq" runat="server">
                    <asp:ListItem Value="0">一个月</asp:ListItem>
                    <asp:ListItem Value="2">二个月</asp:ListItem>
                    <asp:ListItem Value="3">三个月</asp:ListItem>
                </asp:DropDownList>
                </li>
            </ul>
            <ul class="addyd">
                <li class="kfrzts"><span>租赁周期：</span>
                    <p onclick="SaleRealNum(this)">
                        -</p>
                    <input type="text" id="txt_Day" class="numbers" runat="server" value="1" onchange="addsDate();TAbles(this)"
                        name="textfield" />
                    <p onclick="addRealNum(this)">
                        +</p>
                    <!--<li >
            入住天数:<span onclick="SaleRealNum(this)"  style="display:inline-block;box-sizing:border-box;font-size:18px;font-weight:bold;width:20px;line-height:26px;background:#f2f2f2">-</span>
            <span><input type="text" id="Text1" class="numbers" runat="server" value="1" onchange="addsDate();TAbles(this)" name="textfield"  style="float:left;width:50px"/></span>
            <span onclick="addRealNum(this)" style="display:inline-block;box-sizing:border-box;font-size:18px;font-weight:bold;line-height:20px;background:#f2f2f2">+</span>
            </li>-->
                    <li>起租日期：<input type="text" name="textfield" id="txt_rzdate" onclick="WdatePicker()"
                        runat="server" />
                    </li>
                    <li>截止日期：<input type="text" name="textfield" id="txt_ylDate" runat="server" onclick="WdatePicker()" />
                    </li>
                    <li>模&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;式：<asp:DropDownList runat="server"
                        ID="DDlKffs0">
                        <asp:ListItem Value="0">付一押一</asp:ListItem>
                        <asp:ListItem Value="2">付一押二</asp:ListItem>
                        <asp:ListItem Value="3">付一押三</asp:ListItem>
                    </asp:DropDownList>
                    </li>
            </ul>
            <!--灰色部分着重强调-->
            <div class="bggrayKF">
                <ul class="addyd">
                    <li>姓 名：<input type="text" name="textfield" id="txt_name" onchange="TAbles(this)"
                        runat="server" />
                    </li>
                    <li>性&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 别：<input type="text" name="textfield" id="txt_Sex"
                        onchange="TAbles(this)" runat="server" />
                    </li>
                    <li>出生年月：<input type="text" name="textfield" id="txt_Date2" onclick="WdatePicker()"
                        runat="server" />
                    </li>
                    <li>民&nbsp;&nbsp;&nbsp;&nbsp; 族：<input type="text" name="textfield" id="txt_mingzhu"
                        onchange="TAbles(this)" runat="server" />
                    </li>
                    <li>证件类型：<asp:DropDownList ID="DDlSFz" DataTextField="ct_name" onchange="TAbles(this)"
                        DataValueField="id" runat="server">
                    </asp:DropDownList>
                    </li>
                    <li>证件号码：<input type="text" name="textfield" id="txt_CardId" onchange="TAbles(this)"
                        runat="server" />
                    </li>
                    <li>联系电话：<input type="text" name="textfield" id="txt_lxphone" onchange="TAbles(this)"
                        runat="server" /></li>
                    <li>主房账号：<input type="text" name="textfield" id="txt_zfzhanghao" onchange="TAbles(this)"
                        runat="server" />
                    </li>
                    <li style="width: 100%; clear: left;">地 址：<input type="text" name="textfield" id="txt_address"
                        onchange="TAbles(this)" style="width: 508px;" runat="server" />
                    </li>
                </ul>
            </div>
            <!--左中右快速开房-->
            <div id="DivDisHidroom" runat="server" class="ksxf_list" style="display: none;">
                <div id="DivKXRoom" class="lr_box1" runat="server">
                </div>
                <ul class="m_box1">
                    <li>
                        <input type="button" value="连　房" class="orangeBtn midBtn" /></li>
                    <li>
                        <asp:Button class="orangeBtn midBtn" ID="btnyzAdds" runat="server" Text="添　加" OnClick="btnyzAdds_Click" /></li>
                    <li>
                        <asp:Button class="grayBtn midBtn" ID="Button1" runat="server" Text="移　除" OnClick="Button1_Click" />
                    </li>
                </ul>
                <div id="DivYXRoom" runat="server">
                    <table id="Tabyxfj" border="0" cellspacing="0" cellpadding="0">
                        <thead>
                            <tr>
                                <td>
                                    房号
                                </td>
                                <td>
                                    房型
                                </td>
                                <td>
                                    房价
                                </td>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <!--其他-->
            <ul class="addyd">
                <li>支付方式：<asp:DropDownList ID="DDlZffs" DataTextField="meth_pay_name" DataValueField="meth_pay_id"
                    runat="server">
                </asp:DropDownList>
                </li>
                <li>押 金：<input type="text" name="textfield" id="txt_yjmoney" runat="server" />
                </li>
                <li style="width: 100%; clear: left; overflow: hidden;">
                备 注：<textarea id="txt_Remaker" runat="server" rows="3" style="width: 748px; vertical-align: top"></textarea>
                </li>
            </ul>
            <!--定金结束-->
            <div class="kfMoreBtn">
                <asp:Button ID="btnAdds" runat="server" Text="开房" class="orangeBtn midBtn" OnClientClick="return isFill();"
                    OnClick="btnAdds_Click" />&nbsp;
                <input name="读取二代身份证" type="button" value="读取二代身份证" class="orangeBtn 120Btn" />
                <input name="联房开房" type="button" onclick="DivDisRoom()" runat="server" value="联房开房"
                    id="btn_rooms" class="greenBtn midBtn" />
                <input type="button" class="blueBtn" value="客人信息" onclick="CostAdds(this)" />
                <input id="guanbi" name="关　闭" type="button" value="关　闭" class="grayBtn midBtn" onclick="clos()" />
            </div>
            <!--按纽结束-->
            <p>
                <asp:Button ID="btnBind" runat="server" Text="Button" OnClientClick="if(isFills()){}else{return false;}"
                    OnClick="btnBind_Click" Style="display: none;" />
                <asp:Button ID="btnbur" runat="server" Text="失去焦点" OnClick="btnbur_Click" Style="display: none;" />
                <input type="hidden" id="txt_id" runat="server" />
                <input type="hidden" id="txt_CardesName" runat="server" />
                <asp:HiddenField ID="hidSchool" runat="server" />
                <asp:HiddenField ID="hidsk2" runat="server" />
                <asp:HiddenField ID="hidSuikeInfo" runat="server" />
                <input type="hidden" id="txt_Info" runat="server" />
                <input type="hidden" id="txt_type" runat="server" />
                <input type="hidden" id="txt_roomnumber" runat="server" />
                <input type="hidden" id="txt_zhi" runat="server" /></p>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnBind" />
            <asp:AsyncPostBackTrigger ControlID="btnAdds" />
        </Triggers>
    </asp:UpdatePanel>
    </form>
</body>
</html>
