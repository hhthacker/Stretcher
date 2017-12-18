app.controller("newGoalController", ["$http", "$scope", "$location", function ($http, $scope, $location) {

    $scope.newGoal = {};
    $scope.opener = {};

    $http.get("api/stretches")
        .then(function (result) {
            $scope.opener = result.data;
        });

    $scope.CreateGoal = function () {
        let goal = $scope.goal;
        $http.post("/api/goals",
            {
                GoalName: goal.GoalName,
                GoalDescription: goal.GoalDescription,
                Intensity: goal.Intensity
            })
            .then(result => console.log(result))
            .catch(error => console.log(error));
    };
    
}]);