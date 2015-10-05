angular.module('dynamicTreeDemoApp')
    .factory('dynamicTree.api', ['$resource', function ($resource) {
        return $resource('api/customer', {}, {
            getConditions: { url: 'api/conditions' },
            filter: { method: 'POST', url: 'api/customers', isArray: true },
            saveExpression: { method: 'POST', url: 'api/conditions' }
        });
    }])

.controller('dynamicTreeClientCtrl', ['$scope', 'dynamicTree.api', 'virtoCommerce.coreModule.common.dynamicExpressionService',
    function ($scope, dynamicTreeApi, dynamicExpressionService) {

        $scope.refresh = function () {
            var expressionToServer = angular.copy($scope.dynamicExpression);
            if (expressionToServer) {
                expressionToServer.$promise = undefined;
                expressionToServer.$resolved = undefined;
                stripOffUiInformation(expressionToServer);
            }
            $scope.entities = dynamicTreeApi.filter(expressionToServer);
        };

        $scope.saveExpression = function () {
            var expressionToServer = angular.copy($scope.dynamicExpression);
            if (expressionToServer) {
                expressionToServer.$promise = undefined;
                expressionToServer.$resolved = undefined;
                stripOffUiInformation(expressionToServer);
            }
            $scope.entities = dynamicTreeApi.saveExpression(expressionToServer);
        };

        // Dynamic ExpressionBlock
        function extendElementBlock(expressionBlock) {
            var retVal = dynamicExpressionService.expressions[expressionBlock.Id];
            if (!retVal) {
                retVal = { displayName: 'unknown element: ' + expressionBlock.Id };
            }

            _.extend(expressionBlock, retVal);

            if (!expressionBlock.Children) {
                expressionBlock.Children = [];
            }
            _.each(expressionBlock.Children, extendElementBlock);
            _.each(expressionBlock.AvailableChildren, extendElementBlock);
            return expressionBlock;
        };

        function stripOffUiInformation(expressionElement) {
            expressionElement.AvailableChildren = undefined;
            expressionElement.displayName = undefined;
            expressionElement.getValidationError = undefined;
            expressionElement.groupName = undefined;
            expressionElement.newChildLabel = undefined;
            expressionElement.templateURL = undefined;

            _.each(expressionElement.Children, stripOffUiInformation);
        };
        // on load
        $scope.refresh();

        dynamicTreeApi.getConditions({}, function (data) {
            _.each(data.Children, extendElementBlock);
            $scope.dynamicExpression = data;
        });
    }]);