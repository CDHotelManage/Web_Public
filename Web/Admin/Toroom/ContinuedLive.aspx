<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContinuedLive.aspx.cs" Inherits="CdHotelManage.Web.Admin.Toroom.ContinuedLive" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
      <script src="../../js/jquery.js" type="text/javascript"></script>
    <script src="../../js/hDate.js" type="text/javascript"></script>
    <link href="../../style/css.css" rel="stylesheet" type="text/css" />
    <link href="../../style/hDate.css" rel="stylesheet" type="text/css" />
    <link href="../../style/Opendiv.css" rel="stylesheet" type="text/css" />
    <script src="../../js/DivWH.js" type="text/javascript"></script>
    <script src="../../calendar/WdatePicker.js" type="text/javascript"></script>
    <script src="../js/base.js" type="text/javascript"></script>
    <script type="text/javascript">
        function clos1() {
            clo("续住");
        }
        function addsDate() {
            var txtNum = document.getElementById("txt_liveDay").value;
               var ydDate = document.getElementById("txt_ydDate").value;
            if (txtNum == "") {
                document.getElementById("txt_liveDay").value = "1";
                txtNum = 1;
             }
             document.getElementById("txt_xdDate").value = getNewDay(ydDate, txtNum);
         }

         function XZintRZ(obj, order_id) {
         var desp=$("#txt_yjMoney").val();
         var url = "/Admin/ShiftExc/OccupancySingle.aspx?orrderID=" + order_id + "&desp=" + desp;
         showMyWindow("打印收款单", url, 400, 620, true, true, true, Close);
         }

         function Close() {
             ShowTabs('房态图');
         }

          function ShowTabs(title) {
            // 关闭当前
            var jq = top.jQuery;
            var url = "/admin/Toroom/ToRoom.aspx";
            AddTabs(title, url);
            window.location.reload(true);
            if (jq('#tabs').tabs('exists', "房态图")) {
                var jq = top.jQuery;
                var a = "房态图";
                clo(a);
                AddTabs(title, url);

            }
            clos();
        }

        function clos() {
            clo("续住");
        }


        function AddDays(Num) {
            var ydDate = document.getElementById("txt_ydDate").value;
            alert(ydDate);
            var LSTR_ndates = new Date();
            alert(LSTR_ndates);
            var LSTR_ndate = new Date(ydDate);
            alert(LSTR_ndate);
           var MHS=" "+ LSTR_ndate.getHours() + ":" + LSTR_ndate.getMinutes() + ":" + LSTR_ndate.getSeconds();
            var LSTR_Year = LSTR_ndate.getFullYear();
            var LSTR_Month = LSTR_ndate.getMonth();
            var LSTR_Date = LSTR_ndate.getDate();
            alert(LSTR_Year);
            alert(LSTR_Month);
            alert(LSTR_Date);
            //处理 
            var uom = new Date(LSTR_Year, LSTR_Month, LSTR_Date);
            uom.setDate(uom.getDate() + parseInt(Num)); //取得系统时间的前一天,重点在这里,负数是前几天,正数是后几天
            var LINT_MM = uom.getMonth();
            LINT_MM++;
            var LSTR_MM = LINT_MM > 10 ? LINT_MM : ("0" + LINT_MM)
            var LINT_DD = uom.getDate();
            var LSTR_DD = LINT_DD > 10 ? LINT_DD : ("0" + LINT_DD)
            //得到最终结果 
            uom = LSTR_Year + "-" + LSTR_MM + "-" + LSTR_DD + MHS;
            document.getElementById("txt_xdDate").value = uom;
        }
        //日期加上天数得到新的日期  
        //dateTemp 需要参加计算的日期，days要添加的天数，返回新的日期，日期格式：YYYY-MM-DD  
        function getNewDay(dateTemp, days) {
            var dateTemps = dateTemp.split(" ");
            var dateTemp = dateTemps[0].split("-");
            var nDate = new Date(dateTemp[1] + '-' + dateTemp[2] + '-' + dateTemp[0]); //转换为MM-DD-YYYY格式
            var millSeconds = Math.abs(nDate) + (days * 24 * 60 * 60 * 1000);
            var rDate = new Date(millSeconds);
            var year = rDate.getFullYear();
            var month = rDate.getMonth() + 1;
            if (month < 10) month = "0" + month;
            var date = rDate.getDate();
            if (date < 10) date = "0" + date;
            return (year + "-" + month + "-" + date + " " + dateTemps[1]);
        }
        function AddDay() {
            var yltime = document.getElementById("txt_xdDate").value;
            var ydtime = document.getElementById("txt_ydDate").value;  
            document.getElementById("txt_liveDay").value = DateDiff(yltime, ydtime);
         }
        //两日期计算天数
        function DateDiff(sDate1, sDate2) {    //sDate1和sDate2是2006-12-18格式  
            var aDate, oDate1, oDate2, iDays
            aDate = sDate1.split("-")
            oDate1 = new Date(aDate[1] + '-' + aDate[2] + '-' + aDate[0])    //转换为12-18-2006格式  
            aDate = sDate2.split("-")
            oDate2 = new Date(aDate[1] + '-' + aDate[2] + '-' + aDate[0])
            iDays = parseInt(Math.abs(oDate1 - oDate2) / 1000 / 60 / 60 / 24)    //把相差的毫秒数转换为天数  
            return iDays
        }
        
        function isfill() {

            var price = document.getElementById("txt_yjMoney").value;
            if (price == "") {
                alert('押金不能为空');
                return false;
            } else { return true; }
        }

        function clo() {
            var bodyHeight = document.documentElement.clientHeight;
            var bodyWidth = document.documentElement.clientWidth;
            var div = document.getElementById("DivGV");

            if (div != null) {

                //  div.style.width = (bodyWidth - 20) + "px";
                $(div).height(bodyHeight - 56);
            }
        }
    </script>
