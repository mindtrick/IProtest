(function () {
    'use strict';

    angular
        .module('proProtest')
        .controller('ProtestCtrl', ProtestCtrl);


    ProtestCtrl.$inject = ['$stateParams', 'ProtestService'];

    /* @ngInject */
    function ProtestCtrl($stateParams, ProtestService) {
        var vm = this;
        vm.title = 'ProtestCtrl';
        vm.protest = null;
        activate();

        vm.status = "";

        vm.select = function(id){
            vm.status = id;
        };
        vm.isSelected = function(id){
            return vm.status == id;
        };
        ////////////////

        function activate() {
            ProtestService.getProtest($stateParams.id).then(function(protest){
                vm.protest = protest;
            })
        }
    }

})();

