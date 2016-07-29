(function () {
    'use strict';

    angular
        .module('customerGreenApp')
        .controller('ContactFormModalController', ContactFormModalController);

    ContactFormModalController.$inject = ['$scope', '$modalInstance'];

    function ContactFormModalController($scope, $modalInstance) {

        $scope.ok = function () {
            $modalInstance.close($scope.contact);
        };

        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };
    }
})();