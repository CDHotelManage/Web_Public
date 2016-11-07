<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddMenu.aspx.cs" Inherits="CdHotelManage.Web.Admin.Permissions.menu.AddMenu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加菜单</title>
     <link href="../../../style/css.css" rel="stylesheet" type="text/css" />
    <script src="../../js/base.js" type="text/javascript"></script>
</head>
<body style=" overflow:hidden;">
    <form id="form1" runat="server">
      <ul class="item">
  　　　<li>菜 单 名 ：<asp:TextBox runat="server" ID="txttitle"></asp:TextBox>
            <asp:Label runat="server" ID="labmenuname" ForeColor="Red"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txttitle">
            </asp:RequiredFieldValidator>
            </li>
	     <li>父类菜单：<asp:DropDownList runat="server" ID="drpMenu"  Width="150"></asp:DropDownList>
        </li>
        <li>菜单路径：<asp:TextBox runat="server" ID="txturl"></asp:TextBox>
         
        </li>
        <li>图　　标：<asp:FileUpload runat="server" ID="UpIcon"></asp:FileUpload>
            <asp:Label runat="server" ID="labicon"></asp:Label>
        </li>
        <li>排　　序：<asp:TextBox runat="server" ID="txtsort" Width="100"></asp:TextBox>
            <asp:Label runat="server" ID="labsort"></asp:Label>
        </li>
        <li>启　　用：<span class="rad">&nbsp;&nbsp;
            <asp:RadioButtonList ID="radable" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Value="1" Selected="True">是</asp:ListItem>
                                    <asp:ListItem Value="0">否</asp:ListItem>
                                </asp:RadioButtonList></span>
        </li>
	 </ul>　
	    <div class="btn">
         <asp:Button runat="server" Text="提交"  CssClass="blueBtn midBtn" ID="btn_save" 
                onclick="btn_save_Click"/>
        <asp:Button runat="server" Text="取消"  CssClass="grayBtn midBtn" ID="btn_cancel" OnClientClick="Close();" />
        </div>
    </form>
</body>
</html>
