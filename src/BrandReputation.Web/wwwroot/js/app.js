define(['marionette'], function (Marionette) {
    var BrandReputationApp = Marionette.Application.extend({
        prueba: function () {
            console.log('Entra a marionette app');
        }
    });

    var newApp = new BrandReputationApp();

    newApp.on('start', function () {
        Backbone.history.start();
    });

    return newApp;
});