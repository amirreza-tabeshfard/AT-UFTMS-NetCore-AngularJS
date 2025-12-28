(function () {
    'use strict';
    angular.module('uftmsApp')
            .controller('HomeController', ['$location', 'authService',
                function ($location, authService) {
                    var vm = this;
                    vm.logout = function () {
                        authService.logout();
                        $location.path('/login');
                    };
                }]);
})();