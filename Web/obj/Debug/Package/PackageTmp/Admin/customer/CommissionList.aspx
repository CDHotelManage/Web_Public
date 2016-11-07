<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CommissionList.aspx.cs" Inherits="CdHotelManage.Web.Admin.customer.CommissionList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/Admin/css/tch.css" rel="stylesheet" type="text/css" />
    <link href="/Admin/css/main.css" rel="stylesheet" type="text/css" />
    <script src="/calendar/WdatePicker.js" type="text/javascript"></script>
    <script src="/Admin/js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="/js/DivWH.js" type="text/javascript"></script>
    <link href="/style/Opendiv.css" rel="stylesheet" type="text/css" />
    <script src="/Admin/js/base.js" type="text/javascript"></script>
    <style type="text/css">
     .main .w120{ width:120px;}
      .div_win_center iframe{ border:none}
    table tr td{  border-left: 1px #ddd solid;}
    </style>
    <script type="text/javascript">
        $(function () {

        })
        function Addcustomer(obj) {
            var ids = "";
            $(".vip_member").find("tbody").eq(1).find("tr").each(function () {
                if ($(this).find(".chk").attr("checked")) {
                    ids += $(this).find(".hidis").val() + ",";
                }
            })
            if (ids == "") {
                alert("请选择佣金!!");
            }
            else {
                ids = ids.substring(0, ids.length - 1);
                var url = "JsComm.aspx?account=" + $("#accoun").val() + "&ids=" + ids;
               
                showMyWindow("结算佣金", url, 280, 310, true, true, true);
            }
           
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" runat="server" id="accoun" />
     <div class="main" style="width: 98%; margin-left:1%;">
     <div class="ftt_search fontYaHei">
            <label>日期：</label>
            <input type="text" class="w120" onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss',onpicked:function() {AddDay()}})"/><label >到</label><input type="text" class="w120" onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss',onpicked:function() {AddDay()}})" />
            <label style="margin-left: 20px;">反佣：</label>
           <asp:DropDownList runat="server" ID="DDLBack">
             <asp:ListItem Value="-1">全部</asp:ListItem>
             <asp:ListItem Value="0">未反佣</asp:ListItem>
             <asp:ListItem Value="1">反佣</asp:ListItem>
           </asp:DropDownList>
            <input type="button"  id="btnQuery" class="qtantj" runat="server" onserverclick="btnQuery_Click" value="查询" />
        </div>
      <div style="width: 100%; float: left;">
            <table cellpadding="0" cellspacing="0" class="vip_member" id="tblgood" style="width: 100%">
                <tbody>
                    <th width="8%">选择</th>
                    <th width="8%">帐号</th>
                    <th width="6%">客户名称</th>
                    <th width="7%">计佣日期</th>
                    <th width="8%">佣金总额</th>
                    <th width="8%">是否反佣</th>
                    <th width="5%">单据号</th>
                    <th width="5%">是否每日计佣</th>
                    <th width="7%">单日佣金</th>
                    <th width="7%">备注</th>
                </tbody>
                <asp:Repeater runat="server" ID="rep1">
                  <ItemTemplate>
                   <tr acc="<%#Eval("accounts") %>">
                     <td><%#GetISok(Convert.ToBoolean(Eval("IsBack")))%><input type="hidden" class="hidis" value="<%#Eval("ID") %>" /></td>
                     <td width="8%"><%#Eval("accounts")%></td>
                     <td width="6%"><%#GetAuuoctn(Eval("accounts").ToString())%></td>
                     <td width="7%"><%#Eval("CommDate")%></td>
                     <td width="8%"><%#Eval("CommSum")%></td>
                     <td width="8%"><%#GetComm(Convert.ToBoolean(Eval("IsBack")))%></td>
                     <td width="5%"><%#Eval("GoodNumber")%></td>
                     <td width="5%"><%#GetComm1( Convert.ToBoolean(Eval("IsEveryDay")))%></td>
                     <td width="7%"><%#Eval("DayComm")%></td>
                     <td width="7%"><%#Eval("CommRemark")%></td>
                   </tr>
                  </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
        <div class="vip_db" style="margin-left: 0px; width: 100%">
                <div class="fl">
                    <input type="button" value="反佣处理" class="bus_add" id="MemberCard" onclick="Addcustomer(this)" />
                   
                </div>
            </div>
    </div>
    </form>
</body>
</html>
