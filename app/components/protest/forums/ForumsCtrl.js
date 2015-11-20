(function () {
    'use strict';

    angular
        .module('proProtest')
        .controller('ForumsCtrl', ForumsCtrl);

    ForumsCtrl.$inject = [];

    /* @ngInject */
    function ForumsCtrl() {
        var vm = this;
        vm.title = 'ForumsCtrl';

        activate();

        ////////////////

        function activate() {

        }
    }

})();

