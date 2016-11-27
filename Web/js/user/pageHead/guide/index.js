define(function (require, exports, module) {
  var Guide = {};
  var tplFunc = require('doT').template(require('./tpl.html'));
  var isShow = false;
  var guideSettingsModule = require('modules/mdpublic/newGuide/guideSetting');
  Guide.options = {
    container: '#newGuideContainer',
    index: 0,
  };
  require('./style.css');

  Guide.init = function ($elem) {
    this.$element = $elem;
    this.$container = $(this.options.container);
    this.guideSetting = this.handleGuideSettings();
    this.options.data = this.guideSetting.get();
    this.show();
  };

  Guide.handleGuideSettings = function () {
    var guideSettings = md.global.Account.guideSettings;
    var data = this.fetchData();
    Guide.options.keys = _.keys(data);
    for (var key in data) {
      data[key].isCompleted = !guideSettings[key] || false;
    }

    return {
      get: function () {
        return data;
      },
      set: function (key) {
        data[key].isCompleted = true;
        guideSettings[key] = false;
      },
    };
  };

  Guide.fetchData = function () {
    return {
      inviteFriend: {
        image: '/modules/mdpublic/pageHead/guide/images/01.png',
        title: '邀请同事加入明道一起协作',
        desc: '邀请团队成员加入明道，可以形成有序的通讯录，以便群组、任务、日程、知识等协作应用的有效使用',
        btnName: '邀请好友',
        tip: '邀请好友',
      },
      editAccountInfo: {
        image: '/modules/mdpublic/pageHead/guide/images/02.png',
        title: '完善你的资料',
        desc: '完善你的公司、职位等信息，可以明确团队成员在协作中的角色，更好的投入工作。',
        btnName: '完善个人资料',
        tip: '完善个人资料',
      },
      deskClientLogin: {
        image: '/modules/mdpublic/pageHead/guide/images/03.png',
        title: '在电脑上安装明道客户端',
        desc: '安装明道桌面客户端，保持开机启动，沟通协作更便捷。',
        btnName: '下载 明道 客户端',
        tip: '下载客户端',
      },
      editTheme: {
        image: '/modules/mdpublic/pageHead/guide/images/04.png',
        title: '定制自己的个性化明道',
        desc: '更换一套自己的主题，让每天工作都有好心情',
        btnName: '更换主题',
        tip: '更换主题',
      },
      addPost: {
        image: '/modules/mdpublic/pageHead/guide/images/05.png',
        title: '发布动态知会工作进度和改善透明沟通',
        desc: '使用动态轻松发布公告，知会工作，反馈建议，沟通将更加透明和富有成效',
        btnName: '发布动态',
        tip: '发布动态',
      },
      addTask: {
        image: '/modules/mdpublic/pageHead/guide/images/06.png',
        title: '把任务协作搬到明道上来',
        desc: '通过明道任务中心提高全员的执行力，减少任务的遗忘和拖沓；同时实现最便利的项目管理',
        btnName: '创建任务',
        tip: '创建任务',
      },
      addCalendar: {
        image: '/modules/mdpublic/pageHead/guide/images/07.png',
        title: '用日程共享预约会议',
        desc: '向团队成员发起日程预约，待办事项记录，随时查看同时日程，不再遗忘任何事项',
        btnName: '创建日程',
        tip: '创建日程',
      },
      addFolder: {
        image: '/modules/mdpublic/pageHead/guide/images/08.png',
        title: '邀请协作者加入共享文件夹',
        desc: '厌倦了成员之间来回发送文件？用明道建立共享文件夹，资料存储不再零散，分类和管理更清晰',
        btnName: '创建共享文件夹',
        tip: '共享文件夹',
      },
      mdAppLogin: {
        image: '/modules/mdpublic/pageHead/guide/images/09.png',
        title: '在手机上随时保持明道协作',
        desc: '安装明道移动客户端，在手机上随时掌握和推进工作进展',
        btnName: '下载 明道 移动应用',
        tip: '移动客户端',
      },
      installApp: {
        image: '/modules/mdpublic/pageHead/guide/images/10.png',
        title: '逛一逛应用市场',
        desc: '明道应用市场提供丰富的第三方拓展应用，满足个人和企业不同的应用需求',
        btnName: '安装 明道 拓展应用',
        tip: '应用市场',
      },
    };
  };

  Guide.show = function () {
    var $container = this.$container;
    if ($container.is(':empty')) {
      var $tpl = this.build();
      $container.html($tpl);
      this.bindEvent();
    }
    this.$container.stop().slideDown(150, function () {
      Guide.$element.addClass('guideShow');
    });
    $.publish('addMdTopTheme');
    isShow = true;
  };

  Guide.rebuildTitle = function () {
    var $container = this.$container;
    var $tpl = this.build('title');
    $container.find('.title').replaceWith($tpl);
  };

  Guide.build = function (type) {
    return tplFunc({
      type: type,
      activeIndex: this.options.index,
      active: this.options.keys[this.options.index],
      keys: this.options.keys,
      steps: this.options.data,
    });
  };

  Guide.hide = function (cb) {
    this.$container.stop().slideUp(150, function () {
      Guide.$element.removeClass('guideShow');
      if ($.isFunction(cb)) {
        cb();
      }
    });
    isShow = false;
  };

  Guide.bindEvent = function () {
    var $container = this.$container;
    var $content = $container.find('.content');
    var $steps = $content.find('.step');
    $container.on('click', '.title .step', function (e) {
      var index = $(this).index();
      if (index !== Guide.options.index) {
        Guide.options.index = index;
        Guide.rebuildTitle();
        $steps.removeClass('active')
          .eq(index).addClass('active');
      }
      e.stopPropagation();
    });
    $container.on('click', '.op', function (e) {
      Guide.btnEventHandler();
      e.stopPropagation();
    });

    $container.on('click', '.closeGuide', function () {
      Guide.hide(Guide.poshytipHandler);
      guideSettingsModule.setAccountGuide(16);
      $.publish('removeMdTopTheme');
    });

    $.subscribe('CLOSE_GUIDE', function () {
      Guide.hide();
    });

    // $(document).on('click.newGuide', function (event) {
    //   if(!isShow) return;
    //   if (!$(event.target).closest('.topbarGuide').length && !$(event.target).closest(Guide.options.container).length) {
    //     Guide.hide();
    //   }
    // });
  };

  Guide.btnEventHandler = function () {
    var options = this.options;
    var index = options.index;
    var $document = $(document);
    switch (index) {
      case 0:
        require.async('addFriends', function (addFriends) {
          addFriends();
        });
        break;
      case 1:
        window.open('/personal?type=information');
        break;
      case 2:
      case 8:
        window.open('/mobile.htm');
        break;
      case 3:
        // Theme
        require.async('../theme/theme.js', function (Theme) {
          $.publish('CLOSE_GUIDE')
          Theme.getData($('#themeChooseContainer'), true);
        });
        break;
      case 4:
        // post
        $document.trigger($.Event('keypress', {
          which: 115,
        }));
        break;
      case 5:
        // task
        $document.trigger($.Event('keypress', {
          which: 116,
        }));
        break;
      case 6:
        // calendar
        $document.trigger($.Event('keypress', {
          which: 99,
        }));
        break;
      case 7:
        require.async('modules/mdpublic/kc/createRoot/createRoot', function (createRoot) {
          createRoot({
            members: [{
              fullname: md.global.Account.fullname,
              avatar: md.global.Account.avatarMiddle,
              accountId: md.global.Account.accountId,
              permission: 1,
            }],
          }).then(function (root) {
            if (root) {
              require.async('createShare', function (createShare) {
                createShare.init({
                  linkURL: location.protocol + '//' + location.host + '/apps/kc/' + root.id,
                  content: '共享文件夹创建成功',
                });
              });
            }
          });
        });
        break;
      case 9:
        window.open('https://app.mingdao.com/');
        break;
      default:
        break;
    }
  };

  Guide.poshytipHandler = function () {
    if (md.global.Account.guideSettings.autoShowGuide) {
      var $trigger = $('#topBarContent .topbarGuide');
      var tpl = '<div class="guideContainer clearfix">' +
        '<div class="image"></div>' +
        '<div class="textBox">' +
        '<div>下次你可以继续在这里完成新手任务，探索明道更多精彩功能</div>' +
        '<div class="TxtRight"><span class="ThemeColor3 Hand closeBtn">我知道了</span></div>' +
        '</div>' +
        '</div>';
      require.async('poshytip', function () {
        $trigger.poshytip({
          additionalClassName: 'z-depth-1-half guidePoshytip',
          showOn: 'none',
          content: tpl,
          alignTo: 'target',
          alignX: 'inner-left',
          alignY: 'bottom',
          arrowRight: 50,
          offsetX: -235,
          offsetY: 12,
          keepInViewport: false,
        });

        $trigger.poshytip('show');

        $('.guidePoshytip').on('click', '.closeBtn', function () {
          $trigger
            .poshytip('hide')
            .poshytip('destroy');
        });

        $.subscribe('addMdTopTheme', function () {
          $trigger
            .poshytip('hide')
            .poshytip('destroy');
        });
      });
    }
  };

  module.exports = Guide;
});
