<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CostMoney.aspx.cs" Inherits="CdHotelManage.Web.Admin.Toroom.CostMoney" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../style/css.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <link href="../../easyui/themes/gray/easyui.css" rel="stylesheet" type="text/css" />
    <script src="../../easyui/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../js/base.js" type="text/javascript"></script>
    <script type="text/javascript">
        function isfill() {

            var price = document.getElementById("txt_Money").value;
            if (price == "") {
                alert('费用金额不能为空');
                return false;
            } else { return true; }
        }
        function ShowOk() {
            ShowAlert("提示", "保存成功！", "info", function () { parent.d_close(); });
        }
    </script>
</head>
<body style="background: #fff">
    <!--费用入帐ok-->
    <form id="form1" runat="server">
    <ul class="sprzul">
        <li>房 号：<asp:Label ID="labfh" runat="server" Text="Label"></asp:Label></li>
        <li>房 型：<asp:Label ID="labfx" runat="server" Text="Label"></asp:Label></li>
        <li>开房方式：<asp:Label ID="labkffs" runat="server" Text="Label"></asp:Label></li>
        <li>来 源：<asp:Label ID="lably" runat="server" Text="Label"></asp:Label></li>
        <li>姓 名：<asp:Label ID="labname" runat="server" Text="Label"></asp:Label></li>
        <li>入住时间：<asp:Label ID="labrzDate" runat="server" Text="Label"></asp:Label></li>
        <li>房 价：<asp:Label ID="labfjMoney" runat="server" Text="Label"></asp:Label></li>
        <li>消费金额：<asp:Label ID="labSymoney" runat="server" Text="Label"></asp:Label></li>
    </ul>
    <div class="bhsl_left002">
        <ul class="sprzul">
            <li>费用类别：<asp:DropDownList ID="DDlfyType" CssClass="textbox-text_hrj textbox_hrj" DataTextField="ct_name" AutoPostBack="true"
                DataValueField="id" runat="server" OnSelectedIndexChanged="DDlfyType_SelectedIndexChanged">
            </asp:DropDownList>
            </li>
            <li>费用名称：<asp:DropDownList ID="DDlName" DataTextField="ct_name" CssClass="textbox-text_hrj textbox_hrj" DataValueField="id"
                runat="server">
            </asp:DropDownList>
            </li>
            <li>费用金额：<input type="text" name="textfield" class="textbox-text_hrj textbox_hrj" id="txt_Money" runat="server" />
            </li>
        </ul>
        <div class="bzdiv" style=" margin-top:8px;">
            备 注：<input type="text" name="textfield" id="txt_Remaker" class="textbox-text_hrj textbox_hrj" style="width: 80%;" runat="server" /></div>
    </div>
    <div style="text-align: right;">
    支付方式：<asp:DropDownList ID="DDlZffs" DataTextField="meth_pay_name"  CssClass="textbox-text_hrj textbox_hrj" DataValueField="meth_pay_id"
                    runat="server">
                </asp:DropDownList>
        <asp:Button ID="btnAdds" runat="server" Text="确认" OnClientClick="if(isfill()){}else{return false;}"  class="button_orange" Style="width: 100px" 
             OnClick="btnAdds_Click" />
        <input name="关　闭" type="button" value=" 关　闭 " class="button_gray " onclick="parent.Window_Close();"
            style="width: 100px;" /></div>
    </form>
</body>
</html>
