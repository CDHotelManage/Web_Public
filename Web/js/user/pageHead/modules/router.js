define(function (require, exports, module) {
  var TYPES = {
    'CHAT': 'CHAT',
    'FEED': 'FEED',
    'TASK': 'TASK',
    'CALENDAR': 'CALENDAR',
    'KC': 'KC',
  };
  var REGS = {
    chat: /\/chat/i,
    post: /\/feed/i,
    task: /\/apps\/task/i,
    calendar: /\/apps\/calendar/i,
    knowledge: /\/apps\/kc/i,
  };

  var _type;

  module.exports = function () {
    if (!_type) {
      var path = window.location.pathname;
      $.each(REGS, function (key, value) {
        if (value.test(path)) {
          _type = key;
          return false;
        }
      });
    }
    return {
      type: _type,
    };
  };
});
