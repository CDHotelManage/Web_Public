define(function (require, exports, module) {
  require('./style.css');
  require('nanoScroller');
  var doT = require('doT');
  var cacheData = null;
  var notices = null;
  var DEFAULTS = {
    element: null,
    gap: 5,
    loadingTpl: '<div class="pageHeadLoading">' + LoadDiv() + '</div>',
  };

  var ajaxPath = require('modules/common/ajax/application');

  var Applist = function (opts) {
    this.options = $.extend({}, DEFAULTS, opts);
    this.getProjectDict();
    this.init();
  };

  Applist.prototype.getProjectDict = function () {
    var options = this.options;
    var projectDict = {
      '': '个人网络',
    };
    $.each(md.global.Account.projects, function (i, project) {
      projectDict[project.projectId] = project.companyName;
    });

    options.projectsDict = projectDict;
  };

  Applist.prototype.init = function () {
    var _this = this;
    var options = this.options;
    this.$element = $(options.element);
    options.noticeApps = this.$element.data('newNotice');
    this.$element.poshytip('update', function (updateCallback) {
      _this.getApps(updateCallback);
      return options.loadingTpl;
    }, true);
  };

  Applist.prototype.getApps = function (updateCallback) {
    var _this = this;
    var options = this.options;
    var promises = [];
    notices = [];
    if (options.noticeApps || !cacheData) {
      promises.push(_this.fetchApps());
      if (options.noticeApps > 0) {
        promises.push(_this.getNoticeApps());
      }
      $.when.apply(null, promises)
        .done(function (list, noticeApps) {
          notices = noticeApps || {};
          cacheData = _this.formatData(list);
          _this.render(updateCallback, cacheData);
        });
    } else {
      setTimeout(function () {
        _this.render(updateCallback, cacheData);
      }, 0);
    }
  };

  Applist.prototype.fetchApps = function () {
    var dfd = $.Deferred();
    ajaxPath.getAccountApps({})
      .then(function (result) {
        if (result && result.success) {
          dfd.resolve(result.data);
        } else {
          dfd.reject('No DATA response');
        }
      });
    dfd.fail(function (reason) {
      alert(reason, 3);
      this.$element.poshytip('hide');
      this.$element.data('isOpen', false);
    });
    return dfd.promise();
  };

  Applist.prototype.getNoticeApps = function () {
    var dfd = $.Deferred();
    var _this = this;
    $.getJSON(md.global.Config.MQServers + '/notification/getappcount?key=' + md.global.Account.accountId + '&jsoncallback=?')
      .success(function (data) {
        var arrlist = [];
        $.each(data, function (key, arr) {
          arrlist = arrlist.concat(arr);
        });
        dfd.resolve(arrlist);
      })
      .fail(function () {
        dfd.resolve({});
      });

    dfd.always(function (arrlist) {
      if (!arrlist.length) {
        _this.$element.removeClass('activeNotice')
          .removeData('newNotice');
      }
    });
    return dfd.promise();
  };

  Applist.prototype.formatData = function (list) {
    var listData = {};
    listData.projectsDict = this.options.projectsDict;
    listData.top = list.top || [];
    listData.projects = list.projects || [];
    listData.projects.unshift({
      projectId: '',
      companyName: md_lang.TB0801031 || '个人应用',
      apps: list.account.apps || [],
      settingUrl: list.account.settingUrl,
    });
    return listData;
  };

  Applist.prototype.render = function (updateCallback, listData) {
    var html = doT.template(require('./tpl/list.html'))(listData);

    this.$list = $(html);

    this.setListHeight(updateCallback);
    this.addNotice();

    this.bindEvent();
  };

  Applist.prototype.addNotice = function () {
    var $apps = this.$list.find('.singleApp');
    var $titles = this.$list.find('.listTitle .companyName');
    var $lists = this.$list.find('.projectApplist');

    // notices = [{appid: 'c2f035c7-b8d3-4fe2-b07e-481b923ddfd3', projectid: 'b308a42b-09d2-4368-b48a-2c830715f7f6'}];

    $.each(notices, function (i, app) {
      var projectId = app.projectid || ''; // convert null to ""
      var appId = app.appid;
      $apps.filter('[data-projectid=' + projectId + '][data-appid=' + appId + ']').first().addClass('notice');
      $titles.filter('[data-projectid=' + projectId + ']').toggleClass('notice', (function () {
        return $lists.filter('[data-projectid=' + projectId + ']').find('.notice').length > 0;
      })());
    });
  };

  Applist.prototype.setListHeight = function (updateCallback) {
    var _this = this;
    var $list = _this.$list;

    updateCallback($list);
    _this.setStickListHeight();
    _this.bindNano();
  };

  Applist.prototype.bindNano = function () {
    var _this = this;
    // bind nanoScroller
    _this.$list.find('.nano')
      .nanoScroller({
        flash: true,
        preventPageScrolling: true,
      });
  };

  Applist.prototype.setStickListHeight = function () {
    var _this = this;
    var $list = _this.$list.find('.nano');
    var pageHeadApplist = $('.pageHeadApplist');
    var maxHeight = ($(window).height() - $('#topBarContent').height()) * 0.8;

    $list.nanoScroller({
      destroy: true,
    });
    $list.removeClass('nano').removeAttr('style');
    var height = $list.height();
    var deltaHeight = maxHeight - _this.$list.height();
    if (maxHeight < _this.$list.height()) {
      height = height + deltaHeight - _this.options.gap;
    }
    // restore
    $list.addClass('nano')
      .css({
        height: height,
        maxHeight: height,
      });
  };

  Applist.prototype.fixTitle = function (event, val) {
    var _this = this;
    var titles = _this.$list.find('.listTitle').filter(':visible');
    var fixedTitle = _this.$list.find('.fixedTitle');
    var projectTitles = titles.slice(1);
    if (val.position < 40) {
      fixedTitle.hide();
      return false;
    }

    for (var i = 0, len = projectTitles.length; i < len; i++) {
      var $this = projectTitles.eq(i);
      var _top = $this.position().top;
      var _list = $this.next('.listContent');
      var _height = _list.height();
      var updateFixTitle = _top + 40 >= -_height;

      if (updateFixTitle) {
        var title = $this.find('.companyName').text() || $this.text();
        fixedTitle.text(title).show();
        break;
      } else {
        fixedTitle.hide();
      }
    }
  };

  Applist.prototype.bindEvent = function () {
    var $list = this.$list.find('.listContent');
    var _this = this;
    var options = _this.options;
    // 应用拖拽
    require.async('jqueryUI', function () {
      $list.sortable({
        items: '>li',
        scrollSpeend: 10,
        containment: 'parent',
        cancel: '.nullPersonalApps',
        update: function (event, ui) {
          var _list = $(event.target);
          var _isTop = !!_list.data('istop');
          var sortValue = [];
          _list.children().each(function () {
            var obj = {};
            var appId = $(this).data('appid');
            var pid = $(this).data('projectid');
            obj['appId'] = appId;
            obj['projectId'] = pid;
            sortValue.push(obj);
          });

          ajaxPath.orderAccountApps({
            isTop: _isTop,
            apps: JSON.stringify(sortValue),
          }).done(function (data) {
            // fail
            if (!data.success) {
              alert('操作失败', 2);
              _list.sortable('cancel');
            } else {
              cacheData = null;
            }
          }).fail(function () {
            alert('操作失败', 2);
            _list.sortable('cancel');
          })
        },
      });
    });

    $list.on('click', '.stickBtn', function () {
      var $this = $(this);
      var $app = $this.closest('.singleApp');
      var appId = $app.data('appid');
      var projectId = $app.data('projectid') || '';
      var isTop = !!$app.data('istop');
      var $stickList = _this.$list.find('.stickApps');
      var $stickListContent = $stickList.find('.listContent');
      var obj = {};
      obj['appId'] = appId;
      obj['projectId'] = projectId;

      ajaxPath.updateAccountAppTop({
        isTop: !isTop,
        apps: JSON.stringify([obj]),
      }).done(function (data) {
        if (!data || !data.success) {
          return alert('操作失败', 2);
        }

        if (!isTop) {
          var $cloned = $app.clone();
          var companyName = options.projectsDict[projectId];
          var html = doT.template('<span class="companyName flex" title="{{! it.companyName }}">{{! it.companyName }}</span>')({companyName: companyName});
          $cloned.find('.appName').removeClass('flex')
            .after(html);
          $cloned.appendTo($stickListContent);
        } else {
          $stickListContent.children().filter('[data-projectid=' + projectId + '][data-appid=' + appId + ']').remove();
        }
        // toggle app stick btn
        _this.$list
          .find('[data-projectid=' + projectId + '][data-appid=' + appId + ']').data('istop', !isTop)
          .find('.stickBtn')
          .toggleClass('Hidden');
        // stick app hide if no apps in list
        $stickList.toggleClass('Hidden', $stickListContent.children().length <= 0);
        _this.setStickListHeight();
        _this.bindNano();
        cacheData = null;
      }).fail(function () {
        alert('操作失败', 2);
      });

      return false;
    });

    _this.$list.on('click', '.listTitle', function (e) {
      if (e.target.classList.contains('settingBtn')) return;
      var $this = $(this);
      if ($this.hasClass('fixedTitle')) return false;
      var $toggleMainBtn = $this.find('.toggleMainList');
      var $toggleMainTitle = $toggleMainBtn.find('span');
      var $load = $('<i class="loadingTip clipLoader"></i>');
      var $list = $this.next();
      if ($list.is(':animated')) {
        return;
      }
      if (!$list.is(':visible')) {
        $toggleMainBtn.prepend($load);
      }
      $toggleMainTitle.hide().toggleClass('Hidden');
      $list.slideToggle(function () {
        $load.remove();
        $toggleMainTitle.removeAttr('style');
        _this.setStickListHeight();
        _this.bindNano();
      });
      e.stopPropagation();
    });

    _this.$list.on('click', '.singleAppLink', function () {
      if ($(this).closest('.singleApp').hasClass('notice')) {
        cacheData = null;
      }
    });

    _this.$list.find('.nano').on('update', $.proxy(this.fixTitle, this));
  };

  module.exports = Applist;
});
