<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangeRoom.aspx.cs" Inherits="CdHotelManage.Web.Admin.Toroom.ChangeRoom" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../js/jquery.js" type="text/javascript"></script>
    <script src="../../js/hDate.js" type="text/javascript"></script>
    <link href="../../style/css.css" rel="stylesheet" type="text/css" />
    <link href="../../style/hDate.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <style type="text/css">
       #form1 .sprzul{overflow: inherit;}
      .lipre{ position:relative;}
      .bhsl_left002  .sprzul .dio{ position:absolute; left:70px; top:28px; border:1px solid #000; width:80px; height:120px; background-color:#fff; overflow-x: hidden; display:none;    z-index: 999999;}
      .bhsl_left002 .sprzul .dio ul li{ line-height:20px; margin:0; padding:0;}
      .bhsl_left002 .sprzul .dio ul li:hover{ background-color:#ececec; cursor:pointer;}
      .frames{background: #ececec;position: fixed;left: 50%;top: 50%;margin-top: -160px;margin-left: -190px; display:none; padding:10px;border-radius:10px;}
    </style>
    <script type="text/javascript">
        $(function () {
            $("#txt_RoomNum").focus(function () {
                $(this).next().css("display", "block");
                var ddroomtype = $("#ddroomtype").val();
                $.post("/Admin/Ajax/Books.ashx", "type=getdel&typeid=" + ddroomtype, function (objs) {
                    var listArrJson = eval("(" + objs + ")");
                    var tbList = listArrJson.data;
                    var html = "";
                    for (var i = 0; i < tbList.length; i++) {
                        html += "<li>" + tbList[i].Rn_roomNum + "</li>";
                    }
                    $(".dio ul").html(html);
                    $(".dio li").click(function () {
                        $("#txt_RoomNum").val($(this).text());
                        $(".dio").css("display", "none");
                    })
                }, "text");
            })
            $('html,body').click(function (e) {
                if (e.target.id.indexOf("txt_RoomNum") == -1) {
                    $(".dio").css("display", "none");
                }
            });
        })
        function Show(odrderid) {
            $(".frames").css("display", "block");
            $(".frames").attr("src", "/Admin/ShiftExc/UpdateRoom.aspx?hfID=" + odrderid);
        }
        function isfill() {
            var roomid = document.getElementById("txt_RoomNum").value;
            var price = document.getElementById("txt_Money").value;
            if (roomid == "") {
                alert('房号不能为空');
                return false;
            } else if (price == "") {
                alert('价钱不能为空');
                return false;
            } else {return true;}
         }
    </script>
</head>
<body style="background:#fff;">
<!--换房已改好-->
   <form id="form1" runat="server">
    <div class="sprzul">
        <ul>
           <li>房　　号：<asp:Label ID="labfh" runat="server" Text="Label"></asp:Label></li>
           <li>房　　型：<asp:Label ID="labfx" runat="server" Text="Label"></asp:Label></li>
           <li>开房方式：<asp:Label ID="labkffs" runat="server" Text="Label"></asp:Label></li>
           <li>来　　源：<asp:Label ID="lably" runat="server" Text="Label"></asp:Label></li>
           <li>姓　　名：<asp:Label ID="labname" runat="server" Text="Label"></asp:Label></li>
           <li>入住时间：<asp:Label ID="labrzDate" runat="server" Text="Label"></asp:Label></li>
           <li>房价方案：<asp:Label ID="labfjMoney" runat="server" Text="Label"></asp:Label></li>
           <li>房　　价：<asp:Label ID="labSymoney" runat="server" Text="Label"></asp:Label></li>
        </ul>
    </div>
           
       
        
        <div class="bhsl_left002" style=" background:none;">
        <ul class="sprzul">
            <li>房　　型：<asp:DropDownList ID="ddroomtype" DataTextField="room_name" CssClass="textbox-text_hrj textbox_hrj" DataValueField="id" AutoPostBack="true" runat="server" onselectedindexchanged="ddroomtype_SelectedIndexChanged"></asp:DropDownList></li>
           　　　<li class="lipre">房　　号：<input style=" width:80px;" type="text" class="textbox-text_hrj textbox_hrj" id="txt_RoomNum" onchange="addsDate()" runat="server" />
           <!--弹出层begin-->
           <div class="dio">
             <ul>
             </ul>
           </div>
           <!--弹出层end-->
           </li>
           　　　<li>房　　价：<input type="text" name="textfield" id="txt_Money" class="textbox-text_hrj textbox_hrj"  runat="server" />
            </li>
            <li style="width:90%;">原　　因：<input type="text" name="textfield" class="textbox-text_hrj textbox_hrj" id="txt_Remaker" style=" width:82%;"  runat="server" /></li>
            </ul>
        </div>
        
        <div class="xzbtn" style="text-align:right; background-color:none; float:left;">

            <asp:Button ID="btnAdds" runat="server" Text="换房" class="button_orange " OnClientClick="if(isfill()){}else{return false;}" Style="width: 100px" onclick="btnAdds_Click" />
            <input name="关　闭" type="button" value=" 关　闭 " class="button_gray " onclick="parent.Window_Close();" style="width: 100px;" /></div>
    <iframe name="if1" class="frames" frameborder="0" width="380px;" height="400px" scrolling="no"></iframe>
    </form>

</body>
</html>
