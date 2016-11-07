<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoomTypeAdd.aspx.cs" Inherits="CdHotelManage.Web.Admin.Menus.RoomTypeAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../style/css.css" type="text/css" rel="stylesheet">
    <script src="../../js/DivWH.js" type="text/javascript"></script>
    <link href="../../style/Opendiv.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #Text3
        {
            width: 49px;
        }
        #Text4
        {
            width: 49px;
        }
        #Text5
        {
            width: 49px;
        }
    </style>
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
    </script>
</head>
<body>
    <form id="form1" runat="server">



     
   <ul  class="addRoomFX" style=" margin:0 auto">
     <li>房型 名 称：<input type="text" id="txt_roomName" CLASS="fh001" runat="server" /></li>
     <li>挂　牌　&nbsp;&nbsp;价：<input type="text" id="txt_room_listedmoney" class="fh001" runat="server" /></li>
     <li>房　　　型：<asp:DropDownList ID="ddroomtype" DataTextField="room_name" DataValueField="id"  CssClass="fxSel001" style="height:24px;" runat="server">  </asp:DropDownList></li>
     <li>周末挂牌价：<input type="text" id="txt_room_zmmoney"  class="AFXinput" runat="server" /></li>
     <li class="Vmiddle">允许钟点房：<asp:RadioButton ID="raddyes" runat="server" name="ab" onclick="GetRadio()"
                    Checked="true" Text="允许" /><asp:RadioButton ID="raddno" runat="server" Text="不允许"
                        name="ab" onclick="GetRadio()" /></li>
     <li  id="divzdf" >钟　点　房：<input type="text" id="Text3" class="zdfInput AFXinput" runat="server" /> 元<input type="text"  id="Text4" runat="server" class="zdfInput fh001" />小时，每超一个小时加收<input type="text" class="zdfInput AFXinput" id="Text5" runat="server" />元</li>
    <li>备　　　注：<input type="text" id="txt_Reamker" runat="server" CLASS="fh001" /></li>
   </ul>
    <div class="ARCbtn02">
    <asp:Button ID="btnAdd" runat="server" Text="　添 加　"　CssClass="greenBtn" style="height:30px;" OnClick="btnAdd_Click" />
    </div>



    
        
    
    </form>
</body>
</html>
