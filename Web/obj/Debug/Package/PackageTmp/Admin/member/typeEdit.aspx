<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="typeEdit.aspx.cs" Inherits="CdHotelManage.Web.Admin.member.typeEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" runat="server" id="hidtypeid"/>
    <div class="types" style="margin: 0px">
            <ul>
                <li>
                    <label>名称：</label>
                    <input type="text" class="txt inps" runat="server" style="width: 138px" id="Name" maxlength="10"></li>
                <li style="margin-left: 30px; display: inline">
                    <label>卡费：</label>
                    <input type="text" class="inps" runat="server" style="width: 60px" id="CardFee" value="0" maxlength="10">
                    <label class="txt">&nbsp;元</label></li>
                <li style="margin-left: 30px; display: inline">
                    
                    <label>备注：</label>
                    <input type="text" class="inps Expire" runat="server" style="width: 60px" id="remark"></li>
            </ul>
        </div>
         <asp:Button Text="确定" OnClick="btn_Sub_Click" runat="server" ID="btn_Sub" />
    </form>
</body>
</html>
