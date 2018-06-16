app.controller("HomePageController", ["$scope", "$element", "$http",
    function ($scope, $element, $http) {
        $scope.allStocks = {};
        $scope.TotalAmountInvested = '';
        $scope.CurrentValueOfInvestments = '';
        $scope.OverallChange=''


        $scope.init = function () {
            $scope.GetAllStocks();
            $scope.GetAllMUtualFunds();
        }

        $scope.GetAllStocks = function () {
            $http.get("http://localhost:3772/api/HomePage").then(function (homePageResponse) {
                var response = homePageResponse;
                $scope.currentStockValue = homePageResponse.data.currentValueStocks;
                $scope.totalInvestmentValue = homePageResponse.data.amountInStocks;
                $scope.changeInValue = homePageResponse.data.changeStocks;
                $scope.profitLossStocks = homePageResponse.data.profitLossStocks;
            });
        };

        $scope.GetAllMUtualFunds = function () {
            $http.get("http://localhost:3772/api/HomePage/GetMutualFunds").then(function (homePageResponse) {
                var response = homePageResponse;
                $scope.currentFundsValue = homePageResponse.data.currentValueFunds;
                $scope.totalInvestmentValueFunds = homePageResponse.data.amountInFunds;
                $scope.changeInValueFunds = homePageResponse.data.changeFunds;
                $scope.profitLossFunds = homePageResponse.data.profitLossFunds;
            });
        };
    }]);