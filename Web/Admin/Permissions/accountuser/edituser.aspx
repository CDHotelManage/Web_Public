<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edituser.aspx.cs" Inherits="CdHotelManage.Web.Admin.Permissions.accountuser.edituser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>编辑管理员</title>
    <link href="/style/css.css" rel="stylesheet" type="text/css" />

</head>
<body style="border:none; overflow:hidden;">
    <form id="form1" runat="server">
      <ul class="item">
  　　　<li>用 户 名 ：<asp:TextBox runat="server" ID="txtname"></asp:TextBox>
         <asp:Label runat="server" ID="labname" ForeColor="Red"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtname">
            </asp:RequiredFieldValidator>
            </li>
	    <li>密　　码：<asp:TextBox runat="server" ID="txtpassword"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtpassword"></asp:RequiredFieldValidator>
        </li>
        <li>真实姓名：<asp:TextBox runat="server" ID="txtTrueName"></asp:TextBox>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="txtTrueName">
                                </asp:RequiredFieldValidator>
        </li>
        <li>性　　别：<span class="rad">
            <asp:RadioButtonList ID="radsex" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Value="1" Selected="True">男</asp:ListItem>
                                    <asp:ListItem Value="0">女</asp:ListItem>
                                </asp:RadioButtonList></span>
        </li>
        <li >电　　话：<asp:TextBox runat="server" ID="txtPhone"></asp:TextBox>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ControlToValidate="txtPhone">
                                </asp:RequiredFieldValidator>
                               
        
        </li>
        <li>目前角色：<asp:Label runat="server" ID="labrole"></asp:Label>
        </li> 
       
        <li>修改角色：<asp:DropDownList ID="drpRole"   runat="server">
                
            </asp:DropDownList>
        </li>
	 </ul>　
	    <div class="btn">
         <asp:Button runat="server" Text="提交"  CssClass="blueBtn midBtn" ID="btn_save" 
                onclick="btn_save_Click"/>
        <asp:Button runat="server" Text="取消"  CssClass="grayBtn midBtn" ID="btn_cancel" 
                onclick="btn_cancel_Click"/>
        </div>
    </form>
</body>
</html>
