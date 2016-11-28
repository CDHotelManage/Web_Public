define(function (require, exports, module) {
    var ctrlName = 'Hotel';
    /**
     * 这是一个Account类
     */
    var account = {
        /**
         * 获取账户一览信息
         * @param {Object} args 请求参数
         * @param {Object} options 配置参数
         * @param {Boolean} options.silent 是否禁止错误弹层
         * @returns {Promise<AccountListModel, ErrorModel>} 
         */
        createHotel: function (args, options) {
            return $.api(ctrlName, 'Add', args, options);
        },

        getHotelList: function (args, options) {
            return $.api(ctrlName, 'GetAllHotelInfo', args, options);
        },

    };
    module.exports = account;
});