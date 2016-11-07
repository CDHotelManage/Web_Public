<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SincetheAdds.aspx.cs" Inherits="CdHotelManage.Web.Admin.Toroom.SincetheAdds" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../js/jquery.js" type="text/javascript"></script>
    <link href="../../style/css.css" rel="stylesheet" type="text/css" />
    <link href="../../style/Opendiv.css" rel="stylesheet" type="text/css" />
    <script src="../../js/DivWH.js" type="text/javascript"></script>
    <script src="../js/base.js" type="text/javascript"></script>
    <script type="text/javascript">
        function clo() {
            var bodyHeight = 300;
            var bodyWidth = document.body.offsetWidth;
            var div = document.getElementById("DivGV");
            div.style.height = (bodyHeight - 56) + "px";


        }
        function houseAdds(obj) {
            var url = "Remaker.aspx?type=" + $("#hidtype").val();
            showMyWindow("添加备注", url, 300, 150, true, true, true);
        }
        function del() {
         var ids = document.getElementById("hidid").value;
         if (ids == "") {
             alert('请选择要操作的数据');
             return false;
         } else { return true; }
         }
        function houseupdate(obj) {
            var ids = document.getElementById("hidid").value;
            if (ids == "") {
                alert('请选择要操作的数据');
            } else {
                var url = "Remaker.aspx?id=" + ids + "&type=" + $("#hidtype").val();
                showMyWindow("修改备注", url, 300, 150, true, true, true);
            }
        }
        function Getid(ids, remaker) {
            document.getElementById("hidid").value = ids;
            document.getElementById("hidRemaker").value = remaker;

        }
        function getRemaker() {
            parent.document.getElementById("txt_wxyying").value = document.getElementById("hidRemaker").value;
        }
        $(function () {

            $(".tr1").hover(function () {
                $(this).addClass("chover");

            }, function () {
                $(this).removeClass("chover");
            })

            $(".tr1").click(function () {
                $(".tr1").each(function () {
                    if ($(this).attr("bookno") == $("#hidid").val()) {
                        $(this).addClass("ches");
                    } else {
                        $(this).removeClass("ches");
                     }
                })

            })

        })
    </script>
    <style type="text/css">
        .div1
        {
            float: left;
            width: 60%;
        }
        .div2
        {
            float: left;
            width: 40%;
        }
        #DivGV
        {
            overflow: auto;
        }
         body #DivGV td{ text-align:left; text-indent:10px;}
        .chover
        {
            background: #4486b7;
        }
        .ches{ background:Yellow;}
        .greenBtn{ margin:0;}
    </style>
</head>
<body onload="clo();">
    <form id="form1" runat="server">
    <input type="hidden" id="hidtype" runat="server" />
    <div id="DivGV" runat="server" style="text-align: left">
    </div>
    <div style="text-align: center;">
        <div class="div1">
            <input type="button" id="btnadd" onclick="houseAdds(this)" value="增加" class="greenBtn" />
            <input type="button" id="Button1" onclick="houseupdate(this)" value="修改" class="greenBtn" />
            <asp:Button ID="btndelete" runat="server" Text="删除" OnClientClick="if(del()){}else{ return false;}" OnClick="btndelete_Click" class="greenBtn" />
        </div>
        <div class="div2">
            <input type="button" id="btnss" value="确定" onclick="getRemaker();parent.Window_Close();"  class="greenBtn"/>
            &nbsp;&nbsp;<input type="button" value="取消" onclick="parent.Window_Close();" class="greenBtn" />
        </div>
    </div>
    <asp:HiddenField ID="hidid" runat="server" />
    <asp:HiddenField ID="hidRemaker" runat="server" />
    <asp:Button ID="btnsercher" runat="server" Text="查询"  style=" display:none;"
        onclick="btnsercher_Click"  class="greenBtn"/>
    </form>
</body>
</html>
