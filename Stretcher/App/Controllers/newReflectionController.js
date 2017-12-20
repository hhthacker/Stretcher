app.controller("newReflectionController", ["$http", "$scope", "$location", function ($http, $scope, $location) {

    $scope.CreateReflection = function () {
        let reflection = $scope.reflection;
        $http.post("/api/reflections",
            {
                ReflectionTitle: reflection.ReflectionTitle,
                ReflectionNotes: reflection.ReflectionNotes
            })
            .then(result => console.log(result))
            .catch(error => console.log(error));
    };
}]);