var AppDependencies = [
'ngResource',
'ng-context-menu',
'virtoCommerce.coreModule.common'
];

angular.module('dynamicTreeDemoApp', AppDependencies)
.run(
  ['$http', '$compile', 'virtoCommerce.coreModule.common.dynamicExpressionService', function ($http, $compile, dynamicExpressionService) {
        //Register root expression
        dynamicExpressionService.registerExpression({
            id: 'BlockConditionAndOr',
            newChildLabel: '+ add condition'
        });

        dynamicExpressionService.registerExpression({
            id: 'ConditionAgeIs',
            displayName: 'Shopper age is []'
        });

        dynamicExpressionService.registerExpression({
            id: 'ConditionGenderIs',
            displayName: 'Shopper gender is []'
        });

        dynamicExpressionService.registerExpression({
            id: 'ConditionOrdersIs',
            displayName: 'Shopper has placed [] orders'
        });

        dynamicExpressionService.registerExpression({
            id: 'ConditionFirstNameIs',
            displayName: 'First name is []'
        });

        dynamicExpressionService.registerExpression({
            id: 'ConditionLastNameIs',
            displayName: 'Last name is []'
        });

        $http.get('Scripts/expressionClient/all-templates.html').then(function (response) {
            // compile the response, which will put stuff into the cache
            $compile(response.data);
        });
    }
  ]);
