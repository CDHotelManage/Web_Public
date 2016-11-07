<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Remaker.aspx.cs" Inherits="CdHotelManage.Web.Admin.Toroom.Remaker" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../style/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function Isfill() {
            var remaker = document.getElementById("txt_remaker").value;
            if (remaker == "") {
                alert('备注不能为空');
                return false;
            } else {
               return true;
             }
         }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" id="hidtype" runat="server" />
    <div style=" text-align:center;">
    <div style=" padding-top:10px;">
    备注：<input type="text" runat="server" id="txt_remaker" />
    </div>
    <div style=" padding-top:20px;">
        <asp:Button ID="btnAdds" CssClass="greenBtn"  runat="server" Text="保存"  OnClientClick="if(Isfill()){}else{return false;}" onclick="btnAdds_Click" />&nbsp;&nbsp;<input type="button" class="grayBtn midBtn"  value="关闭" onclick="parent.Window_Close();" id="btnClose" />
    </div>
    </div>
    </form>
</body>
</html>
