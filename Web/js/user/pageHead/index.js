define(function pageHeadIndex(require, exports, module) {
  __webpack_public_path__ = window.__webpack_public_path__;
  var pageHead = require('./pageHead');
  var util = require('util');
  var request = util.getRequest();
  if (request['account']) {
      md.global.Account.accountId = request['account'];
  }
  pageHead.init();
});
