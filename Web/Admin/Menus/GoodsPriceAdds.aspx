<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsPriceAdds.aspx.cs"
    Inherits="CdHotelManage.Web.Admin.Menus.GoodsPriceAdds" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>添加费用</title>
    <link href="../../style/css.css" rel="stylesheet" type="text/css" />
    <script src="../../js/DivWH.js" type="text/javascript"></script>
    <link href="../../style/Opendiv.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .quanxian
        {
            padding-top: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="quanxian">
            <ul class="addRoomCon">
                <li>商品类别：
                    <asp:DropDownList ID="DDlfylb" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDlfylb_SelectedIndexChanged">
                    </asp:DropDownList>
                </li>
                <li>编&nbsp;&nbsp;&nbsp;&nbsp; 号：
                    <input type="text" id="txtBH" runat="server" maxlength="10" />
                    <input type="hidden" id="ShopBH" />
                </li>
                <li>商品名称：<input type="text" id="txtName" runat="server" maxlength="30" />
                </li>
                <li>单&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 价：<input id="txtPrice" runat="server" type="text"
                    maxlength="6" />
                </li>
                <li>积&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 分：<input id="txt_Jf" runat="server" type="text"
                    maxlength="6" />
                </li>
                <li>单&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 位：<input id="txt_unit" runat="server" type="text"
                    maxlength="6" />
                </li>
                <li id="listatus">状&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;态：
                    <input type="radio" id="radStatus" runat="server" name="a"  value="0" class="radio" />使用
                    <input type="radio" id="radStatu" runat="server" name="a" value="1" class="radio" />停用 </li>
                <li>备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 注：<textarea runat="server" id="txtRemark"></textarea></li>
                <li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnAdd" runat="server" CssClass="greenBtn" OnClick="btnAdd_Click"
                        Style="height: 26px;" Text="　添 加　" />
                </li>
            </ul>
            <input type="hidden" id="hidid" value="0" />
        </div>
    </div>
    </form>
</body>
</html>
