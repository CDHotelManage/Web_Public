define(function (require, exports, module) {
  var doT = require('doT');
  require('tooltip');
  var account = require('../../../common/ajax/account');
  var moment = require('moment');
  require('duedatepicker');
  var util = require('util');
  var WorkOrEdu = {};
  WorkOrEdu.options = {
    WorkOrEduId: 0,
  };
  // 首次调用
  WorkOrEdu.init = function (type) {
    var getAccountType = type === 'Work' ? 1 : 2;
    account.getAccountDetail({
      type: getAccountType,
    }).then(function (data) {
      if (data.state === 0) {
        var tpl = type === 'Work' ? './tpl/workhistory.html' : './tpl/education.html';
        require.async(tpl, function (rowsTpl) {
          var strHtml = doT.template(rowsTpl)({
            data: data,
            type: type,
          });
          $('.personalInfoMain').html(strHtml);
          WorkOrEdu.updateOrdel(type);
          // 加载用户工作经历
          $('#chNow' + type + '').on('click', function (event) {
            WorkOrEdu.SelEndDate(type);
          });
          $('#btnAdd' + type + '').on('click', function (event) {
            WorkOrEdu.AddUserJE(type);
          });
          $('#btnSave' + type + '').on('click', function (event) {
            WorkOrEdu.UpdateUserJE(type);
          });
          $('#spn' + type + 'Reset').on('click', function (event) {
            WorkOrEdu.Exit(type);
          });
          WorkOrEdu.LoadDate();
        });
        var accountDetail = data.list;
        $('.updateHistoryBtn').on('click', function (event) {
          var $this = $(this);
          var autoId = $this.attr('autoId');
          var name = $this.attr('name');
          var title = $this.attr('title');
          var description = $this.attr('description');
          var startDate = $this.attr('startDate');
          var endDate = $this.attr('endDate');
          var typeNum = $this.attr('type');
          WorkOrEdu.ToUpdate(autoId, name, title, description, startDate, endDate, typeNum);
        });
        $('.delHistoryBtn').off('click').on('click', function (event) {
          WorkOrEdu.DelUserJE($(this).attr('accountAttr'), type);
        });
      } else {
        alert('请求数据失败，请稍后重试！', 2, 2000);
      }
    }).fail();
  };
  WorkOrEdu.updateOrdel = function (type) {
    $('.updateHistoryBtn').on('click', function (event) {
      var $this = $(this);
      var autoId = $this.attr('autoId');
      var name = $this.attr('name');
      var title = $this.attr('title');
      var description = $this.attr('description');
      var startDate = $this.attr('startDate');
      var endDate = $this.attr('endDate');
      var typeNum = $this.attr('type');
      WorkOrEdu.ToUpdate(autoId, name, title, description, startDate, endDate, typeNum);
    });
    $('.delHistoryBtn').off('click').on('click', function (event) {
      WorkOrEdu.DelUserJE($(this).attr('accountAttr'), type);
    });
  };
  // 加载用户工作经历
  WorkOrEdu.LoadWorkOrEdu = function (type) {
    var getAccountType = type === 'Work' ? 1 : 2;
    account.getAccountDetail({
      type: getAccountType,
    }).then(function (data) {
      if (data.state === 0) {
        var accountDetail = data.list;
        if (accountDetail.length >= 0) {
          var sb = '';
          var myHistory = accountDetail.length;
          for (var i = 0; i < myHistory; i++) {
            sb += '<div class="resuleItem2 clearfix mTop10">';
            sb += '<div name="sel" id="Sel' + accountDetail[i].autoId + '" class="Left ThemeBGColor5"><div>';
            sb += '<span class="Black16 overflow_ellipsis Width200" title="' + util.htmlEncodeReg(accountDetail[i].name) + '">' + util.htmlEncodeReg(accountDetail[i].name) + '</span> ';
            sb += '<span class="mLeft20">' + accountDetail[i].startDate + ' ' + (md_lang.ACC0802008 || '至') + ' ';
            sb += accountDetail[i].endDate === '' ? ' 今 ' : accountDetail[i].endDate;
            sb += '</span>';
            sb += '</div><div class="Blue AllBreak">' + util.htmlEncodeReg(accountDetail[i].title) + '</div>';
            sb += '<div class="Blue AllBreak">' + util.htmlEncodeReg(accountDetail[i].description) + '</div>';
            sb += '</div>';
            sb += '<div class="mLeft5 Right">';
            sb += '<a href="javascript:;" class="updateHistoryBtn" autoId="' + accountDetail[i].autoId + '" ';
            sb += 'name="' + util.htmlEncodeReg(accountDetail[i].name) + '" title="' + util.htmlEncodeReg(accountDetail[i].title) + '" ';
            sb += 'description="' + util.htmlEncodeReg(accountDetail[i].description) + '" startDate="' + accountDetail[i].startDate + '" ';
            sb += 'endDate="' + accountDetail[i].endDate + '" type="' + type + '">' + (md_lang.ACC0802009 || '编辑') + '</a><br />';
            sb += '<a href="javascript:;" class="delHistoryBtn" accountAttr="' + accountDetail[i].autoId + '">' + (md_lang.ACC0802010 || '删除') + '</a>';
            sb += '</div>';
            sb += '</div>';
          }
          $('#divTab' + type).find('.resumeModule').html(sb.toString());
          WorkOrEdu.updateOrdel(type);
        }
      } else {
        alert('请求数据失败，请稍后重试！', 2, 2000);
      }
    }).fail();
  };
  // 经历日期
  WorkOrEdu.LoadDate = function () {
    // 开始日期//  结束日期
    $('input[name="startDate"],input[name="endDate"]')
      .datepicker({
        dateFormat: 'yy-mm-dd',
        changeMonth: true,
        changeYear: true,
        yearRange: '1900:' + new Date().addSomeDay(1).format('yyyy'),
      });
  };
  // 更新工作经历
  WorkOrEdu.ToUpdate = function (autoId, name, title, description, startDate, endDate, type) {
    WorkOrEdu.options.subIndex = 'Update' + type;
    WorkOrEdu.options.WorkOrEduId = autoId;
    $('#spn' + type + 'Reset').text(md_lang.docscenter_docs_content_modify_no);
    var divId = 'divTab' + type;
    $('#' + divId + ' div[name="sel"]').attr('class', 'Left ThemeBGColor5');
    $('#' + divId + ' #Sel' + autoId + '').attr('class', 'Left ThemeBGColor6');
    $('#' + divId + ' input[name="nameWE"]').val(name);
    $('#' + divId + ' input[name="titleWE"]').val(title);
    $('#' + divId + ' input[name="description"]').val(description);
    $('#txt' + type + 'StartDate').val(startDate);
    $('#txt' + type + 'EndDate').val(endDate);
    $('#btnAdd' + type).hide();
    $('#btnSave' + type).show();
    if (endDate === '') {
      $('#chNow' + type).prop('checked', true);
      WorkOrEdu.SelEndDate(type);
    }
  };
  // 删除教育经历和工作经历（根据ID)
  WorkOrEdu.DelUserJE = function (Id, type) {
    if (confirm(md_lang.myaccount_text_56 + '?')) {
      account.delAccountDetail({
        autoId: Id,
      }).then(function (data) {
        if (data.state === 0) {
          WorkOrEdu.LoadWorkOrEdu(type);
          WorkOrEdu.Exit(type);
        } else {
          alert(md_lang.ACC0808130 || '删除失败', 2);
        }
      }).fail();
    }
  };
  // 退出修改
  WorkOrEdu.Exit = function (type) {
    var divId = 'divTab' + type;
    WorkOrEdu.options.subIndex = type;
    WorkOrEdu.options.WorkOrEduId = 0;
    $('#spn' + type + 'Reset').text(md_lang.myaccount_profile_job_reset);
    $('#' + divId + ' div[name="sel"]').attr('class', 'Left ThemeBGColor5');
    $('#' + divId + ' input[name="nameWE"]').val('');
    $('#' + divId + ' input[name="titleWE"]').val('');
    $('#' + divId + ' input[name="description"]').val('');
    $('#txt' + type + 'StartDate').val('');
    $('#txt' + type + 'EndDate').val('');
    $('#chNow' + type).removeProp('checked');
    WorkOrEdu.SelEndDate(type);
    $('#btnSave' + type).hide();
    $('#btnAdd' + type).show();
  };
  // 根据类型添加工作经历
  WorkOrEdu.AddUserJE = function (type) {
    var divId = 'divTab' + type;
    if (WorkOrEdu.ValidateUserJE(type)) {
      var name = $('#' + divId + ' input[name="nameWE"]').val();
      var title = $('#' + divId + ' input[name="titleWE"]').val();
      var description = $('#' + divId + ' input[name="description"]').val();
      var startDate = $('#txt' + type + 'StartDate').val();
      var endDate = $('#txt' + type + 'EndDate').val();
      var isSoFar = 1;
      if ($('#chNow' + type).prop('checked')) {
        endDate = '';
        isSoFar = 0;
      }
      var ID = 0;
      WorkOrEdu.editAccountDetail(name, title, description, startDate, endDate, ID, isSoFar, type);
    }
  };
  // 跟新用户工作经历和教育经历（根据type分别）
  WorkOrEdu.UpdateUserJE = function (type) {
    var divId = 'divTab' + type;
    if (WorkOrEdu.ValidateUserJE(type)) {
      var ID = 0;
      ID = WorkOrEdu.options.WorkOrEduId;
      var name = $('#' + divId + ' input[name="nameWE"]').val();
      var title = $('#' + divId + ' input[name="titleWE"]').val();
      var description = $('#' + divId + ' input[name="description"]').val();
      var startDate = $('#' + divId + ' input[name="startDate"]').val();
      var endDate = $('#' + divId + ' input[name="endDate"]').val();
      var isSoFar = 1;
      if ($('#chNow' + type).prop('checked')) {
        endDate = '';
        isSoFar = 0;
      }
      WorkOrEdu.editAccountDetail(name, title, description, startDate, endDate, ID, isSoFar, type);
    }
  };
  WorkOrEdu.editAccountDetail = function (name, title, description, startDate, endDate, ID, isSoFar, type) {
    var getAccountType = type === 'Work' ? 1 : 2;
    account.editAccountDetail({
      name: name,
      title: title,
      description: description,
      startDate: startDate,
      endDate: endDate,
      type: getAccountType,
      autoId: ID,
      isSoFar: isSoFar,
    }).then(function (data) {
      if (data.state === 0) {
        WorkOrEdu.LoadWorkOrEdu(type);
        WorkOrEdu.Exit(type);
        alert(md_lang.ACC0802011 || '保存成功');
      } else {
        var alertMsg = '';
        switch (data.state) {
          case 1205:
            alertMsg = getAccountType === 1 ? (md_lang.ACC0808131 || '您输入的公司名称超出了最大长度') : (md_lang.ACC0808132 || '您输入的学校名称超出了最大长度');
            break;
          case 1206:
            alertMsg = getAccountType === 1 ? (md_lang.ACC0808133 || '您输入的期间最高职位超出了最大长度') : (md_lang.ACC0808134 || '您输入的专业和学历超出了最大长度');
            break;
          case 1207:
            alertMsg = getAccountType === 1 ? (md_lang.ACC0808135 || '您输入的描述超出了最大长度') : (md_lang.ACC0808136 || '您输入的核心课程超出了最大长度');
            break;
          default:
            alertMsg = md_lang.myaccount_text_47 || '保存失败';
            break;
        }
        alert(alertMsg, 2);
      }
    }).fail();
  };
  // 验证工作履历和教育经历
  WorkOrEdu.ValidateUserJE = function (type) {
    var divId = 'divTab' + type;
    var result = false;
    var name = $('#' + divId + ' input[name="nameWE"]').val();
    var title = $('#' + divId + ' input[name="titleWE"]').val();
    var startDate = $('#' + divId + ' input[name="startDate"]').val();
    var endDate = $('#' + divId + ' input[name="endDate"]').val();
    var message = '';
    if (!$.trim(name)) {
      message = type === 'Work' ? md_lang.myaccount_text_58 : md_lang.myaccount_text_59;
    } else if (!title) {
      message = type === 'Work' ? md_lang.myaccount_text_60 : md_lang.myaccount_text_61;
    } else if (!RegExp.isUnSymbols($.trim(title))) {
      message = type === 'Work' ? md_lang.myaccount_text_62 : md_lang.myaccount_text_63;
    } else if (!startDate) {
      message = md_lang.myaccount_text_64;
    } else if (moment(startDate) > moment(new Date)) {
      message = md_lang.ACC0808137 || '您输入的日期不正确';
    } else if (!$('#chNow' + type).prop('checked')) {
      if (!endDate) {
        message = md_lang.myaccount_text_65;
      } else {
        if (moment(endDate) > moment(new Date) || moment(startDate) > moment(endDate)) {
          message = md_lang.ACC0808137 || '您输入的日期不正确';
        } else {
          result = true;
        }
      }
    } else {
      result = true;
    }
    if (!result) {
      alert(message, 3, 2000);
    }
    return result;
  };
  // 设定结束日期
  WorkOrEdu.SelEndDate = function (type) {
    if ($('#chNow' + type).prop('checked')) {
      $('#txt' + type + 'EndDate').attr("disabled", true).addClass('Gray_c6');
    } else {
      $('#txt' + type + 'EndDate').removeAttr('disabled').removeClass('Gray_c6');
    }
  };
  return WorkOrEdu;
});
