(function () {
    'use strict';

    var employeesServices = angular.module('employeesServices', ['ngResource']);

    employeesServices.factory('Employees', ['$resource',
        function ($resource) {
            return $resource('/api/employees', {}, {
                query: { method: 'GET', params: {}, isArray: true }
            });
        }]);
})();