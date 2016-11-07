<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HandOverXiang.aspx.cs" Inherits="CdHotelManage.Web.Admin.ShiftExc.HandOverXiang" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../js/printy.js" type="text/javascript"></script>
    <link href="../../style/Sheet.css" rel="stylesheet" type="text/css" />
  
</head>
<body>  
<input width="300px" type="button" value="打印预览" id="btnPrint" onclick="printWork('handlr')">
    <form id="form1" runat="server">
    <div id="handlr">
      <h3 style=" font-size:15px; font-weight:100; text-align:center;"><%=name %><%=day %><%=banchi %>班 交班明细报表</h3>
      <p style="font-size:14px; text-align:center;"><span style=" margin-right:200px;">打印时间:<%=DateTime.Now.ToString("yyyy-MM-dd")%></span>打印人:admin</p>
      <table>
       <tr>
         <td colspan="7">收款</td>
       </tr>
       <tr>
         <td colspan="7"></td>
       </tr>
       <%=sb.ToString() %>
      </table>
      <table>
        <tr>
          <td colspan="4">
            付款方式合计:(负值表示应交财务金额，正值表示向财务取的金额)
          </td>
        </tr>
         <%=sbtext.ToString() %>
      </table>
          </div>
    </form>
</body>
</html>
