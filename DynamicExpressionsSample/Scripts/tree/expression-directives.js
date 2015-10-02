//Call this to register our module to main application
var moduleName = "virtoCommerce.coreModule.common";

if (AppDependencies != undefined) {
    AppDependencies.push(moduleName);
}

angular.module(moduleName, [])
.factory('virtoCommerce.coreModule.common.dynamicExpressionService', function () {
    var retVal = {
        expressions: [],
        registerExpression: function (expression) {
            if (!expression.templateURL) {
                expression.templateURL = 'expression-' + expression.id + '.html';
            }

            this.expressions[expression.id] = expression;
        }
    };
    return retVal;
})
.directive('vaDynamicExpressionTree', function () {
    return {
        restrict: 'E',
        //scope: {
        //    source: '='
        //},
        link: function ($scope, $element, $attrs) {
            $scope.addChild = function (chosenMenuElement, parentBlock) {
                if (!parentBlock.Children) {
                    parentBlock.Children = [];
                }
                parentBlock.Children.push(angular.copy(chosenMenuElement));
            };
            $scope.deleteChild = function (child, parentList) {
                parentList.splice(parentList.indexOf(child), 1);
            }

            $scope.$watch($attrs.source, function (newVal) {
                $scope.source = newVal;
            });
        },
        templateUrl: 'Scripts/tree/expression-tree.tpl.html'
    };
})
;