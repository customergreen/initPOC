(function () {
    angular
        .module('customerGreenApp')
        .factory('registerFactory', ['$http', function ($http) {
            var getCountry = function () {
                return $http.get('Country').then(function (d) { // Country Details api to be created 
                    return d.data;
                })
            }
            var getB1 = function () {
                return $http.get('api/businessSubTypes/GetBusinessSubTypes').then(function (d) { // Business Type 1 along with type2 Details api to be created 
                    return d.data;
                })
            }            
            var getPlan = function () {
                return $http.get('plan').then(function (d) { // Plan selection Details api to be created 
                    return d.data;
                })
            }
            var getRev = function () {
                return $http.get('Rev').then(function (d) { // Revenue details api to be created 
                    return d.data;
                })
            }
            var factory = {
                country: getCountry,
                b1: getB1,
                plan: getPlan,
                rev: getRev    
            }
            return factory;
    }])
})();
