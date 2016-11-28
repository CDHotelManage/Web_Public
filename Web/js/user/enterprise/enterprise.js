define(function (require, exports, module) {
  var doT = require('doT');
  //var EditCard = require('./editCard');
  var hotelController = require('../../common/hotel');
  var common = require('../common');
  //var UpgradeController = require('../../../common/ajax/upgrade');
  //var bindAccount = require('../accountPassword/bindAccount');
  var authType = 213;
  var Enterprise = {};
  var util = require('util');
  var request = util.getRequest();
  var invitShow = false;
  require('tooltip');
  require('./enterprise.css');
  require('pager');
  if (request['invitShow'] === 'true') {
    invitShow = true;
  }
  var projectIdUrl = null;
  if (request['projectId']) {
    projectIdUrl = request['projectId'];
  }
  Enterprise.options = {
    pageIndex: 1,
    pageSize: 10,
    verifyCodeTimer: null,
    isUserFillJobNumberEnabled: false,
    isUserFillWorkSiteEnabled: false,
    isUserFillCompanyEnabled: false,
    token: '',
    inviterAccountId: '',
    email: '',
    mobilePhone: '',
  };
  // 首次调用
  Enterprise.init = function () {
    $('#accountCenterMainBox').html('<div class="mTop10 mBottom10 WhiteBG boderRadAll_2 pAll20 card">' + LoadDiv() + '</div>');
    require.async('./tpl/enterprise.html', function (rowsTpl)
    {
        common.ajaxObj = hotelController.getHotelList(
            {
                accountId: md.global.Account.accountId
            });

      common.ajaxObj.then(function (data) {
          if (data.success) {
          $('.enterprise').find('.enterpriseLoad').hide();
          // 判断网络情况
          var isEnterprise = data.result.length > 0;

          var strHtml = doT.template(rowsTpl)({
            isEnterprise: isEnterprise,
          });
          $('#accountCenterMainBox').html(strHtml);
          if (isEnterprise) {
            Enterprise.listEnterprise(data);
          }
          // 直接预览网络编辑名片
          //if (projectIdUrl) {
          //  var mdProjects = md.global.Account.projects;
          //  for (var i = 0; i < mdProjects.length; i++) {
          //    if (mdProjects[i].projectId === projectIdUrl) {
          //      EditCard.editCard(projectIdUrl, 0, 0);
          //      break;
          //    }
          //  }
          //}
          $('.btnExperience').on('click', function (event) {
              window.open('/User/enterpriseRegister.htm?account=' + md.global.Account.accountId);
          });
          Enterprise.bind();
          // 我的邀请信息
          $('.invitationList').on('click', 'p', function (event) {
            $('.invitationListBox').slideToggle();
            $(this).children('span').toggleClass('icon-arrow-up-border');
          });
          if (invitShow) {
            $('.MyInvitation').click();
          }

          Enterprise.getUntreatAuthList();
        } else {
          alert('操作失败', 2);
        }
      }).fail();
    });
  };
  Enterprise.getUntreatAuthList = function () {
      hotelController.getUntreatAuthList({}).then(function (user) {
      if (user.state === 0 && user.count > 0) {
        // 显示新的邀请信息数
        $('.MyInvitationNew').html(user.count).show();
      } else {
        $('.MyInvitationNew').hide();
      }
    });
  };
  Enterprise.getProjectList = function () {
    if (common.ajaxObj) {
      common.ajaxObj.abort();
    }
    common.ajaxObj = hotelController.getProjectList({
      pageIndex: Enterprise.options.pageIndex,
      pageSize: Enterprise.options.pageSize,
    });

    common.ajaxObj.done(function (data) {
      if (data.allCount) {
        Enterprise.listEnterprise(data);
      }
    });
  };

  Enterprise.bind = function () {
    Enterprise.addEnterprise();
    Enterprise.myInvitation();
    hotelController.getAccountInfo({}).then(function (data) {
      if (data.state === 0) {
        if (data.email && data.mobilePhone) {
          Enterprise.options.email = data.email;
          Enterprise.options.mobilePhone = data.mobilePhone;
        } else if (data.email) {
          Enterprise.options.email = data.email;
        } else if (data.mobilePhone) {
          Enterprise.options.mobilePhone = data.mobilePhone;
        }
      }
    });
  };
  Enterprise.listEnterprisePage = function (data) {
    if (Number(data.allCount) > 0) {
      $('#divPager').show().Pager({
        pageIndex: Enterprise.options.pageIndex,
        pageSize: Enterprise.options.pageSize,
        count: Number(data.allCount),
        changePage: function (pIndex) {
          $('.enterprise').find('.enterpriseListLoad').show();
          $('#accountCenterMainBox').find('.enterpriseListOneBox').html('');
          Enterprise.options.pageIndex = pIndex;
            hotelController.getProjectList({
            pageIndex: Enterprise.options.pageIndex,
            pageSize: Enterprise.options.pageSize,
          }).then(function (dataList) {
            if (dataList.state === 0) {
              //  显示网络列表
              Enterprise.listEnterprise(dataList);
            } else {
              alert('操作失败', 2);
            }
          }).fail();
        },
      });a
    } else {
      $('#divPager').hide();
    }
  };
  // 显示网络列表
  Enterprise.listEnterprise = function (data) {
    var tpl = require('./tpl/listEnterprise.html');
    $.each(data.result, function (i, item) {
      item.companyName = util.htmlEncodeReg(item.hName);
    });
    var contentHtml = doT.template(tpl)({
      data: data,
    });
    var $content = $(contentHtml);
    $('.enterprise').find('.enterpriseListLoad').hide();
    $('#accountCenterMainBox').find('.enterpriseListOneBox').html($content);
    //  管理企业账户
    $('.goAdminPage').on('click', function (event) {
      var projectId = $(this).closest('.enterpriseList').attr('projectId');
      location.href = '/Admin/index.aspx?hid=' + projectId;
    });
    // 提醒管理员审核
    $('.sendSystemMessageToAdmin').on('click', function (event) {
      var projectId = $(this).closest('.enterpriseList').attr('projectId');
        hotelController.sendSystemMessageToAdmin({
        projectId: projectId,
        msgType: 1,
      }).then(function (dataSend) {
        if (dataSend.state === 0) {
          alert('已提醒管理员审核');
        } else {
          alert('操作失败', 2);
        }
      }).fail();
    });
    // 开通
    //$('.buyNowBtn').on('click', function (event) {
    //  var projectId = $(this).closest('.enterpriseList').attr('projectId');
    //  UpgradeController.checkAllowTrial({
    //    projectId: projectId,
    //  }).then(function (isAllowTrial) {
    //    if (isAllowTrial) {
    //      // 再次获取试用机会
    //      location.href = '/upgrade/advanced?projectId=' + projectId + '&trialAgain=true';
    //    } else {
    //      // 试用机会已满，前往购买
    //      location.href = '/upgrade/choose?projectId=' + projectId;
    //    }
    //  });
    //});
    // 续费
    //$('.renewalNowBtn').on('click', function (event) {
    //  var projectId = $(this).closest('.enterpriseList').attr('projectId');
    //  location.href = '/upgrade/choose?projectId=' + projectId;
    //});
    // 编辑名片
    //$('.editCard').on('click', function (event) {
    //  var projectId = $(this).closest('.enterpriseList').attr('projectId');
    //  EditCard.editCard(projectId, 0, 0);
    //});
    // 退出
    $content.on('click', '.exitEnterprise', function (event) {
      var $listItem = $(this).closest('.enterpriseList');
      var projectId = $listItem.attr('projectId');
      var companyName = $listItem.find('.companyName').text();
      Enterprise.validPassword(projectId, companyName);
    });

    // 申请成为管理员
    //$content.on('click', '.applyForProjectAdmin', function (event) {
    //  var projectId = $(this).closest('.enterpriseList').attr('projectId');
    //  account.applyForProjectAdmin({
    //    projectId: projectId,
    //  }).then(function (dataApply) {
    //    if (dataApply.state === 0) {
    //      Enterprise.sendApplyOK();
    //    } else {
    //      alert(md_lang.ACC0808045 || '操作失败', 2);
    //    }
    //  }).fail();
    //});
    Enterprise.listEnterprisePage(data);
  };
  // 成功发送审核信息给管理员提示
  //Enterprise.sendApplyOK = function () {
  //  alert(md_lang.ACC0808090 || '您的申请已提交，等待管理员审批。', 1);
  //};

  // 加入企业网络
  Enterprise.addEnterprise = function () {
    $('.addEnterpriseBtn').on('click', function (event) {
      require.async('./tpl/dialogAdd.html', function (tpl) {
        var contentHtml = doT.template(tpl)();
        require.async('dialog', function () {
          easyDialog.open({
            dialogBoxID: 'dialogBoxForAddEnterprise',
            fixed: false,
            container: {
              content: contentHtml,
              width: 400,
            },
            callback: function () {},
          });
          $('#dialogBoxForAddEnterprise').find('.inputForMDID')
            .focus()
            .select();
          Enterprise.reloadVerifyCode();

          $('#changeValidateCode').on('click', function () {
            Enterprise.reloadVerifyCode();
          });
          // 加入企业网络
          $('.btnSureForMDID').on('click', function () {
            var projectCode = $.trim($('#dialogBoxForAddEnterprise').find('.inputForMDID').val());
            var checkCode = $.trim($('#dialogBoxForAddEnterprise').find('.inputForCode').val());
            if (!projectCode) {
              alert('请输入明道企业网络号', 3);
              return;
            }
            if (!checkCode) {
              alert('请输入验证码', 3);
              return;
            }
            Enterprise.myInvitationAddProject(projectCode, checkCode);
          });
        });
      });
    });
  };
  Enterprise.reloadVerifyCode = function () {
    $('#dialogBoxForAddEnterprise').find('img').attr('src', '/actionpage/verifyCode.aspx?' + Math.random());
  };
  // 我的受邀信息
  Enterprise.myInvitation = function () {
    $('.MyInvitation').on('click', function (event) {
        hotelController.getMyAuthList({}).then(function (data) {
        if (data.state === 0) {
          var tpl = require('./tpl/myInvitation.html');
          var contentHtml = doT.template(tpl)({
            data: data,
          });
          require.async('mdDialog', function () {
            var dialogBoxForAddEnterprise = $.DialogLayer({
              dialogBoxID: 'dialogBoxForAddEnterprise',
              width: 400,
              container: {
                content: contentHtml,
                noText: '',
                yesText: '',
              },
              readyFn: function () {},
              callback: function () {},
              drag: true,
            });
            // 加入
            $('#dialogBoxForAddEnterprise').on('click', '.btnForAuthListAdd', function () {
              var countNum = parseInt($('.MyInvitationNew').html(), 10) - 1;
              if (countNum > 0) {
                $('.MyInvitationNew').html(countNum);
              } else {
                $('.MyInvitationNew').hide();
              }
              var projectId = $(this).attr('projectId');
              Enterprise.options.token = $(this).attr('token');
              Enterprise.options.inviterAccountId = $(this).attr('inviterAccountId');
              Enterprise.agreeInvition(projectId, dialogBoxForAddEnterprise);
            });
            // 拒绝
            $('#dialogBoxForAddEnterprise').on('click', '.btnForAuthListRefused', function () {
              var countNum = parseInt($('.MyInvitationNew').html(), 10) - 1;
              if (countNum > 0) {
                $('.MyInvitationNew').html(countNum);
              } else {
                $('.MyInvitationNew').hide();
              }
              var projectId = $(this).attr('projectId');
              Enterprise.options.inviterAccountId = $(this).attr('inviterAccountId');
              Enterprise.refuseInvition(projectId, dialogBoxForAddEnterprise);
            });
          });
        } else {
          alert('操作失败', 2);
        }
      }).fail();
    });
  };
  // 加入企业网络
  Enterprise.myInvitationAddProject = function (projectCode, checkCode) {
      hotelController.joinProject({
      projectCode: projectCode,
      checkCode: checkCode,
    }).then(function (data) {
      switch (data.state) {
        case 2:
          Enterprise.sendApplyOK();
          easyDialog.close('dialogBoxForAddEnterprise');
          alert('您加入的企业网络已开启审批策略，请等待管理员审批验证');
          break;
        case 0:
          alert(md_lang.ACC0808091 || '您已成功加入该企业网络');
          easyDialog.close('dialogBoxForAddEnterprise');
          break;
        case 1252:
          //EditCard.editCard(data.projectId, authType, 2, 2);
          //easyDialog.close('dialogBoxForAddEnterprise');
          break;
        case 203:
          $('#dialogBoxForAddEnterprise').find('.inputForMDID').focus();
          switch (data.projectUserStatus) {
            case 1:
              alert('您已是该企业网络成员', 3);
              break;
            case 2:
              alert('您已被该企业网络拒绝加入', 3);
              break;
            case 3:
              alert('您已是该企业网络成员，请等待审批', 3);
              break;
            case 4:
              alert('您已从该企业网络退出，需联系该企业网络的管理员进行恢复', 3);
              break;
            default:
              alert('您已是该企业网络的成员', 3);
          }
          break;
        case 1247:
          alert('您输入的企业网络号不存在', 3);
          break;
        case 1228:
        case 1248:
          alert('免费模式的明道企业网络无法加入，请开通企业版', 3);
          break;
        case 1249:
          alert('您申请加入的企业网络人数已超出上限，请提醒企业管理员购买用户增补包', 3);
          break;
        case 103:
          alert('验证码错误', 3);
          Enterprise.reloadVerifyCode();
          break;
        default:
          alert('操作失败', 2);
      }
    }).fail();
  };
  // 拒绝企业网络
  Enterprise.refuseInvition = function (projectId, dialogBoxForAddEnterprise) {
      hotelController.refuseInvition({
      projectId: projectId,
      inviterAccountId: Enterprise.options.inviterAccountId,
    }).then(function (data) {
      if (data.state === 0) {
        alert('您已成功拒绝该企业网络的邀请');
      } else {
        alert('操作失败', 2);
      }
      dialogBoxForAddEnterprise.closeDialog();
    }).fail();
  };
  // 同意加入企业网络
  Enterprise.agreeInvition = function (projectId, dialogBoxForAddEnterprise) {
      hotelController.agreeInvition({
      projectId: projectId,
      inviterAccountId: Enterprise.options.inviterAccountId,
    }).then(function (data) {
      if (data.state === 0) {
        alert('您已同意该企业网络的邀请');
      } else if (data.state === 1252) {
        //EditCard.editCard(projectId, authType, 1, Enterprise.options.inviterAccountId);
      } else if (data.state === 2) {
        alert('您的申请已提交，请等待管理员审批');
      } else {
        alert('操作失败', 2);
      }
      dialogBoxForAddEnterprise.closeDialog();
    }).fail();
  };
  Enterprise.validPassword = function (projectId, companyName) {
    require.async(['./tpl/validPassword.html', 'dialog'], function (tpl) {
      easyDialog.open({
        dialogBoxID: 'dialogBoxValidate',
        fixed: false,
        container: {
          header: '提示',
          content: doT.template(tpl)(),
          width: 400,
        },
        callback: function () {},
      });
      var $dialog = $('#dialogBoxValidate');
      var $input = $dialog.find('.inputBox');
      $input.on('keyup', function (event) {
        if (event.keyCode === 13) {
          $dialog.find('.btnPasswordValidate').trigger('click');
        }
      });
      $dialog.on('click', '.btnPasswordValidate', function () {
        var password = $input.val();
        var $btn = $(this);
        if (!password.length) {
          alert('请输入密码', 2);
        } else {
          $btn.prop('disabled', true).css('cursor', 'not-allowed');
            hotelController.validateExitProject({
            password: password,
            projectId: projectId,
          }).done(function (result) {
            if (result === 2) {
              alert('密码错误', 3);
              $input.val('').focus();
            } else {
              // result
              // 0 failed
              // 1 success
              // 2 password error
              // 3 need transfter admin
              // 4 need apply to Mingdao
              easyDialog.close('dialogBoxValidate');
              switch (result) {
                case 1:
                case 3:
                  Enterprise.transferAdminProject(projectId, companyName, password, result);
                  break;
                case 4:
                  alert('您是该企业网络唯一成员，无法退出，请联系明道客服', 3);
                  break;
                case 0:
                default:
                  alert('操作失败');
              }
            }
          }).always(function () {
            $btn.prop('disabled', false).css('cursor', 'pointer');
          });
        }
      });
    });
  };
  // 指定同事
  //Enterprise.transferAdminProject = function (projectId, companyName, password, type) {
  //  var tpl = require('./tpl/dialogExit.html');
  //  var needTransfer = type === 3;
  //  var contentHtml = doT.template(tpl)({
  //    needTransfer: needTransfer,
  //    companyName: companyName,
  //  });
  //  require.async('dialog', function () {
  //    easyDialog.open({
  //      dialogBoxID: 'dialogBoxTransferAdminProject',
  //      fixed: false,
  //      container: {
  //        header: md_lang.ACC0801129 || '提示',
  //        content: contentHtml,
  //        width: 400,
  //      },
  //    });
  //    $('#dialogBoxTransferAdminProject').on('click', '.selectUserTransfer', function () {
  //      var $this = $(this);
  //      require.async('dialogSelectUser', function () {
  //        $this.dialogSelectUser({
  //          title: md_lang.ACC0802036 || '指定管理员',
  //          zIndex: 100,
  //          showMoreInvite: false,
  //          SelectUserSettings: {
  //            projectId: projectId,
  //            filterAll: true,
  //            filterFriend: true,
  //            filterOtherProject: true,
  //            filterAccountIds: [md.global.Account.accountId],
  //            unique: true,
  //            callback: function (userInfo) {
  //              var user = userInfo[0];
  //              $this.val(user.fullname);
  //              $this.next().data('accountId', user.accountId)
  //                .removeClass('Hidden');
  //            },
  //          },
  //        });
  //      });
  //    }).on('click', '.exitProject', function () {
  //      var accountId = $(this).data('accountId');
  //      var $btn = $(this);
  //      $btn.prop('disabled', true).css('cursor', 'not-allowed');
  //      account.exitProject({
  //        projectId: projectId,
  //        password: password,
  //        newAdminAccountId: accountId,
  //      }).done(function (result) {
  //        switch (result) {
  //          case 1:
  //            alert(md_lang.ACC0808116 || '退出成功');
  //            easyDialog.close('dialogBoxTransferAdminProject');
  //            Enterprise.init();
  //            break;
  //          case 3:
  //            Enterprise.transferAdminProject(projectId, companyName, password, result);
  //            break;
  //          case 4:
  //            alert(md_lang.ACC0808115 || '您是该企业网络唯一成员，无法退出，请联系明道客服', 3);
  //            break;
  //          case 0:
  //          default:
  //            alert(md_lang.ACC0808045 || '操作失败');
  //        }
  //      }).always(function () {
  //        $btn.prop('disabled', false).css('cursor', 'pointer');
  //      });
  //    });
  //  });
  //};
  return Enterprise;
});
