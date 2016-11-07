<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FloorAdd.aspx.cs" Inherits="CdHotelManage.Web.Admin.Menus2.FloorAdd" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../style/css.css" type="text/css" rel="stylesheet"/>
    <script src="../../js/DivWH.js" type="text/javascript"></script>
    <link href="../../style/Opendiv.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <ul class="addFloorCon">
       <li>楼栋：<asp:DropDownList ID="DDlLD" DataTextField="ld_Name" DataValueField="id" runat="server" class="AFCselect">
        </asp:DropDownList></li>
        <li>楼层：<input type="text" id="txt_Flooer" class="AFCinput  " runat="server" /></li>
    </ul>
        <div class="btnWrap" style="text-align:left;padding-left:130px;"><asp:Button ID="btnAdd" runat="server" Text="添加" CssClass="greenBtn" Style="width:60px;height: 26px;"
                OnClick="btnAdd_Click" />
        </div>
   
    </form>
</body>
</html>
