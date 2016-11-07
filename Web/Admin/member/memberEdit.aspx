<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="memberEdit.aspx.cs" Inherits="CdHotelManage.Web.Admin.member.memberEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
       body{ margin:0; padding:0;}
       li,ul{ margin:0; padding:0; list-style:none;}
      .type{  background: #EFEFEF;margin-top: 0px;}
      .vip_infor{  float: left;
  background: #fff;  width: 600px;}
      .vip_infor ul li {
  width: auto;
  float: left;
  padding: 4px 0px;
  line-height: 22px;
}
.vip_infor ul {
  width: 100%;
  float: left;
}
.vip_infor ul li input.inps {
  height: 20px;
  line-height: 20px;
}
.vip_infor ul li .txt {
  margin-right: 40px;
  display: inline;
}
.vip_infor ul li input {
  float: left;
  border: 1px solid #ccc;
  padding-left: 5px !important;
}
.vip_infor ul li label {
  float: left;
  text-align: right;
  line-height: 22px;
  color: #333;
  font-size: 12px;
  padding: 0 5px;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" runat="server" id="hiduid"/>
    <div class="vip_infor">
    <div class="type">
            <ul>
                 <li>
                    <label style="width: 60px">卡号：</label>
                    <input type="text" class="txt inps" style="width: 130px" id="card" runat="server" maxlength="20">
                </li>
                <li>
                    <label style="width: 60px">姓名：</label>
                    <input type="text" class="txt inps" style="width: 130px" id="Name" runat="server" maxlength="20">
                </li>
                <li>
                    <label>性别：</label>
                    <select class="txt" runat="server" style="width: 86px" id="Sex">
                        <option value="0">男</option>
                        <option value="1">女</option>
                    </select>
                </li>
                <li>
                    <label style="width: 50px">证件：</label>
                    <asp:DropDownList ID="CardType" runat="server"></asp:DropDownList>
                    <%--<select style="width: 98px" id="CardType">
                    <option value="身份证">身份证</option><option value="驾驶证">驾驶证</option><option value="军官证">军官证</option>
                    </select>--%>
                </li>
                <li>
                    <label style="width: 60px">证件号码：</label><input type="text" class="inps txt" style="width: 130px" id="CardNo" runat="server" maxlength="20">
                </li>
                <li>
                    <label>类型：</label>
                    <asp:DropDownList ID="CategoryId" runat="server"></asp:DropDownList>
                    <%--<select class="txt" id="CategoryId" onchange="CategoryType()" disabled="disabled" style="width: 86px;background:#CCC;">
                    <option value="0">请选择</option><option value="63">金卡</option><option value="69">铂金卡</option><option value="84">qqqq</option></select>--%>
                </li>
                <li>
                    <label>手机号码：</label>
                    <input type="text" class="inps txt" runat="server" style="width: 130px" id="Phone" maxlength="11">
                </li>
                <li>
                    <label>生日：</label>
                    <input type="text" class="inps txt" runat="server" style="width: 78px" id="BirthDay">
                </li>
                <li style="width: 100%">
                    <label style="width: 60px">喜好：</label>
                    <input type="text" class="inps" runat="server" style="width: 500px" id="Love" maxlength="100">
                </li>
                <li style="width: 100%">
                    <label style="width: 60px">地址：</label>
                    <input type="text" class="inps" runat="server" style="width: 500px" id="Address" maxlength="100">
                </li>
                <li style="width: 100%">
                    <label style="width: 60px">备注：</label>
                    <input type="text" class="inps" runat="server" style="width: 500px" id="Remark" maxlength="100">
                </li>
            </ul>
    </div>
    <asp:Button Text="确定" OnClick="btn_Sub_Click" runat="server" ID="btn_Sub" />
    </div>
    </form>
</body>
</html>
