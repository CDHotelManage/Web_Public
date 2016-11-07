<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookList.aspx.cs" Inherits="CdHotelManage.Web.Admin.Book.BookList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>




<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <title> 
 预定信息
 </title>
    <script src="../../js/jquery.js" type="text/javascript"></script>
    <script src="../../js/hDate.js" type="text/javascript"></script>
    <link href="../../style/css.css" rel="stylesheet" type="text/css" />
    <link href="../../style/hDate.css" rel="stylesheet" type="text/css" />
    <link href="../../style/reset.css" rel="stylesheet" type="text/css" />
    <script src="../../js/DivWH.js" type="text/javascript"></script>
    <link href="../../style/Opendiv.css" rel="stylesheet" type="text/css" />
    <script src="../../calendar/WdatePicker.js" type="text/javascript"></script>
    <script src="../js/base.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        
        $(function () {
            $(".dysum").text($(".tr1").length);
            $(".tr1").hover(function () {
                if ($(this).attr("class").indexOf("cbok") > 0) {

                }
                else { $(this).addClass("chover"); }
            }, function () {
                $(this).removeClass("chover");
            });
            $(".cbxCheck1").click(function () {
                var nowchk = $(this).parent().parent().attr("bookno");
                //alert($(this).parent().parent().attr("bookno"));
                $(".tr1").each(function () {
                    if ($(this).attr("bookno") != nowchk) {
                        $(this).find(".cbxCheck1").attr("checked", false);
                    }
                })
            })
            $(".tr1").click(function () {
                $(".tr1").removeClass("cbok");
                var allid = $(this).attr("bookno");
                $(".tr1").each(function () {
                    if ($(this).attr("bookno") == allid) {
                        $(this).addClass("cbok");
                    }
                })
              
                if ($(this).find(".tdstate").text() != "取消预定") {
                    $('#button04').removeAttr("disabled");
                    $('#button05').removeAttr("disabled");
                    $('#button06').removeAttr("disabled");
                    $('#button04').css("background", "#ff7f00");
                    $('#button05').css("background", "#8fbf00");
                    $('#button06').css("background", "#8fbf00");
                    $('#button04').css("color", "#fff");
                    $('#button05').css("color", "#fff");
                    $('#button06').css("color", "#fff");
                    $('#button07').css("display", "none");
                }
                else {
                   
                    $('#button04').attr('disabled', "true");
                    $('#button05').attr('disabled', "true");
                    $('#button06').attr('disabled', "true");
                    $('#button04').css("background", "#ececec");
                    $('#button05').css("background", "#ececec");
                    $('#button06').css("background", "#ececec");
                    $('#button04').css("color", "#000");
                    $('#button05').css("color", "#000");
                    $('#button06').css("color", "#000");
                    $('#button07').css("display", "block");
                }
                if ($(this).find(".tdstate").text() == "已入住") {
                    $('#button04').attr('disabled', "true");
                    $('#button05').attr('disabled', "true");
                    $('#button06').attr('disabled', "true");
                    $('#button04').css("background", "#ececec");
                    $('#button05').css("background", "#ececec");
                    $('#button06').css("background", "#ececec");
                    $('#button04').css("color", "#000");
                    $('#button05').css("color", "#000");
                    $('#button06').css("color", "#000");
                    $('#button07').css("display", "none");
                }
            });
            $(".fontblue").each(function () {
                if ($(this).find("a").length <= 1) {
                    var book = $(this).parent().parent().attr("bookno");
                    $(".tr1").each(function () {
                        if ($(this).attr("bookno") == book) {
                            $(this).find(".cbxCheck1").attr("disabled", "disabled");
                        }
                    })
                }
            })
        })
        function BookEancel(obj,id) {
            var url = "BookCancel.aspx?id=" + id;
            
            showMyWindow("取消预定", url, 1000, 450, true, true, true);
        }

        function BookAdd(obj, type,id) {
            var url = "/Admin/Book/BookAdd.aspx?type=" + type + "&id=" + id;
            AddTabs("新增预订信息", url);
        }

        function BookAdd1(obj, type, id) {
            var url = "/Admin/Book/BookAdd.aspx?type=" + type + "&id=" + id;
            AddTabs("编辑预订信息", url);
        }

        function Refund(obj) {
            var bookno = $(".cbok").eq(0).attr("bookno");
            var url = "Refund.aspx?bookno=" + bookno;
            
            showMyWindow("退定金", url, 640, 350, true, true, true);
        }
        function BookAdds(obj, type, id) {
            var url = "BookAdd.aspx?type=" + type + "&id=" + id + "&isok=true";
           
            showMyWindow("查看预订信息", url, 1000, 600, true, true, true);
        }
        function BookToLive(obj) {
            id = $(".cbok").attr("bookno");
            var b = false;
            $(".cbok").each(function () {
                if ($(this).find(".cbxCheck1").attr("checked") == "checked") {
                    b = true;
                }
            })
            if (b) {
                var url = "../Toroom/PeopleInfoAdds.aspx?type=yding&id=" + id;
                Window_Open(obj, 4, url, 1000, 450);
                //showMyWindow("");
            }
            else {
                alert("必须选择一项!!");
            }
         } 
        function DepositAdd(obj) {
            id = $(".cbok").attr("id");
            if (typeof (id) == "undefined") {
                alert("必须选择一项目!!");
                return false;
            }
            var url = "DepositAdd.aspx?id=" + id;
            
            showMyWindow("补交订金", url, 640, 350, true, true, true);
        }
        function RoomFf(obj) {
            id = $(".cbok").attr("id");
            if (typeof (id) == "undefined") {
                alert("必须选择一项目!!");
                return false;
            }
            var bookno = $(".cbok").attr("bookno");
            var url = "HousDis.aspx?id=" + id + "&bookno=" + bookno;
            
            showMyWindow("分房", url, 640, 350, true, true, true);
        }
        function ShowTab(title) {
            id = $(".cbok").attr("bookno");
            var b = false;
            $(".cbok").each(function () {
                if ($(this).find(".cbxCheck1").attr("checked") == "checked") {
                    b = true;
                }
            })
            if (b) {
                ids = $(".cbok").attr("id");
                room = $(".cbok").attr("rooms");
                ydbookno = $(".cbok").attr("bookno");
                var chks = $(".cbxCheck1:checked");
                var xqids = "";

                chks.each(function () {
                    if (xqids == "") {
                        xqids = "'" + $(this).next().val() + "'";
                    } else {
                        xqids += "," + "'" + $(this).next().val() + "'";
                    }

                })
                var url = "/Admin/Toroom/PeopleInfoAddsCs1.aspx?type=yding&id=" + ids + "&rooms=" + room + "&ydbookno=" + ydbookno + "&xqid=" + xqids;
                AddTabs(title, url);
            }
            else {
                alert("必须选择一项!!");
            }
        }
        
    </script>
