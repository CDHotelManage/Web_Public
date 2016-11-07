<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Priceinfor.aspx.cs" Inherits="CdHotelManage.Web.Admin.Menus.Priceinfor" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加费用</title>
    <link href="../../style/css.css" rel="stylesheet" type="text/css" />
    <script src="../../js/DivWH.js" type="text/javascript"></script>
    <link href="../../style/Opendiv.css" rel="stylesheet" type="text/css" />
    <script src="../../js/hDate.js" type="text/javascript"></script>
    <script src="../../js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <style type="text/css">
       .quanxian{ padding-top:20px; }
    </style>
    <script type="text/javascript">
        function Vail() {
//            alert($("#txtName").val());
            if ($("#txtName").val() == "") {
                alert("费用名称不能为空！！");
                return false;
            }
            else if ($("#txtPrice").val() == "") {
                alert("价格不能为空！！");
                return false;
            }
            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="quanxian">
         <ul  class="addRoomCon">
            <li>
                费用类别：
                     
                <asp:DropDownList ID="DDlfylb" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDlfylb_SelectedIndexChanged">
                </asp:DropDownList>
           </li>
          
                <li>编&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;号：
                    <input type="text" id="txtBH" runat="server" maxlength="10" />
                    <input type="hidden" id="ShopBH" />
                </li>
                <li>费用名称：<input type="text" id="txtName" runat="server" maxlength="30" />
                </li>
                <li>单&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 价：<input id="txtPrice" runat="server" type="text" maxlength="6" />
                    </li>
                <li id="listatus">状&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;态：
                    <input type="radio" id="radStatu" name="a" checked="checked" value="0" class="radio" />使用
                    <input type="radio" id="radStatus" name="a"  id="1" value="1" class="radio" />停用
                </li>
                <li>备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 注：<textarea runat="server" id="txtRemark"></textarea></li>
                <li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnAdd" runat="server" CssClass="greenBtn"  OnClientClick="if(Vail()){ }else{return false}"
                         OnClick="btnAdd_Click" style="height:26px;" Text="　添 加　" />
                </li>
            </ul>
            <input type="hidden" id="hidid" value="0" />
        </div>
    </div>
    </form>
</body>
</html>
