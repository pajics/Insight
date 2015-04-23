(function () {
    'use strict';

        angular
            .module('employeesServices', ['ngResource'])
            .factory('Employees', Employees);

        Employees.$inject = ['$resource', '$http'];

        function Employees($resource, $http) {
            var employeesServicesObj = {};
            //return $resource('/api/employees/:id');
            employeesServicesObj.getAll = function () {
                $http({
                    url: '/api/employees/',
                    method: 'GET',
                    params: []
                }).success(function (result) {
                    return result;
                }).error(function (err) {
                    console.log(err);
                });
            }

            return employeesServicesObj;
        }

    })();