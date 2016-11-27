define(function (require, exports, module) {
  var Favico = require('modules/uicontrol/favicojs/favico');
  var $redDot = $('#topBarContainer .messageLittleRedDot');
  var _Favico = !$.browser.msie ? new Favico({
    position: 'popFade',
  }) : null;
  var _SmallbellCount = null;

  module.exports = {
    // `small bell` count closure
    smallBellCount: function () {
      if (_SmallbellCount) return _SmallbellCount;

      var _modelCount;
      var _viewCount;

      init(0);

      return (_SmallbellCount = {
        init: init,
        setNum: setNum,
        getNum: getNum,
        updateNum: updateNum,
        getState: getState,
        resetNum: resetNum,
      });

      function init(num) {
        setNum(num);
      }

      function setNum(num) {
        if (!_.isNumber(num)) {
          // compatible
          num = 0;
        }
        var timer = null;
        _modelCount = parseInt(num, 10);
        _viewCount = Math.min(_modelCount, 99);
        $redDot.toggle(_viewCount > 0)
          .data('count', _modelCount)
          .text(_viewCount >= 99 ? '99' : _viewCount);
        // set favico number
        if (_Favico) {
          // FIXME: favico throw error too much request
          if (timer) {
            clearTimeout(timer);
          }
          timer = setTimeout(function () {
            clearTimeout(timer);
            _Favico.badge(_viewCount);
          }, 500);
        }
      }

      function getNum() {
        return {
          viewCount: _viewCount,
          modelCount: _modelCount,
        };
      }

      function getState() {
        return _modelCount > 0;
      }

      function updateNum(num, isRefresh) {
        var _num = isRefresh ? num : (_modelCount + parseInt(num, 10));
        setNum(_num);
      }

      function resetNum() {
        setNum(0);
      }
    },
  };
});
