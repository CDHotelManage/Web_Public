<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoomInfos.aspx.cs" Inherits="CdHotelManage.Web.Admin.Menus2.RoomInfos" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../js/DivWH.js" type="text/javascript"></script>
    <script src="../../js/jquery.js" type="text/javascript"></script>
    <link href="../../style/Opendiv.css" rel="stylesheet" type="text/css" />
    <script src="../js/base.js" type="text/javascript"></script>
    <script type="text/javascript">
        //添加
        function openY(obj) {
            var url = "FloorAdd.aspx?id=";
            showMyWindow("增加楼层", url, 280, 100, true, true, true, update);
        }
        function openupdateY(obj, ids) {
            var url = "FloorAdd.aspx?id=" + ids;
           
            showMyWindow("修改楼层", url, 280, 100, true, true, true, update);
        }
        function OpenLD(obj, ids) {
            var title = "";
            if (ids == "") {
                title = "增加楼栋";
            } else {
                title = "修改楼栋";
            }
            var url = "FlloorLd.aspx?id=" + ids;  );
            showMyWindow(title, url, 400, 100, true, true, true, update);
        }
        function OpenFh(obj, ids) {
            var url = "roomAdds.aspx?id=" + ids;
            showMyWindow("", url, 400, 350, true, true, true);
        }
        function update() {
            window.location.reload();
          }
        function deletes(ids) {
            var btn = document.getElementById("btndelete")
            document.getElementById("txt_id").value = ids;
            if (confirm("确定要删除吗？")) {
                $.get("/Admin/Ajax/IsDel.ashx", "type=loucheng&id=" + ids, function (obj) {
                    if (obj == "ok") {
                        btn.click();
                    }
                    else {
                        alert("该楼层下面有房间，不能删除");
                        return false;
                    }
                }, "text");
            }


        }
        function deletes1(ids) {
            var btn = document.getElementById("btndelete1")
            document.getElementById("txt_fxid").value = ids;
            if (confirm("确定要删除吗？")) {
                $.get("/Admin/Ajax/IsDel.ashx", "type=loudong&id=" + ids, function (obj) {
                    if (obj == "ok") {
                        btn.click();
                    }
                    else {
                        alert("该楼栋下面有楼层，不能删除");
                        return false;
                    }
                }, "text");
                
            }


        }
        function deletes2(ids) {
            var btn = document.getElementById("btndelete2")
            document.getElementById("txt_fj").value = ids;
            if (confirm("确定要删除吗？")) {
                btn.click();
            }


        }
    </script>
    <style type="text/css">
        body ul.room
        {
            float: left;
            width: 100%;
        }
        
        .h1s{  padding-left: 15px;
  margin-top: 20px;
  margin-bottom: 10px;
  font-size: 20px;
  color: #4486b7;
  font-weight: 100;}
        body ul.room li
        {
            float: left;
            margin-top: 10px;
            position: relative;
        }
        body ul.room .lc_span
        {
            width: 6%;
            line-height: 40px;
            float: left;
            font-size: 12px;
            text-align: right;
            color: #333;
        }
        body ul.room .rs
        {
            float: left;
            background: #EFFAFE;
            border: #eee 1px solid;
            width: 90%;
            padding: 6px 5px;
        }
        body ul.room .all
        {
            background: #0e95cc;
            float: left;
            width: 65;
            height:28px;
            line-height:28px;
            font-size:12px;
            color:#fff;
            text-align: center;
        }
        body .main ul.room
        {
            width: 100%;
            margin-left: 0px;
            display: inline;
            float: left;
            margin-bottom: 20px;
        }
        ul.room .lines
        {
            color: #FFF;
            background: #999;
            padding: 0px 1px;
            float: left;
            margin: 0 2px;
            cursor: pointer;
            height: 28px;
             margin-bottom:2px;
        }
        ul.room .lines:hover{ background:#0e95cc;}
        ul.room li span img
        { width:10px;
           height:13px;            }
        ul.room .lines .lines
        {
              margin:0; background:none;
            }
        ul.room li .dell
        {
            background-position: 0px -16px;
        }
        ul.room li span
        {
            float: left;
            margin-left: 8px;
            margin-top: 7px;
              font-size: 12px;
        }
        .jiahao1{ cursor:pointer;  background: #70b236;  padding: 0px 8px;
  line-height: 26px;
  height: 28px;
  overflow: hidden;
  float: left;
  border: 0px;
  font-size: 22px;
  color: #FFF;
  cursor: pointer;
  font-weight: bold;
  border-radius: 1px;}
  .color000{ font-size:12px; color:#333; margin-left:10px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <br />
    <h1 class="h1s">楼栋楼层信息<span class="color000">第一步添加楼栋，第二步添加楼层，第三步添加房间。</span></h1>







    <div class="content">
        <div class="main" style="background-color: White;">
            <br />
           
            <div class="fj_ld">
                <ul class="room">
                    <div class="lc_span">
                        楼栋：</div>
                    <div class="rs">
                        <div class="fj_lc">
                            <div class="all">
                                全 部</div>
                            <asp:Repeater ID="Repeater1" runat="server">
                                <ItemTemplate>
                                    <li class="lines"><span class="leftfloat">
                                        <%# Eval("ld_Name")%></span><span class="lines"><span onclick="OpenLD(this,<%# Eval("id") %>)"
                                            class="update"><img src="../../Images/iconbj.png" /></span> <span class="dell" onclick="return deletes1(<%# Eval("id") %>)">
                                                <img src="../../images/iconsc.png" /></span></span></li>
                                </ItemTemplate>
                            </asp:Repeater>
                            <span style=" cursor:pointer;"  onclick="OpenLD(this,'')" class="bggreen jiahao1">+</span>
                        </div>
                    </div>
                </ul>
            </div>


                        <div class="fj_ld">
                <ul class="room">
                    <div class="lc_span"> 楼层：</div>
                    <div class="rs">
                   
                        <div class="fj_lc">
                         <div class="all">全 部</div>
                            
                            <asp:Repeater ID="Repeaterlc" runat="server">
                            <ItemTemplate>
                                <li class="lines"><span class="leftfloat">
                                    <%# Eval("floor_name")%></span><span class="lines"><span onclick="openupdateY(this,<%# Eval("floor_id") %>)"
                                        class="update"><img src="../../Images/iconbj.png" /></span> <span class="dell" onclick="return deletes(<%# Eval("floor_id") %>)">
                                            <img src="../../images/iconsc.png" /></span></span></li>
                            </ItemTemplate>
                        </asp:Repeater>
                        <span  style=" cursor:pointer;" onclick="openY(this)" class="bggreen jiahao1">+</span>
                        </div>
                    </div>
                </ul>
            </div>



           
        <input type="hidden" id="txt_id" runat="server" />
        <asp:Button ID="btndelete" runat="server" Text="删除" OnClick="btndelete_Click" Style="display: none;" />
        <asp:Button ID="btndelete1" runat="server" Text="删除房型" OnClick="btndelete1_Click"  Style="display: none;" />
        <input type="hidden" id="txt_fxid" runat="server" />
        <asp:Button ID="btndelete2" runat="server" Text="删除房间" Style="display: none;" />
        <input type="hidden" id="txt_fj" runat="server" />
    </div>
    </form>
</body>
</html>
