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
                apps: [
                    {
                        id: 1,
                        name: 'Facebook',
                        options: [
                            {
                                id: 1,
                                description: "Allow post on your wall relevant protest's posts and statuses",
                                allowed: false
            },
            {
                id: 2,
                                description: "Allow sharing posts on your behalf",
                                allowed: false
                            }
                        ]
                    },
                    {
                        id: 2,
                        name: 'Twitter',
                        options: [
                            {
                                id: 1,
                                description: "Allow Tweet on your behalf relevant protest's posts and statuses",
                                allowed: false
                            },
                            {
                                id: 2,
                                description: "Allow sharing posts on your behalf",
                                allowed: false
                            }
                        ]
                    },
                    {
                        id: 3,
                        name: 'Gmail',
                        options: [
                            {
                                id: 1,
                                description: "Allow send emails on your behalf relevant protest's posts and statuses to your contacts",
                                allowed: false
                            },
                            {
                                id: 2,
                                description: "Allow receiveing posts to your email account",
                                allowed: false
                            }
                        ]
                    }
                ]
            },
            {
                id: 2,
                name: 'test protest2',
                description: 'bla bla2',
                apps: [
                    {
                        id: 1,
                        name: 'Facebook',
                        options: [
                            {
                                id: 1,
                                description: "Allow post on your wall relevant protest's posts and statuses",
                                allowed: false
                            },
                            {
                                id: 2,
                                description: "Allow sharing posts on your behalf",
                                allowed: false
                            }
                        ]
                    },
                    {
                        id: 2,
                        name: 'Twitter',
                        options: [
                            {
                                id: 1,
                                description: "Allow Tweet on your behalf relevant protest's posts and statuses",
                                allowed: false
                            },
                            {
                                id: 2,
                                description: "Allow sharing posts on your behalf",
                                allowed: false
                            }
                        ]
                    },
                    {
                        id: 3,
                        name: 'Gmail',
                        options: [
                            {
                                id: 1,
                                description: "Allow send emails on your behalf relevant protest's posts and statuses to your contacts",
                                allowed: false
                            },
                            {
                                id: 2,
                                description: "Allow receiveing posts to your email account",
                                allowed: false
                            }
                        ]
                    }
                ]
            }
        ];


        //todo: uncomment when server is up
        //function getProtests() {
        //    return ApiHttpInfra.sendRequest('/protest', 'GET', '');
        //}

        //function getProtest(id) {
        //    return ApiHttpInfra.sendRequest('/protest/', 'GET', id)
        //}

        //todo: comment when server is up
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
                var protest = _.filter(protests,function(protest){
                    return protest.id == id;
                })[0];

                deferred.resolve(protest);
            });

            return deferred.promise;
        }
    }

})();