</head>
<body onload="clo()" style="background:#fff">
<!--续住OK-->
<div id="DivGV">
    <form id="form1" runat="server">
        <ul class="sprzul">
           <li>房　　号：<asp:Label ID="labfh" runat="server" Text="Label"></asp:Label></li>
           <li>房　　型：<asp:Label ID="labfx" runat="server" Text="Label"></asp:Label></li>
           <li>开房方式：<asp:Label ID="labkffs" runat="server" Text="Label"></asp:Label></li>
           <li>来　　源：<asp:Label ID="lably" runat="server" Text="Label"></asp:Label></li>
           <li>姓　　名：<asp:Label ID="labname" runat="server" Text="Label"></asp:Label></li>
           <li>入住时间：<asp:Label ID="labrzDate" runat="server" Text="Label"></asp:Label></li>
           <li>房价方案：<asp:Label ID="labfjMoney" runat="server" Text="Label"></asp:Label></li>
           <li>已交押金：<asp:Label ID="labSymoney" runat="server" Text="Label"></asp:Label></li>
          
        </ul>
        <div class="bhsl_left002">
        <ul class="sprzul02" >
          <li>原定日期：<input id="txt_ydDate"  type="text" runat="server" class="ydxddate textbox-text_hrj textbox_hrj" disabled="disabled" /></li>
          <li>续住天数：<input style=" width:60px;" type="text" id="txt_liveDay" onchange="addsDate();" value="1" runat="server" class="xztsyj textbox-text_hrj textbox_hrj" /></li>
          <li>现定离期：<input type="text" name="textfield" id="txt_xdDate" onchange="AddDay()"  onclick="WdatePicker({startDate:'%y-%M-%d 07:59',dateFmt:'yyyy-MM-dd HH:mm:ss'})" runat="server" class="ydxddate textbox-text_hrj textbox_hrj" /></li>
          <li>支付方式：<asp:DropDownList ID="DDlZffs" DataTextField="meth_pay_name" CssClass="textbox-text_hrj textbox_hrj" DataValueField="meth_pay_id"
                runat="server"></asp:DropDownList></li>
         <li>押　　金：<input type="text" id="txt_yjMoney" runat="server" class="xztsyj2 textbox-text_hrj textbox_hrj" /></li>
        </ul>
        <div class="bzdiv" style=" margin-top:8px;">备　　注：<input type="text" name="textfield" id="txt_Remaker" style=" width:82%;" class="textbox-text_hrj textbox_hrj" runat="server" /></div>
        </div>
        <div class="xzbtn" style="text-align:right" >

            <asp:Button ID="btnAdds" runat="server" Text="续住" class="button_orange "  OnClientClick="if(isfill()){}else{return false;}" Style="width: 100px"     onclick="btnAdds_Click"/>
            <input name="关　闭" type="button" value=" 关　闭 " class="button_gray " onclick="clos1();" style="width: 100px;" /></div>
  
    </form>
    </div>
</body>
</html>
