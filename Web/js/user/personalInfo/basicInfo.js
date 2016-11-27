define(function (require, exports, module) {
  var doT = require('doT');
  require('tooltip');
  var util = require('util');
  var account = require('../../account/account');
  var moment = require('moment');
  var common = require('../common');
  require('duedatepicker');

  var BasicInfo = {};
  BasicInfo.options = {};
  // 首次调用
  BasicInfo.init = function () {
      var loginAccount="";
      var request = util.getRequest();
      if (request['account']) {
          loginAccount = request['account'];
      }
      common.ajaxObj = account.getAccountBasicInfo({ AccountId: loginAccount });
    common.ajaxObj.then(function (data) {
      if (data && data.result) {
        require.async('./tpl/basicInfo.html', function (rowsTpl) {
          var strHtml = doT.template(rowsTpl)({});
          $('.personalInfoMain').html(strHtml.toString()); // 绑定头部到指定位置
          // 基本信息
          $("#divTabProfile input[name='Fullname']").val(data.result.userName);
          //var birthdate = null;
          //if (data.result.birthdate) {
          //    birthdate = data.result.birthdate.split(' ')[0];
          //}
          //$('#txtBirthday').val(birthdate);
          //BasicInfo.LoadDate();
          if (!data.result.sex) {
            $("#divTabProfile input[name='Gender']").first().prop('checked', true);
          }
         else {
            $("#divTabProfile input[name='Gender']").last().prop('checked', true);
          }
          //$("#divTabProfile input[name='CompanyName']").val(data.result.companyName);
          //$("#divTabProfile input[name='Job']").val(data.profession);
          //$("#divTabProfile input[name='address']").val(data.address);
          // 保存基本信息
          $('#btnSaveProfile').click(function () {
            BasicInfo.AddProfile();
          });
        });
      }
    }).fail();
  };
  // 添加用户基本信息
  BasicInfo.AddProfile = function () {
    if (BasicInfo.ValidateProfile()) {
      BasicInfo.AddProfileDetail();
    }
  };
  // 验证基本信息
  BasicInfo.ValidateProfile = function () {
    var result = true;
    var Fullname = $("#divTabProfile input[name='Fullname']").val();
    var Job = $("#divTabProfile input[name='Job']").val();
    var address = $("#divTabProfile input[name='address']").val();
    var birthdate = $('#txtBirthday').val();
    var myDate = new Date;
    var birthTime = moment(birthdate);
    var nowTime = moment(myDate);
    if (birthTime > nowTime) {
      alert( '您输入的生日超过当前时间！', 3);
      return;
    }
    if (!$.trim(Fullname)) {
      alert("名字不能为空", 3);
      result = false;
    }
    return result;
  };
  // 添加用户基本信息
  BasicInfo.AddProfileDetail = function () {
    var visibleLabel = '';
    var checkedInput = '';
    $("label[id*='Label_']").each(function () {
      if ($(this).is(':visible')) {
        visibleLabel += this.id.split('_')[1];
        if ($(this).find('input').prop('checked')) {
          checkedInput += $(this).find('input').val();
        }
      }
    });

    var fullname = $.trim($("#divTabProfile input[name='Fullname']").val());
    var companyName = $("#divTabProfile input[name='CompanyName']").val();
    var job = $("#divTabProfile input[name='Job']").val();
    var address = $("#divTabProfile input[name='address']").val();
    var birthdate = $("#txtBirthday").val();
    var gender = 0;
    $("#divTabProfile input[name='Gender']").each(function (index) {
      if ($(this).prop("checked")) {
        gender = $(this).val();
      }
    });

    var jobNumber = $("input[name='JobNumber']").val();

    account.editAccountBasicInfo({
      fullname: fullname,
      companyName: companyName,
      profession: job,
      birthdate: birthdate,
      gender: gender,
      address: address,
    }).then(function (data) {
      if (data.state === 0) {
        alert("保存成功", 1);
      } else if (data.state === 1210) {
        alert( "您输入的姓名超出了最大长度", 2);
      } else if (data.state === 1211) {
        alert( "您输入的公司名称超出了最大长度", 2);
      } else if (data.state === 1212) {
        alert( "您输入的职业超出了最大长度", 2);
      } else {
        alert( '操作失败', 2);
      }
    }).fail();
  };

  BasicInfo.LoadDate = function () {
    // 生日日期
    $('#txtBirthday').datepicker({
      dateFormat: 'yy-mm-dd',
      changeMonth: true,
      changeYear: true,
      yearRange: '1900:' + new Date().addSomeDay(1).format('yyyy'),
    });
  };

  return BasicInfo;
});
