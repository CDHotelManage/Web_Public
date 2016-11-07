<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userlist.aspx.cs" Inherits="CdHotelManage.Web.Admin.Permissions.accountuser.userlist" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理员管理</title>
    <link href="/style/css.css" rel="stylesheet" type="text/css" />
     <script src="/js/jquery.js" type="text/javascript"></script>
      <script src="/js/DivWH.js" type="text/javascript"></script>
     <link href="/style/Opendiv.css" rel="stylesheet" type="text/css" />
    <script src="../../js/base.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function OpenAdd(obj) {
            var url = "adduser.aspx";
            showMyWindow("添加管理员", url, 330, 400, true, true, true, update);
        }
        function OpenEdit(obj, id) {
            var url = "edituser.aspx?uid=" + id;
            showMyWindow("编辑管理员", url, 330, 400, true, true, true, update);
        }
        function update() {
            window.location.reload();
         }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <h1 class="h1s">
            用户管理
        </h1>
   <table class="tableBlue"    cellspacing="0" >
			<thead>
				<tr>
					<td width="10%">用户名</td>
					<td width="10%">密码</td>
					<td width="10%">角色</td>
					<td width="20%">真实姓名</td>
                    <td width="5%">性别</td>
					<td width="15%">上次登录时间</td>
					<td width="20%">电话</td>
					<td width="10%" class="last">操作</td>
				</tr>
			</thead>
			<tbody>
				 <asp:HiddenField ID="hidSort" Value="Email"  runat="server" />
                 <asp:HiddenField ID="hidOrder" Value="DESC" runat="server" />
                 <asp:HiddenField ID="hidCheck" Value="false" runat="server" />
				<asp:Repeater ID="rptUser" runat="server" onitemcommand="rptUser_ItemCommand">
                    <ItemTemplate>
                        <tr class="tr1">
					    <td><%#Eval("UserName")%></td>
					    <td><%#Eval("Password") %></td>
					    <td><%#GetRole(Eval("UserID").ToString())%></td>
					    <td><%#Eval("TrueName")%></td>
					    <td><%#Eval("Sex") %></td>
					    <td><%#Eval("Email")%></td>
                        <td><%#Eval("Phone")%></td>
					    <td>
                            <a href="#" onclick="OpenEdit(this,'<%#Eval("UserID") %>')">[改]</a>
                            [<asp:LinkButton ID="LinkButton1" runat="server" CommandName="delete" OnClientClick='javascript:return confirm("确定要删除吗？");'>删</asp:LinkButton>]
                            </td>
                        <asp:HiddenField ID="hidid" runat="server" Value='<%#Eval("UserID") %>' />
				</tr>
                    </ItemTemplate>
                </asp:Repeater>
			</tbody>
		</table>

          
               <div  class="pageupdown" > <webdiyer:AspNetPager ID="Pager" runat="server" FirstPageText="首页" LastPageText="尾页"
                    NextPageText="下一页" AlwaysShow="True" PrevPageText="上一页" NextPrevButtonClass="incoleft"
                    CurrentPageButtonClass="rednum" PagingButtonClass="numbs" SubmitButtonText="转到"
                    SubmitButtonClass="enterpage" PageIndexBoxClass="pagebox" FirstLastButtonClass="firstlastbutton"
                    OnPageChanged="Pager_PageChanged">
                </webdiyer:AspNetPager></div>
                <div class="tablepageBtn"><input name=" 添  加 " type="button" value=" 添  加 " class="button_green " onclick="OpenAdd(this)"
                style="width: 100px;" /></div>
           
       

    
    </form>
</body>
</html>
 