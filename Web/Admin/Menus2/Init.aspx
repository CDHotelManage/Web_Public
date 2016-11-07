<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Init.aspx.cs" Inherits="CdHotelManage.Web.Admin.Menus2.Init" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function isFill() {
            if (confirm('是否确定初始化,将不能恢复?')) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:Button  ID="btnInit" runat="server" Text="系统初始化" OnClientClick="return isFill();" OnClick="BtnInit_Click"/>
    </div>
    </form>
</body>
</html>
