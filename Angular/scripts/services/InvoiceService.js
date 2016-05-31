//Service used for transfering invoices.
(function () {

    var app = angular.module("invoicer");

    app.factory("InvoiceService", function ($http, $rootScope, schConfig) {

        return {
            invoice: {},

            setInvoice : function(inv) {
                this.invoice = inv;
            },

            getInvoice: function () {
                return this.invoice;
            }

            
        };
        
    });
}());