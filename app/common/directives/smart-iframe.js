(function () {
    'use strict';

    angular
        .module('proDirective')
        .directive('smartIframe', smartIframe);

    smartIframe.$inject = ['$compile'];

    /* @ngInject */
    function smartIframe($compile) {
        var directive = {
            restrict: 'E',
            scope: {
                src: "=src"
            },
            link: function (scope, element, attrs) {
                var template = '<div click-down><div  class="glass-over-screen"></div><iframe width="100%" height="600px" src="' + scope.src + '" style="z-index: -1"></iframe></div>';
                var el = $compile(template)(scope);
                element.replaceWith(el);

            }
        };
        return directive;
    }
})();

