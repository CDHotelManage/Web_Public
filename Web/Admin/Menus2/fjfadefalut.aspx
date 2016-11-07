<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fjfadefalut.aspx.cs" Inherits="CdHotelManage.Web.Admin.Menus2.fjfadefalut" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../style/css.css" type="text/css" rel="stylesheet">
    <script src="../../js/jquery.js" type="text/javascript"></script>
    <link href="../../style/Opendiv.css" rel="stylesheet" type="text/css" />
    <script src="../../js/DivWH.js" type="text/javascript"></script>
    <script src="../../calendar/WdatePicker.js" type="text/javascript"></script>
    <script src="../js/base.js" type="text/javascript"></script>
    <style type="text/css">
        h1
        {
            padding-left: 15px;
            margin-top: 20px;
            margin-bottom: 10px;
            font-size: 20px;
            color: #4486b7;
  font-weight: 100;
        }
        .list
        {
            width: 100%;
            float: left;
            display: inline;
            margin-top: 10px;
        }
        .list input.butn
        {
            background: #70b236;
            border: 0 none;
            border-radius: 1px;
            color: #fff;
            cursor: pointer;
            float: left;
            font-size: 22px;
            font-weight: bold;
            line-height: 28px;
            height: 28px;
            padding: 0 8px;
            width: 36px;
        }
        .list input
        {
            width: 180px;
            float: left;
            background: #FFF;
            border: 1px solid #ddd;
            height: 24px;
            padding-left: 10px;
            font-size: 14px;
        }
        .list label
        {
            float: left;
            width: 120px;
            text-align: right;
            line-height: 26px;
            color: #333;
            font-size: 12px;
        }
        .divlist
        {
            margin-left: 120px;
            margin-top: 10px;
        }
        .lin
        {
            color: #FFF;
            background: #999;
            padding: 0px 10px;
            line-height: 28px;
            float: left;
            margin: 10px 10px 10px 0px;
            cursor: pointer;
        }
        .chover
        {
            background: blue;
        }
        table
        {border-collapse: collapse;
             border:1px solid #ddd;
            }
            table td{ text-align:center;}
            .table1{ width:60%; float:left; margin-left:2%;}
            .table2{ width:80%; float:left; margin-top:20px; margin-left:2%;}
    </style>
    <script type="text/javascript">
        function BookEancel(ids, type) {
            var btn = document.getElementById("btndelete");
            document.getElementById("txt_id").value = ids;
            if (confirm("确定要删除吗？")) {
                btn.click();
            }


        }
        $(function () {
            $(".lin").hover(function () {
                $(this).addClass("chover");
            }, function () { $(this).removeClass("chover") });

            $(".itset li").hover(function () {
                $(this).addClass("chovers");
            }, function () { $(this).removeClass("chovers") });

            $.get("/admin/ajax/GoodsAcce.ashx", "type=getyuan&typeid=" + $("#ddroomtype").val(), function (obj) {
                $("#Hs_yuan").val(obj);
            }, "text");
            $("#ddroomtype").change(function () {
                $.get("/admin/ajax/GoodsAcce.ashx", "type=getyuan&typeid=" + $(this).val(), function (obj) {
                    $("#Hs_yuan").val(obj);
                }, "text")
            })

            $("#hs_Discount").change(function () {
                var Hs_yuan = $("#Hs_yuan").val();
                var zk = $(this).val();
                if (zk != "" && (!/^\d+(\.\d+)?$/.test(zk) || parseFloat(zk) <= 0)) {
                    alert("请输入正确格式!");
                }
                else {
                    $("#Hs_zdr").val(parseFloat(Hs_yuan) * parseFloat(zk));
                }
            })

            $("#Hs_zdr").change(function () {
                var Hs_yuan = $("#Hs_yuan").val();
                var Hs_zdr = $(this).val();
                if (Hs_zdr != "" && (!/^\d+(\.\d+)?$/.test(Hs_zdr) || parseFloat(Hs_zdr) <= 0)) {
                    alert("请输入正确格式!");
                }
                else {
                    $("#hs_Discount").val(parseFloat(Hs_zdr) / parseFloat(Hs_yuan));
                }
            })
        })

        function isfill() {
            var txtname = $("#txt_name").val();
            if (txtname == "") {
                alert('名称不能为空');
                return false;
            } else {
                return true;
            }
            $("#txt_name").val('');
        }
        function OpenBc(obj, ids) {
            var url = "fjfaAdd.aspx?id=" + ids;
            showMyWindow("修改房价方案", url, 400, 120, true, true, true);
        }

        function Fiss() {
            $("#hid").val("");
            $("#BtnEdit").attr("disabled", true);
            if ($("#Hs_name").val() == "") {
                alert("折扣名不能为空!");
                return false;
            }
            else if ($("#hs_Discount").val() == "") {
                alert("折扣值不能为空!");
                return false;
            }
            else if ($("#Hs_Strat").val() == "") {
                alert("开始时间不能为空！");
                return false;
            }
            else if ($("#Hs_End").val() == "") {
                alert("结束时间不能为空！");
                return false;
            }
            else if ($("#Hs_zdr").val() == "") {
                alert("折扣后房价不能为空！");
                return false;
            }
        }

        function del(id) {
            if (confirm("是否确定删除！")) {
                $.get("/admin/Ajax/Books.ashx", "type=isdel&id=" + id, function (obj) {
                    if (obj == "ok") {
                        $("#delId").val(id);
                        alert("删除成功！");
                        window.location.reload();
                    }
                    else {
                        alert("该方案已经有房间使用过，不能删除!");
                    }
                }, "text");
            } else { 
               
            }
        }

        function modify(id, obj) {
            var trnow = $(obj).parent().parent();
            $("#hid").val(id);
            $("#Hs_name").val(trnow.find("td").eq(0).text());
            $("#hs_Discount").val(trnow.find("td").eq(1).text());
            $("#Hs_isAll").attr("checked", trnow.find("td").eq(2).find("input").attr("checked"));
            $("#ddroomtype").val(trnow.find("td").eq(3).text());
            $("#Hs_Strat").val(trnow.find("td").eq(5).text());
            $("#Hs_End").val(trnow.find("td").eq(6).text());
            $("#Hs_zdr").val(trnow.find("td").eq(4).text());
            $("#Hs_Reamrk").val(trnow.find("td").eq(7).text());
            $("#BtnEdit").attr("disabled",false);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" id="delId" runat="server" />
    <input type="hidden" id="hid" runat="server"/>
    <h1>
            房价方案</h1>
    <div style=" display:none;">
        
        <div class="list">
            <label>
                方案名称:</label>
            <input type="text" id="txt_name" runat="server" />
          
            
            
        </div>
        <div class="list">
            <label>
                方案折扣:</label>
            <input type="text" id="txt_zkfa" runat="server" />
          
            
            </div>
            <div  style="  padding-left:80px; padding-top:90px;">
           <asp:Button ID="btnSave" class="orangeBtn midBtn" OnClientClick="if(isfill()){}else{return false}"
                runat="server" Text="添加" OnClick="btnSave_Click" />
            
            </div>
        <div class="divlist" id="DivHtml" runat="server">
            <div class="lin">
                <span>测试</span> <em>x</em>
            </div>
            <div class="lin">
                <span>样式</span> <em>x</em>
            </div>
            <div class="lin">
                <span>样式</span> <em>x</em>
            </div>
        </div>
        <asp:Button ID="btndelete" runat="server" Text="删除" Style="display: none;" OnClick="btndelete_Click" />
        <asp:Button ID="btnSeach" runat="server" Text="查询" style=" display:none;" onclick="btnSeach_Click" />
        <input type="hidden" id="txt_id" runat="server" />
    </div>
    <table class="table1">
      <tr>
        <td>折扣名:</td>
        <td><input type="text" runat="server" id="Hs_name"/></td>
        <td>折扣值:</td>
        <td><input type="text" id="hs_Discount" runat="server"/></td>
        <td>是否为所有房类:</td>
        <td><input type="checkbox" runat="server" id="Hs_isAll" /></td>
      </tr>
      <tr>
        <td>房类:</td>
        <td><asp:DropDownList ID="ddroomtype" DataTextField="room_name" DataValueField="id" runat="server">
                    </asp:DropDownList></td>
        <td>开始时间:</td>
        <td><input type="text" onclick="WdatePicker({dateFmt:'yyyy-MM-dd',onpicked:function() {AddDay()}})" runat="server" id="Hs_Strat"/></td>
        <td>结束时间:</td>
        <td><input type="text" onclick="WdatePicker({dateFmt:'yyyy-MM-dd',onpicked:function() {AddDay()}})" runat="server" id="Hs_End"/></td>
      </tr>
      <tr>
        <td>原房价:</td>
        <td><input type="text" runat="server" id="Hs_yuan"/></td>
        <td>打折后房价:</td>
        <td><input type="text" runat="server" id="Hs_zdr"/></td>
        <td>备注:</td>
        <td><input type="text" runat="server" id="Hs_Reamrk"/></td>
       
      </tr>
    </table><br />
    <asp:Button ID="btnOk" runat="server" OnClientClick="return Fiss()" OnClick="BtnOk_Click" CssClass="orangeBtn"  Text="添加新方案" />
    <asp:Button ID="BtnEdit" runat="server" Text="修改方案" Enabled="false" OnClick="BtnEdit_Click" CssClass="greenBtn "/>
    <table class="table2">
       <tr>
        <td>折扣名</td>
        <td style=" width:90px;">是否为所有房类</td>
        <td>房类编号</td>
        <td>原价</td>
        <td>折扣值</td>    
        <td>打折后房价</td>
        <td>开始时间</td>
        <td>结束时间</td>
        <td>备注</td>
        <td>操作</td>
       </tr>
       <asp:Repeater runat="server" ID="rep1">
       <ItemTemplate>
       <tr>
        <td><%#Eval("hs_name")%></td>
        <td><%#GetIs( Convert.ToBoolean(Eval("Hs_isAll")))%></td>
        <td><%#GetFxName(Eval("hs_room").ToString())%></td>
        <td><%#GetFxPrice(Eval("hs_room").ToString())%></td>
         <td><%#Eval("hs_Discount")%></td>    
        <td><%# Convert.ToDecimal(Eval("Hs_zdr")).ToString("0.##")%></td>
        <td><%# Convert.ToDateTime(Eval("Hs_Strat")).ToString("yyyy-MM-dd")%></td>
        <td><%# Convert.ToDateTime(Eval("Hs_End")).ToString("yyyy-MM-dd")%></td>
        <td><%#Eval("Hs_Reamrk")%></td>
        <td><a href="#" onclick="modify(<%#Eval("id")%>,this)">修改</a><a href="#" onclick="del(<%#Eval("id")%>)">删除</a></td>
       </tr>
       </ItemTemplate>
       </asp:Repeater>
    </table>
    <%--<asp:Button ID="btn_del" runat="server" OnClick="btn_del_click"/>--%>
    </form>
</body>
</html>
