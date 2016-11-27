/* eslint-disable max-len */
seajs.config({
    base: '/',
    preload: [
      Function.prototype.bind ? '' : 'es5Safe',
      window.JSON ? '' : 'json',
    ],

    alias: {
        /* common*/
        'util': 'js/common/util.js',
        'moment': 'js/vendor/moment/moment.js',
        'querystring': 'js/common/querystring',
        'doT': 'js/uicontrol/doT/doT.js',
        'dot': 'js/uicontrol/doT/doT.js',
    },
    map: [
       [/^(.*\.(?:css|js|htm|html))(\?.*)?$/i, '$1?20160218083771'],
    ],
});
