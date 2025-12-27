(function () {
    'use strict';
    angular.module('uftmsApp')
            .service('authService', ['$window', function ($window) {
                var TOKEN_KEY = 'uftms_token';
                this.setToken = function (token) {
                    $window.localStorage.setItem(TOKEN_KEY, token);
                };
                this.getToken = function () {
                    return $window.localStorage.getItem(TOKEN_KEY);
                };
                this.isAuthenticated = function () {
                    return !!this.getToken();
                };
                this.logout = function () {
                    $window.localStorage.removeItem(TOKEN_KEY);
                };
            }]);
})();