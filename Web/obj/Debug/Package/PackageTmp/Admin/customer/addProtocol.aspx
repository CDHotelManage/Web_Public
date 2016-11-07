<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addProtocol.aspx.cs" Inherits="CdHotelManage.Web.Admin.customer.addProtocol" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/tch.css" rel="stylesheet" type="text/css" />
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../../calendar/WdatePicker.js" type="text/javascript"></script>
    <link href="../css/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
    <script src="../js/vip_rechargesolution2.js" type="text/javascript"></script>
    <style type="text/css">
    table{ width:97%;}
    .divOtherCustomer table{ width:100%; background:#fff;}
    table th{ font-size:12px; height:28px;}
    body  .types li span{ height:22px;} 
    </style>
    <script type="text/javascript">
        $(function () {
            HireShow();
        })
        function HireShow() {
            if ($("#Isdiscount").attr("checked")) {
                $("#RoomType").css("display", "none");
                 
            }
            else {
                $("#RoomType").css("display", "block");
            }
        }

    </script>
</head>
<body style=" overflow:hidden">
  <form id="form1" runat="server">
  <input type="hidden" value="" id="accountst" runat="server" />
  <input type="hidden" value="" id="pids" runat="server" />
  <input type="hidden" id="htmls" runat="server" value="" />
  <div class="vip_infor" style="width: 718px">
    <div class="types" style="background: #EFEFEF; border: 1px solid #ddd; margin-top: 0px">
        <ul>
            <li>
                <label style="width: 60px">
                    帐号：</label>
                    <span  id="Accounts" style="width: 120px" class="txt inps" runat="server"></span>
            </li>
            <li>
                <label>
                    客户简称：</label><span  style="width: 120px" id="cusDesy" runat="server" class="txt inps"></span>
            </li>
            <li>
                <label style="width: 60px">
                    协议主题：</label>
                    <input name="Name" type="text" id="Ptheme" class="txt inps"  runat="server" style="width: 120px" maxlength="20">
            </li>
            <li>
                <label style="width: 60px">
                    协议类型：</label>
                    
                <asp:DropDownList runat="server" ID="pType" CssClass="txt"  style=" width:127px;"></asp:DropDownList>
            </li>
            <li>
                <label>
                   协议单号：</label>
                <input name="Name" type="text" id="PNumber" class="txt inps"  runat="server" style="width: 120px" maxlength="20">
            </li>
            <li>
                <label style="width: 60px">
                    签约时间：</label>
                <input name="Name" type="text" id="term" class="txt inps"  runat="server" onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss',onpicked:function() {AddDay()}})" style="width: 120px" maxlength="20">
            </li>
            <li>
                <label>
                    有效期至：</label>
                <input name="Phone" type="text" id="period" class="inps txt"  onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss',onpicked:function() {AddDay()}})" runat="server" style="width: 120px"
                    maxlength="11">
            </li>
            <li>
                <label>
                    早餐份数：</label>
               <input name="Phone" type="text" id="breakfast" class="inps txt"  value="0" runat="server" style="width: 120px"
                    maxlength="11">
            </li>
            <li>
                <label style="width: 60px">
                    佣金：</label>
                <input name="Phone" type="text" id="Commission" class="inps txt" value="0" runat="server" style="width: 120px"
                    maxlength="11">
            </li>
            
            <li>
                <label style="width:75px; text-align:left;">
                    客户签约人：</label>
                <input name="Name" type="text" id="signatory" class="txt inps"  runat="server" style="width: 106px; " maxlength="20">
            </li>
            <li>
                <label style="width:75px;text-align:left;">
                    本司签约人：</label>
                <input name="Name" type="text" id="companysignatory" class="txt inps"  runat="server" style="width: 105px;" maxlength="20">
            </li>
            <li style=" display:none;">
                <label style="width:60px;">
                    房间号：</label>
                <input name="Name" type="text" id="roomNumber" class="txt inps"  runat="server" style="width: 120px; margin:0;" maxlength="20">
            </li>
             <li>
                <label style="width:100px;text-align:left;">
                    房价固定折扣值：</label>
                <input name="Name" type="text" id="discount" class="txt inps"  runat="server" value="1" style="width: 80px;" maxlength="20">
            </li>
             <li>
                <label style="width: 60px">
                    备&nbsp;&nbsp;&nbsp;&nbsp;注：</label>
                <input name="Name" type="text" id="Remark" class="txt inps"  runat="server" style="width: 595px" maxlength="20">
            </li>
            <li>
               <label style="width: 60px">
               协议内容：</label>
               <textarea style=" width:595px; height:80px;" id="Details" runat="server"></textarea>
            </li>
        </ul>
    </div>
    <div class="types" style="background: #EFEFEF; border: 1px solid #ddd; margin-top: 10px">
        <ul>
      <li style=" width:25%">
                <input type="checkbox" id="ishire" onclick="Ishire()"  runat="server" /><label>是否按房类记佣</label>
            </li>
            <li style=" width:25%">
                <input type="checkbox" id="Dayhire"  runat="server" /><label>是否每日记佣</label>
            </li>
            <li style=" width:25%; display:none">
                <input type="checkbox" id="prohire"  runat="server" /><label>前台是否显示佣金金额</label>
            </li>
            <li style=" width:25%">
                <input type="checkbox" id="Isdiscount" onclick="HireShow()"  runat="server" /><label>是否使用固定房价折扣</label>
            </li>
            </ul>
     </div>
      <div class="types" id="RoomType" style="background: #EFEFEF; border: 1px solid #ddd; margin-top: 10px;">
       自定义协议房价方案<br />
        <div class="ruzhu_infor" style="width:95%; margin-top:10px">
            <div style="width: 100%; background: #00ADEF; float: left;">
                <table cellspacing="0" cellpadding="0" style="width: 98%;">
                    <tbody>
                        <tr>
                            <th width="15%">房型</th>
                            <th width="15%">标准价格</th>
                            <th width="15%">折扣值</th>
                            <th width="15%">折扣价格</th>
                            <th width="15%">月租房</th>
                            <th width="15%">佣金</th>
                            <th width="16%">操作</th>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="gundong" style="max-height: 174px; height: auto">
                <div class="divOtherCustomer">
                    <table cellpadding="0" cellspacing="0" class="ruzhu">
                        <tbody>
                        <%=sbPrice.ToString() %>
                        <asp:Repeater runat="server" ID="rep1">
                            <ItemTemplate>
                              <tr>
                                <td width="15%" typeid="<%#Eval("RoomType") %>" class="roomType"><%#Getyuan( Convert.ToInt32(Eval("RoomType")))%></td>
                                <td width="15%" class="Price"><%#Eval("Price")%></td>
                                <td width="15%" class="zdPrice"><%#Eval("zdPrice")%></td>
                                <td width="15%" class="protoPrice"><%#Eval("protoPrice")%></td>
                                <td  width="15%" class="mothPrice"><%#Eval("mothPrice")%></td>
                                <td  width="15%" class="commission"><%#Eval("commission")%></td>
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
                    <input type="text" name="zdPrice" id="protoPrice" maxlength="8">
                </td>
                <td width="15%">
                    <input type="text" name="lcPrice" id="mothPrice" maxlength="8">
                </td>
                <td width="15%">
                    <input type="text" name="commission" id="commission" maxlength="8">
                </td>
                <td width="15%">
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
      </div>
      <div class="vip_db" style="margin-left: 0px; width: 100%">
                <div class="fl">
                    <input type="button" value="确定" class="bus_add" runat="server" onclick="AddHtml();" onserverclick="bus_add_Click" id="btn_Sa">
                </div>
      </div>
    </form>
</body>
</html>
