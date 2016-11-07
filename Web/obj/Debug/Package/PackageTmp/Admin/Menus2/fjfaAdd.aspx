<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fjfaAdd.aspx.cs" Inherits="CdHotelManage.Web.Admin.Menus2.fjfaAdd" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
       <link href="../../style/css.css" type="text/css" rel="stylesheet">
    <script src="../../js/jquery.js" type="text/javascript"></script>
    <style type="text/css">
        h1
        {
            padding-left: 15px;
            margin-top: 20px;
            margin-bottom: 10px;
            font-size: 19px;
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
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
        <div style="padding-left: 50px; padding-top: 90px;">
            <asp:Button ID="btnSave" class="orangeBtn midBtn" OnClientClick="if(isfill()){}else{return false}"
                runat="server" Text="修改" OnClick="btnSave_Click" />
        </div>
    </div>
    </form>
</body>
</html>
