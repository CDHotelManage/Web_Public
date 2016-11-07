<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FloorAdd.aspx.cs" Inherits="CdHotelManage.Web.Admin.Menus.FloorAdd" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../style/css.css" type="text/css" rel="stylesheet">

    <script src="../../js/DivWH.js" type="text/javascript"></script>
    <link href="../../style/Opendiv.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
  



       <div  class="addFloorCon">
     楼层：<input type="text" id="txt_Flooer" class="AFCinput  " runat="server"  />
     <asp:Button ID="btnAdd" runat="server" Text="　添 加　"  CssClass="greenBtn" style="height:26px;"   onclick="btnAdd_Click" />
    </div>


    </form>
</body>
</html>
