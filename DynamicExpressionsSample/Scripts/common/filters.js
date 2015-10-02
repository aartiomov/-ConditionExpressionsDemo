angular.module('dynamicTreeDemoApp')
    .filter('boolToValue', function () {
        return function (input, trueValue, falseValue) {
            return input ? trueValue : falseValue;
        };
    });