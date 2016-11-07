<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CostMoney.aspx.cs" Inherits="CdHotelManage.Web.Admin.customer.CostMoney" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../style/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function isfill() {

            var price = document.getElementById("txt_Money").value;
            if (price == "") {
                alert('费用金额不能为空');
                return false;
            } else { return true; }
        }
    </script>
</head>
<body style="background: #fff">
    <!--费用入帐ok-->
    <form id="form1" runat="server">
    <ul class="sprzul">
        <li>帐 号：<asp:Label ID="ga_Account" runat="server" Text="Label"></asp:Label></li>
            <li>客户名称：<asp:Label ID="accounts" runat="server" Text="Label"></asp:Label></li>
    </ul>
    <div class="bhsl_left002">
        <ul class="sprzul">
            <li>费用类别：<asp:DropDownList ID="DDlfyType" DataTextField="ct_name" AutoPostBack="true"
                DataValueField="id" runat="server" OnSelectedIndexChanged="DDlfyType_SelectedIndexChanged">
            </asp:DropDownList>
            </li>
            <li>费用名称：<asp:DropDownList ID="DDlName" DataTextField="ct_name" DataValueField="id"
                runat="server">
            </asp:DropDownList>
            </li>
            <li>费用金额：<input type="text" name="textfield" id="txt_Money" runat="server" />
            </li>
        </ul>
        <div class="bzdiv">
            备 注：<input type="text" name="textfield" id="txt_Remaker" style="width: 80%;" runat="server" /></div>
    </div>
    <div style="text-align: right;">
        <asp:Button ID="btnAdds" runat="server" Text="确认" OnClientClick="if(isfill()){}else{return false;}" class="button_orange " Style="width: 100px" 
             OnClick="btnAdds_Click" />
        <input name="关　闭" type="button" value=" 关　闭 " class="button_gray " onclick="parent.Window_Close();"
            style="width: 100px;" /></div>
    </form>
</body>
</html>
