<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BusiDaily.aspx.cs" Inherits="CdHotelManage.Web.Admin.Rpt.BusiDay1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../calendar/WdatePicker.js" type="text/javascript"></script>
    <link href="../../style/css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .report_h2
        {
            width: 100%;
            display: inline;
            float: left;
            text-align: center;
            font-size: 14px;
            padding-bottom: 10px;
        }
        .report_h2 b
        {
            width: 960px;
            font-size: 20px;
            color: #000;
            text-align: center;
            float: left;
            line-height: 45px;
        }
        .report_h2 p
        {
            width: 100%;
            float: left;
            text-align: left;
            padding: 0px;
            margin: 0px;
        }
        .report_h2 p span
        {
            padding-right: 40px;
            font-size: 12px;
            display: block;
            float: left;
            white-space: normal;
            width: 140px;
        }
        .report_h2 p span em
        {
            font-style: italic;
            font-size: 14px;
        }
        .report_table
        {
            width: 100%;
            margin: 0px 0px 10px 0px;
            border-top: 0px solid #000;
            border-left: 0px solid #000;
            color: #000;
            float: left;
            font-size: 12px;
            text-align: center;
        }
        .report_table tr
        {
            color: #000;
        }
        .report_table tr td
        {
            border-bottom: 0px solid #000;
            border-right: 0px solid #000;
            padding: 0px 5px;
        }
        table.report_table tr td.left
        {
            text-align: left;
        }
        table.report_table tr td.right
        {
            text-align: right;
        }
        table.report_table tr td.titles
        {
            text-align: left;
            font-weight: bold;
        }
        .report_db
        {
            width: 98%;
            float: left;
        }
        .report_table tr.tis
        {
            font-weight: bold;
        }
    </style>
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
    <object id="WebBrowser" classid="CLSID:8856F961-340A-11D0-A96B-00C04FD705A2" height="0"
        width="0" viewastext>
    </object>
    <%--打印设置--%>
    <form id="form2" runat="server">
    <div class="rightTable">
        <div class="nameTable">
            <span>营业日:
                <input type="text" name="textfield" runat="server" id="date1" onclick="WdatePicker()" />
                -
                <input type="text" name="textfield" runat="server" id="date2" onclick="WdatePicker()" />
                <%-- <input   type="button" value="查询"  class="czBtnBlue" />
<input   type="button" value="打印预览"  class="jbBtn" />
	 <input   type="button" value="导出EXCEL"  class="jbBtn"/></div>--%>
                <asp:Button ID="Button1" runat="server" Text="查询" class="czBtnBlue" OnClick="Button1_Click" />
                <a href="javascript:; " onclick="doPrint() ">
                    <input type="button" value="打印预览" class="jbBtn" /></a>
                <%--   <asp:Button ID="Button2" runat="server" Text="打印预览" class="jbBtn" "/>--%>
                <asp:Button ID="Button3" runat="server" Text="导出EXCEL" class="jbBtn" OnClick="Button3_Click" /></div>
        <!--startprint-->
        <div class="report_h2">
            <h3 class="CenterTitle">
                营业日报表</h3>
            <div class="yyRbbTitle">
                营业日:<span><asp:Label ID="lbstarttime" runat="server" Text="Label"></asp:Label>
                    <asp:Label ID="Label2" runat="server" Text="至"></asp:Label>
                    <asp:Label ID="lbendtime" runat="server" Text="Label"></asp:Label>
                </span>打印时间:<span><asp:Label ID="lbtoday" runat="server" Text="Label"></asp:Label></span>
                <span>制表单位: </span>
            </div>
            <table style="border: solid 1px #cdcdcd" width="95%" border="0" cellspacing="0" cellpadding="0"
                id="tableExcel">
                <asp:Repeater ID="Repeater1" runat="server">
                    <HeaderTemplate>
                        <tr class="textCenter">
                            <td rowspan="2">
                                主帐单号
                            </td>
                            <td rowspan="2">
                                单号
                            </td>
                            <td rowspan="2">
                                房号
                            </td>
                            <td rowspan="2">
                                入住类型
                            </td>
                            <td rowspan="2">
                                来源
                            </td>
                            <td rowspan="2">
                                姓名
                            </td>
                            <td rowspan="2">
                                入住时间
                            </td>
                            <td rowspan="2">
                                离店时间
                            </td>
                            <td rowspan="2">
                                状态
                            </td>
                            <%--<td rowspan="2">天数</td>--%>
                            <td rowspan="2">
                                房价
                            </td>
                            <td colspan="3">
                                本期营业
                            </td>
                        </tr>
                        <tr class="textCenter">
                            <td class="topHB">
                                房租
                            </td>
                            <td class="topHB">
                                消费
                            </td>
                            <td class="topHB">
                                小计
                            </td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# Eval("lordRoomid")%>
                            </td>
                            <td>
                                <%# Eval("occ_no")%>
                            </td>
                            <td>
                                <%# Eval("room_number")%>
                            </td>
                            <td>
                                <%# GetRealModelName(Eval("real_mode_id"))%>
                            </td>
                            <td>
                                <%# GetSourceName(Eval("source_id"))%>
                            </td>
                            <td>
                                <%# Eval("occ_name")%>
                            </td>
                            <td>
                                <%# Eval("occ_time", "{0:yyyy-MM-dd HH:mm}")%>
                            </td>
                            <td>
                                <%# Eval("depar_time", "{0:yyyy-MM-dd HH:mm}")%>
                            </td>
                            <td>
                                <%# GetStateName(Eval("state_id"))%>
                            </td>
                            <%--<td>&nbsp;</td>--%>
                            <td>
                                <%# Eval("real_price","{0:f2}")%>
                            </td>
                            <td>
                                <%# Eval("fangzu", "{0:f2}")%>
                            </td>
                            <td>
                                <%# Eval("xiaofei", "{0:f2}")%>
                            </td>
                            <td>
                                <%# Eval("MoneySum", "{0:f2}")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        <tr>
                            <td colspan="10" align="right" style = "color:Red">
                                合计
                            </td>
                            <td style = "color:Red">
                                <% =fz %>
                            </td>
                            <td style = "color:Red">
                                <% =xh %>
                            </td>
                            <td style = "color:Red">
                                <% =xj %>
                            </td>
                        </tr>
                    </FooterTemplate>
                </asp:Repeater>
            </table>
            <!--endprint-->
            <br />
        </div>
        <!--right-->
    </div>
    <!--主体conTree-->
    <!--main结束-->
    <br />
    <div class="clearboth">
    </div>
    </span><!-- InstanceEndEditable -->
    </form>
</body>
<!-- InstanceEnd -->
</html>
