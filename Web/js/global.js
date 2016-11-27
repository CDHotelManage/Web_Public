var md = {};
md.global = {
    File: {
        FileServerLength: 2,
        ServerIndex: parseInt(2 * Math.random()),
        PictureExt: '*.gif;*.png;*.jpg;*.jpeg;*.bmp', //图片后缀判断
        DocmentExt: '*.doc;*.docx;*.ppt;*.pot;*.pps;*.pptx;*.xls;*.xlsx;*.pdf;*.txt;*.mmap;*.vsd', //可转换文档
        CompressFileExt: '*.rar;*.zip;*.7z', //压缩文件
        //上传插件替换完成后使用NEW
        PictureExtNew: 'gif,png,jpg,jpeg,bmp', //图片后缀判断
        DocmentExtNew: 'doc,docx,ppt,pot,pps,pptx,xls,xlsx,pdf,txt,mmap,vsd,md,ai,psd,tif,dwt,dwg,dws,dxf,wps,dps,dpt,pps,et,xmind,cdr,project,key,numbers,pages,rp,pub,cal,3ds,max,indd,mpp,eml,log,dotx', //可上传文档
        CompressFileExtNew: 'zip,rar,7z', //压缩文件
        DocViewExt: 'doc,docx,ppt,pptx,xls,xlsx,pdf'
    },
    Config: {
        MQServers: '',
        ShowStorage: 0, //是否显示网盘存储
        VirtualPath: '',
        DocViewServer: 'http://nodeserver.com/token?',
        QiniuUploadUrl: "https://up.qbox.me/"
    },
    APPInfo: {
        taskAppID: "ab99d0bb-3249-46f9-8a60-6952cb76cac2",
        calendarAppID: "42c96ef1-3ab6-4269-9824-e21436f34a38"
    },
    AjaxRequestQueue: new Array()
};
var globalVariablesEl = document.getElementById('globalVariables');
if(globalVariablesEl) {
    var globalVariables = JSON.parse(globalVariablesEl.innerHTML);
    var VirtualPath = globalVariables.VirtualPath;
    var CustomizeTheme = globalVariables.CustomizeTheme;
    var config = globalVariables.config;
    for(var k in globalVariables['md.global']) {
        md.global[k] = $.extend({}, md.global[k], globalVariables['md.global'][k]);
    }
}

// Webchat 要用
function createTimeSpan(dateStr) {
    var dateTime = new Date();

    var date = dateStr.split(" ")[0];
    var year = date.split("-")[0];
    var month = date.split("-")[1] - 1;
    var day = date.split("-")[2];

    var time = dateStr.split(" ")[1];
    var hour = time.split(":")[0];
    var minute = time.split(":")[1];
    var second = time.split(":")[2];

    dateTime.setFullYear(year);
    dateTime.setMonth(month);
    dateTime.setDate(day);
    dateTime.setHours(hour);
    dateTime.setMinutes(minute);
    dateTime.setSeconds(second);

    var now = new Date();

    var today = new Date();
    today.setFullYear(now.getFullYear());
    today.setMonth(now.getMonth());
    today.setDate(now.getDate());
    today.setHours(0);
    today.setMinutes(0);
    today.setSeconds(0);

    var milliseconds = 0;
    var timeSpanStr;
    if (dateTime - today >= 0) {
        milliseconds = now - dateTime;
        if (milliseconds < 1000 && milliseconds < 60000) {
            timeSpanStr = md_lang.common_phrase_justnow;
        } else if (milliseconds > 1000 && milliseconds < 60000) {
            timeSpanStr = Math.floor(milliseconds / 1000) + md_lang.myfeed_updates_time_second;
        } else if (milliseconds > 60000 && milliseconds < 3600000) {
            timeSpanStr = Math.floor(milliseconds / 60000) + md_lang.myfeed_updates_time_minute;
        } else {
            timeSpanStr = md_lang.common_phrase_today + " " + hour + ":" + minute;
        }
    }
    else {
        milliseconds = today - dateTime;
        if (milliseconds < 86400000) {
            timeSpanStr = md_lang.common_phrase_yesterday + " " + hour + ":" + minute;
        } else if (milliseconds > 86400000 && year == today.getFullYear()) {
            timeSpanStr = (month + 1) + md_lang.PM_date_month + day + md_lang.PM_date_day+" " + hour + ":" + minute;
        } else {
            timeSpanStr = year + md_lang.myaccount_profile_job_year + (month + 1) + md_lang.PM_date_month + day + md_lang.PM_date_day + " " + hour + ":" + minute;
        }
    }
    return timeSpanStr;
}
function CreateTimeSpan(dateStr) {
    return createTimeSpan(dateStr);
}

