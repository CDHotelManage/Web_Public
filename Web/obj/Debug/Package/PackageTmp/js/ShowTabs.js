function ShowTabs(url, title) {
    // 关闭当前
    var jq = top.jQuery;
    if (jq('#tabs').tabs('exists', title)) {
        jq('#tabs').tabs('select', title);
    }
    else {
        jq('#tabs').tabs('add', {
            title: title,
            content: createFrame(url),
            closable: true
        });
    }
}

function createFrame(url) {
    var s = '<iframe scrolling="auto" frameborder="0"  src="' + url + '" style="width:100%;height:100%"></iframe>';
    return s;
}