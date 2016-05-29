(function () {

    var app = angular.module("invoicer");

    app.controller("CustomerController", function ($scope, $rootScope, DataService) {

        var dataSet = "customer"; 
        $scope.selString = "";
        $scope.sortOrder = "";
        fetchData();

        function fetchData() {
            DataService.list(dataSet, function (data) {
                $scope.customers = data;
            });
        }

        $scope.transfer = function (item) {
            $scope.customer = item;
        };

        $scope.newCustomer = function () {
            $scope.customer = {
                id: 0,
                name: "",
                companyName: "",
                address: "",
                city: "",
                zip: "",
                phone: ""
            }
        };

        $scope.deleteData = function () {
            DataService.delete(dataSet, $scope.customer.id, function (data) { fetchData() });
        }

        $scope.saveData = function () {
            if ($scope.customer.id == 0) {
                DataService.create(dataSet, $scope.customer, function (data) { fetchData(); });
            }
            else {
                DataService.update(dataSet, $scope.customer.id, $scope.customer, function (data) { fetchData(); });
            }
        }        
    });
}());
