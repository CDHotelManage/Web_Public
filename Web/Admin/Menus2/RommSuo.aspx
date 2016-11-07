<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RommSuo.aspx.cs" Inherits="CdHotelManage.Web.Admin.Menus2.RommSuo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/tch.css" rel="stylesheet" type="text/css" />
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <style type="text/css">
       .leftdiv{ width:70%; float:left; height:350px; overflow-y:scroll;}
       #tblist{  border-collapse: collapse; width:100%; font-size:12px;}
       #tblist td{ border:1px solid #cdcdcd; padding:4px 7px;}
       #tblist th{ border:1px solid #cdcdcd;}
       .suonumber{ width:50px; margin:0; padding:0;}
       .rigthdiv{ width:30%; float:left;}
    </style>
    <script type="text/javascript">
        $(function () {
            $(".suonumber").blur(function () {
                var txt = $(this).val();
                var tr = $(this).parent().parent();
                var typeroom = $("#txt").val();
                var roomnu = tr.find("td").eq(0).text();
                $.get("/admin/ajax/SysPara.ashx", "type=uproom&txt=" + txt + "&room=" + roomnu.trim() + "&typeroom=" + typeroom, function (obj) {

                }, "text");
            })
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" id="txt" runat="server" />
     <div class="leftdiv">
        <table id="tblist">
         <tr>
           <th>房号</th>
           <th>楼栋</th>
           <th>楼层</th>
           <th>锁号</th>
         </tr>
         <asp:Repeater ID="rep1" runat="server">
           <ItemTemplate>
               <tr>
                   <td>
                       <%#Eval("Rn_roomNum")%>
                   </td>
                   <td>
                       <%#Eval("Rn_flloeld")%>
                   </td>
                   <td>
                   <%#Eval("Rn_floor")%>
                   </td>
                   <td>
                     <%#GetSuoma(Eval("Rn_roomNum").ToString())%>
                   </td>
               </tr>
           </ItemTemplate>
         </asp:Repeater>
        </table>
     </div>
     <div class="rigthdiv">
        <input type="checkbox" id="IsComm" runat="server"/>是否可以开公共门<br />
        <input type="checkbox" id="IsBackSuo" runat="server" />是否可以开反锁
     </div>
     <div style="clear:both;"></div>
     <div class="types">
            <ul style="float: right; width: 100%; margin-top:15px;">
                <li id="ShowFee" style="display:none;">
                    <input name="NoCardFee" type="checkbox" id="NoCardFee" class="inps" value="1" onchange="BtnCardFee()" style="border: 0px; margin-top: 6px">&nbsp;免卡费
                </li>
                <li style=" float:left;">
                    <input name="BtnSave" type="submit" id="BtnSave" class="bus_add " value="确定" runat="server" onserverclick="BtnSave_Click">
                </li>
                <li style="margin-right: 0px; float:left;">
                    <input type="button" id="BtnDel" class="bus_dell " onclick="Close()" value="关闭" style="margin-right: 0px">
                </li>
            </ul>
        </div>
    </form>
</body>
</html>
