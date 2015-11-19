(function () {
    'use strict';

    angular
        .module('proProtest')
        .controller('NewsCtrl', NewsCtrl);

    NewsCtrl.$inject = [];

    /* @ngInject */
    function NewsCtrl() {
        var vm = this;
        vm.title = 'NewsCtrl';

        activate();

        ////////////////

        function activate() {

        }
    }

})();

