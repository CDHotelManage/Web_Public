define(function(require, exports, module) {

	var doT = require("doT");
	require("tooltip");
	var account = require("../../../common/ajax/account.js");
	var workhistory = {};
	workhistory.options = {
		workID: 0
	};
	//首次调用
	workhistory.init = function() {
		require.async('./tpl/workhistory.html', function(rowsTpl) {
			var strHtml = doT.template(rowsTpl)({});
			$(".personalInfoMain").html(strHtml.toString());
			//加载用户工作经历
			workhistory.LoadWork();
			workhistory.LoadDate($("#workhistory"));
			$("#chNowWork").click(function(event) {
				workhistory.SelEndDate('Work');
			});
			$("#btnAddWork").click(function(event) {
				workhistory.AddUserJE('Work');
			});
			$("#btnSaveWork").click(function(event) {
				workhistory.UpdateUserJE('Work');
			});
			$("#spnWorkReset").click(function(event) {
				workhistory.Exit('Work');
			});
		});
	};

	//加载用户工作经历
	workhistory.LoadWork = function() {
		account.getAccountDetail({
			type: 1
		}).then(function(data) {
			if (data.state == 0) {
				var accountDetail = data.list;
				if (accountDetail.length >= 0) {
					var sb = new StringBuilder();
					var myHistory = accountDetail.length;
					for (var i = 0; i < myHistory; i++) {
						var len = parseInt(myHistory.toString().length);
						sb.Append("<div class='resuleItem2'><div name='sel' id='Sel" + accountDetail[i].autoId + "' class='Left ThemeBGColor5'><div><span class='Black16'>");
						sb.Append(accountDetail[i].name);
						sb.Append("</span> <span class='mLeft20'>");
						sb.Append(accountDetail[i].startDate + " 至 ");
						sb.Append(accountDetail[i].endDate == "" ? " 今 " : accountDetail[i].endDate);
						sb.Append("</span></div><div class='Blue'>");
						sb.Append(accountDetail[i].title);
						sb.Append("</div><div class='Blue'>");
						sb.Append(accountDetail[i].description);
						sb.Append("</div></div><div class='mLeft5 Right'>");
						sb.Append("<a href='javascript:;' class='updateHistoryBtn' accountAttr=\"" + accountDetail[i].autoId + "," + accountDetail[i].name + "," + accountDetail[i].title + "," + accountDetail[i].description + "," + accountDetail[i].startDate + "," + accountDetail[i].endDate + ",Work\">编辑</a>");
						sb.Append("<br /><a href='javascript:;' class='delHistoryBtn' accountAttr=\"" + accountDetail[i].autoId + "\">删除</a>");
						sb.Append("</div><div class='Clear'></div></div>");
					}
					$("#divTabWork .resumeModule").html(sb.toString());
					$(".updateHistoryBtn").click(function(event) {
						workhistory.ToUpdate($(this).attr("accountAttr"));
					});
					$(".delHistoryBtn").click(function(event) {
						workhistory.DelUserJE($(this).attr("accountAttr"));
					});
				}
				$("#spanWorkScore").text(data.score);
			} else {
				alert("请求数据失败，请稍后重试！")
			}
		}).fail();
	};
	//经历日期
	workhistory.LoadDate = function(el) {
		try {
			if ($(el).find('.date').length > 0) {
				return;
			}

			$(el).find("input[name='StartDate'],input[name='EndDate']").jSelectDate({
				css: "date",
				yearBeign: 1995,
				disabled: false,
				isShowLabel: true,
				isShowDay: false
			});
		} catch (e) {
			return;
		}
	};

	//更新工作经历
	/*workhistory.ToUpdate = function(ID, Name, Title, Description, StartDate, EndDate, Type) {
	 */
	workhistory.ToUpdate = function(dataString) {
		workhistory.options.subIndex = "Update" + dataString.split(',')[6];
		workhistory.options.workID = dataString.split(',')[0];
		$("#spnWorkReset").text(md_lang.docscenter_docs_content_modify_no);
		var divId = "divTab" + dataString.split(',')[6];
		$("#" + divId + " div[name='sel']").attr("class", "Left ThemeBGColor5");
		$("#" + divId + " #Sel" + dataString.split(',')[0] + "").attr("class", "Left ThemeBGColor6");
		$("#" + divId + " input[name='Name']").val(dataString.split(',')[1]);
		$("#" + divId + " input[name='Title']").val(dataString.split(',')[2]);
		$("#" + divId + " input[name='Description']").val(dataString.split(',')[3]);
		$("#" + divId + " input[name='StartDate']").val(dataString.split(',')[4]);
		$("#" + divId + " input[name='EndDate']").val(dataString.split(',')[5]);
		$("#btnAdd" + dataString.split(',')[6]).hide();
		$("#btnSave" + dataString.split(',')[6]).show();

		$("#selYeartxt" + dataString.split(',')[6] + "StartDate").val(dataString.split(',')[4].split('-')[0]);
		$("#selMonthtxt" + dataString.split(',')[6] + "StartDate").val(dataString.split(',')[4].split('-')[1]);
		if (dataString.split(',')[5].Trim() != "") {
			$("#selYeartxt" + dataString.split(',')[6] + "EndDate").val(dataString.split(',')[5].split('-')[0]);
			$("#selMonthtxt" + dataString.split(',')[6] + "EndDate").val(dataString.split(',')[5].split('-')[1]);
		} else {
			$("#chNow" + dataString.split(',')[6]).prop("checked", true);
			workhistory.SelEndDate(dataString.split(',')[6]);
		}
	};
	//删除教育经历和工作经历（根据ID)
	workhistory.DelUserJE = function(Id) {
		if (confirm(md_lang.myaccount_text_56 + "?")) {
			account.delAccountDetail({
				autoId: Id
			}).then(function(data) {
				if (data.state == 0) {
					workhistory.LoadWork();
					workhistory.Exit("Work");
				} else {
					alert("删除失败，请稍后重试！");
				}
			}).fail();
		}
	};
	//退出修改
	workhistory.Exit = function(type) {
		var divId = "divTab" + type;
		workhistory.options.subIndex = type;
		workhistory.options.workID = 0;
		$("#spnWorkReset").text(md_lang.myaccount_profile_job_reset);
		$("#" + divId + " div[name='sel']").attr("class", "Left ThemeBGColor5");
		$("#" + divId + " input[name='Name']").val("");
		$("#" + divId + " input[name='Title']").val("");
		$("#" + divId + " input[name='Description']").val("");

		$("#selYeartxt" + type + "StartDate>option").removeProp("selected").eq(0).prop("selected", true);
		$("#selMonthtxt" + type + "StartDate>option").removeProp("selected").eq(0).prop("selected", true);
		$("#" + divId + " input[name='StartDate']").val($("#selYeartxt" + type + "StartDate").val() + "-" + $("#selMonthtxt" + type + "StartDate").val());
		$("#" + divId + " input[name='EndDate']").val();
		$("#selYeartxt" + type + "EndDate>option").removeProp("selected").eq(0).prop("selected", true);
		$("#selMonthtxt" + type + "EndDate>option").removeProp("selected").eq(0).prop("selected", true);
		$("#chNow" + type).removeProp("checked");
		workhistory.SelEndDate(type);
		$("#" + divId + " input[name='EndDate']").val($("#selYeartxt" + type + "EndDate").val() + "-" + $("#selMonthtxt" + type + "EndDate").val());
		$("#btnSave" + type).hide();
		$("#btnAdd" + type).show();
	};
	//根据类型添加工作经历
	workhistory.AddUserJE = function(type) {

		var divId = "divTab" + type;
		if (workhistory.ValidateUserJE(type)) {
			var Name = $("#" + divId + " input[name='Name']").val();
			var Title = $("#" + divId + " input[name='Title']").val();
			var Description = $("#" + divId + " input[name='Description']").val();
			var StartDate = $("#" + divId + " input[name='StartDate']").val();
			var EndDate = $("#" + divId + " input[name='EndDate']").val();
			var isSoFar = 1;
			if ($("#chNow" + type).prop("checked")) {
				EndDate = "";
				isSoFar = 0
			}
			var ID = 0;
			/*$("#btnAdd" + type).attr("disabled", "disabled");*/
			workhistory.editAccountDetail(Name, Title, Description, StartDate, EndDate, ID, isSoFar, type);
		}
	};
	//跟新用户工作经历和教育经历（根据type分别）
	workhistory.UpdateUserJE = function(type) {
		var divId = "divTab" + type;
		if (workhistory.ValidateUserJE(type)) {
			/*$("#btnSave" + type).attr("disabled", "disabled");*/
			var ID = 0;
			ID = workhistory.options.workID;
			var Name = $("#" + divId + " input[name='Name']").val();
			var Title = $("#" + divId + " input[name='Title']").val();
			var Description = $("#" + divId + " input[name='Description']").val();
			var StartDate = $("#" + divId + " input[name='StartDate']").val();
			var EndDate = $("#" + divId + " input[name='EndDate']").val();
			var isSoFar = 1;
			if ($("#chNow" + type).prop("checked")) {
				EndDate = "";
				isSoFar = 0
			}
			workhistory.editAccountDetail(Name, Title, Description, StartDate, EndDate, ID, isSoFar, type);
		}
	};
	workhistory.editAccountDetail = function(Name, Title, Description, StartDate, EndDate, ID, isSoFar, type) {
		account.editAccountDetail({
			name: Name,
			title: Title,
			description: Description,
			startDate: StartDate,
			endDate: EndDate,
			type: 1,
			autoId: ID,
			isSoFar: isSoFar
		}).then(function(data) {
			if (data.state == 0) {
				workhistory.LoadWork();
				workhistory.Exit(type);
				alert("保存成功!");
				/*$("#btnSave" + type).removeAttr("disabled", "disabled");*/
			} else if (data.state == 1205) {
				alert("您输入的公司名称超出了最大长度，请重新输入！");
			} else if (data.state == 1206) {
				alert("您输入的期间最高职位超出了最大长度，请重新输入！");
			} else if (data.state == 1207) {
				alert("您输入的描述超出了最大长度，请重新输入！");
			} else {
				alert("工作履历保存失败，请稍后重试！");
			}
		}).fail();
	};
	//验证工作履历和教育经历
	workhistory.ValidateUserJE = function(type) {
		var pZH = /^[\u4e00-\u9fa5\w \(\)\（\）]+$/;
		var divId = "divTab" + type;
		var result = true;
		var Name = $("#" + divId + " input[name='Name']").val();
		var Title = $("#" + divId + " input[name='Title']").val();
		var StartDate = $("#" + divId + " input[name='StartDate']").val();
		var EndDate = $("#" + divId + " input[name='EndDate']").val();
		if (Name.Trim() == "") {
			result = false;
			alert(md_lang.myaccount_text_58, 3);

		} else if (Title == "") {
			result = false;
			alert(md_lang.myaccount_text_60, 3);
		} else if (!RegExp.isUnSymbols(Title.Trim())) {
			result = false;
			alert(md_lang.myaccount_text_62, 3);

		} else if (StartDate == "") {
			result = false;
			alert(md_lang.myaccount_text_64, 3);
		} else if (EndDate == "" && !$("#chNow" + type).prop("checked")) {
			result = false;
			alert(md_lang.myaccount_text_65, 3);
		}
		return result;
	};
	//设定结束日期
	workhistory.SelEndDate = function(Type) {
		if ($("#chNow" + Type).prop("checked")) {
			$("#selYeartxt" + Type + "EndDate,#selMonthtxt" + Type + "EndDate").attr("disabled", true);
		} else {
			$("#selYeartxt" + Type + "EndDate,#selMonthtxt" + Type + "EndDate").removeAttr("disabled");
		}
	};
	return workhistory;
});