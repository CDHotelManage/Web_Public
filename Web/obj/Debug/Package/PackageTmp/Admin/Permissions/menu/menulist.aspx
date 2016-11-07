<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="menulist.aspx.cs" Inherits="CdHotelManage.Web.Admin.Permissions.menu.menulist" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>菜单管理</title>
    <link href="/style/css.css" rel="stylesheet" type="text/css" />
     <script src="/js/jquery.js" type="text/javascript"></script>
      <script src="/js/DivWH.js" type="text/javascript"></script>
     <link href="/style/Opendiv.css" rel="stylesheet" type="text/css" />
    <script src="../../js/base.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function OpenAdd(obj) {
            var url = "AddMenu.aspx";
            showMyWindow("添加菜单", url, 350, 380, true, true, true, update);
        }
        function OpenEdit(obj, id) {
            var url = "EditMenu.aspx?menu_id=" + id;
            showMyWindow("编辑菜单", url, 350, 380, true, true, true, update);
        }
        function update() {
            window.location.reload();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <h1 class="h1s">
            菜单管理
        </h1>
    <table class="tableBlue"    cellspacing="0" >
			<thead>
				<tr>
					<td width="15%">菜单名称</td>
					<td width="15%">父级菜单</td>
					<td width="30%">路径</td>
		   			<td width="10%">是否启用</td>
					<td width="30%" class="last">操作</td>
				</tr>
			</thead>
			<tbody>
				 <asp:HiddenField ID="hidSort" Value="sortId"  runat="server" />
                 <asp:HiddenField ID="hidOrder" Value="DESC" runat="server" />
                 <asp:HiddenField ID="hidCheck" Value="false" runat="server" />
				<asp:Repeater ID="rptMenu" runat="server" onitemcommand="rptMenu_ItemCommand">
                    <ItemTemplate>
                        <tr class="tr1">
					    <td><%#Eval("title")%></td>
					    <td><%# GetName(Eval("parent_id").ToString())%></td>
					    <td><%#Eval("url") %></td>
					    <td><%#Eval("isable").ToString()=="True"?"是":"否"%></td>
					    <td>[<asp:LinkButton runat="server" CommandName="look" CommandArgument='<%#Eval("menu_id") %>'>查看子菜单</asp:LinkButton>]
                            [<asp:LinkButton runat="server" CommandName="delete" OnClientClick='javascript:return confirm("确定要删除吗？");'>删除</asp:LinkButton>]
                            <a href="#" onclick="OpenEdit(this,'<%#Eval("menu_id") %>')">[编辑]</a>
                            </td>
                        <asp:HiddenField ID="hidid" runat="server" Value='<%#Eval("menu_id") %>' />
				</tr>
                    </ItemTemplate>
                </asp:Repeater>
			</tbody>
		</table>
       
            <div class="pageupdown">
                <webdiyer:AspNetPager ID="Pager" runat="server" FirstPageText="首页" LastPageText="尾页"
                    NextPageText="下一页" AlwaysShow="True" PrevPageText="上一页" NextPrevButtonClass="incoleft"
                    CurrentPageButtonClass="rednum" PagingButtonClass="numbs" SubmitButtonText="转到"
                    SubmitButtonClass="enterpage" PageIndexBoxClass="pagebox" FirstLastButtonClass="firstlastbutton"
                    OnPageChanged="Pager_PageChanged">
                </webdiyer:AspNetPager>
            </div>
       
     <div class="xzbtn" style="text-align: right;">
            <input name=" 添  加 " type="button" value=" 添  加 " class="button_green " onclick="OpenAdd(this)"
                style="width: 100px;" /></div>
    </form>
</body>
</html>
