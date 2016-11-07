<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="price.aspx.cs" Inherits="CdHotelManage.Web.Admin.Menus.price" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>



<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../style/css.css" rel="stylesheet" type="text/css" />
    <script src="../../js/DivWH.js" type="text/javascript"></script>
    <script src="../../js/jquery.js" type="text/javascript"></script>
    <link href="../../style/Opendiv.css" rel="stylesheet" type="text/css" />
    <link href="../../style/reset.css" rel="stylesheet" type="text/css" />
    <script src="../js/base.js" type="text/javascript"></script>
    <script type="text/javascript">

        function isFills() {

            var isValid = true;
            var title = document.getElementById("txt_name");
            if (title.value == "") {
                alert('请输入费用名称');
                isValid = false;
            }

            return isValid;

        }
        function openupadd(obj, ids, type) {
            var title = "";
            var url = "Priceinfor.aspx?id=" + ids + "&type=" + type;
            if (type == 0) {
                title = "添加商品费用";
            } else {
                title = "编辑商品费用";
            }
           
            showMyWindow(title, url, 280, 350, true, true, true, update);
        }
        
        function Goodsupa(obj, ids, type) {

            var url = "GoodsAdds.aspx?id=" + ids + "&type=" + type;
            showMyWindow("编辑类型", url, 400, 150, true, true, true, update);
        }
        function update() {

            window.location.reload();
         }
        function BookEancel(ids) {
            var btn = document.getElementById("btndelete1");
            document.getElementById("txt_id").value = ids;
            if (confirm("确定要删除吗？")) {
                btn.click();
            }


        }
        function deletes(ids) {
            var btn = document.getElementById("btndelete")
            document.getElementById("txt_id").value = ids;
            if (confirm("确定要删除吗？")) {
                $.get("/admin/ajax/IsDel.ashx", "type=price&id=" + ids, function (obj) {
                    if (obj == "ok") {
                        alert("该分类下面有子分类!不能删除");
                        return false;
                    }
                    else if (obj == "err") {
                        btn.click();
                    }
                }, "text");
            }


        }
        function clo() {
            var bodyHeight = document.documentElement.clientHeight;
            var bodyWidth = document.documentElement.clientWidth;
            var div = document.getElementById("DivGV");

            if (div != null) {

                //  div.style.width = (bodyWidth - 20) + "px";
                $(div).height(bodyHeight - 56);
            }
        }

        function ShowDiv(cid,obj) {
            $("#DivHrml .lis").css("background", "#fff");
            $(obj).css("background", "#E5FFD2");
            $.get("/Admin/Ajax/Books.ashx?r=" + Math.random(), "type=getCost&cid=" + cid, function (obj) {
                switch (obj.statu) {

                    case "ok":
                        var trs = $("#Tabcox .tr").nextAll();
                        trs.remove();
                        var ts = "";
                        var tbList = obj.data;
                        for (var i = 0; i < tbList.length; i++) {
                            ts += "<tr class=\"tr1 trtop\"><td>" + tbList[i].ct_number + "</td><td>" + tbList[i].ct_name + "</td><td>" + GetName(tbList[i].ct_categories) + "</td><td>" + tbList[i].ct_money + "</td><td><span class=\"fontblue\"><a href=\"#\" class=\"aedit\" onclick=\"openupadd(this," + tbList[i].id + ",1)\">[编缉]</a> <a href=\"#\" onclick=\"BookEancel(" + tbList[i].id + ")\">[删除]</a></span></td></tr>";
                        }
                        $("#Tabcox .tr").after(ts);
                        break;
                    case "err":
                        var trs = $("#Tabcox .tr").nextAll();
                        trs.remove();
                        $("#Tabcox .tr").after("<td colspan=\"5\">"+obj.msg+"</td>");
                        break;
                }
            }, "json");
        }
        function GetName(id) {
            var txt = "";
            $.get("/Admin/Ajax/Books.ashx?r=" + Math.random(), "type=getNames1&id=" + id, function (obj) {
                txt = obj;
            }, "text");
            return txt;
        }
        $.ajaxSetup({
            async: false
        });
        $(function () {
            $(".tr1").hover(function () {
                $(this).addClass("chover");
            }, function () {
                $(this).removeClass("chover");
            });
            $(".tr1").click(function () {
                $(".tr1").removeClass("cbok");


            })
        });
    </script>
    <style type="text/css">
        .tr
        {
            background: #4486B7;
            line-height: 30px;
            font-size: 14px;
            font-weight: bold;
            color: #FFFFFF;
        }
        #form1 .chover
        {
            background: rgb(204,242,255);
        }
        .Tabcox
        {
            border-color: #dedede;
        }
        #form1 .qxShow
        {
            border: none;
        }
        .qxgl
        {
            border: none;
        }
        /*g表头深色背景 备选颜色#3b5998*/
        .tr1
        {
            background: #fff;
        }
        /*白色背景*/
        .tr2
        {
            background: #f2f5fa;
        }
        body
        {
            background: #fff;
        }
        #form1 .cbok
        {
            background: rgb(251,232,137);
        }
        /*隔行有色背景*/
        body #DivHrml li{ position:relative; margin:0; padding:0; height:30px; line-height:30px; border-bottom:1px solid #dcdcdc;}
        #DivHrml li:hover{ background-color:#E5FFD2;}
        #DivHrml li a.dela{ position:absolute; right:18px; right:10px \9; top:5px; display:block; width:5px; height:5px;}
        #DivHrml li a.modif{ position:absolute; right:30px;  top:5px; }
    </style>
