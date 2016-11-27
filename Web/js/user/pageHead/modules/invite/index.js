define(function (require, exports, module) {
  var doT = require('doT');
  var InviteDialog = function (opts) {
    this.init();
  };
  var addFriend = require('addFriends');
  var invite = require('modules/mdpublic/addressList/comm/inviteMember');
  require('./style.css');

  InviteDialog.prototype.init = function () {
    var _this = this;
    if (md.global.Account.projects.length) {
      require.async('mdDialog', function (DialogLayer) {
        _this.Dialog = DialogLayer.index({
          dialogBoxID: 'inviteDialog',
          width: 420,
          container: {
            header: md_lang.TXL0801028 || '邀请新同事',
            yesText: '',
            noText: '',
          },
        });
        _this.render();
      });
    } else {
      // 只有一个网络， 直接邀请好友
      this.invite();
    }
  };

  InviteDialog.prototype.render = function () {
    this.$content = $(doT.template(require('./content.html'))());
    this.Dialog.showContent(this.$content);
    this.Dialog.dialogCenter();
    this.bindEvent();
  };

  InviteDialog.prototype.bindEvent = function () {
    var _this = this;
    var $content = this.$content;
    $content.on('click', '.projectItem', function () {
      var projectId = $(this).data('projectid');
      _this.invite(projectId);
      // _this.Dialog.closeDialog();
    });
  };

  InviteDialog.prototype.invite = function (projectId) {
    if (!projectId) {
      addFriend();
    } else {
      invite.inviteMembers(projectId);
    }
  };

  module.exports = function () {
    var invite = new InviteDialog();
  };
});
