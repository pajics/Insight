'use strict';

angular
    .module('insightApp', ['ngResource'])
    .factory('Employees', Employees);

function Employees($resource, $http) {

    var employeesServicesObj = {};
    //return $resource('/api/employees/:id');
    employeesServicesObj.getAll = function () {
        return [{ firstName: 'test' }];
        //$http({
        //    url: '/api/employees/',
        //    method: 'GET',
        //    params: []
        //}).success(function (result) {
        //    return result;
        //}).error(function (err) {
        //    console.log(err);
        //});
    }

    return employeesServicesObj;
}