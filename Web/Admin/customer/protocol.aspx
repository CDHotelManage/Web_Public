<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="protocol.aspx.cs" Inherits="CdHotelManage.Web.Admin.customer.protocol" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <link href="../css/tch.css" rel="stylesheet" type="text/css" />
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <script src="../../js/DivWH.js" type="text/javascript"></script>
    <link href="../../style/Opendiv.css" rel="stylesheet" type="text/css" />
    <script src="../js/base.js" type="text/javascript"></script>
    <style type="text/css">
      table th{ font-size:12px;}
               .div_win_center iframe{ border:none}
    table tr td{  border-left: 1px #ddd solid;}
    </style>
    <script type="text/javascript">
        function Addcustomer(obj) {
            var url = "addProtocol.aspx?type=add&accounts=" + $("#accounts").val();
            showMyWindow("添加协议方案", url, 700, 600, true, true, true);
        }
        function Modeficustomer(obj, id) {
            var url = "addProtocol.aspx?type=edit&accounts=" + $("#accounts").val() + "&id=" + id;
            showMyWindow("修改协议方案", url, 700, 600, true, true, true);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" id="accounts" runat="server"/>
    
    <div class="main" style="width: 98%; margin-left: 1%;">
      <div style="width: 100%; float: left; height:100%; margin-top:20px;">
            <table cellpadding="0" cellspacing="0" class="vip_member" id="tblgood" style="width: 100%">
                <tbody>
                    <th width="7%">客户协议编号</th>
                    <%--<th width="6%">协议状态</th>--%>
                    <th width="10%">协议项目种类</th>
                    <th width="7%">协议主题</th>
                    <th width="8%">客户签约人</th>
                    <th width="8%">本公司签约人</th>
                    <th width="5%">房间号</th>
                    <th width="7%">协议单号</th>
                    <th width="7%">签约时间</th>
                    <th width="5%">有效期至</th>
                    <th width="3%">折扣值</th>
                    <%--<th width="5%">审核人</th>
                    <th width="5%">审核时间</th>--%>
                    <th width="5%">操作人</th>
                    <th width="10%">操作</th>
                </tbody>
                <asp:Repeater runat="server" ID="rep1">
                  <ItemTemplate>
                      <tr>
                          <td width="3%">
                              <%#Eval("ID")%>
                          </td>
                          <%--<td width="6%">
                              <%#Eval("isVerify")%>
                          </td>--%>
                          <td width="10%">
                              <%#GetTypeName( Convert.ToInt32(Eval("pType")))%>
                          </td>
                          <td width="7%">
                               <%#Eval("Ptheme")%>
                          </td>
                          <td width="8%">
                               <%#Eval("signatory")%>
                          </td>
                          <td width="8%">
                               <%#Eval("companysignatory")%>
                          </td>
                          <td width="5%">
                               <%#Eval("roomNumber")%>
                          </td>
                          <td width="7%">
                              <%#Eval("PNumber")%>
                          </td>
                          <td width="7%">
                              <%#Convert.ToDateTime(Eval("term")).ToString("yyyy-MM-dd")%>
                          </td>
                          <td width="5%">
                                <%#Convert.ToDateTime(Eval("period")).ToString("yyyy-MM-dd")%>
                          </td>
                          <td width="3%">
                              <%#Eval("discount")%> 
                          </td>
                          <%--<td width="5%">
                               <%#Eval("verifyUser")%>
                          </td>
                          <td width="5%">
                             
                          </td>--%>
                          <td width="5%">
                               <%#GetUser(Eval("editUser").ToString())%>
                          </td>
                          <td width="10%">
                              <a href="#" onclick="Modeficustomer(this,<%#Eval("ID")%>)">编辑</a>
                              <a href="#">删除</a>
                          </td>
                      </tr>
                  </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
        <div class="vip_db" style="margin-left: 0px; width: 100%">
                <div class="fl">
                    <input type="button" value="新增协议" class="bus_add" id="MemberCard" onclick="Addcustomer(this)" />
                </div>
            </div>
    </div>
    </form>
</body>
</html>
