    'use strict';

    angular
        .module('insightApp')
        .controller('EmployeesController', EmployeesController);

    function EmployeesController($scope, Employees) {
        $scope.title = 'Employees overview';
        $scope.employees = Employees.getAll();
    }
