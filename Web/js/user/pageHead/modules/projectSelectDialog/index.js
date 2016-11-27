define(function (require, exports, module) {
  var easyDialog = require('dialog');
  var SelectProjectDialog = function (opts) {
    var projects = md.global.Account.projects;
    if (projects && projects.length === 1) {
      SelectProjectDialog.checkProject(projects[0].projectId);
    } else {
      this.init();
    }
  };
  require('./style.css');

  SelectProjectDialog.prototype.init = function () {
    var template = require('./content.html');
    var $content = $(require('doT').template(template)({
      projects: md.global.Account.projects,
    }));

    easyDialog.open({
      dialogBoxID: 'projectDialogSelect',
      container: {
        width: 500,
      },
      drag: true,
      fixed: false,
      zIndex: 100,
    });
    easyDialog.setContent('projectDialogSelect', $content);

    $content.on('click', '.singleProject', function () {
      var $this = $(this);
      var projectId = $this.data('projectid');
      SelectProjectDialog.checkProject(projectId);
    });
  };

  SelectProjectDialog.checkProject = function (projectId) {
    require.async('mdFunction', function (Function) {
      Function.expireDialogAsync(projectId).then(function () {
        easyDialog.close('projectDialogSelect');
        window.location.href = '/admin/index/' + projectId;
      });
    });
  };

  module.exports = function (opts) {
    var dialog = new SelectProjectDialog(opts);
  };
});
