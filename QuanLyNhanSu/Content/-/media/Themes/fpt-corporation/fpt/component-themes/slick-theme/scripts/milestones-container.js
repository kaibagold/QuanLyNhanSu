jQuery(document).ready(function () {
  if (jQuery(".wrapper-component-milestones-container-slider").length > 0) {
    jQuery(".menu-sidebar-slider ul li a").click(function (e) {
      var headerHeight = jQuery('.fpt-header-bottom').height();
      e.preventDefault(), jQuery("html, body").animate({
        scrollTop: jQuery(this.hash).offset().top - headerHeight
      }, 400);
    });
    var menu = jQuery(".menu-sidebar");
    var offsetMenu = menu.offset().top;
    var topRight = 0;
    var lastScrollTop = 0;
    jQuery(window).scroll(function () {
      var e = jQuery(window).scrollTop() + 100;
      var st = window.pageYOffset || document.documentElement.scrollTop;
      jQuery(".content-slider-left").each(function () {
        var t = jQuery(this).offset().top,
            a = t + jQuery(this).height(),
            i = jQuery(this).attr("id"),
            s = jQuery('a[href$="' + i + '"]').parent();

        if (e > t && e < a) {
          if (s.hasClass("active")) {
            return !1;
          }

          s.siblings().addBack().removeClass("active"), s.addClass("active");
        }
      });

      if (jQuery(window).scrollTop() >= offsetMenu) {
        jQuery(".wrapper-component-milestones-container-slider").addClass("wrapper-fixed");
        jQuery(".menu-sidebar-history .slider ul").css("top", topRight);
      } else {
        topRight = 0;
        jQuery(".wrapper-component-milestones-container-slider").removeClass("wrapper-fixed");
        jQuery(".menu-sidebar-history .slider ul").css("top", topRight);
      }

      var footer = jQuery('#footer').offset().top;
      var ScrollFooter = jQuery(window).scrollTop() + 500;

      if (st > lastScrollTop) {
        topRight -= 1.5;
      } else {
        topRight += 1.8;
      }

      if (ScrollFooter > footer) {
        topRight = -700;
      }

      lastScrollTop = st <= 0 ? 0 : st;
    });
  }
});
jQuery(document).ready(function () {
  if (jQuery(".wrapper-component-milestones-container-tab").length) {
    jQuery(".menu-sidebar-tab ul li").click(function (e) {
      var t = jQuery(this).attr("data-id");
      history.pushState("", null, "?id=" + t), e.preventDefault(), jQuery(this).closest('.menu-sidebar-tab').find("li").removeClass("active");
      jQuery(this).closest('.wrapper-component-milestones-container-tab').find(".content-left-tab").removeClass("active");
      jQuery(this).addClass("active"), jQuery("#" + t + ".content-left-tab").addClass("active");
    });
    jQuery(".menu-sidebar-tab-financial ul li").first().addClass("active");
    jQuery(".wrapper-content .content-left-tab-financial").first().addClass("active");
    jQuery(".menu-sidebar-tab-monthly ul li").first().addClass("active");
    jQuery(".wrapper-content .content-left-tab-monthly").first().addClass("active");
    jQuery(".menu-sidebar-tab-whats ul li").first().addClass("active");
    jQuery(".wrapper-content .content-left-tab-whats").first().addClass("active");
    jQuery(".menu-sidebar-tab-shareholders ul li").first().addClass("active");
    jQuery(".wrapper-content .content-left-tab-shareholders").first().addClass("active");
    jQuery(".menu-sidebar-tab-investor ul li").first().addClass("active");
    jQuery(".wrapper-content .content-left-tab-investor").first().addClass("active");
  }
});
jQuery(document).ready(function () {
  if (jQuery(".wrapper-component-milestones-container-slider").length > 0 || jQuery(".wrapper-component-milestones-container-tab").length > 0) {
    var oneLineHeightMenuRight = 50;
    setTimeout(function () {
      if (jQuery(".wrapper-menu-sidebar .menu-sidebar-history ul").height() > oneLineHeightMenuRight && window.innerWidth <= 801) {
        jQuery(".wrapper-menu-sidebar .menu-sidebar-history ul").slick({
          infinite: false,
          arrows: false,
          slidesToShow: 6
        });
      }
    }, 500);
  }
});