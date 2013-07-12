var app = angular.module('myApp', []);
app.controller('MyCtrl', function ($scope) {
    function init() {
        $scope.employees = [{
            Id: 1,
            Name: "Admin Admin"
        },
        {
            Id: 2,
            Name: "Guest Guest"
        },
        {
            Id: 3,
            Name: "Joe Brown"
        }]
    }

    init();

    $scope.add = function () {
        $scope.$broadcast('openAddEmployee');
    };

    $scope.edit = function () {
        $scope.$broadcast('openEditEmployee');
    };

    $scope.$on('editedEmpoloyee', function () {
        $scope.edited = true;
    });

    $scope.$on('addedEmpoloyee', function () {
        $scope.added = true;
    });
});

app.controller('addCtrl', function ($scope) {
    $scope.$on('openAddEmployee', function () {
        angular.element("#addEmployees").modal("show");
    });

    $scope.submit = function () {
        $scope.$emit('addedEmpoloyee');
        angular.element("#addEmployees").modal("hide");
    };
});

app.controller('editCtrl', function ($scope) {
    $scope.$on('openEditEmployee', function (scope, id) {
        $scope.employee = { Id: id };
        angular.element("#editEmployees").modal("show");
    });

    $scope.submit = function () {
        $scope.$emit('editedEmpoloyee');
        angular.element("#editEmployees").modal("hide");
    };
});