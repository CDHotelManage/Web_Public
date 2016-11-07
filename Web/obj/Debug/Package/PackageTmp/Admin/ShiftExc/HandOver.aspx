<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HandOver.aspx.cs" Inherits="CdHotelManage.Web.Admin.ShiftExc.HandOver" %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../js/printy.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
         <input width="300px" type="button" value="打印预览" id="btnPrint" onclick="printWork('jiaoban')">
    <div id="jiaoban" style=" width:300px; margin:0 auto;">
      <h4 style=" text-align:center;"><%=name %> <%=DateTime.Now.ToString("yyyy-MM-dd")%> <%=banchi %>班 交班报表</h4>
      <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False" 
                        DataKeyNames="meth_pay_id" 
                          ShowFooter ="True"
                        >
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
                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("ga_sum_price","{0:f2}")%>  '></asp:Label>                                                      
                            </ItemTemplate>

                            <FooterTemplate>
                            <% =Sum %>
                            </FooterTemplate>
                              
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
    </div>
    </form>
</body>
</html>
