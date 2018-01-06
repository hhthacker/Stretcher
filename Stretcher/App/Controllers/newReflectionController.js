app.controller("newReflectionController", ["$http", "$scope", "$routeParams", "$location", function ($http, $scope, $routeParams, $location) {

   // let reflectionGoal = $routeParams.goalId;

    $scope.PostReflection = function () {
    let reflection = $scope.reflection;

        $http.post("/api/reflections",
            {
                ReflectionTitle: reflection.ReflectionTitle,
                ReflectionNotes: reflection.ReflectionNotes,
                //Goals: reflectionGoal

            })
            .then(results => console.log(results))
            .catch(error => console.log(error));
    };
   
}]);