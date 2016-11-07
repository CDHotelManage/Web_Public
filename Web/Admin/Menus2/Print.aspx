<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Print.aspx.cs" Inherits="CdHotelManage.Web.Admin.Menus2.Print" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <link href="../../style/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $("#btnOk").click(function () {
                if (Show()) {
                    alert("修改成功");
                }
            })


        })

        function Show() {
            var b = false;
            $(".dsli").each(function () {
                var id = $(this).find("#hids").val();
                var pritName = $(this).find("label").text();
                var priContent = $(this).find("#SingleEnd").val();
                $.post("/Admin/Ajax/SysPara.ashx?r=" + Math.random, "id=" + id + "&pritName=" + pritName + "&priContent=" + priContent + "&type=editprint", function (obj) {
                    if (obj == "ok") {
                        
                        b = true;
                    }
                    else {
                        b = false;
                    }
                }, "text");
            })
            alert("修改成功！！");
            return b;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <h1 class="titles">系统打印设置</h1>
    <asp:Repeater ID="rep1" runat="server">
    <ItemTemplate>
    <div class="dsli" style="width: 100%; margin:10px 0;">
                    <input type="hidden" id="hids" value="<%#Eval("id") %>" />
                    <label><%#Eval("pritName")%></label><textarea id="SingleEnd"  class="mytexta" style="vertical-align:text-top; margin-left:10px; width:800px; height:60px;  border: 1px solid #ddd;" rows="6" cols="40"><%#Eval("priContent")%></textarea>
    </div>
    </ItemTemplate>
    </asp:Repeater>
    <input type="button" value="保存" class="btnOk" id="btnOk" />
    </form>
</body>
</html>
