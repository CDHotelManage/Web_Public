<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bannerlist.aspx.cs" Inherits="CdHotelManage.Web.Admin.banner.bannerlist" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>横幅管理</title>
     <link href="/style/css.css" rel="stylesheet" type="text/css" />
     <script src="/js/jquery.js" type="text/javascript"></script>
      <script src="/js/DivWH.js" type="text/javascript"></script>
     <link href="/style/Opendiv.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        function OpenAdd(obj) {
            var url = "addbanner.aspx";
            Window_Open(obj, 4, url, 400, 500, "添加横幅");
        }
        function OpenEdit(obj, id) {
            var url = "editbanner.aspx?banner_id=" + id;
            Window_Open(obj, 4, url, 400, 500,"修改横幅");
        }
    </script>
    <style type="text/css">
    .mright{margin:0 auto;width:500px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="float:right;margin-right:30px;"><a href="#" onclick="OpenAdd(this)">[添加]</a></div>
   <table width="100%" align="center"    cellspacing="0" >
			<thead>
				<tr>
					<td width="30%">图片</td>
					<td width="20%">标题</td>
					<td width="10%">排序</td>
                    <td width="20%">修改日期</td>
					<td width="30%" class="last">操作</td>
				</tr>
			</thead>
			<tbody>
				 <asp:HiddenField ID="hidSort" Value="Email"  runat="server" />
                 <asp:HiddenField ID="hidOrder" Value="DESC" runat="server" />
                 <asp:HiddenField ID="hidCheck" Value="false" runat="server" />
				<asp:Repeater ID="rptBanner" runat="server" onitemcommand="rptBanner_ItemCommand">
                    <ItemTemplate>
                        <tr class="tr1">
					    <td><img src='<%#Eval("imgurl")%>' width="120" height="60" /></td>
					    <td><%#Eval("title") %></td>
					    <td><%#Eval("sortId") %></td>
					    <td><%#Eval("pubdate","{0:yyyy-MM-dd}")%></td>
					    <td></a>
                            [<asp:LinkButton ID="LinkButton1" runat="server" CommandName="delete" OnClientClick='javascript:return confirm("确定要删除吗？");'>删除</asp:LinkButton>]
                            <a href="#" onclick="OpenEdit(this,'<%#Eval("banner_id") %>')">[修改]</a>
                            </td>
                        <asp:HiddenField ID="hidid" runat="server" Value='<%#Eval("banner_id") %>' />
				</tr>
                    </ItemTemplate>
                </asp:Repeater>
			</tbody>
		</table>
       <div class="clearboth">
        <div class="mright">
            <div class="cart-page">
                <webdiyer:AspNetPager ID="Pager" runat="server" FirstPageText="首页" LastPageText="尾页"
                    NextPageText="下一页" AlwaysShow="True" PrevPageText="上一页" NextPrevButtonClass="incoleft"
                    CurrentPageButtonClass="rednum" PagingButtonClass="numbs" SubmitButtonText="转到"
                    SubmitButtonClass="enterpage" PageIndexBoxClass="pagebox" FirstLastButtonClass="firstlastbutton"
                    OnPageChanged="Pager_PageChanged">
                </webdiyer:AspNetPager>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
