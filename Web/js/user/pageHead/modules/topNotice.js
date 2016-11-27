define(function(require, exports, module) {
    var TopReminder = {
        Settings: {
            fetchURL: md.global.Config.MQServers + "/notice/get?key=" + md.global.Account.accountId + "&jsoncallback=?",
            postURL: md.global.Config.MQServers + "/notice/read?key=" + md.global.Account.accountId + "&id=@id&jsoncallback=?",
            cookieName: 'closednotice',
            cookieExpire: new Date((new Date()).getTime() + 10 * 60000)
        }
    };

    TopReminder.init = function() {
        this.$reminder = $("#topReminder");
        this.getTopNotice();
        this.bindEvent();
    }

    TopReminder.bindEvent = function() {
        var $reminder = this.$reminder;
        $reminder.off('click.topNotice').on('click.topNotice', '.readNotice', function() {
            var id = $(this).attr("noticeID");
            $reminder.hide();
            TopReminder.readTopNotice(id);
        });

        $reminder.off('hover.topNotice').on('hover.topNotice', '.readNotice', function(event) {
            $(this).toggleClass('Bold', event.type == "mouseenter");
        });

        $reminder.off('click.topNotice').on('click.topNotice', '.closeNotice', function() {
            var id = $(this).attr("noticeID");
            $reminder.hide();
            if ($(this).prev().is('.readNotice')) {
                TopReminder.readTopNotice(id);
            }
        });
    };

    TopReminder.getTopNotice = function() {
        if (getCookie(TopReminder.Settings.cookieName) == "1") {
            return;
        }

        $.ajax({
            url: TopReminder.Settings.fetchURL,
            cache: false,
            dataType: "json",
            success: TopReminder.renderNotice
        });
    };

    TopReminder.renderNotice = function(data) {
        if (data.msg == "T") {
            if (data.id == "") {
                setCookie(TopReminder.Settings.cookieName, "1", TopReminder.Settings.cookieExpire);
                TopReminder.$reminder.hide();
                return;
            }
            var html = new StringBuilder();
            html.Append("<div class='nContent'>" + decodeURIComponent(data.notice));
            if (data.url && data.url != "http://") {
                html.Append("<a href='" + data.url + "' class='mLeft10 readNotice' noticeID='" + data.id + "' target='_blank' >了解详情</a>");
            }
            html.Append("<span class='closeNotice ThemeColor3' noticeID='" + data.id + "' title='关闭'>×</span>");
            html.Append("</div>");
            TopReminder.$reminder
                .html(html.toString())
                .show();

            $(document).trigger('mq.notice', md.global.notice = true);
            //添加小黄条的标记类
            $('html').addClass('mdTopNotice');
        }
    };

    //读取顶部推送信息
    TopReminder.readTopNotice = function(id) {
        setCookie(TopReminder.Settings.cookieName, "0"); //关闭
        $('html').removeClass('mdTopNotice');
        $.ajax({
            url: TopReminder.Settings.postURL.replace(/@id/, id),
            cache: false,
            dataType: "json",
            success: function(data) {
                if (data.msg == "T") {
                    $(document).trigger('mq.notice', md.global.notice = false);
                }
            }
        });
    };

    module.exports = TopReminder;
});