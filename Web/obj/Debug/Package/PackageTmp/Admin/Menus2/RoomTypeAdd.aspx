<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoomTypeAdd.aspx.cs" Inherits="CdHotelManage.Web.Admin.Menus2.RoomTypeAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../style/css.css" type="text/css" rel="stylesheet">
    <script src="../../js/DivWH.js" type="text/javascript"></script>
    <link href="../../style/Opendiv.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function GetRadio() {
            var rad1 = document.getElementById("raddyes");
            var rad2 = document.getElementById("raddno");
            var divzdfs = document.getElementById("divzdf");
            if (rad1.checked) {
                divzdfs.style.display = "";
            } else {
                divzdfs.style.display = "none";
            }
        }

        function IsFill() {
            if (document.getElementById("txt_room_listedmoney").value == "") {
                alert("挂牌价不能为空！");
                return false;
            }
            else if (document.getElementById("txt_lcPrice").value == "") {
                alert("凌晨价不能为空！");
                return false;
            }
            else if (document.getElementById("txt_yzprice").value == "") {
                alert("月租价不能为空！");
                return false;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <ul class="addRoomFX">
        <li>房型名称 ：<input type="text" id="txt_roomName" class="fh001" runat="server" /></li>
        <li>挂 &nbsp;牌 &nbsp;价：<input type="text" id="txt_room_listedmoney" class="fh001" runat="server" value="0"/></li>
        <li>零 &nbsp;晨 &nbsp;价：<input type="text" id="txt_lcPrice" class="fh001" runat="server" value="0"/></li>
        <li>月 &nbsp;租 &nbsp;价：<input type="text" id="txt_yzprice" class="fh001" runat="server" value="0"/></li>
        <li>周末挂牌价：<input type="text" id="txt_room_zmmoney" class="AFXinput" runat="server" value="0"/></li>
        <li>预超百分比:<input type="text" id="txt_iscy" runat="server" style=" width:30px;" value="0" />%.请填写百分比</li>
        <li class="Vmiddle">允许钟点房：
            <input type="radio" id="raddyes" style="  vertical-align: bottom;" runat="server" checked="true" name="a" value="允许"
                class="radio" />允许
            <input type="radio" id="raddno" style="  vertical-align: bottom;" runat="server" name="a" value="不允许" class="radio" />不允许
        </li>
       
        <li>备 注：<input type="text" id="txt_Reamker" runat="server" class="fh001" /></li>
    </ul>
    <div class="ARCbtn02">
        <asp:Button ID="btnAdd" runat="server" Text="　添 加　" CssClass="greenBtn" OnClientClick="return IsFill();"  Style="height: 30px;"
            OnClick="btnAdd_Click" />
    </div>
    </form>
</body>
</html>
