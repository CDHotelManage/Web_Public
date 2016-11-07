<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mtPrice.aspx.cs" Inherits="CdHotelManage.Web.Admin.member.mtPrice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <link href="../css/tch.css" rel="stylesheet" type="text/css" />
    <link href="../css/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../js/vip_rechargesolution1.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" id="memtypeid" value="" runat="server"/>
      <div class="ruzhu_infor" style="width: 600px">

        <div class="line">
            <div class="fl">会员价格</div>
            <div class="errortips" id="btnRead"></div>
        </div>
        <div class="types">
            <div style="width: 100%; background: #00ADEF; float: left">
                <table cellspacing="0" cellpadding="0" style="width: 98%;">
                    <tbody>
                        <tr>
                            <th width="15%">房间类型</th>
                            <th width="15%">实际价格</th>
                            <th width="15%">折扣值</th>
                            <th width="15%">折扣价格</th>
                            <th width="15%">凌晨房间价格</th>
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
                                <td width="15%" class="roomType"><%#Getyuan( Convert.ToInt32(Eval("RoomType")))%></td>
                                <td width="15%" class="Price"><%#Eval("Price")%></td>
                                <td width="15%" class="zdPrice"><%#Eval("zdPrice")%></td>
                                <td width="15%" class="Dayprice"><%#Eval("Dayprice")%></td>
                                <td  width="15%" class="lcPrice"><%#Eval("lcPrice")%></td>
                                <td width="16%">
                                <input type="hidden" id="ids" value="<%#Eval("ID")%>"/>
                                <a href="javascript:void(0)" onclick="RowEdit(this)">
                                        <img src="../images/037.gif" width="10" height="10" alt=""></a> <a href="javascript:void(0)"
                                            onclick="RowDelete(this)">
                                            <img src="../images/010.gif" width="10" height="10" alt=""></a></td>
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
                    <input type="button" class="bus_dell " id="btnClose" value="关闭" style="margin-right: 0px" /></li>
            </ul>
        </div>
    </div>


    <table id="divEditRow" class="none">
        <tbody>
            <tr>
                <td width="15%">
                    <select id="roomType">
                     <%=sbtext.ToString() %>
                    </select>
                </td>
                <td width="15%">
                    <input type="text" name="Dayprice" id="Price" maxlength="8">
                </td>
                <td width="15%">
                    <input type="text" name="zdPrice" id="zdPrice" maxlength="8">
                </td>
                <td width="15%">
                    <input type="text" name="zdPrice" id="Dayprice" maxlength="8">
                </td>
                <td width="15%">
                    <input type="text" name="lcPrice" id="lcPrice" maxlength="8">
                </td>
                <td width="15%">
                    <input type="hidden" name="RowId" id="RowId" value="0" />
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
                <td width="15%"></td>
                <td width="15%"></td>
                <td width="15%"></td>
                <td width="15%"></td>
                <td width="15%"></td>
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
