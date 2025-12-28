(function () {
    'use strict';
    angular.module('uftmsApp')
            .factory('authService', ['$window', function ($window) {
                var TOKEN_KEY = 'uftms_token';
                function getTokenPayload(token) {
                    try {
                        var payload = token.split('.')[1];
                        return JSON.parse(atob(payload));
                    } catch {
                        return null;
                    }
                }
                return {
                    setToken: function (token) {
                        $window.localStorage.setItem(TOKEN_KEY, token);
                    },

                    getToken: function () {
                        return $window.localStorage.getItem(TOKEN_KEY);
                    },

                    isAuthenticated: function () {
                        var token = this.getToken();
                        if (!token)
                            return false;

                        var payload = getTokenPayload(token);
                        if (!payload || !payload.exp)
                            return false;

                        var now = Math.floor(Date.now() / 1000);
                        return payload.exp > now;
                    },

                    logout: function () {
                        $window.localStorage.removeItem(TOKEN_KEY);
                    }
                };
            }]);
})();