//重新定位弹出层的位置，让其居中
function resetOffset(obj) {
    if ($(obj).length) {
        var top = ($(window).height() - $(obj).height()) / 2 + $(window).scrollTop();
        var left = ($(window).width() - $(obj).width()) / 2
        $(obj).offset({ left: left, top: top });
    }
}

//加载中...
var LoadDiv = function (msg) {
    return '<div class="TxtCenter TxtMiddle mTop10 mBottom10 w100"><div class="divCenter clipLoader ThemeColor3"></div></div>';
    // var tip = typeof (md_lang) != 'undefined' ? md_lang.All_loading_description : "加载中...";
    // if (msg) {
    //     tip = msg;
    // }
    // return "<div id=\"LoadDiv\" class=\"TxtCenter mTop10 mBottom10 TxtMiddle\"><span class='iconLoading'></span><span class='TxtMiddle Font12'>" + tip + "</span></div>";
};
//数据为空
var NullDiv = function (msg) {
    var tip = md_lang.admin_stats_cost_blankstate;
    if (msg) {
        tip = msg;
    }
    return "<div class=\"TxtCenter mTop10\">" + tip + "</div>";
};

//统一非空提醒
var glintInterval = new Object();
glintInterval.curInterval = null;
glintInterval.count = 0;
function NullTextbox(divID) {
    var $el = $(divID);
    if ($el.children().length) {
        var bgColor = $el.css("backgroundColor");
        $el.children().css("backgroundColor", bgColor);
    }
    if (glintInterval.curInterval) {
        clearInterval(glintInterval.curInterval);
        glintInterval.curInterval = null;
    }
    glintInterval.curInterval = setInterval(function() {
        glint($el);
    }, 300);
}
function glint(divID) {
    glintInterval.count++;
    try {
        var $el = $(divID);
        $el.children().andSelf($el).add($el.find(':text')).animate({
            backgroundColor: '#ffcccc'
        }, 180).animate({
            backgroundColor: '#ffffff'
        }, 180);
    } catch (e) { }
    if (glintInterval.count % 2 == 0) {
        clearInterval(glintInterval.curInterval);
        glintInterval.curInterval = null;
    }
}


//封装StringBuilder
function StringBuilder() {
    this._string_ = new Array();
}
StringBuilder.prototype.Append = function (str) {
    this._string_.push(str);
}
StringBuilder.prototype.toString = function () {
    return this._string_.join("");
}
StringBuilder.prototype.AppendFormat = function () {
    if (arguments.length > 1) {
        var TString = arguments[0];
        if (arguments[1] instanceof Array) {
            for (var i = 0, iLen = arguments[1].length; i < iLen; i++) {
                var jIndex = i;
                var re = new RegExp('\\{' + jIndex + '\\}', 'g');
                TString = TString.replace(re, arguments[1][i]);
            }
        } else {
            for (var i = 1, iLen = arguments.length; i < iLen; i++) {
                var jIndex = i - 1;
                var re = new RegExp('\\{' + jIndex + '\\}', 'g');
                TString = TString.replace(re, arguments[i]);
            }
        }
        this.Append(TString);
    } else if (arguments.length == 1) {
        this.Append(arguments[0]);
    }
};

