$(document).ready(function () {
    //banner下面滑出菜单
    var $M = $(".index_menu_item");
    var bro = $.browser;
    $M.css({ "height": "0", "paddingTop": "0", "overflow": "hidden" });
    $(".clicktype").click(function () {
        if (bro.msie && bro.version < 7) {
            var index = $(this).index() - 12;
        } else {
            var index = $(this).index();
        }

        $M.eq(index).stop().animate({ "height": "440px", "paddingTop": "20px", "overflow": "visible", "top": "-260px" });
    })
    $(".deleteicon img").click(function () {
        if (bro.msie && bro.version < 7) {
            var index = $(this).index() - 12;
        } else {
            var index = $(this).index();
        }
        $M.eq(index).stop().animate({ "height": "0", "paddingTop": "0", "overflow": "hidden", "top": "0" })
    })
}); 