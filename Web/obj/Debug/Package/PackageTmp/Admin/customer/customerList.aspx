<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="customerList.aspx.cs" Inherits="CdHotelManage.Web.Admin.customer.customerList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <link href="../css/tch.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../../js/DivWH.js" type="text/javascript"></script>
    <link href="../../style/Opendiv.css" rel="stylesheet" type="text/css" />
    <script src="/Admin/js/base.js" type="text/javascript"></script>
    <style type="text/css">
    .div_win_center iframe{ border:none}
    table tr td{  border-left: 1px #ddd solid;}
    body .vip_member tr.lihover{ background:#FBE889;}
    body .vip_member tr.cbox{ background:#FBE889;}
    </style>
    <script type="text/javascript">
        $(function () {
            $(".vip_member tbody tr").hover(function () {
                $(".vip_member tbody tr").removeClass("cbox");
                $(this).addClass("cbox");
            })
            $(".vip_member tbody tr").click(function () {
                $(".vip_member tbody tr").removeClass("lihover");
                $(this).addClass("lihover");
            })
            $(".vip_member tbody tr").dblclick(function () {
                var accous = $(this).attr("acc");
                window.location.href = "custromerDestic.aspx?accounts=" + accous;
            })
        })
        function Addcustomer(obj) {
            var url = "addCustomer.aspx?type=add";
           
            showMyWindow("添加客户", url, 870, 300, true, true, true);
        }

        function customerEdit(obj, id) {
            var url = "addCustomer.aspx?type=edit&accounts=" + id;
           
            showMyWindow("编辑客户", url, 870, 400, true, true, true);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="main" style="width: 98%; margin-left: 1%;">
    <div class="ftt_search fontYaHei">
        <label>条件：</label>
        <input type="text" runat="server" style=" width:250px;" id="Word" placeholder="请输入客户名称/帐号/联系电话/公司电话" onfocus="Focus()"/>
        <label>客户类型：</label>
        <asp:DropDownList runat="server" ID="cusType"  CssClass="txt" AutoPostBack="true" OnSelectedIndexChanged="cusTypechange" style=" width:85px;"></asp:DropDownList>
        <label>客户状态：</label>
        <asp:DropDownList runat="server" ID="Cstate" CssClass="txt" AutoPostBack="true" OnSelectedIndexChanged="cusTypechange"   style=" width:85px;"></asp:DropDownList>
        <label>所属行业：</label>
        <asp:DropDownList runat="server" ID="cIndustry" CssClass="txt" AutoPostBack="true" OnSelectedIndexChanged="cusTypechange"  runat="server" style=" width:85px;"></asp:DropDownList>
        <label>客户来源：</label>
       <asp:DropDownList runat="server" ID="Csource" CssClass="txt" AutoPostBack="true" OnSelectedIndexChanged="cusTypechange"  runat="server" style=" width:85px;"></asp:DropDownList>
       <label> <input type="button" class="qtantj " id="Button3" value="查询" runat="server"  onserverclick="Button3_Click" /></label>
        </div>
      <div style="width: 100%; float: left;">
            <table cellpadding="0" cellspacing="0" class="vip_member" id="tblgood" style="width: 100%">
                <tbody>
                    <th width="8%">帐号</th>
                    <th width="6%">客户名称</th>
                    <th width="7%">客户状态</th>
                    <th width="8%">客户类型</th>
                    <th width="8%">客户编号</th>
                    <th width="5%">客户行业</th>
                    <th width="5%">主联系人</th>
                    <th width="7%">联系电话</th>
                    <th width="7%">公司电话</th>
                    <th width="5%">传真</th>
                    <th width="8%">地区</th>
                    <th width="5%">Email</th>
                    <th width="5%">邮编</th>
                    <th width="10%">操作</th>
                </tbody>
                <asp:Repeater runat="server" ID="rep1">
                  <ItemTemplate>
                   <tr acc="<%#Eval("accounts") %>">
                     <td><%#Eval("accounts")%></td>
                     <td><%#Eval("cName")%></td>
                     <td><%#GetState(Convert.ToInt32(Eval("Cstate")))%></td>
                     <td><%#GetCtName(Convert.ToInt32(Eval("cusType")))%></td>
                     <td><%#Eval("cusNumber")%></td>
                     <td><%#GetIdName(Convert.ToInt32(Eval("cindustry")))%></td>
                     <td><%#Eval("contacts")%></td>
                     <td><%#Eval("cPhone")%></td>
                     <td><%#Eval("companyPhone")%></td>
                     <td><%#Eval("Fax")%></td>
                     <td><%#Eval("area")%></td>
                     <td><%#Eval("Email")%></td>
                     <td><%#Eval("ybNum")%></td>
                     
                     <td><a href="#" onclick="customerEdit(this,'<%#Eval("accounts")%>')">编辑</a> <a href="#">删除</a></td>
                   </tr>
                  </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
        <div class="vip_db" style="margin-left: 0px; width: 100%">
                <div class="fl">
                    <input type="button" value="添加客户" class="bus_add" id="MemberCard" onclick="Addcustomer(this)" />
                   
                </div>
            </div>
    </div>
    </form>
</body>
</html>
