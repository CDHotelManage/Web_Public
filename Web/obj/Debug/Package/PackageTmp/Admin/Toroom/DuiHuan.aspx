<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DuiHuan.aspx.cs" Inherits="CdHotelManage.Web.Admin.Toroom.DuiHuan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="../css/tch.css" rel="stylesheet" type="text/css" />
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <script src="../js/base.js" type="text/javascript"></script>
    <script src="../js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            var CardNo = $("#CardNo").val();
            $("#Amount").change(function () {
                var Amount = $(this).val();
                if (parseInt(Amount) > parseInt($("#txt_xfMoneys").val())) {
                    alert("本次最多只可以兑换" + $("#txt_xfMoneys").val() + "元");
                    $("#Amount").val($("#txt_xfMoneys").val());
                }
                $.get("/admin/ajax/Member.ashx", "type=getDuihaun&mid=" + CardNo + "&Amount=" + Amount + "&syjf=" + $("#syjf").val(), function (obj) {
                    if (obj.statu == "ok") {
                        if (parseInt($("#zjf").val()) < parseInt(obj.data)) {
                            $("#Amount").val("0");
                            alert("积分不足");
                        }
                        else {
                            $("#kcjf").text(obj.data);
                        }
                    }
                    else if (obj.statu == "err") {
                        alert("积分不足");
                        $("#Amount").val(obj.data.je);
                        $("#kcjf").text(obj.data.sumjf);
                    }
                }, "json");

            })
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" id="txt_xfMoneys" value="" runat="server" />
    <input type="hidden" id="orderid" runat="server"/>
    <div class="vip_infor" style="width: 306px">
        <div class="line">
            <div class="fl">积分兑换</div>
            <div class="errortips" id="divErrTips"></div>
        </div>
        <div class="types" style="margin:0px">
            <ul>
                <li>
                    <label style="width:60px">卡号：</label>
                    <input type="text" class=" inps" id="CardNo" maxlength="20" runat="server" style="margin-right:8px"/>
                    <input type="button" class="credit " value="读卡" id="btnReadCard" style="margin-right:0px !important"/>
                </li></ul>
            <ul>
                <li>
                    <label style="width:60px">类型：</label>
                    <input type="text" class="txt inps" id="CategoryName" runat="server" maxlength="20" disabled="disabled"  value="会员"/>
                </li></ul>
            <ul>
                <li>
                    <label style="width:60px">姓名：</label>
                    <input type="text" class="txt inps" id="MemberName" runat="server" maxlength="20" disabled="disabled"  value="许诺"/>
                </li></ul>
            <ul>
                <li>
                    <label style="width:60px">总积分：</label>
                    <input type="text" class=" inps" id="zjf" runat="server" maxlength="20" disabled="disabled"  value="5000" />&nbsp;元
                </li></ul>
                 <ul>
                <li>
                    <label style="width:60px">已用积分：</label>
                    <input type="text" class=" inps" id="xyjf" runat="server" maxlength="20" disabled="disabled"  value="5000" />&nbsp;元
                </li></ul>
                 <ul>
                <li>
                    <label style="width:60px">剩余积分：</label>
                    <input type="text" class=" inps" id="syjf" runat="server" maxlength="20" disabled="disabled"  value="5000" />&nbsp;元
                </li></ul>
            <ul>
                <li>
                    <label style="width:60px">兑换金额：</label>
                    <input type="text" class=" inps" id="Amount" style="width:60px;" runat="server" maxlength="20" value="1"/>&nbsp;<label>元，扣除</label><span id="kcjf" style="width:60px;">0</span><label>积分</label>
                </li></ul>
<%--            <ul>
                <li>
                    <label style="width:60px">密码：</label>
                    <input type="password" class="txt inps" id="Password" runat="server" maxlength="20" />
                </li></ul>--%>
        </div>
        <!--储值卡支付-->
        <div class="types">
            <ul style="float: right; width: 240px">
                <li style="">
                    <input type="button" class="bus_add " value="确定" id="btnSave" runat="server" onserverclick="bus_add_Click" runat="server"/></li>
                <li style="margin-right: 0px">
                    <input type="button" class="bus_dell " id="btnClose" value="关闭" onclick="Close()" style="margin-right: 0px" />
                </li>
            </ul>
        </div>
    </div>
    </form>
</body>
</html>
