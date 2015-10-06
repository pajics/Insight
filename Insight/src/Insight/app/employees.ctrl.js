'use strict';

angular
    .module('insightApp')
    .controller('EmployeesCtrl', EmployeesCtrl);

function EmployeesCtrl($scope, Employees) {
    $scope.title = 'Employees overview';
    function setWookmark() {//hack
        var $tiles = $('#tiles'),
            $handler = $('li', $tiles),
            $main = $('#main'),
            $window = $(window),
            $document = $(document),
            options = {
                autoResize: true, // This will auto-update the layout when the browser window is resized.
                container: $main, // Optional, used for some extra CSS styling
                offset: 20, // Optional, the distance between grid items
                itemWidth: 280 // Optional, the width of a grid item
            };
        if ($handler.wookmarkInstance) {
            $handler.wookmarkInstance.clear();
        }

        // Create a new layout handler.
        $handler = $('li', $tiles);
        $handler.wookmark(options);
    }

    Employees.getAll().then(function(em) {
        $scope.employees = em;

        setTimeout(setWookmark, 50);
    });
    //[{ "id": 0, "firstName": "Srdjan", "lastName": "Pajic", "displayName": "Srdjan Pajic", "profileImageUrl": "img2.jpg", "role": "Software Developer", "skills": [{ "id": 0, "name": "C#" }, { "id": 0, "name": "MVC" }, { "id": 0, "name": "Azure" }, { "id": 0, "name": "AngularJS" }], "Additionalroles": [], "Gender": 0 }, { "id": 0, "firstName": "Carlos", "lastName": "Pascual", "displayName": "Carlos Pascual", "profileImageUrl": "img2.jpg", "role": "Software Developer", "skills": [{ "id": 0, "name": "C#" }, { "id": 0, "name": "MVC" }, { "id": 0, "name": "Azure" }, { "id": 0, "name": "AngularJS" }], "Additionalroles": [], "Gender": 0 }, { "id": 0, "firstName": "Janko", "lastName": "Medjugorac", "displayName": "Janko Medjugorac", "profileImageUrl": "img2.jpg", "role": "Software Developer", "skills": [{ "id": 0, "name": "C#" }, { "id": 0, "name": "MVC" }, { "id": 0, "name": "Azure" }, { "id": 0, "name": "AngularJS" }], "Additionalroles": [], "Gender": 0 }, { "id": 0, "firstName": "Dmitry", "lastName": "Popov", "displayName": "Dmitry Popov", "profileImageUrl": "img2.jpg", "role": "Software Developer", "skills": [{ "id": 0, "name": "C#" }, { "id": 0, "name": "MVC" }, { "id": 0, "name": "Azure" }, { "id": 0, "name": "AngularJS" }], "Additionalroles": [], "Gender": 0 }, { "id": 0, "firstName": "Georg", "lastName": "Pfeiffer", "displayName": "Georg Pfeiffer", "profileImageUrl": "img2.jpg", "role": "Software Developer", "skills": [{ "id": 0, "name": "C#" }, { "id": 0, "name": "MVC" }, { "id": 0, "name": "Azure" }, { "id": 0, "name": "AngularJS" }], "Additionalroles": [], "Gender": 0 }, { "id": 0, "firstName": "Josef", "lastName": "Heidegger", "displayName": "Josef Heidegger", "profileImageUrl": "img2.jpg", "role": "Software Developer", "skills": [{ "id": 0, "name": "C#" }, { "id": 0, "name": "MVC" }, { "id": 0, "name": "Azure" }, { "id": 0, "name": "AngularJS" }], "Additionalroles": [], "Gender": 0 }, { "id": 0, "firstName": "Erika", "lastName": "Kuskova", "displayName": "Erika Kuskova", "profileImageUrl": "img3.jpg", "role": "Software Developer", "skills": [{ "id": 0, "name": "C#" }, { "id": 0, "name": "MVC" }, { "id": 0, "name": "Azure" }, { "id": 0, "name": "AngularJS" }], "Additionalroles": [], "Gender": 0 }, { "id": 0, "firstName": "Jelena", "lastName": "Stankov", "displayName": "Jelena Stankov", "profileImageUrl": "img1.jpg", "role": "Software Developer", "skills": [{ "id": 0, "name": "C#" }, { "id": 0, "name": "MVC" }, { "id": 0, "name": "Azure" }, { "id": 0, "name": "AngularJS" }], "Additionalroles": [], "Gender": 0 }, { "id": 0, "firstName": "Michael Riedel", "lastName": null, "displayName": "Michael Riedel ", "profileImageUrl": null, "role": "PM", "skills": [], "Additionalroles": [], "Gender": 0 }, { "id": 0, "firstName": "Marc Rathai", "lastName": null, "displayName": "Marc Rathai ", "profileImageUrl": null, "role": "PM", "skills": [], "Additionalroles": [], "Gender": 0 }];
}
