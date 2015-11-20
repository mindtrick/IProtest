﻿var mainApp = angular.module('iprotestApp', [
    "ui.bootstrap",
    "oc.lazyLoad",
    'ui.router',
    'proServices',
    'proDirective',
    'proProtest',
    'satellizer']);

mainApp.config(['$ocLazyLoadProvider', function ($ocLazyLoadProvider) {
    $ocLazyLoadProvider.config({});
}]);

mainApp.config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {

    // Redirect any unmatched url
    $urlRouterProvider.otherwise("/protests");

    $stateProvider
        .state('login', {
            url: "/login",
            templateUrl: "components/login/login.html",
            controller: "LoginCtrl"
        })

        .state('protests', {
            url: "/protests",
            templateUrl: "components/protest/protests.html",
            controller: "ProtestsCtrl",
            controllerAs: "ps"
        })

        .state('protest', {
            url: "/protest/:id",
            templateUrl: "components/protest/protest.html",
            controller: "ProtestCtrl",
            controllerAs: "p"
        })

        .state('protest.desc', {
            url: "/desc",
            templateUrl: "components/protest/desc/desc.html",
            controller: "DescCtrl"
        })

        .state('protest.news', {
            url: "/news",
            templateUrl: "components/protest/news/news.html",
            controller: "NewsCtrl"
        })
    ;


}])

    .config(function ($authProvider) {

        $authProvider.twitter({
            url: '/auth/twitter'
        });
        // No additional setup required for Twitter

        $authProvider.oauth2({
            name: 'foursquare',
            url: '/auth/foursquare',
            clientId: 'MTCEJ3NGW2PNNB31WOSBFDSAD4MTHYVAZ1UKIULXZ2CVFC2K',
            redirectUri: window.location.origin || window.location.protocol + '//' + window.location.host,
            authorizationEndpoint: 'https://foursquare.com/oauth2/authenticate'
        });


        function skipIfLoggedIn($q, $auth) {
            var deferred = $q.defer();
            if ($auth.isAuthenticated()) {
                deferred.reject();
            } else {
                deferred.resolve();
            }
            return deferred.promise;
        }

        function loginRequired($q, $location, $auth) {
            var deferred = $q.defer();
            if ($auth.isAuthenticated()) {
                deferred.resolve();
            } else {
                $location.path('/login');
            }
            return deferred.promise;
        }
    })
;
