(function () {
    "use strict";

    angular.module("uftmsApp")
        .controller("HomeController", ["$scope", function ($scope) {
            $scope.message = "Welcome to AT.UFTMS AngularJS App";
        }]);

})();