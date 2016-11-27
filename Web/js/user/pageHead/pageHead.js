define(function (require, exports, module) {
  var PageHead = {};
  var SmallBell = require('./modules/smallBell/index');
  var Theme = require('./theme/theme');
  var Guide = require('./guide/index');
  var Router = require('./modules/router')();
  var emojiFontFace = require('modules/mdcontrol/emojiFontFace/emojiFontFace');
  var KcController = require('modules/common/ajax/kc');
  require('./headNavbar.css');
  require('poshytip');
  PageHead.options = {
    pageHeadLoadingTpl: '<div class="pageHeadLoading">' + LoadDiv() + '</div>',
  };

  PageHead.init = function () {
    PageHead.menuItemResponse();
    PageHead.initPage();

    
  };

  PageHead.initPage = function () {
    PageHead.getDom();
    PageHead.bindMSTC();
    PageHead.bindPoshytip();
    emojiFontFace($('body'));
    PageHead.afterContentReady();
    PageHead.bindEvent();
  };

  PageHead.afterContentReady = function () {
    // after DOMContentLoaded
    $(function () {
      PageHead.newGuide();
      PageHead.buildUserCenterGuide();
      PageHead.callGuide();
      if (md.global.Account.guideSettings.selectScale) {
        require.async('modules/mdpublic/newGuide/selectScale/index', function (guide) {
          guide({
            callback: function () {
              md.global.Account.guideSettings.selectScale = false;
              PageHead.callGuide();
            },
          });
        });
      }
    });
  };

  PageHead.bindMSTC = function () {
    var callDialog = function (which) {
      // event.which reference to：
      // http://www.west-wind.com/WestwindWebToolkit/samples/Ajax/html5andCss3/keycodechecker.aspx
      // event: keyPress
      switch (which) {
        case 109: // m is deleted
          break;
        case 115:
          require.async('s', function (s) {
            s({
              callback: function (postItem) {
                if (window.postListActions) {
                  window.postListActions.addPostLocally(postItem);
                }
              },
            });
          });
          break;
        case 116:
          require.async('t', function (t) {
            t();
          });
          break;
        case 99:
          require.async('c', function (c) {
            c();
          });
          break;
        case 117:
          PageHead.buildUploadWindow();
          break;
        default:
          break;
      }
    };
    callDialog = (window._ && window._.debounce) ? _.debounce(callDialog, 200) : callDialog;
    $(document).on('keypress', function (e) {
      if (e.ctrlKey || e.shiftKey || e.altKey || e.cmdKey || e.metaKey) return;
      var tag = e.target.tagName && e.target.tagName.toLowerCase();
      if (tag === 'input' || tag === 'textarea' || $(e.target).is('[contenteditable]')) return;

      callDialog(e.which);
    });
  };

  PageHead.getDom = function () {
    PageHead.$appList = $('#topBarContent .appItem');
    PageHead.$quickAddInterface = $('#topBarContent .quickAddInterface');
    PageHead.$userCenter = $('#topBarContent .userCenter');
    PageHead.$inboxMessage = $('#topBarContent .inboxMessage');
    PageHead.$newGuide = $('#topBarContent .topbarGuide');
    PageHead.$themeChoose = $('#topBarContent .themeChoose');
  };

  PageHead.bindPoshytip = function () {
    var buildPoshytip = function ($elem, options) {
      var DEFAULTS = {
        additionalClassName: 'z-depth-1-half',
        showOn: 'none',
        content: PageHead.options.pageHeadLoadingTpl,
        alignTo: 'target',
        alignX: 'center',
        alignY: 'bottom',
        offsetX: 0,
        offsetY: -2,
        fixed: true,
        keepInViewport: false,
      };
      var opts = $.extend({}, DEFAULTS, options);
      if (opts.additionalClassName) {
        var _classArr = opts.additionalClassName.split(' ');
        _classArr.push(DEFAULTS.additionalClassName);
        opts.additionalClassName = _classArr.join(' ');
      } else {
        opts.additionalClassName = DEFAULTS.additionalClassName;
      }
      return $elem.poshytip(opts);
    };

    // user center
    buildPoshytip(PageHead.$userCenter, {
      additionalClassName: 'userSetList',
      offsetY: 12,
    });
    // quick add
    buildPoshytip(PageHead.$quickAddInterface, {
      additionalClassName: 'quickAdd',
      offsetY: 12,
    });
    // applist
    buildPoshytip(PageHead.$appList, {
      additionalClassName: 'pageHeadApplist',
      arrowLeft: 80,
      alignX: 'inner-left',
      offsetX: -45,
    });
    // small bell
    buildPoshytip(PageHead.$inboxMessage, {
      additionalClassName: 'informationHome',
      offsetY: 12,
    });

    // poshytips
    var $_arr = PageHead.$inboxMessage
      .add(PageHead.$appList)
      .add(PageHead.$quickAddInterface)
      .add(PageHead.$userCenter);

    $_arr.on('click', function (e) {
      var $this = $(this);
      // baidu Statistics
      var _bssp = $this.data('bssp');
      BSS.setBssp(_bssp);
      if ($this.data('isOpen')) {
        $_arr.poshytip('hide').data('isOpen', false);
      } else {
        $this.poshytip('show').data('isOpen', true);
        $_arr.not($this).poshytip('hide').data('isOpen', false);
      }
      e.stopPropagation();
    });

    $(window).on('resize.pagehead', function () {
      $.publish('CLOSE_PAGEHEAD_POSHYTIPS');
    });

    $(document).on('click', function () {
      $.publish('CLOSE_PAGEHEAD_POSHYTIPS');
    });

    $.subscribe('CLOSE_PAGEHEAD_POSHYTIPS', function (e, onlySmallBell) {
      if (onlySmallBell) {
        PageHead.$inboxMessage.poshytip('hide').data('isOpen', false);
      } else {
        $_arr.poshytip('hide').data('isOpen', false);
      }
    });
  };

  PageHead.renderUserDropDown = function () {
    var doT = require('doT');
    var tpl = require('./tpl/dropdowns.html');
    var $dropDownTpl = $(doT.template(tpl)({
      type: 'user',
    }));
    PageHead.$userCenter.poshytip('update', $dropDownTpl);
    PageHead.bindUserCenterEvent($dropDownTpl);

    PageHead.buildUserCenterGuide();
  };

  PageHead.buildUserCenterGuide = function () {
    // build guide
    var userSetGuideSetting = md.global.Account.guideSettings;
    var hasGuide = userSetGuideSetting.accountEmail ||
      userSetGuideSetting.accountMobilePhone ||
      userSetGuideSetting.mdDaShi ||
      userSetGuideSetting.createCompany;
    if (hasGuide) {
      require.async('modules/mdpublic/newGuide/guideForPageHead.js', function (guideForPageHead) {
        guideForPageHead.warnLightUserSetTip();
        guideForPageHead.warnLightUserSetItemTip(userSetGuideSetting);
      });
    }
  };

  PageHead.bindUserCenterEvent = function ($userSet) {
    // 关注微信号
    $userSet.find('.showFollowWeixinDialog').on('click', function () {
      require.async('modules/mdpublic/common/function.js', function (mdFunction) {
        mdFunction.showFollowWeixinDialog();
      });
    });
    // 明道大使
    $userSet.find('.btnMDDashi').on('click', function () {
      require.async('modules/mdpublic/newGuide/guideSetting.js', function (guideSetting) {
        guideSetting.setAccountGuide(guideSetting.guideTypes.mdDaShi);
      });
    });
    // 网络管理
    $userSet.find('.nmEntry').on('click', function () {
      require.async('./modules/projectSelectDialog/index.js', function (projectDialog) {
        projectDialog({});
      });
    });
  };

  PageHead.renderQuickAddInterface = function () {
    var doT = require('doT');
    var tpl = require('./tpl/dropdowns.html');
    var $dropDownTpl = $(doT.template(tpl)({
      type: 'invite',
    }));
    PageHead.$quickAddInterface.poshytip('update', $dropDownTpl);
    PageHead.bindAddInterfaceEvent($dropDownTpl);
  };

  PageHead.bindAddInterfaceEvent = function ($addInviteList) {
    $addInviteList.find('.createPost').on('click', function () {
      require.async('s', function (s) {
        s({
          callback: function (postItem) {
            if (window.postListActions) {
              window.postListActions.addPostLocally(postItem);
            }
          },
        });
      });
    });
    $addInviteList.find('.createTask').on('click', function () {
      require.async('t', function (t) {
        t();
      });
    });
    $addInviteList.find('.createCalendar').on('click', function () {
      require.async('c', function (c) {
        c();
      });
    });
    $addInviteList.on('click', '.inviteMember', function () {
      require.async('./modules/invite/index', function (invite) {
        invite();
      });
    });
    $addInviteList.find('.linkCreateGroup').on('click', function () {
      require.async('modules/mdpublic/group/create/creatGroup.js', function (CreatGroup) {
        CreatGroup.createInit({
          callback: function (data) {
            var groupId = data.groupId;
            if (Router.type === 'chat') {
              $.publish('CROSS_ACTIONS_ACTIVATE_CONTACT', {
                type: 2,
                id: groupId,
              });
            } else {
              window.location.href = '/chat?type=group&id=' + groupId;
            }
          },
        });
      });
    });

    $addInviteList.find('.uploadAssistant').on('click', function () {
      PageHead.buildUploadWindow();
    });
  };

  PageHead.bindEvent = function () {
    PageHead.$userCenter.one('click', PageHead.renderUserDropDown);
    PageHead.$quickAddInterface.one('click', PageHead.renderQuickAddInterface);
    PageHead.$inboxMessage.on('click', function () {
      var $this = $(this);
      // eslint-disable-next-line no-new
      new SmallBell({
        element: $this,
        isChat: Router.type === 'chat',
      });
    });
    PageHead.$appList.on('click', function () {
      var $this = $(this);
      require.async('./modules/appList/applist', function (AppList) {
        // eslint-disable-next-line no-new
        new AppList({
          element: $this,
          loadingTpl: PageHead.options.pageHeadLoadingTpl,
        });
      });
    });

    PageHead.themeAndGuide();

    PageHead.scrollEventHandler();

    PageHead.initSearch();
  };

  PageHead.themeAndGuide = function () {
    var $html = $('html');
    $.subscribe('removeMdTopTheme', function () {
      $html.removeClass("mdTopTheme");
    });

    $.subscribe('addMdTopTheme', function () {
      $html.addClass("mdTopTheme");
    });

    // Theme
    PageHead.$themeChoose.on('click', function () {
      $.publish('CLOSE_GUIDE');
      Theme.getData($('#themeChooseContainer'));
    });

    // Guide
    PageHead.$newGuide.on('click', function () {
      Guide.init(PageHead.$newGuide);
    });

    $(document).on('click.mdTopTheme', function (e) {
      var $target = $(e.target);
      var $newGuideContianer = $('#newGuideContainer');
      if ($newGuideContianer.html() && $newGuideContianer.is(':visible')) return;
      var bNotTriggers = !$target.closest(PageHead.$themeChoose).length && !$target.closest(PageHead.$newGuide).length;
      var bNotInTopContent = !$target.closest('.topbarTopContent').length;
      if (bNotTriggers && bNotInTopContent) {
        $.publish('removeMdTopTheme');
      }
    });
  };

  PageHead.callGuide = function () {
    if (!md.global.Account.guideSettings.selectScale && md.global.Account.guideSettings.autoShowGuide) {
      Guide.init(PageHead.$newGuide);
    }
  };

  PageHead.newGuide = function () {
    var guideSettings = md.global.Account.guideSettings;
    var keys = _.keys(guideSettings).slice(0, 10);
    var flag = false;
    $.each(keys, function (i, key) {
      if (guideSettings[key]) {
        flag = true;
        return false;
      }
    });
    PageHead.$newGuide.find('.activeNotice').toggle(flag);
  };

  PageHead.initSearch = function () {
    // 智能搜索响应
    var $smartSearchPart = $('#topBarContent .searchPart');
    var $smartSearchContainer = $('#SmartSearch .smartSearchContainer');
    var $SmartSearchTextBox = $('#SmartSearchTextBox');
    var isSearchActive = false;
    var originalPadding;

    function show() {
      isSearchActive = true;
      $smartSearchContainer.addClass('Gray_9 active').removeClass('ThemeBGColor3');
      $SmartSearchTextBox
        .attr('placeholder', md_lang.myfeed_totalsearch)
        .stop()
        .animate({
          width: 237,
        }, {
          queue: false,
          complete: function () {
            $SmartSearchTextBox.focus();
            require.async('modules/mdpublic/search/smartSearch.js', function (smartSearch) {
              $('#SmartSearch .searchClose').show();
              smartSearch.bindSmartSearch();
            });
          },
        });
      originalPadding = $smartSearchPart.css('paddingLeft');
      $smartSearchPart.stop().animate({
        paddingLeft: 0,
      }, {
        queue: false,
      });

      PageHead.$userCenter.add(PageHead.$newGuide).fadeOut(200);
    }

    function hide() {
      isSearchActive = false;
      $smartSearchContainer.addClass('ThemeBGColor3').removeClass('Gray_9 active');
      $SmartSearchTextBox.val('').blur()
        .removeAttr('placeholder');
      $('#SmartSearch .searchClose').hide();
      $('#SmartSearchResultDiv').hide();
      $SmartSearchTextBox.stop().animate({
        width: 0,
      }, {
        queue: false,
      });
      $smartSearchPart.stop().animate({
        paddingLeft: originalPadding,
      }, {
        queue: false,
      });

      PageHead.$userCenter.add(PageHead.$newGuide).fadeIn(200);
    }

    $smartSearchContainer.on('click', '.searchBtn', function (e) {
      if (!isSearchActive) {
        show();
      }
      // e.stopPropagation();
    });

    $smartSearchContainer.on('click', '.searchClose', function (event) {
      $(this).hide();
      hide();
      // event.stopPropagation();
    });

    $(document).on('click', function (event) {
      if ($(event.target).is($SmartSearchTextBox) || $(event.target).closest('.searchBtn').length) return;
      if (isSearchActive && ($.trim($SmartSearchTextBox.val()) === '')) {
        hide();
      }
    });
  };

  PageHead.scrollEventHandler = function () {
    var $backTop = $('#topBarContent .backTop');
    var oldHeight = 0;
    var $html = $('html, body');
    $.subscribe('scroll.backToTop', function (e, data) {
      var newHeight = data.top || 0;
      if (newHeight === 0) {
        $backTop.stop().fadeOut(500);
        return;
      }
      var scrollTop = oldHeight > 500 && Math.abs(newHeight - oldHeight) >= 50;
      if (scrollTop && !$backTop.is(':animated')) {
        var time = 4;
        while (time--) {
          $backTop.fadeToggle(1500);
        }
      }
      oldHeight = newHeight;
    });

    $.subscribe('scrollTop.backToTop', function (e) {
      var $content = $('.feedApp .feedAppScrollContent');
      if (!$content.length) {
        $content = $html;
      }
      $content.animate({
        scrollTop: 0,
      }, 500);
    });

    $(window).on('scroll', function () {
      var top = $(this).scrollTop();
      $.publish('scroll.backToTop', {
        top: top,
      }, 50);
    });

    // 滚动条回到顶部
    $('#topBarContent').on('click', function (event) {
      if ($(event.target).is('#topBarContent')) {
        $.publish('scrollTop.backToTop');
      }
    });

    $backTop.on('click', function () {
      $.publish('scrollTop.backToTop');
    });
  };

  PageHead.buildUploadWindow = function () {
    if (!window.uploadAssistantWindow || window.uploadAssistantWindow.closed) {
      var url = '/apps/kcupload';
      var name = 'uploadAssistant';
      var iTop = (window.screen.availHeight - 660) / 2; // 获得窗口的垂直位置;
      var iLeft = (window.screen.availWidth - 930) / 2; // 获得窗口的水平位置;
      var options = 'width=930,height=598,toolbar=no,menubar=no,location=no,status=no,top=' + iTop + ',left=' + iLeft;
      window.uploadAssistantWindow = window.open(url, name, options);
    } else {
      window.uploadAssistantWindow.focus();
    }
    if (!PageHead.options.canUpload) {
      KcController.getUsage({}).then(function (data) {
        PageHead.options.canUpload = data.used < data.total;
        if (!PageHead.options.canUpload && window.uploadAssistantWindow) {
          window.uploadAssistantWindow.close();
          delete window.uploadAssistantWindow;
          alert('已达到本月上传流量上限');
        }
      });
    }
  };

  PageHead.menuItemResponse = function () {
    var $menuTags = $('#topBarContent .menuTags');

    $menuTags.find('.' + Router.type + 'Tag')
      .addClass('activeTag')
      .attr('tag', 'true');
  };

  module.exports = PageHead;
});
