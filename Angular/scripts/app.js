(function () {

    var app = angular.module("invoicer", ["ngRoute"]);

    app.constant("schConfig",
        {
            source: "http://localhost:64250/api/",
        });

    app.config(function ($routeProvider) {

        $routeProvider
            .when("/customer", { templateUrl: "views/customer.html", controller: "CustomerController" })
            .when("/article", { templateUrl: "views/article.html", controller: "ArticleController" })
            .when("/invoice", { templateUrl: "views/invoice.html", controller: "InvoiceController" })
            .otherwise({ redirectTo: "/customer" });
    });

}());