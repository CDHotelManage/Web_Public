<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlloorLd.aspx.cs" Inherits="CdHotelManage.Web.Admin.Menus2.FlloorLd" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="../../style/css.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">



       <div  class="addFloorCon">
           <span style="vertical-align: baseline;">楼栋名称：</spn><input type="text" id="txt_Flooer" class="AFCinput  " runat="server"  />
     <asp:Button ID="btnAdd" runat="server" Text="添加"  CssClass="greenBtn" style="width:60px;height:26px;"   onclick="btnAdd_Click" />
    </div>


    </form>
</body>
</html>
