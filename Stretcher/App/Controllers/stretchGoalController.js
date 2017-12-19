app.controller("stretchGoalController", ["$http", "$scope", function ($http, $scope) {

    $scope.stretches = {};

    $http.get("/api/stretches")
        .then(function (result) {
            $scope.stretches = result.data;
        });
}]);