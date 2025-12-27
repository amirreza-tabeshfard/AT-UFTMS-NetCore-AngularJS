(function () {
    'use strict';
    angular.module('uftmsApp')
            .controller('LoginController', [
                '$scope',
                '$location',
                'apiService',
                'authService',
                function ($scope, $location, apiService, authService) {
                    $scope.login = function () {
                        apiService.login()
                            .then(function (response) {
                                console.log('LOGIN SUCCESS:', response);
                                var token = response.data.token;
                                authService.setToken(token);
                                $location.path('/home');
                            })
                            .catch(function (error) {
                                console.error('LOGIN ERROR:', error);
                                alert('Login failed');
                            });
                    };
                }
            ]);
})();