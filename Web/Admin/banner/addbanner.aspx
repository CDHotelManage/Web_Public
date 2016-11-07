<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addbanner.aspx.cs" Inherits="CdHotelManage.Web.Admin.banner.addbanner" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>添加横幅</title>
    <link href="/style/css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .item{padding-left:50px;}
        .item div{width:500px;height:40px;}
        .item div input{height:20px;width:200px;}
        .btn input{margin-left:60px;width:80px;}
        .rad{width:200px;}
        .rad span input{width:40px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
  <div class="item">
  　　　<div>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;标题：
            <asp:TextBox runat="server" ID="txttitle"></asp:TextBox>
         <asp:Label runat="server" ID="labtitle" ForeColor="Red"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txttitle">
            </asp:RequiredFieldValidator>
            </div>
	    <div>选择图片：
            <asp:FileUpload ID="UpFile" runat="server" />
            <asp:Label ID="labimg" runat="server" ForeColor="Red"></asp:Label>
        </div>
        <div>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;排序：<asp:TextBox runat="server" ID="txtsort"></asp:TextBox>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                ControlToValidate="txtsort"></asp:RequiredFieldValidator><span>（已设默认值）</span>
         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="必须为正整数"
          ForeColor="Red" ControlToValidate="txtsort" ValidationExpression="^[1-9]d*$"></asp:RegularExpressionValidator>
        </div>
      
	 </div>　
	    <div class="btn">
         <asp:Button runat="server" Text="提交"  CssClass="button_orange" ID="btn_save" 
                onclick="btn_save_Click"/>
        <asp:Button runat="server" Text="取消"  CssClass="button_gray" ID="btn_cancel" 
                onclick="btn_cancel_Click"/>
        </div>
    </form>
</body>
</html>
