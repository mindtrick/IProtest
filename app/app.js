var mainApp = angular.module('iprotestApp', [
    "ui.bootstrap",
    "oc.lazyLoad",
    'ui.router',
    'proServices',
    'proDirective',
    'proProtest',
    'proJoinProtest']);

mainApp.config(['$ocLazyLoadProvider', function ($ocLazyLoadProvider) {
    $ocLazyLoadProvider.config({

    });
} ]);

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

        .state('joinProtest', {
            url: "/joinProtest/:id",
            templateUrl: "components/joinProtest/joinProtest.html",
            controller: "JoinProtestCtrl",
            controllerAs: "jp"
        })

        .state('protest.desc', {
            url: "/protest/:id/desc",
            templateUrl: "components/protest/desc/desc.html",
            controller: "DescCtrl"
        })

        .state('protest.news', {
            url: "/protest/:id/news",
            templateUrl: "components/protest/news/news.html",
            controller: "NewsCtrl"
        })
    ;


} ]);