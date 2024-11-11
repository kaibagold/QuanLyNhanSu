var lazyloadnew=function(){"use strict";var t="undefined"!=typeof globalThis?globalThis:"undefined"!=typeof window?window:"undefined"!=typeof global?global:"undefined"!=typeof self?self:{};return function(t,e,r){return t(r={path:e,exports:{},require:function(t,e){return function(){throw new Error("Dynamic requires are not currently supported by @rollup/plugin-commonjs")}(null==e&&r.path)}},r.exports),r.exports}((function(e,r){function o(t){return(o="function"==typeof Symbol&&"symbol"==typeof Symbol.iterator?function(t){return typeof t}:function(t){return t&&"function"==typeof Symbol&&t.constructor===Symbol&&t!==Symbol.prototype?"symbol":typeof t})(t)}
/*! Lazy Load 2.0.0-rc.2 - MIT license - Copyright 2007-2019 Mika Tuupola */!function(t,s){"object"==o(r)?e.exports=s(t):t.LazyLoad=s(t)}(void 0!==t?t:t.window||t.global,(function(t){function e(t,e){this.settings=o(r,e||{}),this.images=t||document.querySelectorAll(this.settings.selector),this.observer=null,this.init()}var r={src:"data-src",srcset:"data-srcset",selector:".lazyload",root:null,rootMargin:"0px",threshold:0},o=function t(){var e={},r=!1,o=0,s=arguments.length;for("[object Boolean]"===Object.prototype.toString.call(arguments[0])&&(r=arguments[0],o++);o<s;o++)!function(o){for(var s in o)Object.prototype.hasOwnProperty.call(o,s)&&(r&&"[object Object]"===Object.prototype.toString.call(o[s])?e[s]=t(!0,e[s],o[s]):e[s]=o[s])}(arguments[o]);return e};if(e.prototype={init:function(){if(t.IntersectionObserver){var e=this,r={root:this.settings.root,rootMargin:this.settings.rootMargin,threshold:[this.settings.threshold]};this.observer=new IntersectionObserver((function(t){Array.prototype.forEach.call(t,(function(t){if(t.isIntersecting){e.observer.unobserve(t.target);var r=t.target.getAttribute(e.settings.src),o=t.target.getAttribute(e.settings.srcset),s="picture"===t.target.tagName.toLowerCase()&&t.target.children;if("picture"===t.target.tagName.toLowerCase())for(var n=0;n<s.length;n++)"source"===s[n].nodeName.toLowerCase()&&(s[n].getAttribute("data-srcset")?s[n].setAttribute("srcset",s[n].getAttribute("data-srcset")):s[n].setAttribute("srcset",s[s.length-1].getAttribute("data-src")));t.target.tagName.toLowerCase(),"img"===t.target.tagName.toLowerCase()?(r&&(t.target.src=r),o&&(t.target.srcset=o)):"picture"!==t.target.tagName.toLowerCase()&&(t.target.style.backgroundImage="url("+r+")")}}))}),r),Array.prototype.forEach.call(this.images,(function(t){e.observer.observe(t)}))}else this.loadImages()},loadAndDestroy:function(){this.settings&&(this.loadImages(),this.destroy())},loadImages:function(){if(this.settings){var t=this;Array.prototype.forEach.call(this.images,(function(e){var r=e.getAttribute(t.settings.src),o=e.getAttribute(t.settings.srcset);"picture"===t.target.tagName.toLowerCase()?console.log("abc",t.target):"img"===e.tagName.toLowerCase()?(r&&(e.src=r),o&&(e.srcset=o)):e.style.backgroundImage="url('"+r+"')"}))}},destroy:function(){this.settings&&(this.observer.disconnect(),this.settings=null)}},t.lazyload=function(t,r){return new e(t,r)},t.jQuery){var s=t.jQuery;s.fn.lazyload=function(t){return(t=t||{}).attribute=t.attribute||"data-src",new e(s.makeArray(this),t),this}}return e}))}))}();