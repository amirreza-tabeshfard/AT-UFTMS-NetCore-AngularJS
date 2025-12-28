(function () {
    'use strict';
    angular.module('uftmsApp')
            .config(['$routeProvider', function ($routeProvider) {
                $routeProvider
                    .when('/login', {
                        templateUrl: 'app/views/login.html',
                        controller: 'LoginController',
                        controllerAs: 'vm',
                        requiresAuth: false
                    })
                    .when('/home', {
                        templateUrl: 'app/views/home.html',
                        controller: 'HomeController',
                        controllerAs: 'vm',
                        requiresAuth: true
                    })
                    .otherwise({
                        redirectTo: '/login'
                    });
            }])
            .run(['$rootScope', '$location', 'authService',
                function ($rootScope, $location, authService) {
                    $rootScope.$on('$routeChangeStart', function (event, next) {
                        if (next.requiresAuth && !authService.isAuthenticated()) {
                            event.preventDefault();
                            $location.path('/login');
                        }
                        if (next.originalPath === '/login' && authService.isAuthenticated()) {
                            event.preventDefault();
                            $location.path('/home');
                        }
                    });
                }]);
})();