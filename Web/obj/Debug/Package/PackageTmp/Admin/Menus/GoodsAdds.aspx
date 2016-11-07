<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsAdds.aspx.cs" Inherits="CdHotelManage.Web.Admin.Menus.GoodsAdds" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
            font-size: 16px;
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
      
    </style>
    <script type="text/javascript">
        function isfill() {
            var txtname = $("#txt_name").val();
            if (txtname == "") {
                alert('名称不能为空');
                return false;
            } else {
                return true;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>
            编辑类型</h1>
        <div class="list">
            <label>
                <asp:Label ID="Label1" runat="server" Text="商品类别:"></asp:Label>  </label>
            <input type="text" id="txt_name" runat="server" />
            <asp:Button ID="btnSave" CssClass="butn" OnClientClick="if(isfill()){}else{return false}"
                runat="server" Text="改" OnClick="btnSave_Click" />
        </div>

    </div>
    </form>
</body>
</html>
