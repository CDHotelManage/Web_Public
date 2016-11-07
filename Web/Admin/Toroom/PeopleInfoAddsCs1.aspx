<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="PeopleInfoAddsCs1.aspx.cs"
    Inherits="CdHotelManage.Web.Admin.Toroom.PeopleInfoAddsCs1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="../../easyui/jquery.min.js" type="text/javascript"></script>
    <script src="../../js/hDate.js" type="text/javascript"></script>
    <link href="../../style/css.css" rel="stylesheet" type="text/css" />
    <link href="../../style/hDate.css" rel="stylesheet" type="text/css" />
    <link href="../../style/Opendiv.css" rel="stylesheet" type="text/css" />
    <script src="../../js/DivWH.js" type="text/javascript"></script>
    <script src="../../calendar/WdatePicker.js" type="text/javascript"></script>
    <script src="../../easyui/jquery.easyui.min.js" type="text/javascript"></script>
    <link href="../../easyui/themes/gray/easyui.css" rel="stylesheet" type="text/css" />
    <script src="../js/base.js" type="text/javascript"></script>
    <script type="text/javascript">
        function clos() {
            // 关闭当前
            clo("入住信息");
        }

        function clos1() {
            // 关闭当前
            var jq = top.jQuery;
            var a = "在住房信息";
            var c = "修改在住房信息";
            var d = "加开房间";
            jq("#tabs").tabs("close", a);
            jq("#tabs").tabs("close", c);
            jq("#tabs").tabs("close", d);
        }
       
        function addss(obj) {
            document.getElementById("btnkffs").click();
        }


        function CloseTile(title) {
            clo(title);
        }
        function CostAdds(obj) {
            var ids = "";
            $("#tb_List tr").each(function () {
                ids += "'" + $(this).attr("roomnumber") + "'" + ","
            })
            ids = ids.substring(0, ids.length - 1);
            var roomid = document.getElementById("hidSuikeInfo").value;
            var url = "PeopleInfosk.aspx?id=" + ids + "&rooms=" + roomid;
            
            showMyWindow("客人信息", url, "1000", "450", true, true, true);
        }
        function DivDis(){
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
        function addsDate(){
            var txtNum = document.getElementById("txt_Day").value;
            if (txtNum == "") { document.getElementById("txt_ylDate").value = ""; }
            else if (txtNum == "0") {alert("最少为一天！");   document.getElementById("txt_Day").value = "1";addsDate(); }
            else {  
                if (!isNaN(txtNum)) {
                    document.getElementById("txt_ylDate").value = getNewDay(ydDate, parseInt(txtNum) - 1);
                } else {
                    alert("请输入正确天数!!");
                    document.getElementById("txt_Day").value = "1";
                }
            }
            VailTime();
        }

        function VailTime() {
            if ($("#retime").text() != "") {
                var startTime = $("#txt_ylDate").val();
                var start = new Date(startTime.replace("-", "/").replace("-", "/"));
                var endTime = $("#retime").text();
                var end = new Date(endTime.replace("-", "/").replace("-", "/"));
                if (end < start) {
                    alert("该房间该时段已预定!!");
                    document.getElementById("txt_Day").value = 1;
                    addsDate();
                    $("#btnAdds").css("background", "#ececec");
                    $("#btnAdds").attr("disabled", "true");
                }
                else {
                    $("#btnAdds").css("background", "#ff7f00");
                }
            }
        }

        function MarkCard(ids) {

            //  Window_Close();
            var objs = document.getElementById("btnAdds");
            var url = "makecard.aspx?orders=" + ids;
            showMyWindow("制卡", url, 450, 150, true, true, true, update);
        }

        function update() {
            Close();//
        }

        function AddDays(Num) {
            var ydDate = document.getElementById("txt_rzdate").value;
            var LSTR_ndate = new Date();
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
        //日期加上天数得到新的日期  
        //dateTemp 需要参加计算的日期，days要添加的天数，返回新的日期，日期格式：YYYY-MM-DD  
        function getNewDay(dateTemp, days) {
            var dateTemps = dateTemp.split(" ");
            var dateTemp = dateTemps[0].split("-");
            var nDate = new Date(dateTemp[1] + '-' + dateTemp[2] + '-' + dateTemp[0]); //转换为MM-DD-YYYY格式
            var millSeconds = Math.abs(nDate) + (days * 24 * 60 * 60 * 1000);
            var rDate = new Date(millSeconds);
            var year = rDate.getFullYear();
            var month = rDate.getMonth() + 1;
            if (month < 10) month = "0" + month;
            var date = rDate.getDate();
            if (date < 10) date = "0" + date;
            return (year + "-" + month + "-" + date + " " + dateTemps[1]);
        }
        function funAddTa(ta) {
            var txtName = document.getElementById("txt_CardesName").value;
            var table = document.getElementById(ta);
            var row = table.insertRow(table.rows.length);
            $(row).addClass("tr3");
            var bindcs = "<select><option>请选择</option>";
            var vcel = row.insertCell(0);
            vcel = row.insertCell(0);

            row.insertCell(0).innerHTML = "<input class='tdkd01'  name='textfield' style='width:60px;' type='text' />";
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
            })

        }

        function PrintRZ(obj, order_id) {
            var url = "/Admin/ShiftExc/OccupancySingle.aspx?orrderID=" + order_id + "&type=rz";
            showMyWindow("打印开房单", url, 400, 900, true, true, true, Close);
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
      
        
        function isFills() {

            var isValid = true;
            var txtName = document.getElementById("txt_name");
            if (txtName.value == "") {
                alert('姓名不能为空');
                isValid = false;
            }
            return isValid;
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
                var a = "房态图";
                jq("#tabs").tabs("close", a);
                jq('#tabs').tabs('add', {
                    title: title,
                    content: createFrame(url),
                    closable: true
                });

            }
            clos();
        }

        function disp(type) {
            if (type == 0) {
                document.getElementById("cap1").style.display = "block";

            } else {
                document.getElementById("cap1").style.display = "none";

            }

        }
        function saveToFile() {
            var LSTR_ndate = new Date();
            var MHS = " " + LSTR_ndate.getHours() + LSTR_ndate.getMinutes() + LSTR_ndate.getSeconds();
            var LSTR_Year = LSTR_ndate.getFullYear();
            var LSTR_Month = LSTR_ndate.getMonth();
            var LSTR_Date = LSTR_ndate.getDate();
            //得到最终结果 
            uom = LSTR_Year + LSTR_Month + LSTR_Date + MHS;
            var a = uom + ".jpg";
            var path = $("#txtpath").val();
            var File = path + "\Admin\\Images\\HeaderImg\\" + a;
            alert(File);
            document.getElementById('cap1').saveToFile(File); //可以尝试修改文件扩展名试试,如改成test.bmp
            $(".imgdiv").html("<img width='100px' height='100px' src='../Images/HeaderImg/" + a + "'>");
            document.getElementById("txt_img").value = "../Images/HeaderImg/" + a;
        }

        function AddDay() {
            var yltime = document.getElementById("txt_rzdate").value;
            var list = yltime.split(' ');
            var ydtime = document.getElementById("txt_ylDate").value;
            var list1 = ydtime.split(' ');
            document.getElementById("txt_Day").value = DateDiff(list[0], list1[0]);
            VailTime();
        }
        //两日期计算天数
        function DateDiff(sDate1, sDate2) {    //sDate1和sDate2是2006-12-18格式 
            var aDate, oDate1, oDate2, iDays
            aDate = sDate1.split("-")
            oDate1 = new Date(aDate[1] + '-' + aDate[2] + '-' + aDate[0])    //转换为12-18-2006格式
            aDate = sDate2.split("-")
            oDate2 = new Date(aDate[1] + '-' + aDate[2] + '-' + aDate[0])
            if (oDate1 > oDate2) {
                alert("预离时间不能小于入住时间!!");
                $("#txt_ylDate").val("");
            }
            iDays = parseInt(Math.abs(oDate1 - oDate2) / 1000 / 60 / 60 / 24)    //把相差的毫秒数转换为天数
            return iDays
        }
        $(function () {
            $(document).keydown(function (event) {
                //esc键
                if (event.keyCode == 38) {//shang

                    index--;
                    if (index < 0) {
                        index = $(".dio ul li").length;
                    }
                    $(".dio ul li").css("background", "#fff");
                    $(".dio ul li").eq(index).css("background", "#4410E9");
                }
                if (event.keyCode == 13) {
                    var names = $(".dio ul li").eq(index).attr("name");
                    var cardNo = $(".dio ul li").eq(index).attr("card");
                    $.post("/Admin/Ajax/Books.ashx", "type=getBind&typeName=" + names + "&carno=" + cardNo, function (objs) {
                        var listArrJson = eval("(" + objs + ")");
                        var tbList = listArrJson.data;
                        $("#txt_name").val(tbList[0].occ_name);
                        $("#DDlSFz").val(tbList[0].card_id);
                        $("#ddll_sex").val(tbList[0].sex);
                        $("#txt_Date2").val(tbList[0].brithday);
                        $("#txt_mingzhu").val(tbList[0].family_name);
                        $("#txt_CardId").val(tbList[0].card_no);
                        $("#txt_lxphone").val(tbList[0].phonenum);
                        $("#txt_address").val(tbList[0].address);
                    }, "text");
                    $(".dio").css("display", "none");
                }
                if (event.keyCode == 40) {//xia
                    if (b) { } else { index = -1; b = true; }
                    index++;
                    if (index > $(".dio ul li").length) {
                        index = 0;
                    }
                    $(".dio ul li").css("background", "#fff");
                    $(".dio ul li").eq(index).css("background", "#4410E9");

                }
            });
            $(".btnStark").click(function () {
                document.getElementById('cap1').start();
                disp(0);
            })
        })

        $('html,body').click(function (e) {
            if (e.target.id.indexOf("txt_name") == -1) {
                $(".dio").css("display", "none");
            }
        });

        $('html,body').click(function (e) {
            if (e.target.id.indexOf("txt_hycardId") == -1) {
                $(".ac_results").css("display", "none");
            }
        });
        
        function aa() {


            var txt_Number = $("#txt_name").val();
            $.post("/Admin/Ajax/Books.ashx?i=0", "type=getname&typeid=" + txt_Number, function (objs) {
                if (objs == "err") { $(".dio").css("display", "none"); }
                else {
                    $(".dio").css("display", "block");
                    var listArrJson = eval("(" + objs + ")");
                    var tbList = listArrJson.data;
                    var html = "";

                    for (var i = 0; i < tbList.length; i++) {
                        html += "<li  name=" + tbList[i].occ_name.trim() + " card=" + tbList[i].card_no + "> <span class='ys'>姓名：" + tbList[i].occ_name.trim() + "</span> &nbsp;<span class='ys2'>身份证：" + tbList[i].card_no + " </span> <span style=\"width:100px;\">入住次数：" + tbList[i].remark + "</span></li>";
                    }
                    $(".dio ul").html(html);
                    $(".dio li").click(function () {
                        //  var id = $(this).attr("id");
                        $(".dio").css("display", "none");
                        var names = $(this).attr("name");
                        var cardNo = $(this).attr("card");

                        $.post("/Admin/Ajax/Books.ashx", "type=getBind&typeName=" + names + "&carno=" + cardNo, function (objs) {
                            var listArrJson = eval("(" + objs + ")");
                            var tbList = listArrJson.data;
                            $("#txt_name").val(tbList[0].occ_name);
                            $("#DDlSFz").val(tbList[0].card_id);
                            $("#ddll_sex").val(tbList[0].sex);
                            $("#txt_Date2").val(tbList[0].brithday);
                            $("#txt_mingzhu").val(tbList[0].family_name);
                            $("#txt_CardId").val(tbList[0].card_no);
                            $("#txt_lxphone").val(tbList[0].phonenum);
                            $("#txt_address").val(tbList[0].address);
                        }, "text");

                        
                        //$("#txt_name").focus();
                        Baocun();

                    })
                }
            }, "text");
            }
            function Occerr() {
                alert("该主房已开，请重新选择！！");
                var jq = top.jQuery;
                var currTab = jq('#tabs').tabs('getSelected');
                jq('#tabs').tabs('close','在住房信息');
            }
            var ydDate;
            //页面加载完成事件
            $(function () {
                ydDate = $("#txt_ylDate").val();
                LoadInput();
                BookToRz();
                BindZK();
                if ($("#customer").val() != "") {//修改的时候。如果有协议单位。直接改图片为X
                    $("#imgicos").attr("src", "../images/clear.jpg");
                }
            })
            function Gz(obj) {
                var url = "/admin/Toroom/GZlist.aspx";
                if (document.getElementById("guazhangs").value != "") {
                    url = "/admin/Toroom/GZlist.aspx?orderid=" + document.getElementById("guazhangs").value;
                }


                showMyWindow("挂帐", url, "1000", "350", true, true, true);
            }
            function BindZK() {
                $("#DDLfjfa").change(function () {
                    Zjfan(); //重新计算折后价格
                })
            }

            //为文本框赋值
            function LoadInput() {
                Zjfan();//绑定折后价格
                BindNav(); //绑定民族
                //绑定开房方式改变事件
                $("#DDlKffs").change(function () {
                    GetKffsSe();
                })
               
                //钟点房方案改变事件
                $("#ZD_hourse").change(function () {
                    ZdfPrice();
                })
                if ($("#type").val() == "yuding") {//如果是预定转入住
                    var startTime1 = $("#txt_ylDate").val();
                    var start1 = new Date(startTime1.replace("-", "/").replace("-", "/"));
                    var endTime1 = $("#txt_rzdate").val();
                    var end1 = new Date(endTime1.replace("-", "/").replace("-", "/"));
                    var data3 = start1.getTime() - end1.getTime();
                    var s = parseInt(data3 / (1000 * 60 * 60 * 24));
                    $("#txt_Day").val(s);
                    ydDate = $("#ylDate").val();
                    if ($("#inpText").val() != "") {
                        $("#tb_List").html($("#inpText").val()); //得到预定的房间详情信息
                        var txt = $("#DDlKffs option:checked").text();
                        var ykroom = "";
                        var onetr = "";
                        $("#tb_List tr").each(function () {
                            ykroom += "'" + $(this).attr("roomnumber") + "',";
                            //绑定已先房间
                            onetr += "<tr onclick='BTncher(0,0,this)'><td style=' width:62px;'>" + $(this).find(".txt_roomid").text() + "</td><td style='width:230px;'>" + $(this).find(".ddroomtype").text() + "</td><td  style='width:70px;'>" + $(this).find(".txt_moneys").text() + "</td></tr>";
                        })
                        $("#DivYXRoom #yxtable").html(onetr);
                        //绑定事件
                        $('#yxtable tr').unbind('dblclick');
                        $("#yxtable tr").dblclick(function () {
                            $("#DivKXRoom tr").removeClass("cbox");
                            $("#yxtable tr").removeClass("cbox");
                            $(this).addClass("cbox");
                            if ($(this).find("td").eq(0).text() == $("#txt_zfzhanghao").val()) {
                                alert("该房为主房,不能移除!!");
                            }
                            else {
                                RemvoeRoom();
                            }
                        })
                        ykroom = ykroom.substring(0, ykroom.length - 1);
                        $.get("/admin/Ajax/Books.ashx", "type=getFx&txt=" + txt + "&yk=" + ykroom, function (obj) {
                            if (obj != "") {

                                $("#DivKXRoom").html(obj);
                            }
                        }, "text");
                        Select($("#yxtable tr").eq(0).find("td").eq(0).text()); //还原
                    }
                }
                else if ($("#kftype").val() == "加开") {
                DivDisRoom();
                }
                else {
                    //保存一行
                    Baocun();
                }

            }
            //根据开房方式来显示对应的文本框。
            function GetKffsSe() {
                var txt = $("#DDlKffs option:checked").text();
                $("#fangan").css("display", "none");
                $("#moshi").css("display", "none");
                $("#listSfrq").css("display", "none");

                /*首先通过会员卡号计算*/
                var memid = $("#txt_hycardId").val();
                var kffs = $("#DDlKffs").val();
                if (txt == "钟点房") {
                    var id = $("#ddroomtype").val();
                    $.get("/Admin/Ajax/SysPara.ashx?r=" + Math.random(), "type=getfa&typeid=" + id + "&memid=" + memid + "&kffs="+kffs, function (obj) {
                        if (obj.statu == "ok") {
                            $("#txt_Day").val("0");
                            $("#fangan").css("display", "block");
                            var data = obj.data;
                            var options = "";
                            for (var i = 0; i < data.length; i++) {
                                if ($("#txtsort").val() == data[i].id) {
                                    options += "<option selected=\"selected\" hs_start_long=\"" + data[i].hs_start_long + "\"  hs_start_price=\"" + data[i].hs_start_price + "\" value=\"" + data[i].id + "\">" + data[i].hs_name + "</option>";
                                }
                                else {
                                    options += "<option hs_start_long=\"" + data[i].hs_start_long + "\"  hs_start_price=\"" + data[i].hs_start_price + "\" value=\"" + data[i].id + "\">" + data[i].hs_name + "</option>";
                                }
                            }
                            $("#fangan #ZD_hourse").html(options);
                            ZdfPrice(); //更新房价
                        }
                        else if (obj.statu == "err") {
                            alert(obj.msg);
                            $("#DDlKffs").val(1);
                        }
                    }, "json");
                }
                else if (txt == "月租房") {
                    if ($("#txt_Day").val() == "0") {
                        $("#txt_Day").val("1");
                    }
                    $("#txt_Day").val("30");
                    var id = $("#ddroomtype").val();
                    $("#moshi").css("display", "block");
                    $("#listSfrq").css("display", "block");

                    $.get("/Admin/Ajax/SysPara.ashx?r=" + Math.random(), "type=getyzf&typeid=" + id + "&memid=" + memid + "&kffs=" + kffs, function (obj) {
                        $("#txt_money").val(obj);
                        $("#txt_moneys").val(obj);
                    }, "text");
                }
                else if (txt == "天房") {
                    if ($("#txt_Day").val() == "0") {
                        $("#txt_Day").val("1");
                    }
                    $("#txt_Day").val("1");
                    var id = $("#ddroomtype").val();
                    $.get("/Admin/Ajax/SysPara.ashx?r=" + Math.random(), "type=gettf&typeid=" + id + "&memid=" + memid + "&kffs=" + kffs, function (obj) {
                        if ($("#txt_hycardId").val() == "") {
                            $("#txt_moneys").val(obj);
                        }
                        else {
                            $("#txt_money").val(obj);
                        }
                    }, "text");

                }
                else if (txt == "凌晨房") {
                    if ($("#txt_Day").val() == "0") {
                        $("#txt_Day").val("1");
                    }
                    $("#txt_Day").val("1");
                    var id = $("#ddroomtype").val();
                    $.get("/Admin/Ajax/SysPara.ashx?r=" + Math.random(), "type=getlcf&typeid=" + id + "&memid=" + memid + "&kffs=" + kffs, function (obj) {
                        if ($("#txt_hycardId").val() == "") {
                            $("#txt_moneys").val(obj);
                        }
                        else {
                            $("#txt_money").val(obj);
                        }
                    }, "text");
                }
                else if (txt == "免费房") {
                    if ($("#txt_Day").val() == "0") {
                        $("#txt_Day").val("1");
                    }
                    $("#txt_Day").val("1");
                    var id = $("#ddroomtype").val();
                    $.get("/Admin/Ajax/SysPara.ashx?r=" + Math.random(), "type=gettf&typeid=" + id + "&memid=" + memid + "&kffs=" + kffs, function (obj) {
                        $("#txt_moneys").val(obj);
                    }, "text");
                }
                else {
                    $("#txt_moneys").val(zqqian);
                    $("#txt_ylDate").val(zqtime);
                }
                YlTimeLoad();
                if ($("#txt_hycardId").val()==""){
                   Zjfan(); //重新计算折后价格
                }
                Baocun();

                GetKxRoom(txt);
                if ($("#yxtable .cbox").length > 0) {
                    $("#yxtable .cbox").eq(0).find("td").eq(2).text($("#txt_moneys").val());
                }
            }

            //重新计算离开时间
            function YlTimeLoad() {
                var roomType = $("#ddroomtype").val(); //房型
                var day = $("#txt_Day").val();
                var txt = $("#DDlKffs option:checked").text();
                var rztime = $("#txt_rzdate").val();
                if (txt!= "钟点房") {
                    $.get("/Admin/Ajax/SysPara.ashx?r=" + Math.random(), "type=getyl&roomType=" + roomType + "&day=" + day + "&txt=" + txt + "&rztime=" + rztime, function (obj) {
                        $("#txt_ylDate").val(obj);
                    }, "text");
                }
            }
            $.ajaxSetup({
                async: false
            });

            //根据房价方案和价格获折后价格
            function Zjfan() {
                var txt = $("#DDlKffs option:checked").text();
                if ($("#CpId").val() == "" || txt=="凌晨房" || txt=="免费房" || txt=="钟点房") {
                    var fjfas = $("#DDLfjfa").val();
                    var fjfa = 1;
                    $.get("/admin/Ajax/GoodsAcce.ashx", "type=getFA&id=" + fjfas, function (obj) {
                        fjfa = obj;
                    }, "text");
                    var hs_start_price = $("#txt_moneys").val();
                    if ($("#DDlKffs option:checked").text() == "免费房") {
                        $("#txt_money").val(0);
                    }
                    else if ($("#DDlKffs option:checked").text() == "天房") {
                        $.get("/admin/Ajax/GoodsAcce.ashx", "type=getFA1&id=" + fjfas, function (obj) {
                            $("#txt_money").val(obj);
                        }, "text");
                    }
                    else {
                        $("#txt_money").val(hs_start_price * fjfa);
                    }
                }
                else { //如果是协议单位
                    var cpid = $("#CpId").val();
                    var typeid = $("#ddroomtype").val();
                    $.get("/admin/Ajax/Member.ashx", "type=getPrice&cpid=" + cpid + "&typeid=" + typeid, function (obj) {
                        if (obj.statu == "ok") {
                            var tblist = obj.data;
                            $("#txt_moneys").val(tblist[0].Price); //房价
                            $("#txt_money").val(tblist[0].protoPrice); //折扣价
                        }
                        else if (obj.statu == "err") {
                            $("#txt_moneys").val(obj.data.Price); //房价
                            $("#txt_money").val(obj.data.protoPrice); //折扣价
                        }
                    }, "json");
                }
            }

            //绑定民族
            function BindNav() {
                var national = ["汉族", "壮族", "满族", "回族", "苗族", "维吾尔族", "土家族", "彝族", "蒙古族", "藏族", "布依族", "侗族", "瑶族", "朝鲜族", "白族", "哈尼族", "哈萨克族", "黎族", "傣族", "畲族", "傈僳族", "仡佬族", "东乡族", "高山族", "拉祜族", "水族", "佤族", "纳西族", "羌族", "土族", "仫佬族", "锡伯族", "柯尔克孜族", "达斡尔族", "景颇族", "毛南族", "撒拉族", "布朗族", "塔吉克族", "阿昌族", "普米族", "鄂温克族", "怒族", "京族", "基诺族", "德昂族", "保安族", "俄罗斯族", "裕固族", "乌孜别克族", "门巴族", "鄂伦春族", "独龙族", "塔塔尔族", "赫哲族", "珞巴族"];
                var nat = document.getElementById("national");
                for (var i = 0; i < national.length; i++) {
                    var option = document.createElement('option');
                    option.value = i;
                    var txt = document.createTextNode(national[i]);
                    option.appendChild(txt);
                    nat.appendChild(option);
                }
                nat.onchange = function () {
                    var txt = document.getElementById("national").options[window.document.getElementById("national").selectedIndex].text;
                    $("#txt_mingzhu").val(txt);
                }
            }

            //根据选择的的钟点房方案改变价格
            function ZdfPrice() {
                var hs_start_long = $("#ZD_hourse").find("option:checked").attr("hs_start_long");
                var hs_start_price = $("#ZD_hourse").find("option:checked").attr("hs_start_price");
                $("#txtsort").val($("#ZD_hourse").find("option:checked").attr("value"));
                $("#txt_moneys").val(hs_start_price);
                $("#txt_price").val($("#txt_moneys").val());

                Zjfan();
                $.get("/Admin/Ajax/SysPara.ashx?r=" + Math.random(), "type=gettime&time=" + hs_start_long, function (obj) {
                    $("#txt_ylDate").val(obj);
                }, "text");
            }

            //联房点击
            function DivDisRoom() {
                var Div = document.getElementById("DivDisHidroom");
                var hidd = document.getElementById("btn_rooms");

                if (hidd.value == "联房开房") {
                    hidd.value = "终止开房";
                    Div.style.display = "block";
                    //   window.location.reload();
                    var txt = $("#DDlKffs option:checked").text();
                    if ($("#DivKXRoom tr").length <= 0) {
                        GetKxRoom(txt);
                    }
                    if ($("#kftype").val() == "加开") {
                    }
                    else if ($("#DivYXRoom tr").length <= 0 && $("#kftype").val() != "加开") {
                        var ontblist = $("#tb_List tr").eq(0);
                        var onetr = "<tr class=\"cbox\" onclick='BTncher(0,0,this)'><td style=' width:62px;'>" + ontblist.find(".txt_roomid").text() + "</td><td style='width:230px;'>" + $("#ddroomtype option:selected").text() + "</td><td  style='width:70px;'>" + ontblist.find(".txt_moneys").text() + "</td></tr>";
                        $("#DivYXRoom #yxtable").html(onetr);
                        $('#yxtable tr').unbind('dblclick');
                        $("#yxtable tr").dblclick(function () {
                            $("#DivKXRoom tr").removeClass("cbox");
                            $("#yxtable tr").removeClass("cbox");
                            $(this).addClass("cbox");
                            if ($(this).find("td").eq(0).text() == $("#txt_zfzhanghao").val()) {
                                alert("该房为主房,不能移除!!");
                            }
                            else {
                                RemvoeRoom();
                            }
                        })
                    }
                    
                } else {
                    hidd.value = "联房开房";
                    Div.style.display = "none";
                }
            }
            var newTr;
            //添加
            function AddRoom() {
                var bxo = $("#DivKXRoom .cbox");
                if (bxo.length > 0) { //如果有选中的话
                    Baocun();
                    bxo.remove();
                    newTr = "<tr class=\"cbox\"  onclick='BTncher(0,0,this)'><td style=' width:62px;'>" + bxo.find("td").eq(0).text() + "</td><td style='width:230px;'>" + bxo.find("td").eq(1).text() + "</td><td  style='width:70px;'>" + bxo.find("td").eq(2).text() + "</td></tr>";
                    //如果预定转入住的时间没有一个房间的话
                    if ($("#yxtable tr").length <= 0 && $("#txt_zfzhanghao").val()=="") {
                        $("#yxtable").html(newTr);
                        $("#txt_zfzhanghao").val(bxo.find("td").eq(0).text());//添加后绑定主房账号
                    }
                    else {
                        if ($("#yxtable tr").length <= 0 && $("#txt_zfzhanghao").val() != "") {
                            $("#yxtable").html(newTr);
                        }
                        else {
                            $("#yxtable tr").eq($("#yxtable tr").length - 1).after(newTr);
                        }
                    }
                    newTr = "";
                    $('#yxtable tr').unbind('dblclick');
                    $("#yxtable tr").dblclick(function () {
                        $("#DivKXRoom tr").removeClass("cbox");
                        $("#yxtable tr").removeClass("cbox");
                        $(this).addClass("cbox");
                        if ($(this).find("td").eq(0).text() == $("#txt_zfzhanghao").val()) {
                            alert("该房为主房,不能移除!!");
                        }
                        else {
                            RemvoeRoom();
                        }
                    })
                }
                else {
                    alert("请选择房间！然后在点击添加！！");
                }
          }

          //移除
          function RemvoeRoom() {
              
              var box = $("#yxtable").find(".cbox");
              if (box.length > 0) {
                  if (box.find("td").eq(0).text() == $("#txt_zfzhanghao").val()) {
                      alert("该房为主房,不能移除!!");
                   }
                  else {
                      $("#tb_List tr[roomnumber=" + box.find("td").eq(0).text() + "]").remove();
                      box.remove();
                      newTr = "<tr class=\"cbox\"  onclick='BTncher(0,1,this)'><td style=' width:70px;'>" + box.find("td").eq(0).text() + "</td><td style='width:260px;'>" + box.find("td").eq(1).text() + "</td><td  style='width:70px;'>" + box.find("td").eq(2).text() + "</td></tr>";
                      $("#DivKXRoom tr").eq(0).after(newTr);
                      newTr = "";
                      $('#DivKXRoom tr').unbind('dblclick');
                      $("#DivKXRoom tr").dblclick(function () {
                          $("#DivKXRoom tr").removeClass("cbox");
                          $("#yxtable tr").removeClass("cbox");
                          $(this).addClass("cbox");
                          AddRoom();
                      })
                  }
              }
              else {
                  alert("请选择需要移除的房间！");
              }
          }

            //双击添加
            function dbToAdd(obj) {
                $("#DivKXRoom tr").removeClass("cbox");
                $("#yxtable tr").removeClass("cbox");
                $(obj).addClass("cbox");
                AddRoom();
            }

            function GetKxRoom(txt) {
                var ykroom = $("#txt_roomid").val();
                ykroom = "'" + ykroom + "'";
                $.get("/admin/Ajax/Books.ashx", "type=getFx&txt=" + txt + "&yk=" + ykroom, function (obj) {
                    if (obj != "") {
                        $("#DivKXRoom").html(obj);
                    }
                }, "text");
            }
            //失去焦点修改
            function TAbles(obj) {
                var id = $(obj).attr("id");//得到ID
                var vs = $(obj).val(); //得到值
//                if ($("#yxtable .cbox").length > 0) {
//                    var number = $("#yxtable .cbox").find("td").eq(0).text();
//                    $("#tb_List tr[roomnumber=" + number + "]").find("." + id).text(vs);
                //                                }
                Baocun();
                
               
            }

            function BindDDLfjfa() {
                $.get("/Admin/Ajax/Books.ashx", "type=updateFjfa", function (obj) {
                
                 }, "text");
            }

            function BTncher(ids, type, obj) {
            if (!$("#txt_name").val()=="") {
                    $("#DivKXRoom tr").removeClass("cbox");
                    $("#yxtable tr").removeClass("cbox");
                    $(obj).addClass("cbox");
                    if (type == 1) { //点击可选房间
                        $("#fangan").css("display", "none");
                        $("#moshi").css("display", "none");
                        $("#listSfrq").css("display", "none");
                        $("#txt_roomid").val($(obj).find("td").eq(0).text());
                        $("#ddroomtype option:contains('" + $(obj).find("td").eq(1).text() + "')").attr("selected", "selected");
                        $("#DDlKffs option:contains('天房')").attr("selected", "selected");
                        $("#txt_moneys").val($(obj).find("td").eq(2).text());

                        Zjfan(); //重新计算折后价格

                    }
                    else if (type == 0) { //点击已选房间
                        Select($(obj).find("td").eq(0).text()); //还原
                        GetKffsSe();
                        Select($(obj).find("td").eq(0).text()); //还原
                    }
                }
                else {
                    alert("姓名不能为空!!!");
                }
            }
           
            //开房验证
            function isFill() {
                var isb = true;
                var contents = "";
                var guazhangs = $("#guazhangs").val(); //如果有挂帐目标就可以不输入押金
                if ($("#kftype").val() != "加开" && guazhangs == "" && $("#accounts").val()=="") {
                    $.ajaxSetup({
                        async: false
                    });
                    var desp = 0;
                    /*获得是否需要押金,需要多少*/
                    $.get("/Admin/Ajax/SysPara.ashx?r=" + Math.random(), "type=GetYJ", function (obj) {
                        var isValid = obj.statu;
                        desp = obj.msg;
                        var title = document.getElementById("txt_name");
                        var kffs = document.getElementById("DDlKffs");
                        var yjMoney = document.getElementById("txt_yjmoney");
                        var txt_ylDate = document.getElementById("txt_ylDate");
                        if (title.value == "") {
                            alert('姓名不能为空');
                            //isb = false;
                            isb = false;
                        }
                        if (txt_ylDate.value == "") {
                            alert('预离时间不能为空！');
                            isb = false;
                        }
                        if (isValid != "False") {
                            if (yjMoney.value == "") {
                                alert('押金不能为空');
                                isb = false;
                            }
                            if (parseInt(yjMoney.value) < desp) {
                                isb = false;
                                alert("押金不能低于" + desp);
                            }
                        }
                    }, "json");
                    if ($("#txt_hycardId").val() != "") {
                        $.get("/admin/ajax/Member.ashx", "type=isok&num=" + $("#txt_hycardId").val(), function (obj) {
                            if (obj == "ok") {

                            }
                            else {
                                alert("该会员不存在！");
                                isb = false;
                            }
                        }, "text");
                    }
                }
                if (isb) {
                    //遍历生成的已先表格
                    $("#tb_List tr").each(function () {
                        contents += $(this).find(".txt_roomid").text() + "#" + $(this).find(".ddroomtype").text() + "#" + $(this).find(".DDlkrly").text() + "#" + $(this).find(".DDLfjfa").text() + "#" + $(this).find(".txt_money").text() + "#" + $(this).find(".isok").text() + "#" + $(this).find(".DDlKffs").text() + "#" + $(this).find(".txt_rzdate").text() + "#" + $(this).find(".txt_Day").text() + "#" + $(this).find(".txt_ylDate").text() + "#" + $(this).find(".txt_name").text() + "#" + $(this).find(".ddll_sex").text() + "#" + $(this).find(".txt_Date2").text() + "#" + $(this).find(".txt_mingzhu").text() + "#" + $(this).find(".DDlSFz").text() + "#" + $(this).find(".txt_CardId").text() + "#" + $(this).find(".txt_hycardId").text() + "#" + $(this).find(".txt_Remaker").text() + "#" + $(this).find(".DDlZffs").text() + "#" + $(this).find(".txt_address").text() + "#" + $(this).find(".txt_zfzhanghao").text() + "#" + $(this).find(".txt_lxphone").text() + "#" + $(this).find(".DDlmoshi").text() + "#" + $(this).find(".txt_sfr").text() + "#" + $(this).find(".txt_img").text() + "#" + $(this).find(".ZD_hourse").text() + "#" + $(this).find(".txt_moneys").text() + "|";
                    })
                    $("#contents1").val(contents);
                    if ($("#txt_hycard").val() == "") {
                        var desp = $("#txt_yjmoney").val();
                        var url = "SetPwd.aspx?mid=" + $("#txt_hycardId").val();
                        showMyWindow("输入会员密码", url, 310, 120, true, true, true, LoadForm);
                        return false;
                    }
                }
                return isb;
               
            }


            function LoadForm() { 
              
            }

            //时间到了。是否转入住
            function BookToRz() {
                var startTime = $("#txt_rzdate").val();
                var start = new Date(startTime.replace("-", "/").replace("-", "/"));
                var endTime = $("#retime").text();
                var end = new Date(endTime.replace("-", "/").replace("-", "/"));

                if (start > end) {
                    if (confirm("已到预定时间，是否转入住?")) {
                        $("#isOk").val(1);
                        var room = $("#txt_roomid").val();
                        $.get("/Admin/Ajax/Books.ashx?r=" + Math.random(), "type=getRoom&roomNumber=" + room, function (obj) {
                            var url = obj;
                            AddTabs("在住房信息", url);

                        }, "text");
                    }
                    else {
                        $("#isOk").val(0);
                    }
                }

                VailTime();
            }
            /*赋值已选择房间*/
            function Select(room) {
                $("#tb_List tr").each(function () {
                    if ($(this).attr("roomnumber") == room) {
                        //rowdr = $(this);//少 
                        $("#txt_roomid").val($(this).find(".txt_roomid").text());
                        $("#ddroomtype").val($(this).find(".ddroomtype").text());
                        $("#DDlkrly").val($(this).find(".DDlkrly").text());
                        $("#DDLfjfa").val($(this).find(".DDLfjfa").text());
                        $("#txt_money").val($(this).find(".txt_money").text());
                        $("#isok").val($(this).find(".isok").text());
                        $("#DDlKffs").val($(this).find(".DDlKffs").text());
                        $("#txt_rzdate").val($(this).find(".txt_rzdate").text());
                        $("#txt_Day").val($(this).find(".txt_Day").text());
                        $("#txt_ylDate").val($(this).find(".txt_ylDate").text());
                        $("#txt_name").val($(this).find(".txt_name").text());
                        $("#ddll_sex").val($(this).find(".ddll_sex").text());
                        $("#txt_Date2").val($(this).find(".txt_Date2").text());
                        $("#txt_mingzhu").val($(this).find(".txt_mingzhu").text());
                        $("#DDlSFz").val($(this).find(".DDlSFz").text());
                        $("#txt_CardId").val($(this).find(".txt_CardId").text());
                        $("#txt_hycardId").val($(this).find(".txt_hycardId").text());
                        $("#txt_Remaker").val($(this).find(".txt_Remaker").text());
                        $("#DDlZffs").val($(this).find(".DDlZffs").text());
                        $("#txt_address").val($(this).find(".txt_address").text());
                        $("#txt_zfzhanghao").val($(this).find(".txt_zfzhanghao").text());
                        $("#txt_lxphone").val($(this).find(".txt_lxphone").text());
                        $("#DDlmoshi").val($(this).find(".DDlmoshi").text());
                        $("#txt_sfr").val($(this).find(".txt_sfr").text());
                        $("#txt_img").val($(this).find(".txt_img").text());
                        $("#ZD_hourse").val($(this).find(".ZD_hourse").text());
                        $("#txt_moneys").val($(this).find(".txt_moneys").text());
                    }
                })
            }

            function Baocun() {
                var txt_roomid = $("#txt_roomid").val(); //房号1
                if (txt_roomid.trim() != "") {
                    var ddroomtype = $("#ddroomtype").val(); //房型2
                    var DDlkrly = $("#DDlkrly").val(); //来源3
                    var DDLfjfa = $("#DDLfjfa").val(); //房价方案4
                    var txt_money = $("#txt_money").val(); //折后价格5
                    var isok = "否"; //否6
                    var DDlKffs = $("#DDlKffs").val(); //开房方式7
                    var txt_rzdate = $("#txt_rzdate").val(); //入住时间8
                    var txt_Day = $("#txt_Day").val(); //入住天数9
                    var txt_ylDate = $("#txt_ylDate").val(); //预离时间10
                    var txt_name = $("#txt_name").val(); //姓名11
                    var ddll_sex = $("#ddll_sex").val(); //性别12
                    var txt_Date2 = $("#txt_Date2").val(); //出生年月  13  
                    var txt_mingzhu = $("#txt_mingzhu").val(); //民族14
                    var DDlSFz = $("#DDlSFz").val(); //证件类型15
                    var txt_CardId = $("#txt_CardId").val(); ////证件号码16
                    var txt_hycardId = $("#txt_hycardId").val(); //会员卡号17
                    var txt_Remaker = $("#txt_Remaker").val(); //备注18
                    var DDlZffs = $("#DDlZffs").val(); //支付方式19
                    var txt_address = $("#txt_address").val(); //地址20
                    var txt_zfzhanghao = $("#txt_zfzhanghao").val(); //主房账号21
                    var txt_lxphone = $("#txt_lxphone").val(); //联系电话22
                    var DDlmoshi = $("#DDlmoshi").val(); //模式23
                    var txt_sfr = $("#txt_sfr").val(); //几号24
                    var txt_img = $("#txt_img").val(); //头像25
                    var ZD_hourse = $("#ZD_hourse").val(); //钟点房方案26
                    var txt_moneys = $("#txt_moneys").val(); //折后价格27

                    var delist = "<tr roomnumber=\"" + txt_roomid + "\"><td class=\"txt_roomid\">" + txt_roomid + "</td><td class=\"ddroomtype\">" + ddroomtype + "</td><td class=\"DDlkrly\">" + DDlkrly + "</td><td class=\"DDLfjfa\">" + DDLfjfa + "</td><td class=\"txt_money\">" + txt_money + "</td><td class=\"isok\">" + isok + "</td><td class=\"DDlKffs\">" + DDlKffs + "</td><td class=\"txt_rzdate\">" + txt_rzdate + "</td><td class=\"txt_Day\">" + txt_Day + "</td><td class=\"txt_ylDate\">" + txt_ylDate + "</td><td class=\"txt_name\">" + txt_name + "</td><td class=\"ddll_sex\">" + ddll_sex + "</td><td class=\"txt_Date2\">" + txt_Date2 + "</td><td class=\"txt_mingzhu\">" + txt_mingzhu + "</td><td class=\"DDlSFz\">" + DDlSFz + "</td><td class=\"txt_CardId\">" + txt_CardId + "</td><td class=\"txt_hycardId\">" + txt_hycardId + "</td><td class=\"txt_Remaker\">" + txt_Remaker + "</td><td class=\"DDlZffs\">" + DDlZffs + "</td><td class=\"txt_address\">" + txt_address + "</td><td class=\"txt_zfzhanghao\">" + txt_zfzhanghao + "</td><td class=\"txt_lxphone\">" + txt_lxphone + "</td><td class=\"DDlmoshi\">" + DDlmoshi + "</td><td class=\"txt_sfr\">" + txt_sfr + "</td><td class=\"txt_img\">" + txt_img + "</td><td class=\"ZD_hourse\">" + ZD_hourse + "</td><td class=\"txt_moneys\">" + txt_moneys + "</td></tr>";
                    if ($("#tb_List tr").length > 0) {
                        $("#tb_List tr").each(function () {
                            if ($(this).attr("roomnumber") == txt_roomid) {
                                $(this).remove();
                            }
                        })
                        if ($("#tb_List tr").length > 0) {
                            $("#tb_List tr").eq($("#tb_List tr").length - 1).after(delist);
                        }
                        else {
                            $("#tb_List").html(delist);
                        }
                    }
                    else {
                        $("#tb_List").html(delist);
                    } 
                }
            }





            function KC() {
                var where = $("#txt_hycardId").val();
                GetListNum(where);
            }

            function GetListNum(where) {
                $(".ac_results").css("display", "block");
                $.get("/admin/ajax/Member.ashx", "type=getallm&where=" + where, function (obj) {
                    if (obj.statu == "err") {
                        $(".ac_results").css("display", "none");
                        $("#txt_name").val("");
                        $("#ddll_sex").val("");
                        $("#txt_Date2").val("");
                        $("#txt_CardId").val("");
                        $("#txt_lxphone").val("");
                        $("#txt_address").val("");
                        $("#yst").css("display", "none");
                        $("#sumyue").text("");
                        $("#sumjf").text("");
                        $("#txt_hycard").val("");
                        $("#yst").css("display", "none");
                        //$("#DDlZffs option[text='储值卡']").remove();
                        $("#DDlZffs option").each(function () {
                            if ($(this).text() == "储值卡") {
                                $(this).remove();
                            }
                        })
                        $("#txt_hycard").val("1");
                    }
                    else if (obj.statu == "ok") {

                        var tblist = obj.data;
                        var html = ""
                        for (var i = 0; i < tblist.length; i++) {
                            html += "<li ><span style=\"width: 150px; display: inline-block\">卡号：<span class='mid'>" + tblist[i].Mid + "</span></span><span style=\"width: 150px; display: inline-block\">手机：" + tblist[i].Phone + "</span><span style=\"width: 70px;display: inline-block\">" + GetTypeName(tblist[i].Mtype) + "<strong></strong></li>";
                        }
                        $(".ac_results ul").html(html);
                        $(".ac_results").css("border", "1px solid black");
                        $("#txt_hycard").val("");
                        BindValue();
                    }

                    if (obj.msg == "0") {
                        $("#DDlZffs option").each(function () {
                            if ($(this).text() == "储值卡") {
                                $(this).remove();
                            }
                        })
                        $("#txt_hycard").val("1");
                    }
                    else if (parseInt(obj.msg) > 0) {
                        AddItem(); //如果有这个会员就添加储值卡支付选择
                        $("#txt_hycard").val("");
                    }
                }, "json")
            }


            function BindValue() {
                $(".ac_results ul li").click(function () {
                    var mid = $(this).find(".mid").text();
                    $("#mid").val(mid);
                    $("#txt_hycardId").val(mid);
                    $.get("/admin/ajax/Member.ashx", "type=getvalue&mid=" + mid, function (obj) {
                        $("#txt_name").val(obj.name);
                        if (obj.Sex == "false") {
                            obj.Sex = "男";
                        }
                        else {
                            obj.Sex = "女";
                        }
                        $("#ddll_sex").val(obj.Sex);
                        $("#txt_Date2").val(obj.Baithday);
                        $("#DDlSFz").find("option").each(function () {
                            if ($(this).text() == obj.zj) {
                                $("#DDlSFz").val($(this).val());
                            }
                        })

                        $("#txt_CardId").val(obj.ZjNumber);
                        $("#txt_lxphone").val(obj.Phone);
                        $("#txt_address").val(obj.Address);
                        $("#yst").css("display", "inline-table");
                        $("#sumyue").text(obj.czyue);
                        $("#sumjf").text(obj.shengyu);
                        $("#txt_hycard").val("");
                    }, "json");
                    $(".ac_results").css("display", "none");
                    GetKffsSe();
                    AddItem();
                })
            }
            function GetTypeName(id) {
                var str = "";
                $.get("/admin/ajax/Member.ashx", "type=GetTypeName&id=" + id, function (obj) {
                    str = obj;
                }, "text");
                return str;
            }
            function AddItem() {
                var b = true
                $("#DDlZffs option").each(function () {
                    if ($(this).val() == "10") {
                        b = false;
                    }
                })
                if (b) {
                    $("#DDlZffs").prepend("<option value='10'>储值卡</option>");
                    $("#DDlZffs").val("10");
                }
            }

            function Xy(obj) {
                if ($(obj).attr("src") == "../images/clear.jpg") {
                    $("#customer").val("");
                    $("#CpId").val("");
                    $("#accounts").val("");
                    $(obj).attr("src", "../Images/search.jpg")
                }
                else {
                    var url = "/admin/Toroom/customerList.aspx";
                    showMyWindow("选择客户", url, "1000", "550", true, true, true);
                }
            }
    </script>
    <link href="../css/toomroom.css" rel="stylesheet" type="text/css" />
