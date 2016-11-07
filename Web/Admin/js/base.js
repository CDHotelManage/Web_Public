/*止JS为公共JS方法*/

/*弹出窗体关闭10 11 12 1*/
function Close() {
    parent.Window_Close();
}

/*创建一个新的Tabs*/
function createFrame(url) {
    var s = '<iframe scrolling="auto" frameborder="0"  src="' + url + '" style="width:100%;height:100%"></iframe>';
    return s;
}

function AddTabs(title,url) {
    var jq = top.jQuery;
    if (jq('#tabs').tabs('exists', title)) {
        jq("#tabs").tabs("close", title);
    }
    jq('#tabs').tabs('add', {
        title: title,   
        content: createFrame(url),
        closable: true
    });
}

/*关闭一个tabs*/
function clo(title) {
    var jq = top.jQuery;
    jq("#tabs").tabs("close", title);
}


//新建一个窗体
function showMyWindow(title, href, width, height, modal, minimizable, maximizable, close) {
    
    if ($('.dd').length <= 0) {
        $("body").append("<div class='dd'></div>");
    }
    $('.dd').window({
        title: title,
        width: width === undefined ? 600 : width,
        height: height === undefined ? 400 : height,
        content: '<iframe scrolling="no" frameborder="0"  src="' + href + '" style="width:100%;height:98%;"></iframe>',
        modal: modal === undefined ? true : modal,
        minimizable: minimizable === undefined ? false
                : minimizable,
        maximizable: maximizable === undefined ? false
                : maximizable,
        shadow: false,
        zIndex : 9999,
        cache: false,
        closed: false,
        collapsible: false,
        resizable: false,
        loadingMessage: '正在加载数据，请稍等片刻......',
        onClose: close
    });
}

//eausyui 弹出提示框
function ShowAlert(title, msg, icon,fn) {
    $.messager.alert(title, msg, icon,fn);
}

//关闭窗体
function d_close() {
    $('#dd').dialog('close');
}

//公共AJAX方法
function PostMaeth(url, data, datatype, fn) { 
  if(fn)
  {
    fn();
  }
}