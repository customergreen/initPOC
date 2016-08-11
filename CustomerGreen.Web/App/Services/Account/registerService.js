(function () {
    angular
        .module('customerGreenApp')
        .factory('registerFactory', ['$http', function ($http) {
            var getDetails = function () {
                return $http.get('api/RegistrationDetails/Get').then(function (d) { // Country Details api to be created 
                    return d.data;
                })
            }
            //var getState = function (s) {
            //    return $http.get('state' + s).then(function (d) { // Country respective state Details api to be created 
            //        return d.data;
            //    })
            //}
            //var registerOrg = function (d) {
            //    return $http.post('api/businessSubTypes/GetBusinessSubTypes',d).then(function (d) { // Business Type 1 along with type2 Details api to be created 
            //        return d.data;
            //    })
            //}                       
            var factory = {
                details: getDetails,
               // register : registerOrg
   
            }
            return factory;
        }])    
})();
