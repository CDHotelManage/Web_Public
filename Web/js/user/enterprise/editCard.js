define(function (require, exports, module) {
  var doT = require('doT');
  require('./enterprise.css');
  var account = require('../../../common/ajax/account');
  var util = require('util');
  var EditCard = {};
  require('tooltip');
  EditCard.options = {
    user: {
      companyName: "",
      department: "",
      job: "",
      jobNum: "",
      workSite: "",
      contactPhone: "",
    },
    settings: {
      isUserFillJobNumberEnabled: false,
      isUserFillWorkSiteEnabled: false,
      isUserFillCompanyEnabled: false,
    },
  };
  var validateEditCard = function (data, dialogBoxEditCard) {
    switch (data.state) {
      case 0:
        alert(md_lang.ACC0808091 || '您已成功加入该企业网络');
        window.location.reload();
        dialogBoxEditCard.closeDialog();
        break;
      case 2:
        alert(md_lang.ACC0808092 || '您的申请已提交，请等待管理员审批');
        window.location.reload();
        dialogBoxEditCard.closeDialog();
        break;
      case 203:
        alert(md_lang.ACC0808106 || '您已是该企业网络的成员', 3);
        break;
      case 1228:
      case 1248:
        alert(md_lang.ACC0808108 || '免费模式的明道企业网络无法加入，请开通企业版', 3);
        break;
      case 1249:
        alert(md_lang.ACC0808093 || '您申请加入的企业网络人数已超出上限，请提醒企业管理员购买用户增补包', 3);
        break;
      default:
        alert(md_lang.ACC0808045 || '操作失败', 2);
        break;
    }
  };
  // 编辑名片
  EditCard.editCard = function (projectId, authType, isAddTeam, inviterAccountId) {
    // 管理员在后台是否勾选需要用户填
    EditCard.getProjectUserSetting(projectId, function (dataStr) {
      EditCard.options.settings.isUserFillJobNumberEnabled = dataStr.isUserFillJobNumberEnabled;
      EditCard.options.settings.isUserFillWorkSiteEnabled = dataStr.isUserFillWorkSiteEnabled;
      EditCard.options.settings.isUserFillCompanyEnabled = dataStr.isUserFillCompanyEnabled;

      // 获取用户该网络编辑名片信息
      account.getUserCard({
        projectId: projectId,
        authType: authType,
      }).then(function (data) {
        if (data.state === 0) {
          var tpl = require('./tpl/editCard.html');
          var contentHtml = doT.template(tpl)({
            data: data,
            settings: EditCard.options.settings,
            isEdit: isAddTeam !== 1 && isAddTeam !== 2,
          });

          require.async('mdDialog', function () {
            var dialogBoxEditCard = $.DialogLayer({
              dialogBoxID: 'dialogBoxEditCard',
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

            var $cardDepartment = $('.cardDepartment');
            if ($cardDepartment.length) {
              EditCard.loadDepartment($cardDepartment, data.departments, data.department);
            }
            var $cardWorkSite = $('.cardWorkSite');
            if ($cardWorkSite.length) {
              EditCard.loadWorkSite($cardWorkSite, data.workSites, data.workSite);
            }

            // 部门和地址的选择*/
            $('.departmentDropdown,.workSiteDropdown').click(function (event) {
              if ($(this).hasClass('Gray_c6')) {
                return;
              }
              $(this).siblings('ol').toggle();
            });
            // 选择部门*/
            $('#dialogBoxEditCard .liEditCard.department ol li').click(function (event) {
              var department = $(this).text();
              $('.cardDepartment').val(department);
              $(this).parent('ol').hide();
            });
            // 选择地址*/
            $('#dialogBoxEditCard .liEditCard.workSite ol li').click(function (event) {
              var workSite = $(this).text();
              $('.cardWorkSite').val(workSite);
              $(this).parent('ol').hide();
            });

            $('.sureBtnForEditCard').on('click', function (event) {
              if (!EditCard.validateField()) {
                return;
              }
              if (isAddTeam === 1) {
                // 受邀加入网络
                account.addUserCardInProject({
                  projectId: projectId,
                  job: EditCard.options.user.job,
                  isDirectInvite: true, // 定向
                  department: EditCard.options.user.department,
                  companyName: EditCard.options.user.companyName,
                  workSite: EditCard.options.user.workSite,
                  jobNum: EditCard.options.user.jobNum,
                }).then(function (dataCard) {
                  validateEditCard(dataCard, dialogBoxEditCard);
                }).fail();
              } else if (isAddTeam === 2) {
                // 填写网络号加入网
                account.addUserCardInProject({
                  projectId: projectId,
                  job: EditCard.options.user.job,
                  isDirectInvite: false, // 非定向
                  department: EditCard.options.user.department,
                  companyName: EditCard.options.user.companyName,
                  workSite: EditCard.options.user.workSite,
                  jobNum: EditCard.options.user.jobNum,
                }).then(function (dataCard) {
                  validateEditCard(dataCard, dialogBoxEditCard);
                }).fail();
              } else {
                // 提交编辑信息
                account.editUserCard({
                  projectId: projectId,
                  department: EditCard.options.user.department,
                  job: EditCard.options.user.job,
                  companyName: EditCard.options.user.companyName,
                  workSite: EditCard.options.user.workSite,
                  jobNum: EditCard.options.user.jobNum,
                  contactPhone: EditCard.options.user.contactPhone,
                }).then(function (dataCard) {
                  if (dataCard.state === 0) {
                    dialogBoxEditCard.closeDialog();
                    alert(md_lang.ACC0808094 || '您的企业网络名片保存成功');
                  } else {
                    alert(md_lang.ACC0808045 || '操作失败', 2);
                  }
                }).fail();
              }
            });
          });
        } else {
          alert(md_lang.ACC0808045 || '操作失败', 2);
        }
      });
    });
  };

  // 管理员在后台是否勾选需要用户填
  EditCard.getProjectUserSetting = function (projectId, callback) {
    account.getProjectUserSetting({
      projectId: projectId,
    }).then(function (data) {
      if (data.state === 0) {
        callback(data);
      }
    });
  };

  EditCard.validateField = function () {
    var $cardCompanyName = $('.cardCompanyName');
    var $cardDepartment = $('.cardDepartment');
    var $cardJob = $('.cardJob');
    var $cardJobNum = $('.cardJobNum');
    var $cardWorkSite = $('.cardWorkSite');
    var $cardContactPhone = $('.cardContactPhone');

    if ($cardCompanyName.length) {
      var companyName = $.trim($cardCompanyName.val());
      if (!companyName) {
        $cardCompanyName.focus();
        alert(md_lang.ACC0808095 || '公司名称不能为空', 3);
        return false;
      }
      EditCard.options.user.companyName = companyName;
    }

    if ($cardDepartment.length) {
      var department = $.trim($cardDepartment.val());
      if (!department) {
        $cardDepartment.focus();
        alert(md_lang.ACC0808096 || '部门不能为空', 3);
        return false;
      }
      EditCard.options.user.department = department;
    }

    if ($cardJob.length) {
      var job = $.trim($cardJob.val());
      if (!job) {
        $cardJob.focus();
        alert(md_lang.ACC0808097 || '职位不能为空', 3);
        return false;
      }
      EditCard.options.user.job = job;
    }

    if ($cardJobNum.length) {
      var jobNum = $.trim($cardJobNum.val());
      if (!jobNum) {
        $cardJobNum.focus();
        alert(md_lang.ACC0808098 || '工号不能为空', 3);
        return false;
      }
      EditCard.options.user.jobNum = jobNum;
    }

    if ($cardWorkSite.length) {
      var workSite = $.trim($cardWorkSite.val());
      if (!workSite) {
        $cardWorkSite.focus();
        alert(md_lang.ACC0808099 || '工作地点不能为空', 3);
        return false;
      }
      EditCard.options.user.workSite = workSite;
    }

    if ($cardContactPhone.length) {
      var contactPhone = $.trim($cardContactPhone.val());
      if (!contactPhone) {
        $cardContactPhone.focus();
        alert(md_lang.ACC0808100 || '工作电话不能为空', 3);
        return false;
      } else if (!RegExp.isTel(contactPhone) && !RegExp.isMobile(contactPhone)) {
        $cardContactPhone.focus();
        alert(md_lang.ACC0808101 || '工作电话格式不正确', 3);
        return false;
      }
      EditCard.options.user.contactPhone = contactPhone;
    }

    return true;
  };

  // 部门
  EditCard.loadDepartment = function ($txtDeparment, departments, defaultDepartment) {
    if (departments) {
      var dataArr = [{
        id: "",
        name: md_lang.TXL0801038 || '部门',
      }];
      for (var i = 0, length = departments.length; i < length; i++) {
        var item = departments[i];
        dataArr.push({
          id: item,
          name: item,
        });
      }

      var selectDepartment = defaultDepartment || '';
      EditCard.loadSelect($txtDeparment, dataArr, 11, selectDepartment);
    }
  };
  // 工作点
  EditCard.loadWorkSite = function ($txtWorkSite, workSites, defaultWorkSite) {
    var settings = EditCard.options.settings;
    // if (settings.isUserFillWorkSiteEnabled) {
    if (workSites) {
      var dataArr = [{
        id: "",
        name: md_lang.TXL0801041 || '工作地点',
      }];
      for (var i = 0, length = workSites.length; i < length; i++) {
        var item = workSites[i];
        dataArr.push({
          id: item,
          name: item,
        });
      }

      var selectWorkSite = defaultWorkSite || '';

      EditCard.loadSelect($txtWorkSite, dataArr, 10, selectWorkSite);
    }
  };
  // 绑定MDSelect
  EditCard.loadSelect = function ($element, dataArr, zIndex, defaultSelect) {
    require.async("select", function () {
      $element.MDSelect({
        dataArr: dataArr,
        defualtSelectedValue: defaultSelect,
        showType: 4,
        wordLength: 40,
        zIndex: zIndex,
        onChange: function (value, text) {
          if (value) {
            $element.parents(".liEditCard:first").addClass("Gray_6");
          } else {
            $element.parents(".liEditCard:first").removeClass("Gray_6");
          }
        },
      });
      if ($element.val()) {
        $element.parents(".liEditCard:first").addClass("Gray_6");
      }
    });
  };
  return EditCard;
});
