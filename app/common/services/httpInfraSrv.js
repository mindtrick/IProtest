(function () {
    'use strict';

    angular
        .module('proServices')
        .service('ApiHttpInfra', ApiHttpInfra);

    ApiHttpInfra.$inject = ['$location', '$http', '$q', '$rootScope'];

    /* @ngInject */
    function ApiHttpInfra($location, $http, $q, $rootScope) {
        var self = this;
        this.sendRequest = sendRequest;

        ////////////////
        this.domain = "localhost";

        var sendRequest = function (subDomain, method, queryString, request, parser) {
            var deferred = $q.defer();

            $rootScope.$emit('$stateNetworkRequestStarted');
            $http({
                url: self.domain + subDomain + queryString,
                method: method,
                data: request,
                headers: {
                    "Content-Type": "application/json"
                }
            }).
                success(function (data, status, header, config) {
                    var parsedData = parser ? parser(data) : data;
                    deferred.resolve(parsedData);
                    $rootScope.$emit('$stateNetworkRequestEnded');
                }).
                error(function (data, status, header, config) {
                    if (status == 403)
                        $location.url(cmsOrigin + '/login.html');

                    // TODO: Indiate error to user??
                    console.log("Error for request - " + queryString);
                    $rootScope.$emit('$stateNetworkRequestEnded');
                    deferred.reject(data);
                });

            return deferred.promise;
        };
    }

})();


