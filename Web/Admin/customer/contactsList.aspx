<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="contactsList.aspx.cs" Inherits="CdHotelManage.Web.Admin.customer.contactsList" %>

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
        })

        function Addcustomer(obj) {
            var url = "addContact.aspx?type=add&accounts=" + $("#accounts").val();
           
            showMyWindow("添加联系人", url, 650, 300, true, true, true);
        }

        function customerEdit(obj, id) {
            var url = "addContact.aspx?type=edit&accounts=" + $("#accounts").val() + "&id=" + id;
            
            showMyWindow("编辑客户", url, 650, 300, true, true, true);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
      <input type="hidden" id="accounts" runat="server"/>
       <div class="main" style="width: 98%; margin-left: 1%;">
      <div style="width: 100%; float: left; margin-top:20px;">
            <table cellpadding="0" cellspacing="0" class="vip_member" id="tblgood" style="width: 100%">
                <tbody>
                    <th width="8%">姓名</th>
                    <th width="6%">性别</th>
                    <th width="7%">生日</th>
                    <th width="8%">称呼</th>
                    <th width="8%">部门</th>
                    <th width="5%">职务</th>
                    <th width="5%">办公电话</th>
                    <th width="7%">移动电话</th>
                    <th width="7%">家庭电话</th>
                    <th width="5%">Eamil</th>
                    <th width="10%">操作</th>
                </tbody>
                <asp:Repeater runat="server" ID="rep1">
                  <ItemTemplate>
                   <tr>
                     <td width="8%"><%#Eval("cName")%></td>
                    <td width="6%"><%#GetSex(Convert.ToBoolean(Eval("Sex")))%></td>
                    <td width="7%"><%#Eval("Bearthday")%></td>
                    <td width="8%"><%#GetCall( Convert.ToInt32(Eval("Appellation")))%></td>
                    <td width="8%"><%#GetDepartment(Convert.ToInt32(Eval("department")))%></td>
                    <td width="5%"><%#GetPost( Convert.ToInt32(Eval("Post")))%></td>
                    <td width="5%"><%#Eval("officPhone")%></td>
                    <td width="7%"><%#Eval("Phone")%></td>
                    <td width="7%"><%#Eval("familyPhone")%></td>
                    <td width="5%"><%#Eval("Mail")%></td>
                    <td width="10%">
                     <a href="#" onclick="customerEdit(this,<%#Eval("ID")%>)">编辑</a>
                     <a href="#">删除</a>
                    </td>
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
