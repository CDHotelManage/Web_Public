<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PartHouse.aspx.cs" Inherits="CdHotelManage.Web.Admin.PartHouse" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../calendar/WdatePicker.js" type="text/javascript"></script>
    <script src="../js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="../js/DivWH.js" type="text/javascript"></script>
    <link href="../style/Opendiv.css" rel="stylesheet" type="text/css" />
    <script src="js/base.js" type="text/javascript"></script>
    <style type="text/css">
        .h1s
        {
            margin-top: 20px;
            margin-bottom: 10px;
            font-size: 20px;
            color: #4486b7;
            font-weight: 100;
        }
        .yui
        {
            border-collapse: collapse;
            border: 1px solid #ececec;
        }
        .yui td
        {
            border: 1px solid #ececec;
        }
        .btn
        {
            cursor: pointer;
            padding: 1px 5px;
            font-size: 12px;
            color: #fff;
            line-height: 24px;
            text-align: center;
            background-color: #1492e3;
            border: none;
            outline: none;
            margin: 2px 1px;
        }
        #tables{ font-size:12px;}
        #tables td{ font-size:12px;}
        .div1
        {
            margin-top: 50px;
        }
        .red
        {
            color: Red;
            font-weight: bold;
        }
        .w70
        {
            width: 70px;
        }
        .w30
        {
            width: 30px;
        }
    </style>
    <script type="text/javascript">
        $(function () {

        })
        function clo() {
            var bodyHeight = document.documentElement.clientHeight;
            var bodyWidth = document.documentElement.clientWidth;
            var div = document.getElementById("DivGV");

            if (div != null) {

                $(div).height(bodyHeight - 56);
            }
        }
        function defut(obj, ids) {
            var url = "DespAdd.aspx?id=" + ids + "&type=xg";
            showMyWindow("方案修改", url, 300, 430, true, true, true, update);
        }
        function dispAdd(obj) {
            var url = "DespAdd.aspx?type=add";
            showMyWindow("添加方案", url, 500, 430, true, true, true, update);
        }
        function update() {
            window.location.reload();
        }
        function Copy(obj, ids) {
            var nowtr = $(obj).parent().parent();
            var htmlstr = nowtr.html();
            $.get("/Admin/Ajax/GoodsAcce.ashx?r=" + Math.random(), "type=addFus&id=" + ids, function (objs) {
                if (objs.statu == "ok") {
                    var s = "<tr><td align=\"center\" style=\"width:150px;\">标准双人间</td><td align=\"center\" style=\"width:150px;\">" + objs.data.hs_name + "</td><td align=\"center\">" + objs.data.hs_start_long + "</td><td align=\"center\">" + objs.data.hs_start_price + "</td><td align=\"center\">" + objs.data.hs_add_time + "</td><td align=\"center\">" + objs.data.hs_add_price + "</td><td align=\"center\">" + objs.data.hs_min_time + "</td><td align=\"center\">" + objs.data.hs_min_price + "</td><td align=\"center\">" + objs.data.hs_max_time + "</td><td align=\"center\">" + objs.data.MtID + "</td><td align=\"center\"><input type=\"button\" value=\"修改\" onclick=\"defut(this," + objs.data.id + ")\">  <a href=\"?type=del&id=" + objs.data.id + "\">删除</a>  <input type=\"button\" value=\"复制\" onclick=\"Copy(this," + objs.data.id + ")\"></td></tr>";
                    nowtr.after("<tr>" + s + "</tr>");
                }
                else { }
            }, "json");
        }
    </script>
</head>
<body onload="clo()" style=" width:95%; margin:0 auto; ">
<div id="DivGV">
    <form id="form1" runat="server" style="font-size:12px;">
    <h1 class="h1s">
    钟点房信息设置
    </h1>
    钟点房开始时间<input type="text" class="inputTime w70" id="begintime" runat="server" onClick="WdatePicker({dateFmt:'H:mm:ss',minDate:'0:00:00',maxDate:'24:00:00'})"/>到<input type="text" class="inputTime w70" id="endtime" runat="server" onClick="WdatePicker({dateFmt:'H:mm:ss',minDate:'0:00:00',maxDate:'24:00:00'})"/><br />
    <%--钟点房最晚停留时间<input type="text" class="inputTime" id="latest" runat="server" onClick="WdatePicker({dateFmt:'H:mm:ss',minDate:'0:00:00',maxDate:'24:00:00'})"/><br />--%>
    钟点房计费缓冲时间为<input type="text" class="w30" id="buffer" runat="server" />
    钟点房提前<input type="text" id="tixing" class="w30" runat="server" />分钟通知
    <input type="button"  runat="server" onserverclick="Btn_Ok_Click" value="确定"/>
    <div class="div1">
    钟点房房价方案参数设置<span class="red">注：所有时间单位都为分钟！</span><input type="button" value="添加方案" class="btn" onclick="dispAdd(this);">
    </div>
    <table width="100%" border="0" cellpadding="0" cellspacing="1" style="margin-bottom: 1px; font-size:12px;" class="yui">
						<tbody><tr class="commBg">
							<td align="center" height="23" style="width:50px;">房型</td>
							<td align="center">方案名称</td>
						  	<td align="center">起步时间</td>
							<td align="center">起步价格</td>
							<td align="center">加钟时长</td>
							<td align="center">加钟价格</td>
							<td align="center">最小时长</td>
							<td align="center">最小价格</td>
                            <td align="center">超时转全天</td>
                            <td align="center">类型</td>
							<td align="center">操作</td>
						</tr>
                        <asp:Repeater ID="rp1" runat="server">
                        <ItemTemplate>
						<tr>
                        <td align="center" style="width:150px;">
										<%#GetName(Convert.ToInt32(Eval("hs_type_id")))%>
									</td>
									<td align="center" style="width:150px;">
										<%#Eval("Hs_name") %>
									</td>
									<td align="center">
										<%#Eval("Hs_start_long")%>
									</td>
									<td align="center">
										<%# Convert.ToDecimal(Eval("Hs_start_price")).ToString("0.##")%>
									</td>
									<td align="center">
										<%#Eval("Hs_add_time")%>
									</td>
									<td align="center">
										<%#Convert.ToDecimal(Eval("Hs_add_price")).ToString("0.##")%>
									</td>
									<td align="center">
										<%#Eval("Hs_min_time")%>
									</td>
									<td align="center">
										<%# Convert.ToDecimal(Eval("Hs_min_price")).ToString("0.##")%>
									</td>
									<td align="center">
										<%#Eval("Hs_max_time")%>
									</td>
                                    <td align="center">
										<%#Eval("MtID")%>
									</td>
									<td align="center">
										<input type="button" value="修改" onclick="defut(this,<%#Eval("id") %>)">&nbsp;
										<a href="?type=del&id=<%#Eval("id")%>">删除</a>
                                        <input type="button" value="复制" onclick="Copy(this,<%#Eval("id") %>)" />
									</td>
								</tr>
                                </ItemTemplate>
                                </asp:Repeater>
                     </tbody>
                </table>
    </form>
    </div>
</body>
</html>
