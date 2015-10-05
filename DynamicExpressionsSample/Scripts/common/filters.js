angular.module('dynamicTreeDemoApp')
    .filter('boolToValue', function () {
        return function (input, trueValue, falseValue) {
            return input ? trueValue : falseValue;
        };
    })

.filter('compareConditionToText', function () {
    return function (input) {
        var retVal;
        switch (input) {
            case 'IsMatching': retVal = 'matching'; break;
            case 'IsNotMatching': retVal = 'not matching'; break;
            case 'IsGreaterThan': retVal = 'greater than'; break;
            case 'IsGreaterThanOrEqual': retVal = 'greater than or equals'; break;
            case 'IsLessThan': retVal = 'less than'; break;
            case 'IsLessThanOrEqual': retVal = 'less than or equals'; break;
            case 'Contains': retVal = 'containing'; break;
            case 'NotContains': retVal = 'not containing'; break;
            case 'Matching': retVal = 'matching'; break;
            case 'NotMatching': retVal = 'not matching'; break;
            default:
                retVal = input;
        }
        return retVal;
    };
});