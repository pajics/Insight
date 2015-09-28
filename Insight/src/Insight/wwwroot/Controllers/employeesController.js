(function () {
    'use strict';

    angular
        .module('insightApp')
        .controller('EmployeesController', EmployeesController);

    EmployeesController.$inject = ['$scope', 'Employees'];//$inject() method call is required to enable the EmployeesController to work with minification.  http://stephenwalther.com/archive/2015/01/13/asp-net-5-and-angularjs-part-2-using-the-mvc-6-web-api 

    function EmployeesController($scope, Employees) {
        $scope.title = 'Employees overview';
        //$scope.employees = Employees.query
        $scope.employees = [
                    { firstName: 'Srdjan', lastName: 'Pajic', role: 'Software developer', profileImageUrl: 'web/images/img2.jpg' },
                    { firstName: 'Jelena', lastName: 'Stankov', role: 'Software developer', profileImageUrl: 'web/images/img1.jpg' },
        ];
    }
})();
