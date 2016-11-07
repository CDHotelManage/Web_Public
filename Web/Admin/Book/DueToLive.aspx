<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DueToLive.aspx.cs" Inherits="CdHotelManage.Web.Admin.Book.DueToLive" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../js/jquery.js" type="text/javascript"></script>
    <script src="../../js/hDate.js" type="text/javascript"></script>
    <link href="../../style/css.css" rel="stylesheet" type="text/css" />
    <link href="../../style/hDate.css" rel="stylesheet" type="text/css" />
    <link href="../../style/Opendiv.css" rel="stylesheet" type="text/css" />
    <script src="../../js/DivWH.js" type="text/javascript"></script>
    <script src="../../calendar/WdatePicker.js" type="text/javascript"></script>
 <script type="text/javascript">
     function DivDis() {
         var Div = document.getElementById("DivDisHid");
         var hidd = document.getElementById("zhankai");
         if (hidd.innerHTML == "展开") {
             hidd.innerHTML = "隐藏";
         } else {
             hidd.innerHTML = "展开";
         }


         if (hidd.innerHTML == "隐藏") {
             Div.style.display = "block";

         } else {
             Div.style.display = "none";
         }
     }
     function DivDisRoom() {
         var Div = document.getElementById("DivDisHidroom");
         var hidd = document.getElementById("btn_rooms");
         if (hidd.value == "继续开房") {
             hidd.value = "终止开房";
         } else {
             hidd.value = "继续开房";
         }
         if (hidd.value == "终止开房") {
             Div.style.display = "block";

         } else {
             Div.style.display = "none";
         }
     }
     function funAddTa(ta) {

         var txtName = document.getElementById("txt_CardesName").value;
         var table = document.getElementById(ta);
         var row = table.insertRow(table.rows.length);
         var bindcs = "<select><option>请选择</option>";
         var vcel = row.insertCell(0);
         vcel = row.insertCell(0);
         row.insertCell(0).innerHTML = "<input class='tdkd01' name='textfield' style='width:60px;' type='text' />";
         row.insertCell(1).innerHTML = "<input class='tdkd02'  name='textfield' style='width:60px;' type='text' />";
         row.insertCell(2).innerHTML = "<input class='tdkd02'  name='textfield' style='width:70px;' type='text' onclick=\"calendar.show({ id: this })\" />";
         for (var i = 0; i < txtName.split(';').length - 1; i++) {

             bindcs += "<option value='" + txtName.split(';')[i].split(',')[0] + "'>" + txtName.split(';')[i].split(',')[1] + "</option>";
         }
         row.insertCell(3).innerHTML = bindcs;
         row.insertCell(4).innerHTML = " <input class='tdkd04'  name='textfield' style='width:90px;' type='text' />";
         row.insertCell(5).innerHTML = " <input class='tdkd05'  name='textfield' style='width:350px;' type='text' />";
         row.insertCell(6).innerHTML = "<span class='tdkd06'> <a onclick=\"tableDel('Tabcs')\" href='#'>[删]</a></span>";

     }
     function tableDel(Table) {

         var table = document.getElementById(Table);
         var rowIndex = event.srcElement.parentNode.parentNode.parentNode.rowIndex;
         table.deleteRow(rowIndex);


     }
     function TableText(tab) {
         var text = "";
         var table = document.getElementById(tab);

         for (var i = 1; i < table.rows.length; i++) {
             var cellstr = "";
             var str = "";
             for (var y = 0; y < table.rows[i].cells.length - 3; y++) {
                 if (y == "3") {
                     str += table.rows[i].cells[y].getElementsByTagName("select")[0].value;
                     cellstr += table.rows[i].cells[y].getElementsByTagName("select")[0].value + "#";
                 }
                 else if (y == "5") {

                     str += table.rows[i].cells[y].getElementsByTagName("INPUT")[0].value;
                     cellstr += table.rows[i].cells[y].getElementsByTagName("INPUT")[0].value;
                 }
                 else {
                     str += table.rows[i].cells[y].getElementsByTagName("INPUT")[0].value;
                     cellstr += table.rows[i].cells[y].getElementsByTagName("INPUT")[0].value + "#";

                 }

             }

             if (str != "")
                 text += cellstr + "|";

         }

         document.getElementById("hidSchool").value = text;
         text = "";
     }

     function BTncher(ids) {
         var btn = document.getElementById("btnBind")
         document.getElementById("txt_id").value = ids;
         btn.click();
     }
     function isFill() {

         var isValid = true;
         var title = document.getElementById("txt_yjmoney");
         var kffs = document.getElementById("DDlKffs");
         if (title.value == "") {
             alert('押金不能为空');
             isValid = false;
         } else if (kffs.selectedIndex == "0") {
             alert('请选择开房方式');
             isValid = false;
         }
         TableText('Tabcs');
         return isValid;

     }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="overflow: auto;">
        <label>
            <span class="tctitle01">预定转入住</span>
            <ul class="addyd">
                <li><span>房 号：</span><p>
                    <input type="text" name="textfield" id="txt_roomid" runat="server" /></p>
                </li>
                <li><span>房 型：</span><p>
                    <asp:DropDownList ID="ddroomtype" DataTextField="room_name" DataValueField="id" runat="server">
                    </asp:DropDownList>
                </p>
                </li>
                <li><span>会员卡号：</span><p>
                    <input type="text" name="textfield" id="txt_hycardId" runat="server" /></p>
                </li>
                <li><span>来 源：</span><p>
                    <asp:DropDownList ID="DDlkrly" runat="server">
                    </asp:DropDownList>
                </p>
                </li>
                <li style="width: 420px"><span>房价方案：</span>
                    <p>
                        <asp:DropDownList ID="DDLfjfa" runat="server" Style="width: 334px;">
                        </asp:DropDownList>
                    </p>
                </li>
                <li><span>房 价：</span><p>
                    <input type="text" name="textfield" id="txt_money" runat="server" /><p>
                </li>
                <li><span>开房方式：</span><asp:DropDownList ID="DDlKffs" DataTextField="real_mode_name"
                    DataValueField="real_mode_id" runat="server">
                </asp:DropDownList>
                </li>
                <li><span>入住天数：</span>
                    <p style="text-align: center; width: 28px; float: left; background: #b3b3b3; color: #FFF;
                        cursor: pointer; font-size: 18px;">
                        -</p>
                    <p style="width: 68px; float: left;">
                        <input type="text" id="txt_Day" runat="server" value="1" name="textfield" style="width: 52px;
                            margin: 0 1px" /></p>
                    <p style="text-align: center; width: 28px; float: left; background: #b3b3b3; color: #FFF;
                        cursor: pointer; font-size: 18px;">
                        +</p>
                </li>
                <li><span>入住时间：</span><p>
                    <input type="text" name="textfield" id="txt_rzdate" onclick="calendar.show({ id: this })"
                        runat="server" /></p>
                </li>
                <li><span>预离时间：</span><p>
                    <input type="text" name="textfield" id="txt_ylDate" runat="server" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})" /></p>
                </li>
                <li style="width: 940px; background: #f2f2f2">
                    <ul>
                        <li><span>姓 名：</span><p>
                            <input type="text" name="textfield" id="txt_name" runat="server" /></p>
                        </li>
                        <li><span>性 别：</span><p>
                            <input type="text" name="textfield" id="txt_Sex" runat="server" /></p>
                        </li>
                        <li><span>出生年月：</span><p>
                            <input type="text" name="textfield" id="txt_Date2" onclick="calendar.show({ id: this })"
                                runat="server" /></p>
                        </li>
                        <li><span>民 族：</span><p>
                            <input type="text" name="textfield" id="txt_mingzhu" runat="server" /></p>
                        </li>
                        <li><span>证件类型：</span><p>
                            <asp:DropDownList ID="DDlSFz" DataTextField="ct_name" DataValueField="id" runat="server">
                            </asp:DropDownList>
                        </p>
                        </li>
                        <li><span>证件号码：</span><p>
                            <input type="text" name="textfield" id="txt_CardId" runat="server" /></p>
                        </li>
                        <li><span>联系电话：</span><p>
                            <input type="text" name="textfield" id="txt_lxphone" runat="server" /></p>
                        </li>
                        <li style="width: 800px;"><span>地址：</span><p>
                            <input type="text" name="textfield" id="txt_address" style="width: 800px;" runat="server" /></p>
                        </li>
                    </ul>
                </li>
                <li style="width: 940px; background: #FFFFF; text-align:center;">
                <div id="DivDisHidroom" style="width: 100%; display: none;">
                    <ul>
                        <asp:Repeater ID="Repeaterfj" runat="server">
                            <ItemTemplate>
                                <li style=" width:50px; padding-left:20px;">
                                  <span onclick="BTncher(<%# Eval("id") %>)"> <%# Eval("Rn_roomNum")%></span> 
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    </div>
                </li>
                <li style="width: 940px;"><span style="width: 870px; text-align: right;">新增随客信息</span>&nbsp;<a
                    style="cursor: pointer; color: Blue;" id="zhankai" onclick="DivDis()">展开</a>
                    <div id="DivDisHid" style="width: 100%; display: none;">
                        <table width="100%" id="Tabcs" align="center" cellspacing="0">
                            <tr class="tr">
                                <td class="tdkd01">
                                    姓名
                                </td>
                                <td class="tdkd02">
                                    性别
                                </td>
                                <td class="tdkd03">
                                    出生年月
                                </td>
                                <td class="tdkd03">
                                    证件类型
                                </td>
                                <td class="tdkd04">
                                    证件号码
                                </td>
                                <td class="tdkd05">
                                    联系地址
                                </td>
                                <td class="tdkd06">
                                    操作
                                </td>
                            </tr>
                            
                        </table>
                        <span onclick="funAddTa('Tabcs')" style="width: 900px; text-align: right; color: Red;
                            cursor: pointer;">增加</span>
                    </div>
                </li>
                <li style="width: 940px; clear: left; overflow: hidden;">
                    <ul class="addyd" style="border: none; padding-left: 0;">
                        <li><span>支付方式：</span><p>
                            <asp:DropDownList ID="DDlZffs" DataTextField="meth_pay_name" DataValueField="meth_pay_id"
                                runat="server">
                            </asp:DropDownList>
                        </p>
                        </li>
                        <li><span>押 金：</span><p>
                            <input type="text" name="textfield" id="txt_yjmoney" runat="server" /></p>
                        </li>
                        <!--定金结束-->
                        <li><span>房 价：</span><p>
                            <input type="text" name="textfield" id="txt_fjPrice" runat="server" /></p>
                        </li>
                        <li style="width: 880px; clear: left; overflow: hidden;"><span>备 注：</span><p>
                            <textarea id="txt_Remaker" runat="server" rows="3" style="float: left; width: 748px;"></textarea></p>
                        </li>
                    </ul>
                </li>
                <li style="width: 800px; padding-left: 80px; clear: left;">
                    <asp:Button ID="btnAdds" runat="server" Text="开房" class="button_orange" Style="height: 34px; 
                        padding-left: 0" OnClientClick="if(isFill()){}else{return false}" OnClick="btnAdds_Click"  />&nbsp;
                    <input name="预　订" type="button" value="读取二代身份证" class="button_orange" style="height: 34px;
                        padding-left: 0" />
                    <input name="关　闭" type="button" value="关　闭" class="button_gray" onclick="parent.Window_Close();" style="height: 34px;
                        padding-left: 0" />
                    <input name="关　闭" type="button" onclick="DivDisRoom()" value="继续开房" id="btn_rooms" class="button_green" style="height: 34px;
                        padding-left: 0" />
                    <li>
                        <!--按纽结束-->
            </ul>
        </label>
        <asp:Button ID="btnBind" runat="server" Text="Button" onclick="btnBind_Click"  style="display:none;" />
        <input type="hidden" id="txt_id" runat="server" />
        <input type="hidden" id="txt_CardesName" runat="server" />
        <asp:HiddenField ID="hidSchool" runat="server" />
    </div>
    </form>
    <br />
    <div class="clearboth">
    </div>
</body>
</html>