<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="customerList1.aspx.cs" Inherits="CdHotelManage.Web.Admin.Toroom.customerList1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <link href="../css/toomroom.css" rel="stylesheet" type="text/css" />
    <link href="../css/tch.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../../js/DivWH.js" type="text/javascript"></script>
    <link href="../../style/Opendiv.css" rel="stylesheet" type="text/css" />
    <script src="../js/base.js" type="text/javascript"></script>
    <style type="text/css">
      .ftt_search{ margin:0; margin-bottom:10px; margin-top:10px;}
      .main{ margin-bottom:5px; margin-left:10px;}
       body .vip_member tr.lihover{ background:#FBE889;}
    body .vip_member tr.cbox{ background:#FBE889;}
    .modeif{ width:400px; height:300px; position:fixed; left:50%; top:50%; margin-left:-200px; margin-top:-150px; background-color:#fff; border:1px solid #000;}
    .modeif ul li{ line-height:25px; text-align:center;}
    .modeleft{ width:100px; float:left;  margin-top: 0px;
  border-bottom: 1px solid #DDD;
  border-left: 1px solid #ddd;
  background: #D0F2FF;}
     .modeTop{ height:200px;}
     .modeRight{float:left; height:100%;}
     .modeif h2{text-align: center;padding: 5px 0; font-family:微软雅黑; color:Maroon;}
     .modeleft ul li{ text-align:left; text-indent:15px;  float: left;
  width: 90%;
  text-align: left;
  line-height: 31px;
  color: #333;
  border-top: 1px solid #AAE8FF;
  border-bottom: 1px solid #FFF;
  cursor: pointer;
  position: relative;
  padding-left: 5%;}
   .modeleft ul li:hover{  background: #E5FFD2;}
   body  .ftt_search input, .ftt_search select{ padding-right:0px;}
    </style>
    <script type="text/javascript">
        $(function () {
            //          
            $(".vip_member tbody tr").click(function () {
                $(".vip_member tbody tr").removeClass("cbox");
                $(this).addClass("cbox");
            })
            if ($("#type").val() == "selectCou") {
                $("#hidType").css("display", "none");
            }
        })

        $.ajaxSetup({
            async: false
        });
        function BtnClick() {
            if ($("#tblgood .cbox").length <= 0) {
                alert("请选择客户!");
            }
            else {
                if ($("#type").val() == "selectCou") {
                    parent.document.getElementById("accounts").value = $("#tblgood .cbox").find("td").eq(0).text();
                    
                    parent.document.getElementById("accnames").value = $("#tblgood .cbox").find("td").eq(1).text();
                    parent.document.getElementById("imgicos").src = "../images/clear.jpg"; 
                    parent.Window_Close();
                }
                else {
                    var ids = "";
                    if ($("#cheIsOk").attr("checked")) { //如果按具体项目记账
                        $("#tblistacc tr").each(function () {
                            ids += $(this).find(".chkID").val() + ",";
                        })
                        if (ids == "") {
                            alert("请选择具体项目");
                        }
                    }
                    else {
                        $.get("/admin/ajax/Member.ashx", "type=getids&orders=" + $("#orderids").val(), function (obj) {
                            ids = obj;
                        }, "text");
                    }
                }
                var d = 0;
                ids = ids.substring(0, ids.length - 1);
                $.get("/admin/ajax/Member.ashx", "type=getsumprice&ids=" + ids, function (obj) {
                    d = obj;
                }, "text");
                $.get("/admin/ajax/Member.ashx", "type=getisOk&accout=" + $("#tblgood .cbox").find("td").eq(0).text() + "&price=" + d, function (obj) {
                    if (obj.statu == "err") {
                        alert(obj.msg);
                    }
                    else {
                        var trobj = parent.document.getElementById("xy");
                        $(trobj).find(".txt_Money").val(d);
                        parent.document.getElementById("idids").value = ids;
                        parent.document.getElementById("account").value = $("#tblgood .cbox").find("td").eq(0).text();
                        parent.document.getElementById("accnames").value = $("#tblgood .cbox").find("td").eq(1).text();
                        parent.document.getElementById("imgicos").src = "../images/clear.jpg"; 
                        parent.Window_Close();
                    }
                }, "json");
            }
        }

        function ISok() {
            if ($("#cheIsOk").attr("checked")) {
                $("#ahover").css("display", "inline-block");
            }
            else {
                $("#ahover").css("display", "none");
            }
        }

        function ShowProject(obj) {
            var url = "accountlist.aspx?orderids=" + $("#orderids").val();
            showMyWindow("选择帐单", url, 600, 300, true, true, true);
        }
    </script>
</head>
<body style=" overflow:hidden;">
    <form id="form1" runat="server">
    <input type="hidden" id="cpid" runat="server"/>
    <input type="hidden" id="orderids" runat="server" />
    <input type="hidden" id="type" runat="server" />
    <div class="modeif" style=" display: none;">
    <div class="modeTop">
    <div class="modeleft">
      <h2>房价协议</h2>
      <ul>
         
      </ul>
     </div>
     <div class="modeRight">
       
     </div>
     </div>
      <div class="types">
            <ul style="float: right; width: 274px">
                <li style=" float:left; margin-right:10px;">
                    <input type="button" class="bus_add " id="Button1" onclick="return BtnClick1();" value="确认" runat="server"  /></li>
                <li style="margin-right: 0px">
                    <input type="button" class="bus_dell" onclick="Close()" id="Button2" value="关闭" style="margin-right: 0px" /></li>
            </ul>
        </div>
    </div>
    <div class="main">
    <div class="ftt_search fontYaHei">
        <label>条件：</label>
        <input type="text" runat="server" style=" width:120px;" id="Word" onfocus="Focus()" placeholder="客户名称/帐号/联系电话/公司电话"/>
        <label>客户类型：</label>
        <asp:DropDownList runat="server" ID="cusType"  CssClass="txt" AutoPostBack="true" OnSelectedIndexChanged="cusTypechange" style=" width:85px;"></asp:DropDownList>
        <label>客户状态：</label>
        <asp:DropDownList runat="server" ID="Cstate" CssClass="txt" AutoPostBack="true" OnSelectedIndexChanged="cusTypechange"   style=" width:85px;"></asp:DropDownList>
        <label>所属行业：</label>
        <asp:DropDownList runat="server" ID="cIndustry" CssClass="txt" AutoPostBack="true" OnSelectedIndexChanged="cusTypechange"  runat="server" style=" width:85px;"></asp:DropDownList>
        <label>客户来源：</label>
       <asp:DropDownList runat="server" ID="Csource" CssClass="txt" AutoPostBack="true" OnSelectedIndexChanged="cusTypechange"  runat="server" style=" width:85px;"></asp:DropDownList>
       <label> <input type="button" class="qtantj" id="Button3" value="查询" runat="server"  onserverclick="Button3_Click" /></label>
        </div>
   
    <table cellpadding="0" cellspacing="0" class="vip_member" id="tblgood" style="width: 98%; margin:0 auto;">
                <tbody>
                    <th width="8%">帐号</th>
                    <th width="6%">客户名称</th>
                    <th width="7%">客户状态</th>
                    <th width="8%">客户类型</th>
                    <th width="8%">客户编号</th>
                    <th width="5%">客户行业</th>
                    <th width="5%">主联系人</th>
                    <th width="7%">联系电话</th>
                    <th width="7%">公司电话</th>
                    <th width="5%">传真</th>
                    <th width="8%">地区</th>
                    <th width="5%">Email</th>
                    <th width="5%">邮编</th>
                </tbody>
             <asp:Repeater runat="server" ID="rep1">
                  <ItemTemplate>
                   <tr accounts="<%#Eval("accounts")%>">
                     <td width="8%"><%#Eval("accounts")%></td>
                     <td width="6%"><%#Eval("cName")%></td>
                     <td width="7%"><%#GetState(Convert.ToInt32(Eval("Cstate")))%></td>
                     <td width="8%"><%#GetCtName(Convert.ToInt32(Eval("cusType")))%></td>
                     <td width="8%"><%#Eval("cusNumber")%></td>
                     <td width="5%"><%#GetIdName(Convert.ToInt32(Eval("cindustry")))%></td>
                     <td width="5%"><%#Eval("contacts")%></td>
                     <td width="7%"><%#Eval("cPhone")%></td>
                     <td width="5%"><%#Eval("companyPhone")%></td>
                     <td width="8%"><%#Eval("Fax")%></td>
                     <td width="8%"><%#Eval("area")%></td>
                     <td width="5%"><%#Eval("Email")%></td>
                     <td width="5%"><%#Eval("ybNum")%></td>
                   </tr>
                  </ItemTemplate>
                </asp:Repeater>
            </table>
             </div>
             <div class="types" id="hidType">
               <input type="checkbox" id="cheIsOk" onclick="ISok()"/>是否按具体项目记账&nbsp;&nbsp;&nbsp;&nbsp;<a href="#" onclick="ShowProject(this)" id="ahover" style=" display:none;">选择具体项目</a>
               
             </div>

             <div class="types">
                <table id="tblistacc">
                  
                </table>
             </div>
             <div class="types">
            <ul style="float: right; width: 274px">
                <li style=" float:left; margin-right:10px;">
                    <input type="button" class="bus_add " id="BtnSave" onclick="BtnClick();" value="确认" runat="server"  /></li>
                <li style="margin-right: 0px">
                    <input type="button" class="bus_dell" onclick="Close()" id="BtnDel" value="关闭" style="margin-right: 0px" /></li>
            </ul>
        </div>
    </form>
</body>
</html>
