<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsList.aspx.cs" Inherits="CdHotelManage.Web.Admin.customer.GoodsList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/Admin/css/tch.css" rel="stylesheet" type="text/css" />
    <link href="/Admin/css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="divMain" style="overflow: auto;">
        <div>
            <table cellspacing="0" rules="all" border="1" id="GridView1" style="width: 100%;
                border-collapse: collapse;">
                <tbody>
                    <tr class="cart-data">
                        <th scope="col">
                            消费名称
                        </th>
                        <th scope="col">
                            消费金额
                        </th>
                        <th scope="col">
                            操作人
                        </th>
                        <th scope="col">
                            入账日期
                        </th>
                        <th scope="col">
                            备注
                        </th>
                    </tr>
                    <asp:Repeater ID="rep1" runat="server">
                    <ItemTemplate>
                        <tr>
                           <td><%#Eval("ga_name")%></td>
                           <td><%#Eval("ga_sum_price")%></td>
                           <td><%#GetUserName(Eval("ga_people").ToString())%></td>
                           <td><%#Eval("ga_date")%></td>
                           <td><%#Eval("ga_remker")%></td>
                        </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
            </div>
    </form>
</body>
</html>
