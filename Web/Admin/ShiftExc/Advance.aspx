<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Advance.aspx.cs" Inherits="CdHotelManage.Web.Admin.ShiftExc.Advance" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../style/css.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../js/printy.js" type="text/javascript"></script>
    <link href="../../style/Sheet.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            var sum = 0;
            $(".numbe").each(function () {
                sum += parseInt($(this).text());
            })
            $(".hesum").text(sum);

            $(".imgclose").click(function () {
                parent.parent.location.reload();
            })
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input width="300px" type="button" value="打印预览" id="btnPrint" onclick="printWork('advance')">
    <div id="advance">
       <h3><%=Modelsi.shop_Name %>预定单</h3>
       <p><span class="sblock sleft">单据号码:</span><span class="sorder"><%=nowModel.book_no%></span></p>
       <p><span class="sblock sleft">姓名:<%=nowModel.book_Name %> </span>客户类型：散客</p>
       <p>会员卡:<%=nowModel.mem_cardno %></p>
       <p>协议单位:</p>
       <p><span class="sblock sleft">预定人:<%=nowModel.book_Name %></span> 联系人<%=nowModel.tele_no %></p>
       <p>预抵时间:<%=nowModel.time_to %></p>
       <p>预离时间:<%=nowModel.time_from %></p>
       <p>付款方式:<%=GetSourceTypeName(nowModel.meth_pay_id)%> 预定金:<%=nowModel.deposit %></p>
       <table>
        <tr>
         <th>房间类型</th>
         <th>数量</th>
         <th>序号</th>
         <th>标准房价</th>
         <th>实际价格</th>
        </tr>
        <%=sbtext.ToString()%>
        <tr class="hj">
         <td colspan="3">合计数量: </td>
         <td colspan="2"><span class="hesum"></span></td>
        </tr>
       </table>
       <p>友情提示:<%=ListPrint.Where(d => d.id == 3).First().priContent %></p>
       <p>备注:</p>
       <p>操作员：</p>
       <p>客户签字:</p>
    </div>
    </form>
</body>
</html>
