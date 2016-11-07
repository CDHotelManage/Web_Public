<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="roomAdds.aspx.cs" Inherits="CdHotelManage.Web.Admin.Menus2.roomAdds" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../../style/css.css" type="text/css" rel="stylesheet">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <ul class="addRoomCon" style=" padding-top:20px;">
        <li>楼 &nbsp;&nbsp;&nbsp;&nbsp;栋：<asp:DropDownList ID="DDlLD" OnSelectedIndexChanged="ddlldSelect" AutoPostBack="true" DataTextField="ld_Name" DataValueField="id"
            CssClass="fxSel001" runat="server">
        </asp:DropDownList>
        </li>
        <li>楼 &nbsp;&nbsp;&nbsp;&nbsp;层：<asp:DropDownList ID="DDlouc" DataTextField="floor_name" DataValueField="floor_id"
            CssClass="fxSel001" runat="server">
        </asp:DropDownList>
        </li>
        <li>房 &nbsp;&nbsp;&nbsp;&nbsp;号：<input type="text" id="txt_roomid" class="fh001" runat="server" /></li>
        <li>房 &nbsp;&nbsp;&nbsp;&nbsp;型：<asp:DropDownList ID="ddroomtype" DataTextField="room_name" DataValueField="id" AutoPostBack="true"
            CssClass="fxSel001" runat="server" 
                onselectedindexchanged="ddroomtype_SelectedIndexChanged">
        </asp:DropDownList>
        </li>
        <li>房间价格：<input type="text" id="txt_money" runat="server" class="fh001" /></li>
        <li>特征描述：<input type="text" id="txt_Reamker" runat="server" class="fh001" /></li>
    </ul>
    <div class="ARCbtn">
        <asp:Button ID="btnAdd" runat="server" Text="　添 加　" CssClass="greenBtn" Style="height: 30px;"
            OnClick="btnAdd_Click" /></div>
    </form>
</body>
</html>
