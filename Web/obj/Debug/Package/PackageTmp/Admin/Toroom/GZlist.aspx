<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GZlist.aspx.cs" Inherits="CdHotelManage.Web.Admin.Toroom.GZlist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../style/css.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <link href="../../style/css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
      .divlist{ position:relative; width:100%; height:280px;  overflow: auto;}
      .divlist table{  border: 1px solid #cdcdcd;  border-collapse: collapse; width:95%; margin:0 auto;}
      .divlist table th{ border: 1px solid #cdcdcd;}
      .divlist table td{ border: 1px solid #cdcdcd;  text-align: center;}
      .divlist table tr:hover{ background-color:Green; color:#fff;}
      .list1{ position:absolute; left:0; top:0; display:none; width:100%;}
    </style>
    <script type="text/javascript">
        $(function () {
            $(".list1").eq(0).css("display", "block");
            $("#Btn_Zz").click(function () {
                $(".list1").css("display", "none");
                $(".list1").eq(0).css("display", "block");
            })
            $("#Btn_Gz").click(function () {
                $(".list1").css("display", "none");
                $(".list1").eq(1).css("display", "block");
            })
            SJ();
            $(".cbx").click(function () {
                $(".cbx").attr("cke", "no");
                $(this).attr("cke", "yes");
            })
        })

        function Ok() {
            var readi = $(".cbx[cke='yes']");
            if (readi.length <= 0) {
                alert("请选择挂帐目标!!");
            }
            else {
                parent.document.getElementById("guazhangs").value = readi.parent().parent().attr("order");
                parent.document.getElementById("guazhang").value = readi.parent().parent().find("td").eq(2).text() + "的账户";
                parent.document.getElementById("guazhangRoom").value = readi.parent().parent().attr("ids");
                parent.Window_Close();
            }
        }

        function Clear() {
            parent.document.getElementById("guazhangs").value = "";
            parent.document.getElementById("guazhang").value = "";
            parent.document.getElementById("guazhangRoom").value = "";
            parent.Window_Close();
        }

        function SJ() {
            $(".list1 tr").dblclick(function () {
                if ($(this).attr("order") != "") {
                    parent.document.getElementById("guazhangs").value = $(this).attr("order");
                    parent.document.getElementById("guazhang").value = $(this).find("td").eq(2).text() + "的账户";
                    parent.document.getElementById("guazhangRoom").value = $(this).attr("ids");
                    parent.Window_Close();
                }

            })
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="divtabs">
      <input type="button" id="Btn_Zz" class="orangeBtn" value="在住房间" />
      <input type="button" id="Btn_Gz" class="orangeBtn" value="挂帐帐号" />
      <span  style=" color:Red;">*双击选择</span>
    </div>
    <div class="divlist">
      <div class="list1">
        <table>
          <tr order="">
           <th></th>
           <th>房间号</th>
           <th>客户姓名</th>
           <th>联系电话</th>
           <th>消费金额</th>
           <th>已收金额</th>
           <th>余额</th>
          </tr>
          <%=sbhtml1.ToString() %>
        </table>
      </div>
      <div class="list1">
        <table>
          <tr order="">
           <th></th>
           <th>房间号</th>
           <th>客户姓名</th>
           <th>联系电话</th>
           <th>消费金额</th>
           <th>已收金额</th>
           <th>余额</th>
          </tr>
          <%=sbhtml2.ToString() %>
        </table>
      </div>
      
    </div>
    <div>
        <input type="button" value="确定" class="orangeBtn" onclick="Ok()"/>
        <input type="button" value="清除挂帐目标" class="orangeBtn" onclick="Clear()"/>
      </div>
    </form>
</body>
</html>
