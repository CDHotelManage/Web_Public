<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TkMoney.aspx.cs" Inherits="CdHotelManage.Web.Admin.Toroom.TkMoney" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <link href="../../style/css.css" rel="stylesheet" type="text/css" />
    <link href="../../style/Opendiv.css" rel="stylesheet" type="text/css" />
    <script src="../../js/DivWH.js" type="text/javascript"></script>
    <script src="../js/base.js" type="text/javascript"></script>
    <style type="text/css">
        .addyds{width: 99%;overflow: hidden;margin: 0 auto;padding-left: 2%;line-height:50px;}
        .addyds li{width: 25%;min-width: 220px;float: left;padding: 5px 0.5% 5px 0;text-align: left;overflow: hidden;}
        .addyds input{height: 22px;margin: 0;padding-left: 2px;}
        .addyds select{height: 26px;padding-left: 2px;}
    </style>
    <script type="text/javascript">
        function IsFill() {
            var reg = new RegExp("^[0-9]*$");
            var t = $("#txt_tkMoney").val();
            if (!reg.test(t)) {
                alert("请输入正确格式的金额!");
                return false;
            }
            if (parseInt($("#txt_tkMoney").val()) < 0) {
                alert("退款金额不能为负数!!");
                return false;
            }
            if (parseInt($("#txt_tkMoney").val()) > parseInt($("#txt_yMoney").val())) {
                alert("退款金额不能大于余额!!");
                return false;
            }
        }
        function XZintRZ(obj, order_id) {
            var desp = $("#txt_tkMoney").val();
            var url = "/Admin/ShiftExc/OccupancySingle.aspx?orrderID=" + order_id + "&desp=-" + desp;
            showMyWindow("打印退款单", url, 400, 600, true, true, true);
        }
    </script>
</head>
<body>
    <!--退款-->
    <form id="form1" runat="server">
    <div>
        <ul class="addyds">
            <li>客人姓名：<input type="text" name="textfield" id="txt_name" runat="server" /></li>
            <li>房&nbsp;&nbsp;&nbsp;&nbsp; 号：<input type="text" name="textfield" id="txt_fh" runat="server" /></li>
            <li>收款合计：<input type="text" name="textfield" id="txt_skCount" runat="server" /></li>
            <li>余&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 额：<input type="text" name="textfield" id="txt_yMoney" runat="server" /></li>
            <li>付款方式：<asp:DropDownList ID="DDlZffs" DataTextField="meth_pay_name" DataValueField="meth_pay_id"
                runat="server">
            </asp:DropDownList>
            </li>
            <li>退款金额：<input type="text" name="textfield" id="txt_tkMoney" runat="server" /></li>
            <li style="width: 600px;">备注：
                <input type="text" name="textfield" id="txt_Remaker" style="width: 500px; height: 50px;" runat="server" /></li>
        </ul>
        <div class="sprz_grays" style="text-align: right; width: 740px;">
            <asp:Button ID="btnAdds" runat="server" Text="确定" class="button_orange " OnClientClick="return IsFill()" Style="width: 100px" OnClick="btnAdds_Click" />
            <input name="关　闭" type="button" value=" 关　闭 " class="button_gray " onclick="parent.Window_Close();" style="width: 100px;" /></div>
    </div>
    </form>
</body>
</html>
