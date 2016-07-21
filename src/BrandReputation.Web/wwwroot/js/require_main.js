requirejs.config({
    baseUrl: '/',
    paths: {
        backbone: 'lib/backbone/backbone',
        jquery: 'lib/jquery/dist/jquery',
        json2: 'lib/json2/json2',
        underscore: 'lib/underscore/underscore',
        marionette:'lib/marionette/lib/backbone.marionette'
    },
    shim: {
        underscore: {
            exports:'_'
        },
        backbone: {
            deps: ['jquery', 'underscore', 'json2'],
            exports:'Backbone'
        },
        marionette: {
            deps: ['backbone'],
            exports:'Marionette'
        }
    }
});

require(['js/app'], function (BrandReputationApp) {
    BrandReputationApp.start();
});