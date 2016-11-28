define(function (require, exports, module) {
    var type = 'personalInfo'; // 账户一览
  var util = require('util');
  var common = require('./common');
  var request = util.getRequest();
  if (request['type']) {
    type = request['type'];
  }
  var User = {};

  if (request['account']) {
      md.global.Account.accountId  = request['account'];
  }

  User.init = function () {
    $('#accountNav').on('click', 'li', function () {
      var $this = $(this);
      $this.addClass('ThemeBGColor8')
        .siblings('li')
        .removeClass('ThemeBGColor8');
      var typeTag = $this.attr('typeTag');
      history.pushState(typeTag, document.title, location.href.split('?')[0] + '?type=' + typeTag);
      common.init();
      User.reloadList(typeTag);
    });
    var guideSettings = md.global.Account.guideSettings;
    if (guideSettings.accountEmail || guideSettings.accountMobilePhone) {
      $('.accountTab').find('.warnLight').show();
    }
    User.reloadList(type);
  };
  User.reloadList = function (typeTag) {
    var pageUrl = './accountChart/accountChart.js';
    var event = $('.accountChartLi');
    switch (typeTag) {
      case 'information':
        pageUrl = './personalInfo/personalInfo.js';
        event = $('.personalInfoLi');
        break;
      case 'management':
        pageUrl = './accountPassword/accountPassword.js';
        event = $('.accountPasswordLi');
        break;
      case 'system':
        pageUrl = './systemSettings/systemSettings.js';
        event = $('.systemSettingsLi');
        break;
      case 'enterprise':
        pageUrl = './enterprise/enterprise.js';
        event = $('.enterprisemLi');
        break;
      case 'emblem':
        pageUrl = './emblem/emblem.js';
        event = $('.emblemLi');
        break;
      default:
        pageUrl = './accountChart/accountChart.js';
        event = $('.accountChartLi');
        break;
    }
    event.addClass('ThemeBGColor8')
      .siblings('li')
      .removeClass('ThemeBGColor8');
    require.async(pageUrl, function (account) {
      account.init();
    });
  };
  $(function () {
    User.init();
  });
  return User;
});
