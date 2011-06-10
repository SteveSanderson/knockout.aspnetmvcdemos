// Prototype for an observable<->URL binding plugin.
(function () {
    var currentParams = {}, updateTimer, $ = window.jQuery;

    // Gives an address (URL) to a view model state
    ko.linkObservableToUrl = function (observable, hashPropertyName, defaultValue) {
        // When the observable changes, update the URL
        observable.subscribe(function (value) {
            currentParams[hashPropertyName] = value === defaultValue ? null : value;
            queueAction(function () {
                for (var key in currentParams)
                    $.address.parameter(key, currentParams[key]);
                $.address.update();
            });
        });

        // When the URL changes, update the observable
        $.address.change(function (evt) {
            observable(hashPropertyName in evt.parameters ? evt.parameters[hashPropertyName] : defaultValue)
        });
    }

    function queueAction(action) {
        if (updateTimer)
            clearTimeout(updateTimer);
        updateTimer = setTimeout(action, 0);
    }

    $.address.autoUpdate(false);
})();