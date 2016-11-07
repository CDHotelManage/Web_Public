<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Transfer.aspx.cs" Inherits="CdHotelManage.Web.Admin.customer.Transfer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/Admin/css/stylebyzz.css" rel="stylesheet" type="text/css" />
    <link href="/Admin/css/mainzz.css" rel="stylesheet" type="text/css" />
    <link href="/style/Opendiv.css" rel="stylesheet" type="text/css" />
    <script src="/Admin/js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="/js/DivWH.js" type="text/javascript"></script>
    <link href="/Admin/css/main.css" rel="stylesheet" type="text/css" />
    <script src="/Admin/js/base.js" type="text/javascript"></script>
    <style type="text/css">
       body .tablelist tr.lihover{ background:#FBE889;}
       body .tablelist tr.cbox{ background:#FBE889;}
       body table{ border:none;}
      body table td{border:none;}
       .tablelist table{border-collapse:collapse}
    </style>
    <script type="text/javascript">
        $(function () {
            BindClor();
        })

        function BindClor() {
            $(".tablelist tr").hover(function () {
                $(".tablelist tr").removeClass("lihover");
                $(this).addClass("lihover");
            })
            $(".tablelist tr").click(function () {
                $(".tablelist tr").removeClass("cbox");
                $(this).addClass("cbox");
            })
        }

        function AllRight() {
            if ($(".tablelistLeft tbody").eq(1).find("tr").length > 0) {
                $(".tablelistRigth table").html($(".tablelistLeft tbody").eq(1).html());
                $(".tablelistLeft tbody").eq(1).html("");
                BindClor();
            }
        }

        function AllLeft() {
            if ($(".tablelistRigth table tr").length > 0) {
                $(".tablelistLeft tbody").eq(1).html($(".tablelistRigth tbody").html());
                $(".tablelistRigth table").html("");
                BindClor();
            }
        }

        function Rigth() {
            var trs = $(".tablelistLeft .cbox").html();
            if ($(".tablelistRigth tr").length == 0) {
                $(".tablelistRigth table").html("<tr>" + trs + "</tr>");
            }
            else {
                $(".tablelistRigth tr").eq($(".tablelistRigth tr").length - 1).after("<tr >" + trs + "</tr>");
            }
            $(".tablelistLeft .cbox").remove();
            BindClor();
        }

        function Left() {
            var trs = $(".tablelistRigth .cbox").html();
            if ($(".tablelistLeft tr").length == 0) {
                $(".tablelistLeft table").html("<tr>" + trs + "</tr>");
            }
            else {
                $(".tablelistLeft tr").eq($(".tablelistLeft tr").length - 1).after("<tr >" + trs + "</tr>");
            }
            $(".tablelistRigth .cbox").remove();
            BindClor();
        }

        function Xy(obj) {
            if ($(obj).attr("src") == "../images/clear.jpg") {
                $("#customer").val("");
                $("#CpId").val("");
                $("#accounts").val("");
                $(obj).attr("src", "../Images/search.jpg")
            }
            else {
                var url = "/admin/Toroom/customerList1.aspx?type=selectCou&not=" + $("#account").val();;
                
                showMyWindow("选择客户", url, 1000, 560, true, true, true);
            }
        }

        function Addcustomer() {
            if ($("#accounts").val() == "") {
                alert("请选择目标客户！！");
                return false;
            }
            else if ($(".tablelistRigth tr").length <= 0) {
                alert("请选择帐！");
                return false;
            }
            else {
                var goods = "";
                $(".tablelistRigth tr").each(function () {
                    goods += "'" + $(this).find(".ids").val() + "',";
                })
                goods = goods.substring(0, goods.length - 1);
                $("#goodnos").val(goods);
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" id="account" runat="server"/>
    <input type="hidden" id="goodnos" runat="server" />
    <table width="90%" id="linkgoods-table" style="display: table;" align="center">
          
          <tbody>
          <tr>
            <th>未结账费用</th>
            <th>操作</th>
            <th style=" text-align:left;">客户名称：<input type="text" id="accnames" /><img src="../Images/search.jpg" id="imgicos" onclick="Xy(this)" style="  vertical-align: bottom;">
                        <input type="hidden" id="accounts" runat="server" />
                        <input type="hidden" id="CpId" runat="server"/>
            </th>
          </tr>
          <tr>
            <td width="42%">
              <div class="tablelist tablelistLeft"style=" width:100%; height:322px;">
              <table>
              <tbody>
              <tr>
                <th>日期</th>
                <th>帐号</th>
                <th>客户名称</th>
                <th>房号</th>
                <th>金额</th>
                <th>备注</th>
              </tr>
              </tbody>
                <%=sbtext.ToString() %>
              </table>
              </div>
            </td>
            <td align="center" style=" width:5%;">
              <p><input type="button" value=">>" onclick="AllRight()" class="button"></p>
              <p><input type="button" value=">" onclick="Rigth()" class="button"></p>
              <p><input type="button" value="<" onclick="Left()" class="button"></p>
              <p><input type="button" value="<<" onclick="AllLeft()" class="button"></p>
            </td>
            <td width="42%">
            <div class="tablelist tablelistRigth" style=" width:100%; height:322px;">
              <table>
                
              </table>
             </div>
            </td>
          </tr>
        </tbody></table>
        <div class="vip_db" style="margin-left: 0px; width: 100%">
                <div class="fl">
                    <input type="submit" value="转帐" class="bus_add" id="MemberCard" runat="server" style=" display:block;" onclick="return Addcustomer();" onserverclick="MemberCard_Click" >
                </div>
            </div>
    </form>
</body>
</html>
