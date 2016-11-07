<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addCustomer.aspx.cs" Inherits="CdHotelManage.Web.Admin.customer.addCustomer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/tch.css" rel="stylesheet" type="text/css" />
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <script src="../js/base.js" type="text/javascript"></script>
    <style type="text/css">
     .vip_infor ul li .txt{ margin-right:20px;}
     .vip_infor ul li .w80{ width:50px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" id="acc" runat="server" />
    <div class="vip_infor" style="width: 868px">
    <div class="types" style="background: #EFEFEF; border: 1px solid #ddd; margin-top: 0px">
        <ul>
            <li>
                <label style="width: 60px">
                    客户全称：</label>
                <input name="Name" type="text" id="cName" class="txt inps" runat="server" style="width: 120px" maxlength="20">
            </li>
            <li>
                <label>
                    系统类型：</label>
               <asp:DropDownList runat="server" ID="sysType" CssClass="txt" style=" width:127px;"></asp:DropDownList>
            </li>
            <li>
                <label style="width: 60px">
                    客户类型：</label>
                    <asp:DropDownList runat="server" ID="cusType" CssClass="txt" style=" width:127px;"></asp:DropDownList>
            </li>
            <li>
                <label style="width: 60px">
                    客户简称：</label><input name="cusDesy" type="text" id="cusDesy"  runat="server" class="inps txt" style="width: 120px"
                        maxlength="20">
            </li>
            <li>
                <label>
                   客户编号：</label>
                <input name="Name" type="text" id="cusNumber" class="txt inps"  runat="server" style="width: 120px" maxlength="20">
            </li>
            <li>
                <label style="width: 60px">
                    主联系人：</label>
                <input name="Name" type="text" id="contacts" class="txt inps"  runat="server" style="width: 120px" maxlength="20">
            </li>
            <li>
                <label>
                    手&nbsp;&nbsp;&nbsp;&nbsp;机：</label>
                <input name="Phone" type="text" id="cPhone" class="inps txt"  runat="server" style="width: 120px"
                    maxlength="11">
            </li>
            <li>
                <label>
                    状&nbsp;&nbsp;&nbsp;&nbsp;态：</label>
                <asp:DropDownList runat="server" ID="Cstate" CssClass="txt"  style=" width:127px;"></asp:DropDownList>
            </li>
            <li>
                <label style="width: 60px">
                    销售人员：</label>
                <asp:DropDownList runat="server" ID="sales" CssClass="txt" style=" width:127px;"></asp:DropDownList>
            </li>
            
            <li>
                <label style="width: 60px">
                    地&nbsp;&nbsp;&nbsp;&nbsp;区：</label>
                <input name="Name" type="text" id="area" class="txt inps"  runat="server" style="width: 120px" maxlength="20">
            </li>
            <li>
                <label style="width: 60px">
                    邮&nbsp;&nbsp;&nbsp;&nbsp;编：</label>
                <input name="Name" type="text" id="ybNum" class="txt inps"  runat="server" style="width: 120px" maxlength="20">
            </li>
            <li>
                <label style="width: 60px">
                    地&nbsp;&nbsp;&nbsp;&nbsp;址：</label>
                <input name="Name" type="text" id="Address" class="txt inps"  runat="server" style="width: 120px" maxlength="20">
            </li>
             <li>
                <label style="width: 60px">
                    公司电话：</label>
                <input name="Name" type="text" id="companyPhone" class="txt inps"  runat="server" style="width: 120px" maxlength="20">
            </li>
             <li>
                <label style="width: 60px">
                    传&nbsp;&nbsp;&nbsp;&nbsp;真：</label>
                <input name="Name" type="text" id="Fax" class="txt inps"  runat="server" style="width: 120px" maxlength="20">
            </li>
             <li>
                <label style="width: 60px">
                    Email：</label>
                <input name="Name" type="text" id="Email" class="txt inps"  runat="server" style="width: 120px" maxlength="20">
            </li>
             <li>
                <label style="width: 60px">
                    主&nbsp;&nbsp;&nbsp;&nbsp;页：</label>
                <input name="Name" type="text" id="homepage" class="txt inps"  runat="server" style="width: 120px" maxlength="20">
            </li>
             <li>
                <label style="width: 60px">
                    客户来源：</label>
                <asp:DropDownList runat="server" ID="Csource" CssClass="txt"  runat="server" style=" width:127px;"></asp:DropDownList>
            </li>
             <li>
                <label style="width: 60px">
                    客户行业：</label>
                <asp:DropDownList runat="server" ID="cIndustry" CssClass="txt"  runat="server" style=" width:127px;"></asp:DropDownList>
            </li>
           <li>
                <label style="width: 60px">
                    备&nbsp;&nbsp;&nbsp;&nbsp;注：</label>
                <input name="Name" type="text" id="Remark" class="txt inps"  runat="server" style="width: 120px" maxlength="20">
            </li>
        </ul>
    </div>
    <div class="types" style="background: #EFEFEF; border: 1px solid #ddd; margin-top: 10px">
        <ul>
      <li style=" width:25%">
                <input type="checkbox" id="Ischalk"  runat="server" /><label>不允许该单位记帐</label>
            </li>
            <li style=" width:25%">
                <input type="checkbox" id="isXz" runat="server"/><label>记帐限额</label><input name="Name" type="text" id="limit"  runat="server" class="inps" style="width:50px"><label>元</label>
            </li>
            <li style=" width:25%">
                <input type="checkbox" id="prosceniumIss"  runat="server" /><label>前台是否可以查询</label>
            </li>
            <li style=" width:25%">
                <input type="checkbox" id="Ishire"  runat="server" /><label>是否返佣单位</label>
            </li>
            </ul>
     </div>
     <div class="types" style="background: #EFEFEF; border: 1px solid #ddd; margin-top: 10px; display:none;" id="accoes" runat="server">
       <ul>
           <li>
                <label style="width: 100px">
                    应收帐款：</label>
              <span class="inps w80" id="ysh" runat="server"></span>
            </li>
            <li>
                <label style="width: 100px">
                    预收帐款：</label>
              <span class="inps w80" id="yush" runat="server"></span>
            </li>
            <li>
                <label style="width: 100px">
                    已结算：</label>
              <span class="inps w80" id="yjsh" runat="server"></span>
            </li>
            <li>
                <label style="width: 100px">
                    累计消费总额：</label>
              <span class="inps w80" id="njxfs" runat="server" ></span>
            </li>
            <li>
                <label style="width: 100px">
                    累计入住天数：</label>
              <span class="inps w80" id="Span4"><%=modelcus.occNum %></span>
            </li>
            <li>
                <label style="width: 100px">
                    累计NoShow次数：</label>
              <span class="inps w80" id="Span5"><%=modelcus.NoShow %></span>
            </li>
            <li>
                <label style="width: 100px">
                    累计取消预定：</label>
              <span class="inps w80" id="Span6"><%=modelcus.xqBook %></span>
            </li>
            <li>
                <label style="width: 100px">
                    同类客户排名：</label>
              <span class="inps w80" id="Span7"><%=modelcus.Pming %></span>
            </li>
            <li>
                <label style="width: 100px">
                    未结算佣金：</label>
              <span class="inps w80" id="Span8"><%=commw %></span>
            </li>
            <li>
                <label style="width: 100px">
                    已结算佣金：</label>
              <span class="inps w80" id="Span9"><%=commy %></span>
            </li>
        </ul>
     </div>

     <!--end-->
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
