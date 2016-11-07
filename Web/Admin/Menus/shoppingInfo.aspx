<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shoppingInfo.aspx.cs" Inherits="CdHotelManage.Web.Admin.Menus.shoppingInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../style/css.css" type="text/css" rel="stylesheet" />
    <script src="../../js/function.js" type="text/javascript"></script>
    <script src="../../js/jquery.js" type="text/javascript"></script>
    <style type="text/css">
        h1
        {
            padding-left: 15px;
            margin-top: 20px;
            margin-bottom: 10px;
            font-size: 19px;
        }
        ul.hotel_infor
        {
            float: left;
            width: 100%;
        }
        ul.hotel_infor li
        {
            width: 100%;
            float: left;
            line-height:40px;
            position: relative;
        }
        ul.hotel_infor li textarea
        {
            width: 600px;
            height: 200px;
            background: #FFF;
            border-color: #ddd;
            border-style: solid;
            border-width: 1px;
        }
        ul.hotel_infor li input
        {
            width: 330px;
            height: 24px;
            line-height: 24px;
            border: 1px solid #7F9DB9;
           
            float: left;
            padding-left: 5px;
            font-size: 14px;
        }
        ul.hotel_infor li textarea{border:solid 1px #7f9db7}
        ul.hotel_infor li label
        {
            float: left;
            font-size: 12px;
            color: #333;
            width: 100px;
            text-align: right;
        }
        .btnOk{ width:0;}
        .xminput{width: 80px; background: #EEE;border:solid 1px ##7F9DB9}
        .mains
        {
            width: 100%;
            margin-left: 0px;
            display: inline;
            float: left;
           
        }
        .hotel_infor input{border:solid 1px #4486b7}
     body{
          }
    </style>
    <script type="text/javascript">
        function isfill() {
            var txtName = $("#txtName").val();
            var txt_lxr = $("#txtContactName").val();
            var txt_phone = $("#txtPhone").val();
            if (txtName == "") {
                alert('酒店名称不能为空');
                return false;
            }
            else if (txt_lxr == "") {
                alert('联系人不能为空');
                return false;
            }
            else if (txt_phone == "") {
                alert('联系电话不能为空');
                return false;
            } else { return true; }
        }
        function abc() {

        }
        $(function () {
            _init_area();
            document.getElementById("s_province").selectedIndex = $("#sp").val();
            change(1);
            document.getElementById("s_city").selectedIndex = $("#sc").val();
            change(2);
            document.getElementById("s_county").selectedIndex = $("#sc1").val();
            $("#s_province").change(function () {
                $("#sp").val(document.getElementById("s_province").selectedIndex);
            })

            $("#s_city").change(function () {
                $("#sc").val(document.getElementById("s_city").selectedIndex);
            })

            $("#s_county").change(function () {
                $("#sc1").val(document.getElementById("s_county").selectedIndex);
            })
        })
    </script>
   
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" id="txtid" runat="server"/>
    <div class="mains">
        <h1>
            酒店信息
        </h1>
        <ul class="hotel_infor">
            <li>
                <label>
                    酒店名称：</label>
                <input type="text" runat="server" id="txtName" />
            </li>
            <li>
                <label>
                    联系人：</label>
                <input type="text" runat="server" id="txtContactName" />
            </li>
            <li>
                <label>
                    电话：</label>
                <input type="text" runat="server" id="txtPhone" />
            </li>
            <li>
                <label>
                    传真：</label>
                <input type="text" runat="server" id="txtFax" />
            </li>
            
            <li>
                <label>
                    城市：</label>
                    <input type="hidden" value="0" runat="server" id="sp" />
                <select id="s_province" runat="server"  name="s_province" onchange="abc()">
                </select>
                <input type="hidden" value="0" runat="server" id="sc" />
                <select id="s_city" runat="server" name="s_city">
                </select>
                <input type="hidden" value="0" runat="server" id="sc1" />
                <select id="s_county" runat="server" name="s_county">
                </select>
                 <script src="../../js/function.js" type="text/javascript"></script>
                 <script type="text/javascript">       _init_area();</script>
            </li>
            <li>
                <label>
                    地址：</label>
                <input type="text" id="txtAddress" runat="server" maxlength="100" />
                <a href="###" onclick="chooseMap()">获取坐标</a> </li>
            <li>
                <label>
                    X坐标：</label>
                <input type="text" id="txtMapX" runat="server" class="xyinput" disabled="true" style="width: 97px" />
                <label style="width: 128px">
                    Y坐标：</label>
                <input type="text" id="txtMapY" runat="server" class="xyinput" disabled="true" style="width: 97px" />
            </li>
            <li>
                <label>
                    简介：</label>
                <textarea runat="server" id="Discription"></textarea>
            </li>
            <li>
                <label>
                    &nbsp;
                </label>
             <%-- <asp:Button ID="btnsave" runat="server" Text="保存" OnClientClick="if(isfill()){}else{return false;}"
                    OnClick="btnsave_Click" />--%>
              <input type="button" value="保存" class="btnOk" onclick="if(isfill()){}else{return false;}"  runat="server" onserverclick="btnsave_Click" />
            </li>
        </ul>
    </div>
    <div id="show">
    </div>
    </form>
</body>
</html>
