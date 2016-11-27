define(function (require, exports, module) {
  var Common = {};
  Common.ajaxObj = null;

  Common.init = function () {
    if (Common.ajaxObj) {
      Common.ajaxObj.abort();
    }
  };

  return Common;
});
