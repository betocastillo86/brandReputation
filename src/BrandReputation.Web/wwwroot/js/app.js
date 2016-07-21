define(['marionette'], function (Marionette) {
    debugger;
    var BrandReputationApp = new Marionette.Application.extend({
        prueba: function () {
            console.log('Entra a marionette app');
        }
    });

    var newApp = new BrandReputationApp();

    newApp.on('before:start', function () {
        debugger;
    });

    return BrandReputationApp;
});