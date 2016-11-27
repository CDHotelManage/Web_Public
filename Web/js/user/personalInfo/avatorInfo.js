define(function (require, exports, module) {
  var doT = require('doT');
  require('tooltip');
  var account = require('../../../common/ajax/account');

  var avatorInfo = {};
  avatorInfo.options = {};
  // 首次调用
  avatorInfo.init = function () {
    account.getAccountAvatar({}).then(function (data) {
      if (data.state == 0) {
        require.async('./tpl/avatorInfo.html', function (rowsTpl) {
          var strHtml = doT.template(rowsTpl)({
            groupObject: data,
          });
          $('.personalInfoMain').html(strHtml.toString());
          $('#spanNormal').click(function (event) {
            avatorInfo.updateLoadType(true);
          });
          $('#spanPz').click(function (event) {
            avatorInfo.updateLoadType(false);
          });
          if (data.avatar != '') {
            avatorInfo.ShowHead(data.avatarBig, data.avatarMiddle, data.avatarSmall);
          }
        });
      }
    }).fail();
  };
  avatorInfo.updateLoadType = function (IsLocation) {
    if (IsLocation) {
      $('#spanNormal').addClass('Bold');
      $('#spanPz').removeClass('Bold');
      $('#AratorPz').hide();
      $('#AvatorNormal').show();
    } else {
      $('#spanNormal').removeClass('Bold');
      $('#spanPz').addClass('Bold');
      $('#AvatorNormal').hide();
      $('#AratorPz').show();
    }
  };
  // 头像更新后事件
  avatorInfo.CallBackOpenHeadImageDialog = function (avatar) {
    if (avatar) {
      $('#AvatorBig').attr('src', avatar.bigAvatar);
      $('#AvatorMiddle').attr('src', avatar.middleAvatar);
      $('#AvatorSmall').attr('src', avatar.smallAvatar);
      $('#userProfileAvatar').attr('src', avatar.bigAvatar);
      alert(md_lang.myaccount_text_49, 1);
      $('#AvatorNormal').html('<iframe frameborder="0" scrolling="no" width="458" height="430" src="' + VirtualPath + 'UIControl/jcrop/head_upload.aspx"></iframe>');
    } else {
      parent.alert(md_lang.myaccount_text_48, 2);
    }
  };
  // 根据URL分别显示头像
  avatorInfo.ShowHead = function (BigAvatorURL, MiddleAvatorURL, SmallAvatorURL) {
    avatorInfo.options.isSelAvator = true;
    $('.AvatorBig img').attr('src', BigAvatorURL);
    $('.AvatorMiddle img').attr('src', MiddleAvatorURL);
    $('.AvatorSmall img').attr('src', SmallAvatorURL);
  };

  return avatorInfo;
});
