<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToRoom.aspx.cs" Inherits="CdHotelManage.Web.Admin.Toroom.ToRoom" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../js/DivWH.js" type="text/javascript"></script>
    <link href="../../style/css.css" type="text/css" rel="Stylesheet" />
    <link href="../../style/Opendiv.css" rel="stylesheet" type="text/css" />
    <link href="../css/tooms.css" rel="stylesheet" type="text/css" />
    <script src="../js/toomJs.js" type="text/javascript"></script>
    <link href="../../style/toom.css" rel="stylesheet" type="text/css" />
    <script src="../js/base.js" type="text/javascript"></script>
    <link href="../../easyui/themes/gray/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../easyui/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="../../easyui/jquery.easyui.min.js" type="text/javascript"></script>
</head>
<body onload="clo();" onselect='document.selection.empty()'   style=" overflow:hidden">
    <form id="form1" runat="server">
    <div class="dd"></div>  
    <!--菜单部分-->
    <%--<div class="menu" id="menu">
    </div>--%>
    <div id="menu" class="easyui-menu" style="width:120px;">
      
    </div>
    <div class="f_l_left">
        <div class="lcfxft">
            <div class="lffSelect">
                楼层：<asp:DropDownList ID="DDlouc" DataTextField="floor_name" DataValueField="floor_id"
                    AutoPostBack="true" runat="server" OnSelectedIndexChanged="DDlouc_SelectedIndexChanged">
                </asp:DropDownList>
                房型：<asp:DropDownList ID="ddroomtype" DataTextField="room_name" DataValueField="id"
                    AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddroomtype_SelectedIndexChanged">
                </asp:DropDownList>
                房态：<asp:DropDownList ID="ddlState" DataTextField="room_state_name" DataValueField="room_state_id"
                    AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div class="cxKBtn">
                <input id="sstext" type="text" name="textfield" runat="server" />
                <asp:Button ID="czbutton" runat="server" Text="查找" OnClick="czbutton_Click" /></div>
                <ul id="ulss" class=" zhuangtai">
          
            <asp:Repeater ID="Repeaterft" runat="server">
                <ItemTemplate>
                
                    <li ids="<%# Eval("room_state_id") %>" onclick="btnserch(this,<%# Eval("room_state_id") %>)"><span class="<%# GetClassDiv(Convert.ToInt32( Eval("room_state_id"))) %>">
                        <%# Eval("room_state_name")%></span><span class="ztspan02"><%# Eval("remark")%></span><span></span>间</li>
                </ItemTemplate>
            </asp:Repeater>
            <li onclick="btnserch(this,'999')"><span class="alltext ztspan01">全部</span><span class="ztspan02"><%=allroom %></span><span></span>间</li>
        </ul>
        </div>
    </div>
    <div class="ycan">
    <%=sbtext1.ToString() %>
    <div id="DivContent" class="content" style="overflow: auto;" runat="server">
    </div>
    </div>
    <div>
        <ul class="ulright">
           <li class="libgicon13"><a href="#">免房</a><a href="#" class="ahidden">免房</a><span id="span2" runat="server"><%=mfcount%></span>间</li>
           <li class="libgicon12"><a href="#">催帐</a><a href="#" class="ahidden">催帐</a><span id="span1" runat="server"><%=czCount%></span>间</li>
           <li class="libgicon05"><a href="#">联房</a><a href="#" class="ahidden">联房</a><span id="spanlf" runat="server"><%=LFcount %></span>间</li>
           <li class="libgicon04"><a href="#">钟点房</a><a href="#" class="ahidden">钟点房</a><span id="spanzdf" runat="server"><%=zdfang %></span>间</li>
           <li class="libgicon03"><a href="#">凌晨房</a><a href="#" class="ahidden">凌晨房</a><span id="spanlingc" runat="server"><%=lingcfang %></span>间</li>
           <li class="libgicon09"><a href="#">月租房</a><a href="#" class="ahidden">月租房</a><span id="spanyzf" runat="server"><%=yzf %></span>间</li>
           <li class="libgicon10"><a href="#">锁房</a><a href="#" class="ahidden">锁房</a><span id="spansuofang" runat="server"><%=suofang %></span>间</li>
           <li class="libgicon08"><a href="#">欠费</a><a href="#" class="ahidden">欠费</a><span id="spanqianf" runat="server"><%=qianfei %></span>间</li>
           <li class="libgicon11"><a href="#">续住</a><a href="#" class="ahidden">续住</a><span id="spanxuzhu" runat="server"><%=xuzhufang %></span>间</li>
           <li class="libgicon02" style=" padding:0; width:70px; text-align:right;"><div style="width:10px; height:12px; background-color:green; float:left; margin-top:7px;"></div><a href="#">将走房</a><a href="#" class="ahidden">将走房</a><span id="spanjiangz" runat="server"><%=jzhouf %></span>间</li>
        </ul>
    </div>
    <!--左击弹出框开始-->
    <div class="divFv" id="divFv" runat="server">
    <span class="close"></span>
        <div>
            <ul class="ul2">
                <li>
                   联房房号:<span class="lfkf" style="color:#0D94CC">101,102,103</span>
                </li>
                <li>姓名：<asp:Label ID="labName" runat="server" Text="测试数据"></asp:Label>
                    性别：<span class="sex">男</span> <span class="roomnums" style="color: Red;">109</span>
                    /<span class="types" style="color: Green;">标准双人间</span>开房方式:<span class="tjs" style=" color:Green">天方</span></li>
                <li>到离时间：<span id="staytime" runat="server">2015-10-1</span>至<span
                    id="endtime" runat="server">2015-10-2</span> </li>
                <li>证件类型：<span id="cardid" runat="server">身份证</span>&nbsp;&nbsp;<span class="hidmember" style="display:none;">会员卡号：<span class="spanSpn"></span></span><span class="spanSpn1" style=" display:block"></span><span class="hidXie" style="display:none;">协议单位：<span class="spanXie"></span></span></li>
                <li>证件号码：<span id="cardidNumber" runat="server">362425199632121</span></li>
                <li>原价：<span id="YuJia"></span> &nbsp;&nbsp;折后价：<span id="zhj"></span></li>
                <li>地址：<span id="txt_address" runat="server"></span></li>
                <li>
                    <ul class="ul3">
                        <li>
                            <div id="divxF" runat="server" style="width: 45px; vertical-align: middle; text-align: center;
                                color: White;height: 45px; line-height:45px; background: #0788BE;">
                                <span class="xiaof"></span>
                            </div>
                            消费</li>
                        <li>
                            <div id="divYsq" runat="server" style="width: 45px; vertical-align: middle; text-align: center;
                                color: White;height: 45px; line-height:45px; background: #eca629;">
                                <span class="xyysk"></span>
                            </div>
                            预授权</li>
                        <li>
                            <div id="divSk" runat="server" style="width: 45px; vertical-align: middle; text-align: center;
                                color: White;height: 45px; line-height:45px; background: Green;">
                                <span class="shouk"></span>
                            </div>
                            收款</li>
                        <li>
                            <div id="divye" runat="server" style="width: 45px; vertical-align: middle; text-align: center;
                                color: White;height: 45px; line-height:45px; background: red;">
                                <span class="yue"></span>
                            </div>
                            余额</li>
                    </ul>
                </li>
                <li>随客：<span id="spansk" runat="server"></span></li>
                <li>备注：<span id="txt_remaker" runat="server"></span></li>
                
            </ul>
        </div>
    </div>
    <!--左JI弹出框结束-->
    <asp:Button ID="btnsercher" runat="server" Text="查询" Style="display: none;" OnClick="btnsercher_Click" />
    <input type="hidden" id="txt_ids" runat="server" />
    <input type="hidden" id="hidxq" runat="server" />
    <asp:Button ID="Button1" Style="display: none;" runat="server" Text="Button" OnClick="Button1_Click" />
    <asp:Button ID="btncx" runat="server" Text="撤销入单" OnClick="btncx_Click" Style="display: none;" />
    <asp:HiddenField ID="hidNumber" runat="server" />
    <asp:HiddenField ID="hidRoom" runat="server" />
    <input type="hidden" id="txt_Namesp" runat="server" />
    <asp:Button ID="btnGetzhi" runat="server" Style="display: none;" Text="显示值" OnClick="btnGetzhi_Click" />
    </form>
</body>
</html>
