<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="accountlist.aspx.cs" Inherits="CdHotelManage.Web.Admin.Toroom.accountlist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/tch.css" rel="stylesheet" type="text/css" />
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {

        })

        function BtnClick() {
            var html = "";
            $("#tb tr").each(function () {
                if ($(this).find("input").attr("checked")) {
                    html += "<tr>" + $(this).html() + "</tr>";
                }
            })
            parent.document.getElementById("tblistacc").innerHTML = html;
            parent.Window_Close();
        }
    </script>
    
</head>
<body>
    <form id="form1" runat="server">
    <table id="tb">
      <tr>
       <th>选择</th>
       <th>房间号</th>
       <th>费用名称</th>
       <th>金额</th>
       <th>发生时间</th>
       <th>备注</th>
      </tr>
      <asp:Repeater ID="rep1" runat="server">
      <ItemTemplate>
        <tr>
           <td><input type="checkbox" class="chk" /></td>
           <td><input type="hidden" class="chkID" value=<%#Eval("id") %> /><%#Eval("Ga_roomNumber")%></td>
           <td><%#Eval("Ga_name")%></td>
           <td><%#Eval("ga_sum_price")%></td>
           <td><%#Eval("ga_date")%></td>
           <td><%#Eval("ga_remker")%></td>
        </tr>
        </ItemTemplate>
      </asp:Repeater>
    </table>
     <div class="types">
            <ul style="float: right; width: 274px">
                <li style=" float:left; margin-right:10px;">
                    <input type="button" class="bus_add " id="BtnSave" onclick="return BtnClick();" value="确认" runat="server"  /></li>
                <li style="margin-right: 0px">
                    <input type="button" class="bus_dell" onclick="Close()" id="BtnDel" value="关闭" style="margin-right: 0px" /></li>
            </ul>
        </div>
    </form>
</body>
</html>
