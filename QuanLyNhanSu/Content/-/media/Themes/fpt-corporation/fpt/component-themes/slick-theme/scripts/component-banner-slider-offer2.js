!function(){"use strict";!function(){jQuery(".banner-slider-content-container .slider-content").length;!function(){function e(){c&&clearInterval(c)}function t(){function t(e){return jQuery('<button type="button" />').text(e)}function i(){k>1&&(f.find("li").removeClass("slick-active").end(),f.find("li").eq(u).addClass("slick-active"))}function a(t){n(r),n(s),e();var c=0;jQuery(".main-slider-content .banner-slider-content-container .item").map((function(e,t){jQuery(t).hasClass("custom-slick-active")&&(c=e)})),d("fadein-left-img-with-delay","fadeout-left-img-with-delay","fadein-right-img-with-delay",c,t),i()}function o(t){n(r),n(s),e();var c=0;jQuery(".main-slider-content .banner-slider-content-container .item").map((function(e,t){jQuery(t).hasClass("custom-slick-active")&&(c=e)})),d("fadein-right-img-with-delay","fadeout-right-img-with-delay","fadein-left-img-with-delay",c,t),i()}function l(){e(),c=setInterval((function(){u===k-1?u=0:u+=1,a(u)}),6e3)}function d(e,t,i,n,c){y=!1,jQuery(".main-slider-content .banner-slider-content-container .slider-content .item").map((function(a,o){o.querySelector(".slick-item-container .slick-item__image").classList.remove(i),n===a&&(o.querySelector(".slick-item-container .slick-item__image").style="opacity: 1;",o.querySelector(".slick-item-container .slick-item__image").classList.remove(e),o.querySelector(".slick-item-container .slick-item__image").classList.add(t),o.querySelector(".slick-item-container .slick-item__content-container").classList.remove("fadein-text-with-delay"),o.querySelector(".slick-item-container .slick-item__content-container").classList.add("fadeout-text-with-delay"),r=setTimeout((function(){jQuery(".main-slider-content .banner-slider-content-container .slider-content .item").map((function(t,i){c===t&&(i.classList.add("custom-slick-active"),i.querySelector(".slick-item-container .slick-item__image").classList.add(e),i.querySelector(".slick-item-container .slick-item__content-container").classList.add("fadein-text-with-delay"))}))}),350),s=setTimeout((function(){o.querySelector(".slick-item-container .slick-item__image").style="opacity: 0;",o.classList.remove("custom-slick-active"),o.querySelector(".slick-item-container .slick-item__image").classList.remove(t),o.querySelector(".slick-item-container .slick-item__content-container").classList.remove("fadeout-text-with-delay"),y=!0,l()}),850))}))}var m=0,u=0,y=!0,f=jQuery(".main-slider-content .banner-slider-content-container .slider-content"),k=jQuery(".main-slider-content .banner-slider-content-container .slider-content .item").length;jQuery(".main-slider-content .banner-slider-content-container .slick-btn-next").on("click",(function(e){e.preventDefault(),y&&(u===k-1?u=0:u+=1,a(u))})),jQuery(".main-slider-content .banner-slider-content-container .slick-btn-prev").on("click",(function(e){e.preventDefault(),y&&(0===u?u=k-1:u-=1,o(u))})),l(),jQuery(".main-slider-banner-offer .banner-slider-content-container").on("mousedown",(function(e){m=e.clientX})),jQuery(".main-slider-banner-offer .banner-slider-content-container").on("mouseup",(function(t){y&&(t.clientX-m>0?t.clientX-m>25&&(e(),u===k-1?u=0:u+=1,a(u),m=0):t.clientX-m<-25&&(e(),0===u?u=k-1:u-=1,o(u),m=0))})),jQuery(".main-slider-content .banner-slider-content-container .slider-content").map((function(e,t){u===e&&(t.querySelector(".item").classList.add("custom-slick-active"),t.querySelector(".slick-item-container .slick-item__image").classList.remove("fadein-left-img-with-delay"),t.querySelector(".slick-item-container .slick-item__image").classList.remove("fadein-right-img-with-delay"),t.querySelector(".slick-item-container .slick-item__image").classList.add("fadein-left-img-with-delay"),t.querySelector(".slick-item-container .slick-item__image").classList.remove("fadeout-left-img-with-delay"),t.querySelector(".slick-item-container .slick-item__content-container").classList.add("fadein-text-with-delay"),t.querySelector(".slick-item-container .slick-item__content-container").classList.remove("fadeout-text-with-delay"))})),function(){var e,n;if(k>1){for(f.addClass("custom-slick-dotted"),n=jQuery("<ul />").addClass("slick-dots"),e=0;e<k;e++)n.append(jQuery("<li />").append(t(e)));f.append(n),f.find("li").first().addClass("slick-active"),jQuery(".main-slider-content .banner-slider-content-container .custom-slick-dotted ul.slick-dots li").on("click",(function(){var e;y&&(jQuery(".main-slider-content .banner-slider-content-container .item").map((function(t,i){jQuery(i).hasClass("custom-slick-active")&&(e=t)})),(u=parseInt($(this).find("button").text()))-e>0?a(u):o(u),i())}))}}(),i()}function i(){n(r),n(s),jQuery(".slick-item__image").css({opacity:1}),jQuery(".banner-slider-content-container .slider-content .item").each((function(e,t){return jQuery(t).removeClass("custom-slick-active")})),jQuery(".banner-slider-content-container .slider-content .item .slick-item__image").removeClass("fadein-right-img-with-delay"),jQuery(".banner-slider-content-container .slider-content .item .slick-item__image").removeClass("fadein-left-img-with-delay"),jQuery(".banner-slider-content-container .slider-content").slick({slidesToShow:1,slidesToScroll:1,arrows:!1,infinite:!0,speed:500,autoplay:!0,dots:!0})}function n(e){e&&clearTimeout(e)}var c,r,s;jQuery(window).resize((function(){if(jQuery(window).width()<1024){if(0===jQuery(".banner-slider-content-container .slick-initialized").length){e();var n=jQuery(".banner-slider-content-container .slider-content .slick-dots");n&&n.remove(),i()}}else jQuery(".banner-slider-content-container .slick-initialized").length>0&&(jQuery(".main-slider-content .banner-slider-content-container .slider-content").slick("destroy"),e(),t())})),setTimeout((function(){window.dispatchEvent(new Event("resize"))}),2e3),jQuery(window).width()<1024?i():t()}()}()}();