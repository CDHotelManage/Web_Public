<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeBehind="mlist.aspx.cs" Inherits="CdHotelManage.Web.Admin.member.mlist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <link href="../../style/Opendiv.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../js/DivWH.js" type="text/javascript"></script>
    <script src="../../easyui/jquery.easyui.min.js" type="text/javascript"></script>
    <link href="../../easyui/themes/gray/easyui.css" rel="stylesheet" type="text/css" />
    <script src="../js/base.js" type="text/javascript"></script>
    <style type="text/css">
     .vip_member ul li span{ display:block; width:70%;}
     body .vip_member tr.lihover{ background:#FBE889;}
     body .vip_member tr.cbox{ background:#FBE889;}
     table tr td{border-left: 1px #ddd solid;}
     .div_win_center iframe{ border:none;}
    </style>
    <script type="text/javascript">
        function Del(id) {
            if (confirm("是否删除该类型?")) {
                $.get("/admin/ajax/Member.ashx", "type=delmt&id=" + id, function (obj) {
                    if (obj == "ok") {
                        window.location.reload();
                    }
                    else {
                        alert("该类型还存在会员，不能删除!");
                    }
                }, "text")
            }
        }
        $(function () {
            $(".vip_member tbody tr").hover(function () {
                $(".vip_member tbody tr").removeClass("cbox");
                $(this).addClass("cbox");
            })
            $(".vip_member tbody tr").click(function () {
                $(".vip_member tbody tr").removeClass("lihover");
                $(this).addClass("lihover");
            })
            var sm1 = 0;
            var sm2 = 0;
            $("#tblgood tbody").eq(1).find("tr").each(function () {
                sm1 += parseInt($(this).find("td").eq(5).text());
                sm2 += parseInt($(this).find("td").eq(6).text());
            })
            $("#pointsPage").text(sm1);
            $("#amountPage").text(sm2);
        })
        function MemberCard1(obj) {
            var url = "mAdd.aspx?type=add";
            showMyWindow("添加会员", url, 620, 400, true, true, true);
        }
        function addType(obj) {
            var url = "mAddType.aspx?type=add";
            showMyWindow("添加类型", url, 680, 600, true, true, true);
        }

        function editType(obj, id) {
            var url = "mAddType.aspx?type=edit&id=" + id;
            showMyWindow("编辑类型", url, 680, 600, true, true, true);
        }

        function Loc(id) {
            window.location.href = "mlist.aspx?typeid=" + id;
        }

        function MemberCardType(obj, id) {
            var url = "mAdd.aspx?type=edit&id=" + id;
            showMyWindow("编辑会员", url, 605, 500, true, true, true);
        }
        function AddPrice(obj, id) {
            var mid = $(".vip_member tbody .lihover").eq(0).find("td").eq(0).text();
            if (mid != "") {
                $("#CardNo").val(mid);
            }
            var url = "mLoss.aspx?type=addPrice&id=" + mid;
            showMyWindow("会员冲值", url, 820, 490, true, true, true);
        }
        function jftz(obj, id) {
            var mid = $(".vip_member tbody .lihover").eq(0).find("td").eq(0).text();
            if (mid != "") {
                $("#CardNo").val(mid);
            }
            var url = "mLoss.aspx?type=jftz&id=" + mid;
            showMyWindow("积分调整", url, 820, 520, true, true, true);
        }
        function gua(obj, id) {
            var mid = $(".vip_member tbody .lihover").eq(0).find("td").eq(0).text();
            if (mid != "") {
                $("#CardNo").val(mid);
            }
            var url = "mLoss.aspx?type=gua&id=" + mid;
            showMyWindow("会员挂失", url, 820, 500, true, true, true);
        }

        function updatecard(obj, id) {
            var mid = $(".vip_member tbody .lihover").eq(0).find("td").eq(0).text();
            if (mid != "") {
                $("#CardNo").val(mid);
            }
            var url = "mLoss.aspx?type=cardUp&id=" + mid;
            showMyWindow("会员挂失", url, 820, 500, true, true, true);
        }
        function lvup(obj) {
            var mid = $(".vip_member tbody .lihover").eq(0).find("td").eq(0).text();
            if (mid != "") {
                $("#CardNo").val(mid);
            }
            var url = "mLoss.aspx?type=lvup&id=" + mid;
            showMyWindow("会员升级", url, 820, 500, true, true, true);
        }

        function xucard(obj, id) {
            var mid = $(".vip_member tbody .lihover").eq(0).find("td").eq(0).text();
            if (mid != "") {
                $("#CardNo").val(mid);
            }
            var url = "mLoss.aspx?type=xucard&id=" + mid;
            showMyWindow("会员续卡", url, 820, 500, true, true, true);
        }
        
        function tuicard(obj, id) {
            var mid = $(".vip_member tbody .lihover").eq(0).find("td").eq(0).text();
            if (mid != "") {
                $("#CardNo").val(mid);
            }
            var url = "mLoss.aspx?type=tuicard&id=" + mid;
            showMyWindow("会员退卡", url, 820, 500, true, true, true);
        }

        function Pwds(obj) {

            var mid = $(".vip_member tbody .lihover").eq(0).find("td").eq(0).text();
            if (mid != "") {
                $("#CardNo").val(mid);
            }
            var url = "mLoss.aspx?type=pwdResl&id=" + mid;
            showMyWindow("修改密码", url, 820, 500, true, true, true);
        }
        function AddPrices(obj) {
            var url = "addPice.aspx";
            showMyWindow("添加方案", url, 620, 310, true, true, true);
        }

        function exchange(obj) {
            var url = "exchange.aspx";
            showMyWindow("兑换商品", url, 863, 550, true, true, true);
        }
        function Read() {
            var h = $("#tblgood").html();
            $("#hidtable").val("<table style='padding:10px;'>" + h + "</table>");
        }
        function Find(obj,mid) {
            if (confirm("是否确认找回？")) {
                $.get("/admin/ajax/Member.ashx", "type=find&mid=" + mid, function (obj) {
                    if (obj == "ok") {
                        alert("找回成功!");
                        window.location.reload();
                    }
                }, "text")
            }
        }
    </script>
    
</head>
<body>
    <form id="form1" runat="server">
    <div class="main" style="width: 98%; margin-left: 1%;">
        <div class="ftt_search fontYaHei">
            <label>条件：</label>
            <input type="text" style="width: 180px" placeholder="请输入卡号/电话/姓名/证件号码" id="Members" runat="server"/>
            <label>最近</label><input type="text" id="Days" runat="server" style="width: 35px; margin-right: 3px;"/><label>天将要过生日的会员信息</label>
            <label style="margin-left: 20px;">卡状态：</label><%--<select style="width: 80px; margin-right: 25px" id="Status">
                <option value="">全部</option>
                <!--<option value="0">新卡</option>
                    <option value="1">未激活</option>-->
                <option value="10" selected="selected">正常</option>
                <option value="20">挂失</option>
                <option value="21">过期</option>
                <option value="30">作废</option>
            </select>--%>
            <asp:DropDownList runat="server" ID="Status">
            </asp:DropDownList>
            <input type="button" class="qtantj" value="查询" id="btnQuery" runat="server" onserverclick="btnQuery_click"/>
        </div>
        <div style="width: 10%; float: left">
            <ul class="vip_member" id="li_kind" style="width: 100%">
                <ul class="vip_member" id="Ul1" style="width: 100%">
                    <li id="li_0" class="select" onclick="Loc(0)"><span id="sp_0">全部</span></li>
                    <%--<li id="li_8" class=""><span
                        id="sp_8">金卡</span><em id="ea_8" class="edit"></em><em id="em_8" class="dell"></em></li>--%>
                        <%=sbtext.ToString() %>
                    <li class="add">
                        <input type="button" value="添加" id="btnSPFLAdd" onclick="addType(this)" class="bus_add"></li>
                        </ul>
            </ul>
            <div class="vip_db" style="margin: 0px; width: 100%">
                <!--<input type="button" value="积分设置" class="add_price_type" onclick="javascript: top.openTab('/Member/vip_credit.html', '积分设置', true)" style="margin-top: 10px" />-->
                <input class="add_price_type" type="button" value="充值方案" id="Rechargesolution" style="margin-top: 10px" onclick="AddPrices(this)">
            </div>
        </div>
        <div style="width: 90%; float: left">
            <table cellpadding="0" cellspacing="0" class="vip_member" id="tblgood" style="width: 100%">
                <tbody>
                    <th width="8%">卡号</th>
                    <th width="5%">类型</th>
                    <th width="7%">姓名</th>
                    <th width="8%">电话</th>
                    <th width="5%">状态</th>
                    <th width="7%">卡内积分</th>
                    <th width="7%">卡余额</th>
                    <th width="5%">性别</th>
                    <th width="8%">生日</th>
                    <th width="5%">证件类型</th>
                    <th width="10%">证件号码</th>
                    <th width="10%">发卡时间</th>
                    <th width="8%">操作员</th>
                    <th width="7%">操作</th>
                </tbody>
                <asp:Repeater ID="rep1" runat="server">
                 <ItemTemplate>
                   <tr>
                      <td><%#Eval("Mid")%></td>
                      <td><%#BindCate( Convert.ToInt32(Eval("Mtype")))%></td>
                      <td><%#Eval("Name")%></td>
                      <td><%#Eval("Phone")%></td>
                      <td><%#GetState(Convert.ToInt32(Eval("Statid")))%></td>
                      <td><%#GetJf(Eval("Mid").ToString())%></td>
                      <td><%#GetYue(Eval("Mid").ToString())%></td>
                      <td><%#Sex( Convert.ToBoolean(Eval("Sex")))%></td>
                      <td><%#Eval("Baithday")%></td>
                      <td><%#Zj(Convert.ToInt32(Eval("Zjtype")))%></td>
                      <td><%#Eval("ZjNumber")%></td>
                      <td><%#Eval("AddDate")%></td>
                      <td><%#GetName(Eval("addUser").ToString())%></td>
                      <td><%#GetMenu(Convert.ToInt32(Eval("Statid")), Eval("Mid").ToString())%></td>
                   </tr>
                 </ItemTemplate>
                </asp:Repeater>
            </table>
            <table cellpadding="0" cellspacing="0" class="vip_member" id="Table1" style="width: 100%">
                <tr>
                    <td colspan="5" width="33%" style="text-align: right">当前合计：</td>
                    <td width="7%" style="text-align: right" id="pointsPage">0.00</td>
                    <td width="7%" style="text-align: right" id="amountPage">0.00</td>
                    <td colspan="7" width="53%">&nbsp;</td>
                </tr><%--
                <tr>
                    <td colspan="5" width="33%" style="text-align: right">总合计：</td>
                    <td width="7%" style="text-align: right" id="points">0.00</td>
                    <td width="7%" style="text-align: right" id="amount">0.00</td>
                    <td colspan="7" width="53%">&nbsp;</td>
                </tr>--%>
            </table>
            <div class="vip_db" style="margin-left: 0px; width: 100%">
                <div class="fl">
                    <input type="button" value="会员发卡" class="bus_add" id="MemberCard" onclick="MemberCard1(this)" />
                    <input type="button" value="会员充值" class="bus_add" id="Recharge" onclick="AddPrice(this)"/>
                    <input type="button" value="积分兑换" class="bus_add" id="Pointsfor" onclick="exchange(this)"/>
                    <input type="button" value="积分调整" class="bus_add" id="MemberScore" onclick="jftz(this)"/>
                    <input type="button" value="会员挂失" class="bus_add" id="Memberloss" onclick="gua(this)"/>
                    <input type="button" value="会员导入" class="bus_add" id="Dataimport" />
                </div>
                <div class="fr">
                    <div id="divPage"></div>
                </div>
                <div class="fl" style="margin-top: 10px; width: 100%">
                    <input type="button" value="会员换卡" class="bus_add" id="MemberIn"  onclick="updatecard(this)"/>
                    <input type="button" value="会员续卡" class="bus_add" id="MemberRenew"  onclick="xucard(this)"/>
                    <input type="button" value="会员退卡" class="bus_add" id="MemberOut" onclick="tuicard(this)"/>
                    <input type="button" value="会员升级" class="bus_add" id="Memberup" onclick="lvup(this)"/>
                    <input type="button" value="密码重置" class="bus_add" id="Setpassword" onclick="Pwds(this)"/>
                    <input type="submit" value="会员导出" class="bus_add" id="MemberExport" runat="server" onclick="Read()" onserverclick="MemberExport_Click" />
                    <input type="hidden" value="" id="hidtable" runat="server" />
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
