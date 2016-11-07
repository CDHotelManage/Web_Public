<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Roomsmoshi.aspx.cs" Inherits="CdHotelManage.Web.Admin.Menus.Roomsmoshi" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../style/css.css" type="text/css" rel="stylesheet">
    <script src="../../js/jquery.js" type="text/javascript"></script>
    <link href="../../style/Opendiv.css" rel="stylesheet" type="text/css" />
    <script src="../../js/DivWH.js" type="text/javascript"></script>
    <script src="../js/base.js" type="text/javascript"></script>
    <style type="text/css">
        h1{padding-left: 15px;margin-top: 20px;margin-bottom: 10px;font-size: 20px;color: #4486b7;font-weight:100;}
        .list{width: 100%;float: left;display: inline;margin-top: 10px;}
        .list input.butn{background: #70b236;border: 0 none;border-radius: 1px;color: #fff;cursor: pointer;float: left;font-size: 22px;font-weight: bold;line-height: 28px;height: 28px;padding: 0 8px;width: 36px;}
        .list input{width: 180px;float: left;background: #FFF;border: 1px solid #ddd;height: 24px;padding-left: 10px;font-size: 14px;}
.list label{float: left;width: 120px;text-align: right;line-height: 26px;color: #333;font-size: 12px;}
.divlist{margin-left: 120px;margin-top: 10px;}
.lin{color: #FFF;background: #999;padding: 0px 10px;line-height: 28px;float: left;margin: 10px 10px 10px 0px;cursor: pointer;}
.chover{background: blue;}
    </style>
    <script type="text/javascript">
        function BookEancel(ids, type) {
            var btn = document.getElementById("btndelete");
            document.getElementById("txt_id").value = ids;
            if (confirm("确定要删除吗？")) {
                btn.click();
            }
        }

        $(function () {
            $(".lin").hover(function () {
                $(this).addClass("chover");
            }, function () { $(this).removeClass("chover"); });

            $(".itset li").hover(function () {
                $(this).addClass("chovers");
            }, function () { $(this).removeClass("chovers"); });
        })

        function isfill() {
            var txtname = $("#txt_name").val();
            if (txtname == "") {
                alert('名称不能为空');
                return false;
            } else {
                return true;
            }
            $("#txt_name").val('');
        }
        function OpenBc(obj, ids) {
            var url = "RoommoshiAdd.aspx?id=" + ids;
            showMyWindow("修改模式", url, 400, 120, true, true, true);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>
            模式管理
        </h1>
        <div class="list">
            <label>
                模式名称:</label>
            <input type="text" id="txt_name" runat="server" />
            <asp:Button ID="btnSave" CssClass="butn" OnClientClick="if(isfill()){}else{return false}"
                runat="server" Text="+" OnClick="btnSave_Click" />
        </div>
        <div class="divlist" id="DivHtml" runat="server">
            <div class="lin">
                <span>测试</span> <em>x</em>
            </div>
            <div class="lin">
                <span>样式</span> <em>x</em>
            </div>
            <div class="lin">
                <span>样式</span> <em>x</em>
            </div>
        </div>
        <asp:Button ID="btndelete" runat="server" Text="删除" style="display: none;" OnClick="btndelete_Click" />
        <asp:Button ID="btnSeach" runat="server" Text="查询" style=" display:none;" onclick="btnSeach_Click" />
        <input type="hidden" id="txt_id" runat="server" />
    </div>
    </form>
</body>
</html>
