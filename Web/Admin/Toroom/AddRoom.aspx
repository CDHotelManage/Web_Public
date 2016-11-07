<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddRoom.aspx.cs" Inherits="CdHotelManage.Web.Admin.Toroom.AddRoom" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>房间合并</title>
    <style type="text/css">
      .yhbtalbe{  border-collapse: collapse; width:100%;  border: 1px solid #ececec;}
      .yhbtalbe td{ border: 1px solid #ececec;}
    </style>
    <script src="../../js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function isFill() {
            if ($(".yhbtalbe input:checkbox:checked").length > 0) {
                return true;
           }
            else {
                alert("至少选择一项");
                return false;
           }
        }
        function Close() {
            parent.Window_Close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" runat="server" id="orderid"/>
    <input type="hidden" runat="server" id="loadRoom"/>
      <table class="yhbtalbe">
       <tr>
        <td>选择</td>
        <td>房号</td>
        <td>房价</td>
       </tr>
       <asp:Repeater ID="rep" runat="server">
           <ItemTemplate>
               <tr>
                   <td>
                   <asp:CheckBox runat="server" ID="cbk" />
                   <asp:HiddenField ID="hidId" Value='<%# Eval("occ_id")%>' runat="server" />
                   </td>
                   <td>
                       <%#Eval("room_number") %>
                   </td>
                   <td>
                       <%#Eval("real_price") %>
                   </td>
               </tr>
           </ItemTemplate>
       </asp:Repeater>
      </table> 
      <input type="submit" value="确认合并" class="BtnOk" onclick="return isFill();" runat="server" onserverclick="BtnOk_Click" />
      <input type="button" value="关闭" class="BtnEarch" onclick="Close()">
    </form>
</body>
</html>
