<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CdHotelManage.Web.Admin.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>酒店管理系统主界面</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <link href="/style/css.css" rel="stylesheet" type="text/css" />
    <link href="../easyui/themes/gray/easyui.css" rel="stylesheet" type="text/css" />
    <link href="/Admin/css/default.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="/Admin/js/themes/icon.css" />
    <script type="text/javascript" src="/Admin/js/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="/Admin/js/jquery.easyui.min-1.2.0.js"></script>
    <script type="text/javascript" src='/Admin/js/outlook.js'> </script>
    <script src="/Admin/js/jq-main.js" type="text/javascript"></script>
    <script src="js/base.js" type="text/javascript"></script>
    <script type="text/javascript">
        function ShowTab(title, url) {
            AddTabs(title, url);
        }
        $(function () {
            $("div").css("overflow", "hidden");
            $("body").css("overflow", "hidden");
            $(".layout-split-west").css("top", "80px");
            //判断是否为谷歌浏览器 true false
            var isChrome = window.navigator.userAgent.indexOf("Chrome") !== -1;
            
        })
        function IsCecck() {
            $.get("/Admin/Ajax/IsDel.ashx", "type=qingchu", function (obj) {
                if (obj == "ok") {
                    alert("退出成功!");
                    window.location.href = '/admin/login.aspx';
                }
            }, "text");
        }
        function keepsession() {
            //alert("aaa");
            //$("#hiddenframe").attr("src", "Jfcs.aspx?RandStr=" + Math.random());
            // alert($("#hiddenframe").attr("src"));
        }
    </script>
</head>
<body class="easyui-layout" style="overflow: hidden">
    <div region="north" split="true" border="false" style="overflow: hidden; height: 80px;">
        <div class="top">
            <div class="logo">
                <img src="/Admin/Toroom/images/95ssgylogo.png" />
                </div>
            <ul id="css3menu">
                <li style="display: none;"><a id="firstpage" rel="/admin/iframe.html" title="起始页"></a>
                </li>
                <asp:Repeater runat="server" ID="rptNav">
                    <ItemTemplate>
                        <li><a name='name<%#Eval("menu_id") %>' id='' rel='' onclick="ShowTab('<%#GetChildMenu(Eval("menu_id").ToString())[0] %>','<%#GetChildMenu(Eval("menu_id").ToString())[1] %>')">
                            <img src='<%#Eval("imgurl") %>' /></a> </li>
                    </ItemTemplate>
                </asp:Repeater>
                <li><a name="name24" id="" rel="" onclick="IsCecck()">
                            <img src="/Upload/MenuIcon/qiehuan.png"></a> </li>
            </ul>
        </div>
        
    </div>
    <div class="footer" region="south" split="true" style="height: 30px;">
  
        <ul id="ulfllor" runat="server" class="ulleft">
            <li><%=modelsi.shop_Name %></li>
            <li>用户名：<%=UserNow.UserName??string.Empty %></li>
            <li>姓名：<%=UserNow.TrueName??string.Empty %></li>
            <li><%=DateTime.Now.ToLongDateString() %></li>
            <li style="float:right; color:#fff;"><a href="#" onclick="IsCecck()" style="color:#fff">退出</a></li>
        </ul>
        
    </div>
    <div region="west" hide="true" split="true" title="导航菜单" style="width: 150px;" id="west">
        <div id='wnav' class="easyui-accordion" fit="true" border="false">
        </div>
    </div>
    <div id="mainPanle" region="center" style="background: #eee; overflow: hidden;">
        <div id="tabs" class="easyui-tabs" fit="true" border="false">
        </div>
    </div>
    <div id="mm" class="easyui-menu" style="width: 150px;">
        <div id="mm-tabupdate">
            刷新</div>
        <div class="menu-sep">
        </div>
        <div id="mm-tabclose">
            关闭</div>
        <div id="mm-tabcloseall">
            全部关闭</div>
        <div id="mm-tabcloseother">
            除此之外全部关闭</div>
        <div class="menu-sep">
        </div>
        <div id="mm-tabcloseright">
            当前页右侧全部关闭</div>
        <div id="mm-tabcloseleft">
            当前页左侧全部关闭</div>
        <div class="menu-sep">
        </div>
        <div id="mm-exit">
            退出</div>
    </div>
    <div id="pp" style="display: none;" runat="server">
    </div>
</body>
</html>
