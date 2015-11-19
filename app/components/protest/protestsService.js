(function () {
    'use strict';

    angular
        .module('proProtest')
        .service('ProtestService', ProtestService);

    ProtestService.$inject = ['$q', '$timeout', 'ApiHttpInfra'];

    /* @ngInject */
    function ProtestService($q, $timeout, ApiHttpInfra) {
        this.getProtests = getProtests;
        this.getProtest = getProtest;

        ////////////////
        var protests = [
            {
                id: 1,
                name: 'test protest',
                description: 'bla bla',

            },
            {
                id: 2,
                name: 'test protest2',
                description: 'bla bla2'
            }
        ];

        function getProtests() {
            var deferred = $q.defer();

            $timeout(function(){
                deferred.resolve(protests);
            });

            return deferred.promise;
        }

        function getProtest(id) {

            var deferred = $q.defer();

            $timeout(function(){
                var protest = _.find(protests,function(protest){
                    return protest.id == id;
                });

                deferred.resolve(protests);
            });

            return deferred.promise;


        }
    }

})();

