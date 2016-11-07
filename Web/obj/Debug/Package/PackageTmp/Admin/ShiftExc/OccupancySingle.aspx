<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OccupancySingle.aspx.cs" Inherits="CdHotelManage.Web.Admin.ShiftExc.OccupancySingle" %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="../../js/printy.js"></script>
    <link href="../../style/Sheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="checkOut" runat="server" >
    <input width="300px" type="button" value="打印预览" id="btnPrint" onclick="printWork('div1')">
    <div id="div1">
    <h3><%=Modelsi.shop_Name %><%=tishi %></h3>
     <p><label class="w80">姓名:<%=nowmodel.occ_name %></label><label>单号:<%=nowmodel.order_id %></label></p>
     <p><label class="w80">房号:<%=nowmodel.room_number %></label> <label>来时:<%=nowmodel.occ_time %></label> </p>
     <p><label class="w80">证件:<%=nowmodel.Card_type_model.ct_name %></label><label>离时:<%=nowmodel.depar_time %></label> </p>
     <p>号码:<%=nowmodel.phonenum %></p>
     <p>地址:<%=nowmodel.address %></p>
     <p><label class="w80">付款方式:<%=nowmodel.Meth_pay_model.meth_pay_name %></label><label><%=fangshi %>:<%= Convert.ToDouble(nowmodel.deposit) %></label> </p>
     <p><label class="w80">房型:<%=nowmodel.Room_type_model.room_name %></label><label>收银:<%=UserNow.TrueName%></label> </p>
     <p><label class="w80">会员:<%=nowmodel.mem_cardno %></label><label>协议单位:<%=GetXieYi(nowmodel.Accounts)%></label> </p>
     <table style=" width:100%; font-size:13px;">
      <tr>
        <th>房号</th>
        <th>类型</th>
        <th>标价</th>
        <th>折扣价</th>
      </tr>
     <%=sbtext.ToString() %>
     </table>
      <p>友情提示:<%=ListPrint.Where(d => d.id == 1).First().priContent %></p>
     <p>宾客签字:</p>
     <p>打印时间:<%=System.DateTime.Now.ToString() %></p>
     <p>联系电话：021-5895400</p>
    </div>
    </form>
</body>
</html>
