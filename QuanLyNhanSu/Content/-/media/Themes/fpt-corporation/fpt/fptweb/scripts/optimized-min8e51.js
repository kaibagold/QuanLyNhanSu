!function(){"use strict";jQuery(document).ready(function(){jQuery(".component.banner-slider .slider-content").length&&jQuery(".component.banner-slider .slider-content").slick({slidesToShow:1,slidesToScroll:1,arrows:!1,fade:!0,infinite:!0,speed:500,autoplay:!1,dots:!0})})}(),function(){"use strict";jQuery(document).ready(function(){jQuery(".two-cols-text-with-image .refer-links").length>0&&(jQuery(".two-cols-text-with-image .refer-links a").click(function(n){var t=jQuery(".fpt-header-bottom").height();n.preventDefault();jQuery("html, body").animate({scrollTop:jQuery(this.hash).closest(".component.two-cols-text-with-image").first().offset().top-t},400)}),jQuery(window).scroll(function(){var n=jQuery(window).scrollTop()+100;jQuery(".two-cols-text-with-image").each(function(){var t=jQuery(this).offset().top,i=t+jQuery(this).height(),r=jQuery(this).attr("id"),u=jQuery('a[href$="'+r+'"]').parent();if(n>t&&n<i&&u.hasClass("active"))return!1})}))})}(),function(){"use strict";jQuery(".component-landing-page-ir-news")&&jQuery(document).ready(function(){jQuery(".landing-ir-news__slider").length&&jQuery(".landing-ir-news__slider").slick({slidesToShow:3,slidesToScroll:1,arrows:!1,infinite:!0,speed:500,autoplay:!1,dots:!1,responsive:[{breakpoint:992,settings:{slidesToShow:1,slidesToScroll:1,autoplaySpeed:5e3,fade:!0,dots:!0}}]})})}(),function(){"use strict";jQuery(document).ready(function(){jQuery("#wrap-item-business-partner").length&&(jQuery("#wrap-item-business-partner .item").length>6&&jQuery("#wrap-btn-show-more").addClass("show"),jQuery("#wrap-item-business-partner .item").each(function(n){n>5&&jQuery(this).addClass("hidden")}),jQuery("#wrap-btn-show-more .w-btn-show-more").click(function(n){n.preventDefault();jQuery("#wrap-item-business-partner .item").removeClass("hidden");jQuery(this).remove()}));jQuery(function(){var n,u,f,t,e;if(jQuery(".join-width-us-slider").length){var i=function(){r();t=0;u=!1;f=setInterval(o,10)},o=function(){!1===u&&(t+=1/(e+.1),n.css({width:t+"%"}),t>=100&&(jQuery(".join-width-us-slider").slick("slickNext"),i()))},r=function(){n.css({width:"0%"});clearTimeout(f)};jQuery(".join-width-us-slider").slick({slidesToShow:1,slidesToScroll:1,fade:!0,infinite:!0,speed:500,arrows:!1,dots:!1});e=5;n=jQuery(".slider-progress .progress");i();jQuery(".join-width-us-slider").on("beforeChange",function(){r();i();n.css({width:"100%"})})}})})}(),function(){"use strict";var n;(n=jQuery)(".block-list-with-filter").length>0&&(n.fn.extend({filterTag:function(n,t){for(var u,r=document.querySelectorAll("."+n+" > .item"),i=0;i<r.length;i++)u=r[i].getAttribute("data-tags"),null!=u&&(u.indexOf(t)<0?r[i].setAttribute("data-toggle","off"):r[i].setAttribute("data-toggle","on"))},resetFilter:function(n){for(var i=document.querySelectorAll("."+n+" > .item"),t=0;t<i.length;t++)i[t].setAttribute("data-toggle","on")}}),n(".block-list-with-filter .sidebar-right ul li a").click(function(){var t=n(this).attr("data-filter"),i;(n(".block-list-with-filter .sidebar-right ul li").removeClass("active"),n(this).parents("li").addClass("active"),"true"===n(this).attr("data-reset"))?n(this).resetFilter(t):(i=n(this).attr("data-filter-tag"),n(this).filterTag(t,i))}))}(),function(){"use strict";jQuery(document).ready(function(){jQuery(function(){var n,u,f,t,e;if(jQuery(".main-slider").length){var i=function(){r();t=0;u=!1;f=setInterval(o,10)},o=function(){!1===u&&(t+=1/(e+.1),n.css({width:t+"%"}),t>=100&&(jQuery(".main-slider .slider-content").slick("slickNext"),i()))},r=function(){n.css({width:"0%"});clearTimeout(f)};jQuery(".main-slider .slider-content").slick({slidesToShow:1,slidesToScroll:1,fade:!0,infinite:!0,speed:500,arrows:!1,dots:!0});e=5;n=jQuery(".slider-homepage-progress .progress");i();jQuery(".main-slider .slider-content").on("beforeChange",function(){r();i();n.css({width:"100%"})});jQuery(".main-slider .slider-content .w-icon").click(function(n){n.preventDefault();jQuery(".main-slider .slider-content").slick("slickNext")})}})})}(),function(){"use strict";jQuery(".navigation.in-header .fpt-toggle-menu-btn").click(function(){jQuery(this).toggleClass("is-open");jQuery(window).width()>1024?jQuery(".fpt-header, .navigation.in-header").toggleClass("on-showing-menu"):($(".fpt-header .language-selector-item-container").is(":visible")&&$(".fpt-header .language-selector-select-link").trigger("click"),jQuery(".fpt-header").toggleClass("on-showing-menu-mobile"),jQuery(".fpt-sidebar").toggle(100,function(){$(this).is(":visible")||jQuery(".navigation.in-sidebar .mobile-menu-back-btn").trigger("click")}))});jQuery(document).ready(function(){var n=0;jQuery(window).scroll(function(){var t=jQuery(window).scrollTop();jQuery(window).scrollTop()>50?jQuery(".fpt-header").addClass("on-scroll"):jQuery(".fpt-header").removeClass("on-scroll");t>n?jQuery(".breadcrumb").slideUp("fast"):jQuery(".breadcrumb").slideDown("fast");n=t})});jQuery(document).ready(function(){jQuery(".navigation.in-sidebar nav li > div").each(function(){jQuery(this).siblings("ul").length&&jQuery(this).append('<span class="mobile-menu-goto-btn"><\/span>')});jQuery(".navigation.in-sidebar nav li > div > span, .navigation.in-sidebar nav li > div > p").click(function(){var n=jQuery(this);n.closest("li").siblings("li").hide();n.closest("li").find("div").first().hide();n.closest("li").find("ul").first().show();n.closest(".navigation").siblings(".link").hide()});jQuery(".navigation.in-sidebar nav > ul ul").each(function(){var n=jQuery(this).closest("li").find(".navigation-title").first().find("> :first-child").text();jQuery(this).prepend('<li class="mobile-menu-back-btn">'.concat(n,"<\/li>"))});jQuery(".navigation.in-sidebar .mobile-menu-back-btn").click(function(){var n=jQuery(this);n.closest("ul").hide();n.parent().closest("li").find("div").first().show();n.parent().closest("li").siblings("li").show();n.parent().closest("li").first().hasClass("level1")&&n.closest(".navigation").siblings(".link").show()})});jQuery(document).ready(function(){jQuery(".fpt-header .language-selector").click(function(){jQuery(window).width()<=1024&&($(".fpt-sidebar").is(":visible")&&(jQuery(".navigation.in-header .fpt-toggle-menu-btn").removeClass("is-open"),jQuery(".fpt-header").removeClass("on-showing-menu-mobile"),jQuery(".fpt-sidebar").hide()),$(".fpt-header .language-selector-item-container").is(":visible")&&jQuery(".fpt-header").addClass("on-showing-language-selection"),setTimeout(function(){$(".fpt-header .language-selector-item-container").is(":visible")||jQuery(".fpt-header").removeClass("on-showing-language-selection")},500))})});jQuery(document).ready(function(){jQuery(window).width()<767&&(jQuery(".navigation.in-footer nav li.level1").removeClass("active"),jQuery(".navigation.in-footer nav li.level1 > .navigation-title").each(function(n){(0===n||jQuery(".navigation.in-footer nav li.level1:nth-child("+(n+1)+")").has("ul").length>0)&&jQuery(this).append('<span class="show-detail-btn"><\/span>')}),jQuery(".navigation.in-footer .navigation-title").click(function(){var n=jQuery(this).closest("li");if(n.hasClass("active"))return n.find("ul").first().slideUp(),n.removeClass("active"),!1;n.siblings("li.active").find("ul").first().slideUp();n.siblings("li.active").removeClass("active");n.toggleClass("active");n.find("ul").first().slideDown()}))})}(),function(){"use strict";var t,i,n,r,u,f,e,o,s,h,c,l,a;t=jQuery(".section-longform").length>0||jQuery(".richtext-new-detail").length>0;i=jQuery(".component.news-search > .component-content");n=jQuery(".news-search > .component-content > .c-data");r=encodeURIComponent(n.attr("data-search-scope"));u=encodeURIComponent(n.attr("data-item-id"));f=encodeURIComponent(n.attr("data-lang"));e=encodeURIComponent(n.attr("data-variant"));o=encodeURIComponent(n.attr("data-page-size"))||5;s=encodeURIComponent(n.attr("data-autofire-search"))||!1;h=n.attr("data-title")||"Tin mới nhất";c=n.attr("data-text-viewmore")||"Xem thêm";l=n.attr("data-text-viewless")||"Thu gọn";a="/sxa/search/results/?l=".concat(f,"&s=").concat(r,"&itemid=").concat(u,"&autoFireSearch=").concat(s,"&v=").concat(e,"&p=").concat(o,"&o=Published,Descending");t&&jQuery.ajax({type:"GET",url:a,success:function(n){var t='<div class="related-news"><p class="related-news-title field-title">'.concat(h,"<\/p>");n.Results.length>0&&n.Results.map(function(n){t+=n.Html});t+=n.Results.length>2?'<div class="related-news__button-show-more">'.concat(c,'\n                                <i class="icon-narrow-bottom"><\/i>\n                            <\/div>\n                            <div class="related-news__button-show-less" style="display: none">').concat(l,'\n                                <i class="icon-narrow-top"><\/i>\n                            <\/div>\n                            <\/div>\n                            '):"<\/div>";i.html(t);jQuery(".news-search > .component-content .related-news-article").map(function(n,t){n<2&&(t.style="display: flex")});jQuery(".news-search > .component-content .related-news__button-show-more").on("click",function(){jQuery(".news-search > .component-content .related-news-article").map(function(n,t){t.style="display: flex"});jQuery(".news-search > .component-content .related-news__button-show-more")[0].style="display: none";jQuery(".news-search > .component-content .related-news__button-show-less")[0].style="display: block";jQuery(".news-search > .component-content .related-news__button-show-less").on("click",function(){jQuery(".news-search > .component-content .related-news-article").map(function(n,t){t.style=n<2?"display: flex":"display: none"});jQuery(".news-search > .component-content .related-news__button-show-less")[0].style="display: none";jQuery(".news-search > .component-content .related-news__button-show-more")[0].style="display: block"})});jQuery(".news-search > .component-content .related-news__button-show-less").on("click",function(){jQuery(".news-search > .component-content .related-news-article").map(function(n,t){t.style=n<2?"display: flex":"display: none"});jQuery(".news-search > .component-content .related-news__button-show-less")[0].style="display: none";jQuery(".news-search > .component-content .related-news__button-show-more")[0].style="display: block";jQuery(".news-search > .component-content .related-news__button-show-more").on("click",function(){jQuery(".news-search > .component-content .related-news-article").map(function(n,t){t.style="display: flex"});jQuery(".news-search > .component-content .related-news__button-show-more")[0].style="display: none";jQuery(".news-search > .component-content .related-news__button-show-less")[0].style="display: block"})})}});t&&(jQuery(".related-news > .component-content > .related-news-article").map(function(n,t){n<2&&(t.style="display: flex")}),jQuery(".related-news > .component-content > .related-news__button-show-more").on("click",function(){jQuery(".related-news > .component-content > .related-news-article").map(function(n,t){t.style="display: flex"});jQuery(".related-news > .component-content > .related-news__button-show-more")[0].style="display: none";jQuery(".related-news > .component-content > .related-news__button-show-less")[0].style="display: block";jQuery(".related-news > .component-content > .related-news__button-show-less").on("click",function(){jQuery(".related-news >.component-content > .related-news-article").map(function(n,t){t.style=n<2?"display: flex":"display: none"});jQuery(".related-news > .component-content > .related-news__button-show-less")[0].style="display: none";jQuery(".related-news > .component-content > .related-news__button-show-more")[0].style="display: block"})}),jQuery(".related-news > .component-content > .related-news__button-show-less").on("click",function(){jQuery(".related-news > .component-content > .related-news-article").map(function(n,t){t.style=n<2?"display: flex":"display: none"});jQuery(".related-news > .component-content > .related-news__button-show-less")[0].style="display: none";jQuery(".related-news > .component-content > .related-news__button-show-more")[0].style="display: block";jQuery(".related-news > .component-content >.related-news__button-show-more").on("click",function(){jQuery(".related-news > .component-content > .related-news-article").map(function(n,t){t.style="display: flex"});jQuery(".related-news > .component-content > .related-news__button-show-more")[0].style="display: none";jQuery(".related-news > .component-content > .related-news__button-show-less")[0].style="display: block"})}))}(),function(){"use strict";jQuery(".component-content > .component.news-search").length>0&&function(){function i(n){return(n=(n=(n=(n=(n=(n=(n=(n=(n=(n=(n=n.toLowerCase()).replace(/(à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ)/g,"a")).replace(/(è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ)/g,"e")).replace(/(ì|í|ị|ỉ|ĩ)/g,"i")).replace(/(ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ)/g,"o")).replace(/(ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ)/g,"u")).replace(/(ỳ|ý|ỵ|ỷ|ỹ)/g,"y")).replace(/(đ)/g,"d")).replace(/([^0-9a-z-\s])/g,"")).replace(/(\s+)/g,"-")).replace(/^-+/g,"")).replace(/-+$/g,"")}var n=jQuery(".news-search > .component-content > .c-data"),o=encodeURIComponent(n.attr("data-search-scope")),s=encodeURIComponent(n.attr("data-item-id")),h=encodeURIComponent(n.attr("data-site-name")),e=encodeURIComponent(n.attr("data-lang")),w=encodeURIComponent(n.attr("data-variant")),c=n.attr("data-search-text"),l=n.attr("data-search-all"),t=isNaN(n.attr("data-page-size"))?9:n.attr("data-page-size"),a=[],v=window.location.href.split("/"),y=v.findIndex(function(n){return"page"===n.toLowerCase()}),r="",p,u,f;-1===y?(p=window.location.pathname+"/page",r=window.location.origin+p.replace(/\/+/g,"/")):r=v.reduce(function(n,t,i){return i<=y?n+"/"+t:n});u=function(n){jQuery("#pagination-".concat(n)).pagination("destroy");setTimeout(function(){f(n)},100)};f=function(n){var l=window.location.href.split("/"),v=l.findIndex(function(n){return"page"===n.toLowerCase()}),f="",y;-1===v?(y=window.location.pathname+"/page",f=window.location.origin+y.replace(/\/+/g,"/")):f=l.reduce(function(n,t,i){return i<=v?n+"/"+t:n});var b=l[v+1],u=parseInt(b)||1,p=new URLSearchParams(window.location.search).get("type"),c=null!==p?"?type="+i(p):"",r=jQuery("#pagination-".concat(n));r.children().length>0||r.pagination({dataSource:"/sxa/search/results",locator:"Results",totalNumberLocator:function(n){return n.Count},prevText:'<i class="fa fa-chevron-left"><\/i>',nextText:'<i class="fa fa-chevron-right"><\/i>',pageSize:t,pageRange:1,pageNumber:u,beforePreviousOnClick:function(n){u--;n.preventDefault();window.location.href=f+"/"+u+c;r.pagination("destroy")},beforePageOnClick:function(n){u=Number(jQuery(n.target).text());n.preventDefault();window.location.href=f+"/"+u+c;r.pagination("destroy")},beforeNextOnClick:function(n){u++;n.preventDefault();window.location.href=f+"/"+u+c;r.pagination("destroy")},ajax:{beforeSend:function(i,f){var v,c;r.prev().children().toggleClass("loading");r.prev().children().html('<div class="fpt-spinner"><\/div>');var y=jQuery("#".concat(n)).find(".news-search-box input").val(),p=(u-1)*t,l="/sxa/search/results?l=".concat(e,"&s=").concat(o,"&v=").concat(w,"&itemid=").concat(s,"&sc_site=").concat(h,"&p=").concat(t,"&e=").concat(p,"&q=").concat(encodeURIComponent(y),"&o=Published,Descending");"all"!==jQuery("#".concat(n)).find(".news-dropdown-content .active").attr("data-value")&&(v=jQuery("#".concat(n)).find(".news-dropdown-btn p").text(),l+="&type=".concat(v));c=a.find(function(t){return t.Name.toLowerCase().replace(/ /g,"_")===n});c&&c.Name&&(l+="&category=".concat(c.Name));f.url=l}},callback:function(n,i){var o="",s;n.length?(jQuery.each(n,function(n,t){o+='\n                            <div class="col-12 col-md-6 col-lg-4">\n                                '.concat(t.Html,"\n                            <\/div>\n                        ")}),r.prev().children().toggleClass("loading"),r.prev().children().html(o),jQuery(".pagination-section .paginationjs a").removeAttr("href"),"function"==typeof lazyload&&(jQuery("picture.lazyload").lazyload(),jQuery("img.lazyload").lazyload())):(s=i.totalNumber%t==0?i.totalNumber/t:parseInt(i.totalNumber/t)+1,1!==u?window.location.href=f+"/"+s+c:(o='<div style="display: flex; width: 100%; justify-content: center; font-size: 24px">'.concat("vi-VN"===e?"Không tìm thấy kết quả":"No Results","<\/div>"),r.prev().children().toggleClass("loading"),r.prev().children().html(o),r.pagination("destroy")))}})};jQuery(document).ready(function(){n.length&&jQuery.ajax({type:"GET",url:"/sxa/search/facets?f=type||category&l=".concat(e,"&s=").concat(o,"&itemid=").concat(s,"&sc_site=").concat(h,"&e=0"),success:function(n){var h,d=n.Facets,e=d.find(function(n){return"Category"===n.Key}),t=d.find(function(n){return"Type"===n.Key}),v=new URLSearchParams(window.location.search).get("type"),g='<div class="news-dropdown-item '.concat("all"===(h=null===v?"all":v)?"active":"",'" data-value="all">').concat(l,"<\/div>"),tt=t.Values.findIndex(function(n){return i(n.Name.toLowerCase().replace(/ /g,"_"))===v}),it="<p>".concat("all"===h?l:t.Values[tt].Name,"<\/p>"),o,y,p,w,b,s,k,nt;if(t&&t.Values)for(o=0;o<t.Values.length;o++)y=t.Values[o].Name,p=y.toLowerCase().replace(/ /g,"_"),g+='<div class="news-dropdown-item '.concat(i(p)==i(h)?"active":"",'" data-value="').concat(p,'">').concat(y,"<\/div>");if(w='\n                        <div class="news-dropdown">\n                            <div class="news-dropdown-btn">\n                                '.concat(it,'\n                                <i class="fa fa-caret-down"><\/i>\n                            <\/div>\n                            <div class="news-dropdown-content fpt-scroll">\n                                ').concat(g,"\n                            <\/div>\n                        <\/div>\n                    "),b='\n                        <div id="all" class="tab-content container-1430 active">\n                            <div class="row">\n                                <div class="col-12 filter-row">\n                                    <div class="row">\n                                        <div class="col-12 col-md-6">\n                                            '.concat(w,'\n                                        <\/div>\n                                        <div class="col-12 col-md-6">\n                                            <div class="news-search-box">\n                                                <input name="search-box" type="text" placeholder="').concat(c,'" />\n                                                <i class="fa fa-search"><\/i>\n                                            <\/div>\n                                        <\/div>\n                                    <\/div>\n                                <\/div>\n                                <div class="col-12 result-row">\n                                    <div class="result-container">\n                                        <div class="row">\n                                            \n                                        <\/div>\n                                    <\/div>\n                                    <div id="pagination-all" class="pagination-section"><\/div>\n                                <\/div>\n                            <\/div>\n                        <\/div>\n                    '),e&&e.Values)for(a=e.Values,s=0;s<e.Values.length;s++)k=e.Values[s].Name.toLowerCase().replace(/ /g,"_"),b+='\n                                <div id="'.concat(k,'" class="tab-content container-1430">\n                                    <div class="row">\n                                        <div class="col-12 filter-row">\n                                            <div class="row">\n                                                <div class="col-12 col-md-6">\n                                                    ').concat(w,'\n                                                <\/div>\n                                                <div class="col-12 col-md-6">\n                                                    <div class="news-search-box">\n                                                        <input name="search-box" type="text" placeholder="').concat(c,'" />\n                                                        <i class="fa fa-search"><\/i>\n                                                    <\/div>\n                                                <\/div>\n                                            <\/div>\n                                        <\/div>\n                                        <div class="col-12 result-row">\n                                            <div class="result-container">\n                                                <div class="row">\n                                                    \n                                                <\/div>\n                                            <\/div>\n                                            <div id="pagination-').concat(k,'" class="pagination-section"><\/div>\n                                        <\/div>\n                                    <\/div>\n                                <\/div>\n                            ');nt="".concat(b);jQuery(".news-search > div").html(nt);setTimeout(function(){jQuery(".news-tabs button.tab-item").on("click",function(n){for(var r,u=n.currentTarget.getAttribute("data-id"),i=jQuery(".tab-content"),t=0;t<i.length;t++)i[t].classList.remove("active");for(r=jQuery(".news-tabs .tab-item"),t=0;t<r.length;t++)r[t].classList.remove("active");document.getElementById(u).classList.toggle("active");n.currentTarget.classList.toggle("active");jQuery(".tab-item").first().hasClass("active")||jQuery(".tab-item.active")[0].scrollIntoView({behavior:"smooth",inline:"center"});jQuery(".tab-item.active").prev().length>0&&jQuery(".tab-item.active").prev().position().left<0&&jQuery(".tab-item.active").prev()[0].scrollIntoView({behavior:"smooth",inline:"start"});f(u)});jQuery(document).click(function(n){if(!jQuery(n.target).closest(".news-dropdown").length&&jQuery(".news-dropdown.active").length){var t=jQuery(".news-dropdown.active");t.find(".news-dropdown-content").removeClass("active");t.find(".news-dropdown-btn").removeClass("active");t.find(".news-dropdown-btn .fa").removeClass("fa-caret-up");t.find(".news-dropdown-btn .fa").toggleClass("fa-caret-down");t.removeClass("active")}});jQuery(".news-dropdown").click(function(n){n.currentTarget.classList.toggle("active");jQuery(this).find(".news-dropdown-content").toggleClass("active");jQuery(this).find(".news-dropdown-btn").toggleClass("active");jQuery(this).find(".news-dropdown-btn .fa").toggleClass("fa-caret-up");jQuery(this).find(".news-dropdown-btn .fa").toggleClass("fa-caret-down")});jQuery(".news-dropdown-item").click(function(n){var t,f;n.preventDefault();t=jQuery(this).closest(".news-dropdown");t.find(".news-dropdown-btn p").text(jQuery(this).text());t.find(".news-dropdown-content .news-dropdown-item").removeClass("active");jQuery(this).addClass("active");"all"===$(this).attr("data-value")?window.history.pushState({},{},r+"/1"):window.history.pushState({},{},r+"/1?type="+i($(this).attr("data-value")));f=jQuery(this).closest(".tab-content").attr("id");u(f)});jQuery('input[name="search-box"]').keypress(function(n){if("13"==(n.keyCode?n.keyCode:n.which)){var t=jQuery(this).closest(".tab-content").attr("id");u(t)}n.stopPropagation()});jQuery(".news-search-box i").click(function(){var n=jQuery(this).closest(".tab-content").attr("id");u(n)});f("all");window.onpopstate=function(){location.reload(!0)}},300)}})})}()}(),function(){"use strict";jQuery(document).ready(function(){jQuery(".offer-sliders .offer-sliders-card").before('<div class="fpt-spinner"><\/div>');setTimeout(function(){jQuery(".offer-sliders .offer-sliders-card").each(function(){jQuery(this).slick({slidesToScroll:1,speed:700,variableWidth:!0,infinite:!1,prevArrow:jQuery(this).closest(".offer-sliders").find(".slick-btn-prev"),nextArrow:jQuery(this).closest(".offer-sliders").find(".slick-btn-next")})});jQuery(".offer-sliders .offer-sliders-button").css("opacity",1);jQuery(".offer-sliders .fpt-spinner").remove()},2e3)})}(),function(){"use strict";jQuery(document).ready(function(){jQuery(window).width()<768&&jQuery(".component.our-mission .our-mission__top-detail-items").length&&jQuery(".component.our-mission .our-mission__top-detail-items").slick({slidesToScroll:1,speed:700,variableWidth:!0,infinite:!1,arrows:!1})})}(),function(){"use strict";jQuery(".recognition-slider .recognition-slider-card").each(function(){jQuery(this).slick({slidesToScroll:1,dots:!0,arrows:!0,speed:700,variableWidth:!0,infinite:!1,prevArrow:jQuery(this).closest(".recognition-slider").find(".slick-btn-prev"),nextArrow:jQuery(this).closest(".recognition-slider").find(".slick-btn-next")})})}(),function(){"use strict";var t=jQuery("div.component.right-panel").length,n=jQuery("input#right-panel-item-id").attr("value");jQuery;t&&n&&jQuery.ajax({type:"GET",url:"/api/sitecore/RightPanel/GetRightPanel?itemId=".concat(n),success:function(n){if(0!==n.selectItems.length){var t="",i=n.priceUp?"index-up":"index-down",r=n.priceUp?"price-up":"price-down";n.selectItems.length>0&&(t+="<div class= 'right-panel-social-media'>",n.selectItems.map(function(n){t+='<a target="_blank" href='.concat(n.href,'>\n\t\t\t\t\t\t\t<img class="lazyload" data-src=').concat(n.urlImage,' alt="Icon">\n\t\t\t\t\t\t<\/a>')}),t+="<\/div>");jQuery(".component.right-panel .right-panel-collapse .right-panel-collapse-fpt-index p").text(n.closePrice||"N/A");n.selectItems.length>0&&jQuery(".component.right-panel .right-panel-collapse").append(t);"function"==typeof lazyload&&jQuery("img.lazyload").lazyload();jQuery(".component.right-panel .right-panel-expand p.right-panel-expand-date span#fpt-date").text(n.currentDate||"N/A");jQuery(".component.right-panel .right-panel-expand div.right-panel-expand-fpt .right-panel-expand-fpt-description .right-panel-expand-fpt-detail #fpt-point.right-panel-expand-fpt-detail-point").text(n.closePrice||"N/A");jQuery(".component.right-panel .right-panel-expand div.right-panel-expand-fpt .right-panel-expand-fpt-description .right-panel-expand-fpt-detail #fpt-percent.right-panel-expand-fpt-detail-percent").text(n.percent||"N/A");jQuery(".component.right-panel .right-panel-expand div.right-panel-expand-fpt .right-panel-expand-fpt-description .right-panel-expand-fpt-volume p span#fpt-volume").text(n.volume||"N/A");jQuery(".right-panel .right-panel-expand .right-panel-expand-fpt-title").addClass(i);jQuery(".right-panel .right-panel-collapse .right-panel-collapse-fpt-index p").addClass(i);jQuery(".component.right-panel .right-panel-expand div.right-panel-expand-fpt .right-panel-expand-fpt-description .right-panel-expand-fpt-detail #fpt-point.right-panel-expand-fpt-detail-point").addClass(r);jQuery(".component.right-panel .right-panel-expand div.right-panel-expand-fpt .right-panel-expand-fpt-description .right-panel-expand-fpt-detail #fpt-percent.right-panel-expand-fpt-detail-percent").addClass(r)}},error:function(n){console.log(n)}});jQuery(document).ready(function(){window.matchMedia("(min-width: 1025px)").matches&&(jQuery(".right-panel-collapse > div").first().click(function(){jQuery(".right-panel-expand").show(250);jQuery(".right-panel-expand").css("display","flex");jQuery(".right-panel-expand").addClass("active")}),jQuery(".right-panel-expand .btn-close").click(function(){jQuery(".right-panel-expand").hide(250);jQuery(".right-panel-expand").removeClass("active")}))});jQuery(document).ready(function(){window.matchMedia("(max-width: 1024px)").matches&&(jQuery(".right-panel-collapse .mobile-btn").click(function(){jQuery(".right-panel-collapse .mobile-btn .fa").hasClass("fa-ellipsis-v")?(jQuery(".right-panel-collapse .right-panel-collapse-fpt-index").show(200),jQuery(".right-panel-collapse .right-panel-collapse-fpt-index").addClass("active"),jQuery(".right-panel-collapse .right-panel-social-media").show(200),jQuery(".right-panel-collapse .right-panel-social-media").addClass("active"),jQuery(".right-panel-collapse .mobile-btn .fa").removeClass("fa-ellipsis-v"),jQuery(".right-panel-collapse .mobile-btn .fa").addClass("fa-times")):(jQuery(".right-panel-collapse .right-panel-collapse-fpt-index").hide(200),jQuery(".right-panel-collapse .right-panel-collapse-fpt-index").removeClass("active"),jQuery(".right-panel-collapse .right-panel-social-media").hide(200),jQuery(".right-panel-collapse .right-panel-social-media").removeClass("active"),jQuery(".right-panel-collapse .mobile-btn .fa").removeClass("fa-times"),jQuery(".right-panel-collapse .mobile-btn .fa").addClass("fa-ellipsis-v"))}),jQuery(".right-panel-collapse .right-panel-collapse-fpt-index").click(function(){jQuery(".right-panel-expand").show(250);jQuery(".right-panel-expand").css("display","flex");jQuery(".right-panel-expand").addClass("active")}),jQuery(".right-panel-expand .btn-close").click(function(){jQuery(".right-panel-expand").hide(250);jQuery(".right-panel-expand").removeClass("active")}))})}(),function(){"use strict";if(jQuery("#button-scroll-top")){var n=jQuery("#button-scroll-top");jQuery(window).scroll(function(){jQuery(window).scrollTop()>300?n.addClass("show"):n.removeClass("show")});n.on("click",function(n){n.preventDefault();jQuery("html, body").animate({scrollTop:0},"300")})}}(),function(){"use strict";jQuery(document).ready(function(){jQuery(".search .component-content > .search-icon").click(function(){jQuery(this).toggleClass("on-showing");jQuery(this).parent().find(".search-container").slideToggle(200);jQuery(this).parent().find("input").focus()});jQuery("#inp_search").on("keypress",function(n){13==n.keyCode&&jQuery(this).parents("form").submit()});jQuery(".component.search .search-container .search-icon").click(function(){jQuery(this).closest("form").submit()})})}(),function(){"use strict";jQuery(document).ready(function(){if(jQuery(".history-desc").length){jQuery(".history-desc").show();var n=7*parseInt(jQuery(".history-desc").first().children("p").first().css("line-height"));jQuery(".history-desc").each(function(){if(jQuery(this).height()>n){var t=jQuery(this);t.height(n);t.addClass("is-show-more");t.siblings(".btn-show-more").show()}});jQuery(".history-desc").siblings(".btn-show-more").click(function(n){n.preventDefault();var t=jQuery(this);t.siblings(".history-desc").css("height","auto");t.siblings(".history-desc").removeClass("is-show-more");t.hide();t.siblings(".btn-show-less").show()});jQuery(".history-desc").siblings(".btn-show-less").click(function(t){t.preventDefault();var i=jQuery(this);i.siblings(".history-desc").height(n);i.siblings(".history-desc").addClass("is-show-more");i.hide();i.siblings(".btn-show-more").show()})}})}(),function(){"use strict";var t=jQuery("html").attr("lang")||"vi-VN",n=jQuery("input#stock-report-item-id").attr("value");jQuery;n&&jQuery.ajax({type:"GET",url:"/api/sitecore/StockReport/GetStockReport?itemId=".concat(n,"&language=").concat(t),success:function(n){if(jQuery("div.business-report").length){var t="",i=n.PriceUp?"price-up":"price-down",r=n.PriceUp?"icon-triangle-top":"icon-triangle-bottom";n.Resultlists.map(function(n,i){t+="<a href=".concat(n.Link,' class="business-report__bottom__link-').concat(i+1,'">\n                                ').concat(n.Txtlink,'\n                                <i class="icon-narrow-right"><\/i>\n                            <\/a>')});jQuery(".component.business-report .business-report__top .business-report__top__main-info span").text(n.ClosingPrice||"N/A");jQuery(".component.business-report .business-report__middle p.business-report__middle__line-1").text((n.VolatilityIndex||"N/A")+" ("+(n.VolatilityPercentage||"N/A")+")");jQuery(".component.business-report .business-report__middle p.business-report__middle__line-2 span").text(n.CurrentDate||"N/A");jQuery(".component.business-report .business-report__bottom p.business-report__bottom__title").text(n.Title||"N/A");jQuery(".component.business-report .business-report__bottom").append(t||"N/A");jQuery(".for-investors__bottom__right .business-report").addClass(i);jQuery(".for-investors__bottom__right .business-report .business-report__top .business-report__top__main-info i").addClass(r)}else jQuery("div.stock-report").length&&(Object.keys(n).map(function(t){jQuery(".component.stock-report .stock-report-body .stock-report-body-statement h4#".concat(t,".stock-report-body-statement-subheading")).length&&jQuery(".component.stock-report .stock-report-body .stock-report-body-statement h4#".concat(t,".stock-report-body-statement-subheading")).text(n[t]||"N/A")}),jQuery(".component.stock-report .stock-report-heading .stock-report-heading-left").text(n.ClosingPrice||"N/A"),jQuery(".component.stock-report .stock-report-heading .stock-report-heading-right h4.stock-report-heading-right-date span").text(n.CurrentDate||"N/A"),jQuery(".component.stock-report .stock-report-heading .stock-report-heading-right div.stock-report-heading-right-rate h4#price-change").text(n.VolatilityIndex||"N/A"),jQuery(".component.stock-report .stock-report-heading .stock-report-heading-right div.stock-report-heading-right-rate h4#price-change-percent").text(" ("+(n.VolatilityPercentage||"N/A")+")"))},error:function(n){console.log(n)}})}(),function(){"use strict";jQuery(document).ready(function(){jQuery(".two-cols-text-with-slider .img-slider").before('<div class="fpt-spinner"><\/div>');setTimeout(function(){jQuery(".two-cols-text-with-slider .img-slider").each(function(){jQuery(this).slick({arrows:!0,variableWidth:!0,prevArrow:jQuery(this).closest(".two-cols-text-with-slider").find(".prev-title-button").first(),nextArrow:jQuery(this).closest(".two-cols-text-with-slider").find(".next-title-button").first(),infinite:!1,responsive:[{breakpoint:768,settings:{prevArrow:jQuery(this).closest(".two-cols-text-with-slider").find(".prev-img-button").first(),nextArrow:jQuery(this).closest(".two-cols-text-with-slider").find(".next-img-button").first(),variableWidth:!1}}]})});jQuery(".two-cols-text-with-slider .fpt-spinner").remove()},2e3)});jQuery(document).ready(function(){jQuery(function(){var n,u,f,t,e;if(jQuery(".two-cols-text-with-slider-gioi-thieu-chung .img-container .img-slider").length){var i=function(){r();t=0;u=!1;f=setInterval(o,10)},o=function(){!1===u&&(t+=1/(e+.1),n.css({width:t+"%"}),t>=100&&(jQuery(".two-cols-text-with-slider-gioi-thieu-chung .img-container .img-slider").slick("slickNext"),i()))},r=function(){n.css({width:"0%"});clearTimeout(f)};jQuery(".two-cols-text-with-slider-gioi-thieu-chung .img-container .img-slider").slick({arrows:!1,dots:!0,slidesToShow:1,slidesToScroll:1,fade:!0,infinite:!0,speed:500});e=5;n=jQuery(".slider-homepage-progress .progress");i();jQuery(".two-cols-text-with-slider-gioi-thieu-chung .img-container .img-slider").on("beforeChange",function(){r();i();n.css({width:"100%"})})}})})}(),function(){"use strict";jQuery("img").each(function(){!this.closest("a")&&(jQuery(".richtext-new-detail").length||jQuery(".component-top-new-feature").length||jQuery(".component-bottom-new-feature").length)&&$(this).on("click",function(n){jQuery("body").hasClass("show-zoom")||(n.stopPropagation(),jQuery("body").addClass("show-zoom"),jQuery(".popup-zoom .wrap-img-zoom img")[0].src=this.src,window.innerWidth>991?(jQuery(".popup-zoom .wrap-img-zoom img")[0].style="width: auto; height:80%; max-width: 100% object-fit: cover",jQuery("body").css({overflow:"hidden"})):(jQuery(".popup-zoom .wrap-img-zoom img")[0].style="max-width: 100%; height: auto}; object-fit: cover",jQuery("body").css({overflow:"hidden"})))})});jQuery(".close-zoom").click(function(){jQuery("body").removeClass("show-zoom");jQuery("body").css({overflow:"unset"});jQuery(".img-zoom").attr("src","")})}(),function(){"use strict";document.addEventListener("DOMContentLoaded",function(){var i=document.querySelectorAll("a.dmca-badge"),n,t;if(i[0].getAttribute("href").indexOf("refurl")<0)for(n=0;n<i.length;n++)t=i[n],t.href=t.href+(-1===t.href.indexOf("?")?"?":"&")+"refurl="+document.location},!1)}(),function(){"use strict";var n;(n=jQuery)(".fpt-modal-wrap").length&&n(".fpt-modal-wrap .fpt-modal__open-modal").click(function(t){t.preventDefault();n(".fpt-modal__content_iframe").length>0&&n(".fpt-modal__content_iframe").attr("src",n(".fpt-modal__content_iframe").attr("data-src"));n("body").append(n(this).closest(".fpt-modal-wrap").find(".fpt-modal").first().prop("outerHTML"));n("body > .fpt-modal img.lazyload").attr("src",n("body > .fpt-modal img.lazyload").attr("data-src"));"function"==typeof window.lazyload()&&n("body > .fpt-modal picture.lazyload").lazyload();n("body > .fpt-modal .fpt-modal__btn-close").click(function(){n(this).closest(".fpt-modal").remove()});n("body > .fpt-modal").click(function(){n(this).remove()});n("body > .fpt-modal .fpt-modal__content").click(function(n){n.stopPropagation()});n(document).keyup(function(t){"Escape"===t.key&&n("body > .fpt-modal").remove()})})}(),function(){"use strict";jQuery(document).ready(function(){jQuery("picture.lazyload").lazyload();jQuery("img.lazyload").lazyload()})}(),function(){"use strict";jQuery(document).ready(function(){function n(){var n=decodeURIComponent(window.location.hash),i=jQuery(".fpt-container-full-width").outerHeight()+1,r,t;n&&jQuery(n).length>0&&jQuery("html, body").animate({scrollTop:jQuery(n).offset().top-100-parseInt(i)},600);r=jQuery(".fpt-toc-container");t=jQuery(".fpt-toc-container a");r&&t&&t.click(function(n){n.preventDefault();history.pushState?history.pushState(null,null,jQuery(this).attr("href")):location.hash=jQuery(this).attr("href");jQuery("html, body").animate({scrollTop:jQuery(jQuery(this).attr("href")).offset().top-100-parseInt(i)},600)})}jQuery(".richtext-new-detail").length>0&&(jQuery("#fpt-toc__content-id").toc({content:"div.richtext-new-detail",headings:"h2,h3,h4,h5,h6,h7"}),jQuery(".fpt-toc__header__icon-dropdown").on("click",function(){jQuery(".fpt-toc__content").toggleClass("show-toc-content");jQuery(".fpt-toc__header__icon-dropdown").toggleClass("active-show-dropdown")}),n());jQuery(".contentlongform").length>0&&(jQuery("#fpt-toc__content-id").toc({content:"div.contentlongform",headings:"h2,h3,h4,h5,h6,h7"}),jQuery(".fpt-toc__header__icon-dropdown").on("click",function(){jQuery(".fpt-toc__content").toggleClass("show-toc-content");jQuery(".fpt-toc__header__icon-dropdown").toggleClass("active-show-dropdown")}),n())})}(),function(){"use strict";jQuery(document).ready(function(){if(jQuery(".thankyou-component").length>0){var n=jQuery(".thankyou-page__icon-container").offset().top;$("html, body").animate({scrollTop:n-300},100)}})}(),function(){"use strict";jQuery(document).ready(function(){jQuery(".two-cols-text-with-image .fpt-accordion").length&&(jQuery(".two-cols-text-with-image .fpt-accordion li").each(function(){jQuery(this).hasClass("active")||jQuery(this).find(".accordion__item__content").first().slideUp()}),jQuery(".two-cols-text-with-image .fpt-accordion .item-title").click(function(){var n=jQuery(this).closest("li");if(n.hasClass("active"))return n.removeClass("active"),n.find(".accordion__item__content").first().slideUp(),!1;n.siblings("li.active").find(".accordion__item__content").first().slideUp();n.siblings("li.active").removeClass("active");n.toggleClass("active");n.find(".accordion__item__content").first().slideDown()}))})}()