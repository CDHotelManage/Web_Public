<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShiftExc.aspx.cs" Inherits="CdHotelManage.Web.Admin.ShiftExc.ShiftExc" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../js/DivWH.js" type="text/javascript"></script>
    <link href="../../style/css.css" rel="stylesheet" type="text/css" />
    <link href="../../style/Opendiv.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery.js" type="text/javascript"></script>
    <script src="../js/base.js" type="text/javascript"></script>
    <script type="text/javascript">
            var single = "";
            function m_over(obj) {
                single = obj.style.backgroundColor;
                obj.style.backgroundColor = '#6699ff';
            }
            function m_out(obj) {
                obj.style.backgroundColor = single;
            }

            $(function () {
                var sum = 0;
                $(".pri").each(function () {
                    var s = $(this).text();
                    sum += parseInt(s);
                })
                $("#asb").text(sum.toFixed(2));
                var isdis=<%=isdis %>;
                if(isdis==1){
                  $("#Button2").css("display","-webkit-inline-box");
                  $("#Button3").css("display","-webkit-inline-box");
                }
            })
            function Checkout(obj) {
                var banc = $("#ShiftDdl").val();
                if (banc == "请选择班次") {
                    alert("请选择班次");
                }
                else {
                    var url = "../ShiftExc/HandOver.aspx?banc=" + banc+"";
                    showMyWindow("打印交班报表",url,400,600,true,true,true);
                }
                return false;
            }
            function ShowTabs(title) {
                // 关闭当前
                var url = "/admin/ShiftExc/ShiftExc.aspx";
                AddTabs(title,url);
                window.location.reload(true);
                
                clos();
            }
            function HandOverXiang(obj) {
                var banc = $("#ShiftDdl").val();
                if (banc == "请选择班次") {
                    alert("请选择班次");
                }
                else {
                    var url = "../ShiftExc/HandOverXiang.aspx?banc=" + banc;
                    showMyWindow("打印交班报表",url,600,600,true,true,true);
                }
                return false;
            }
            $("#ShiftDdl").change(function () {
                $(".tds").attr("disabled", true);
            })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="jbtop">
        <div>
            <asp:DropDownList ID="ShiftDdl" runat="server" CssClass="jbsel">
            </asp:DropDownList>
            <asp:Button ID="Button1" runat="server" Text="确认交班报表" CssClass="greenBtn 120Btn"
                OnClick="Button1_Click" />
            <input type="button" id="Button2" runat="server" value="打印交班报表" class="greenBtn 120Btn"
                style="display: none;" onclick="Checkout(this)" />
            <input type="button" id="Button3" runat="server" value="打印明细交班报表" class="greenBtn 120Btn"
                style="display: none;" onclick="HandOverXiang(this)" /></div>
        <ul>
            <li class="jbleft">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound"
                    DataKeyNames="meth_pay_id" OnSelectedIndexChanging="GridView1_SelectedIndexChanging"
                    ShowFooter="True" CssClass="tableBlue">
                    <Columns>
                        <asp:TemplateField HeaderText="id" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="Labeid" runat="server" Text=' <%# Eval("meth_pay_id")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="支付方式">
                            <FooterTemplate>
                                <asp:Label ID="Label4" runat="server" Text="合计:"></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text=' <%# Eval("meth_pay_name")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="金额">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" CssClass="pri" Text='<%# Eval("ga_sum_price","{0:f2}")%>  '></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <a id="asb"></a>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowSelectButton="True" SelectText="明细" />
                    </Columns>
                </asp:GridView>
            </li>
            <li class="jbright">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CssClass="tableBlue">
                    <Columns>
                        <asp:TemplateField HeaderText="房间号">
                            <ItemTemplate>
                                <%# Eval("ga_roomNumber")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="项目名称">
                            <ItemTemplate>
                                <%# Eval("ga_name")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="支付方式">
                            <ItemTemplate>
                                <%# GetRealTypeName(Eval("ga_zffs_id"))%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="金额">
                            <ItemTemplate>
                                <%# Eval("ga_price", "{0:f2}")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="发生时间">
                            <ItemTemplate>
                                <%# Eval("ga_date", "{0:yyyy-MM-dd HH:mm}")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="备注">
                            <ItemTemplate>
                                <%# Eval("ga_remker")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="操作员">
                            <ItemTemplate>
                                <%# GetUserName(Eval("ga_people")) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="操作时间">
                            <ItemTemplate>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </li>
            <li class="pageupdown">
                <webdiyer:AspNetPager ID="Pager" runat="server" FirstPageText="首页" LastPageText="尾页"
                    NextPageText="下一页" AlwaysShow="True" PrevPageText="上一页" NextPrevButtonClass="incoleft"
                    CurrentPageButtonClass="rednum" PagingButtonClass="numbs" SubmitButtonText="转到"
                    SubmitButtonClass="enterpage" PageIndexBoxClass="pagebox" FirstLastButtonClass="firstlastbutton"
                    OnPageChanged="Pager_PageChanged">
                </webdiyer:AspNetPager>
            </li>
        </ul>
        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" CssClass="tableBlue">
            <Columns>
                <asp:TemplateField HeaderText="房间号">
                    <ItemTemplate>
                        <%# Eval("ga_roomNumber")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="项目名称">
                    <ItemTemplate>
                        <%# Eval("ga_name")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="支付方式">
                    <ItemTemplate>
                        <%# GetRealTypeName(Eval("ga_zffs_id"))%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="金额">
                    <ItemTemplate>
                        <%# Eval("ga_price", "{0:f2}")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="发生时间">
                    <ItemTemplate>
                        <%# Eval("ga_date", "{0:yyyy-MM-dd HH:mm}")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="备注">
                    <ItemTemplate>
                        <%# Eval("ga_remker")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作员">
                    <ItemTemplate>
                        <%# GetUserName(Eval("ga_people")) %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作时间">
                    <ItemTemplate>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
