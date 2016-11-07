<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BusiMonthy.aspx.cs" Inherits="CdHotelManage.Web.Admin.Rpt.BusiMonthy" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../../style/css.css" rel="stylesheet" type="text/css" />
    <script src="../../calendar/WdatePicker.js" type="text/javascript"></script>
    <title></title>
    <script language="javascript">
        function doPrint() {
            bdhtml = window.document.body.innerHTML;
            sprnstr = "<!--startprint-->";
            eprnstr = "<!--endprint-->";
            prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + 17);
            prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));
            window.document.body.innerHTML = prnhtml;
            window.print();
        } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="rightTable">
        <div class="nameTable">
            <span>营业月:
                <input type="text" name="textfield" id="Month" onfocus="WdatePicker({dateFmt:'yyyy-MM'})"
                    runat="server" />
                <%-- <input   type="button" value="查询"  class="czBtnBlue" />--%>
                <asp:Button ID="Button1" runat="server" Text="查询" class="czBtnBlue" OnClick="Button1_Click" />
                <a href="javascript:; " onclick="doPrint() ">
                    <input type="button" value="打印预览" class="jbBtn" /></a>
                <%-- <input   type="button" value="导出EXCEL"  class="jbBtn" />--%>
                <asp:Button ID="Button2" runat="server" Text="导出EXCEL" class="jbBtn" 
                onclick="Button2_Click" />
        </div>
         <!--startprint-->
        <h3 class="CenterTitle">
            营业月报表</h3>
        <div class="yyRbbTitle">
            营业月:<span><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></span> 
            打印时间:<span><asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></span>
            <span class="rightFu">制表单位:金都假日大酒店
            </span>
        </div>
        <table class="rTable01" border="0" cellspacing="0" cellpadding="0">
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <tr>
                        <td rowspan="2">
                          营业日
                        </td>
                        <td colspan="4">
                            入住情况
                        </td>
                        <td colspan="3">
                            营业情况
                        </td>
                    </tr>
                    <tr>
                        <td class="topBB">
                            入住数
                        </td>
                        <td class="topBB">
                            总房数
                        </td>
                        <td class="topBB">
                            入住率
                        </td>
                        <td class="topBB">
                            平均房价
                        </td>
                        <td class="topBB">
                            房租
                        </td>
                        <td class="topBB">
                            消费
                        </td>
                        <td class="topBB">
                            小计
                        </td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                      <a href ="BusiDaily.aspx?date=<%# Eval("date") %>">  <%# Eval("date") %></a>
                        </td>
                        <td>
                    <%--  <%# GetRuzhushu(Eval("date"))%> --%>
                        </td>
                        <td>
                         <%# Eval("totalfang")%>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                   
                </ItemTemplate>
                <FooterTemplate>
                    <tr class="red">
                        <td>
                            合计：
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </FooterTemplate>
            </asp:Repeater>
        </table>
           <!--endprint-->
        <br />
        <br />
    </div>
    <!--right-->
    </div><!--主体conTree-->
    <!--main结束-->
    <br />
    <div class="clearboth">
    </div>
    </form>
</body>
</html>
