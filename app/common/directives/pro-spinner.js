(function () {
    'use strict';

    angular
        .module('proDirective')
        .directive('proSpinner', proSpinner);

    proSpinner.$inject = ['$rootScope'];

    /* @ngInject */
    function proSpinner($rootScope) {
        var directive = {
            bindToController: true,
            link: link,
            restrict: 'A',
            scope: {}
        };
        return directive;

        function link(scope, element, attrs) {
            // by defult hide the spinner bar
            element.addClass('hide'); // hide spinner bar by default

            // count how many time requests were sent to the server
            // so when they all done the spinner will be removed
            scope.counter = 0;

            $rootScope.$on('$stateNetworkRequestStarted', function () {
                scope.counter++;
                element.removeClass('hide'); // show spinner bar
                //  $('body').addClass('page-on-load');
            });

            $rootScope.$on('$stateNetworkRequestEnded', function () {
                scope.counter--;
                if (scope.counter <= 0) {
                    scope.counter = 0;
                    element.addClass('hide'); // show spinner bar
                }
                //  $('body').removeClass('page-on-load'); // remove page loading indicator
            });

            // display the spinner bar whenever the route changes(the content part started loading)
            $rootScope.$on('$stateChangeStart', function () {
                element.removeClass('hide'); // show spinner bar
            });

            // hide the spinner bar on rounte change success(after the content loaded)
            $rootScope.$on('$stateChangeSuccess', function () {
                element.addClass('hide'); // hide spinner bar

                $('body').removeClass('page-on-load'); // remove page loading indicator
                Layout.setSidebarMenuActiveLink('match'); // activate selected link in the sidebar menu

                // auto scorll to page top
                setTimeout(function () {
                    Metronic.scrollTop(); // scroll to the top on content load
                }, $rootScope.settings.layout.pageAutoScrollOnLoad);

            });

            // handle errors
            $rootScope.$on('$stateNotFound', function () {
                element.addClass('hide'); // hide spinner bar
            });

            // handle errors
            $rootScope.$on('$stateChangeError', function () {
                element.addClass('hide'); // hide spinner bar
            });
        }
    }



})();

