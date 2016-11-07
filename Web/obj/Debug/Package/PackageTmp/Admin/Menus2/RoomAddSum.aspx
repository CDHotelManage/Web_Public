<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoomAddSum.aspx.cs" Inherits="CdHotelManage.Web.Admin.Menus2.RoomAddSum" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../../style/css.css" type="text/css" rel="stylesheet">
    <title></title>
    <style type="text/css">
        .a
        {
            width: 60px;
        }
        .divGv
        {
            margin-left: 40px;
        }
        ul li
        {
            line-height: 30px;
        }
        span
        {
            color: Blue;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="divGv">
        <ul style="padding-top: 20px;">
            <li>
                <label>
                    房号前添加</label><input class="a" type="text" id="txt_A" runat="server" />
                <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    提示：如果房号为A101,那么在此填A</span> </li>
            <li>
                <label>
                    房&nbsp;&nbsp; 号&nbsp;&nbsp;从
                </label>
                <input class="a" type="text" id="txt_stay" runat="server" />至<input class="a" type="text"
                    id="txt_end" runat="server" />
                <span>&nbsp;&nbsp; 提示：房号只能输入数字</span> </li>
            <li>
                <label>
                    房号尾数为</label><input class="a" type="text" id="txt_roomws" runat="server" />不添加
                <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 提示：如果有多个尾数，中间用逗号分开，如4,7</span></li>
           <%-- <li>
                <label>
                    分机号码在房号前加：</label><input class="a" type="text" id="txt_phone" runat="server" />
                <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 提示：如果分机号码和房间号相同此处不用填写</span> </li>--%>
            <li>房间价格：<input class="a" type="text" id="txt_money" runat="server" /></li>
            <li>月租价格：<input class="a" type="text" id="txt_modth" runat="server" disabled="disabled" /></li>
            <li>凌晨房价：<input class="a" type="text" id="txt_lc" runat="server" disabled="disabled"/></li>
            <li>楼 层：<asp:DropDownList ID="DDlouc" DataTextField="floor_name" DataValueField="floor_id"
                CssClass="fxSel001" runat="server">
            </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 楼 栋：<asp:DropDownList ID="DDlLD" OnSelectedIndexChanged="ddlldSelect" AutoPostBack="true" DataTextField="ld_Name"
                    DataValueField="id" CssClass="fxSel001" runat="server">
                </asp:DropDownList>
            </li>
            <li>房 型：<asp:DropDownList ID="ddroomtype" DataTextField="room_name" DataValueField="id" AutoPostBack="true"
                CssClass="fxSel001" runat="server" 
                    onselectedindexchanged="ddroomtype_SelectedIndexChanged">
            </asp:DropDownList>
            </li>
        </ul>
    </div>
    <div style="padding-top: 10px; text-align: center;">
        <asp:Button ID="btnAdd" runat="server" Text="　添 加　" CssClass="greenBtn" Style="height: 30px;"
            OnClick="btnAdd_Click" />
        <input name="关　闭" type="button" value="关　闭" class="button_gray" onclick="parent.Window_Close();"
            style="height: 34px; width:80px; padding-left: 0" />
    </div>
    </form>
</body>
</html>
