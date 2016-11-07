<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoomkrSelect.aspx.cs" Inherits="CdHotelManage.Web.Admin.RoomGustkr.RoomkrSelect" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>预定信息 </title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery.js" type="text/javascript"></script>
   <link href="../../style/css.css" rel="stylesheet" type="text/css" />
    <link href="../../style/reset.css" rel="stylesheet" type="text/css" />
    <script src="../../js/DivWH.js" type="text/javascript"></script>
    <link href="../../style/Opendiv.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/ShowTabs.js"></script>
    <script src="../js/base.js" type="text/javascript"></script>
   <style type="text/css">
        html, body
        {
            width: 100%;
            height: 100%;
            padding: 0;
            margin: 0;
            outline: none;
        }
        #Text1, #Text2 
        {
            padding: 7px 5px;
            outline: none;
            width: 100px;
            height: 10px;
            border-radius: 3px;
            border: 1px solid #ccc;
        }
    </style>
    <script language="javascript" type="text/javascript">
        $(function () {
            $(".cbxCheck").click(function () {
                var nowchk = $(this).parent().parent().attr("orrderid");
                //alert($(this).parent().parent().attr("bookno"));
                $(".tr1").each(function () {
                    if ($(this).attr("orrderid") != nowchk) {
                        $(this).find(".cbxCheck").attr("checked", false);
                    }
                })
                SC();
            })
        })

        function SC() {
            var rooms = "";
            $(".cbxCheck").each(function () {
                if ($(this).attr("checked") == "checked") {
                    rooms += "'" + $(this).parent().next().next().text() + "',";
                }
            })
            var r = rooms.substring(0, rooms.length - 1);
            $("#rooms").val(r);
        }

        function Openupdate(obj, ids) {
            var ids = document.getElementById("hidPermissionId");
        }
        function Close(){}
        function BookAdd(obj) {
            if ($(".cbok").length <= 0) {
                alert("请选择一项！！");
             }
            else {
                var order_id = $(".cbok").attr("orrderid");
                if ($("#button03").val() == "补打入住单") {
                    var url = "/Admin/ShiftExc/OccupancySingle.aspx?orrderID=" + order_id + "&type=rz";
                    showMyWindow("打印开房单", url, 400, 600, true, true, true, Close);
                }
                else {
                    var url = "/Admin/ShiftExc/Checkout.aspx?ga_sfacount=" + order_id;
                    showMyWindow("结账单", url, 400, 600, true, true, true, Close);
                } 
            }
            
        }
        function GustMoneyAdds(obj, ids) {
            var table = document.getElementById("Tabcox");
            var count = 0;
            for (var i = 1; i < table.rows.length - 1; i++) {
                var a = table.rows[i].getElementsByTagName("INPUT")[1].value;

                if (table.rows[i].getElementsByTagName("INPUT")[0].checked) {
                    document.getElementById("txt_room").value = a;
                    ids = a;
                    count++;
                }
            }
            if (count > 0) {
                var url = "/Admin/Toroom/GoodsAcountsMoney.aspx?id=" + ids;
                ShowTabs(url, "结账");
            } else {
                alert('请先选择要退的房间');
                return;
            }

        }
        function Bookchakan(obj,ids) {
           // var ids = document.getElementById("txt_room").value;

            var url = "../Toroom/AcountInfos.aspx?id=" + ids;
            showMyWindow("结账明细", url, 1000, 450, true, true, true);
        }
        function cobxsTab(obj) {

            var table = document.getElementById("Tabcox");
            for (var i = 1; i < table.rows.length - 3; i++) {

                table.rows[i].cells[0].getElementsByTagName("INPUT")[0].checked = false;
            }
            obj.checked = true;
        }
        $(function () {
            $(".tr1").hover(function () {
                if ($(this).attr("class").indexOf("cbok") > 0) {

                }
                else { $(this).addClass("chover"); }
            }, function () {
                $(this).removeClass("chover");
            });
            $(".tr1").click(function () {


                $(".tr1").removeClass("cbok");
                var allid = $(this).attr("bookno");
                $(".tr1").each(function () {
                    if ($(this).attr("bookno") == allid) {
                        $(this).addClass("cbok");
                    }
                })

                var orrderID = $(this).attr("orrderid");
                var statid = $(this).attr("State_Id");
                if (statid == 0) {
                    $("#button03").val("补打入住单");
                }
                else if (statid == 3) {
                    $("#button03").val("补打结账单");
                }
            });
            //            $("#ddlState").change(function () {
            //                if ($(this).val() == "3") {
            //                    $("#btndisplay").css("display", "");
            //                } else { $("#btndisplay").css("display", "none"); }

            //            })

        });

        function btnAddscx() {
            var table = document.getElementById("Tabcox");

            var count = 0;
            for (var i = 1; i <= table.rows.length - 2; i++) {
                var a = table.rows[i].getElementsByTagName("INPUT")[1].value;

                if (table.rows[i].getElementsByTagName("INPUT")[0].checked) {
                    document.getElementById("txt_room").value = a;
                    count++;
                }
            }
            if (count > 0) {
                if (confirm("确定要撤销该房间吗？")) {
                    document.getElementById("btncxSava").click();
                }
            } else {
                alert('请先选择要退的房间');
                return;
            }
        }
    </script>