//trim去掉字符串两边的指定字符，默认去空格
String.prototype.Trim = function (str) {
    if (!str) {
        str = '\\s';
    } else {
        if (str == '\\') {
            str = '\\\\';
        } else if (str == ',' || str == '|' || str == ';' || str == '-') {
            str = '\\' + str;
        } else {
            str = '\\s';
        }
    }
    var reg = new RegExp('(^' + str + '+)|(' + str + '+$)');

    return this.replace(reg, '');
};
String.prototype.trim = function (str) {
    return this.Trim(str);
};
//判断一个字符串是否为NULL或者空字符串
String.prototype.isNull = function () {
    return this == null || this.trim().length == 0;
}
String.prototype.equals = function (str) {
    return this == str;
}
String.prototype.contains = function (str) {
    if (str) return this.indexOf(str) != -1;
    else return false;
}
String.prototype.endWith = function (str) {
    return this.slice(-str.length) == str;
}
//字符串截取，后面加入...
String.prototype.interceptString = function (len) {
    if (this.length > len) {
        return this.substring(0, len - 1) + "...";
    } else {
        return this;
    }
}
//获得一个字符串的字节数
String.prototype.countLength = function () {
    var strLength = 0;
    for (var i = 0; i < this.length; i++) {
        if (this.charAt(i) > '~') strLength += 2;
        else strLength += 1;
    }
    return strLength;
}
//根据指定的字节数截取字符串
String.prototype.cutString = function (cutLength, withEllipsis) {
    if (!cutLength) {
        cutLength = this.countLength();
    }
    var strLength = 0;
    var cutStr = "";
    if (cutLength > this.countLength()) {
        cutStr = this;
    } else {
        for (var i = 0; i < this.length; i++) {
            if (this.charAt(i) > '~') {
                strLength += 2;
            } else {
                strLength += 1;
            }
            if (strLength >= cutLength) {
                cutStr = this.substring(0, i + 1);
                if (withEllipsis) {
                    cutStr += "...";
                }
                break;
            }
        }
    }
    return cutStr;
};
//去掉所有的html标记
String.prototype.cutHTML = function () {
    return this.replace(/<[^>]+>/g, "");
};
//html 转义
String.prototype.SpecialCharacters = function () {
    return this.replace(/"/g, "&quot;").replace(/'/g, "&acute;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
}
//去除script标签 ,Raven Added
String.prototype.CutScript = function () {
    return this.replace(/<script>/gi, "&lt;script&gt;").replace(/<\/script>/gi, "&lt;/script&gt;");
}
String.prototype.toArray = function (str) {
    if (this.indexOf(str) != -1) {
        return this.split(str);
    } else {
        if (this != '') {
            return [this.toString()];
        } else {
            return [];
        }
    }
};

String.prototype.replaceAll = function (reallyDo, replaceWith, ignoreCase) {
    if (!RegExp.prototype.isPrototypeOf(reallyDo)) {
        return this.replace(new RegExp(reallyDo, (ignoreCase ? "gi" : "g")), replaceWith);
    } else {
        return this.replace(reallyDo, replaceWith);
    }
};

//根据数据取得再数组中的索引
String.prototype.cutStringWithHtml = function (len, rows) {
    var str = new StringBuilder();
    var strLength = 0;
    var isA = false;
    var isPic = false;
    var isBr = false;
    var brCount = 0;
    for (var i = 0; i < this.length; i++) {
        var letter = this.substring(i, i + 1);
        var nextLetter = this.substring(i + 1, i + 2);
        var nextnextLetter = this.substring(i + 2, i + 3);

        if (letter == "<" && nextLetter == "a") { //a标签包含
            isA = true;
        } else if (letter == "<" && nextLetter == "b" && nextnextLetter == "r") { //换行符
            isBr = true;
            brCount++;
        } else if (letter == "<") { //图片
            isPic = true;
        }

        if (brCount == Number(rows)) {
            break;
        }
        str.Append(letter);
        if (!isA && !isPic && !isBr) {
            if (this.charAt(i) > '~')
                strLength += 2;
            else strLength += 1;
        }

        if (isPic) {
            if (letter == ">") {
                isPic = false;
            } else {
                continue;
            }

        }
        if (isA) {
            if (letter == ">" && this.substring(i - 1, i) == "a") {
                isA = false;
            } else {
                continue;
            }
        }

        if (isBr) {
            if (letter == ">" && this.substring(i - 1, i) == "r") {
                isBr = false;
            } else {
                continue;
            }
        }

        if (strLength >= len) {
            break;
        }
    }
    return str.toString();
};
//zp  2015/8/3 翻译中替换{0} {1}
String.prototype.format = function(args) {
    var result = this;
    if (arguments.length > 0) {
        if (arguments.length == 1 && typeof(args) == "object") {
            for (var key in args) {
                if (args[key] != undefined) {
                    var reg = new RegExp("({" + key + "})", "g");
                    result = result.replace(reg, args[key]);
                }
            }
        } else {
            for (var i = 0; i < arguments.length; i++) {
                if (arguments[i] != undefined) {
                    //var reg = new RegExp("({[" + i + "]})", "g");//这个在索引大于9时会有问题，谢谢何以笙箫的指出

                    　　　　　　　　　　　　
                    var reg = new RegExp("({)" + i + "(})", "g");
                    result = result.replace(reg, arguments[i]);
                }
            }
        }
    }
    return result;
};
//日期格式化
Date.prototype.format = function (format) {
    var o = {
        "M+": this.getMonth() + 1,
        "d+": this.getDate(),
        "h+": this.getHours(),
        "m+": this.getMinutes(),
        "s+": this.getSeconds(),
        "q+": Math.floor((this.getMonth() + 3) / 3),
        "S": this.getMilliseconds()
    }

    if (/(y+)/.test(format)) {
        format = format.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    }

    for (var k in o) {
        if (new RegExp("(" + k + ")").test(format)) {
            format = format.replace(RegExp.$1, RegExp.$1.length == 1 ? o[k] : ("00" + o[k]).substr(("" + o[k]).length));
        }
    }
    return format;
}
//日期加减
Date.prototype.addSomeDay = function (n) {
    var uom = new Date(this - 0 + n * 86400000);
    uom = (uom.getMonth() + 1) + "/" + uom.getDate() + "/" + uom.getFullYear();
    return new Date(uom);
}
//分钟加减
Date.prototype.addSomeMinutes = function (m) {
    var currentDate = new Date(this);
    currentDate.setTime(currentDate.getTime() + parseInt(m) * 60 * 1000);
    return currentDate;
}
Date.getDaysInMonth = function (year, month) {
    return [31, (Date.isLeapYear(year) ? 29 : 28), 31, 30, 31, 30, 31, 31, 30, 31, 30, 31][month];
};
Date.prototype.isLeapYear = function () {
    var y = this.getFullYear();
    return (((y % 4 === 0) && (y % 100 !== 0)) || (y % 400 === 0));
};
Date.prototype.getDaysInMonth = function () {
    return Date.getDaysInMonth(this.getFullYear(), this.getMonth());
};
Date.prototype.addMonths = function (value) {
    var n = this.getDate();
    this.setDate(1);
    this.setMonth(this.getMonth() + value);
    this.setDate(Math.min(n, this.getDaysInMonth()));
    return this;
};


var File = typeof File == 'undefined' ? {} : File;
//获取后缀名
File.GetExt = function (fileName) {
    var t = fileName.split(".");
    return t[t.length - 1];
}
File.isValid = function(fileExt) {
    var fileExts = ['.exe', '.vbs', '.bat', '.cmd', '.com'];
    if (fileExt) {
        fileExt = fileExt.toLowerCase();
        return !fileExts.contains(fileExt);
    }
    return true;
}
File.isPicture = function (fileExt) {
    var fileExts = [".jpg", ".gif", ".png", ".jpeg", ".bmp"];
    if (fileExt) {
        fileExt = fileExt.toLowerCase();
        return fileExts.contains(fileExt);
        //return fileExt == ".jpg" || fileExt == '.gif' || fileExt == '.png' || fileExt == 'jpeg';
    }
    return false;
}
File.isDocument = function (fileExt) {
    var fileExts = [".doc", ".docx", ".ppt", ".pot", ".pps", ".pptx", ".xls", ".xlsx", ".pdf", ".txt", ".mmap", ".vsd", ".psd", ".tif", ".ai", ".md", ".dwt", ".dwg", ".dws", ".dxf", ".wps", ".dps", ".dpt", ".pps", ".et", ".xmind", ".cdr", ".project", ".key", ".numbers", ".pages", ".rp", ".pub", ".cal", ".3ds", ".max", ".indd", ".mpp", ".eml", ".log", ".dotx"];
    if (fileExt) {
        fileExt = fileExt.toLowerCase();
        return fileExts.contains(fileExt);
        //return fileExt == ".doc" || fileExt == ".docx" || fileExt == ".ppt" || fileExt == ".pot" || fileExt == ".pps" || fileExt == ".pptx" || fileExt == ".xls" || fileExt == ".xlsx" || fileExt == ".pdf" || fileExt == ".txt";
    }
    return false;
}
File.isCompress = function (fileExt) {
    var fileExts = [".zip", ".rar", ".7z", ".mm", ".vsd"];
    if (fileExt) {
        fileExt = fileExt.toLowerCase();
        return fileExts.contains(fileExt);
        //return fileExt == ".zip" || fileExt == ".rar" || fileExt == ".7z";
    }
    return false;
}

//关于链接的操作命名空间
var Link = {};
//把一个字符串变成链接
Link.Filter = function (str) {
    var urlReg = /http(s)?:\/\/([\w-]+\.)+[\w-]+(\/[\w- .\/?%&=])?[^ <>\[\]*(){}\u4E00-\u9FA5]+/gi; //lio 2012-4-25 eidt   //         /^[\u4e00-\u9fa5\w]+$/;\u4E00-\u9FA5
    return str.replace(urlReg, function (m) {
        return '<a target="_blank" href="' + m + '">' + m + '</a>';
    });
}

//验证一个字符串是否包含特殊字符
RegExp.isContainSpecial = function (str) {
    var containSpecial = RegExp(/[(\,)(\\)(\/)(\:)(\*)(\')(\?)(\\\)(\<)(\>)(\|)]+/);
    return (containSpecial.test(str));
}
//验证一个字符串时候是email
RegExp.isEmail = function (str) {
    var emailReg = /^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)*\.[\w-]+$/i;
    return emailReg.test(str);
}
//验证一个字符串是否是
RegExp.isUrl = function (str) {
    var patrn = /^http(s)?:\/\/[A-Za-z0-9\-]+\.[A-Za-z0-9\-]+[\/=\?%\-&_~`@[\]\:+!]*([^<>])*$/;
    return patrn.exec(str);
}
//验证一个字符串是否是电话或传真
RegExp.isTel = function (str) {
    var pattern = /^[+]?((\d){3,4}([ ]|[-]))?((\d){3,9})(([ ]|[-])(\d){1,12})?$/;
    return pattern.exec(str);
}
//验证一个字符串是否是手机号码
RegExp.isMobile = function (str) {
    var patrn = /^(1[3-8]{1})\d{9}$/;
    return patrn.exec(str);

}
//验证一个字符串是否是传真号
RegExp.isFax = function (str) {
    var patrn = /^[+]{0,1}(\d){1,3}[ ]?([-]?((\d)|[ ]){1,12})+$/;
    return patrn.exec(str);

}
//验证一个字符串是否为外国手机号码
RegExp.isElseMobile = function (str) {
    var patrn = /^\d{5}\d*$/;
    return patrn.exec(str);
}
//验证一个字符串是否是汉字
RegExp.isZHCN = function (str) {
    var p = /^[\u4e00-\u9fa5\w]+$/;
    return p.exec(str);
}
//验证一个字符串是否是数字
RegExp.isNum = function (str) {
    var p = /^\d+$/;
    return p.exec(str);
}
//验证一个字符串是否是纯英文
RegExp.isEnglish = function (str) {
    var p = /^[a-zA-Z., ]+$/;
    return p.exec(str);
}
// 判断是否为对象类型
RegExp.isObject = function (obj) {
    return (typeof obj == 'object') && obj.constructor == Object;
}
//验证字符串是否不包含特殊字符 返回bool
RegExp.isUnSymbols = function (str) {
    var p = /^[A-Za-z0-9\u0391-\uFFE5 \.,()，。（）\-]+$/;
    return p.exec(str);
}

//密码为8-20位，必须包含字母+数字
RegExp.isPasswordRule=function(str){
    return str.length >= 8 && str.length <= 20 && (/[a-zA-Z]/.test(str) && /[0-9]/.test(str));
}


//将一个字符串用给定的字符变成数组，

Array.prototype.getIndex = function (obj) {
    for (var i = 0; i < this.length; i++) {
        if (obj == this[i] || obj.equals(this[i])) {
            return i;
        }
    }
    return -1;
}
//移除数组中的某元素
Array.prototype.remove = function (obj) {
    for (var i = 0; i < this.length; i++) {
        if (obj.equals(this[i])) {
            this.splice(i, 1);
            break;
        }
    }
    return this;
};
//判断元素是否在数组中
Array.prototype.contains = function (obj) {
    for (var i = 0; i < this.length; i++) {
        if (obj == this[i] || obj.equals(this[i])) {
            return true;
        }
    }
    return false;
};
Array.prototype.findAll = function (fn) {
    var arr = [];
    for (var i = 0, len = this.length; i < len; i++) {
        var o = this[i];
        if (fn.call(o, o)) {
            arr.push(o);
        }
    }
    return arr;
};
Array.prototype.find = function (fn) {
    var arr = [];
    for (var i = 0, len = this.length; i < len; i++) {
        var o = this[i];
        if (fn.call(o, o)) {
            arr.push(o);
            break;
        }
    }
    return arr;
};
Array.prototype.getObjIndex = function (fn) {
    var index = -1;
    for (var i = 0, len = this.length; i < len; i++) {
        var o = this[i];
        if (fn.call(o, o)) {
            index = i;
        }
    }
    return index;
};
Array.prototype.removeObj = function (fn) {
    for (var i = 0; i < this.length; i++) {
        var o = this[i];
        if (fn.call(o, o)) {
            this.splice(i, 1);
            break;
        }
    }
    return this;
};


//文本框获取焦点
function TextBoxFocus(txtBox, txtValue, lang) {
    if (lang)
        txtValue = md_lang[lang];
    if ($(txtBox).val() == txtValue) {
        $(txtBox).removeClass("Gray_c").addClass("Black");
        $(txtBox).val("");
    } else if (txtValue == 'undefined') {
        $(txtBox).removeClass("Gray_c").addClass("Black");
    }
}
//文本框失去焦点
function TextBoxUnFocus(txtBox, txtValue, lang) {
    if (lang)
        txtValue = md_lang[lang];
    if ($(txtBox).val() == "") {
        $(txtBox).removeClass("Black").addClass("Gray_c");
        $(txtBox).val(txtValue);
    }
}

//Cookies 操作
//写入
function setCookie(name, value, expire) {
    //过期时间处理
    var expireDate;
    if (!expire) {
        var nextyear = new Date();
        nextyear.setFullYear(nextyear.getFullYear() + 10);
        expireDate = nextyear.toGMTString();
    } else
        expireDate = expire.toGMTString();

    if (document.domain.indexOf('.mingdao.com') == -1) {
        document.cookie = name + "=" + escape(value) + ";expires=" + expireDate + ";path=/";
    } else {
        document.cookie = name + "=" + escape(value) + ";expires=" + expireDate + ";path=/;domain=.mingdao.com";
    }
}
//读取
function getCookie(name) {
    var arr = document.cookie.match(new RegExp("(^| )" + name + "=([^;]*)(;|$)"));
    if (arr != null) {
        return unescape(arr[2]);
    }
    return null;
}
//删除
function delCookie(name) {
    var exp = new Date();
    exp.setTime(exp.getTime() - 10000);
    if (getCookie(name) == null) {
        return;
    }
    var cval = document.cookie.match(new RegExp("(^| )" + name + "=([^;]*)(;|$)"))[2];
    if (cval != null) {
        if (document.domain.indexOf('.mingdao.com') == -1) {
            document.cookie = name + "=" + cval + ";expires=" + exp.toGMTString() + ";path=/";
        } else {
            document.cookie = name + "=" + cval + ";expires=" + exp.toGMTString() + ";path=/;domain=.mingdao.com";
        }

    }
}


//SelectSingleNode  扩展 兼容
if (!document.all) {
    var ex;
    XMLDocument.prototype.__proto__.__defineGetter__("xml", function () {
        try {
            return new XMLSerializer().serializeToString(this);
        }
        catch (ex) {
            var d = document.createElement("div");
            d.appendChild(this.cloneNode(true));
            return d.innerHTML;
        }
    });
    Element.prototype.__proto__.__defineGetter__("xml", function () {
        try {
            return new XMLSerializer().serializeToString(this);
        }
        catch (ex) {
            var d = document.createElement("div");
            d.appendChild(this.cloneNode(true));
            return d.innerHTML;
        }
    });
    XMLDocument.prototype.__proto__.__defineGetter__("text", function () {
        return this.firstChild.textContent;
    });
    Element.prototype.__proto__.__defineGetter__("text", function () {
        return this.textContent;
    });
    XMLDocument.prototype.selectSingleNode = Element.prototype.selectSingleNode = function (xpath) {
        var x = this.selectNodes(xpath);
        if (!x || x.length < 1) { return null; }
        return x[0];
    }
    XMLDocument.prototype.selectNodes = Element.prototype.selectNodes = function (xpath) {
        var xpe = new XPathEvaluator();
        var nsResolver = xpe.createNSResolver(this.ownerDocument == null ? this.documentElement : this.ownerDocument.documentElement);
        var result = xpe.evaluate(xpath, this, nsResolver, 0, null);
        var found = [];
        var res;
        while (res = result.iterateNext()) {
            found.push(res);
        }
        return found;
    }
}

//elementId 输入框ID，如：#city
//requestUrl 请求连接，如：Autocomplete.aspx
//callbackFunction 返回处理函数，如：function SelectedItem(name, value){}
//maxRows 最大呈现个数(默认10个)，如：10 可以不填充
function AutoComplete(elementId, requestUrl, callbackFunction, maxRows, filterSelf, filterUser, filterEgroup) {

    var filterMySelf = filterSelf ? 1 : 0;
    var filterUserId = filterUser ? filterUser : "";
    var filterEgroupUser = filterEgroup ? filterEgroup : "";
   
    $(elementId).each(function () {
        $(this).autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: requestUrl,
                    data: {
                        maxRows: maxRows == null ? 10 : maxRows,
                        keywords: request.term,
                        filterMySelf: filterMySelf,
                        filterUserId: filterUserId,
                        filterEgroupUser: filterEgroupUser
                    },
                    cache: false,
                    success: function (data) {
                        response($.map(data.items, function (item) {
                            return {
                                label: item.Name,
                                value: item.ID,
                                item: item
                            }
                        }));
                    }
                });
            },
            minLength: 1,
            focus: function (event, ui) {
                return false;
            },
            select: function (event, ui) {
                if (ui.item) {
                    $(this).val(ui.item.label);
                    if (callbackFunction) {
                        callbackFunction(ui.item.label, ui.item.value, ui.item.item);
                    }
                    return false;
                }
            },
            create: function (event, ui) {
                $(this).on("focus", function () {
                    $(this).autocomplete("search", " ");
                });
            }
        });
    });
}

function NewAutoComplete(elementId, requestUrl, callbackFunction, maxRows, filterSelf) {

    var filterMySelf = filterSelf ? 1 : 0;
   
    $(elementId).each(function () {
        $(this).autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: requestUrl,
                    data: {
                        maxRows: maxRows == null ? 10 : maxRows,
                        keywords: request.term,
                        filterMySelf: filterMySelf
                    },
                    cache: false,
                    success: function (data) {
                        response($.map(data.items, function (item) {
                            return {
                                label: item.Name,
                                value: item.ID,
                                name: item.FullName,
                                avatar: item.Avatar,
                                department: item.Department,
                                job: item.Job
                            }
                        }));
                    }
                });
            },
            minLength: 0,
            open: function () {
                $(this).attr('state', 'open');
            },
            close: function () {
                $(this).attr('state', 'closed');
            },
            focus: function (event, ui) {
                $(this).val(ui.item.name);
                return false;
            },
            select: function (event, ui) {
                if (ui.item) {
                    $(this).val(ui.item.name);
                    if (callbackFunction) {
                        callbackFunction(ui.item.name, ui.item.value);
                    }
                    return false;
                }
            }
        }).focus(function (event, ui) {
            if ($(this).attr('state') != 'open' && $(this).val().trim() == "") {
                $(this).autocomplete("search");
            }
        }).data("autocomplete")._renderItem = function (ul, item) {
            ul.removeClass("ui-widget-content").addClass("autocomplete-content");
            return $("<li></li>")
                .data("item.autocomplete", item)
                .append('<a><div class="item"><div class="Left icon"><img src="' + item.avatar + '" /></div><div class="limitWidth ThemeColor3">' + item.name + '</div><div class="limitWidth mRight10 mLeft10">' + item.department + '</div><div class="limitWidth">' + item.job + '</div><div class="Clear"></div></div></a>')
                .appendTo(ul);
        };
    });
}

//requestUrl 请求连接，如：GetAjaxValue.aspx
//requestType 请求类型，如：GET、POST、JSON
//requestData 请求传递数据，如：name=mytest&psd=meihua
//callbackFunction 返回处理函数，如：function SelectedItem(data){}
//loadingElementId 请求时呈现图片元素ID，如：#city 可以不填充
function AjaxRequest(requestUrl, requestType, requestData, callbackFunction, loadingElementId) {
    var queueItem = requestUrl;
    if (requestData) {
        if (typeof(requestData) == "String") {
            queueItem = queueItem + "&" + requestData;
        } else {
            for (var name in requestData) {
                queueItem = queueItem + "&" + name + "=";
                queueItem = queueItem + requestData[name];
            }
        }
    }
    if (md.global.AjaxRequestQueue.contains(queueItem)) {
        return;
    } else {
        md.global.AjaxRequestQueue.push(queueItem);
    }
    if (loadingElementId != null && loadingElementId != '') $(loadingElementId).html('<img src="AjaxLoading.gif">');
    if (requestUrl.indexOf('?') > -1) {
        requestUrl = requestUrl + '&';
    } else {
        requestUrl = requestUrl + '?';
    }
    requestUrl = requestUrl + 'rt=' + new Date().getTime();
    if (requestType != null && requestType != '' && requestType.toUpperCase() != 'JSON') {
        $.ajax({
            url: requestUrl,
            type: requestType,
            data: requestData,
            cache: false,
            error: function () {
                if (md.global.AjaxRequestQueue.contains(queueItem)) {
                    md.global.AjaxRequestQueue.remove(queueItem);
                }
            },
            success: function (data) {
                if (md.global.AjaxRequestQueue.contains(queueItem)) {
                    md.global.AjaxRequestQueue.remove(queueItem);
                }
                if (loadingElementId != null && loadingElementId != '') {
                    $(loadingElementId).html('');
                }
                callbackFunction(data);
            }
        });
    } else {
        $.ajax({
            url: requestUrl,
            data: requestData,
            cache: false,
            error: function () {
                if (md.global.AjaxRequestQueue.contains(queueItem)) {
                    md.global.AjaxRequestQueue.remove(queueItem);
                }
            },
            success: function (data) {
                if (md.global.AjaxRequestQueue.contains(queueItem)) {
                    md.global.AjaxRequestQueue.remove(queueItem);
                }
                if (loadingElementId != null && loadingElementId != '') {
                    $(loadingElementId).html('');
                }
                callbackFunction(data);
            }
        });
    }
}

/** 通用请求 */
(function ($) {
    /**
     * 根据错误码 / HTTP状态码获取错误信息
     * @param  {Number} statusCode 错误码或 HTTP 状态码
     * @return {String}            错误信息
     */
    function getErrorMessageByCode(statusCode) {
        if(statusCode >= 400 && statusCode < 500) {
            if (statusCode == 401) {
                return '您可能未登录或登录超时，请先登录';
            } else if (statusCode == 403) {
                return '您的帐号没有足够的权限';
            } else if (statusCode == 404) {
                return '您请求的页面不存在';
            } else if (statusCode == 405) {
                return '您发起的请求方法不能被用于请求相应的资源';
            } else if (statusCode == 413 ) {
                return '您的请求因数据量过大而不被支持，请联系明道支持';
            } else if (statusCode == 414 ) {
                return '您的请求因 URL 过长而不被支持，请联系明道支持';
            } else if (statusCode == 421 ) {
                return '您发起的请求过于频繁，请稍后再试';
            } else {
                return '服务器无法理解该请求，请联系明道支持';
            }
        }
        if(statusCode >= 500) {
            if (statusCode == 501) {
                return '服务端不支持此方法';
            } else if (statusCode == 502) {
                return '上游服务器发生异常';
            } else if (statusCode == 503) {
                return '服务临时不可用，请稍后重试';
            } else if (statusCode == 504) {
                return '服务超时，请稍后重试';
            } else if (statusCode == 505) {
                return '服务器不支持您的 HTTP 版本';
            } else {
                return '服务端发生错误';
            }
        }
    }

    /** @type {Object} ajax 请求队列 */
    var ajaxQueue = $({});
    /** @type {Object} 正在请求中的 queueName */
    var requesting = {};

    /**
     * 请求 Ajax API 接口
     * @param  {String} controllerName 模块名称
     * @param  {String} actionName     操作名称
     * @param  {Object} paramObj       请求参数
     * @param  {Object} options        额外配置
     * @param  {Boolean} options.silent 发生错误时不弹出提示
     * @param  {String} options.method HTTP 请求方法，默认为 POST
     * @return {Promise}               返回结果的 promise
     */
    function requestApi(controllerName, actionName, paramObj, options) {
        var ajaxOptions = (options && options.ajaxOptions) || {};
        if(options && options.method) { ajaxOptions.type = options.method; }
        paramObj = paramObj || {};

        for (var key in paramObj) {
            var val = paramObj[key];
            if (typeof val === 'function') { val = val(); }
            if (val && typeof val === 'object') { val = JSON.stringify(val); }
            paramObj[key] = val;
        }

        var alert = (options && options.silent)
            ? function() {}
            : function(msg, level) {
                level = level || 3;
                window.alert(msg, level);
            };

        var ajax;
        var dfd = $.Deferred();
        var promise = dfd.promise();

        function doRequest (next) {
            requesting[queueName] = true;
            ajax = $.ajax($.extend({
                url: '/api/services/app/'
                    + encodeURIComponent(controllerName)
                    + '/'
                    + encodeURIComponent(actionName),
                type: 'POST',
                cache: false,
                data: JSON.stringify(paramObj),
                dataType: 'json',
                contentType: 'application/json'
            }, ajaxOptions));
            ajax.then(undefined, function(jqXHR, textStatus) {
                var errorCode, errorMessage;
                if(jqXHR.status === 0) {
                    errorCode = 0;
                    errorMessage = '请求服务器失败，请检查您的网络';
                } else if (jqXHR.status < 200 || jqXHR.status > 299) {
                    errorCode = jqXHR.status;
                    errorMessage = getErrorMessageByCode(jqXHR.status) || '发生未知错误，请联系明道支持';
                }

                if(jqXHR.responseText) {
                  try {
                    error = JSON.parse(jqXHR.responseText).error;
                  } catch (jsonError) {
                    try {
                      var textErrorMessage = $(jqXHR.responseText).find('#textErrorMessage').val();
                      if (textErrorMessage) { /*TODO: 处理服务端返回的错误信息*/ }
                    } catch (htmlError) { void 0; }
                  }
                }

                if(errorMessage && textStatus !== 'abort') { alert(errorMessage); }
                return $.Deferred().reject({
                    errorCode: errorCode,
                    errorMessage: errorMessage
                });
            }).then(function(res) {
                var errorCode, errorMessage;
                if(typeof res !== 'object') {
                    errorCode = -1;
                    errorMessage = '解析返回结果错误，请联系明道支持';
                } else if (res.exception) {
                    errorCode = res.state;
                    errorMessage = res.exception;
                } else {
                    return res;
                }
                alert(errorMessage || '未知错误，请联系明道支持');
                return $.Deferred().reject({
                    errorCode: errorCode,
                    errorMessage: errorMessage
                });
            }).then(dfd.resolve).fail(dfd.reject).always(function(){
                if(next) { next(); }
                if(!ajaxQueue.queue(controllerName).length) {
                    requesting[queueName] = false;
                }
            });
        }

        var queueName = controllerName + '.' + actionName;
        ajaxQueue.queue(queueName, doRequest);

        promise.abort = function( statusText ) {
            // proxy abort to the ajax if it is active
            if ( ajax ) {
                return ajax.abort(statusText).always(function(){
                    dfd.reject(1);
                    return promise;
                });
            }
            // if there wasn't already a ajax we need to remove from queue
            var queue = ajaxQueue.queue(queueName),
                index = $.inArray( doRequest, queue );
            if ( index > -1 ) {
                queue.splice( index, 1 );
            }
            // and then reject the deferred
            dfd.reject(1);
            return promise;
        };

        if(!requesting[queueName]) {
            ajaxQueue.dequeue(queueName);
        }

        return promise;
    };

    requestApi.abortAll = function() {
        ajaxQueue.clearQueue();
        requesting = {};
    };

    $.api = requestApi;
})(jQuery);

/**
 * 订阅发布模式，用于Chat和PageHead的数据传递
 */
(function($) {
    var o = $({});

    $.subscribe = function() {
        o.on.apply(o, arguments);
    };

    $.unsubscribe = function() {
        o.off.apply(o, arguments);
    };

    $.publish = function() {
        o.trigger.apply(o, arguments);
    };

}(jQuery));


