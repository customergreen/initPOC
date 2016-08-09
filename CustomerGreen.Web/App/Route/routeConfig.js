(function () {
    'use strict';

    angular.module('customerGreenApp')
        //.config(['$routeProvider', function ($routeProvider) {
        //    $routeProvider.when('/', {
        //        templateUrl: '/App/Templates/Contact/Index.html',
        //        requiresLogin: true,
        //        controller: 'ContactController'
        //    })
        //  .when('/Account/Login', {
        //      templateUrl: '/App/Templates/Account/Login.html',
        //      controller: 'LoginController'
        //  })
        //  .when('/Account/Register', {
        //      templateUrl: '/App/Templates/Account/Register.html',
        //      controller: 'RegisterController'
        //  })
        //  .otherwise({
        //      templateUrl: '/App/Templates/Shared/_404.html'
    //  })
    .config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {
        $stateProvider.state('register', {
            url: "/register",
            abstract: true,
            templateUrl: '/App/Templates/Account/Register.html',
            controller: 'RegisterController'
        }).state('register.email', {
            url: "/email",
            templateUrl: '/App/Templates/Account/RegistrationEmail.html', // ui-sref:register.email            
        }).state('register.details', {
            url: "/details",
            templateUrl: '/App/Templates/Account/RegistrationDetails.html',            
        }).state('register.business', {
            url: "/business",
            templateUrl: '/App/Templates/Account/RegistrationBusiness.html',            
        }).state('login', {
            url: "/login",         
            templateUrl: '/App/Templates/Account/Login.html',
            controller: 'LoginController'
        })
        $urlRouterProvider.otherwise('/login');
    }])
        
        //.run(checkAuthentication);

        //checkAuthentication.$inject = ['$rootScope', '$location', 'tokenHandler'];
        //function checkAuthentication($rootScope, $location, tokenHandler) {
        //    $rootScope.$on('$routeChangeStart', function (event, next, current) {
        //        var requiresLogin = next.requiresLogin || false;
        //        if (requiresLogin) {

        //            var loggedIn = tokenHandler.hasLoginToken();

        //            if (!loggedIn) {
        //                $location.path('/Account/Login');
        //            }
        //        }
        //    });
        //}
})();