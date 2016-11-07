function Win_GETTOP(e) {//获取元素的纵坐标  
    var offset = e.offsetTop;
    if (e.offsetParent != null) offset += Win_GETTOP(e.offsetParent);
    return offset;
}
function Win_GETLEFT(e) {//获取元素的横坐标 
    var offset = e.offsetLeft;
    if (e.offsetParent != null) offset += Win_GETLEFT(e.offsetParent);
    return offset;
}
//type:1左边 ，2上面，3右边 
//url:页面的路径
//Win_Width:页面宽度
//Win_Heght:页面高度
var div_Window;
var win_Function; //窗体关闭后触发的函数方法，主要用于更新gridview数据
function Window_Open(obj, type, url, Win_Width, Win_Heght, Title, Win_Function, DivName) {
    type = 4;
    win_Function = Win_Function;
    div_Window = document.getElementById("div_Window");
    if (div_Window) {
        $(div_Window).remove();
    }
    else {
        div_Window = document.createElement("div");
    }
    div_Window.id = "div_Window";
    div_Window.style.backgroundColor = "White";
    var top = Win_GETTOP(obj);
    var left = Win_GETLEFT(obj);
    var ClassName = "div_win_left";
    var innerHtml = "<table cellpadding='0' cellspacing='0'><tr><td>"+Title+"</td><td style=' widht:25px;vertical-align:top; padding-top:12px;background:#4486b7'><span style='color:red;font-size:15px;cursor:pointer;' onclick='Window_Close()'>&nbsp;&nbsp;&nbsp;×&nbsp;</span></td>";
  if (type == 4) {
      ClassName = "div_win_center";
      var winh = document.documentElement.clientHeight - 30;
      var winw = document.documentElement.clientWidth;
        top = (winh - Win_Heght) / 2;
        left = (winw - Win_Width) / 2;
        if (Win_Heght > winh) {
            Win_Heght = winh;
            top = 0;
        }
        if (Win_Width > winw) {
            left = 0;
            Win_Width = winw;
        }

        innerHtml = "<table style='border:none' cellpadding='0' cellspacing='0'><tr><td  colspan=\"2\" style='border:1px solid #cdcdcd;  text-align: center;border:none;height:30px;background:#4486b7;'><span style='color:white;font-size:18px;'>" + Title + "</span><span style='color:white;font-size:18px;cursor:pointer;margin-right:10px;  float: right;' title='关闭' onclick='Window_Close()'>×&nbsp;</span></td></tr>";
        innerHtml += "<tr><td colspan='2' style=\"background: #fff;\"><iframe height=\"" + Win_Heght + "\" id=\"iframe_window\" width=\"" + Win_Width + "\" marginwidth=\"0\" marginheight=\"0\" hspace=\"0\" src=\"" + url + "\" vspace=\"0\" frameborder=\"0\" scrolling=\"yes\" ></iframe></td></tr></table>";
        od = div_Window;
        TuoDong($(div_Window));
    }
    div_Window.className = ClassName;
    div_Window.style.width = Win_Width + "px";
    div_Window.style.height = Win_Heght + "px";
    if (DivName != null)
        DivName.appendChild(div_Window);
    else
        document.documentElement.appendChild(div_Window);
    div_Window.innerHTML = innerHtml;
    div_Window.style.left = left + "px";
    div_Window.style.top = top + "px";
    return div_Window;
}

function TuoDong(divs) {
    var dragging = false;
    var iX, iY;
    divs.click(function () {
        dragging = false;
    })
    divs.mousedown(function (e) {
        dragging = true;
        iX = e.clientX - this.offsetLeft;
        iY = e.clientY - this.offsetTop;
        this.setCapture && this.setCapture();
        return false;
    });
    document.onmousemove = function (e) {
        if (dragging) {
            var e = e || window.event;
            var oX = e.clientX - iX;
            var oY = e.clientY - iY;
            divs.css({ "left": oX + "px", "top": oY + "px" });
            return false;
        }
    };
    $(document).mouseup(function (e) {
        dragging = false;
        divs[0].releaseCapture();
        e.cancelBubble = true;
    }) 
}

//页面关闭事件
function Window_Close() {
    try {
        var iframe_window = document.getElementById("iframe_window");
        iframe_window.src = "";
        var t = setTimeout("div_Window.parentNode.removeChild(div_Window);", 100);
        if (win_Function) {
            win_Function();
        }
        document.getElementById("btnSearch").click();
    } catch (e) {
        var iframe_window = document.getElementById("iframe_window");
        iframe_window.src = "";
        var t = setTimeout("div_Window.parentNode.removeChild(div_Window);", 100);
        if (win_Function) {
            win_Function();
        }
    }
}
//页面关闭事件
function Window_Closes() {
    try {
        var iframe_window = document.getElementById("iframe_window");
        iframe_window.src = "";
        var t = setTimeout("div_Window.parentNode.parentNode.removeChild(div_Window);", 100);
        if (win_Function) {
            win_Function();
        }
        document.getElementById("btnSearch").click();
    } catch (e) {
        var iframe_window = document.getElementById("iframe_window");
        iframe_window.src = "";
        var t = setTimeout("div_Window.parentNode.parentNode.removeChild(div_Window);", 100);
        if (win_Function) {
            win_Function();
        }
    }
}
/*-------------------------鼠标拖动---------------------*/
var od; //= document.getElementById("fd");
var dx, dy, mx, my, mouseD;
var odrag;
var isIE = document.all ? true : false;
//div鼠标放开事件
MouseUp = function () {
    mouseD = false;
    odrag = "";
    if (isIE) {
        od.releaseCapture();
        // od.filters.alpha.opacity = 100;
    }
    else {
        window.releaseEvents(od.MOUSEMOVE);
        // od.style.opacity = 1;
    }
}

//div鼠标按下事件
MouseDown = function (e) {
    odrag = this;
    var e = e ? e : event;
    if (e.button == (document.all ? 1 : 0)) {
        mx = e.clientX;
        my = e.clientY;

        if (isIE) {
            od.setCapture();
        }
        else {
            window.captureEvents(Event.MOUSEMOVE);
        }

        mouseD = true;
    }
}
//div移动事件
MouseMove = function (e) {
    var e = e ? e : event;

    //alert(mrx);
    //alert(e.button);        
    if (mouseD == true && odrag) {
        var mrx = e.clientX - mx;
        var mry = e.clientY - my;
        od.style.left = parseInt(od.style.left) + mrx + "px";
        od.style.top = parseInt(od.style.top) + mry + "px";
        mx = e.clientX;
        my = e.clientY;
    }
}









