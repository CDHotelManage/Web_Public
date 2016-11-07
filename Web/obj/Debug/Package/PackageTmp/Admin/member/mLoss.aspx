<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mLoss.aspx.cs" Inherits="CdHotelManage.Web.Admin.member.mLoss" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/tch.css" rel="stylesheet" type="text/css" />
    <link href="../css/tooms.css" rel="stylesheet" type="text/css" />
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <link href="../css/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
    <script src="../../calendar/WdatePicker.js" type="text/javascript"></script>
    <script src="../js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../js/lss.js" type="text/javascript"></script>
    <script src="../js/base.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" id="CategoryId" runat="server" />
    <input type="hidden" id="mid" runat="server" />
    <div class="vip_infor" style="width: 800px">
        <div class="line">
            <div class="fl" id="lal" style=" display:none;" runat="server">会员充值</div>
            <input type="hidden" id="CardId" />
            <div class="errortips" id="btnRead"></div>
            <input type="hidden" id="CCardNo" />
            <input type="hidden" id="MemberPrepaid" />
        </div>
        <div class="types" style="margin: 0px">
            <ul>
                <li>
                    <label>条件：</label>
                    <input type="text" class="txt inps" id="CardNo" autocomplete="off" maxlength="20" runat="server" />
                    <input type="button" class="credit" value="查询" id="btnQuery" runat="server" />
                    <input type="button" class="credit " value="读卡" id="btnReadCard" runat="server" />
                    <input type="button" class="credit " value="写卡" id="btnWriteCard" runat="server" style="display: none;"/>
                    <input type="button" class="credit " value="清卡" id="btnClearCard"  runat="server" style="display: none;" />
                </li>
            </ul>
        </div>
        <div class="types" style="background: #EFEFEF; border: 1px solid #ddd; margin-top: 0px">
            <ul>
                <li>
                    <label>姓名：</label>
                    <span class="txt inps" style="width: 90px" id="Name">&nbsp;</span></li>
                <li>
                    <label style="width: 50px">证件：</label>
                    <span class="txt inps" style="width: 90px" id="MemberType">&nbsp;</span></li>
                <li>
                    <label>证件号码：</label>
                    <span class="txt inps" id="MemberCardNo">&nbsp;</span></li>
                <li>
                    <label>类型：</label>
                    <span class=" inps" style="width: 80px" id="CategoryName">&nbsp;</span></li>
                <li>
                    <label>生日：</label>
                    <span class="inps txt" style="width: 90px" id="BirthDay">&nbsp;</span></li>
                <li>
                    <label style="width: 50px">销售员：</label>
                    <span class="inps txt" style="width: 90px" id="SalerMan">&nbsp;</span></li>
                <li>
                    <label>手机号码：</label>
                    <span class="inps" id="Phone">&nbsp;</span></li>
                <li style="width: 100%">
                    <label>喜好：</label>
                    <span class="inps" style="width: 730px" id="Love">&nbsp;</span></li>
                <li style="width: 100%">
                    <label>地址：</label>
                    <span class="inps" style="width: 730px" id="Address">&nbsp;</span></li>
                <li style="width: 100%">
                    <label>备注：</label>
                    <span class="inps" style="width: 730px" id="Remark">&nbsp;</span></li>
            </ul>
        </div>
        <div class="types" style="background: #EFEFEF; border: 1px solid #ddd">
            <ul>
                <li>
                    <label>&nbsp;&nbsp;总积分：</label>
                    <span class="txt inps" style="width: 90px" id="TotalScore">0.00</span></li>
                <li>
                    <label>兑换积分：</label>
                    <span class="txt inps" style="width: 90px" id="UsedScore">0.00</span></li>
                <li>
                    <label>剩余积分：</label>
                    <span class="txt inps" style="width: 90px" id="UsableScore">0.00</span></li>

                <li>
                    <label>冻结积分：</label>
                    <span class="inps" style="width: 90px" id="FrozenScore">0.00</span>
                </li>
                <li>
                    <label>&nbsp;&nbsp;总储值：</label>
                    <span style="width: 90px" class="txt inps" id="TotalAmount">0.00</span>
                </li>
                <li>
                    <label>消费储值：</label>
                    <span style="width: 90px" class="inps txt " id="UsedAmount">0.00</span>
                </li>

                <li>
                    <label>储值余额：</label>
                    <span style="width: 90px" class="txt inps" id="UsableAmount">0.00</span>
                </li>
                <li>
                    <label>消费次数：</label>
                    <span class="inps" style="width: 90px" id="ConsumeTimes">0.00</span></li>
                <li>
                    <label>消费金额：</label>
                    <span class="txt inps" style="width: 90px" id="ConsumeAmount">0.00</span></li>

                <li>
                    <label>卡片状态：</label>
                    <span class="txt inps" style="width: 90px" id="StatusName">&nbsp;</span></li>
                <li>
                    <label>发卡时间：</label>
                    <span class="inps txt" style="width: 90px" id="OpenDate">&nbsp;</span></li>
                <li>
                    <label>有效时间：</label>
                    <span class="inps" style="width: 90px" id="ExprieDate">&nbsp;</span></li>
            </ul>
        </div>
        <!--会员充值-->
        <div class="types" style="background: #EFEFEF; border: 1px solid #ddd;" id="hyck" runat="server">
            <ul>
                <li>
                    <label>支付方式：</label>
                    <asp:DropDownList runat="server" ID="PayMethod"></asp:DropDownList>
                </li>
                <li>
                    <label>收款金额：</label>
                    <input type="text" class="inps" style="width: 70px" id="PaymentAmount" runat="server" maxlength="6" />
                    <label style="margin-right: 5px">元</label></li>
                <li>
                    <label>充值金额：</label>
                    <input type="text" class="inps" style="width: 70px" id="TopAmount" runat="server" onfocus="this.blur()" />
                    <label style="margin-right: 5px">元</label>
                </li>
                <li>
                    <label>赠送积分：</label>
                    <input type="text" class="inps" style="width: 70px" id="GiveScore" runat="server" onfocus="this.blur()" />
                </li>
                <li>
                    <label>销售员：</label>
                    <select style="width: 80px" id="SalerId"></select>
                </li>
            </ul>
        </div>

        <div class="types" style="background: #EFEFEF; border: 1px solid #ddd;" id="jftz" runat="server">
            <ul>
                <li>
                    <label style="width: 60px">调整积分：</label>
                    <input type="text" class="inps" style="width: 90px" id="AdjustScore" maxlength="6" runat="server"><label style="width: 10px; padding-right: 24px">&nbsp;分</label></li>
                <li>
                    <label style="width: 60px">原因：</label>
                    <input type="text" class="inps" style="width: 502px" id="AdjustRemark">
                </li>
                <li>
                    <label style="color: #0788bd;">说明：正数代表增加积分，负数代表减少积分</label></li>
            </ul>
        </div>

        <%--会员换卡--%>
        <div class="types" style="background: #EFEFEF; border: 1px solid #ddd;" id="upCard" runat="server">
            <ul>
                <li>
                    <label style="width: 60px">新卡号：</label>
                    <input type="text" class="inps txt" style="width: 296px" id="NewCard" runat="server"></li>
                <li>
                    <label style="width: 60px">支付方式：</label>
                    <%--<select class="txt" style="width: 96px" id="Paymethed">
                    <option value="1213">现金</option><option value="13909">信用卡</option><option value="13910">支票</option><option value="13911">转帐</option><option value="20034">支付宝</option><option value="20035">团购券</option><option value="20041">金卡</option></select>--%>
                    <asp:DropDownList runat="server" ID="Paymethed1"></asp:DropDownList>
                    </li>
                <li>
                    <label>收款金额：</label>
                    <input type="text" class="inps" style="width: 90px" id="CardPrice" runat="server">
                </li>
            </ul>
        </div>
        <%--会员续卡--%>
        <div class="types" style="background: #EFEFEF; border: 1px solid #ddd; display:none;" id="xucard" runat="server">
            <ul>
                <li>
                    <label style="width: 60px">延长：</label>
                    <input type="text" class="inps" style="width: 120px" id="PeriodDay" runat="server" onclick="WdatePicker({dateFmt:'yyyy-MM-dd',onpicked:function() {AddDay()}})">
                    <label style="width: 50px; padding-right: 40px">天有效期</label></li>
                <li>
                    <label style="width: 60px">支付方式：</label>
                    <asp:DropDownList runat="server" ID="DropDownList1"></asp:DropDownList>
                </li>
                <li>
                    <label>收款金额：</label>
                    <input type="text" class="inps" style="width: 90px" id="PeriodPrice" runat="server"></li>
            </ul>
        </div>

        <%--会员退卡--%>
        <div class="types" style="background: #EFEFEF; border: 1px solid #ddd; display:none;" id="tuicard" runat="server">
            <ul>
                <li>
                    <label>退款金额：</label>
                    <input type="text" class="txt inps" style="width: 90px" id="OutPrice" runat="server">
                </li>
                <li>
                    <label style="width: 60px">支付方式：</label>
                    <asp:DropDownList runat="server" ID="DropDownList2"></asp:DropDownList>
                </li>
                <li>
                    <label style="width: 60px">退卡原因：</label>
                    <input type="text" class="inps" style="width: 298px" id="OutRemark">
                </li>
            </ul>
        </div>

        <%--密码--%>
        <div class="types" style="background: #EFEFEF; border: 1px solid #ddd; display:none;" id="pwdResl" runat="server">
            <ul>
                <li>
                    <label style="width: 60px">新密码：</label>
                    <input type="password" class="inps txt" style="width: 90px" id="NewPwd" runat="server" maxlength="15"></li>
                <li>
                    <label style="width: 60px">确认密码：</label>
                    <input type="password" class="inps" style="width: 90px" id="SavePwd" runat="server" maxlength="15"></li>
            </ul>
        </div>
        <!--会员升级-->
        <div class="types" style="background: #EFEFEF; border: 1px solid #ddd; display:none;" id="lvup" runat="server">
            <ul>
                <li>
                    <label style="width: 60px">升级类型：</label>
                    <input type="text" class="txt inps" style="width: 90px; color: #000" id="CategorgName" disabled="disabled">
                    <input type="hidden" class="inps" style="width: 90px" id="CategorgId" value="102" runat="server">
                </li>
                <li>
                    <label style="width: 60px">扣减积分：</label>
                    <input type="text" class="inps" style="width: 90px; color: #000" id="DeductScore" onfocus="this.blur()"></li>
            </ul>
        </div>

        <!--end-->
        <div class="types">
            <ul style="float: right; width: 174px">
                <li style="">
                    <input type="button" class="bus_add " value="会员充值" id="BtnSave" runat="server" onserverclick="BtnSaveClick"/></li>
                <li style="margin-right: 0px">
                    <input type="button" class="bus_dell " id="BtnDel" onclick="Close()" value="关闭" style="margin-right: 0px" />
                </li>
            </ul>
        </div>

        
    </div>
    <div class="ac_results" style="position: absolute; width: 420px; top: 57px; left: 46px;">
        <ul style="max-height: 180px; overflow: auto;">
                                
                                </ul>
    </div>
    </form>
</body>
</html>
