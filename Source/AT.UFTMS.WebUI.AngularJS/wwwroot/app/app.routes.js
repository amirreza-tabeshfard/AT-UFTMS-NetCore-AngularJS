(function () {
    "use strict";

    angular.module("uftmsApp")
        .config(["$routeProvider", function ($routeProvider) {

            $routeProvider
                .when("/", {
                    templateUrl: "app/views/home.html",
                    controller: "HomeController"
                })
                .otherwise({
                    redirectTo: "/"
                });

        }]);

})();