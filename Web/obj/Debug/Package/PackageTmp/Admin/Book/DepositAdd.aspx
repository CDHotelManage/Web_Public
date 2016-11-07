<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepositAdd.aspx.cs" Inherits="CdHotelManage.Web.Admin.Book.DepositAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../js/jquery-1.9.1.min.js" type="text/javascript"></script>
     <link href="../../style/css.css" rel="stylesheet" type="text/css" />
    <link href="../../style/Opendiv.css" rel="stylesheet" type="text/css" />
    <script src="../../js/DivWH.js" type="text/javascript"></script>
    <script src="../js/base.js" type="text/javascript"></script>
    <script type="text/javascript">
        function ShowDivs(id) {
            var obj = $("#button03", window.parent.document);
            var desp = $("#adddeposit").val();
            var url = "/Admin/ShiftExc/Advance.aspx?id=" + id + "&desp=" + desp;
            
            showMyWindow("打印预定收款单", url, 400, 500, true, true, true, Close);
        }
        function Close() {
            parent.window.location.reload(true);
        }
    </script>
</head>


<body><!--补交订金-->
    <form id="form1" runat="server" >
				<div class="titleDB">
                <span style="color:#4486b7">补交订金</span><span class="fontRed" style=" float:right;">单号：<asp:Label ID="lbbookno" runat="server"
                    Text="Label"></asp:Label></span></div>
				<ul class="sprzul03">
					<li >姓　　名:<asp:Label ID="lbname" runat="server" Text="Label"></asp:Label></li>
					<li >电　　话:<asp:Label ID="lbtele" runat="server" Text="Label"></asp:Label></li>
					<li >订单来源:<asp:Label ID="lbsource" runat="server" Text="Label"></asp:Label></li>
					<li >房　　型:<asp:Label ID="lbroomtype" runat="server" Text="Label"></asp:Label></li>
					<li >房　　数:<asp:Label ID="lbrealnum" runat="server" Text="Label"></asp:Label></li>					
					<li >已交订金:<asp:Label ID="lbdeposit" runat="server" Text="Label"></asp:Label></li>					
				</ul>
		 <!--灰色部分开始-->
			  <ul class="sprzul03" style="background:#f2f2f2">
	            <li>支付方式:<asp:DropDownList ID="meth_payDdl" runat="server"></asp:DropDownList></li> 
		 	    <li style="width:300px">订　　金:<input type="text" name="textfield" runat ="server"  id="adddeposit" style="width:85px" /></li>
			    <li style="width:610px">备　　注:<input type="text" name="textfield" style="width:540px" runat="server" id ="txtremark" /></li>
		 　　　</ul>
		<div class="btnWrap">			
            <asp:Button ID="Button1" runat="server" Text="补交订金" class="orangeBtn midBtn"  onclick="Button1_Click" />					
            <asp:Button ID="Button2" runat="server" Text="关　闭" class="grayBtn midBtn"  onclick="Button2_Click"/>
		 </div>	<!--按纽结束-->

<div class="clearboth"></div>
    </form>
</body>
</html>
