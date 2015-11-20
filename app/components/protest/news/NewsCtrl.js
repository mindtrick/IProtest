(function () {
    'use strict';

    angular
        .module('proProtest')
        .controller('NewsCtrl', NewsCtrl);

    NewsCtrl.$inject = [];

    /* @ngInject */
    function NewsCtrl() {
        var vm = this;
        vm.title = 'NewsCtrl';
        vm.news = [
            {
                id: 1,
                name: 'Walla - very important topic',
                image: 'https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcQop9SwrLJQsDhL58eF9BLBlfWzc27odH7VdlpRJJphlB_6S_WcxWEYr3U',
                src: 'http://news.walla.co.il/item/2908395'
            },
            {
                id: 2,
                name: 'Ynet - hot descussion',
                image: 'https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcQop9SwrLJQsDhL58eF9BLBlfWzc27odH7VdlpRJJphlB_6S_WcxWEYr3U',
                src: 'http://www.ynet.co.il/articles/0,7340,L-4728382,00.html'
            },
            {
                id: 3,
                name: 'Nrg - breaking',
                image: 'http://2.bp.blogspot.com/-nuSEy00J8RM/Tpp14Cpnx_I/AAAAAAAAB8w/gOsW5afUGuM/s23/icon_new.gif',
                src: 'http://www.nrg.co.il/online/1/ART2/738/632.html?hp=1&cat=875&loc=1'
            },
            {
                id: 4,
                name: 'Ynet - protest coverage',
                src: 'http://www.ynet.co.il/articles/0,7340,L-4728365,00.html'
            },
            {
                id: 5,
                name: 'Mako - protest coverage',
                src: 'http://www.mako.co.il/news-israel/local-q4_2015/Article-912d6cdbe512151004.htm'
            }
        ];

        activate();

        ////////////////

        function activate() {

        }
    }

})();

