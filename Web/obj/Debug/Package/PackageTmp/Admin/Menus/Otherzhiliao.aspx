<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Otherzhiliao.aspx.cs" Inherits="CdHotelManage.Web.Admin.Menus.Otherzhiliao" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../style/css.css" type="text/css" rel="stylesheet">
    <script src="../../js/jquery.js" type="text/javascript"></script>
    <style type="text/css">
        .Divleft
        {
            width: 10%;
            float: left;
        }
        .Divright
        {
            width: 85%;
            float: left;
            margin-top: 0px;
            border: 1px solid #ddd;
            padding: 10px 0px;
            margin-left:1%;
        }
        h1
        {
            padding-left: 30px;
            margin-top: 20px;
            margin-bottom: 10px;
            font-size: 19px;
        }
        .Divleft{ margin-left:30px;}
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
        .fontYaHei
        {
            padding: 10px 20px;
            font-size: 16px;
            color: #0788BD;
            font-weight: 700;
        }
        .list
        {
            width: 100%;
            float: left;
            display: inline;
            margin-top: 10px;
        }
        .list input.butn
        {
            background: #70b236;
            border: 0 none;
            border-radius: 1px;
            color: #fff;
            cursor: pointer;
            float: left;
            font-size: 22px;
            font-weight: bold;
            line-height: 28px;
            height: 28px;
            padding: 0 8px;
            width: 36px;
        }
        .list input
        {
            width: 180px;
            float: left;
            background: #FFF;
            border: 1px solid #ddd;
            height: 24px;
            padding-left: 10px;
            font-size: 14px;
        }
        .list label
        {
            float: left;
            width: 120px;
            text-align: right;
            line-height: 26px;
            color: #333;
            font-size: 12px;
        }
        .divlist
        {
            margin-left: 120px;
            margin-top: 10px;
        }
        .lin
        {
            color: #FFF;
            background: #999;
            padding: 0px 10px;
            line-height: 28px;
            float: left;
            margin: 10px 10px 10px 0px;
            cursor: pointer;
        }
        .chover{ background:blue;}
        ul.itset li.chovers{ background:#E5FFD2;}
    </style>
    <script type="text/javascript">
        $(function () {
            $(".lin").hover(function () {
                $(this).addClass("chover");
            }, function () { $(this).removeClass("chover") });

            $(".itset li").hover(function () {
                $(this).addClass("chovers");
            }, function () { $(this).removeClass("chovers") });

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
        function btnserch(type, obj) {
            $(".itset li").css("background", "#D0F2FF");
            $(obj).css("background", "#E5FFD2");
            document.getElementById("txt_type").value = type;
            document.getElementById("labName").innerText = obj.innerText;
            document.getElementById("txt_name").value = "";
            document.getElementById("btnSercher").click();
        }
        function BookEancel(ids,type) {
            var btn = document.getElementById("btndelete");
            document.getElementById("txt_types").value = type;
            document.getElementById("txt_id").value = ids;
            if (confirm("确定要删除吗？")) {
                btn.click();
            }


        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <h1 class="h1s">
            其他资料
        </h1>
        <div class="Divleft">
            <ul class="itset">
                <li onclick="btnserch(0,this)">客人来源</li>
                <li onclick="btnserch(1,this)">商品单位</li>
                <li onclick="btnserch(2,this)">房间特征</li>
                <li onclick="btnserch(3,this)">支付方式</li>
                <li onclick="btnserch(4,this)">证件类型</li>
                <li onclick="btnserch(5,this)">房价方案</li>
                <%--<li onclick="btnserch(6,this)">民族</li>--%>
                <li onclick="btnserch(11,this)"> 系统类型</li>
                <li onclick="btnserch(7,this)"> 客户状态</li>
                <li onclick="btnserch(8,this)">客户类型</li>
                <li onclick="btnserch(9,this)">客户行业</li>
                <li onclick="btnserch(10,this)">协议项目类型</li>
                <li onclick="btnserch(12,this)">部门</li>
                <li onclick="btnserch(13,this)">职务</li>
                <li onclick="btnserch(14,this)">称呼</li>
            </ul>
        </div>
        <div class="Divright">
            <div class="fontYaHei">
                <asp:Label ID="labName" runat="server" Text="客人来源"></asp:Label></div>
            <div class="list">
                <label>
                    添加值:</label>
                <input type="text" id="txt_name" runat="server" />
                <asp:Button ID="btnSave" CssClass="butn" OnClientClick="if(isfill()){}else{return false}"
                    runat="server" Text="+" OnClick="btnSave_Click" />
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
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
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnSercher" />
                   <%-- <asp:AsyncPostBackTrigger ControlID="btnSave" />--%>
                </Triggers>
            </asp:UpdatePanel>
        </div>
        <asp:Button ID="btnSercher" runat="server" Text="查询" Style="display: none;" OnClick="btnSercher_Click" />
        <asp:Button ID="btndelete" runat="server" Text="删除" style=" display:none;" onclick="btndelete_Click" />
    </div>
    <input type="hidden" id="txt_type" value='0' runat="server" />
    <input type="hidden" id="txt_id" runat="server" />
    <input type="hidden" id="txt_types" value='0' runat="server" />

    </form>
</body>
</html>
