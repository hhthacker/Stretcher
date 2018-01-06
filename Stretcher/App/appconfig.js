app.config(["$routeProvider", function ($routeProvider) {
    $routeProvider
        .when("/home",
        {
            templateUrl: "/App/Views/home.html",
            controller: "homeController"
        })
        .when("/allgoals",
        {
            templateUrl: "/App/Views/allgoals.html",
            controller: "allGoalsController"
        })
        .when("/newgoal",
        {
            templateUrl: "/App/Views/newgoal.html",
            controller: "newGoalController"
        })
        .when("/stretchgoal/:goalId",
        {
            templateUrl: "App/Views/stretchgoal.html",
            controller: "stretchGoalController"
        })
        .when("/newreflection",
        {
            templateUrl: "App/Views/newreflection.html",
            controller: "newReflectionController"
        })
        .when("/allreflections",
        {
            templateUrl: "App/Views/allreflections.html",
            controller: "allReflectionsController"
        });
}]);