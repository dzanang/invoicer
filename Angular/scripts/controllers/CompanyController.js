(function () {

    var app = angular.module("invoicer");

    app.controller("CompanyController", function ($scope, $rootScope, DataService) {

        var dataSet = "company";
        $scope.selString = "";
        $scope.sortOrder = "";
        fetchData();

        function fetchData() {
            DataService.list(dataSet, function (data) {
                $scope.companies = data;
            });
        }

        $scope.transfer = function (item) {
            $scope.company = item;
        };

        $scope.newCompany = function () {
            $scope.company = {
                id: 0,
                name: "",
                address: "",
                city: "",
                zip: "",
                phone: ""
            }
        };

        $scope.deleteData = function () {
            DataService.delete(dataSet, $scope.company.id, function (data) { fetchData() });
        }

        $scope.saveData = function () {
            if ($scope.company.id == 0) {
                DataService.create(dataSet, $scope.company, function (data) { fetchData(); });
            }
            else {
                DataService.update(dataSet, $scope.company.id, $scope.company, function (data) { fetchData(); });
            }
        }
    });
}());
