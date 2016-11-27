define(function (require, exports, module) {
  var PageHeadIM = {};
  var Router = require('./router')();
  var Util = require('./util');
  var SmallBellCount = Util.smallBellCount();
  require('socket');

  PageHeadIM.options = {
    socketReconnectCount: 0,
    socketConnected: false,
    MAX_COUNT: 10,
  };

  PageHeadIM.init = function () {
    if (Router.type !== 'chat') {
      PageHeadIM.connect();
      PageHeadIM.initEvent();
    } else {
      $.subscribe('CROSS_ACTIONS_UPDATE_BELL_UNREAD', function (event, data) {
        SmallBellCount.setNum(data.count);
      });
    }

    PageHeadIM.loadUserPostAndMessageCount();

    setInterval(function () {
      PageHeadIM.loadUserPostAndMessageCount();
    }, 20000);
  };

  PageHeadIM.connect = function () {
    if (window.IM === undefined) {
      window.IM = {};
      window.IM.socket = io.connect(config.SERVER_NAME, {
        'resource': 'mds',
        'max reconnection attempts': 100,
        'force new connection': true,
      });
    }
  };

  PageHeadIM.initEvent = function () {
    IM.socket.on('connect', function () {
      PageHeadIM.options.socketConnected = true;
      PageHeadIM.syncUnreadCount();
    });

    // socket 连接的一些监听
    // 重新连接
    IM.socket.on('reconnect', function () {
      PageHeadIM.options.socketReconnectCount = 0;
    });

    IM.socket.on('reconnecting', function () {
      // 超过重连次数，显示连接失败
      if (PageHeadIM.options.socketReconnectCount > PageHeadIM.options.MAX_COUNT) {
        return false;
      }
      PageHeadIM.connect();
    });

    // 连接失败
    IM.socket.on('error', function () {
    });

    IM.socket.on('disconnect', function () {
    });

    IM.socket.on('reconnect_failed', function () {
    });

    $.each(['new group message', 'new message', 'new offical message'], function (i, event) {
      IM.socket.on(event, function (msg) {
        // message count add 1
        PageHeadIM.increaseCount(msg);
      });
    });

    IM.socket.on('new notify', function (msg) {
      PageHeadIM.increaseCount(msg);
      PageHeadIM.onNotify(msg);
    });

    $.each(['clear unread', 'clear notification', 'session removed', 'removed from group'], function (i, event) {
      IM.socket.on(event, function () {
        PageHeadIM.syncUnreadCount();
      });
    });

    IM.socket.on('clear all unread', PageHeadIM.clearAllCount);

    IM.socket.on('leave chat', function (data) {
      window.localStorage.removeItem(md.global.Account.accountId + '_isChating');
    });
  };

  PageHeadIM.syncUnreadCount = function () {
    IM.socket.emit('all unread', {}, function (err, data) {
      SmallBellCount.setNum(data.count);
    });
  };

  // new notify hander
  PageHeadIM.onNotify = function (nfy) {
    var auth = window.Notification && Notification.permission === 'granted';
    // 同步计数
    PageHeadIM.loadUserPostAndMessageCount();
    if ((nfy.type !== 0 && nfy.type !== 1) || !nfy.msg) {
      return;
    }
    // FIXME: windows客户端不提示notification
    if (window.navigator && window.navigator.userAgent.indexOf('MDClient_Win') > -1) {
      return;
    }

    if (auth) {
      var title = '';
      var inboxType = 'post';

      if (nfy.dtype === 3) {
        inboxType = 'task';
      }

      if (nfy.type === 0) {
        title = nfy.name + '提到了您';
      } else if (nfy.type === 1) {
        title = nfy.name + '回复了您';
      }

      var notification = new Notification(title, {
        tag: 'mingdaoNotification',
        icon: 'http://upwww.mingdao.com/images/mdLogo48.jpg',
        body: (function () {
          return $('<div>').html(nfy.msg).text();
        }()),
      });

      notification.onshow = function () {
        setTimeout(function () {
          notification.close();
        }, 10000);
      };

      notification.onclick = function () {
        var origin = window.location.origin;
        if (!origin) {
          origin = window.location.protocol + "//" + window.location.hostname + (window.location.port ? ':' + window.location.port : '');
        }
        window.focus();
        window.location.href = origin + '/chat?type=' + inboxType + '&id=' + inboxType;
      };
      notification.onshow();
    }
  };

  PageHeadIM.loadUserPostAndMessageCount = function () {
    var path = md.global.Config.MQServers + "/notification/get?";
    var aid = md.global.Account.accountId;
    if (aid) {
      $.getJSON(path + 'key=' + aid + '&jsoncallback=?', function (data) {
        if (data.msg === '1') {
          // 新动态
          $(document).trigger('mq.post', data.post);

          // addresslist notice
          var $addressListNotice = $('#topbarContent .addressListEntry').find('.activeNotice');
          var count = data.addressbookmessage;
          if (count) {
            $addressListNotice.show();
            $.publish('CROSS_ACTIONS_UPDATE_ADDRESSLIST_COUNT', {
              count: count,
            });
          } else {
            $addressListNotice.hide();
          }

          // APP消息提醒图标
          var $appItemNotice = $('#topbarContent .appItem').find('.activeNotice');
          if (data.apps) {
            $appItemNotice.show()
              .parent()
              .data('newNotice', parseInt(data.apps, 10));
          } else {
            $appItemNotice.hide();
          }

          // 任务中心
          var $taskNotice = $('#topbarContent .taskTag').find('.activeNotice');
          if (data.taskcomment || data.foldercomment) {
            var taskTitle = data.taskcomment ? data.taskcomment + '条任务讨论' : '';
            var folderTitle = data.foldercomment ? data.foldercomment + '条项目讨论' : '';
            $taskNotice.show().attr('title', taskTitle + folderTitle);
          } else {
            $taskNotice.hide();
          }

          //强制退出
          if (data.removesession && data.removesession === 1) {
            require.async('modules/common/ajax/account', function (account) {
              account.clearMQSession().then(function () {
                window.location.href = '/logout';
              });
            });
          }

          // 检测当前用户的会话是否失效
          if (!getCookie('md_pss_id')) {
            setCookie('sessionFail', '1');
            window.location.href = '/login.htm';
          }
        }
      });
    }
  };

  PageHeadIM.clearAllCount = function () {
    // set count to 0
    SmallBellCount.resetNum();
    $.publish('CLOSE_PAGEHEAD_POSHYTIPS', true);
  };

  PageHeadIM.increaseCount = function (msg) {
    if (msg.sysType || msg.isPush === false || md.global.Account.accountId === msg.from || msg.type === 3) { // inboxTypes 为弱消息, 不需要加计数
      return false;
    }
    var _isCurrentChat = PageHeadIM.checkCurrentChat(msg);
    var _isChating = PageHeadIM.checkChating();

    if (!_isCurrentChat) {
      SmallBellCount.updateNum(1);
    }

    if (_isCurrentChat && !_isChating) {
      SmallBellCount.updateNum(1);
      $.publish('CLOSE_PAGEHEAD_POSHYTIPS', true);
    }
  };

  PageHeadIM.checkCurrentChat = function (msg) {
    var from = '';
    var aid = md.global.Account.accountId;
    var localData = JSON.parse(window.localStorage.getItem(aid + '_current'));
    var flag = false;

    if (msg.groupname) {
      from = msg.to; // from 为群组id
    } else {
      from = msg.from; // from 为 发送者id
    }

    if (aid === from) {
      flag = true;
    }

    flag = localData && localData.id === from;

    return flag;
  };

  PageHeadIM.checkChating = function () {
    var key = md.global.Account.accountId + '_isChating';
    var old = window.localStorage.getItem(key);
    var now = new Date().getTime();
    var flag = false;
    if (old) {
      if (now - old >= 1500) {
        window.localStorage.removeItem(key);
      } else {
        flag = true;
      }
    }
    return flag;
  };

  module.exports = PageHeadIM;
});
