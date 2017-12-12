app.controller("newGoalController", ["$http", "$scope", "$location", function ($http, $scope, $location) {

    $scope.newGoal = {};
  
    $scope.AddStretches = function () {
        $scope.addStretches = false;
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

    $scope.stretchOverview = function () {
        $scope.stretchgoal = "blah blah blah";

        //$scope.post in stretch goals join table
        //$location.goooo to overview of stretch sequence
    };
}]);