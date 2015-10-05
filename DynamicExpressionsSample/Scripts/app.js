var AppDependencies = [
'ngResource',
'ng-context-menu',
'virtoCommerce.coreModule.common'
];

angular.module('dynamicTreeDemoApp', AppDependencies)
.run(
  ['$rootScope', '$templateCache',
    function ($rootScope, $templateCache) {

    }
  ]);
