(function () {
    'use strict';

    angular
        .module('proServices')
        .service('FacebookLogin', FacebookLogin);

    FacebookLogin.$inject = ['$q'];

    /* @ngInject */
    function FacebookLogin($q) {
        var self = this;
        this.checkLoginState = checkLoginState;
        this.getName = FBGetName;
        this.getId = FBGetId;
        this.getProfilePic = FBGetProfilePic;
        this.getUser = FBGetUser;
        this.init = init;

        var _initialized = false;
        var _initDefer;
        var _user;

        function init() {
            _initDefer = $q.defer();
            if (_initialized) {
                _initDefer.resolve();
            }
            return _initDefer.promise;
        }


        // This is called with the results from from FB.getLoginStatus().
        function statusChangeCallback(response) {
            _initialized = true;
            if (_initDefer) {
                _initDefer.resolve();
            }

            // The response object is returned with a status field that lets the
            // app know the current login status of the person.
            // Full docs on the response object can be found in the documentation
            // for FB.getLoginStatus().
            if (response.status === 'connected') {
                var user = {};
                user.token = response.authResponse.accessToken;
                user.uid = response.authResponse.userID;

                FB.api('/me', function (response) {
                    user.image = "//graph.facebook.com/" + response.id + "/picture";
                    user.name = response.name;
                    $.ajax({
                        url: '/PostStatus/Login',
                        type: 'POST',
                        data: user
                    }).done(function () {

                    });
                });
            }
            else {
                alert('Error when trying to connect to facebook');
            }
        }

        // This function is called when someone finishes with the Login
        // Button.  See the onlogin handler attached to it in the sample
        // code below.
        function checkLoginState() {
            FB.getLoginStatus(function (response) {
                statusChangeCallback(response);
            });
        }

        window.fbAsyncInit = function () {
            FB.init({
                appId: '944613048943438',
                cookie: true,  // enable cookies to allow the server to access
                // the session
                xfbml: true,  // parse social plugins on this page
                version: 'v2.2' // use version 2.2
            });

            // Now that we've initialized the JavaScript SDK, we call
            // FB.getLoginStatus().  This function gets the state of the
            // person visiting this page and can return one of three states to
            // the callback you provide.  They can be:
            //
            // 1. Logged into your app ('connected')
            // 2. Logged into Facebook, but not your app ('not_authorized')
            // 3. Not logged into Facebook and can't tell if they are logged into
            //    your app or not.
            //
            // These three cases are handled in the callback function.

            FB.getLoginStatus(function (response) {
                statusChangeCallback(response);
            });

        };

        function FBGetName() {
            var defer = $q.defer();
            FB.api('/me', function (response) {
                defer.resolve(response.name);
            });
            return defer.promise;
        }
        function FBGetId() {
            var defer = $q.defer();
            FB.api('/me', function (response) {
                defer.resolve(response.id);
            });
            return defer.promise;
        }
        function FBGetProfilePic() {
            var defer = $q.defer();
            FBGetId().then(function (id) {
                defer.resolve("//graph.facebook.com/" + id + "/picture");
            });
            return defer.promise;
        }

        function FBGetUser() {
            var defer = $q.defer();
            if (_user && _user.id) {
                defer.resolve(_user);
                return defer.promise;
            }

            _user = {};
            var promises = [];

            var namePromise = FBGetName();
            namePromise.then(function (userName) {
                _user.userName = userName;
            });
            promises.push(namePromise);

            var picPromise = FBGetProfilePic();
            picPromise.then(function (profilePic) {
                _user.profilePic = profilePic;
            });
            promises.push(picPromise);

            var idPromise = FBGetId();
            idPromise.then(function (id) {
                _user.id = id;
            });
            promises.push(idPromise);

            $q.all(promises).then(function () {
                defer.resolve(_user);
            });

            return defer.promise;
        }
    }

})();


