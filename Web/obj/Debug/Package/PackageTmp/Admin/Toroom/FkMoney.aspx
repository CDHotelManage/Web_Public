<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FkMoney.aspx.cs" Inherits="CdHotelManage.Web.Admin.Toroom.FkMoney" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../style/css.css" rel="stylesheet" type="text/css" />
    <link href="../../style/Opendiv.css" rel="stylesheet" type="text/css" />
    <link href="../../style/css2.css" rel="stylesheet" type="text/css" />
    <link href="../../style/css3.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../js/DivWH.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/base.js"></script>
    <script type="text/javascript">
        function XZintRZ(obj, order_id) {
            var desp = $("#txt_Money").val();
            var url = "/Admin/ShiftExc/OccupancySingle.aspx?orrderID=" + order_id + "&desp=" + desp;
            showMyWindow("打印收款单", url, 400, 600, true, true, true, update);
        }
        function update() {
            alert("aaa");
           // parent.window.location.reload();
        }
    </script>
    <style type="text/css">
        /*入帐开房*/
        .addyds
        {
            width: 99%;
            overflow: hidden;
            margin: 0 auto;
            padding-left: 2%;
           line-height:50px;
        }
        /*弹出框最外部的ul*/
        .addyds li
        {
            width: 35%;
            float: left;
            padding: 5px 0.5% 5px 0;
            text-align: left;
            overflow: hidden;
        }
        .addyds input
        {
            height: 22px;
            margin: 0;
            padding-left: 2px;
        }
        /*文本框*/
        .addyds select
        {
            height: 26px;
            padding-left: 2px;
        }
       
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ul class="addyds" style="width: 640px;">
            
            <li><span>房号：</span>
                <input type="text" name="textfield" id="txt_fh" runat="server" />
            </li>
            <li><span>金额：</span>
                <input type="text" name="textfield" id="txt_Money" runat="server" />
            </li>
            
            <li><span>付款方式：</span>
                <asp:DropDownList ID="DDlZffs" DataTextField="meth_pay_name" DataValueField="meth_pay_id"
                    runat="server">
                </asp:DropDownList>
           
            </li>
            <li><span>单据号：</span>
                <input type="text" name="textfield" id="txt_djh" runat="server" />
            </li>
            <li style="width: 600px;"><span>备注：</span>
                <input type="text" name="textfield" id="txt_Remaker" style="width: 550px; height: 50px;"
                    runat="server" />
            </li>
        </ul>
        <div class="sprz_grays" style="text-align: right; width: 640px;">
            <asp:Button ID="btnAdds" runat="server" Text="确定" class="button_orange " 
                Style="width: 100px" onclick="btnAdds_Click" />
            <input name="关　闭" type="button" value=" 关　闭 " class="button_gray " onclick="parent.Window_Close();"
                style="width: 100px;" /></div>
    </div>
    </form>
</body>
</html>

