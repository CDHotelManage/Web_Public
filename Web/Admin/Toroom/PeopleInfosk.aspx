<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PeopleInfosk.aspx.cs" Inherits="CdHotelManage.Web.Admin.Toroom.PeopleInfosk" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../js/jquery.js" type="text/javascript"></script>
    <script src="../../calendar/WdatePicker.js" type="text/javascript"></script>
    <script src="../../js/hDate.js" type="text/javascript"></script>
    <link href="../../style/css.css" rel="stylesheet" type="text/css" />
    <link href="../../style/hDate.css" rel="stylesheet" type="text/css" />
    <link href="../../style/Opendiv.css" rel="stylesheet" type="text/css" />
    <script src="../../js/DivWH.js" type="text/javascript"></script>
    <link href="../../style/css2.css" rel="stylesheet" type="text/css" />
    <link href="../../style/css3.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        $(function () {
            $("#btnzj").click(function () {
                var content = "";
                var txtname = $("#txt_name").val();
                var txtsex = $("#txt_Sex").val();
                var txtDate = $("#txt_Date2").val();
                //  var txtzjlx = $("#DDlSFz").val();
                var obj = document.getElementById('DDlSFz');
                var txtzjlx = obj.options[obj.selectedIndex].text; //获取文本
                var objs = document.getElementById('DDlFh');
                var txt_fh = objs.options[objs.selectedIndex].text; //获取文本
                // alert(txt_fh);
                var txt_zjhm = $("#txt_CardId").val();
                var txtlxdh = $("#txt_lxphone").val();
                var txtmz = $("#txt_mingzhu").val();
                var remaker = $("#txt_remaker").val();
                var a = "<tr><td>" + txt_fh + "</td><td>" + txtname + "</td><td>" + txtsex + "</td><td>" + txtDate + "</td><td>" + txtzjlx + "</td><td>" + txt_zjhm + "</td><td>" + remaker + "</td><td><span style='cursor:pointer;' onclick=\"tableDel('Tabcs')\">删除</span></td></tr>";
                $("#Tabcs").find("tr").eq(0).after(a);
                $("#txt_name").val('');
                $("#txt_Sex").val('');
                $("#txt_Date2").val('');
                $("#DDlSFz").val('')
                $("#txt_CardId").val('');
                $("#txt_lxphone").val('');
                $("#txt_mingzhu").val('');
                $("#txt_remaker").val('');

            })
            var A = "";
            if (parent.document.getElementById("txt_zhi").value == "") {
                A = $("#txt_Info").val();

            } else {
                A = parent.document.getElementById("txt_zhi").value;

            }
            var s = A.split('|');

            var ass = "";
            for (var i = 0; i < s.length; i++) {
                if (s == "") {
                    return;
                } else {
                    ass += "<tr><td>" + s[i].split(',')[0] + "</td><td>" + s[i].split(',')[1] + "</td><td>" + s[i].split(',')[2] + "</td><td>" + s[i].split(',')[3] + "</td><td>" + s[i].split(',')[4] + "</td><td>" + s[i].split(',')[5] + "</td><td>" + s[i].split(',')[6] + "</td><td><span style='cursor:pointer;' onclick=\"tableDel('Tabcs')\">删除</span></td></tr>";
                }
            }
            $("#Tabcs").find("tr").eq(0).after(ass);
        })
        function tableDel(Table) {
            var table = document.getElementById(Table);
            var rowIndex = event.srcElement.parentNode.parentNode.rowIndex;
            table.deleteRow(rowIndex);
        }
        function TableText(tab) {
            var content = "";
            var Table = document.getElementById(tab);
            for (var i = 1; i < Table.rows.length; i++) {

                if (content == "") {
                    content += Table.rows[i].cells[0].innerText + "," + Table.rows[i].cells[1].innerText + "," + Table.rows[i].cells[2].innerText + "," + Table.rows[i].cells[3].innerText + "," + Table.rows[i].cells[4].innerText + "," + Table.rows[i].cells[5].innerText+"," + Table.rows[i].cells[6].innerText;
                } else {
                    content += "|" + Table.rows[i].cells[0].innerText + "," + Table.rows[i].cells[1].innerText + "," + Table.rows[i].cells[2].innerText + "," + Table.rows[i].cells[3].innerText + "," + Table.rows[i].cells[4].innerText + "," + Table.rows[i].cells[5].innerText +","+ Table.rows[i].cells[6].innerText;

                }
            }
            alert(content);
            parent.document.getElementById("txt_zhi").value = content;
        }
        $(function () {
            $("#selSex").change(function () {
                $("#txt_Sex").val($(this).val());
            })
            BindNav();
        })
        //绑定民族
        function BindNav() {
            var national = ["汉族", "壮族", "满族", "回族", "苗族", "维吾尔族", "土家族", "彝族", "蒙古族", "藏族", "布依族", "侗族", "瑶族", "朝鲜族", "白族", "哈尼族", "哈萨克族", "黎族", "傣族", "畲族", "傈僳族", "仡佬族", "东乡族", "高山族", "拉祜族", "水族", "佤族", "纳西族", "羌族", "土族", "仫佬族", "锡伯族", "柯尔克孜族", "达斡尔族", "景颇族", "毛南族", "撒拉族", "布朗族", "塔吉克族", "阿昌族", "普米族", "鄂温克族", "怒族", "京族", "基诺族", "德昂族", "保安族", "俄罗斯族", "裕固族", "乌孜别克族", "门巴族", "鄂伦春族", "独龙族", "塔塔尔族", "赫哲族", "珞巴族"];
            var nat = document.getElementById("national");
            for (var i = 0; i < national.length; i++) {
                var option = document.createElement('option');
                option.value = i;
                var txt = document.createTextNode(national[i]);
                option.appendChild(txt);
                nat.appendChild(option);
            }
            nat.onchange = function () {
                var txt = document.getElementById("national").options[window.document.getElementById("national").selectedIndex].text;
                $("#txt_mingzhu").val(txt);
            }
        }
    </script>
    <style type="text/css">
     #Tabcs td{ text-align:center;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="overflow: auto;">
        <ul class="addyd">
            <li style="width: 940px;">
                <ul>
                    <li><span>房号：</span><p>
                        <asp:DropDownList ID="DDlFh" DataTextField="Rn_roomNum" CssClass="textbox_hrj textbox-text_hrj" DataValueField="id" runat="server">
                        </asp:DropDownList>
                    </p>
                    </li>
                    <li><span>姓 名：</span><p>
                        <input type="text" name="textfield" id="txt_name" class="textbox_hrj" runat="server" /></p>
                    </li>
                    <li><span>性 别：</span><p>
                    <select id="selSex" class="textbox_hrj"><option value="男">男</option><option value="女">女</option></select>
                        <input type="hidden" name="textfield" id="txt_Sex" runat="server" value="男" />
                        
                        </p>
                    </li>
                    <li><span>出生年月：</span><p>
                        <input type="text" name="textfield" class="textbox_hrj" id="txt_Date2" onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss',onpicked:function() {AddDay()}})"
                            runat="server" /></p>
                    </li>
                    <li><span>证件类型：</span><p>
                        <asp:DropDownList ID="DDlSFz" DataTextField="ct_name" CssClass="textbox_hrj textbox-text_hrj" Height="23px" DataValueField="id" runat="server">
                        </asp:DropDownList>
                    </p>
                    </li>
                    <li><span>证件号码：</span><p>
                        <input type="text" name="textfield" class="textbox_hrj" id="txt_CardId" runat="server" /></p>
                    </li>
                    <li><span>联系电话：</span><p>
                        <input type="text" name="textfield" class="textbox_hrj" id="txt_lxphone" runat="server" /></p>
                    </li>
                    <li><span>民 族：</span><p>
                    <select id="national" class="textbox_hrj" ></select>
                        <input type="hidden" name="textfield" id="txt_mingzhu" runat="server" /></p>
                    </li>
                    <li style="width: 700px;"><span>联系地址：</span><p>
                        <input type="text" class="textbox_hrj"  name="textfield" id="txt_remaker" style="width:80%;" runat="server" /></p>
                    </li>
                </ul>
            </li>
            <li style="width: 940px; background: #fffff">&nbsp; &nbsp; &nbsp;
                <input class="button_orange" style="height: 30px; padding:0 7px;" type="button" id="btnzj"
                    value="新增" />
            </li>
            <li style="width: 950px; background: #f2f2f2; padding:0;">
                <table width="100%" id="Tabcs" align="center" cellspacing="0">
                    <tr class="tr">
                        <td class="tdkd00">
                            房号
                        </td>
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
            </li>
            <li style="width: 800px; padding-left: 80px; text-align: right; clear: right;">&nbsp;
                <input name="确定" type="button" value="确定" class="button_orange" onclick="TableText('Tabcs');parent.Window_Close();"
                    style="height: 30px; padding:0 5px;" />
                <input name="关闭" type="button" value="关闭" class="button_gray" onclick="parent.Window_Close();"
                    style="height: 30px; margin-left: 20px;padding:0 5px; color:#fff;" /></li>
            &nbsp;
        </ul>
        <input type="hidden" id="txt_id" runat="server" />
        <input type="hidden" id="txt_type" runat="server" />
        <input type="hidden" id="txt_CardesName" runat="server" />
        <asp:HiddenField ID="hidSchool" runat="server" />
        <input type="hidden" id="txt_Info" runat="server" />
    </div>
    </form>
</body>
</html>
