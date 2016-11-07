<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdjustPrice.aspx.cs" Inherits="CdHotelManage.Web.Admin.Toroom.AdjustPrice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="../../js/jquery.js" type="text/javascript"></script>
    <script src="../../js/hDate.js" type="text/javascript"></script>
    <link href="../../style/css.css" rel="stylesheet" type="text/css" />
    <link href="../../style/hDate.css" rel="stylesheet" type="text/css" />
</head>
<body style="background:#fff">
    <form id="form1" runat="server">

    <!--唐建说先进要管-->

     <div class="sprzul">
        <ul>
            <li>房 号：<asp:Label ID="labfh" runat="server" Text="Label"></asp:Label></li>
            <li>房 型：<asp:Label ID="labfx" runat="server" Text="Label"></asp:Label></li>
            <li>开房方式：<asp:Label ID="labkffs" runat="server" Text="Label"></asp:Label></li>
            <li>来 源：<asp:Label ID="lably" runat="server" Text="Label"></asp:Label></li>
            <li>姓 名：<asp:Label ID="labname" runat="server" Text="Label"></asp:Label></li>
            <li>入住时间：<asp:Label ID="labrzDate" runat="server" Text="Label"></asp:Label></li>
            <li>房 价方案：<asp:Label ID="labfjMoney" runat="server" Text="Label"></asp:Label></li>
            <li>房价：<asp:Label ID="labSymoney" runat="server" Text="Label"></asp:Label></li>
          
        </ul>
     </div>


    
     
     
        <div class="bhsl_left002">
      

        <ul class="sprzul02" >

       
        <li>房价方案：<asp:DropDownList ID="DDLfjfa" runat="server" >
                    </asp:DropDownList></li>
         <li>来源：<asp:DropDownList
                    ID="DDlkrly" runat="server">
                </asp:DropDownList></li>
         <li>开房方式：<asp:DropDownList ID="DDlKffs" DataTextField="real_mode_name"
                    DataValueField="real_mode_id" runat="server">
                </asp:DropDownList></li>
         <li>房价：<input type="text" id="txt_roomMoney" style="width: 100px;" runat="server" /></li>
            </ul>

            <div>原因：<input type="text" name="textfield" id="txt_Remaker" style="width: 80%;"
                runat="server" />        </div>
                </div>
        

        <div class="sprz_gray" style="text-align: right;">
            <asp:Button ID="btnAdds" runat="server" Text="房价调整" class="button_orange " Style="width: 100px"
                OnClick="btnAdds_Click" />
            <input name="关　闭" type="button" value=" 关　闭 " class="button_gray " onclick="parent.Window_Close();"
                style="width: 100px;" /></div>
    </form>
</body>
</html>
