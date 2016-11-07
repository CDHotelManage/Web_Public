<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addContact.aspx.cs" Inherits="CdHotelManage.Web.Admin.customer.addContact" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="../css/tch.css" rel="stylesheet" type="text/css" />
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <script src="../js/base.js" type="text/javascript"></script>
    <script src="../../calendar/WdatePicker.js" type="text/javascript"></script>
    <style type="text/css">
     .vip_infor ul li .txt{ margin-right:20px;}
     .vip_infor ul li .w80{ width:50px;} body  .types li span{ height:22px;} 
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" runat="server" id="Accounts" />
    <div class="vip_infor" style="width: 638px">
    <div class="types" style="background: #EFEFEF; border: 1px solid #ddd; margin-top: 0px">
        <ul>
            <li>
                <label style="width: 60px">
                    客户简称：</label><span  style="width: 120px" id="cusDesy" runat="server" class="txt inps"></span>
            </li>
            <li>
                <label>
                    姓名：</label>
                    <input name="cusDesy" type="text" id="cName"  runat="server" class="inps txt" style="width: 120px"
                        maxlength="20">
            </li>
            <li>
                <label style="width: 60px">
                    性别：</label>
                    <asp:DropDownList runat="server" ID="Sex" CssClass="txt" style=" width:127px;">
                     <asp:ListItem Value="0" Text="男"></asp:ListItem>
                     <asp:ListItem Value="1" Text="女"></asp:ListItem>
                    </asp:DropDownList>
            </li>
            <li>
                <label style="width: 60px">
                    出生日期：</label><input name="cusDesy" type="text" id="Bearthday" onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss',onpicked:function() {AddDay()}})" runat="server" class="inps txt" style="width: 120px"
                        maxlength="20">
            </li>
            <li>
                <label>
                   称呼：</label>
                   
                <asp:DropDownList runat="server" ID="Appellation" CssClass="txt" style=" width:127px;">
                     <%--<asp:ListItem Value="0" Text="先生"></asp:ListItem>
                     <asp:ListItem Value="1" Text="女士"></asp:ListItem>
                     <asp:ListItem Value="2" Text="阿咦"></asp:ListItem>
                     <asp:ListItem Value="3" Text="大哥"></asp:ListItem>--%>
                </asp:DropDownList>
            </li>
            <li>
                <label style="width: 60px">
                    部门：</label>
               <asp:DropDownList runat="server" ID="department" CssClass="txt" style=" width:127px;">
               <%--<asp:ListItem Value="0" Text="技术部"></asp:ListItem>
                     <asp:ListItem Value="1" Text="业务"></asp:ListItem>--%>
               </asp:DropDownList>
            </li>
            <li>
                <label>
                    办公电话：</label>
                <input name="Phone" type="text" id="officPhone" class="inps txt"  runat="server" style="width: 120px"
                    maxlength="11">
            </li>
            <li>
                <label>
                    手机：</label>
                <input name="Phone" type="text" id="Phone" class="inps txt"  runat="server" style="width: 120px"
                    maxlength="11">
            </li>
            <li>
                <label style="width: 60px">
                    家庭电话：</label>
                <input name="Phone" type="text" id="familyPhone" class="inps txt"  runat="server" style="width: 120px"
                    maxlength="11">
            </li>
            
            <li>
                <label style="width: 60px">
                    职&nbsp;&nbsp;&nbsp;&nbsp;务：</label>
               <asp:DropDownList runat="server" ID="Post" CssClass="txt" style=" width:127px;">
               </asp:DropDownList>
            </li>
            <li>
                <label style="width: 60px">
                    邮&nbsp;&nbsp;&nbsp;&nbsp;编：</label>
                <input name="Name" type="text" id="zipcode" class="txt inps"  runat="server" style="width: 120px" maxlength="20">
            </li>
            <li>
                <label style="width: 60px">
                    Email：</label>
                <input name="Name" type="text" id="Mail" class="txt inps"  runat="server" style="width: 120px" maxlength="20">
            </li>
             <li>
                <label style="width: 60px">
                    地址：</label>
                <input name="Name" type="text" id="Address" class="txt inps"  runat="server" style="width: 120px" maxlength="20">
            </li>
             <li>
                <label style="width: 60px">
                    兴趣爱好：</label>
                <input name="Name" type="text" id="Likes" class="txt inps"  runat="server" style="width: 120px" maxlength="20">
            </li>
             <li>
                <label style="width: 60px">
                    备注：</label>
                <input name="Name" type="text" id="Remark" class="txt inps"  runat="server" style="width: 120px" maxlength="20">
            </li>
        </ul>
    </div>

     <div class="types">
            <ul style="float: right; width: 174px">
                <li style="">
                    <input name="BtnSave" type="button" id="BtnSave" class="bus_add " value="新增客户" runat="server" onserverclick="BtnSave_Click">
                </li>
                <li style="margin-right: 0px">
                    <input type="button" class="bus_dell " id="BtnDel" onclick="Close()" value="关闭" style="margin-right: 0px">
                </li>
            </ul>
        </div>
     <!--end-->
    </div>
    </form>
</body>
</html>