</head>
<body style=" overflow-x:hidden" id="mainBody">

    <form id="form1" runat="server">
    <div id="dd"></div>  
    <input type="hidden" id="isOk" runat="server"/>
    <input type="hidden" id="txtpath" runat="server" />
    <input type="hidden" id="isZF" runat="server" />
    <input type="hidden" id="type" runat="server" /> 
    <input type="hidden" id="contents1" runat="server" />
    <input type="hidden" id="ylDate" runat="server" />
    <input type="hidden" id="kftype" runat="server" />
    <input type="hidden" id="guazhangRoom" runat="server"/>
    <input type="hidden" id="txt_hycard" value="1" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div class="tops">
            <div class="top1left">
                <ul>
                <li style=" position:relative;">姓&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 名：<input type="text" autocomplete="off" name="textfield" id="txt_name" onkeyup="aa()"
                        onchange="TAbles(this)" onfocus="aa()" class="w30 textbox_hrj textbox-text_hrj" runat="server" style=" width:40%;"/>
                        <div class="dio">
                            <ul>
                            </ul>
                        </div>
                    </li>
                    <li>性&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 别：<%--<input type="text" name="textfield" id="txt_Sex"
                        onchange="TAbles(this)" runat="server" />--%><asp:DropDownList ID="ddll_sex"  CssClass="w80 textbox_hrj textbox-text_hrj easyui-combobox_hrj" onchange="TAbles(this)"
                            runat="server">
                            <asp:ListItem Value="男">男</asp:ListItem>
                            <asp:ListItem>女</asp:ListItem>
                        </asp:DropDownList>
                    </li>
                    <li>房&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;号：<input type="text" name="textfield" id="txt_roomid" class="w120 textbox_hrj textbox-text_hrj" onchange="TAbles(this)"
                        runat="server" /></li>
                    <li>房&nbsp;&nbsp;&nbsp;&nbsp;型：<asp:DropDownList ID="ddroomtype"  CssClass="textbox_hrj textbox-text_hrj easyui-combobox_hrj" DataTextField="room_name" DataValueField="id"
                        onchange="TAbles(this)"  disabled="disabled" runat="server">
                    </asp:DropDownList>
                    </li>
                    <li style=" position:relative;">会员卡号：<input type="text" name="textfield" id="txt_hycardId" onchange="TAbles(this)"
                        runat="server" class="w30 textbox_hrj textbox-text_hrj" onkeyup="KC()" /><p id="yst" style=" display: none; position:absolute; left:60px; top:20px;;">余额<span id="sumyue"></span>积分<span id="sumjf"></p></span>
                    </li>
                    <li>来&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;源：<asp:DropDownList ID="DDlkrly" onchange="TAbles(this)" class="w80 textbox_hrj textbox-text_hrj easyui-combobox_hrj" runat="server">
                    </asp:DropDownList>
                    </li>
                    <li>房价方案：<asp:DropDownList ID="DDLfjfa" runat="server" CssClass="w120 textbox_hrj textbox-text_hrj easyui-combobox_hrj" onchange="TAbles(this)">
                    </asp:DropDownList>
                    </li>
                    <li>房&nbsp;&nbsp;&nbsp;&nbsp;价：<input type="text" name="textfield" id="txt_moneys" disabled="disabled" class="w88 textbox_hrj textbox-text_hrj" runat="server" />
                    </li>
                    <li>折 后 &nbsp;价：<input type="text" name="textfield" id="txt_money" onchange="TAbles(this)"
                        runat="server" class="w30 textbox_hrj textbox-text_hrj"/>
                    </li>
                    <li>开房方式：<asp:DropDownList ID="DDlKffs"  class="w80 textbox_hrj textbox-text_hrj easyui-combobox_hrj" runat="server" onchange="TAbles(this)">
                    </asp:DropDownList>
                    </li>
                    <li>主房账号：<input type="text" class="w120 textbox_hrj textbox-text_hrj" name="textfield" id="txt_zfzhanghao" onchange="TAbles(this)"
                        runat="server" /></li>
                        <li id="fangan" runat="server" style="display: none;">钟点房方案：<asp:DropDownList runat="server" CssClass="textbox_hrj textbox-text_hrj easyui-combobox_hrj"
                            ID="ZD_hourse">
                        </asp:DropDownList>
                            <input type="hidden" runat="server" id="txtsort" />
                        </li>
                        <li id="moshi" runat="server" class="w88" style="display: none;">模&nbsp;&nbsp;&nbsp;&nbsp;式：<asp:DropDownList
                            runat="server" ID="DDlmoshi" CssClass="textbox_hrj textbox-text_hrj easyui-combobox_hrj" onchange="TAbles(this)">
                        </asp:DropDownList>
                        </li>
                </ul>
                
            </div>
            <div class="top1right" style="text-align:center;">
                <div class="imgdiv" id="headimg" runat="server" style="width: 100px; margin:0 auto; height: 100px;
                    background-color: Gray;">

                </div>
                <input type="button" style=" 
    margin-left: 13px;
