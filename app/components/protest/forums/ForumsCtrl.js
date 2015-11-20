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
        vm.forums = [
            {
                id: 1,
                name: 'Kikar - religious discussion',
                image: 'https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcQop9SwrLJQsDhL58eF9BLBlfWzc27odH7VdlpRJJphlB_6S_WcxWEYr3U',
                src: 'http://www.bhol.co.il/forums/topic.asp?cat_id=4&topic_id=3097770&forum_id=21306'
            },
            {
                id: 2,
                name: 'Tapuz - hot discussion',
                image: 'https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcQop9SwrLJQsDhL58eF9BLBlfWzc27odH7VdlpRJJphlB_6S_WcxWEYr3U',
                src: 'http://www.tapuz.co.il/forums2008/forumPage.aspx?forumId=219'
            },
            {
                id: 3,
                name: 'Rotter - discussion & poll',
                image: 'http://2.bp.blogspot.com/-nuSEy00J8RM/Tpp14Cpnx_I/AAAAAAAAB8w/gOsW5afUGuM/s23/icon_new.gif',
                src: 'http://rotter.net/forum/scoops1/266612.shtml'
            },
            {
                id: 4,
                name: 'Walla Forums - poll',
                src: 'http://forums.walla.co.il/viewtopic.php?f=2903&t=14698127'
            }
        ];

        activate();

        ////////////////

        function activate() {

        }
    }

})();

