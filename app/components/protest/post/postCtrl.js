(function () {
    'use strict';

    angular
        .module('proProtest')
        .controller('PostCtrl', PostCtrl);

    PostCtrl.$inject = ['$scope', '$stateParams', '$state', 'ProtestService'];

    /* @ngInject */
    function PostCtrl($scope, $stateParams, $state, ProtestService) {
        var vm = this;
        vm.title = 'PostCtrl';

        vm.post = post;

        activate();

        ////////////////

        function activate() {
            var protestId = $stateParams.id;
            ProtestService.getProtest(protestId).then(function (protest) {
                vm.protest = protest;
            })
        }

        function post() {
            ProtestService.sendPost(vm.message, vm.protest.id)
            $state.go('protest', { id: vm.protest.id });
        }

    }

})();