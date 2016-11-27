define(function (require, exports, module) {
  var doT = require('doT');
  require('tooltip');
  var account = require('../../../common/ajax/account');
  var ContactInfo = {};
  ContactInfo.options = {};
  // 首次调用
  ContactInfo.init = function () {
    account.getContactInfo({}).then(function (data) {
      if (data.state == 0) {
        require.async('./tpl/contactInfo.html', function (rowsTpl) {
          var strHtml = doT.template(rowsTpl)({
            groupObject: data
          });
          $('.personalInfoMain').html(strHtml.toString());
          // 联系信息
          if (data.imqq != '') {
            $("#divTabContract input[name='QQ']").val(data.imqq);
          }
          if (data.snsLinkedin != '') {
            $("#divTabContract input[name='LinkedIn']").val(data.snsLinkedin);
          }
          if (data.snsSina != '') {
            $("#divTabContract input[name='Sina']").val(data.snsSina);
          }
          if (data.snsQQ != '') {
            $("#divTabContract input[name='QQWeibo']").val(data.snsQQ);
          }
          if (data.weiXin != '') {
            $("#divTabContract input[name='weiXin']").val(data.weiXin);
          }
          // 保存联系方式
          $('#btnAddContract').click(function () {
            ContactInfo.AddContract();
          });
        });
      }
    }).fail();
  };
  // 添加联系方式
  ContactInfo.AddContract = function () {
    if (ContactInfo.ValidateContract()) {
      var qq = $("#divTabContract input[name='QQ']").val();
      var linkedIn = $("#divTabContract input[name='LinkedIn']").val();
      if (linkedIn.Trim() == md_lang.myaccount_profile_contact_blankstate_1) {
        linkedIn = "";
      }
      var sina = $("#divTabContract input[name='Sina']").val();
      if (sina.Trim() == md_lang.myaccount_profile_contact_blankstate_2) {
        sina = "";
      }
      var qqWeibo = $("#divTabContract input[name='QQWeibo']").val();
      if (qqWeibo.Trim() == md_lang.myaccount_profile_contact_blankstate_3) {
        qqWeibo = "";
      }
      var weiXin = $("#divTabContract input[name='weiXin']").val();
      if (weiXin.Trim() == md_lang.myaccount_profile_contact_blankstate_4) {
        weiXin = '';
      }
      account.editContactInfo({
        imQQ: qq,
        snsLinkedin: linkedIn,
        snsSina: sina,
        snsQQ: qqWeibo,
        weiXin: weiXin,
        // ,phone: mobilePhone
      }).then(function (data) {
        if (data.state == 0) {
          alert(md_lang.myaccount_text_46, 1);
        } else if (data.state == 1200) {
          alert(md_lang.ACC0808122 || '您输入的QQ帐号超出了最大长度', 2);
        } else if (data.state == 1201) {
          alert(md_lang.ACC0808123 || '您输入的LinkedIn帐号超出了最大长度', 2);
        } else if (data.state == 1202) {
          alert(md_lang.ACC0808124 || '您输入的新浪微博帐号超出了最大长度', 2);
        } else if (data.state == 1203) {
          alert(md_lang.ACC0808125 || '您输入的腾讯微博帐号超出了最大长度', 2);
        } else if (data.state == 1204) {
          alert(md_lang.ACC0808126 || '您输入的微信帐号超出了最大长度', 2);
        } else {
          alert(md_lang.ACC0808045 || '操作失败', 2);
        }
      }).fail();
    }
  };
  // 验证联系方式
  ContactInfo.ValidateContract = function () {
    var qq = $("#divTabContract input[name='QQ']").val();

    if (qq != '' && isNaN(qq)) {
      alert(md_lang.myaccount_text_50, 3);
      return false;
    }

    var linkedIn = $("#divTabContract input[name='LinkedIn']").val();
    if (linkedIn != '' && linkedIn.Trim() != 'LinkedIn个人页面地址' && !RegExp.isUrl(linkedIn.Trim())) {
      alert(md_lang.myaccount_text_52, 3);
      return false;
    }
    var sina = $("#divTabContract input[name='Sina']").val();
    if (sina != '' && sina.Trim() != "新浪微博个人页面地址" && !RegExp.isUrl(sina.Trim())) {
      alert(md_lang.myaccount_text_53, 3);
      return false;
    }
    var qqWeibo = $("#divTabContract input[name='QQWeibo']").val();
    if (qqWeibo != '' && qqWeibo.Trim() != "腾讯微博个人页面地址" && !RegExp.isUrl(qqWeibo.Trim())) {
      alert(md_lang.myaccount_text_54, 3);
      return false;
    }
    return true;
  };

  return ContactInfo;
});