</head>

<body  onload = "Openupdate(obj, "")" id="myobyd" >
    <form id="form2" runat="server">
    
    <div class="krtop">
        来店时间:<input type="text" name="textfield" class="input001b" id="date1" runat="server"
            onClick="WdatePicker()" />
        至
        <input class="input001b" type="text" name="textfield" runat="server" id="date2" onClick="WdatePicker()" />单号：<input
            class="input001c" type="text" name="textfield" id="book_no" runat="server" />预订人：<input
                class="input001b" type="text" name="textfield" runat="server" id="book_name" />电话：<input
                    class="input001b" type="text" name="textfield" runat="server" id="tele_no" />状态：
     
        <asp:DropDownList ID="RoomStateDdl" runat="server" class="select26">
        </asp:DropDownList>
        是否分房：
       
        <asp:DropDownList ID="fengfangddl" runat="server" class="select26">
            <asp:ListItem Value="0">全部</asp:ListItem>
            <asp:ListItem Value="1">是</asp:ListItem>
            <asp:ListItem Value="2">否</asp:ListItem>
        </asp:DropDownList>
       
        <asp:Button ID="button02" class="fintBtn" runat="server" Text="查询" OnClick="button02_Click" />
    </div>
   
    <table  cellspacing="0" class="tableBlue">
        <thead><tr>
            
            <td>
                预订单号
            </td>
            <td>
                选择
            </td>
            <td>
                状态
            </td>
            <td>
                房号
            </td>
            <td style=" width:5%">
                房型
            </td>
            <td>
                预订房间
            </td>
            <td>
                已开房间
            </td>

            <td>
                来店时间
            </td>
            <td>
                留房时间
            </td>
            <td style=" width:6%">
                预订人
            </td>
            <td>
                电话
            </td>
           <td>
                订单状态
            </td>
            <td>
                来源
            </td>
            <td>
                订金
            </td>
            
            <td style=" width:6%">
                操作
            </td>
        </tr></thead>
<%=sbHtml.ToString() %>
       
       <tbody> <tr class="tr2">
                    <td colspan="4">
                        <div align="right">
                            当页合计：</div>
                    </td>
                    <td class="dysum">
                        
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td colspan="6">
                        <div align="right">
                        </div>
                    </td>
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
                <tr class="tr2">
                    <td colspan="4">
                        <div align="right">
                            总合计：</div>
                    </td>
                    <td>
                      <%=sum %>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td colspan="6">
                        <div align="right">
                        </div>
                    </td>
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr></tbody>
    </table>
   
            <div class="pageupdown">
                <webdiyer:AspNetPager ID="Pager" runat="server" FirstPageText="首页" LastPageText="尾页"
                    NextPageText="下一页" AlwaysShow="True" PrevPageText="上一页" NextPrevButtonClass="incoleft"
                    CurrentPageButtonClass="rednum" PagingButtonClass="numbs" SubmitButtonText="转到"
                    SubmitButtonClass="enterpage" PageIndexBoxClass="pagebox" FirstLastButtonClass="firstlastbutton"
                    OnPageChanged="Pager_PageChanged">
                </webdiyer:AspNetPager>
            </div>
        
   
        <span class="youfu"><input name="提交" type="button"  class="orangeBtn midBtn" id="button03" value="新增预订" onclick = "BookAdd(this,'add')" runat ="server" />
        <input name="提交" type="button"  class="orangeBtn midBtn" id="button04" value="预订转入住" onclick="ShowTab('预订转入住')" />
        <input name="提交" type="button"  class="greenBtn midBtn" id="button05" value="补交订金" onclick="DepositAdd(this)"/>

        <input name="提交" type="button" class="greenBtn midBtn" id="button06" value="分房" onclick="RoomFf(this)"/>
        <input type="button" class="tprice midBtn greenBtn" id="button07" value="退定金" onclick="Refund(this)"/>
        </span>
     <style>
       .youfu{ position:inherit;}
     </style>
    </form>


</body>
</html>
