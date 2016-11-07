<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoomInfos.aspx.cs" Inherits="CdHotelManage.Web.Admin.Menus.RoomInfos" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../style/css.css" type="text/css" rel="stylesheet">
    <script src="../../js/DivWH.js" type="text/javascript"></script>
    <script src="../../js/jquery.js" type="text/javascript"></script>
    <link href="../../style/Opendiv.css" rel="stylesheet" type="text/css" />
    <script src="../js/base.js" type="text/javascript"></script>
    <script type="text/javascript">
        //添加
        function openY(obj) {
            var url = "FloorAdd.aspx?id=";
            showMyWindow("添加", url, 400, 350, true, true, true);
        }
        function openupdateY(obj, ids) {
            var url = "FloorAdd.aspx?id="+ids;
            showMyWindow("添加", url, 400, 350, true, true, true);
        }
        function OpenFx(obj, ids) {
            var url = "RoomTypeAdd.aspx?id="+ids;
            showMyWindow("添加", url, 400, 350, true, true, true);
        }
        function OpenFh(obj, ids) {
            var url = "roomAdds.aspx?id="+ids;
            showMyWindow("添加", url, 400, 350, true, true, true);
        }
        function deletes(ids) {
            var btn = document.getElementById("btndelete")
            document.getElementById("txt_id").value = ids;
            if (confirm("确定要删除吗？")) {
                btn.click();
            }


        }
        function deletes1(ids) {
            var btn = document.getElementById("btndelete1")
            document.getElementById("txt_fxid").value = ids;
            if (confirm("确定要删除吗？")) {
                btn.click();
            }


        }
        function deletes2(ids) {
            var btn = document.getElementById("btndelete2")
            document.getElementById("txt_fj").value = ids;
            if (confirm("确定要删除吗？")) {
                btn.click();
            }


        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="content">
        <div style="background-color: White;">
            <br />
            <span class="span01 color000">房间信息 </span><span class="color000">第一步添加楼层，第二步添加房型，第三步添加房间。</span>
            <div class="fj_lc">
                <span class="lc_span">楼层： </span><span class="qb_span ">全 部</span>
                <ul class="lcfx_ul_1">
                    <asp:Repeater ID="Repeaterlc" runat="server">
                        <ItemTemplate>
                            <li class="bggray_s"><span class="leftfloat">
                                <%# Eval("floor_name")%></span><span class="rightfloat topbj"><span onclick="openupdateY(this,<%# Eval("floor_id") %>)" class="update"><img src="../../Images/iconbj.png" /></span>
                                <span onclick="return deletes(<%# Eval("floor_id") %>)" class="delete"><img src="../../images/iconsc.png" /></span></span></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <span onclick="openY(this)" class="bggreen jiahao1">+</span>
            </div>
            <div class="fj_lc">
                <span class="lc_span">房型： </span><span class="qb_span ">全 部</span>
                <ul class="lcfx_ul_1">
                    <asp:Repeater ID="Repeaterfx" runat="server">
                        <ItemTemplate>
                            <%--<li class="<%#getstyle(Eval("")) %>">1111</li>--%>
                            <li class="bggray_s"><span class="leftfloat">
                                <%# Eval("room_name")%></span><span class="rightfloat topbj"><span onclick="OpenFx(this,<%# Eval("id") %>)" class="update"><img src="../../Images/iconbj.png" /></span><span onclick="return deletes1(<%# Eval("id") %>)" class="delete"><img
                                    src="../../images/iconsc.png" /></span></span></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <span onclick="OpenFx(this,'')" class="bggreen jiahao1">+</span>
            </div>
            <div class="fj_lc">
                <span class="lc_span">房间： </span>
                <ul class="fj_ul_3">
                    <asp:Repeater ID="Repeaterfh" runat="server">
                        <ItemTemplate>
                            <li class="bgblue"><span class="span02">
                                <%# Eval("Rn_roomNum")%></span><span onclick="OpenFh(this,<%# Eval("id") %>)" class="update"><img src="../../Images/iconbj.png" /></span><span onclick="return deletes2(<%# Eval("id") %>)"  class="delete"><img
                                    src="../../images/iconsc.png" /></span><br />
                                <span class="span_jj">
                                    <%# Eval("Rn_room")%></span></li>
                        </ItemTemplate>
                    </asp:Repeater>
                    <li onclick="OpenFh(this,'')" class="bggreen jiahao"><span class="font01">+</span><br />
                    </li>
                </ul>
            </div>
        </div>
        <input type="hidden" id="txt_id" runat="server" />
        <asp:Button ID="btndelete" runat="server" Text="删除" onclick="btndelete_Click" style=" display:none;" />
          <asp:Button ID="btndelete1" runat="server" Text="删除房型" onclick="btndelete1_Click" style=" display:none;" />
           <input type="hidden" id="txt_fxid" runat="server" />
                     <asp:Button ID="btndelete2" runat="server" Text="删除房间" onclick="btndelete2_Click" style=" display:none;" />
           <input type="hidden" id="txt_fj" runat="server" />
           
    </div>
    </form>
</body>
</html>
