app.controller("stretchGoalController", ["$http", "$scope", function ($http, $scope) {

    $scope.stretches = {};

    $http.get("/api/stretches/goal/{goalid}")
        .then(function (result) {
            $scope.stretches = result.data;
            console.log("data", result.data)
        });
}]);