var mainApp = angular.module('iprotestApp', ['ngRoute','pagesModule']);

mainApp.config(function ($routeProvider) {
    $routeProvider
        .when('/', {
            templateUrl: './Pages/HomePage.html',
        })

        // route for the about page
        .when('/protest/:protestId', {
            templateUrl: './Pages/protestPage.html'
        })

        // route for the home page
        .otherwise({ redirect: '/' });
});