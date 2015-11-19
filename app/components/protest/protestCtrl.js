(function () {
    'use strict';

    angular
        .module('proProtest')
        .controller('ProtestCtrl', ProtestCtrl);


    ProtestCtrl.$inject = ['$stateParams', '$state','ProtestService'];

    /* @ngInject */
    function ProtestCtrl($stateParams, $state, ProtestService) {
        var vm = this;
        vm.title = 'ProtestCtrl';
        vm.protest = null;
        vm.join = join;

        activate();

        ////////////////

        function activate() {
            ProtestService.getProtest($stateParams.id).then(function(protest){
                vm.protest = protest;
            })
        }

        function join() {
            $state.go('joinProtest', { 'id': vm.protest.id });
        }
    }

})();

