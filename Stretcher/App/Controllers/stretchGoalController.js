app.controller("stretchGoalController", ["$http", "$scope", "$routeParams", "$location", function ($http, $scope, $routeParams, $location) {

    $scope.stretches = {};

    var goalid = $routeParams.goalId;

    $http.get(`/api/goals/${goalid}`)
            .then(function (result) {
                
                $scope.stretches = result.data;
                console.log("stretchgoal", $scope.stretches);
        });

    $scope.addReflection = function () {
        $location.url("/newreflection");

    };
}]);