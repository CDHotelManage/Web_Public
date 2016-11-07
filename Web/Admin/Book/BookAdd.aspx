<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookAdd.aspx.cs" Inherits="CdHotelManage.Web.Admin.Book.Book_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
 <title> 
 预定信息
 </title>
   <script src="../../js/jquery.js" type="text/javascript"></script>
    <script src="../../js/hDate.js" type="text/javascript"></script>
    <link href="../../style/css.css" rel="stylesheet" type="text/css" />
    <link href="../../style/hDate.css" rel="stylesheet" type="text/css" />
    <link href="../../style/Opendiv.css" rel="stylesheet" type="text/css" />
    <script src="../../js/DivWH.js" type="text/javascript"></script>
    <script src="../../calendar/WdatePicker.js" type="text/javascript"></script>
    <link href="../../easyui/themes/gray/easyui.css" rel="stylesheet" type="text/css" />
    <script src="../../easyui/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../js/base.js" type="text/javascript"></script>
    <script type="text/javascript">
        var isType = true;
        //新增
        function checkForm(thi) {
            if (!isType) {
                alert("不能选择一样的房型!!");
                return false;
            }
            //验证姓名
            var book_name = document.getElementById("book_name").value;
            var patrn = /^\s*[\u4e00-\u9fa5]{1,}[\u4e00-\u9fa5.·]{0,15}[\u4e00-\u9fa5]{1,}\s*$/;
            if (book_name == "") {
                alert("请输入预定人姓名");
                return false;
            }
            if (!patrn.exec(book_name)) {
                alert("预定人姓名为2-15个汉字，请重新输入!");
                return false;
            }
            //验证手机号
            var tele_no = document.getElementById("tele_no").value;
            //定金
            var deposit = document.getElementById("deposit").value;
            var checkTeleNo = /^0?(13[0-9]|15[012356789]|18[0236789]|14[57])[0-9]{8}$/;//正则表达式
            if (tele_no == "") {
                alert("请输入手机号");
                return false;
            }
            var reg = new RegExp("^[0-9]*$");
            if (deposit == "") {
                $("#deposit").val("0");
            }
            if (!checkTeleNo.test(tele_no)) {
                alert("手机号格式错误，请重新输入");
                return false;
            }
            if ($("#real_time").val() == "") {
                alert("留房时间不能为空");
                return false;
            }
            if ($("#time_from").val() == "") {
                alert("退房时间不能为空");
                return false;
            }
            if ($("#time_to").val() == "") {
                alert("预定时间不能为空");
                return false;
            }
            //验证类型
            var type = $("#BookAddButton").val();
            var isUpdate = false;
            var book_no = "";
            switch (type) {
                case "预定":
                    isUpdate = false;
                    break;
                case "更新":
                    isUpdate = true;
                    book_no = $("#book_no_hid").val();
                    break;
            }
            var txtname = $("#book_name").val();
            var txtPhone = $("#tele_no").val();
            var txtDh = $("#onli_no").val();
            var txtrz = $("#real_time").val();
            var txttf = $("#time_from").val();
            var txtyd = $("#time_to").val();
            var txtmCard = $("#mem_cardNo").val();
            var guarWayDll = $("#GuarWayDll").val();
            var guestSourceDdl = $("#GuestSourceDdl").val();
            var methPayDdl = $("#MethPayDdl").val();
            var txtdj = $("#deposit").val();
            var textRemaker = $("#textRemaker").val();
            var accounts = $("#accounts").val(); //协议单位编号
            var CpId = $("#CpId").val();//协议方案ID
            var delits = "";
            $("#TabAdd tr").each(function () {
                var typeid = $(this).find("#RoomTypeDdl").val();
                var fangan = $(this).find("#HouseShameDdl").val();
                var price = $(this).find(".txtprice").val();
                var number = $(this).find(".number").val();
                $(this).find("#fh a").each(function () {
                    var roomnumber = $(this).text();
                    delits += "typeid:" + typeid + ",fangan:" + fangan + ",price:" + price + ",roomnumber:" + roomnumber + ",number:1*";
                })
            });
            var datas = "txtname=" + txtname + "&txtPhone=" + txtPhone + "&txtDh=" + txtDh + "&txtrz=" + txtrz + "&txttf=" + txttf + "&txtyd=" + txtyd + "&txtmCard=" + txtmCard + "&guarWayDll=" + guarWayDll + "&guestSourceDdl=" + guestSourceDdl + "&methPayDdl=" + methPayDdl + "&txtdj=" + txtdj + "&textRemaker=" + textRemaker + "&book_no=" + book_no + "&accounts=" + accounts + "&CpId=" + CpId;
            $.post("/Admin/Ajax/Books.ashx", datas + "&type=AddZ&isUpdate=" + isUpdate + "&sjs=" + delits, function (obj) {
                var strs = new Array(); //定义一数组 
                strs = obj.split(","); //字符分割 
                if (strs[0] == "新增成功!") {
                    /*新增成功需要入帐*/
                    if (confirm("预定新增成功，是否打印预定单?")) {

                        ShowDivs(thi, strs[1]);
                    }
                    else {
                        Closes();
                    }
                }
                else if (strs[0] == "更新成功!") {
                    alert("更新成功");
                    Closes1();
                }
                else {
                    alert(strs[0]);
                }
            }, "text");
            return false;
        }

        function ShowDivs(obj, id) {
            var url = "/Admin/ShiftExc/Advance.aspx?id=" + id;
            showMyWindow("打印新增预定单", url, "400", "500", true, true, true,Close);
        }
        function Closes1() {
            clo("编辑预订信息");
            var url = "/admin/book/booklist.aspx";
            AddTabs("预定管理", url);
        }

        function Close1() {
            var txt = $(".tabs-wrap", window.parent.document).find(".tabs-selected .tabs-title").text();
            clo(txt);
        }
        function Closes() {
            clo("新增预定信息");
            AddTabs("预定管理", "/admin/book/booklist.aspx");

        }
        function funAddTable() {
            var trs = $("#TabAdd").find("tr");
            var html = trs.eq(0).html();
            trs.eq(trs.length - 1).after("<tr>" + html + "</tr>");
            PuanD();
        }

        function PuanD() {
            trs = $("#TabAdd").find("tr");
            for (var i = 0; i < trs.length; i++) {
                for (var j = i + 1; j < trs.length; j++) {
                    if (trs.eq(i).find("#RoomTypeDdl option:selected").text() == trs.eq(j).find("#RoomTypeDdl option:selected").text()) {
                        trs.eq(i).find("#RoomTypeDdl").css("border", "1px solid red");
                        trs.eq(j).find("#RoomTypeDdl").css("border", "1px solid red");
                        isType = false;
                        return;
                    }
                    else {
                        trs.eq(i).find("#RoomTypeDdl").css("border-color", "rgb(169, 169, 169)");
                        trs.eq(j).find("#RoomTypeDdl").css("border-color", "rgb(169, 169, 169)");
                        isType = true;
                    }
                }
            }
        }

       
        function DelTr(obj) {
            trs = $("#TabAdd").find("tr");
            if (trs.length == 2) {
                isType = true;
                $(obj).parent().parent().remove();
                $("#RoomTypeDdl").css("border-color", "rgb(169, 169, 169)");
            }
            else {
                if ($("#TabAdd").find("tr").length <= 1) {
                    alert("至少选择一个!!");
                }
                else {
                    $(obj).parent().parent().remove();
                }
            }
        }

        function addRealNum(obj) {
            var parw = $(obj).prev("p").find(".number");
            var b = $("#isok").val();
            if (parseInt(parw.val()) >= parseInt($(obj).parent().parent().find("#txtOkNum").text())) {
                if (b == "True") {
                    if (parseInt(parw.val()) >= $(obj).parent().parent().find("#maxNum").text()) {
                        alert("预定数超过了！！");
                        return;
                    }
                }
                else if (b == "False") {
                    alert("不允许超预定!");
                    return;
                }
            }
            parw.val(parseInt(parw.val()) + 1);
            nowtr = $(obj).parent().parent();
            var num = nowtr.find(".number").val();
            
            var as = "";
            for (var i = 0; i < parseInt(num); i++) {
                as += "<a></a>";
            }
            nowtr.find("#fh").html(as);
        }

        function SaleRealNum(obj) {
            var parw = $(obj).next("p").find(".number");
            parw.val(parseInt(parw.val()) - 1);
            if ($(obj).next("p").find(".number").val() < 1) {
                alert("预定房数不能小于1");
                parw.val(1);
                return;
            }
            nowtr = $(obj).parent().parent();
            nowtr.find("#fh").text("");
        }

        var real_num;
        var nowtr;
        function ShowDiog(obj) {
            if (!isType) {
                alert("不能选择一样的房型!!");
                return false;
            }

            nowtr = $(obj).parent().parent();
            var list = new Array();
            var ass = nowtr.find("#fh a");
            for (var i = 0; i < ass.length; i++) {
                list[i] = ass.eq(i).text();
            }
            var RoomTypeDdl = nowtr.find("#RoomTypeDdl");
            real_num = nowtr.find("#real_num");
            $(".mo").css("display", "block")
            $(".diog").css("display", "block");
            $.post("/Admin/Ajax/Books.ashx", "type=getdel&typeid=" + RoomTypeDdl.val(), function (objs) {
                var listArrJson = eval("(" + objs + ")");
                var tbList = listArrJson.data;
                var html = "";
                for (var i = 0; i < tbList.length; i++) {
                    var str = "";
                    if (list.Contains(tbList[i].Rn_roomNum)) {
                        str = "<input type=\"checkbox\" checked=\"checked\" value=\"" + tbList[i].Rn_roomNum + "\" />";
                    }
                    else {
                        str = "<input type=\"checkbox\" value=\"" + tbList[i].Rn_roomNum + "\" />";
                    }
                    html += "<tr><td>" + str + "</td><td>" + RoomTypeDdl.find("option:selected").text() + "</td><td class=\"numbers\">" + tbList[i].Rn_roomNum + "</td><td>" + tbList[i].Rn_price + "</td></tr>";
                }
                $("#tblist").html(html);
            }, "text");
        }

        Array.prototype.Contains = function (element) {
            for (var i = 0; i < this.length; i++) {
                if (this[i] == element) {
                    return true;
                }
            }
            return false;
        };
        function HideDiog() {
            $(".diog").css("display", "none");
            $(".mo").css("display", "none");
        }
        $(function () {
            if ($("#customer").val() != "") {//修改的时候。如果有协议单位。直接改图片为X
                $("#imgicos").attr("src", "../images/clear.jpg");
            }
            if ($("#BookAddButton").css("display") == "none") {
                $("input").attr("disabled", "disabled");
                $("select").attr("disabled", "disabled");
            }
            if ($("#BookAddButton").val() == "更新") {
                $("#TabAdd tr").eq(0).remove();
            }
            $(".btnchech").click(function () {
                HideDiog();
            });
            $(".btnOk").click(function () {
                var ches = $("#tblist tr").find("input:checkbox:checked");
                if (parseInt(ches.length) > parseInt(real_num.val())) {
                    alert("数量超过了!!");
                }
                else {
                    var hs = nowtr.find("#real_num").val();
                    var trs = "";
                    ches.each(function () {
                        trs += "<a>" + $(this).parent().parent().find(".numbers").text() + "</a> ";
                    });
                    if (parseInt(hs) - parseInt(ches.length) > 0) {
                        for (var i = 0; i < parseInt(hs) - parseInt(ches.length); i++) {
                            trs += "<a></a>";
                        }
                    }
                    nowtr.find("#fh").html(trs);
                    HideDiog();
                }
            })
            PuanD();
            //全选择反选
            $(".chkAll").click(function () {
                $("#tblist input:checkbox").attr("checked", this.checked);
            })

        })


        function ShowTabs(title) {
            // 关闭当前
            var jq = top.jQuery;
            var url = "/admin/Toroom/ToRoom.aspx";
            AddTabs(title, url);
            window.location.reload(true);
            if (jq('#tabs').tabs('exists', "房态图")) {
                clo("房态图");
                AddTabs(title, url);
            }
            clos();
        }
        function AddDay() {
            var yltime = document.getElementById("time_from").value;
            var list = yltime.split(' ');
            var ydtime = document.getElementById("real_time").value;
            var list1 = ydtime.split(' ');
            DateDiff(list[0], list1[0]);
        }
        //两日期计算天数
        function DateDiff(sDate1, sDate2) {    //sDate1和sDate2是2006-12-18格式  
            var aDate, oDate1, oDate2, iDays
            aDate = sDate1.split("-");
            oDate1 = new Date(aDate[1] + '-' + aDate[2] + '-' + aDate[0])    //转换为12-18-2006格式
            aDate = sDate2.split("-");
            oDate2 = new Date(aDate[1] + '-' + aDate[2] + '-' + aDate[0])
            if (oDate1 <= oDate2) {
                alert("来店时间不能大于退房时间!!");
                $("#time_to").val("");
            }
            iDays = parseInt(Math.abs(oDate1 - oDate2) / 1000 / 60 / 60 / 24)    //把相差的毫秒数转换为天数
            return iDays
        }
        $.ajaxSetup({
            async: false
        });

        function UpdatesObj() {
            var trs = $(".tr");
            trs.each(function () {
                var obj = trs.find("#RoomTypeDdl");
                var v = obj.find("option:selected").val(); //选中房间类型
                var real_time = $("#real_time").val();
                
                $.get("/Admin/Ajax/Books.ashx", "type=getOkNum&typeid=" + v + "&real_time=" + real_time, function (objs) {
                    obj.parent().parent().find("#txtOkNum").text(objs);
                    $.get("/Admin/Ajax/Books.ashx", "type=getmaxNum&txtOkNum=" + objs + "&typeid=" + v, function (msg) {
                        obj.parent().parent().find("#maxNum").text(msg);
                    }, "text");
                }, "text");
            })
        }

        function txtblur(obj) {
            var trsnow = $(obj).parent().parent().parent();
            var reg = new RegExp("^[0-9]*$");
            var num = $(obj).val();
            if (!reg.test(num)) {
                alert("请输入数字!");
                $(obj).val("1");
            }
            else {
                if (parseInt(num) > 0) {
                    var b = $("#isok").val();
                    if (parseInt(num) > parseInt(trsnow.find("#txtOkNum").text())) {
                        if (b == "True") {

                        }
                        else if (b == "False") {
                            alert("预定数超过了！！");
                            $(obj).val(trsnow.find("#txtOkNum").text())
                            return;
                        }

                    }
                }
                else if (parseInt(num) <= 0) {
                    alert("预定数必须大于0");
                    $(obj).val("1");
                }
            }
        }

        function GetListNum() {
            $(".ac_results").css("display", "block");
            $.get("/admin/ajax/Member.ashx", "type=getallm", function (obj) {
                var tblist = obj.data;
                var html = ""
                for (var i = 0; i < tblist.length; i++) {
                    html += "<li ><span style=\"width: 150px; display: inline-block\">卡号：<span class='mid'>" + tblist[i].Mid + "</span></span><span style=\"width: 150px; display: inline-block\">手机：" + tblist[i].Phone + "</span><span style=\"width: 70px;display: inline-block\">" + tblist[i].Zjtype + "<strong></strong></li>";

                }
                $(".ac_results ul").html(html);
                $(".ac_results").css("border", "1px solid black");
                BindValue();
            }, "json");
        }


        function BindValue() {
            $(".ac_results ul li").click(function () {
                var mid = $(this).find(".mid").text();
                $("#mid").val(mid);
                $("#mem_cardNo").val(mid);
                $.get("/admin/ajax/Member.ashx", "type=getvalue&mid=" + mid, function (obj) {
                    $("#book_name").val(obj.name);
                    $("#txt_Date2").val(obj.Baithday);
                    $("#txt_CardId").val(obj.ZjNumber);
                    $("#tele_no").val(obj.Phone);
                    $("#txt_address").val(obj.Address);
                    $("#yst").css("display", "inline-table");
                    $("#sumyue").text(obj.czyue);
                    $("#sumjf").text(obj.shengyu);

                }, "json");
                $(".ac_results").css("display", "none");
            })
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

        //计算房价
        function Zjfan() {
            if ($("#CpId").val() == "") {

            }
            else {//如果有协议单位。就读取协议单位的价格
                $("#TabAdd tr").each(function () {
                    var metr = $(this);
                    var cpid = $("#CpId").val();
                    var typeid = $(this).find("#RoomTypeDdl").val();
                    $.get("/admin/Ajax/Member.ashx", "type=getPrice&cpid=" + cpid + "&typeid=" + typeid, function (obj) {
                        if (obj.statu == "ok") {
                            var tblist = obj.data;
                            metr.find(".txtYj").val(tblist[0].Price); //房价
                            metr.find(".txtprice").val(tblist[0].protoPrice); //折扣价
                        }
                        else if (obj.statu == "err") {
                            metr.find(".txtYj").val(obj.data.Price); //房价
                            metr.find(".txtprice").val(obj.data.protoPrice); //折扣价
                        }
                    }, "json");
                })
          }
        }

        function selectChange(obj) {
            var obj = $(obj);
            var v = obj.find("option:selected").val(); //选中房间类型
            var real_time = $("#real_time").val();
            var fz = obj.parent().parent().find("#HouseShameDdl").val();
            if ($("#CpId").val() == "") {


               
                $.get("/Admin/Ajax/Books.ashx", "type=updatePrice&typeid=" + v + "&fa=" + fz, function (objs) {
                    obj.parent().parent().find(".txtprice").val(objs.d);
                    obj.parent().parent().find(".txtYj").val(objs.price);
                }, "json");
                $.get("/Admin/Ajax/Books.ashx", "type=getOkNum&typeid=" + v + "&real_time=" + real_time, function (objs) {
                    obj.parent().parent().find("#txtOkNum").text(objs);
                    $.get("/Admin/Ajax/Books.ashx", "type=getmaxNum&txtOkNum=" + objs + "&typeid=" + v, function (msg) {
                        obj.parent().parent().find("#maxNum").text(msg);
                    }, "text");
                }, "text");

                
               
            }
            else {
                Zjfan();
            }
            obj.parent().parent().find("#fh").html("<a></a>"); //清空房号
            PuanD();
        }
    </script>
    <style type="text/css">
      .ac_results{ background:#fff;}
         .ac_results ul li:hover{ background-color:Blue; color:#fff;}
    .frames{  background: #ececec;
  position: fixed;
  left: 50%;
  top: 50%;
  margin-top: -250px;
  margin-left: -150px; display:none; padding:10px;border-radius:10px;}
    </style>
</head>

<body id="bookadd">
    <!--新增预订信息-->
   
    <form id="AddBookForm" name="form1" runat="server" >
    <input type="hidden" value="" id="isok" runat="server"/>
    <input type="hidden" runat="server" id="book_no_hid"/>
    
        <asp:Label ID="lblmsg" runat="server" style="display:none;"></asp:Label>
        <ul class="addyd">
            <li>预 订 人 ：<input type="text" name="txtname" runat="server" id="book_name" class="input001" /></li>
            <li>电　　话：<input type="text" name="txtPhone" runat="server" id="tele_no" class="input001" /></li>
            <li>网上单号：<input type="text" name="txtDh" runat="server" id="onli_no" class="input001" /></li>
            <li>预到时间：<input type="text" name="txtrz"  id="real_time" runat="server"
                    onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm',onpicked:function() {UpdatesObj()}})" class="input001" /></li>
            <li>退房时间：<input type="text" name="txttf" class="input001" id="time_from"
                runat="server" onClick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm',onpicked:function() {AddDay()}})"  /></li>
            <li>预定时间：<input type="text" name="txtyd" class="input001" id="time_to"
                runat="server" onClick="WdatePicker({onpicked:function() {AddDay()}})" /></li>
            <li>会员卡号：<input type="text" name="txtmCard" runat="server" id="mem_cardNo"  onclick="GetListNum()" class="input001" /></li>
            <li> 担保方式：<asp:DropDownList ID="GuarWayDll" runat="server">
                    <asp:ListItem>无担保</asp:ListItem>
                    <asp:ListItem>有担保</asp:ListItem>
                    <asp:ListItem>网上预付</asp:ListItem>
                </asp:DropDownList></li>
            <li>来　　源：<asp:DropDownList ID="GuestSourceDdl" runat="server">
                    </asp:DropDownList></li>
            <li>支付方式：<asp:DropDownList ID="MethPayDdl" runat="server">
                </asp:DropDownList></li>
            <li>协议单位：<input type="text" name="xydan" runat ="server" id = "customer" class="input001"  style="width:100px;"/><img src="../Images/search.jpg" id="imgicos" onclick="Xy(this)">
                        <input type="hidden" id="accounts" runat="server" />
                        <input type="hidden" id="CpId" runat="server"/></li>
            <li>订　　金：<input type="text" name="txtdj" runat ="server" id = "deposit" class="input001"  style="width:100px;"/></li>
           </ul>
            <!--定金结束-->
            
      
                <div  style="border: none; padding-left: 0;  overflow: hidden;background: #f2f2f2">
                 <table width="100%" id="TabAdd" align="center" cellspacing="0" >
                            <tr class="tr" style="border:solid 1px #000;margin-bottom:10px">
                            
                                <td>
                                    房 型：<asp:DropDownList ID="RoomTypeDdl" runat="server" onchange="return selectChange(this);">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                     方 案：<asp:DropDownList ID="HouseShameDdl" runat="server"  >
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    房 价： <input type="text" name="textfield" id="pricetxt" class="txtYj" runat="server" style=" width:60px;"/>
                                </td>
                                <td>
                                    折后价： <input type="text" name="textfield" id="real_price" class="txtprice" runat="server" />
                                </td>
                             <td>
                                    可预定数：<span  id="txtOkNum" runat="server" class="txtprice"  ></span><span runat="server" id="maxNum" style=" display:none;"></span>
                                </td>
                                <td class=" fjsljj">
                                    <p>房间数量：</p>
                                    <p onclick="SaleRealNum(this)" class="jians">-</p>
                                    <p><input type="text" id="real_num" runat="server" value="1" name="textfield" class="number fjslInp" onblur="txtblur(this)"/></p>
                                    <p onclick="addRealNum(this)" class="jia">+</p>
                                    <p onclick="funAddTable()" class="addBook">添加</p>
                                    <p class="delBook"  onclick="DelTr(this)">删除</p>
                                </td>
                                <td>
                                  <input type="type" value="预分" class="addBook" onclick="ShowDiog(this)"  />
                                </td>
                                <td>
                                    房 号：<span id="fh"><a></a></span></td>
                                <td>
                                    <span id="HouseNumDdl"></span>
                                </td>
                            </tr>
                            <%=sbDel.ToString() %>
                        </table>  
                        </div>
                       
                    <!--重要信息，循环部分,添加，删除-->
                    <div class="bookaddbz"><span>备 注：</span>
                            <textarea id="textRemaker" runat="server" rows="3" style="float: left; width: 748px;"></textarea>
                    </div>
                    <!--备注结束-->
                    <div style="width: 880px; text-align: center; clear: left;">
                        <asp:Button ID="BookAddButton" runat="server" Text="预定"  class="orangeBtn midBtn" OnClientClick = "return checkForm(this)"/>  
                        <input name="关　闭" type="button" value="关　闭" class="grayBtn midBtn" onclick="Close1();"/>
                    </div>
                    <!--按纽结束-->
      <input type="hidden" id="RoomType" runat="server" />



<iframe name="if1" class="frames" frameborder="0" width="300px;" height="500px" scrolling="no"></iframe>



    </form>
    <br />
    <div class="clearboth">
    </div>
    <div class="mo"></div>
    <div class="diog" >
       <div class="diogTop">
          房号预分
       </div>
       <div class="diogText" style=" height: 350px; overflow:auto;">
       <table class="tableGray" style="border-left:none;border-right:none;border-bottom:1px solid #cdcdcd">
        <thead>
            <tr style="background:#8FB8D6;text-align:center" >
             <td><input type="checkbox" class="chkAll" /></td>
             <td>房型</td>
             <td>房号</td>
             <td>价格</td>
            </tr></thead>

            <tbody id="tblist">
            </tbody>
            
       </table>
         

        

        
       </div>

       <div class="btns" style="text-align:center">
         <input type="button" value="确定" class="greenBtn btnOk"/><input type="button" value="取消" class="grayBtn btnchech" />
       </div>

      
    </div>
   <div class="ac_results" style="position: absolute; width: 420px;  top: 70px;left: 75px;">
        <ul style="max-height: 180px; overflow: auto;">
        </ul>
    </div>
</body>
</html>