</head>
<body onload="clo()">
    <form id="form1" runat="server">
    <div id="DivGV">
    <div class="fyszbt">
        <p>
            <span class="span01 color000 h1s">费用设置 </span><span class="color000">商品名称和费用名称不能一样。</span></p>
        <input type="text" id="txt_NumberName" runat="server" class="fyIpt fyIpt1" />
        <asp:Button ID="button02" runat="server" Text="查询" CssClass="lanbtn" OnClick="button02_Click" />
    </div>
    <div class="conTree">
        <div class="fylist" style="border: 1px solid #cdcdcd; width:15%; margin-left:1%; float:left;">
            <div id="DivHrml" runat="server">
            </div>
            <div class="wbkCXbtn">
                <input type="text" id="txt_name" runat="server" class="fyIpt" />
                <asp:Button ID="Button1" CssClass="lvbtn" runat="server" OnClientClick="if(isFills()){}else{return false}"
                    Text="  +  " OnClick="Button1_Click" /></div>
        </div>
        <!--lefttree结束-->
        <div class="rightTable" style=" width:80%;">
            <table class="Tabcox" id="Tabcox" align="left" cellspacing="0" style="width: 100%; font-size:12px;">
                <tr class="tr">
                    <td >
                        编号
                    </td>
                    <td>
                        费用名称
                    </td>
                    <td>
                        费用类别
                    </td>
                    <td>
                        费用价格（元）
                    </td>
                    <td>
                        操作
                    </td>
                </tr>
                <%=sbHtml.ToString() %>
            </table>
            <div class="addfy">
                <input type="button" id="btn_feiy" class="button_green bigBtn" onclick="openupadd(this,'',0)"
                    value="添加费用" />
            </div>
            <div class="cart-page">
                <webdiyer:aspnetpager id="Pager" runat="server" firstpagetext="首页" lastpagetext="尾页"
                    nextpagetext="下一页" alwaysshow="True" prevpagetext="上一页" nextprevbuttonclass="incoleft"
                    currentpagebuttonclass="rednum" pagingbuttonclass="numbs" submitbuttontext="转到"
                    submitbuttonclass="enterpage" pageindexboxclass="pagebox" firstlastbuttonclass="firstlastbutton"
                    onpagechanged="Pager_PageChanged">
                                    </webdiyer:aspnetpager>
            </div>
            <!--page结束-->
        </div>
        <!--righttable结束-->
    </div>
    <!--contree结束-->
    <div>
        <asp:Button ID="btndelete1" runat="server" Text="删除" Style="display: none" OnClick="btndelete1_Click" />
        <asp:Button ID="btndelete" runat="server" Text="删除" Style="display: none" OnClick="btndelete_Click" />
        <input type="hidden" id="txt_id" runat="server" />
    </div>
    </div>
    </form>
</body>
</html>
