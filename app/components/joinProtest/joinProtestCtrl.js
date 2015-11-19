(function () {
    'use strict';

    angular
        .module('proJoinProtest',['proProtest'])
        .controller('JoinProtestCtrl', JoinProtestCtrl);

    JoinProtestCtrl.$inject = ['$scope','$stateParams', '$state', 'ProtestService'];

    /* @ngInject */
    function JoinProtestCtrl($scope, $stateParams, $state, ProtestService) {
        var vm = this;
        vm.title = 'JoinProtestCtrl';

        vm.appAllowChanged = appAllowChanged;
        vm.allowedOptions = allowedOptions;
        vm.totalOptions = totalOptions;
        vm.getProgressWidth = getProgressWidth;
        vm.join = join;

        activate();

        ////////////////

        function activate() {
            var protestId = $stateParams.id;
            ProtestService.getProtest(protestId).then(function (protest) {
                vm.protest = protest;
            })
        }

        $scope.$watch(
            function () {
                return getProgressWidth();
            },
            function (width) {
                vm.progressWidth = { 'width': width.toString() + '%' };
            }
        );

        function join() {
            //todo: send to server the thing he needs
            $state.go('protest', { 'id': vm.protest.id });
        }

        function allowedOptions() {
            if (!vm.protest) return 0;

            var allowedOptions = 0;
            vm.protest.apps.forEach(function (app) {
                app.options.forEach(function (option) {
                    if (option.allowed)
                        allowedOptions++;
                });
            });
            return allowedOptions;
        }

        function totalOptions() {
            if (!vm.protest) return 0;

            var totalOptions = 0;
            vm.protest.apps.forEach(function (app) {
                totalOptions += app.options.length;
            });
            return totalOptions;
        }

        function getProgressWidth() {
            if (!vm.protest) return 0;

            return Math.round((allowedOptions() / totalOptions()) * 100);
        }

        function appAllowChanged($event,app) {
            app.options.forEach(function (option) {
                option.allowed = app.allowAll;
            })
            app.expanded = false; // so it will open when clicking
        }

    }

})();