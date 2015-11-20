(function () {
    'use strict';

    angular
        .module('proProtest')
        .controller('ProtestCtrl', ProtestCtrl);


    ProtestCtrl.$inject = ['$stateParams', '$state','$timeout', 'ProtestService','FacebookLogin'];

    /* @ngInject */
    function ProtestCtrl($stateParams, $state, $timeout, ProtestService, facebookLogin) {
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
            $timeout(function () {
                facebookLogin.init().then(function () {
                    facebookLogin.getUser().then(function (user) {
                        vm.user = user;
                    });
                });
            }, 1000);

            ProtestService.getProtest($stateParams.id).then(function(protest){
                vm.protest = protest;
            })
        }

        function join() {
            $state.go('joinProtest', { 'id': vm.protest.id });
        }
    }

})();