" value="启动摄像头" class="btnStark" />
                <input type="button" value="拍照" onclick="javascript:saveToFile();disp(1)" />
                &nbsp;
                <br />
            </div>
       </div>
            <!--灰色部分着重强调-->
            <div class="zd">
            <ul class="ul2s">
                    <li class="kfrzts"><span class="spans">入住天数：</span>
                        <p class="jia" onclick="SaleRealNum(this)">
                            -</p>
                        <input type="text" id="txt_Day" class="numbers w30 textbox_hrj textbox-text_hrj" style="width:30px;" runat="server" value="1" onkeyup="addsDate();TAbles(this)"
                            name="textfield" />
                        <p class="jia" onclick="addRealNum(this)">
                            +</p>
                        <!--<li >
            入住天数:<span onclick="SaleRealNum(this)"  style="display:inline-block;box-sizing:border-box;font-size:18px;font-weight:bold;width:20px;line-height:26px;background:#f2f2f2">-</span>
            <span><input type="text" id="Text1" class="numbers" runat="server" value="1" onchange="addsDate();TAbles(this)" name="textfield"  style="float:left;width:50px"/></span>
            <span onclick="addRealNum(this)" style="display:inline-block;box-sizing:border-box;font-size:18px;font-weight:bold;line-height:20px;background:#f2f2f2">+</span>
            </li>-->
                        <li>入住时间：<input type="text" name="textfield" id="txt_rzdate" disabled="disabled"
                       class="w80 textbox_hrj textbox-text_hrj"     runat="server" />
                        </li>
                        <li style=" position:relative;">预离时间：<input type="text" name="textfield" id="txt_ylDate" autocomplete="off" runat="server" class="w80 textbox_hrj textbox-text_hrj" onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss',onpicked:function() {AddDay()}})"
                             onkeyup="TAbles(this);AddDay();" onchange="TAbles(this);AddDay();"/><span id="redsp" runat="server" class="w110 textbox_hrj textbox-text_hrj" style=" float:left; padding:0;position: absolute;
  width: 100%;
  top: -20px;">该房<span id="retime" runat="server"></span>被预定</span>
                             
                        </li>
                </ul>

                <ul class="ul2s">
                    
                    <li>出生年月：<input type="text" name="textfield" id="txt_Date2" onchange="TAbles(this)"
                        onclick="WdatePicker()" class="w110 textbox_hrj textbox-text_hrj" runat="server" />
                    </li>
                    <li>民&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 族：<input type="text" name="textfield" id="txt_mingzhu" onchange="TAbles(this)" value="汉族" runat="server" style="display:none;"/>
                        <select id="national" onchange="TAbles(this)" class="textbox_hrj textbox-text_hrj easyui-combobox_hrj"></select>
                    </li>
                    <li>证件类型：<asp:DropDownList ID="DDlSFz" CssClass="w120 textbox_hrj textbox-text_hrj easyui-combobox_hrj" DataTextField="ct_name" onchange="TAbles(this)"
                        DataValueField="id" runat="server">
                    </asp:DropDownList>
                    </li>
                    <li>证件号码：<input type="text" class="w80 textbox_hrj textbox-text_hrj" name="textfield" id="txt_CardId" onchange="TAbles(this)"
                        runat="server" />
                    </li>
                    <li>联系电话：<input type="text" class="w80 textbox_hrj textbox-text_hrj" name="textfield" id="txt_lxphone" onchange="TAbles(this)"
                        runat="server" /></li>
                    
                    </li>
                    <li style=" width:40%;">地&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 址：<input type="text"
                        name="textfield" class="textbox_hrj textbox-text_hrj" id="txt_address" onchange="TAbles(this)" style=" width:73%;"
                        runat="server" />
                    </li>
                    
                </ul>
            </div>
            <!--左中右快速开房-->
            <div id="DivDisHidroom" runat="server" class="ksxf_list" style="display: none;">
            <div style="height: 450px; width: 45%;float: left;">
            <table width='100%'  border='0' cellspacing='0' cellpadding='0'>
                <thead>
                    <tr>
                        <td style=" width:62px;">
                            房号</td>
                        <td style="width:230px;">
                            房间类型</td>
                        <td style="width:70px;">
                            房价</td>
                    </tr>
                </thead>
                </tr>
                <tbody></tbody></table>
                <div id="DivKXRoom" class="lr_box1" style="height: 450px; width: 100%; overflow: auto;
                    " runat="server">

                </div>
                </div>
                <ul class="m_box1">
                    <li><%--
                        <asp:Button class="orangeBtn midBtn" ID="btnyzAdds" OnClientClick="AddRoom()" runat="server" Text="添　加"/>--%>
                        <input type="button" class="orangeBtn midBtn" id="btnyzAdds" onclick="AddRoom()" value="添加"/>
                        </li>
                    <li><%--
                        <asp:Button class="grayBtn midBtn" ID="Button1" runat="server" Text="移　除" OnClick="Button1_Click" />--%>
                        <input type="button" class="grayBtn midBtn" id="Button1" value="移　除" onclick="RemvoeRoom()"/>
                    </li>
                </ul>
                <div style="height: 450px; width: 40%;float: right; ">
                <table border='0' width='100%' cellspacing='0' cellpadding='0'>
                    <thead>
                        <tr>
                            <td style=" width:62px;">
                                房号</td>
                            <td style="width:230px;">
                                房间类型</td>
                            <td style="width:70px;">
                                房价</td>
                        </tr>
                    </thead>
                    </tr>
                    <tbody></tbody></table>
                <div id="DivYXRoom" style="width: 100%; height: 450px; overflow: auto;"
                    runat="server">
                    <table id="yxtable"></table>
                </div>
                </div>
            </div>
            <!--其他-->
            <ul class="ul2s">
                <li>支付方式：<asp:DropDownList ID="DDlZffs" DataTextField="meth_pay_name" CssClass="w120 textbox_hrj textbox-text_hrj easyui-combobox_hrj" DataValueField="meth_pay_id"
                    runat="server">
                </asp:DropDownList>
                </li>
                <li>挂帐目标：<input type="text" name="textfield" id="guazhang" class="w110 textbox_hrj textbox-text_hrj" runat="server" disabled="disabled"/><img
                    src="../Images/search.jpg" onclick="Gz(this)" />
                <input type="hidden" id="guazhangs" runat="server" />
                </li>
                <li>押 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;金：<input type="text" name="textfield" id="txt_yjmoney" class="w80 textbox_hrj textbox-text_hrj" runat="server" />
                </li>
                 <li style=" position:relative;">协议单位：<input type="text" name="textfield" disabled="disabled" class="w60 textbox_hrj textbox-text_hrj" id="customer" style=" width:128px;" onchange="TAbles(this)"
                        runat="server" /><img src="../Images/search.jpg" id="imgicos" onclick="Xy(this)">
                        <input type="hidden" id="accounts" runat="server" />
                        <input type="hidden" id="CpId" runat="server"/>
               </li>
                <li id="listSfrq" runat="server" style="display: none;">收费 日 期:每月<input type="text" value="1"
                        name="textfield" id="txt_sfr" style=" width:30px;" runat="server" class="textbox_hrj textbox-text_hrj" onchange="TAbles(this)" />号
                    </li>
                <li style="width: 100%; clear: left; overflow: hidden;">备 注：<textarea id="txt_Remaker"
                    runat="server" rows="3" style="width: 748px; vertical-align: top" class="textbox_hrj textbox-text_hrj"></textarea>
                </li>
            </ul>
            <!--定金结束-->
            <div class="kfMoreBtn">
               <asp:Button ID="btnAdds" runat="server" Text="开房" class="orangeBtn midBtn" OnClientClick="return isFill();"
                    OnClick="btnAdds_Click" />
                   <%-- <input type="button" value="开房" id="btnAdds" class="orangeBtn midBtn"  runat="server" onclick="return isFill();" onserverclick="btnAdds_Click"/>--%>
                    &nbsp;
                <input name="读取二代身份证" type="button" value="读取二代身份证" class="orangeBtn 120Btn" />
                <input name="联房开房" type="button" onclick="DivDisRoom()" runat="server" value="联房开房"
                    id="btn_rooms" class="greenBtn midBtn" />
                <input type="button" class="blueBtn" value="客人信息" onclick="CostAdds(this)" />
                <input id="guanbi" name="关　闭" type="button" value="关　闭" class="grayBtn midBtn" onclick="clos1()" />
            </div>
            <!--按纽结束-->
            <p>
                <asp:Button ID="btnBind" runat="server" Text="Button" OnClientClick="if(isFills()){}else{return false;}"
                    OnClick="btnBind_Click" Style="display: none;" />
                <asp:Button ID="btnbur" runat="server" Text="失去焦点" OnClick="btnbur_Click" Style="display: none;" />
                <%--<asp:Button ID="btnkffs" runat="server" Text="开房方式" Style="display: none;" OnClick="btnkffs_Click" />--%>
                <input type="hidden" id="txt_id" runat="server" />
                <input type="hidden" id="txt_price" runat="server" />
                <input type="hidden" id="txt_CardesName" runat="server" />
                <asp:HiddenField ID="hidSchool" runat="server" />
                <asp:HiddenField ID="hidsk2" runat="server" />
                <asp:HiddenField ID="hidSuikeInfo" runat="server" />
                <input type="hidden" id="txt_Info" runat="server" />
                <input type="hidden" id="txt_type" runat="server" />
                <input type="hidden" id="txt_img" runat="server" />
                <input type="hidden" id="txt_roomnumber" runat="server" />
                <input type="hidden" id="txt_zhi" runat="server" /></p>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnBind" />
            <asp:AsyncPostBackTrigger ControlID="btnAdds" />
        </Triggers>
    </asp:UpdatePanel>
    <object classid="clsid:34681DB3-58E6-4512-86F2-9477F1A9F3D8" id="cap1" class="astyle"
        codebase="../cabs/ImageCapOnWeb.cab#version=2,0,0,0">
        <param name="Visible" value="0">
        <param name="AutoScroll" value="0">
        <param name="AutoSize" value="0">
        <param name="AxBorderStyle" value="1">
        <param name="Caption" value="scaner">
        <param name="Color" value="4278190095">
        <param name="Font" value="宋体">
        <param name="KeyPreview" value="0">
        <param name="PixelsPerInch" value="96">
        <param name="PrintScale" value="1">
        <param name="Scaled" value="-1">
        <param name="DropTarget" value="0">
        <param name="HelpFile" value>
        <param name="PopupMode" value="0">
        <param name="ScreenSnap" value="0">
        <param name="SnapBuffer" value="10">
        <param name="DockSite" value="0">
        <param name="DoubleBuffered" value="0">
        <param name="ParentDoubleBuffered" value="0">
        <param name="UseDockManager" value="0">
        <param name="Enabled" value="-1">
        <param name="AlignWithMargins" value="0">
        <param name="ParentCustomHint" value="-1">
        <param name="key1" value="">
        <param name="key2" value="">
    </object>
    <table id="tb_List" runat="server" style=" display:none;">
    </table>
    <input type="hidden" runat="server" id="inpText" />
    </form>
    <script type="text/javascript">
        document.all.cap1.SwitchWatchOnly();  //切换到只显示摄像头画面形式，隐藏编辑按钮等图标.
    </script>
     <div class="ac_results" style="position: absolute; width: 420px; top:70px; left: 70px;">
        <ul style="max-height: 180px; overflow: auto;">
        </ul>
    </div>
</body>
</html>
