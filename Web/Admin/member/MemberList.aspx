<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberList.aspx.cs" Inherits="CdHotelManage.Web.Admin.member.MemberList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>会员列表</title>
    <script src="../../js/DivWH.js" type="text/javascript"></script>
    <link href="../../style/Opendiv.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../js/base.js" type="text/javascript"></script>
    <script type="text/javascript">
        function CostAdds(obj, ids) {
            var url = "memberEdit.aspx?type=edit&id=" + ids;
            alert(url);
            //showMyWindow("会员信息", url, 600, 350, true, true, true, Updates);
        }
        function ShowEdit(obj, ids) {
            var url = "typeEdit.aspx?type=edit&typeid=" + ids;
            showMyWindow("会员信息", url, 600, 350, true, true, true, Updates);
        }
        function Updates() {
            window.location.reload();
        }

        function ShowEdi1t (obj) {
            var url = "typeEdit.aspx?type=add";
            showMyWindow("新增类型", url, 600, 350, true, true, true, Updates);
        };
        function Delete(id,obj1) {
            if (confirm("是否确定删除??")) {
                $.get("/Admin/Ajax/Books.ashx", "type=delids&typeid=" + id, function (obj) {

                    if (obj == "删除成功") {
                        window.location.reload();
                    }
                    else if (obj == "err") {
                        alert("有会员信息不能删除！！");
                    }
                }, "text");
            }
        }

        

        function selectWhere(typeid) {
            window.location = "MemberList.aspx?types=" + typeid;
        }
    </script>
    <style type="text/css">
       ul,li{ margin:0; padding:0; list-style:none;}
      .lefts{width: 10%; float: left; display:block;}
      .rights{ width:90%; float:left; display:block;}
      .vip_member{border-top: 0px #ddd solid;border-left: 1px #ddd solid;}
      .vip_member tr {  color: #333; font-size: 12px;}
      table tr td {
  border-bottom: 1px #ddd solid;
  border-right: 1px #ddd solid;
  line-height: 28px;
  text-align: center;
  padding: 2px 5px;
}
.spancli{ display:block; padding:5px 15px;}
      .vip_member th {  font-size: 14px;border-bottom: 1px #0789BE solid;border-right: 1px #66D5FF solid;height: 32px;background: #00ADEF;color: #FFF;}
      ul.vip_member{  float: left;width: 10%;margin-top: 0px;border-bottom: 1px solid #DDD;border-left: 1px solid #ddd;background: #D0F2FF;  font-size: 12px;}
      ul.vip_member{  float: left;width: 90%;text-align: left;line-height: 31px;color: #333;border-top: 1px solid #AAE8FF;border-bottom: 1px solid #FFF;cursor: pointer;position: relative;text-indent:20px;}
      ul.vip_member li{ position: relative;}
      ul.vip_member li:hover, ul.vip_member li.select{background: #E5FFD2;}
      ul.vip_member li em.edit{  background-position: 0px 0px;top: 3px;  right: 25px;}
      ul.vip_member li em{  background: url(../../admin/Accounts/Images/edit_1.png) no-repeat;width: 11px;height: 11px;float: left;margin-left: 10px; margin-top: 8px;  position: absolute;}
      ul.vip_member li em.dell {background-position: 0px -16px;  right: 5px; top: 2px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="lefts">
        <ul class="vip_member" id="li_kind" style="width: 100%">
            <li onclick="selectWhere('all')"><span>全部</span></li>
             <%=sbtext.ToString() %>
            <li class="add">
                <input type="button" value="添加" onclick="ShowEdi1t(this)" id="btnSPFLAdd" class="bus_add"></li></ul>
    </div>
    <div class="rights">
        <table cellpadding="0" cellspacing="0" class="vip_member" id="tblgood" style="width: 100%">
            <tr>
                <th width="8%">
                    卡号
                </th>
                <th width="5%">
                    类型
                </th>
                <th width="7%">
                    姓名
                </th>
                <th width="8%">
                    电话
                </th>
                <th width="5%">
                    性别
                </th>
                <th width="8%">
                    生日
                </th>
                <th width="5%">
                    证件类型
                </th>
                <th width="10%">
                    证件号码
                </th>
                <th width="8%">
                    操作员
                </th>
                <th width="7%">
                    操作
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rep1">
            <ItemTemplate>
            <tr>
                <td>
                    <a href="javascript:void(0)" onclick="showCardLog('001','10')">001</a>
                </td>
                <td>
                    <%#Eval("UserTypeModel.typename") %>
                </td>
                <td>
                    <%#Eval("Username")%>
                </td>
                <td>
                   <%#Eval("UserInfoModel.phone")%>
                </td>
                <td>
                    <%#GetSex(Convert.ToBoolean(Eval("UserInfoModel.sex")))%>
                </td>
                <td>
                    <%#Eval("UserInfoModel.bairthday")%>
                </td>
                <td>
                    <%#Eval("UserInfoModel.cardTypeID")%>
                </td>
                <td>
                    <%#Eval("UserInfoModel.cardValue")%>
                </td>
                <td>
                    <%#GetManageName(Eval("UserInfoModel.manageID").ToString())%>
                </td>
                <td>
                    <img src="../Accounts/images/037.gif" width="9" height="9"><span class="STYLE1"> [</span><a
                        href="#" onclick='CostAdds(this,"<%#Eval("userid") %>")'>编辑</a><span class="STYLE1">]</span>
                </td>
            </tr>
            </ItemTemplate>
            </asp:Repeater>
        </table>
        
    </div>
    </form>
</body>
</html>
