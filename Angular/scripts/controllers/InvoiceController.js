(function () {

    var app = angular.module("invoicer");

    app.controller("InvoiceController", function ($scope, $rootScope, DataService) {

        var dataSet = "invoice";
        var articlesDataSet = "article";
        var customersDataSet = "customer";
        $scope.selString = "";
        $scope.sortOrder = "";
        fetchData();
        getArticles();
        getCustomers();

        function fetchData() {
            DataService.list(dataSet, function (data) {
                $scope.invoices = data;
            });
        }

        function fetchById() {
            DataService.read(dataSet, invoice.id, function (data) {
                $scope.invoice = data;
            });
        }

        function getArticles() {
            DataService.list(articlesDataSet, function (data) {
                $scope.articles = data;
            });
        }

        function getCustomers() {
            DataService.list(customersDataSet, function (data) {
                $scope.customers = data;
            });
        }

        $scope.transfer = function (item) {
            $scope.invoice = item;
        };

        $scope.newInvoice = function () {
            $scope.invoice = {
                id: 0,
                billCustomerId: "",
                shipCustomerId: "",
                date: new Date(),
                other: 0,
                status: 0,
            };

            $scope.invoiceStatus = {
                "1": "Draft",
                "2": "Issued",
                "3": "Payed",
                "4": "Canceled"                
            };

            $scope.addItem = function () {
                $scope.newInvoice.entries.push({
                    Article: 0,
                    Quantity: 0,
                    Price: 0.0
                });
            }

            $scope.deleteData = function () {
                DataService.delete(dataSet, $scope.invoice.id, function (data) { fetchData() });
            }

            $scope.saveData = function () {
                if ($scope.invoice.id == 0) {
                    DataService.create(dataSet, $scope.invoice, function (data) { fetchData(); });
                }
                else {
                    DataService.update(dataSet, $scope.invoice.id, $scope.invoice, function (data) { fetchData(); });
                }
            }
        }
    });
}());
