<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="map.aspx.cs" Inherits="CdHotelManage.Web.Wap.about.map" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>��ͼ</title>
    <script src="/js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=1.3"></script>
    <script type="text/javascript">
        $(function () {
            $("#dituContent").width($(document.body).width());
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
  <div style="height:700px;" id="dituContent"></div>
    </form>
</body>
</html>
<script type="text/javascript">
    $(document).ready(function () {
        var map = new BMap.Map("dituContent");            // ����Mapʵ��
        var point = new BMap.Point(121.2635340000, 31.0229470000);    // ����������
        map.centerAndZoom(point, 18);                     // ��ʼ����ͼ,�������ĵ�����͵�ͼ����     
        var marker = new BMap.Marker(point);  // ������ע
        map.addOverlay(marker);              // ����ע��ӵ���ͼ��
        marker.setAnimation(BMAP_ANIMATION_BOUNCE); //�����Ķ���    
    });
</script>