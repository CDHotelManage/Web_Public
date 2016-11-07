<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CzPay.aspx.cs" Inherits="CdHotelManage.Web.Admin.Toroom.CzPay" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <link href="../css/tch.css" rel="stylesheet" type="text/css" />
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <link href="../css/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
    <script src="../js/base.js" type="text/javascript"></script>
    <script src="../../js/AppendHtml.js" type="text/javascript"></script>
    <script src="../js/lss.js" type="text/javascript"></script>
    <script type="text/javascript">
        function isFill() {
            if ($("#CardNo").val() == "") {
                alert("会员卡号不能为空！！");

                return false;
            }
            else if ($("#Amount").val() == "") {
                alert("金额不能为空！！");
                return false;
            }
            else {
                $.get("/admin/ajax/Member.ashx", "type=isok&num=" + $("#CardNo").val(), function (obj) {
                    if (obj == "err") {
                        alert("该会员不存在！");
                        return false;

                    }
                }, "text");
            }
            $.get("/admin/ajax/Member.ashx", "type=VailPwd&num=" + $("#CardNo").val() + "&pwd=" + $("#Password").val(), function (obj) {
                if (obj == "err") {
                    alert("密码错误！");
                    return false;
                }
                else {
                    if (parseInt($("#Amount").val()) > parseInt($("#UsableAmount").text())) {
                        alert("余额不足!");
                    }
                    else {
                        $(".memInp", window.parent.document).val($("#Amount").val());
                        $("#payHycard", window.parent.document).val($("#CardNo").val());
                    parent.Window_Close();
                }
                }
            }, "text");
        }
    </script>
</head>
<body>
    <form id="form2" runat="server">
    <input type="hidden" id="pwd" runat="server" />
    <div class="vip_infor" style="width: 550px">
        <div class="line">
            <div class="fl">储值卡支付</div>
            <div class="errortips" id="divErrTips"></div>
        </div>
        <div class="types" style="margin:0px">
            <ul>
                <li>
                    <label style="width:60px">卡号：</label>
                    <input type="text" class=" inps" id="CardNo" maxlength="20" autocomplete="off" runat="server" style="margin-right:8px"/>
                    <input type="button" class="credit " value="读卡" id="btnReadCard"  style="margin-right:0px !important"/>
                </li></ul>
            <ul>
                <li>
                    <label style="width:60px">类型：</label>
                    <%--<input type="text" class=" inps" id="CategoryName"  runat="server" maxlength="20" disabled="disabled"/>--%>
                    <span class="inps" id="CategoryName" runat="server"></span>
                </li><li>
                    <label style="width:78px;margin-left:30px;">&nbsp;姓名：</label>
                    <%--<input type="text" class="inps" id="Name" runat="server" maxlength="20" disabled="disabled"/>--%>
                    <span class="inps" id="Name" runat="server"></span>
                </li></ul>
            <ul>
                </ul>
            <ul>
                <li>
                    <label style="width:60px">余额：</label>
                   <span id="UsableAmount" class="inps"  runat="server"></span> <%--<input type="text" class=" inps" id="UsableAmount" runat="server"  maxlength="20" disabled="disabled" />--%>&nbsp;元
                </li><li>
                    <label style="width:60px; margin-left:30px;">本次支付：</label>
                    <input type="text" class=" inps" id="Amount" autocomplete="off" runat="server" maxlength="20" />&nbsp;元
                </li></ul>
            <ul>
                </ul>
            <ul>
                <li>
                    <label style="width:60px">密码：</label>
                    <input type="password" class=" inps" autocomplete="off" id="Password" runat="server" maxlength="20" />
                </li></ul>
        </div>
        <!--储值卡支付-->
        <div class="types">
            <ul style="float: right; width: 240px">
                <li style="">
                    <input type="button" class="bus_add " value="确定" id="btnSave" onclick="return isFill();"  runat="server"/></li>
                <li style="margin-right: 0px">
                    <input type="button" class="bus_dell " id="btnClose" value="关闭" onclick="Close()" style="margin-right: 0px" />
                </li>
            </ul>
        </div>
    </div>
    <div class="ac_results" style="position: absolute; width: 420px; top: 57px; left: 70px;">
        <ul style="max-height: 180px; overflow: auto;">
        </ul>
    </div>
    </form>
</body>
</html>
