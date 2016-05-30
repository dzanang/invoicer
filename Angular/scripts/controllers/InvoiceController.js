(function () {

    var app = angular.module("invoicer");

    app.controller("InvoiceController", function ($scope, $rootScope, DataService) {
        var dataSet = "invoice";
        var articlesDataSet = "article";
        var customersDataSet = "customer";

        $scope.newInvoiceObject = {};
        $scope.newInvoiceObject.entries = [];
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

        $scope.invoiceStatus = {
            "1": "Draft",
            "2": "Issued",
            "3": "Payed",
            "4": "Canceled"
        };

        $scope.addInvoiceItem = function () {
            var item = {};
            item.quantity = $scope.newEntryProductQuantity;
            item.article = $scope.newEntryProductId;
            $scope.newInvoiceObject.entries.push(item);
        }

        $scope.saveData = function () {
            if (!$scope.newInvoiceObject.id) {
                DataService.create(dataSet, $scope.newInvoiceObject, function (data) {
                    $scope.invoices.push(data);
                });
            }
            else {
                DataService.update(dataSet, $scope.newInvoiceObject.id, $scope.newInvoiceObject, function (data) { fetchData(); });
            }
            // Reset state`
            $scope.newInvoiceObject = {};
            $scope.newInvoiceObject.entries = [];
        }

        $scope.newInvoice = function () {
        }

        $scope.deleteData = function () {
            DataService.delete(dataSet, $scope.invoice.id, function (data) { fetchData() });
        }
    });
}());
