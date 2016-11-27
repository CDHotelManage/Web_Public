define(function (require, exports, module) {
  var qs = require('querystring');
  /**
   * @exports util
   * @author sin
   * @desc 业务无关公用方法
   */
  var Util = {};

  /**
   * 获取URL里的参数，返回一个参数对象
   * @param  {string} str url中 ? 之后的部分，可以包含 ?
   * @return {object}
   */
  Util.getRequest = function (str) {
    str = str || location.search;
    str = str.replace(/^\?/, '').replace(/#.*$/, '').replace(/(^&|&$)/, '');
    return qs.parse(str);
  };

  /**
   * 替换Url某个参数的值
   * @param  {string} url url
   * @param  {string} key 参数名
   * @param  {string} val 要替换的参数值
   * @return {string}     替换后的url
   */
  Util.replaceUrlParamVal = function (url, key, val) {
    var re = new RegExp('(' + key.replace(/[\-\[\]\/\{\}\(\)\*\+\?\.\\\^\$\|]/g, '\\$&') + '=)([^&]*)', 'g');
    return url.replace(re, key + '=' + encodeURIComponent(val));
  };

  /** 网络管理模块获取URL里的参数 返回[control,action,projectId,各模块其他参数] */
  Util.getAdminRequest = function () {
    var reqArray = location.pathname.split('/');
    var controlIndex = $.inArray('admin', reqArray);
    var arr = [];
    reqArray.forEach(function (item, index) {
      if (index >= controlIndex) {
        arr.push(item);
      }
    });
    return arr;
  };

  /** 获取当前浏览器名称 */
  Util.getExplorer = function () {
    var explorer = window.navigator.userAgent;
    if (explorer.indexOf('MSIE') >= 0) {
      return ('ie');
    } else if (explorer.indexOf('Firefox') >= 0) {
      return ('Firefox');
    } else if (explorer.indexOf('Chrome') >= 0) {
      return ('Chrome');
    } else if (explorer.indexOf('Opera') >= 0) {
      return ('Opera');
    } else if (explorer.indexOf('Safari') >= 0) {
      return ('Safari');
    }
  };

  /**
   * 格式化数字，10 及以上显示 9+，100 及以上显示 99+
   * @param  {number|string} num
   * @return {string}
   */
  Util.reNumString = function (num) {
    num = parseInt(num, 10);
    var reStr;
    if (num > 0 && num < 10) {
      reStr = num.toString();
    } else if (num >= 10 && num < 100) {
      reStr = '9+';
    } else if (num >= 100) {
      reStr = '99+';
    }

    return reStr;
  };

  /** 去除html标签 */
  Util.removeHTMLTag = function (str) {
    str = str.replace(/<\/?[^>]*>/g, ''); // 去除HTML tag
    str = str.replace(/[ | ]*\n/g, '\n'); // 去除行尾空白
    str = str.replace(/\n[\s| | ]*\r/g, '\n'); // 去除多余空行
    str = str.replace(/&nbsp;/ig, ''); // 去掉&nbsp;
    return str;
  };

  /** 判断当前设备是否为移动端 */
  Util.browserIsMobile = function () {
    var sUserAgent = navigator.userAgent.toLowerCase();
    var bIsIpad = sUserAgent.match(/ipad/i) == 'ipad';
    var bIsIphoneOs = sUserAgent.match(/iphone os/i) == 'iphone os';
    var bIsMidp = sUserAgent.match(/midp/i) == 'midp';
    var bIsUc7 = sUserAgent.match(/rv:1.2.3.4/i) == 'rv:1.2.3.4';
    var bIsUc = sUserAgent.match(/ucweb/i) == 'ucweb';
    var bIsAndroid = sUserAgent.match(/android/i) == 'android';
    var bIsCE = sUserAgent.match(/windows ce/i) == 'windows ce';
    var bIsWM = sUserAgent.match(/windows mobile/i) == 'windows mobile';

    return bIsIpad || bIsIphoneOs || bIsMidp || bIsUc7 || bIsUc || bIsAndroid || bIsCE || bIsWM;
  };

  /** 获取光标位置 */
  Util.getCaretPosition = function (ctrl) {
    var sel, sel2;
    var caretPos = 0;
    if (document.selection) { // IE Support
      ctrl.focus();
      sel = document.selection.createRange();
      sel2 = sel.duplicate();
      sel2.moveToElementText(ctrl);
      caretPos = -1;
      while (sel2.inRange(sel)) {
        sel2.moveStart('character');
        caretPos++;
      }
    } else if (ctrl.setSelectionRange) { // W3C
      ctrl.focus();
      caretPos = ctrl.selectionStart;
    }
    return (caretPos);
  };

  /** 设置光标位置 */
  Util.setCaretPosition = function (ctrl, caretPos) {
    if (ctrl.createTextRange) {
      var range = ctrl.createTextRange();
      range.move('character', caretPos);
      range.select();
    } else if (caretPos) {
      ctrl.focus();
      ctrl.setSelectionRange(caretPos, caretPos);
    } else {
      ctrl.focus();
    }
  };

  /** 光标定位到内容最后 */
  Util.inputFocus = function (element) {
    var length = element.value.length;
    if (element.setSelectionRange) {
      element.focus();
      element.setSelectionRange(length, length);
    } else if (element.createTextRange) {
      var range = element.createTextRange();
      range.collapse(true);
      range.moveEnd('character', length);
      range.moveStart('character', length);
      range.select();
    }
  };

  /**
   * 保留小数点后几位，四舍五入
   * @param  {number} src 源数字
   * @param  {number} pos 保留位数
   * @return {number}
   * @see {@link https://stackoverflow.com/questions/20701029/rounding-issue-in-math-round-tofixed}
   */
  Util.formatNumber = function (src, pos) {
    return Math.round(src * Math.pow(10, pos)) / Math.pow(10, pos);
  };

  /**
   * 根据文件名获取相应图标的字体图标 css 类名
   * @param  {string} filename 文件名
   * @return {string}          字体图标 css 类名
   */
  Util.getAttachmentIcon = function (filename) {
    var ext = File.GetExt(filename).toLowerCase();
    var iconClass = 'icon-';
    switch (ext) {
      case '7z':
        iconClass += '7z';
        break;
      case 'rar':
        iconClass += 'rar';
        break;
      case 'zip':
        iconClass += 'zip';
        break;
      case 'pdf':
        iconClass += 'pdf';
        break;
      case 'txt':
        iconClass += 'txt';
        break;
      case 'ppt':
      case 'pptx':
        iconClass += 'ppt';
        break;
      case 'xls':
      case 'xlsx':
        iconClass += 'xls';
        break;
      case 'doc':
      case 'docx':
        iconClass += 'word';
        break;
      case 'vsd':
        iconClass += 'vsd';
        break;
      case 'mmap':
        iconClass += 'mmap';
        break;
      default:
        iconClass += 'defaultFile';
        break;
    }
    return iconClass;
  };

  /**
   * 根据文件名获取相应图标的背景图片 css 类名
   * @param  {string} filename 文件名
   * @return {string}          背景图片 css 类名
   */
  Util.getClassNameByExt = function (filename) {
    if (filename === false) {
      return 'fileIcon-folder';
    }
    var ext = filename ? File.GetExt(filename).toLowerCase() : '';
    var extType = null;
    switch (ext && ext.toLowerCase()) {
      case 'png':
      case 'jpg':
      case 'jpeg':
      case 'gif':
      case 'bmp':
        extType = 'img';
        break;
      case 'xls':
      case 'xlsx':
        extType = 'excel';
        break;
      case 'doc':
      case 'docx':
      case 'dot':
        extType = 'word';
        break;
      case 'ppt':
      case 'pptx':
      case 'pps':
        extType = 'ppt';
        break;
      case 'mmap':
      case 'xmind':
      case 'cal':
      case 'zip':
      case 'rar':
      case '7z':
      case 'pdf':
      case 'txt':
      case 'ai':
      case 'psd':
      case 'vsd':
        extType = ext.toLowerCase();
        break;
      default:
        extType = 'doc';
    }
    return 'fileIcon-' + extType;
  };

  /**
   * 将文件大小转换成可读的格式，即 123.4 MB 这种类型
   * @param  {Number} size  文件以 byte 为单位的大小
   * @param  {Array}  accuracy 小数点后保留的位数
   * @param  {String} space 数字和单位间的内容，默认为一个空格
   * @param  {Array}  units 自定义文件大小单位的数组，默认为 ['B', 'KB', 'MB', 'GB', 'TB']
   * @return {String}       可读的格式
   */
  Util.formatFileSize = function (size, accuracy, space, units) {
    units = units || ['B', 'KB', 'MB', 'GB', 'TB'];
    space = space || ' ';
    accuracy = (accuracy && typeof (accuracy) === 'number' && accuracy) || 0;
    if (!size) { return '0' + space + units[0]; }
    var i = Math.floor(Math.log(size) / Math.log(1024));
    return ((size / Math.pow(1024, i)).toFixed(accuracy) * 1) + space + units[i];
  };

  /**
   * 编码 html 字符串，只编码 &<>"'/
   * @param  {string} str
   * @return {string}
   */
  Util.htmlEncodeReg = function (str) {
    var encodeHTMLRules = { '&': '&#38;', '<': '&lt;', '>': '&gt;', '"': '&#34;', "'": '&#39;', '/': '&#47;' };
    var matchHTML = /&(?!#?\w+;)|<|>|"|'|\//g;
    return str ? str.toString().replace(matchHTML, function (m) { return encodeHTMLRules[m] || m; }) : '';
  };
  /**
   * 解码 html 字符串，只解码 '&#38;','&amp;','&#60;','&#62;','&#34;','&#39;','&#47;','&lt;','&gt;','&quot;'
   * @param  {string} str
   * @return {string}
   */
  Util.htmlDecodeReg = function (str) {
    var decodeHTMLRules = { '&#38;': '&', '&amp;': '&', '&#60;': '<', '&#62;': '>', '&#34;': '"', '&#39;': "'", '&#47;': '/', '&lt;': '<', '&gt;': '>', '&quot;': '"' };
    var matchHTML = /&#(38|60|62|34|39|47);|&(amp|lt|gt|quot);/g;
    return str ? str.toString().replace(matchHTML, function (m) { return decodeHTMLRules[m] || m; }) : '';
  };

  Util.createXml = function (str) {
    var xmlDom;
    try {
      xmlDom = new ActiveXObject('Microsoft.XMLDOM'); // eslint-disable-line no-undef
      xmlDom.loadXML(str);
      return xmlDom;
    } catch (e) {
      xmlDom = new DOMParser();
      return xmlDom.parseFromString(str, 'text/xml');
    }
  };

  /**
   * input不允许输入中文
   * @param  {external:$} obj input 对象
   */
  Util.inputDisabledChinese = function ($obj) {
    $obj.on({
      keyup: function () {
        var pos = Util.getCaretPosition($obj[0]);
        var orgValue = $obj.val();
        $obj.val(orgValue.replace(/[^\x00-\x80]/gi, ''));
        pos = pos - Math.ceil(orgValue.length - $obj.val().length);
        Util.setCaretPosition($obj[0], pos);
      },
    });
  };

  /**
   * 返回表示“加载中”的 HTML 字符串
   * @param {string} modifier 加载圈圈的大小，big 或 small 或 middle，默认 middle
   */
  Util.loadDiv = function (modifier) {
    var size;
    if (modifier === 'big') {
      size = 36;
    } else if (modifier === 'small') {
      size = 16;
    } else {
      modifier = 'middle';
      size = 24;
    }
    var strokeWidth = Math.floor(size / 8);
    var r = Math.floor(size / 2);
    var cx = r + strokeWidth;
    var cy = cx;
    return '<div class="TxtCenter TxtMiddle mTop10 mBottom10 w100"><div class="divCenter MdLoader MdLoader--' + modifier + '"><svg class="MdLoader-circular"><circle class="MdLoader-path" stroke-width="' + strokeWidth + '" cx="' + cx + '" cy="' + cy + '" r="' + r + '"></circle></svg></div></div>';
  };

  /**
   * 返回表示“数据为空”的 HTML 字符串
   * @param {string} msg 要显示的内容
   */
  Util.nullDiv = function (msg) {
    var tip = md_lang.admin_stats_cost_blankstate;
    if (msg) {
      tip = msg;
    }
    return '<div class="TxtCenter mTop10">' + tip + '</div>';
  };

  var glintInterval = {};
  glintInterval.curInterval = null;
  glintInterval.count = 0;
  /**
   * 要求非空的输入框没有输入内容时，进行闪烁提醒
   * @param {string|Element|external:$} divID 要提醒的元素
   */
  Util.nullTextbox = function (divID) {
    var $el = $(divID);
    if ($el.children().length) {
      var bgColor = $el.css('backgroundColor');
      $el.children().css('backgroundColor', bgColor);
    }
    if (glintInterval.curInterval) {
      clearInterval(glintInterval.curInterval);
      glintInterval.curInterval = null;
    }
    glintInterval.curInterval = setInterval(function () {
      Util.glint($el);
    }, 300);
  };

  /**
   * 对象背景色闪烁
   * @deprecated 使用 utils 模块中的方法
   * @param {string|Element|external:$} divID 要提醒的元素
   */
  Util.glint = function glint(divID) {
    glintInterval.count++;
    try {
      var $el = $(divID);
      $el.children().andSelf($el).add($el.find(':text'))
      .animate({
        backgroundColor: '#ffcccc',
      }, 180)
      .animate({
        backgroundColor: '#ffffff',
      }, 180);
    } catch (e) { }
    if (glintInterval.count % 2 === 0) {
      clearInterval(glintInterval.curInterval);
      glintInterval.curInterval = null;
    }
  };

  /**
   * 判断元素是否在视口中
   * @param  {Element}  el 原生元素对象
   * @return {Boolean}    是否在视口中
   */
  Util.isElementInViewport = function isElementInViewport(el) {
    if (typeof window.jQuery === 'function' && el instanceof window.jQuery) {
      el = el[0];
    }
    var rect = el.getBoundingClientRect();
    return (
      rect.top >= 0 &&
      rect.left >= 0 &&
      rect.bottom <= (window.innerHeight || document.documentElement.clientHeight) && /* or $(window).height() */
      rect.right <= (window.innerWidth || document.documentElement.clientWidth) /* or $(window).width() */
    );
  };

  /**
   * 格式化时间显示
   * @param {string} dateStr 具体的日期字符串，格式为 yyyy-MM-dd HH:mm:ss
   * @returns {string} 相对的时间，如15分钟前
   */
  Util.createTimeSpan = window.createTimeSpan; // TODO: 移除 global 里的

  module.exports = Util;
});
