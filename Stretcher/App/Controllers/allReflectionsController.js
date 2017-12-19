app.controller("allReflectionsController", ["$http", "$scope", function ($http, $scope) {

    $scope.reflections = {};

    $http.get("/api/reflections")
        .then(function (result) {
            $scope.reflections = result.data;
        });

}]);