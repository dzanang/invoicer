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

        function getArticles() {
            DataService.list(articlesDataSet, function (data) {
                $scope.articles = data;
                console.log($scope.articles);
            });
        }

        function getCustomers() {
            DataService.list(customersDataSet, function (data) {
                $scope.customers = data;
            });
        }

        $scope.transfer = function (item) {
            $scope.invoice = item;
            //this.invoice = item;
            //$scope.bucket = {};
            //$scope.bucket.invoice = item;
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
            for (var i = 0; i < $scope.articles.length; i++)
            {
                if (item.article == $scope.articles[i].id) {
                    item.name = $scope.articles[i].name;
                    item.price = item.quantity * $scope.articles[i].price;
                    
                }
            }
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
            //$scope.newInvoiceObject = {};
            //$scope.newInvoiceObject.entries = [];
        }

        $scope.newInvoice = function () {
        }

        $scope.deleteData = function (id) {
            DataService.delete(dataSet, id, function (data) { fetchData() });
        }
    });
}());
