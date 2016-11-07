<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mAddType.aspx.cs" Inherits="CdHotelManage.Web.Admin.member.mAddType" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <link href="../css/tch.css" rel="stylesheet" type="text/css" />
    
    <script src="../../calendar/WdatePicker.js" type="text/javascript"></script>
    <script src="../../js/DivWH.js" type="text/javascript"></script>
    <link href="../../style/Opendiv.css" rel="stylesheet" type="text/css" />
    <script src="../js/base.js" type="text/javascript"></script>
    <script src="../js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../js/vip_membertype.js" type="text/javascript"></script>
    <script src="/easyui/jquery.easyui.min.js" type="text/javascript"></script>
    <link href="/easyui/themes/gray/easyui.css" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript">
        function ShowDiv(obj) {
            var url = "mtPrice.aspx?mtid=" + $("#mtid").val();
            showMyWindow("类型价格", url, 620, 400, true, true, true);

        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="vip_infor" style="width: 670px">
    <input type="hidden" value="" runat="server" id="mtid"/>
        <%--<div class="line">
            <div class="fl">会员类型</div>
            <input type="hidden" id="CategoryId" />
            <div class="errortips" id="btnRead"></div>
        </div>--%>
        <div class="types" style="margin: 0px">
            <ul>
                <li>
                    <label>名称：</label>
                    <input type="text" class="txt inps" runat="server" style="width: 138px" id="Name" maxlength="10" /></li>
                <li style="margin-left: 30px; display: inline">
                    <label>卡费：</label>
                    <input type="text" class="inps" runat="server" style="width: 60px" id="CardFee" value="0" maxlength="10" />
                    <label class="txt">&nbsp;元</label></li>
                <li style="margin-left: 30px; display: inline">
                    <input type="checkbox" runat="server" id="Limitcke" class="checkbox" name="Timelimit" value="0" onchange="bTimelimit()" />
                    <label>期限：</label>
                    <input type="text" id="XqTime" runat="server" onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss',onpicked:function() {AddDay()}})" style=" width:80px;"/>
                    <input type="hidden" class="inps Expire" style="width: 60px" id="Expire" runat="server" maxlength="4" />
                    <%--<label>&nbsp;天</label>--%></li>
            </ul>
        </div>
        <div class="types" style="background: #EFEFEF; border: 1px solid #ddd; margin-top: 0px">
            <ul>
                <li style="border-bottom: 1px dotted #fff; width: 100%">
                    <input type="checkbox" class="checkbox" name="ScoreEnable" value="0" id="ScoreChk" runat="server" onchange="bScoreEnable()" />
                    <label>积分卡</label></li>
                <li style="border-top: 1px dotted #ddd; width: 100%">
                    <input type="checkbox" name="SEnable" value="2" id="SEnable2" class="disabled" runat="server" onclick="SEnables1()" />
                    <label class="txt">按消费金额积分</label>
                    <input type="checkbox" class="checkbox Enable" id="Score_1" runat="server" name="ScoreInclude" value="1" />
                    <label style="padding-right: 20px">房租</label>
                    <input type="checkbox" class="checkbox Enable" id="Score_2" runat="server" name="ScoreInclude" value="2" />
                    <label class="txt">消费</label>
                    <label style="margin-left: 60px">每消费</label>
                    <input type="text" class="inps Enable" style="width: 60px" id="Rule_x" runat="server" maxlength="8" />
                    <label>&nbsp;元积&nbsp;</label>
                    <input type="text" class="inps Enable" style="width: 60px" id="Rule_y" runat="server" maxlength="8" />
                    <label>&nbsp;分</label>
                </li>
                <li style="border-top: 1px dotted #ddd; width: 100%">
                    <input type="checkbox" name="SEnables" id="SEnable1" runat="server" value="1" onclick="SEnables(this)" />
                    <label>按入住天数积分</label>
                    <label style="color: #0788bd;">说明:钟点房不参与积分</label>
                    <label style="padding-left: 132px">每入住</label>
                    <input type="text" class="inps stype" style="width: 60px" id="ScoreType_x"  runat="server"/>
                    <label>&nbsp;天积&nbsp;</label>
                    <input type="text" class="inps stype" style="width: 60px" id="ScoreType_y" runat="server" maxlength="8" />
                    <label>&nbsp;分</label>
                </li>
                <li style="border-top: 1px dotted #ddd; width: 100%">
                    <input type="checkbox"  class="checkbox Enable" id="IsAddScore" runat="server" /><label>积分兑换房租时是否计算积分.</label><label>每1元抵扣</label><input type="text" runat="server" style=" width:30px; " id="machJf"/><label>积分</label>
                </li>
            </ul>
        </div>
        <div class="types" style="background: #EFEFEF; border: 1px solid #ddd">
            <ul>
                <li style="width: 100%">
                    <input type="checkbox" class="checkbox" value="0" id="defaultPrice" runat="server" name="TheCARDS" onchange="bTheCARDS();" />
                    <label class="txt">储值卡</label>
                    <label>开卡时默认金额：</label>
                    <input type="text" class="inps TheCARDS" style="width: 60px" id="ThePrice" runat="server" maxlength="8" />
                    <label>&nbsp;元&nbsp;</label>
                </li>
            </ul>
        </div>
        <div class="types" style="background: #EFEFEF; border: 1px solid #ddd">
            <ul>
                <li style="border-bottom: 1px dotted #fff; width: 100%">
                    <label>会员设置</label></li>
                <li style="border-top: 1px dotted #ddd; width: 100%">
                    <input type="checkbox" class="checkbox" id="UpEnable" runat="server" name="UpEnable" value="0" onchange="bUpEnable()" />
                    <label>积分超过</label>
                    <input type="text" class="inps upable" style="width: 60px" id="UpScore" runat="server" maxlength="8" />
                    <label>&nbsp;分时，升级为&nbsp;</label>
                    <%--<select class="txt upable" id="MCategory" maxlength="8">
                    </select>--%>
                    <input type="hidden" runat="server" id="upmtid"/>
                    <asp:DropDownList runat="server" ID="MCategory">
                    
                    </asp:DropDownList>
                    <input type="checkbox" class="checkbox" name="IsReduceScore" id="IsReduceScore" runat="server" value="0" style="margin-left: 40px" />
                    <label>升级扣减相应积分</label>
                </li>
                <li style="border-top: 1px dotted #ddd; width: 100%">
                    <input type="checkbox" class="checkbox" name="RoomMin" id="RoomMin" runat="server" value="0" onchange="bRoomMin()" />
                    <label>天房可推迟</label>
                    <input type="text" class="inps Hour" style="width: 60px;" id="DayRoomHour" runat="server" maxlength="4" />
                    <label>&nbsp;个小时退房，钟点房可推迟&nbsp;</label>
                    <input type="text" class="inps Hour" style="width: 60px" id="HourRoomMin" runat="server" maxlength="4" />
                    <label>&nbsp;分钟退房&nbsp;</label>
                </li>
            </ul>
        </div>
        <div class="types" style="background: #EFEFEF; border: 1px solid #ddd">
            <ul>
                <li style="border-top: 1px dotted #ddd; width: 100%">
                    <label>首次入住房价</label>
                    <input type="text" class="inps" style="width: 60px" id="FirstPrice" runat="server" maxlength="8" />
                    <label>&nbsp;元&nbsp;</label>
                    <label style="color: #0788bd;">说明：首次入住房价输0表示按房价方案计算</label>
                </li>
                <li>
                    <label style="color: #0788bd;">说明：新增会员类型成功后请到设置页面添加相对应的房价方案</label></li>
            </ul>
        </div>
        <div class="types">
            <ul style="float: right; width: 274px">
            <li>
            <input type="button" value="设置类型价格"  class="bus_add " style=" display:none;" id="Btn_mtPrice" onclick="ShowDiv(this)" runat="server"/></li>
                <li style="">
                    <input type="submit" class="bus_add " id="BtnSave" onclick="return BtnClick();" value="确认" runat="server" onserverclick="BtnSave_Click" /></li>
                <li style="margin-right: 0px">
                    <input type="button" class="bus_dell" onclick="Close()" id="BtnDel" value="关闭" style="margin-right: 0px" /></li>
            </ul>
        </div>
    </div>
    </form>
</body>
</html>
