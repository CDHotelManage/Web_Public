<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InteSyS.aspx.cs" Inherits="CdHotelManage.Web.Admin.Menus2.InteSyS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../style/css.css" rel="stylesheet" type="text/css" />
    <link href="../../style/Opendiv.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../js/DivWH.js" type="text/javascript"></script>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <link href="../css/tch.css" rel="stylesheet" type="text/css" />
    <script src="../js/base.js" type="text/javascript"></script>
    <style type="text/css">
      h1
        {
            padding-left: 30px;
            margin-top: 20px;
            margin-bottom: 10px;
            font-size: 19px;
        }
        .csszText{ line-height:30px; letter-spacing:2px;}
        .w30{ width:30px; text-align:center;}
        .w60{ width:60px;}
    </style>
    <script type="text/javascript">
        $(function () {
            $("#LockType").val($("#txt").val());
            $("#LockType").change(function () {
                var txt = $(this).val();
                if (txt == "PROUSB") {
                    var url = "RommSuo.aspx?txt=" + txt;
                    var obj = document.getElementById("LockType");
                    showMyWindow("房间锁号", url, 600, 400, true, true, true);
                }
                else if (txt == "爱迪尔") {
                    var url = "RommSuo.aspx?txt=" + txt;
                    var obj = document.getElementById("LockType");
                    showMyWindow("房间锁号", url, 600, 400, true, true, true);
                }
            })
        })

        function showdiv() {
            var txt = $("#LockType").val();
            if (txt == "PROUSB") {
                var url = "RommSuo.aspx?txt=" + txt;
                var obj = document.getElementById("LockType");
                showMyWindow("房间锁号", url, 600, 400, true, true, true);
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
     <input type="hidden" id="txt" runat="server"/>
     <div class="titleBlue titles">接口设置</div>
     <div class="intediv">
       门锁类型<%--<select id="LockType">
                        <option value="">无</option>
                    <option value="LCRFRWSDK">LCRFRWSDK</option><option value="PROUSB">PROUSB</option><option value="爱迪尔">爱迪尔</option><option value="必达">必达</option><option value="第吉尔">第吉尔</option><option value="摩德隆">摩德隆</option><option value="雅迪顿">雅迪顿</option><option value="远为">远为</option><option value="智能HotelLock">智能HotelLock</option></select>--%>
                    <asp:DropDownList runat="server" ID="LockType">
                     <asp:ListItem Value="" Text="无"></asp:ListItem>
                     <asp:ListItem Value="PROUSB" Text="PROUSB"></asp:ListItem>
                     <asp:ListItem Value="爱迪尔" Text="爱迪尔"></asp:ListItem>
                    </asp:DropDownList><input type="button" class="bus_add " value="设置房间锁码"  onclick="showdiv()" />
     </div>
     <div class="types">
            <ul style="float: right; width: 100%; margin-top:15px;">
                <li id="ShowFee" style="display:none;">
                    <input name="NoCardFee" type="checkbox" id="NoCardFee" class="inps" value="1" onchange="BtnCardFee()" style="border: 0px; margin-top: 6px">&nbsp;免卡费
                </li>
                <li style=" float:left;">
                    <input name="BtnSave" type="submit" id="BtnSave" class="bus_add " value="确定" runat="server" onserverclick="BtnSave_Click">
                </li>
                <li style="margin-right: 0px; float:left;">
                    <input type="button" id="BtnDel" class="bus_dell " onclick="Close()" value="关闭" style="margin-right: 0px">
                </li>
            </ul>
        </div>
    </form>
</body>
</html>
