<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookCancel.aspx.cs" Inherits="CdHotelManage.Web.Admin.Book.BookCancel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../js/jquery-1.9.1.min.js" type="text/javascript"></script>
     <link href="../../style/css.css" rel="stylesheet" type="text/css" />
    <link href="../../style/Opendiv.css" rel="stylesheet" type="text/css" />
    <script src="../../js/DivWH.js" type="text/javascript"></script>
    <script src="/Admin/js/base.js" type="text/javascript"></script>
    <script type="text/javascript">
        function ShowTime() {
            var val = $("#txtdeposit").val();
            if (val == "") {
                alert("金额不能为空!!");
                return false;
            }
            else {
                if (!isNaN(val)) {
                    return true;
                } else {
                    alert("请输入有效金额！");
                    return false;
                }
            }
        }
        function ShowDivs(obj, id) {
            var desp = $("#txtdeposit").val();
            var url = "/Admin/ShiftExc/Advance.aspx?id=" + id + "&desp=-" + desp;
           
            showMyWindow("打印预定退款单", url, 400, 500, true, true, true, Close);
        }
        function Close() {
            ShowTabs('预定管理');
        }

        function ShowTabs(title) {
            // 关闭当前
            parent.window.location.reload(true);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <label>
        <ul class="addyd" style="width: 800px">
            <li class="qxdd"><span>姓名：</span><p>
                <asp:Label ID="lbname" runat="server" Text="Label"></asp:Label></p>
            </li>
            <li class="qxdd"><span>电话：</span><p>
                <asp:Label ID="lbtele" runat="server" Text="Label"></asp:Label></p>
            </li>
            <li class="qxdd"><span>来源：</span><p>
                <asp:Label ID="lbsource" runat="server" Text="Label"></asp:Label></p>
            </li>
            <li class="qxdd"><span>房型：</span><p>
                <asp:Label ID="lbroomtype" runat="server" Text="Label"></asp:Label></p>
            </li>
            <li class="qxdd"><span>房数：</span><asp:Label ID="lbrealnum" runat="server" Text="Label"></asp:Label><p>
            </p>
            </li>
            <li class="qxdd"><span>可退订金：</span><p>
                <asp:Label ID="lbdeposit" runat="server" Text="Label"></asp:Label></p>
            </li>
            <!--灰色部分开始-->
            <li style="width: 940px; clear: left; overflow: hidden;">
                <ul class="addyd" style="border: none; padding-left: 0; background: #f2f2f2">
                    <li><span>支付方式：</span><p>
                      <%--  <select name="select">
                            <option>银行卡</option>
                            <option>支付宝</option>
                            <option>现金</option>
                        </select>--%>
                        <asp:DropDownList ID="meth_payDdl" runat="server">
                        </asp:DropDownList>
                        </p>
                    </li>
                    <li><span>退订金：</span><input type="text" name="textfield" runat="server" id = "txtdeposit" /></li>
                    <li><span>取消原因：</span><input type="text" name="textfield" runat="server" id = "txtremark" /></li>
                </ul>
            </li>
            <li class="btnWrap">
              <%--  <input name="退订金" type="submit" value="退订金" class="button_orange" />--%>
                <asp:Button ID="Button1" runat="server" Text="退订金" class="button_orange" 
                    onclick="Button1_Click" OnClientClick="return ShowTime()"/>
             <%--   <input name="关　闭" type="submit" value="关　闭" class="button_gray" />--%>
                <asp:Button ID="Button2" runat="server" Text="关　闭" class="button_gray" 
                    onclick="Button2_Click"/>
            </li>
            <!--按纽结束-->
        </ul>
    </label>
    </form>
</body>
</html>
