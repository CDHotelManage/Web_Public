define(function (require, exports, module) {
  require('./personalInfo.css');
  var common = require('../common');
  var userInfo = '';
  var type = '';
  var util = require('util');
  var request = util.getRequest();
  if (request['userInfo']) {
    userInfo = request['userInfo'];
  } else {
    userInfo = 'basicData';
  }
  
  var doT = require('doT');
  var PersonalInfo = {};

  // 首次调用
  PersonalInfo.init = function () {
    $('#accountCenterMainBox').html('<div class="mTop10 mBottom10 WhiteBG boderRadAll_2 pAll20 card">' + LoadDiv() + '</div>');
    require.async('./tpl/personalInfo.html', function (rowsTpl) {
      var strHtml = doT.template(rowsTpl)({});
      $('#accountCenterMainBox').html(strHtml.toString());
      PersonalInfo.reloadNav(userInfo);
      $('.' + userInfo).children('a')
        .addClass('ThemeColor3')
        .parents('li')
        .siblings('li')
        .children('a')
        .removeClass('ThemeColor3');
      var left = $('.' + userInfo).offset().left - 285;
      $('.accountTab_secend').find('span.textDecoration')
        .stop()
        .animate({
          'left': (left) + 'px',
        }, 0);
      var index = $('.' + userInfo).index();
      $('.sTabs').eq(index)
        .slideDown()
        .siblings('.sTabs')
        .hide();

      $('.accountTab_secend').on('click', 'li', function (event) {
        var $this = $(this);
        var leftNum = $this.offset().left - 285;
        var indexNum = $this.index();
        var userInfoClick = $this.attr('typetag');
        $this.children('a')
          .addClass('ThemeColor3')
          .parents('li')
          .siblings('li')
          .children('a')
          .removeClass('ThemeColor3');
        $('.accountTab_secend span.textDecoration').stop().animate({
          'left': (leftNum) + 'px',
        }, 500);
        $('.sTabs').eq(indexNum)
          .slideDown()
          .siblings('.sTabs')
          .hide();
        // $('.personalInfoMain').html('');
        PersonalInfo.reloadNav(userInfoClick);
        history.pushState(type, document.title, location.href.split('?')[0] + '?type=information' + type + '&userInfo=' + userInfoClick);
      });
    });
  };
  PersonalInfo.reloadNav = function (typeNum) {
    var url = './basicInfo.js';
    var pageType = '';
    switch (typeNum) {
      case 'avatarSetting':
        url = './avatorInfo.js';
        break;
      case 'contactInformation':
        url = './contactInfo.js';
        break;
      case 'working':
        url = './WorkOrEdu.js';
        pageType = 'Work';
        break;
      case 'educational':
        url = './WorkOrEdu.js';
        pageType = 'Edu';
        break;
      default:
        url = './basicInfo.js';
        break;
    }
    require.async(url, function (info) {
      info.init(pageType);
    });
  };
  return PersonalInfo;
});
