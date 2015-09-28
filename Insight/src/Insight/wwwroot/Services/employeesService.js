(function () {
    'use strict';

//    var employeesServices = angular.module('employeesServices');

//    //employeesServices.factory('Employees', ['',
//    //    function () {
//    //        return {
//    //            employees: [
//    //                { firstName: 'Srdjan', lastName: 'Pajic', role: 'Software developer' },
//    //                { firstName: 'Jelena', lastName: 'Stankov', role: 'Software developer' },
//    //            ]
//    //        };
//    //    }]);
        angular
            .module('employeesServices', ['ngResource'])
            .factory('Employees', Employees);

        Employees.$inject = ['$resource'];

        function Employees($resource) {
            return $resource('/api/employees/:id');
        }

    })();