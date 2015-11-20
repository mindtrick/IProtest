(function () {
    'use strict';

    angular
        .module('proProtest')
        .controller('ProtestCtrl', ProtestCtrl);


    ProtestCtrl.$inject = ['$stateParams', '$state','ProtestService','FacebookLogin'];

    /* @ngInject */
    function ProtestCtrl($stateParams, $state, ProtestService, facebookLogin) {
        var vm = this;
        vm.title = 'ProtestCtrl';
        vm.protest = null;
        vm.join = join;

        activate();

        vm.status = "p";

        vm.select = function(id){
            vm.status = id;
        };
        vm.isSelected = function(id){
            return vm.status == id;
        };
        ////////////////

        function activate() {
            facebookLogin.init().then(function () {
                facebookLogin.getUser().then(function (user) {
                    vm.user = user;
                });
            });

            ProtestService.getProtest($stateParams.id).then(function(protest){
                vm.protest = protest;
            })
        }

        function join() {
            $state.go('joinProtest', { 'id': vm.protest.id });
        }
    }

})();

