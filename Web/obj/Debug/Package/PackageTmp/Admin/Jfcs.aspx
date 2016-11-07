<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Jfcs.aspx.cs" Inherits="CdHotelManage.Web.Admin.Jfcs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../style/css.css" rel="stylesheet" type="text/css" />
    <script src="../../js/hDate.js" type="text/javascript"></script>
    <script src="../../calendar/WdatePicker.js" type="text/javascript"></script>
    <script src="../js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="../js/DivWH.js" type="text/javascript"></script>
    <link href="../style/Opendiv.css" rel="stylesheet" type="text/css" />
   
   <script type="text/javascript">
       $(function () {
           $(".itset li").click(function () {
               $(".itset li").css("background", "#D0F2FF");
               $(this).css("background", "#E5FFD2");
           })
       })
   </script>
    <style type="text/css">
         .Divleft
        {
            width: 10%;
            float: left;
            margin-left:30px;
        }
        .csszText{ letter-spacing:3px;}
        .Divright
        {
            width: 80%;
            float: right;
            margin-top: 0px;
            border: 1px solid #ddd;
            margin-left: 10px;
            padding: 10px 10px;
        }
        ul.itset li
        {
            width: 90%;
            text-align: left;
            padding-left: 10%;
            line-height: 32px;
            color: #333;
            cursor: pointer;
            position: relative;
            margin-top: 0px;
            border-bottom: 1px solid #fff;
            border-left: 1px solid #fff;
            border-right: 1px solid #fff;
            background: #D0F2FF;
        }
       .itset li:hover{ background: #E5FFD2;}
         h1
        {
            padding-left: 30px;
            margin-top: 20px;
            margin-bottom: 10px;
            font-size: 19px;
        }
        .w30{ width:30px; text-align:center;}
        .w60{ width:60px;}
        .ifa{ width:100%; border:0; height:500px; border-width:0;}
    </style>
</head>
<body class="bgIndex">
<form runat="server" id="form1">
 <h1 class="h1s">计费设置</h1>
 <div class="Divleft">
            <ul class="itset">
                <a href="/admin/Menus/Billing.aspx" target="ifa"><li>计费设置</li></a>
                <a href="/admin/Menus2/print.aspx" target="ifa"><li>单据设置</li></a>
                <a href="/admin/Menus/Setup.aspx" target="ifa"><li>房态设置</li></a>
                <a href="Menus2/InteSyS.aspx" target="ifa"><li>门锁接口</li></a>
                <a href="#"><li>身份证接口</li></a>
                <a href="#"><li>微信设置</li></a>
            </ul>
 </div>

	<div class="Divright" >        
				<iframe class="ifa" name="ifa" FRAMEBORDER="0" src="/admin/Menus/Billing.aspx"></iframe>
					
	</div><!--main结束-->
   
<br />
<div class="clearboth">     </div>
<!-- InstanceEndEditable -->
</form>
</body>
<!-- InstanceEnd --></html>
