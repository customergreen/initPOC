(function () {
    'use strict';

    angular
        .module('customerGreenApp')
        .controller('RegisterController', RegisterController);

    RegisterController.$inject = ['$scope', '$location', '$timeout', 'AuthService'];

    function RegisterController($scope, $location, $timeout, AuthService) {

        $scope.savedSuccessfully = false;
        $scope.message = "";

        $scope.details = {
            country: ["United States", "Canada", "India"],
            b1: ["Please Select.."], b2: ["Please Select"],
            plan: ["Select usage type.."],
            rev: ["Select estimated revenue"]
        }

        $scope.registration = {
            firstName: "",
            lastName: "",
            email: "",
            companyName: "",
            userName: "",
            password: "",
            conf_password: "",
            business_type: "",
            business_sub_type: "",
            License_type: ""
        };

        $scope.signUp = function () {

            AuthService.saveRegistration($scope.registration)
                .then(function (response) {

                    $scope.savedSuccessfully = true;
                    $scope.message = {
                        success: true,
                        description: "Registered successfully, you will be redicted to login page shortly"
                    };
                    startTimer();
            },
             function (response) {
                 var errors = [];
                 for (var key in response.data.modelState) {
                     for (var i = 0; i < response.data.modelState[key].length; i++) {
                         errors.push(response.data.modelState[key][i]);
                     }
                 }

                 $scope.message = {
                     success: false,
                     description: "Failed to register user : " + errors.join(' ')
                 };

             });
        };

        var startTimer = function () {
            var timer = $timeout(function () {
                $timeout.cancel(timer);
                $location.path('/Account/Login');
            }, 2000);
        }
    }
})();
