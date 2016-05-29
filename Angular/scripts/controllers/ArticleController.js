(function () {

    var app = angular.module("invoicer");

    app.controller("ArticleController", function ($scope, $rootScope, DataService) {

        var dataSet = "article";
        $scope.selString = "";
        $scope.sortOrder = "";
        fetchData();

        function fetchData() {
            DataService.list(dataSet, function (data) {
                $scope.articles = data;
            });
        }

        $scope.transfer = function (item) {
            $scope.article = item;
        };

        $scope.newArticle = function () {
            $scope.article = {
                id: 0,
                name: "",
                price: 0,
                inStock: 0
            }
        };

        $scope.deleteData = function () {
            DataService.delete(dataSet, $scope.article.id, function (data) { fetchData() });
        }

        $scope.saveData = function () {
            if ($scope.article.id == 0) {
                DataService.create(dataSet, $scope.article, function (data) { fetchData(); });
            }
            else {
                DataService.update(dataSet, $scope.article.id, $scope.article, function (data) { fetchData(); });
            }
        }
    });
}());
