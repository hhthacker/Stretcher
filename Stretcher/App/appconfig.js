app.config(["$routeProvider", function ($routeProvider) {
    $routeProvider
        .when("/home",
        {
            templateUrl: "/App/Views/home.html",
            controller: "homeController"
        })
        .when("/login",
        {
            templateUrl: "/App/Views/login.html",
            controller: "loginController"
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
        .when("/stretchgoal",
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

app.run(["$rootScope", "$http", "$location", function ($rootScope, $http, $location) {

    $rootScope.isLoggedIn = function () { return !!sessionStorage.getItem("token"); };

    $rootScope.$on("$routeChangeStart", function (event, currRoute) {
        var anonymousPage = false;
        var originalPath = currRoute.originalPath;

        if (originalPath) {
            anonymousPage = originalPath.indexOf("/login") !== -1;
        }

        if (!anonymousPage && !$rootScope.isLoggedIn()) {
            event.preventDefault();
            $location.path("/login");
        }
    });

    var token = sessionStorage.getItem("token");

    if (token)
        $http.defaults.headers.common["Authorization"] = `bearer ${token}`;
}]);