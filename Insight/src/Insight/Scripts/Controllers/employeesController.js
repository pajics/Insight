(function () {
    'use strict';

    angular
        .module('app')
        .controller('employeesController', employeesController);

    employeesController.$inject = ['$scope', 'Employees'];//$inject() method call is required to enable the employeesController to work with minification.  http://stephenwalther.com/archive/2015/01/13/asp-net-5-and-angularjs-part-2-using-the-mvc-6-web-api 

    function employeesController($scope, Employees) {
        $scope.title = 'employees overview';
        $scope.employess = Employees.query();
    }
})();
