<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Setup.aspx.cs" Inherits="CdHotelManage.Web.Admin.Menus.Setup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../js/jscolor.js" type="text/javascript"></script>
    <script src="../../js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function Ucolor() {

            $(".ftcolor input").each(function () {
                var id = $(this).attr("ids");
                var color = $(this).val();
                $.get("/admin/ajax/Books.ashx", "type=ucolor&id=" + id + "&color=" + color, function (obj) {

                }, "text");
            })
            alert("保存成功，请手动刷新房态图！");
        }
    </script>
    <style type="text/css">
        body{ font-size:13px;}
      .w60{ width:60px;}
      .w30{ width:30px;}
      .w100{ width:100px;}
      table td{ width:20%;}
      table{ width:100%;}
      .table1{ width:38%; float:left; margin-left:1%;}
      .table2{ width:33%; float:left;}
      .table2 td{ width:30%;}
      .table1 td{ width:50%;}
      .titespan{ width:120px; display:block; float:left;}
      .ftcolor{ float:left;}
      .ftcolor input{ margin-bottom:5px;}
      .table1 .td1{ width:40%}
      .table1 .td2{ width:60%}
      .w20{ width:20px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    
    <div class="ftcolor">
      <%=sb.ToString() %>
    </div>
    <div class="sizecolor">
    <table class="table1">
    <tr>
      <td class="td1">房号字体大小<input type="text" runat="server" class="w20" id="numSize" /> px</td>
      <td class="td2">房 号 颜 色 <input type="text" class="color" style=" width:80px;" runat="server" id="numColor"/></td>
    </tr>
    <tr>
      <td class="td1">房型字体大小<input type="text" runat="server" class="w20" id="fxSize" /> px</td>
      <td class="td2">房 型 颜 色 <input type="text" class="color" style=" width:80px;" runat="server" id="fxColor"/></td>
    </tr>
    <tr>
      <td class="td1">余额字体大小<input type="text" runat="server" class="w20" id="yueSize" /> px</td>
      <td class="td2">余 额 颜 色 <input type="text" class="color"  style=" width:80px;" runat="server" id="yueColor"/></td>
    </tr>
    <tr>
     <td class="td1">姓名字体大小<input type="text" runat="server" class="w20" id="nameSize" /> px</td>
     <td class="td2">姓 名 颜 色 <input type="text" class="color"  style=" width:80px;" runat="server" id="nameColor"/></td>
    </tr>
     <tr>
      <td class="td1">房  价 大 小 <input type="text" runat="server" class="w20" id="priceSize" /> px</td>
      <td class="td2">房 价 颜 色 <input type="text" class="color"  style=" width:80px;" runat="server" id="priceColor"/></td>
     </tr>
     <tr>
      <td class="td1">来店时间大小<input type="text" runat="server" class="w20" id="TotimeSize" /> px</td>
      <td class="td2">来店时间颜色<input type="text" class="color"  style=" width:80px;" runat="server" id="TotimeColor"/></td>
     </tr>
     <tr>
      <td class="td1">钟点时间大小<input type="text" runat="server" class="w20" id="zdSize" /> px</td>
      <td class="td2">钟点时间颜色<input type="text" class="color"  style=" width:80px;" runat="server" id="zdColor"/></td>
     </tr>
     </table>
     <table class="table2">
      <tr>
       <td>图标宽度 <input type="text" class="w30" runat="server" id="Lwidth"/> px</td>
       <td>图标高度 <input type="text" class="w30" runat="server" id="Lhieght"/> px</td>
       
      </tr>
      <tr>
      <td>字&nbsp;&nbsp;&nbsp;&nbsp;体 <select id="Lfontf" style="width:80px;" runat="server"><option>宋体</option><option>微软雅黑</option></select></td>
       <td>字&nbsp;&nbsp;&nbsp;&nbsp;号 <input type="text" class="w30" runat="server" id="Fontsize"/> px</td>
      </tr>
      <tr>
        <td>图标间距 <input type="text" class="w30" runat="server" id="Lmargin"/> px</td>
       <td>图标大小 <input type="text" id="icoColor" class="w30" runat="server" /> px</td>
      </tr>
      <tr>
       <td>房态图区域背景颜色 <input type="text" class="color" runat="server" id="Backcolor" style=" width:60px;"/></td>
       <td>边框背景颜色 <input type="text" class="color" runat="server" id="Bordercolor"  style=" width:60px;"/></td>
      </tr>
      <tr>
       <td>每行图标数 <input type="text" id="ftNum" class="w30" runat="server"/></td>
       <td></td>
      </tr>
     </table>
    </div>
    <table>
     <tr>
      <td><input type="checkbox" id="showType" runat="server"/>空房显示房间类型</td>
      <td><input type="checkbox" id="showPrice" runat="server"/>空房显示房间价格</td>
      <td><input type="checkbox" id="orderLC" runat="server"/>按层楼排序</td>
      <td><input type="checkbox" id="zzShowType" runat="server"/>住客房显示房间类型</td>
      <td><input type="checkbox" id="zzShowPrice" runat="server"/>在住房间显示价格</td>
     </tr>
     <tr>
      <td><input type="checkbox" id="showFormTime" runat="server"/>显示到店时间</td>
      <td><input type="checkbox" id="showLFico" runat="server"/>显示连房图标<br /></td>
      <td><input type="checkbox" id="showBmico" runat="server"/>显示保密图标</td>
      <td><input type="checkbox" id="showXy" runat="server"/>显示协议单位名称</td>
      <td></td>
     </tr>
     <tr>
       <td><input type="checkbox" id="showyjb" runat="server"/>是否显示押金不足图标</td>
       <td colspan="2"><input type="radio" id="showday" name="asb" runat="server"/>当押金不足<input type="text" id="daynum" class="w30" runat="server"/>几天房费显示</td>
       <td colspan="2"><input type="radio" id="showyue" name="asb"  runat="server"/>当余额不足<input type="text" id="moneyNum" class="w30" runat="server"/>元时显示</td>
     </tr>
     <tr>
       <td><input type="checkbox" id="showcf" runat="server"/>是否显示欠费图标</td>
       <td colspan="2"><input type="checkbox" id="showThem" runat="server"/>是否显示团队图标 <input type="text" id="Themtext" class="w60" runat="server"/>团队文字</td>
       <td colspan="2"><input type="checkbox" id="showMember" runat="server"/>是否显示会员图标<input type="text" id="memberText" class="w60" runat="server"/>会员文字</td>
     </tr>
     <tr>
       <td><input type="checkbox" id="showYuli" runat="server"/>显示预离图标 </td>
       <td colspan="2"><input type="radio" name="bsa" id="yuliDay" runat="server"/>只显示当日预离</td>
       <td colspan="2"><input type="radio" name="bsa" id="showDayTime" runat="server"/>是否显示多少<input type="text" id="dayNumYl"   class="w60" runat="server"/>天内预离的</td>
     </tr>
     <tr>
      <td><input type="checkbox" id="Showxz" runat="server"/>显示续住图标</td>
      <td><input type="checkbox" id="showSf" runat="server"/>显示锁房图标</td>
      <td><input type="checkbox" id="showYuee" runat="server"/>是否显示余额</td>
      <td><input type="checkbox" id="Showzdftime" runat="server"/>是否显示钟点房时间</td>
      <td><input type="checkbox" id="Showbooktime" runat="server"/>是否显示预定房到店时间</td>
     </tr>
     <tr>
      <td><input type="checkbox" id="Showzf" runat="server"/>是否显示脏住房图标</td>
      <td><input type="checkbox" id="Showlc" runat="server"/>是否显示凌晨房间图标</td>
      <td><input type="checkbox" id="showPeoNum" runat="server"/>是否显示人数图标</td>
      <td><input type="checkbox" id="showRk" runat="server"/>是否显示房卡数量</td>
      <td><input type="checkbox" id="showWupi" runat="server"/>是否显示物品租借图标</td>
     </tr>
     <tr>
       <td><input type="checkbox" id="Showyz" runat="server"/>是否显示月租房图标</td>
       <td><input type="checkbox" id="Showmf" runat="server"/>是否显示免费房图标</td>
       <td><input type="checkbox" id="Showzdf" runat="server"/>是否显示钟点房图标</td>
       <td></td>
       <td></td>
     </tr>
    </table>
    <div style=" clear:both;"></div>
    <input type="button" value="保存" runat="server" onclick="Ucolor();" onserverclick="btnOk_Click" />
    </div>
    </form>
</body>
</html>
