var pagesModule = angular.module('pagesModule', []);
var protests = [
            {
                id: 1,
                name: 'test protest',
                description: 'bla bla'
            },
            {
                id: 2,
                name: 'test protest2',
                description: 'bla bla2'
            }
];
pagesModule.controller('mainController', function ($scope, $location) {
    $scope.navigateToProtest = navigateToProtest;

    $scope.protests = [];
    _loadProtests();

    function navigateToProtest(protest) {
        $location.path('/protest/' + protest.id);
    }

    function _loadProtests() {
        //todo: load from server
        $scope.protests = protests;
    }
});

pagesModule.controller('protestPageCtrl', function ($scope, $routeParams, $anchorScroll) {
    var protestId = $routeParams.protestId;
    _loadProtest(protestId);

    $scope.tabs = ['Description', 'Links', 'Images'];
    $scope.selectedTab = 'Description';

    $scope.selectTab = selectTab;

    function selectTab(tab) {
        $scope.selectedTab = tab;
        $anchorScroll(tab);
    }


    function _loadProtest(id) {
        //todo: load from server
        $scope.protest = _.filter(protests, function (protest) { return protest.id == id })[0];
    }
});