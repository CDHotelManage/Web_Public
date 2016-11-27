define(function (require, exports, module) {
  var accountSettingController = require('modules/common/ajax/accountSetting');
  var isShow = false;
  require("./style.css");
  var Theme = {
    Options: {
      currentPicCount: 0,
      themes: null,
    },
    bindEvent: function () {
      var $themeCarousel = $('.themeCarouselBG');

      $themeCarousel.find('.closeTheme').on('click', function () {
        Theme.hide();
        $.publish('removeMdTopTheme');
      });

      $themeCarousel.on('click', '.themeItem', function () {
        Theme.setTheme($(this).attr('val'));
      });

      $themeCarousel.on('click', '.backToGuide', function () {
        $('#topBarContent').find('.topbarGuide').trigger('click');
      });

      this.bindJcarousellite();

      $(window).resize(function () {
        var picVisibleCount = Theme.getPicVisibleCount();
        if (Theme.Options.currentPicCount != picVisibleCount) {

          Theme.Options.currentPicCount = picVisibleCount;
          $('.themeListContainer').html(Theme.getThemeHtml());
          Theme.bindJcarousellite();
        }
      });

      $(document).on('click.theme', function (event) {
        if (!isShow) return;
        if (!$(event.target).hasClass('themeChoose') && !$(event.target).closest('.themeCarouselBG').length) {
          $('.themeCarouselBG').stop().slideUp(150);
        }
      });
    },
    hide: function () {
      $('.themeCarouselBG').stop().slideUp(150);
      isShow = false;
    },
    show: function () {
      $('.themeCarouselBG').stop().slideDown(150);
      $.publish('addMdTopTheme');
      isShow = true;
    },
    bindJcarousellite: function () {
      require.async('jcarousellite', function () {
        var carouselElement = '.carousel' + Theme.Options.currentPicCount;
        var $carousel = $(carouselElement);
        $carousel.find('.themeList').jCarouselLite({
          btnPrev: carouselElement + ' .prevTheme',
          btnNext: carouselElement + ' .nextTheme',
          visible: Theme.Options.currentPicCount,
          scroll: 5,
          speed: 100,
          circular: false
        });
      });
    },
    //获取当前分辨率下显示图片数量
    getPicVisibleCount: function () {
      var clientWidth = document.body.clientWidth;
      var picVisibleCount = 0;
      if (clientWidth >= 1870) {
        picVisibleCount = 10;
      } else if (clientWidth < 1870 && clientWidth >= 1670) {
        picVisibleCount = 9;
      } else if (clientWidth < 1670 && clientWidth >= 1470) {
        picVisibleCount = 8;
      } else if (clientWidth < 1470 && clientWidth >= 1330) {
        picVisibleCount = 7;
      } else if (clientWidth < 1330 && clientWidth >= 1120) {
        picVisibleCount = 6;
      } else {
        picVisibleCount = 5;
      }
      return picVisibleCount;
    },
    getData: function (element, addBackBtn) {
      var $themeCarouselBG = element.find('.themeCarouselBG');
      var dfd = $.Deferred();
      dfd.done(function (elem) {
        if (!addBackBtn) {
          elem.find('.themeDesc').html("<i class='icon'></i><span>" + (md_lang.WB248 || '个性化你的明道') + "</span>");
        } else {
          elem.find('.themeDesc').html("<i class='icon'></i><span>" + (md_lang.WB248 || '个性化你的明道') + "</span>" + "<i class='icon-arrow-left-border mLeft50 mRight5'></i><span class='backToGuide Hand'>" + ('继续探索明道') + "</span>");
        }
      });
      if ($themeCarouselBG && $themeCarouselBG.length > 0) {
        dfd.resolve($themeCarouselBG);
        Theme.show();
      } else {
        accountSettingController.getThemes().then(function (data) {
          if (data && data.length) {
            Theme.Options.themes = data;
            Theme.Options.currentPicCount = Theme.getPicVisibleCount();
            var html = new StringBuilder();
            html.Append("<div class='themeCarouselBG Hidden'>");

            html.Append("<div class='themeDesc'>");
            html.Append("<i class='icon'></i><span>" + (md_lang.WB248 || '个性化你的明道') + "</span>");
            html.Append("</div>");

            html.Append("<div class='themeListContainer'>");
            html.Append(Theme.getThemeHtml());

            html.Append("<div class='closeTheme icon-delete' title='关闭'></div>");

            element.html(html.toString());
            dfd.resolve(element);
            Theme.show();
            Theme.bindEvent();
          } else {
            Theme.hide();
          }
        });
      }
    },
    getThemeHtml: function () {

      var html = new StringBuilder();

      html.Append("<div class='themeCarousel TxtCenter carousel" + Theme.Options.currentPicCount + "'>");
      html.Append("<div class='prevTheme changePage InlineBlock mRight15 TxtMiddle'><i class='icon-arrow-left-border'></i></div>");
      html.Append("<div class='themeList InlineBlock TxtMiddle'>");
      html.Append("<ul>");

      for (var i = 0; i < Theme.Options.themes.length; i++) {
        var item = Theme.Options.themes[i];
        html.Append("<li class='themeItem' title='主题" + (i + 1) + "' val='" + item.val + "'><img src='" + item.thumbnail + "?imageView2/1/w/135/h/85' /></li>");
      }

      html.Append("</ul>");
      html.Append("</div>");
      html.Append("<div class='nextTheme changePage InlineBlock TxtMiddle mLeft5'><i class='icon-arrow-right-border'></i></div>");
      html.Append("<div class='Clear'></div>");
      html.Append("</div>");

      return html.toString();
    },
    setTheme: function (val) {
      accountSettingController.editAccountSetting({
        settingType: "ThemeColor",
        settingValue: val
      }).then(function (data) {
        if (data) {
          require.async("lazyload", function (LazyLoad) {
            LazyLoad.css("/modules/mdpublic/mdcss/Themes/Theme" + val + "/Theme.css");
            LazyLoad.css("/modules/react/dist/ming-ui-theme-" + val + ".css");
          });
        } else {
          alert("操作失败", 2);
        }
      });
    }
  };

  return Theme;

});
