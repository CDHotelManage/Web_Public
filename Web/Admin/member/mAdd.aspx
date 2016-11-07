<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mAdd.aspx.cs" Inherits="CdHotelManage.Web.Admin.member.mAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/tch.css" rel="stylesheet" type="text/css" />
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../js/memberadd.js" type="text/javascript"></script>
    <script src="../../calendar/WdatePicker.js" type="text/javascript"></script>
    <script src="../js/base.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" id="cardPice" runat="server"/>
    <div class="vip_infor" style="width: 600px">
        <div class="line">
            <div class="fl" id="divfa" style=" display:none;" runat="server">会员发卡</div>
            <div class="errortips" id="btnRead"></div>
            <input type="hidden" id="CardInfoId" />
            <input type="hidden" id="CardFees" />
            <input type="hidden" id="Price" />
            <input type="hidden" id="OpenAmount" />
            <input type="hidden" id="PrepaidEnable" />
        </div>
        <div class="types" id="CAdd" runat="server" style="margin-top: 0px">
            <ul>
                <li>
                    <label>会员卡号：</label>
                    <input type="text" class="txt inps" id="MemberCardNo" runat="server" autocomplete="off" maxlength="20" />
                </li>
                <li>
                    <input type="button" class="credit" runat="server" value="查询" id="btnSearch" />
                    <input type="button" class="credit" runat="server" value="读卡" id="btnReadCard" />
                    <input type="button" class="credit" runat="server" value="写卡" id="btnWriteCard" />
                    <input type="button" class="credit" runat="server" value="清卡" id="btnClearCard" />
                </li>
            </ul>
        </div>
        <div class="types" runat="server" id="CEdit" style="margin: 0px">
            <ul>
                <li>
                    <label>卡号：</label>
                    <span style="width: 120px" class="txt inps" id="CCardNo" runat="server">0</span>
                </li>
            </ul>
        </div>
        <div class="types" style="background: #EFEFEF; border: 1px solid #ddd; margin-top: 0px">
            <ul>
                <li>
                    <label style="width: 60px">姓名：</label>
                    <input type="text" class="txt inps" style="width: 130px" id="Name" runat="server" maxlength="20" />
                </li>
                <li>
                    <label>性别：</label>
                    <%--<select class="txt" style="width: 86px" id="Sex">
                        <option value="0">男</option>
                        <option value="1">女</option>
                    </select>--%>
                    <asp:DropDownList runat="server" ID="Sex" style="width:85px;margin-right: 40px;">
                     <asp:ListItem Value="0" Text="男" Selected="True"></asp:ListItem>
                     <asp:ListItem Value="1" Text="女"></asp:ListItem>
                    </asp:DropDownList>
                </li>
                <li>
                    <label style="width: 50px">证件：</label>
                    <asp:DropDownList runat="server" ID="CardType" style="width: 98px"></asp:DropDownList>
                </li>
                <li>
                    <label style="width: 60px">证件号码：</label><input type="text" class="inps txt" style="width: 130px" id="CardNo" runat="server" maxlength="20" />
                </li>
                <li>
                    <label>类型：</label>
                    <%--<select class="txt" style="width: 86px;" id="CategoryId" onchange="CategoryType()">

                    </select>--%>
                    <asp:DropDownList runat="server" ID="CategoryId" style=" width:85px; margin-right: 40px;"></asp:DropDownList>
                </li>
                <li>
                    <label style="width: 50px">销售员：</label>
                    <select class="" style="width: 100px" id="SalerId">
                    </select>
                </li>
                <li>
                    <label>手机号码：</label>
                    <input type="text" class="inps txt" style="width: 130px" id="Phone" runat="server" maxlength="11" />
                </li>
                <li>
                    <label>生日：</label>
                    <input type="text" class="inps txt" style="width: 78px" id="BirthDay" onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss',onpicked:function() {AddDay()}})" runat="server"/>
                </li>
                <li id="pwdhide">
                    <label style="width: 50px">卡密码：</label>
                    <%--<input type="password" class="inps " style="width: 90px;" id="Password" runat="server" maxlength="15" />--%>
                    <asp:TextBox ID="Password" runat="server" CssClass="inps" TextMode="Password"  style="width: 90px;"></asp:TextBox>
                </li>
                <li style="width: 100%">
                    <label style="width: 60px">喜好：</label>
                    <input type="text" class="inps" style="width: 500px" id="Love" runat="server" maxlength="100" />
                </li>
                <li style="width: 100%">
                    <label style="width: 60px">地址：</label>
                    <input type="text" class="inps" style="width: 500px" id="Address" runat="server" maxlength="100" />
                </li>
                <li style="width: 100%">
                    <label style="width: 60px">备注：</label>
                    <input type="text" class="inps" style="width: 500px" id="Remark" runat="server" maxlength="100" />
                </li>
            </ul>
        </div>
        <div class="types" style="background: #EFEFEF; border: 1px solid #ddd" id="ShowMd" runat="server">
            <ul>
                <li>
                    <label>支付方式：</label>
                    <%--<select style="width: 80px" id="PayMethod">
                    </select>--%>
                    <asp:DropDownList runat="server" ID="PayMethod"></asp:DropDownList>
                </li>
                <li>
                    <label>收款金额：</label>
                    <input type="text" class="inps" style="width: 70px" id="Amount" runat="server" maxlength="10" />
                    <!--                   <label style="color: #0788bd;">说明：收款金额是卡费</label>-->
                </li>
                <li>
                    <label style="width: 60px">充值金额：</label>
                    <input type="text" class="inps" style="width: 70px" id="TopAmount" name="TopAmount" maxlength="10" onfocus="this.blur()" runat="server" />
                </li>
                <li>
                    <label style="width: 60px">赠送积分：</label>
                    <input type="text" class="inps" style="width: 70px" id="GiveScore" maxlength="10" onfocus="this.blur()" name="GiveScore"/>
                </li>
            </ul>
        </div>
        <div class="types" runat="server" id="showDiv">
            <ul>
                <li>
                    <label>&nbsp;&nbsp;总积分：</label>
                    <span style="width: 90px" class="txt inps" id="TotalScore" runat="server">0.00</span>
                </li>
                <li>
                    <label>兑换积分：</label>
                    <span style="width: 90px" class="txt inps" id="UsedScore" runat="server">0.00</span>
                </li>
                <li>
                    <label>剩余积分：</label>
                    <span style="width: 90px" class="inps" id="UsableScore" runat="server">0.00</span>
                </li>
                <li>
                    <label>冻结积分：</label>
                    <span style="width: 90px" class="txt inps" id="FrozenScore" runat="server">0.00</span>
                </li>
                <li>
                    <label>&nbsp;&nbsp;总储值：</label>
                    <span style="width: 90px" class="txt inps" id="TotalAmount" runat="server">0.00</span>
                </li>
                <li>
                    <label>消费储值：</label>
                    <span style="width: 90px" class="inps" id="UsedAmount" runat="server">0.00</span>
                </li>
                <li>
                    <label>储值余额：</label>
                    <span style="width: 90px" class="txt inps" id="UsableAmount" runat="server">0.00</span>
                </li>
                <li>
                    <label>消费次数：</label>
                    <span style="width: 90px" class="txt inps" id="ConsumeTimes" runat="server">0.00</span>
                </li>
                <li>
                    <label>消费金额：</label>
                    <span style="width: 90px" class="inps" id="ConsumeAmount" runat="server">0.00</span>
                </li>
                <li>
                    <label>卡片状态：</label>
                    <span style="width: 90px" class="txt inps" id="StatusName" runat="server" >&nbsp;</span>
                </li>
                <li>
                    <label>发卡时间：</label>
                    <span style="width: 90px" class="txt inps" id="OpenDate" runat="server">&nbsp;</span>
                </li>
                <li>
                    <label>有效时间：</label>
                    <span style="width: 90px" class="inps" id="ExprieDate" runat="server">&nbsp;</span>
                </li>
            </ul>
        </div>
        <div class="types">
            <ul style="float: right; width: 262px">
                <li id="ShowFee" runat="server">
                    <input type="checkbox" class="inps" id="NoCardFee" name="NoCardFee" runat="server" value="1" onchange="BtnCardFee()" style="border: 0px; margin-top: 6px" />&nbsp;免卡费
                </li>
                <li>
                    <input type="submit" class="bus_add " value="会员发卡" id="BtnSave" runat="server" onclick="return IsFill();" onserverclick="BtnSave_Click"/>
                </li>
                <li style="margin-right: 0px">
                    <input type="button" id="BtnDel" class="bus_dell " onclick="Close()" value="关闭" style="margin-right: 0px" />
                </li>
            </ul>
        </div>
    </div>
    </form>
</body>
</html>
