app.controller("newGoalController", ["$http", "$scope", "$location", function ($http, $scope, $location) {

    $scope.newGoal = {};
    $scope.opener = {};
    $scope.stretches = [];


    $http.get("api/stretches")
        .then(function (result) {
            $scope.opener = result.data;
            console.log("opener", $scope.opener);
        });

    $scope.CreateGoal = function () {


        for (let i = 0; i < $scope.opener.length; i++)
        {
            if ($scope.opener[i].StretchSelect == true)
            {
                $scope.stretches.push($scope.opener[i]);
                console.log($scope.stretches);
            };
        };


        let goal = $scope.goal;
        $http.post("/api/goals",
            {
                GoalName: goal.GoalName,
                GoalDescription: goal.GoalDescription,
                Intensity: goal.Intensity,
                Stretches: $scope.stretches
            })
            .then(result => console.log(result))
            .catch(error => console.log(error));
    };


    
}]);