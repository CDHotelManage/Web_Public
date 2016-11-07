<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HistoryShiftExc.aspx.cs" Inherits="CdHotelManage.Web.Admin.ShiftExc.HistoryShiftExc" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<link href="../../style/reset.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
  <title></title>
     <script src="../../calendar/WdatePicker.js" type="text/javascript"></script>
      <link href="../../style/css.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <link href="../../style/Opendiv.css" rel="stylesheet" type="text/css" />
    <script src="../../js/DivWH.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/base.js"></script>
      <script language="javascript" type="text/javascript">
          var single = "";
          function m_over(obj) {
              single = obj.style.backgroundColor;
              obj.style.backgroundColor = '#6699ff';
          }
          function m_out(obj) {
              obj.style.backgroundColor = single;
          }
          function Checkout(obj) {
              if (YaZheng()) {
                  var banc = $("#ShiftDdl").val();
                  var url = "../ShiftExc/HandOver.aspx?banc=" + banc + "&dtime=" + $("#date").val() + "&uid=" + $("#UserDdl").val();
                  showMyWindow("打印交班报表", url, 400, 250, true, true, true);
              }
          }
          function HandOverXiang(obj) {
              if (YaZheng()) {
                  var banc = $("#ShiftDdl").val();
                  var url = "../ShiftExc/HandOverXiang.aspx?banc=" + banc + "&dtime=" + $("#date").val() + "&uid=" + $("#UserDdl").val();
                  showMyWindow("打印交班明细报表", url, 600, 600, true, true, true);
              }
          }

          function YaZheng() {
              var b = true;
               var banc = $("#ShiftDdl").val();
              if (banc == "请选择班次") {
                  alert("请选择班次");
                  b=false;
              }
              if ($("#UserDdl").val() == "请选择操作员") {
                  alert("请选择操作员！");
                  b = false;
              }
              else if ($("#date").val() == "") {
                  alert("请选择查询日期!");
                  b = false;
              }
              return b;
          }
        </script>
</head>
<body>
    <form id="form1" runat="server">


 <div class="jbtop">
       <div ><asp:Label ID="Label1" runat="server" Text="班次" CssClass="jbsel"></asp:Label>
                    <asp:DropDownList ID="ShiftDdl" runat="server" Height="19px" Width="78px">
                    </asp:DropDownList>
                    <asp:Label ID="Label5" runat="server" Text="操作员"></asp:Label>
                    <asp:DropDownList ID="UserDdl" runat="server">
                    </asp:DropDownList>
                     日期:<input type="text" name="textfield" class="input001" id="date" runat="server"
                     onClick="WdatePicker()" />
                    <asp:Button ID="Button1" runat="server"  CssClass="greenBtn 120Btn" Text="查询" OnClientClick="return YaZheng();" onclick="Button1_Click" />
                    <input type="button" class="greenBtn 120Btn" value="打印交班报表" onclick="Checkout(this)"/>
                    <input type="button" class="greenBtn 120Btn" value="打印明细交班报表" onclick="HandOverXiang(this)"/>
       <ul >
        <li class="jbleft">
                    <asp:GridView ID="GridView1" runat="server"  CssClass="tableBlue" AutoGenerateColumns="False"  Width="100%"
                        onrowdatabound="GridView1_RowDataBound" DataKeyNames="meth_pay_id" 
                        onselectedindexchanging="GridView1_SelectedIndexChanging"  ShowFooter ="True"
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

                            <asp:CommandField ShowSelectButton="True" SelectText="明细" />

                        </Columns>
                    </asp:GridView></li>
        <li class="jbright"><asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="100%">
                     <Columns>
                            <asp:TemplateField  HeaderText="房间号">
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
                            <%# Eval("Remark")%>
                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作员">
                             <ItemTemplate>
                            <%# GetUserName(Eval("UserId"))%>
                            </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="操作时间">
                              <ItemTemplate>
                            
                            </ItemTemplate>
                             </asp:TemplateField>
                        </Columns>
                    </asp:GridView></li>
        <li class="pageupdown"><webdiyer:AspNetPager ID="Pager" runat="server" FirstPageText="首页" LastPageText="尾页"
                    NextPageText="下一页" AlwaysShow="True" PrevPageText="上一页" NextPrevButtonClass="incoleft"
                    CurrentPageButtonClass="rednum" PagingButtonClass="numbs" SubmitButtonText="转到"
                    SubmitButtonClass="enterpage" PageIndexBoxClass="pagebox" FirstLastButtonClass="firstlastbutton"
                    OnPageChanged="Pager_PageChanged">
                </webdiyer:AspNetPager></li>
       </ul>
    
 </div>


    
   
    
   
    </form>
</body>
</html>