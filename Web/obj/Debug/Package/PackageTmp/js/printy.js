function printWork(str) {
    var orderhtml = "";
    if (document.getElementById(str)) { orderhtml = document.getElementById(str).outerHTML; }
    else orderhtml = str;
    /* 创建iframe */
    var headobj = document.getElementsByTagName("head").item(0); //提取head  
    printFrame = document.getElementById("lldxi_printRegionFrame_2012_0112");
    if (printFrame) { document.body.removeChild(printFrame); }
    printFrame = document.createElement("iframe");
    printFrame.setAttribute("src", "about:blank");
    printFrame.setAttribute("id", "lldxi_printRegionFrame_2012_0112");
    printFrame.setAttribute("marginheight", "0");
    printFrame.setAttribute("marginwidth", "0");
    printFrame.style.display = "none";
    document.body.appendChild(printFrame);
    if (window.ActiveXObject)//ie
    {
        var htmlobj = printFrame.contentWindow.document.createElement("html"); var bodyobj = printFrame.contentWindow.document.createElement("body");
        bodyobj.innerHTML = orderhtml; htmlobj.appendChild(headobj.cloneNode(true)); htmlobj.appendChild(bodyobj);
        printFrame.contentWindow.document.appendChild(htmlobj); printFrame.contentWindow.document.execCommand("Print", true);
    }
    else {
        var htmlstr = "<html>" + headobj.outerHTML + "<body>" + orderhtml + "<script type=\"text/javascript\">window.print();<\/script><\/body>" + "<\/html>";
        printFrame.contentWindow.document.write(htmlstr);
    }
}