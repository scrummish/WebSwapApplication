$(document).ready(function () {
    if ($.fn.placeholder) {
        $('input, textarea').placeholder();
    }
    if (!Modernizr.svg) {
        $(".paylocity-logo a").css("background-image", "url(Content/Images/paylocity-logo-sm.png)");
        (function () {
            var e = document.getElementsByTagName("img"),
                t = /.*\.svg$/,
                n = 0,
                r = e.length;
            for (; n < r; ++n) {
                if (e[n].src.match(t)) {
                    e[n].src = e[n].src.slice(0, -3) + "png"
                }
            }
        })()
    }
});

/* //@prepros-append */