<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Refund.aspx.cs" Inherits="CdHotelManage.Web.Admin.Book.Refund" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../style/css.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="/Admin/js/base.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#Label1").text(parseInt($("#lbdeposit").text()) + parseInt($("#ytuiqian").text()));

        })
        function ShowT() {
            var vas = $("#tdeposit").val();
            if (vas != "") {
                if (!isNaN(vas)) {
                    if (vas > parseInt($("#Label1").text())) {
                        alert("不能大于可退金额!!");
                        return false;
                    }
                    return true;
                } else {
                    alert("请输入有效金额！");
                    return false;
                }
            }
            else {
                alert("不能为空！");
                return false;
            }
        }
        function ShowDivs(obj, id) {
            var desp = $("#tdeposit").val();
            var url = "/Admin/ShiftExc/Advance.aspx?id=" + id + "&desp=-" + desp;
           
            showMyWindow("打印预定退款单", url, 400, 500, true, true, true, Close);
        }
        function Close() {
            ShowTabs('预定管理');
        }

        function ShowTabs(title) {
            // 关闭当前
            parent.window.location.reload(true);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
   	
				<div class="titleDB">
                <span style="color:#4486b7">退定金</span><span class="youfu fontRed">单号：<asp:Label ID="lbbookno" runat="server"
                    Text="Label"></asp:Label></span></div>
				<ul class="sprzul03">
					<li >姓　　名:<asp:Label ID="lbname" runat="server" Text="Label"></asp:Label></li>
					<li >电　　话:<asp:Label ID="lbtele" runat="server" Text="Label"></asp:Label></li>			
					<li >已交订金:<asp:Label ID="lbdeposit" runat="server" Text="Label"></asp:Label></li>
                    <li>已退定金:<asp:Label ID="ytuiqian" runat="server" Text="Label"></asp:Label></li>
                    <li>可退定金:<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></li>
				</ul>
					
		
		 <!--灰色部分开始-->
			  <ul class="sprzul03" style="background:#f2f2f2">
	            <li>支付方式:<asp:DropDownList ID="meth_payDdl" runat="server"></asp:DropDownList></li> 
		 	    <li style="width:300px">退 订 金:<input type="text" name="textfield" runat ="server"  id = "tdeposit" style="width:85px" /></li>
			    <li style="width:610px">备 注:<input type="text" name="textfield" style="width:540px" runat="server" id ="txtremark" /></li>
		 　　　</ul> 
	
		<div class="btnWrap">			
            <asp:Button ID="Button1" runat="server" Text="退订金" class="orangeBtn midBtn"  onclick="Button1_Click" OnClientClick="return ShowT()" />					
            <asp:Button ID="Button2" runat="server" Text="关　闭" class="grayBtn midBtn"/>
		 </div>	<!--按纽结束-->

<div class="clearboth"></div>
    </form>
</body>
</html>
