<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addPice.aspx.cs" Inherits="CdHotelManage.Web.Admin.member.addPice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <link href="../css/tch.css" rel="stylesheet" type="text/css" />
    <link href="../css/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../js/vip_rechargesolution.js" type="text/javascript"></script>
    <script src="../js/base.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="ruzhu_infor" style="width: 600px">

        <%--<div class="line">
            <div class="fl">充值方案</div>
            <div class="errortips" id="btnRead"></div>
        </div>--%>
        <div class="types">
            <div style="width: 100%; background: #00ADEF; float: left">
                <table cellspacing="0" cellpadding="0" style="width: 98%;">
                    <tbody>
                        <tr>
                            <th width="20%">充值金额</th>
                            <th width="20%">赠送金额</th>
                            <th width="20%">赠送积分</th>
                            <th>状态</th>
                            <th width="16%">操作</th>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="gundong" style="max-height: 174px; height: auto">
                <div class="divOtherCustomer">
                    <table cellpadding="0" cellspacing="0" class="ruzhu">
                        <tbody>
                        <asp:Repeater runat="server" ID="rep1">
                        <ItemTemplate>
                            <tr>
                                <td width="20%">
                                    <%#Eval("AddPice")%>
                                </td>
                                <td width="20.5%">
                                    <%#Eval("ZsPice")%>
                                </td>
                                <td width="20.5%">
                                    <%#Eval("ZsJf")%>
                                </td>
                                <td>
                                    <%#GetStr( Convert.ToBoolean(Eval("IsOk")))%>
                                </td>
                                <td width="15%">
                                    <input type="hidden" name="RowData" value="<%#Eval("MtID")%>|<%#Eval("AddPice")%>|<%#Eval("ZsPice")%>|<%#Eval("ZsJf")%>|<%#GetStr1( Convert.ToBoolean(Eval("IsOk")))%>">
                                    <input type="hidden" name="RowState" value="<%#Eval("IsOk")%>">
                                    <input type="hidden" name="RowId" value="<%#Eval("MtID")%>">
                                    <a href="javascript:void(0)" onclick="RowEdit(this)">
                                        <img src="../images/037.gif" width="10" height="10" alt=""></a> <a href="javascript:void(0)"
                                            onclick="RowDelete(this)">
                                            <img src="../images/010.gif" width="10" height="10" alt=""></a>
                                </td>
                            </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        </tbody>
                    </table>
                </div>
            </div>
            <input class="butn btnAddOtherCustomer" type="button" value="+">
        </div>
        <div class="types">
            <ul style="float: right; width: 184px;">
            <%--<li style=""><input type="button" class="bus_add" id="btnSubmit" value="确定" /></li>--%>
                <li style="margin-right: 0px">
                    <input type="button" class="bus_dell " id="btnClose" value="关闭" onclick="Close()" style="margin-right: 0px" /></li>
            </ul>
        </div>
    </div>


    <table id="divEditRow" class="none">
        <tbody>
            <tr>
                <td width="20%">
                    <input type="text" name="RechargeAmount" maxlength="8">&nbsp;元
                </td>
                <td width="20.5%">
                    <input type="text" name="GivenAmount" maxlength="8">&nbsp;元
                </td>
                <td width="20.5%">
                    <input type="text" name="GivenSorce" maxlength="8">&nbsp;分
                </td>
                <td>
                    <input type="radio" checked="checked" value="0" style="width: 14px; height: 14px; border: 0px; vertical-align: -3px" />
                    <label>开启</label>
                    <input type="radio" value="1" style="width: 14px; height: 14px; border: 0px; vertical-align: -3px; margin-left: 10px; display: inline" />关闭
                </td>
                <td width="15%">
                    <input type="hidden" name="RowData" />
                    <input type="hidden" name="RowState" value="1" />
                    <input type="hidden" name="RowId" value="0" />
                    <a class="btnSave" onclick="RowSave(this)" href="javascript:void(0)">
                        <img width="10" height="10" alt="" src="../images/save.png" /></a>
                    <a onclick="RowDelete(this)" href="javascript:void(0)">
                        <img width="10" height="10" alt="" src="../images/010.gif" /></a>
                </td>
            </tr>
        </tbody>
    </table>


    <table id="divDetailRow" class="none" style="height: 174px; overflow: hidden">
        <tbody>
            <tr>
                <td width="20%"></td>
                <td width="20.5%"></td>
                <td width="20.5%"></td>
                <td></td>
                <td width="15%">
                    <input type="hidden" name="RowData" />
                    <input type="hidden" name="RowState" value="0" />
                    <input type="hidden" name="RowId" value="0" />
                    <a href="javascript:void(0)" onclick="RowEdit(this)">
                        <img src="../images/037.gif" width="10" height="10" alt="" /></a>
                    <a href="javascript:void(0)" onclick="RowDelete(this)">
                        <img src="../images/010.gif" width="10" height="10" alt="" /></a></td>
            </tr>
        </tbody>
    </table>
    </form>
</body>
</html>
