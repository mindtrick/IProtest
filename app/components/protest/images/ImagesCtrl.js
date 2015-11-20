
(function () {
    'use strict';

    angular
        .module('proProtest')
        .controller('ImagesCtrl', ImagesCtrl);

    ImagesCtrl.$inject = [];


    /* @ngInject */
    function ImagesCtrl() {
        var vm = this;
        vm.title = 'ImagesCtrl';

        vm.myInterval = 5000;
        vm.noWrapSlides = false;
        var slides = vm.slides = [];
        vm.addSlide = function() {
            slides.push({
                image: 'data:image/jpeg;base64,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'
            },{
                image:'https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcRvoZKs7Bgu1TT_ckiOVmOO2d58U8InNIheNQ-WfxqhDkso0E5jxw'
            },
                {
                    image:'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSny8aihdEaqdBZMxoslOx95NlicClYEgusgwiuBI5ykMf5oNmfKg'
                },{
                    image:'https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcTHzbiAaKybXwSg_xvvKYMcF8gSWas0yraOslMEUdsGbruTW9GZbg'
                },{
                    image:'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSmBn_QO3cBcdDXzRvBaBvpm4YsCvrSdHNL-nm8g5aOGj8l1ZFx'
                },{
                    image:'https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcSvKrjgWJA7cPLugNntu7d-2sYBJMuLzDMtwUMnPoGFI0c_IP20HA'
                }
                ,{
                    image:'https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcRWadytI-lLy3B0Vy8uoJpu3U8roAQ5c78Amdve2289odY7ksYf'
                }

            );
        };
        for (var i=0; i<4; i++) {
            vm.addSlide();
        }


        activate();

        ////////////////

        function activate() {

        }
    }

})();

