'use strict';

angular
    .module('insightApp', ['ngResource'])
    .factory('Employees', Employees);

function Employees($resource, $http) {

    var employeesServicesObj = {};
    var employees = $resource('/api/employees/:id');
    employeesServicesObj.getAll = function () {
        return employees.query().$promise;
    }

    return employeesServicesObj;
}