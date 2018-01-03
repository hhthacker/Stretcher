app.controller("newGoalController", ["$http", "$scope", "$location", function ($http, $scope, $location) {

    $scope.newGoal = {};
    $scope.opener = {};
    $scope.stretches = [];
    

    $http.get("api/stretches")
        .then(function (result) {
            $scope.opener = result.data;
            console.log("opener", $scope.opener);
        });

    addRemoveStretch = function () {
       let stretchesArray = new Array;
        forEach(stretchesArray, function (stretches) {
            if (open.selected) {
                stretchesArray.push(open.StretchId);
            }
        })
        $scope.stretches = stretchesArray;
    };

    $scope.CreateGoal = function () {

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