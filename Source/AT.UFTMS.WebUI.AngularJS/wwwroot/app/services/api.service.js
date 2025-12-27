(function () {
    'use strict';
    angular.module('uftmsApp')
            .service('apiService', ['$http', function ($http) {
                var BASE_URL = 'https://localhost:7290/api';
                this.login = function () {
                    return $http.post(BASE_URL + '/Auth/login');
                };
            }]);
})();