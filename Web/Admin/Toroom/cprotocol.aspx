<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cprotocol.aspx.cs" Inherits="CdHotelManage.Web.Admin.Toroom.cprotocol" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/tch.css" rel="stylesheet" type="text/css" />
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
     <div class="main">
       <div class="ftt_search fontYaHei">
        <label>条件：</label>
        <label>房价协议：</label>
        <asp:DropDownList runat="server" ID="cusType" CssClass="txt" AutoPostBack="true" OnSelectedIndexChanged="cusTypechange" style=" width:127px;"></asp:DropDownList>
        </div>
     </div>
    </form>
</body>
</html>
