<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookRptPrint.aspx.cs" Inherits="CdHotelManage.Web.Admin.Rpt.AccountDay1" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <object classid="CLSID:BAEE131D-290A-4541-A50A-8936F159563A" codebase="http://127.0.0.1/aizhigala/PrintControl.cab" version="10,2,0,1078" viewastext style="display: none"></object>
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
            AutoDataBind="true" PrintMode="ActiveX" />
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
        </CR:CrystalReportSource>
    </div>
    </form>
</body>
</html>
