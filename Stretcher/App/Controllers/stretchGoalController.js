app.controller("stretchGoalController", ["$http", "$scope", "$routeParams", function ($http, $scope, $routeParams) {

    $scope.stretches = {};

    var goalid = $routeParams.goalId;

    $http.get(`/api/goals/${goalid}`)
            .then(function (result) {
                
                $scope.stretches = result.data;
                console.log("stretchgoal", $scope.stretches);
            });
}]);