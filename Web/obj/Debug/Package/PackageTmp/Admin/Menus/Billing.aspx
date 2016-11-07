<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Billing.aspx.cs" Inherits="CdHotelManage.Web.Admin.Menus.Billing" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../style/css.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../js/hDate.js" type="text/javascript"></script>
    <script src="../../calendar/WdatePicker.js" type="text/javascript"></script>
    <style type="text/css">
      h1
        {
            padding-left: 30px;
            margin-top: 20px;
            margin-bottom: 10px;
            font-size: 19px;
        }
        .csszText{ line-height:30px; letter-spacing:2px;}
        .w30{ width:30px; text-align:center;}
        .w60{ width:60px;}
    </style>
    <script src="../js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <link href="../../style/Opendiv.css" rel="stylesheet" type="text/css" />
    <script src="../../js/DivWH.js" type="text/javascript"></script>
    <script src="../js/base.js" type="text/javascript"></script>
     <script type="text/javascript">
         $(function () {
             $("#EarlyFee").change(function () {
                 var v = $(this).val();
                 if (v == 2) {
                     $("#p1").css("display", "block");
                 }
                 else { $("#p1").css("display", "none"); }
             })
             $("#DayFee").change(function () {
                 var v = $(this).val();
                 if (v == 1) {
                     $("#p2").css("display", "block");
                 } else { $("#p2").css("display", "none"); }
             })  
         })
         function TypeOpen(obj) {
             var url = "/SysRootType.aspx";
             showMyWindow("费用设置", url, 550, 210, true, true, true);
         }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="titleBlue titles">参数设置</div>
				<ul class="csszText">
				  <li>1.入住后<input type="text" class="inputTime w30" id="CancellMin" runat="server"  />
				  分钟内允许撤单.<asp:CheckBox ID="IsDepost" runat="server" Text="" Checked="true" />登记时必须输入押金，不得抵于<input type="text" class="inputTime" id="deposit" runat="server" style=" width:100px; text-align:center;"/>元.</li>
                  <li>2.<asp:CheckBox ID="isOcczf" runat="server" Text=""/>脏房是否可以入住<asp:CheckBox ID="isCy" runat="server" Text=""  />是否可以超预定</li>
				  <li>3.天房超过退房时间可以再宽限<input type="text" class="inputTime w30" id="GraceTimeEarly" runat="server"/>分钟;凌晨房超时宽限<input type="text" class="inputTime w30" id="GraceTimeDay" runat="server"/>
				  分钟 . </li>
				   <li> 4.<asp:CheckBox ID="IsEarlyRoom1" runat="server" Text=""/>启用凌晨房<input type="text" class="inputTime w60" id="EarlyStart" runat="server" onClick="WdatePicker({dateFmt:'H:mm:ss',minDate:'0:00:00',maxDate:'24:00:00'})"/>点到<input type="text" class="inputTime w60" id="EarlyEnd" runat="server" onClick="WdatePicker({dateFmt:'H:mm:ss',minDate:'0:00:00',maxDate:'24:00:00'})"/>
				   点开房,执行凌晨房价格 .<br />
				   　凌晨房退房时间
				     <input type="text" class="inputTime w60" runat="server" id="EarlyOutTime" onClick="WdatePicker({dateFmt:'H:mm:ss',minDate:'0:00:00',maxDate:'24:00:00'})"/>,超时<select runat="server" id="EarlyFee"><option value="1">加收半天房费</option><option value="2">按分钟收房费</option><option value="3">不加收房费</option></select>，直到<select runat="server" id="EarlyFeeSel"><option value="1">次日</option><option value="2">当日</option></select><input type="text" class="inputTime w60" runat="server" id="EarlyOutTimes" onClick="WdatePicker({dateFmt:'H:mm:ss',minDate:'0:00:00',maxDate:'24:00:00'})"/><select runat="server" id="EarlyFeeTwo"><option value="0">加收全天房价</option><option value="1">转为全天房价</option></select></br><p id="p1">每隔<input type="text" class="inputTime w30" runat="server" id="Earlyapart"/>分钟加收<input type="text" class="inputTime w30" runat="server" id="EarlyapartAddP"/>元，不足<input type="text" class="inputTime w30" runat="server" id="EarlyInsufficient"/>分钟，超过<input type="text" class="inputTime w30" runat="server" id="EarlyInExceed"/>分钟加收<input type="text" class="inputTime w30" id="EarlyInAddPri" runat="server"/>元。</p> </li>
				   <li> 6.全天房中午退房时间<input type="text" class="inputTime w60" runat="server" id="DayOutTime" onClick="WdatePicker({dateFmt:'H:mm:ss',minDate:'0:00:00',maxDate:'24:00:00'})"/> 超时<select name="" id="DayFee" runat="server"><option value="0">加收半天房租</option>
				   <option value="1">按分钟收费</option>
				   </select>，直到<input type="text" class="w60" runat="server" id="DayFeeTwo" onClick="WdatePicker({dateFmt:'H:mm:ss',minDate:'0:00:00',maxDate:'24:00:00'})"/>加收全天房费,<br /><p id="p2">每隔
				   <input type="text" class="inputTime w30" runat="server" id="Dayapart"/>分钟加收<input type="text" class="inputTime w30" runat="server" id="DayapartAddP"/>元不足<input type="text" class="inputTime w30" runat="server" id="DayInsufficient"/>分钟，超过<input type="text" class="inputTime w30" id="DayInExceed" runat="server"/>分钟，加收<input type="text" class="inputTime w30" runat="server" id="DayInAddPri">元.<input type="checkbox" id="istype" runat="server"/><input type="button" class="sysliexing" value="按房间类型设置" onclick="TypeOpen(this);"/></p>
				   　天房在<input type="text" class="inputTime w60" runat="server" id="DayTime" onClick="WdatePicker({dateFmt:'H:mm:ss',minDate:'0:00:00',maxDate:'24:00:00'})"/>之前入住,客人视同前一天入住{建议和夜审时间相同}  夜审时间<input type="text" class="inputTime w60" runat="server" id="ysTime" onClick="WdatePicker({dateFmt:'H:mm:ss',minDate:'0:00:00',maxDate:'24:00:00'})"/></li></ul>
					
                     <input id="Button1" type="button" class="btnOk" value="保存" runat="server" onserverclick="btnOk_Click"/>
    </form>
</body>
</html>
