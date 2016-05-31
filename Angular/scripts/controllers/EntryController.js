(function () {

    var app = angular.module("invoicer");

    app.controller("EntryController", function ($scope, $rootScope, DataService, InvoiceService) {
        $scope.invoice = InvoiceService.getInvoice();
    });
}());