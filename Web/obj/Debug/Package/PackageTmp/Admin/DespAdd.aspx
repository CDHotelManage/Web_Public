<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DespAdd.aspx.cs" Inherits="CdHotelManage.Web.Admin.DespAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
      #tables{ width:100%;border-collapse:collapse; margin:0 auto;}
       #tables td{border:1px solid #ececec;padding:10px; font-size:12px; text-align:center;}
       .w60{ width:60px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <input type="hidden" id="hidtxt"  runat="server"/>
    <table id="tables">
     <tr>
       <td style=" width:50%;">房型</td>
       <td style=" width:50%;">
        <asp:DropDownList runat="server" ID="ddllist"></asp:DropDownList>
       </td>
     </tr>
     <tr>
       <td>方案名称</td>
       <td><input type="text" class="w60" runat="server" id="hs_name"/></td>
     </tr>
     <tr>
       <td>起步时间</td>
       <td><input type="text"  class="w60" runat="server" id="hs_start_long"/></td>
     </tr>
     <tr>
       <td>起步价格</td>
       <td><input type="text" class="w60"  runat="server" id="hs_start_price"/></td>
     </tr>
     <tr>
       <td>加钟时长</td>
       <td><input type="text" class="w60"  runat="server" id="hs_add_time"/></td>
     </tr>
     <tr>
       <td>加钟价格</td>
       <td><input type="text" class="w60"  runat="server" id="hs_add_price"/></td>
     </tr>
     <tr>
       <td>最小时长</td>
       <td><input type="text"  class="w60" runat="server" id="hs_min_time"/></td>
     </tr>
     <tr>
       <td>最小价格</td>
       <td><input type="text" class="w60"  runat="server" id="hs_min_price"/></td>
     </tr>
     <tr>
       <td>超时转全天</td>
       <td><input type="text" class="w60"  runat="server" id="hs_max_time"/></td>
     </tr>
     <tr>
       <td>应用于什么类型会员</td>
       <td><asp:DropDownList runat="server" ID="mttype"></asp:DropDownList></td>
     </tr>
     <tr>
      <td colspan="2"><input type="button" runat="server" id="btnOk" onserverclick="btn_ok_click" value="更新" /></td>
     </tr>
    </table>
    </div>
    </form>
</body>
</html>
