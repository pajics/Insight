    'use strict';

    angular
        .module('insightApp')
        .controller('EmployeesCtrl', EmployeesCtrl);

    function EmployeesCtrl($scope, Employees) {
        $scope.title = 'Employees overview';
        $scope.employees = Employees.getAll();
    }
