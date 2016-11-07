<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsCZ.aspx.cs" Inherits="CdHotelManage.Web.Admin.Toroom.GoodsCZ" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../../style/css.css" />
    <script src="../js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <style type="text/css">
     body{ font-size:12px; padding:20px;}
     .btnOk{ padding:3px 5px; width:60px; margin-left:70px; margin-top:30px;}
    </style>
    <script type="text/javascript">
        $(function () {
            $(".btnOk").click(function () {
                
            })
        })
        function IsFill() {
            if ($("#czprice").val().trim() == "") {
                alert("金额不能为空！");
                return false;
            }
            else {
                if (!isNaN($("#czprice").val().trim())) {
                    
                } else {
                alert("请输入正确格式的金额！");
                    return false;
                }
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" value="" id="txtid" runat="server" />
    单 &nbsp;据 &nbsp;号:<input type="text" id="txtorderid" runat="server" disabled="disabled"/><br /><br />
    冲帐金 额:<input type="text" id="czprice" runat="server" /><br /><br />
    冲帐原因:<%--<input type="text" id="yying" runat="server" style=" width:400px;"/>--%>
    <textarea id="yying" runat="server" style="width:200px;height:80px;  vertical-align: -webkit-baseline-middle;"></textarea>
    <br />
    <asp:Button ID="btnok" runat="server" Text="确定冲帐" CssClass="btnOk" OnClientClick="return IsFill();"  OnClick="btnOk_Click"/>
    </form>
</body>
</html>
