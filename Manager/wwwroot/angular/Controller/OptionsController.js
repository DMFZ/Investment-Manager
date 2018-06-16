app.controller("OptionsController", ["$scope", "$element", "$http",
    function ($scope, $element, $http) {
        $scope.AllOptions = {};
        $scope.newoption = {};


        $scope.init = function () {
            $scope.GetAllOptions();
        }

        $scope.ShowOptionAddPopup = function () {
            $scope.newoption.optionName = '';
            $scope.newoption.avgPrice = '';
            $scope.newoption.change = '';
            $scope.newoption.currentInvestmentValue = '';
            $scope.newoption.currentoptionPrice = '';
            $scope.newoption.quantity = '';
            $scope.newoption.totalInvestmentValue = '';
            $('#optionAddPopup').modal('toggle');
        };

        $scope.GetAllOptions = function () {
            $http.get("http://localhost:3772/api/api/OptionsPage").then(function (allOptionsResponse) {
                $scope.AllOptions = allOptionsResponse.data;
            });
        }

        $scope.AddOption = function () {
            var data = {
                optionName: $scope.newoption.optionName,
                avgPrice: $scope.newoption.avgPrice,
                currentOptionPrice: $scope.newoption.currentoptionPrice,
                quantity: $scope.newoption.quantity
            };
            $http.post("http://localhost:3772/api/api/OptionsPage",data).then(function (allOptionsResponse) {
                $scope.AllOptions = allOptionsResponse.data;
            });
        }

        $scope.SellOption = function () {
            var data = {
                optionName: $scope.editoption.optionName,
                avgPrice: $scope.editoption.avgPrice,
                currentOptionPrice: $scope.editoption.currentoptionPrice,
                quantity: $scope.editoption.quantity
            };
            $http.post("http://localhost:3772/api/api/OptionsPage/SellOption", data).then(function (allOptionsResponse) {
                $scope.AllOptions = allOptionsResponse.data;
            });
        }

    }
]);