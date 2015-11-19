(function () {
    'use strict';

    angular
        .module('proProtest')
        .controller('DescCtrl', DescCtrl);

    DescCtrl.$inject = [];

    /* @ngInject */
    function DescCtrl() {
        var vm = this;
        vm.title = 'DescCtrl';

        activate();

        ////////////////

        function activate() {

        }
    }

})();

