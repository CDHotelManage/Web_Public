define(function (require, exports, module) {
  var DEFAULTS = {
    isChat: true,
    element: null,
    reloadEventToSubScribe: 'SMALL_BELL_RELOAD',
    callback: null,
  };
  var util = require('util');
  var Util = require('../util');
  var doT = require('doT');
  var DICT = (function () {
    var dict = {};
    dict[dict['user'] = 1] = 'user';
    dict[dict['group'] = 2] = 'group';
    dict[dict['system'] = 3] = 'system';
    dict[dict['post'] = 4] = 'post';
    dict[dict['calendar'] = 5] = 'calendar';
    dict[dict['task'] = 6] = 'task';
    dict[dict['knowledge'] = 7] = 'knowledge';
    dict[dict['offical'] = 100] = 'offical';
    return dict;
  }());
  var TYPENAMES = {
    'system': md_lang.TB0801009 || '系统',
    'post': md_lang.TB0801010 || '动态',
    'calendar': md_lang.TB0801012 || '日程',
    'task': md_lang.TB0801011 || '任务',
    'knowledge': md_lang.TB0801013 || '知识',
  };

  var SmallBellCount = Util.smallBellCount();

  var SmallBell = function (opts) {
    this.options = $.extend({}, DEFAULTS, opts);

    this.init();
  };

  require('poshytip');
  require('./style.css');
  require('nanoScroller');

  $.extend(SmallBell.prototype, {
    init: function () {
      var _this = this;
      var options = this.options;
      this.$element = $(options.element);
      // 是否有未读消息
      options.hasUnRead = SmallBellCount.getState();
      this.$element.poshytip('update', function (updateCallback) {
        if (options.hasUnRead) {
          _this.getMessages()
            .done($.proxy(_this.render, _this, updateCallback));
        } else {
          setTimeout(function () {
            _this.render(updateCallback, []);
          }, 0);
        }
        return LoadDiv();
      }, true);
    },

    bindEvent: function () {
      var _this = this;
      var options = this.options;
      var $box = _this.$box;
      var $appLayer = $box.find('.appMsgLayer');

      $box.on('click', function (e) {
        e.stopPropagation();
      });

      $box.on('click', '.iconMessageIgnore', function (event) {
        var $this = $(this);
        var $message = $this.closest('.messageLine');
        var typeID = $message.data('type');
        var messageFrom = $message.data('messagefrom');

        if (_this.options.isChat) {
          $.publish('CROSS_ACTIONS_CLEAN_CONTACT_UNREAD', {
            type: typeID,
            id: messageFrom,
          });
          _this.removeMessage($message);
        } else {
          _this.ignoreMessage(typeID, messageFrom, $message);
        }
        event.stopPropagation();
      });

      $box.on('click', '.infoNavigation', function () {
        $appLayer.toggleClass('Hidden');
      });

      $box.on("click", '.informationOverlook', function (e) {
        e.stopPropagation();
        var $messages = _this.$box.find('.informationList').children();
        // 取消全部消息 用socket
        _this.clearAllMessage();
        _this.removeMessage($messages);
      });

      $box.on('click', '.messageLine .messageLink', function () {
        var $message = $(this).closest('.messageLine');
        var messageType = $message.data('type');
        var messageFrom = $message.data('messagefrom');
        _this.readMessage(messageType, messageFrom);
        _this.removeMessage($message);
        if (options.isChat) {
          return false;
        }
      });

      $appLayer.on('click', '.aNLCloseLayer', function () {
        $appLayer.addClass('Hidden');
      });

      $appLayer.on('click', '.appListItem .appLink', function () {
        var messageType = $(this).closest('.appListItem').data('type');
        _this.readMessage(messageType, DICT[messageType]);
        if (options.isChat) {
          return false;
        }
      });

      $.subscribe(_this.options.reloadEventToSubScribe, function () {
        if ($box.is(':visible')) {
          _this.getMessages()
            .done($.proxy(this.buildMsgList, this));
        }
      });
    },

    getMessages: function () {
      var _this = this;
      var dfd = $.Deferred();
      var promise = dfd.promise();
      if (_this.ajaxReq) {
        _this.ajaxReq.abort();
      }
      _this.ajaxReq = $.ajax({
        url: config.HTTP_SERVER + '/unread_notification',
        data: {
          pss_id: getCookie('md_pss_id'),
        },
        dataType: 'jsonp',
        jsonp: 'cb',
      });

      _this.ajaxReq.then(function (data) {
        if (data.length <= 0) {
          _this.clearAllMessage();
        }
        dfd.resolve(data);
      });

      return promise;
    },

    render: function (updateCallback, data) {
      var _this = this;
      $.each(data, function (i, o) {
        if (o.msg.con) {
          o.msg.con = util.htmlDecodeReg(o.msg.con);
        }
        if (o.time) {
          o.time = createTimeSpan(o.time);
        }
      });
      // messageType
      data.TYPES = DICT;
      data.TYPENAMES = TYPENAMES;
      data.inboxTypes = ['system', 'post', 'task', 'calendar', 'knowledge'];
      data.isChat = this.options.isChat;
      // init
      var html = _this.buildHtml(data, false);
      this.$box = $(html);
      updateCallback(_this.$box);
      this.updateNano();
      // rebind on new DOM
      this.bindEvent();
    },

    updateNano: function () {
      this.$nano = this.$nano || this.$box.find('.nano');
      this.$nano.nanoScroller({
        flash: true,
      });
    },

    // build html template
    buildHtml: function (data, isRebuild) {
      data.isRebuild = !!isRebuild;
      return doT.template(require("./tpl/smallBellMessageLayer.html"))(data);
    },

    // update messageList
    buildMsgList: function (data) {
      var _this = this;
      var listHtml = _this.buildHtml(data, true);
      _this.$box.find('.messageList').html(listHtml);
    },

    readMessage: function (type, id) {
      var _this = this;
      var options = _this.options;
      if (options.isChat && type) {
        // chat active SessionTab
        $.publish('CROSS_ACTIONS_ACTIVATE_CONTACT', {
          type: type,
          id: id,
        });
      } else {
        _this.$element.poshytip('hide');
      }
    },

    removeMessage: function ($messages) {
      var _this = this;
      // animation
      $messages.each(function (i) {
        $(this).animate({
          left: -$(this).width() + 'px',
        }, 300 + i * 30, function () {
          $(this).remove();
          var $list = _this.$box.find('.informationList');
          if ($list.children().length === 0) {
            $list.remove();
          }
        });
        _this.updateNano();
        var _num = $(this).find('.unreadTip').data('unread') || 0;
        // update smallbell count
        SmallBellCount.updateNum(-_num);
        // no message toggle two button
        if (SmallBellCount.getNum().modelCount === 0) {
          _this.$box.find('.infoNavigation').show();
          _this.$box.find('.informationOverlook').hide();
        }
      });
    },

    ignoreMessage: function (typeID, messageFrom, $message) {
      if (typeID === DICT['user'] || typeID === DICT['group']) {
        IM.socket.emit('clear unread', {
          type: typeID,
          id: messageFrom,
        }, $.proxy(this.ignoreMessageHandler, this, $message));
      } else {
        IM.socket.emit('clear notification', {
          type: DICT[typeID],
          value: 0,
          clear: true,
        }, $.proxy(this.ignoreMessageHandler, this, $message));
      }
    },

    ignoreMessageHandler: function ($message, err, data) {
      if (!err) {
        this.removeMessage($message);
      } else {
        alert('忽略失败，请稍候再试', 2);
      }
    },

    clearAllMessage: function () {
      if (this.options.isChat) {
        $.publish('CROSS_ACTIONS_CLEAN_ALL_UNREAD');
      } else {
        IM.socket.emit('clear all unread');
      }
    },
  });


  module.exports = SmallBell;
});
