<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Permission.aspx.cs" Inherits="CdHotelManage.Web.Admin.Permissions.Permission.Permission" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>分配权限</title>
    <link href="/style/css.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery.js" type="text/javascript"></script>
     <script src="/js/DivWH.js" type="text/javascript"></script>
    <link href="/style/Opendiv.css" rel="stylesheet" type="text/css" />
    <script src="../../js/base.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function OpenDiv(obj, opera, id, title,update) {
            var url = "../Role/Role.aspx?opera=" + opera + "&roleid=" + id;
            showMyWindow(title, url, 400, 350, true, true, true);
        }
        function update() {
            window.location.reload();
         }
    </script>
    <style type="text/css">
        .li1{background-color:#66a0cc;}
        .li1 span a{color:#fff}
        .qxList li span a{float:left;}
        .qxList li:hover a{color:#fff;}
    </style>

    <script type="text/javascript">
        $(function () {
            $("#ulrole li:eq(0)").addClass("li1");
        })

        function showli(id) {
//            for (var i = 1; i < $("#ulrole li").length; i++) {
//                $("#li" + i).removeClass("li1");
//            }   
            $("#li" + id).addClass("li1");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
	<asp:HiddenField ID="hidliid" runat="server" />
<div class="conTree">
		  	  
	<div class="rightTable">
	<div style="height:50px;line-height:50px; text-align:left;">
	   <span class="qxTitle">　权限管理</span>
	   <span>　说明:更改权限后需要重新登录</span>
	</div>	
		
		<div class="qxgl">
		<ul class="qxList" id="ulrole">
           <asp:Repeater ID="rptRole" runat="server" onitemcommand="rptRole_ItemCommand">
                <ItemTemplate>
                    <li id='li<%#Eval("RoleID") %>'>
                    <span>
                    <asp:LinkButton ID="lbtn" runat="server" CommandArgument='<%#Eval("RoleID") %>'><%#Eval("title")%></asp:LinkButton></span>
                     <a href="javascript:void(0);" onclick="OpenDiv(this,'edit','<%#Eval("RoleID") %>','编辑角色')"><img src="/images/bj_icon.png" width="14" height="16" /></a>
                     <a>
                       <asp:ImageButton runat="server" ID="Del" ImageUrl="/images/scicon.png" Width="16" Height="15"  CommandName="delete" CommandArgument='<%#Eval("RoleID") %>' OnClientClick='javascript:return confirm("确定要删除吗？");' />
                        </a>
                    </li>
		            <div class="bottom_line"></div>
                    <asp:HiddenField ID="hidid" runat="server" Value='<%#Eval("RoleID") %>' />
                </ItemTemplate>
            </asp:Repeater>
		   
		   <li style="border:none;background:none;">
           <input type="button" value="   添加角色   "  class="button_green" onclick = "OpenDiv(this,'add','0','添加角色')" /></li>
		</ul>
		
		<div class="qxShow">
            <ul class="qxul" >
            <asp:Repeater runat="server" ID="rptMenu" onitemdatabound="rptMenuRole_ItemDataBound">
                 <ItemTemplate>
                    <li>
                        <span><%#Eval("title")%></span>
                        <asp:HiddenField ID="hidid" runat="server" Value='<%#Eval("menu_id") %>'/>
                        <p>  
                            <asp:Repeater runat="server" ID="rptMenuRole">
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbMenu" runat="server" />
                                    <asp:HiddenField ID="hidchildid" runat="server" Value='<%#Eval("menu_id") %>'/>
                                    <%#Eval("title")%>
                                </ItemTemplate>
                            </asp:Repeater>
                        </p>
                    </li>
                 </ItemTemplate>
            </asp:Repeater>
            </ul>
            <div style="text-align:center;">
                <asp:Button runat="server" Text="   保存   " ID="btnSave" CssClass="greenBtn midBtn" onclick="btnSave_Click" /></div>
        </div>
	  </div>
		
		
	</div>
</div>

    </form>
</body>
</html>