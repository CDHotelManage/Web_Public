function AppendHTML(width, height, href) {
    $("#mainBody", window.parent.document).after("<div id='modiv' style='width:" + width + "; height:" + height + ";'><table style='border:none;width:100%; height:100%' cellpadding='0' cellspacing='0'><tr><td  colspan=\"2\" style='border:1px solid #cdcdcd;  text-align: center;border:none;height:30px;background:#4486b7;'><span style='color:white;font-size:18px;'>打印</span><span style='color:white;font-size:18px;cursor:pointer;margin-right:10px;  float: right;' title='关闭' onclick='Close()'>×&nbsp;</span></td></tr><tr><td colspan='2'><iframe scrolling=\"auto\" frameborder=\"0\" src='" + href + "' style=\"width:100%;border:1px solid #000;height:100%\"></iframe></td></tr></table></div>");
    $("#modiv", window.parent.document).css("position", "fixed");
    $("#modiv", window.parent.document).css("top", "50%");
    $("#modiv", window.parent.document).css("left", "50%");
    $("#modiv", window.parent.document).css("margin-left", "-250px");
    $("#modiv", window.parent.document).css("margin-top", "-250px");
}


//$("#mainBody", window.parent.document).after("<div id='modiv' style='width:" + width + "; height:" + height + ";'><iframe scrolling=\"auto\" frameborder=\"0\" src='" + href + "' style=\"width:100%;border:1px solid #000;height:100%\"></iframe></div>");
//$("#modiv", window.parent.document).css("position", "fixed");
//$("#modiv", window.parent.document).css("top", "50%");
//$("#modiv", window.parent.document).css("left", "50%");
//$("#modiv", window.parent.document).css("margin-left", "-250px");
//$("#modiv", window.parent.document).css("margin-top", "-250px");