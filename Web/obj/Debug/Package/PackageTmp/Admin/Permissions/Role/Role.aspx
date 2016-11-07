<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Role.aspx.cs" Inherits="CdHotelManage.Web.Admin.Permissions.Role.AddRole" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>角色操作</title>
    <link href="../../../style/css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        ul
        {
            width: 290px;
            margin: 0 auto;
        }
        ul li
        {
            margin: 8px 0 0 0;
            width: 280px;
        }
        body .content
        {
            min-width: 100px;
            padding-left: 20px;
        }
        .content
        {
            width: 270px;
            margin-left: 0px;
        }
    </style>
    <script src="/js/jquery.js" type="text/javascript"></script>
    <script src="/js/DivWH.js" type="text/javascript"></script>
    <link href="/style/Opendiv.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        function CloseDiv() {
            Window_Close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Panel runat="server" ID="PanelAdd" Visible="false" CssClass="content">
        <ul>
            <li>角色名称 ：
                <asp:TextBox runat="server" ID="txtrolename" Height="22px" Width="200px"></asp:TextBox>
                <asp:Label runat="server" ID="labname" ForeColor="Red"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                    ControlToValidate="txtrolename">
                </asp:RequiredFieldValidator>
            </li>
            <li>角色描述 ：
                <asp:TextBox runat="server" ID="txtdescript" Height="96px" TextMode="MultiLine" Width="200px"></asp:TextBox>
            </li>
            <li style="width: 300px; text-align: left; clear: left; padding-left: 60px;">
                <asp:Button ID="btnSave" runat="server" Text="提交" CssClass="button_orange" Width="50"
                    Height="33" OnClick="btnSave_Click" />
                <asp:Button ID="btnCacel" runat="server" Text="取消" OnClientClick="parent.Window_Close();" CssClass="button_gray" Width="50"
                    Height="33" /></li>
        </ul>
    </asp:Panel>
    <asp:Panel runat="server" ID="PanelEdit" Visible="false" CssClass="content">
        <ul>
            <li>角色名称 ：
                <asp:TextBox runat="server" ID="rolename" Height="22px" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                    ControlToValidate="rolename">
                </asp:RequiredFieldValidator>
            </li>
            <li>角色描述 ：
                <asp:TextBox runat="server" ID="descript" Height="96px" TextMode="MultiLine" Width="200px"></asp:TextBox>
            </li>
        </ul>
        <div style="text-align: center">
            <asp:Button ID="btnEdit" runat="server" Text="编辑" CssClass="blueBtn midBtn" OnClick="btnEdit_Click" />
            <input type="button" value="取消" class="grayBtn midBtn" onclick="parent.Window_Close();" />
        </div>
    </asp:Panel>
    </form>
</body>
</html>
