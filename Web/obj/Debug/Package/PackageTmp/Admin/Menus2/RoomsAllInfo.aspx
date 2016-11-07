<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoomsAllInfo.aspx.cs" Inherits="CdHotelManage.Web.Admin.Menus2.RoomsAllInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../style/shezhi.css" rel="stylesheet" type="text/css" />
    <link href="../../style/css.css" rel="stylesheet" type="text/css" />
    <script src="../../js/DivWH.js" type="text/javascript"></script>
    <script src="../../js/jquery.js" type="text/javascript"></script>
    <link href="../../style/Opendiv.css" rel="stylesheet" type="text/css" />
    <script src="../js/base.js" type="text/javascript"></script>
    <script type="text/javascript">

        function clo() {
            var bodyHeight = document.documentElement.clientHeight;
            var bodyWidth = document.documentElement.clientWidth;
            var div = document.getElementById("DivGV");

            if (div != null) {

              //  div.style.width = (bodyWidth - 20) + "px";
                $(div).height(bodyHeight - 156);
            }
        }

        //全选

        function checkAll(isChecked) {//全选单选
            var gridView1 = document.getElementById('GrdCostRoom');
            var zffs = document.getElementById("Divzffs");
            for (var i = 1; i < gridView1.rows.length; i++) {
                var rowObj = gridView1.rows[i];
                rowObj.cells[0].getElementsByTagName("INPUT")[0].checked = isChecked;

            }

        }
        function isChecked() {//判断是否选中了项，在删除之前
            var checkCount = 0;
            var ids = "";
            var b = true;
            var GridView1 = document.getElementById('GrdCostRoom');
            for (var i = 1; i < GridView1.rows.length; i++) {
                if (GridView1.rows[i].cells[0].getElementsByTagName("INPUT")[0].checked) {
                    if (b) {
                        $.get("/admin/ajax/IsDel.ashx", "type=isroom&id=" + GridView1.rows[i].cells[0].getElementsByTagName("INPUT")[1].value, function (obj) {
                            if (obj == "ok") {
                                alert("有房间已开房!不能删除");
                                b = false;
                            }
                        }, "text");
                    }
                    checkCount++;
                    if (ids == "") {
                        ids = GridView1.rows[i].cells[0].getElementsByTagName("INPUT")[1].value;
                    } else {
                        ids += "," + GridView1.rows[i].cells[0].getElementsByTagName("INPUT")[1].value;
                    }
                    document.getElementById("txt_allids").value = ids;
                }
            }
            document.getElementById("hidCount").value = checkCount;
            if (checkCount == 0) {
                alert("请选中要删除的项");
                return false;
            } 
            else {
                if (b) {
                    return confirm("确认要删除选中的项吗？");
                }
            }
        }
        $.ajaxSetup({
            async: false
        });
        //添加房型
        function deletes(ids) {
            document.getElementById("txt_hidid").value = ids;

            if (confirm("确定要删除吗？")) {
                $.get("/admin/ajax/IsDel.ashx", "type=isroom&id=" + ids, function (obj) {
                    if (obj == "ok") {
                        alert("该房间已开房!不能删除");
                        return false;
                    }
                    else if (obj == "err") {
                        document.getElementById("btndelone").click();
                    }
                }, "text");
                
            }
        }
        function TypeAdds(obj, ids) {
            var title = "";
            if (ids == "")
            { title = "添加房间" } else { title = "修改房间" }
            document.getElementById("txt_hidid").value = ids;
            var url = "roomAdds.aspx?id=" + ids;
            showMyWindow(title, url, 300, 300, true, true, true, update);
        }

        function update() {
            window.location.href = '/admin/Menus2/RoomsAllInfo.aspx';
        }

        function roomplAdds(obj) {

            var url = "RoomAddSum.aspx";
            showMyWindow("批量添加房间", url, 550, 320, true, true, true, update);
        }
        
        $(function () {

            $(".Class_GV tr").hover(function () {
                $(this).addClass("chover");
            }, function () { $(this).removeClass("chover") });
        })
    </script>
</head>
<body onload="clo();">
    <form id="form1" runat="server">
    <h1 class="h1s">
            房号管理
        </h1>
    <div>
     
        <div id="DivGV" class="DivGV">
            <asp:GridView ID="GrdCostRoom" Width="100%" runat="server" CssClass="Class_GV" AutoGenerateColumns="False"
                OnRowDataBound="GrdCostRoom_RowDataBound">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <input id="cbAll" onclick="checkAll(this.checked)" type="checkbox" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox CssClass="cbxCheck" onclick="disonoe()" ID="cbxCheck" runat="server" />
                            <asp:HiddenField ID="hidId" Value='<%# Eval("id")%>' runat="server" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                   <%-- <asp:BoundField DataField="Rn_room" HeaderText="楼栋" />--%>
                    <%--<asp:BoundField DataField="Rn_floor" HeaderText="楼层" />--%>
                     <asp:TemplateField HeaderText="楼栋">
                        <ItemTemplate>
                            <%# GetRealTypeld(Convert.ToInt32(Eval("Rn_flloeld")))%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="楼层">
                        <ItemTemplate>
                            <%# GetRealTypelcmname(Convert.ToInt32(Eval("Rn_floor")))%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Rn_roomNum" HeaderText="房号" />
                    
                    <asp:TemplateField HeaderText="房型">
                        <ItemTemplate>
                            <%# GetRealTypeName(Convert.ToInt32(Eval("Rn_room")))%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <%-- <asp:BoundField DataField="Rn_Type" HeaderText="房型" />--%>
                    <%--<asp:BoundField DataField="Rn_price" HeaderText="房间价格" />--%>
                    <asp:TemplateField HeaderText="房间价格">
                        <ItemTemplate>
                            <%#Convert.ToDouble(Eval("Rn_price"))%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Rn_remaker" HeaderText="特征描述" />
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <a onclick="TypeAdds(this,<%#Eval("id") %>)" href="#">编辑</a> <a onclick="deletes(<%#Eval("id") %>)"
                                href="#">删除</a>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle CssClass="cart-data" />
            </asp:GridView>
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
        </div>
        <div class="divBottom">
            <input type="button" class="btn" id="btnpladd" onclick="roomplAdds(this)" value="批量添加" />
            <input type="button" class="btn" onclick="TypeAdds(this,'')" id="btnAdds" value="添加" />
            <asp:Button ID="btnDelete" CssClass="btn" runat="server" OnClientClick="if(isChecked()){}else{return false;}"
                Text="删除" OnClick="btnDelete_Click" />
        </div>
        <asp:Button ID="btndelone" runat="server" Text="单个删除" Style="display: none;" OnClick="btndelone_Click" />
        <asp:Button ID="btnSerch" runat="server" Text="查询事件" Style="display: none;" OnClick="btnSerch_Click" />
        <input type="hidden" id="txt_hidid" runat="server" />
        <input type="hidden" id="hidCount" runat="server" />
        <input type="hidden" id="txt_allids" runat="server" />
    </div>
    </form>
</body>
</html>
