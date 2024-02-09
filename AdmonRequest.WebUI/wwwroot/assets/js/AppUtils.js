/**
 * Module for perform some javascript tasks" 
 *
 * @author Mark Adesina <omark@simplexsystem.com>
 */

var SiteUtils = SiteUtils || (function ($) {
    'use strict';

    var utilsFunc = {
        postJson: function (data, url) {
            return jQuery.ajax({
                type: "POST",
                url: url,
                data: JSON.stringify(data),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json'
            });
        },
        post: function (data, url) {
            return jQuery.ajax({
                type: "POST",
                url: url,
                data: data
            });
        },
        get: function (data, url) {
            return jQuery.ajax({
                type: "GET",
                url: url,
                data: data
            });
        },
        postImage: function (data, url) {
            return jQuery.ajax({
                type: "POST",
                url: url,
                data: data,
                contentType: false,
                processData: false,
                cache: false
            });
},
        //Format Number
        formatNumber: function (num) {
            if (num === undefined) {
                return 0;
            }

            return accounting.formatMoney(num, '');

        },
        removeFormat: function (num) {
            return accounting.unformat(num);
        },

        toFixed: function (num) {
            return accounting.toFixed(num);
        },
        loading: function (loadingText) { //Show Loading Icon

            $('body').find($(".loading-back-drop")).show();

            $('body').find($("#app-loader")).show();


        },
        loadingOff: function () {
            $('body').find($(".loading-back-drop")).hide();
            $('body').find($("#app-loader")).hide();
            // $(".loader").remove();
        }
    };


    return utilsFunc;



})(jQuery);