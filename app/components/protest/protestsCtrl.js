(function () {
    'use strict';

    angular
        .module('proProtest')
        .controller('ProtestsCtrl', ProtestCtrl);


    console.log("test");
    ProtestCtrl.$inject = ['ProtestService'];

    /* @ngInject */
    function ProtestCtrl(ProtestService) {
        var vm = this;
        vm.title = 'ProtestCtrl';
        vm.protests = "";
        activate();

        ////////////////

        function activate() {
            ProtestService.getProtests().then(function(protests){
                vm.protests = protests;
            })
        }
    }

})();

