<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="methpay.aspx.cs" Inherits="CdHotelManage.Web.Admin.Menus2.methpay" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/tch.css" rel="stylesheet" type="text/css" />
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <style type="text/css">
        .txt1{ display:none;height:26px; line-height:26px;}
     .span1{ display:block; height:26px; line-height:26px;}
    </style>
    <script type="text/javascript">
        $(function () {
            BindClick();
        })
        $.ajaxSetup({
            async: false
        });
        function BindClick() {
            $(".tds").hover(function () {
                $(this).find(".span1").css("border", "1px solid #dcdcdc");
            }, function () {
                $(this).find(".span1").css("border", "none");
            })

            $(".span1").click(function () {
                var txt = $(this).text();
                $(this).css("display", "none");
                $(this).next().css("display", "inline-block");
                $(this).next().focus();
                $(this).next().val(txt);
            })


            $(".txt1").blur(function () {
                var txt = $(this).val();
                var trnow = $(this).parent().parent();
                $(this).css("display", "none");
                $(this).prev().css("display", "inline-block");
                $(this).prev().text(txt);
                var txt = trnow.find("td").eq(0).text();
                var sort = trnow.find("td").eq(3).text();
                var remark = trnow.find("td").eq(4).text();
                var id = trnow.attr("ids");
                $.get("/admin/ajax/customer.ashx", "type=iscz&txt=" + txt, function (obj) {
                    if (obj != "err") {

                        $.get("/admin/ajax/customer.ashx", "type=uptr&id=" + id + "&txt=" + txt + "&sort=" + sort + "&remark=" + remark, function (obj) {
                            if (obj != "err") {
                                window.location.reload();
                            }
                        }, "text");
                    }
                    else {
                        alert("已经存在该支付方式！");
                        window.location.reload();
                    }
                }, "text");

            })
        }

        function Del(id) {
            if (confirm("是否确定删除?")) {
                $.get("/admin/ajax/customer.ashx", "type=isDel&id=" + id, function (obj) {
                    if (obj == "ok") {
                        alert("删除成功！");
                        window.location.reload();
                    }
                    else if (obj == "err") {
                        alert("该支付方式正在使用，不能删除！");
                    }

                }, "text");
            }
        }

        function QieHuan(objs,id) {
            $.get("/admin/ajax/customer.ashx", "type=upYaj&id=" + id, function (obj) {
                if (obj == "err") {
                    alert("切换错误!");
                }
                else {
                    if ($(objs).find("img").attr("src") == "/images/yes.gif") {
                        $(objs).find("img").attr("src", "/images/no.gif");
                    }
                    else {
                        $(objs).find("img").attr("src", "/images/yes.gif");
                    }
                }
            }, "text");
        }

        function Add() {
            var trhtml = $(".tabel1 tr").eq($(".tabel1 tr").length - 1).html();
            $(".tabel1 tr").eq($(".tabel1 tr").length - 1).after("<tr>" + trhtml + "</tr>");
            $(".tabel1 tr").eq($(".tabel1 tr").length - 1).attr("ids", "0");
            BindClick();
        }

        function QieHuan1(objs, id) {
            $.get("/admin/ajax/customer.ashx", "type=upJie&id=" + id, function (obj) {
                if (obj == "err") {
                    alert("切换错误!");
                }
                else {
                    if ($(objs).find("img").attr("src") == "/images/yes.gif") {
                        $(objs).find("img").attr("src", "/images/no.gif");
                    }
                    else {
                        $(objs).find("img").attr("src", "/images/yes.gif");
                    }
                }
            }, "text");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <table class="tabel1">
      <tr>
        <th>支付方式</th>
        <th>是否用于押金付款</th>
        <th>是否用于结账付款</th>
        <th>显示顺序</th>
        <th>备注</th>
        <th>编辑</th>
      </tr>
        <asp:Repeater ID="rep1" runat="server">
            <ItemTemplate>
                <tr ids="<%#Eval("meth_pay_id")%>">
                  <td class="tds"><span class="span1"><%#Eval("meth_pay_name")%></span><input type="text" class="txt1" /></td>
                  <td><a onclick="QieHuan(this,<%#Eval("meth_pay_id")%>)" title="点击切换"><%#GetIsOk(Convert.ToBoolean(Eval("meth_is_ya")))%></a></td>
                  <td><a onclick="QieHuan1(this,<%#Eval("meth_pay_id")%>)" title="点击切换"><%#GetIsOk(Convert.ToBoolean(Eval("meth_is_jie")))%></a></td>
                  <td class="tds"><span class="span1"><%#Eval("meth_sort")%></span><input type="text" class="txt1" /></td>
                  <td class="tds"><span class="span1"><%#Eval("remark")%></span><input type="text" class="txt1" /></td>
                  <td><a href="#" onclick="Del(<%#Eval("meth_pay_id")%>)">删除</a></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <input type="button" value="增加" class="bus_add" onclick="Add()"/>
    </form>
</body>
</html>
