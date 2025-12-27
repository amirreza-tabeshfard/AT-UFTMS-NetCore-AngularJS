(function () {
    'use strict';
    angular.module('uftmsApp')
        .config(['$routeProvider', '$httpProvider', function ($routeProvider, $httpProvider) {
                $httpProvider.interceptors.push('authInterceptor');
                $routeProvider
                    .when('/login', {
                        templateUrl: 'app/views/login.html',
                        controller: 'LoginController'
                    })
                    .when('/home', {
                        templateUrl: 'app/views/home.html',
                        controller: 'HomeController'
                    })
                    .otherwise({
                        redirectTo: '/login'
                    });
            }
        ]);
})();