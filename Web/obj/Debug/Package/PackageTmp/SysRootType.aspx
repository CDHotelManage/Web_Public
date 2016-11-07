<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SysRootType.aspx.cs" Inherits="CdHotelManage.Web.SysRootType" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
     #sysroomType{ width:500px; margin:0 auto;border-collapse:collapse; border:1px solid #ececec;}
     #sysroomType td,#sysroomType th{ text-align:center; border:1px solid #ececec; padding:5px 10px; height:26px; line-height:26px;}
     .txt1{ width:80px; display:none;height:26px; line-height:26px; width:60px;}
     .span1{ display:block; width:60px; height:26px; line-height:26px;}
    </style>
    <script src="js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">

       
        function A() {
            $("#sysroomType td").hover(function () {
                $(this).find(".span1").css("border", "1px solid #dcdcdc");
            }, function () {
                $(this).find(".span1").css("border", "none");
            })
            $.ajaxSetup({
                async: false
            }); 
            $(".span1").click(function () {
                var txt = $(this).text();
                $(this).css("display", "none");
                $(this).next().css("display", "block");
                $(this).next().focus();
                $(this).next().val(txt);
            })
            $(".txt1").blur(function () {
                var txt = $(this).val();
                $(this).css("display", "none");
                $(this).prev().css("display", "block");
                $(this).prev().text(txt);
                var trs = $(this).parent().parent();
                var delst = "typeroom=" + trs.attr('typeroom') + "&Earlyapart=" + trs.find(".span1").eq(0).text() + "&EarlyapartAddP=" + trs.find(".span1").eq(1).text() + "&EarlyInExceed=" + trs.find(".span1").eq(2).text() + "&EarlyInAddPri=" + trs.find(".span1").eq(3).text() + "";
                $.get("/Admin/Ajax/SysPara.ashx?r=" + Math.random(), delst + "&type=upd", function (obj) {
                    if (obj == "err") {
                        alert("请输入正确的数据类型");
                        window.location.reload();
                    }
                }, "text");
            })
//            $("#btnOk").click(function () {


//                var trs = $(this).parent().parent();
//                if (!isNaN(trs.find(".span1").eq(1).text()) && !isNaN(trs.find(".span1").eq(2).text()) && !isNaN(trs.find(".span1").eq(3).text()) && !isNaN(trs.find(".span1").eq(4).text())) {
//                    var TypeRoom = trs.find(".span1").eq(0).text();
//                    var typeid = 0;
//                    $.get("/Admin/Ajax/SysPara.ashx?r=" + Math.random(), "TypeRoom=" + TypeRoom + "&type=add1", function (obj) {
//                        switch (obj.statu) {
//                            case "ok":
//                                typeid = obj.data;
//                                break;
//                            default:

//                        }
//                    }, "json");

//                    var delst = "TypeRoom=" + typeid + "&Earlyapart=" + trs.find(".span1").eq(1).text() + "&EarlyapartAddP=" + trs.find(".span1").eq(2).text() + "&EarlyInExceed=" + trs.find(".span1").eq(3).text() + "&EarlyInAddPri=" + trs.find(".span1").eq(4).text() + "";
//                    $.get("/Admin/Ajax/SysPara.ashx?r=" + Math.random(), delst + "&type=add", function (obj) {
//                        switch (obj.statu) {
//                            case "ok":
//                                window.location.reload();
//                                break;
//                            default:

//                        }
//                    }, "json");
//                } else {
//                    alert("不是数字");
//                }


//            })
        }
        $(function () {
            A();

//            $("#btnAdd").click(function () {
//                var trs = $("#sysroomType tr");
//                var txt = trs.eq(trs.length - 1).html();
//                trs.eq(trs.length - 1).after("<tr type='add'><td ><span class=\"span1\"></span><input type=\"text\" class=\"txt1\" /></td><td ><span class=\"span1\"></span><input type=\"text\" class=\"txt1\" /></td><td ><span class=\"span1\"></span><input type=\"text\" class=\"txt1\" /></td><td ><span class=\"span1\"></span><input type=\"text\" class=\"txt1\" /></td><td ><span class=\"span1\"></span><input type=\"text\" class=\"txt1\" /><input type=\"button\" id=\"btnOk\" value=\"确定\"></td></tr>");
//                A();

//            })
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <table id="sysroomType">
     <tr>
      <th>房间类型</th>
      <th>加钟时间</th>
      <th>加钟价格</th>
      <th>最小时长</th>
      <th>最小价格</th>
     </tr>
     <asp:Repeater ID="rp1" runat="server">
     <ItemTemplate>
     <tr TypeRoom="<%#Eval("TypeID") %>">
      <td >
      <%#GetName(Convert.ToInt32(Eval("TypeID")))%>
      </td>
      <td>
      <span class="span1"><%#Eval("Earlyapart") %></span><input type="text" class="txt1" />
      </td>
      <td>
      <span class="span1"><%#Eval("EarlyapartAddP")%></span><input type="text" class="txt1" />
      </td>
      <td>
      <span class="span1"><%#Eval("EarlyInExceed")%></span><input type="text" class="txt1" />
      </td>
      <td>
      <span class="span1"><%#Eval("EarlyInAddPri")%></span><input type="text" class="txt1" />
      </td>
     </tr>
     </ItemTemplate>
     </asp:Repeater>
    </table>
    </form>
</body>
</html>
