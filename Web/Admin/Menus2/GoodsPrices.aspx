<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsPrices.aspx.cs" Inherits="CdHotelManage.Web.Admin.Menus2.GoodsPrices" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <link href="../../style/css.css" rel="stylesheet" type="text/css" />
    <script src="../../calendar/WdatePicker.js" type="text/javascript"></script>
    <script src="../../js/DivWH.js" type="text/javascript"></script>
    <link href="../../style/Opendiv.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/base.js"></script>
    <script type="text/javascript">
        $(function () {
            var total = 0;
            var leng = 0;
            var c = 0;
            $("#tbList tbody tr").each(function () {
                c += parseInt($(this).find("td").eq(2).text());
                total += parseInt($(this).find("td").eq(3).text());
            })
            $(".pageTotalNumber").text(c);
            $(".pageTotalAmount").text(total);

            $(".totalNumber").text(c);
            $(".totalAmount").text(total);
        })
        function RZ(obj) {
            var url = "AddGoods.aspx";
            showMyWindow("非住客帐", url, 800, 455, true, true, true, Close);
        }
        function XqClick(obj,id) {
            var url = "AddGoods.aspx?type=edit&occid=" + id;
            showMyWindow("账单详情", url, 800, 455, true, true, true, Close);
        }
        function Close() {

        }
        function CheXiao(obj,id) {
            if (confirm("确定撤销？")) {
                $.get("/admin/ajax/Books.ashx", "type=delga&id=" + id, function (obj1) {
                    if (obj1 == "ok") {
                        alert("撤销成功");
                        $(obj).parent().parent().remove();
                    }
                    else if (obj1 == "err") {
                        alert("此帐已经交班，或者已夜审,不能撤销!!");
                    }
                }, "text")
            }
        }
    </script>
    <style type="text/css">
      .main{ width: 98%;margin-left: 1%;}
      .ftt_search {
  width: 100%;
  float: left;
  margin: 10px 0px;
  font-size: 12px;
  color: #333;
}
.fontYaHei {
  font-family: "Hiragino Sans GB","Microsoft YaHei",黑体,宋体,sans-serif;
}
.ftt_search label {
  float: left;
  line-height: 24px;
  padding-right: 5px;
}
.ftt_search input, .ftt_search select {
  border: #ddd 1px solid;
  padding-left: 5px;
  margin-right: 25px;
  padding-right: 0px;
  font-size: 12px;
  font-family: "Hiragino Sans GB","Microsoft YaHei",黑体,宋体,sans-serif;
  color: #000;
  float: left;
}
.ftt_search input {
  width: 240px;
  height: 22px;
  line-height: 22px;
}
.qtantj {
  background: url(../images/search_top.jpg) no-repeat;
  border: 0px !important;
  font-size: 12px;
  font-weight: bold;
  color: #FFF !important;
  cursor: pointer;
  width: 60px !important;
  height: 25px !important;
  float: left;
  margin-right: 0px !important;
  padding-left: 0px !important;
}
table {
  width: 100%;
  border-top: 0px #ddd solid;
  border-left: 1px #ddd solid;
  float: left;
    border-bottom: 1px #ddd solid;
}
table th {
  font-size: 14px;
  border-bottom: 1px #fff solid;
  border-right: 1px #ddd solid;
  height: 32px;
  color: #FFF;
}
table td{
  font-size: 14px;
  border-bottom: 1px #ddd solid;
  border-right: 1px #ddd solid;
  height: 32px;
  color: #333; font-size:12px; text-align:center;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
       <div class="main">
         <div class="ftt_search fontYaHei">
            <label>时间：</label><input type="text" id="StartDate" runat="server" onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss',onpicked:function() {AddDay()}})" style="width: 120px">
            <label style="padding-right: 10px; margin-left: -10px">至</label><input type="text" id="EndDate" runat="server" onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss',onpicked:function() {AddDay()}})" style="width: 120px">
            <label>单号：</label><input type="text" id="OrderNo" runat="server" style="width: 80px">
            <input type="button" class="qtantj" id="btnSearch" runat="server" onserverclick="btnSearch_Click" value="查询">
        </div>
        <table cellpadding="0" cellspacing="0" class="ruzhu" id="tbList">
            <thead>
                <tr>
                    <th width="140">时间</th>
                    <th width="140">单号</th>
                    <th width="80">消费数量</th>
                    <th width="140">消费金额</th>
                    <th width="140">支付方式</th>
                    <th width="100">操作员</th>
                    <th width="">备注</th>
                    <th width="">操作</th>
                </tr>
            </thead>
            <tbody>
            <asp:Repeater ID="rep1" runat="server">
              <ItemTemplate>
                <tr data-temp="0">
                <td><%#Eval("ga_date")%></td>
                <td><%#Eval("ga_number")%></td>
                <td><%#Eval("ga_num")%></td>
                <td><%#Eval("ga_price")%></td>
                <td><%#GetRealTypeName(Eval("ga_zffs_id"))%></td>
                <td><%#GetRealTypeName1(Eval("ga_people"))%></td>
                <td><%#Eval("ga_remker")%></td>
                <td><img src="../Images/037.gif" /><a href="#" style=" color:#0788BD" onclick="XqClick(this,<%#Eval("id")%>)">明细</a> <img src="../Images/cs1.png" /><a style=" color:#0788BD" href="#" onclick="CheXiao(this,<%#Eval("id")%>)" >撤销</a></td>
                </tr>
              </ItemTemplate>
            </asp:Repeater>
            </tbody>
            <tfoot>
                <tr style="color: #0789BE">
                    <td style="text-align: right" colspan="2">当页合计：</td>
                    <td class="pageTotalNumber">9</td>
                    <td style="text-align: right" class="pageTotalAmount">56.00</td>
                    <td style="text-align: right" colspan="4">消费总量：<span class="totalNumber">9</span> 件 &nbsp;&nbsp;&nbsp;&nbsp;消费总额：<span class="totalAmount">56.00</span> 元</td>
                </tr>
            </tfoot>
        </table>
        <webdiyer:AspNetPager ID="Pager" runat="server" FirstPageText="首页" LastPageText="尾页"
                    NextPageText="下一页" AlwaysShow="True" PrevPageText="上一页" NextPrevButtonClass="incoleft"
                    CurrentPageButtonClass="rednum" PagingButtonClass="numbs" SubmitButtonText="转到"
                    SubmitButtonClass="enterpage" PageIndexBoxClass="pagebox" FirstLastButtonClass="firstlastbutton"
                    OnPageChanged="Pager_PageChanged">
                </webdiyer:AspNetPager>
        <input name="button03" type="button" id="button03" class="orangeBtn midBtn" value="录入消费" onclick="RZ(this)">
       </div>
    </form>
</body>
</html>
