(function () {
    'use strict';
    angular.module('uftmsApp')
            .factory('authInterceptor', ['authService', function (authService) {
                return {
                    request: function (config) {
                        var token = authService.getToken();
                        if (token) {
                            config.headers = config.headers || {};
                            config.headers.Authorization = 'Bearer ' + token;
                        }
                        return config;
                    }
                };
            }]);
})();