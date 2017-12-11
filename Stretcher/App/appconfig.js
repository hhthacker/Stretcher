app.config(["$routeProvider", function ($routeProvider) {
    $routeProvider
        .when("/home",
        {
            templateUrl: "/App/Views/home.html",
            controller: "homeController"
        });
}]);