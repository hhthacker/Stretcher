app.controller("allGoalsController", ["$http", "$scope", function ($http, $scope) {


    $scope.goals = {};

    $http.get("/api/goals")
        .then(function (result) {
            $scope.goals = result.data;
        });

}]);