</head>
<body style=" overflow-x:hidden;">
    <form id="form2" runat="server">
    <input type="hidden" id="rooms" runat="server"/>
    </br> &nbsp; 类型：<asp:DropDownList ID="ddlState" runat="server">
        <asp:ListItem Value="全部">全部</asp:ListItem>
        <asp:ListItem Value="0">在住客人</asp:ListItem>
        <asp:ListItem Value="3">已退房</asp:ListItem>
        <asp:ListItem Value="4">挂单客人</asp:ListItem>
    </asp:DropDownList>
    &nbsp;
    <label>
        单号：<input class="input001" type="text" name="textfield" id="book_no" runat="server" />
        房号：<input class="input001" type="text" id="txt_fh" runat="server" />
        姓名：<input class="input001" type="text" id="txt_name" runat="server" />
        <asp:Button ID="button02" runat="server" Text="查询" CssClass="qtantj" style=" float:none;" OnClick="button02_Click" />
    </label>
    <br />
    </br>
    <table id="Tabcox"  class="tableBlue"  cellspacing="0" >
       <thead> <tr>
            <td>
                主账单号
            </td>
            <td>
                选择
            </td>
            <td>
                单号
            </td>
            <td>
                房号
            </td>
            <td>
                房型
            </td>
            <td>
                姓名
            </td>
            <td>
                电话
            </td>
            <td>
                入住时间
            </td>
            <td>
                预离时间
            </td>
            <td>
                退房时间
            </td>
            <td>
                已住天数
            </td>
            <td>
                房价
            </td>
            
            <td>
                房费
            </td>
            <td>
                收款
            </td>
            <td>
                消费
            </td>
            <td>
                余额
            </td>
        </tr></thead>
        <%=sbHtml.ToString() %>
        <tr class="tr1">
            <td colspan="10">
                <div align="right">
                    当页合计：</div>
            </td>
            <td class="days">
                <%=Day%>
            </td>
            <td>
               
            </td>
            <td class="ffs">
            <%=CSGZMoney%>
                
            </td>
            <td class="sks">
                <%=SKMoney%>
            </td>
            <td class="xfs">
                <%=XFMoney%>
            </td>
            <td class="yues">
                <%=YEMoney%>
            </td>
        </tr>
        <%--<tr class="tr1">
            <td colspan="9">
                <div align="right">
                    总合计：</div>
            </td>
            <td>
                <%=Days%>
            </td>
            <td>
                <%=FjMoneys%>
            </td>
            <td>
                <%=SKMoneys%>
            </td>
            <td>
                <%=CSGZMoneys%>
            </td>
            <td>
                <%=XFMoneys%>
            </td>
            <td>
                <%=YEMoneys%>
            </td>
        </tr>--%>
    </table>
    <div class="clearboth">
        <div class="mright">
            <div class="cart-page">
                <webdiyer:AspNetPager ID="Pager" runat="server" FirstPageText="首页" LastPageText="尾页"
                    NextPageText="下一页" AlwaysShow="True" PrevPageText="上一页" NextPrevButtonClass="incoleft"
                    CurrentPageButtonClass="rednum" PagingButtonClass="numbs" SubmitButtonText="转到"
                    SubmitButtonClass="enterpage" PageIndexBoxClass="pagebox" FirstLastButtonClass="firstlastbutton"
                    OnPageChanged="Pager_PageChanged">
                </webdiyer:AspNetPager>
            </div>
        </div>
    </div>
    <br />
    <br />
    <input type="hidden" id="txt_room" runat="server" />
    <input name="提交" type="button" id="button03" class="greenBtn midBtn" style=" width:90px;" value="补打入住单" onclick="BookAdd(this)"
        runat="server" />
    <input name="挂单结账" id="btnGuadan" style="display: none;" onclick="GustMoneyAdds(this)"
        type="button" class="button03" value="挂单结账" runat="server" />
    <input name="撤销结账" id="btndisplay" style="display: none;" type="button" class="button03"
        value="撤销结账" onclick="return btnAddscx()" runat="server" />
    <asp:Button ID="btncxSava" Style="display: none;" class="button03" runat="server"
        Text="撤销结账" OnClick="btncxSava_Click" />
    </form>
</body>
</html>
