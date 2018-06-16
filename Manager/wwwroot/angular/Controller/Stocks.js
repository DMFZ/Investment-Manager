app.controller("StocksController", ["$scope", "$element", "$http",
    function ($scope, $element, $http) {
        $scope.newStock = {};
        $scope.allStocks = {};
        $scope.editStockData = {};
        $scope.sumOfStocksWithProfit = '';
        $scope.sumOfStocksWithLoss = '';
        $scope.sumOfStocksWithProfitSold = 'NA';
        $scope.sumOfStocksWithLossSold = 'NA';
        $scope.sellShare = false;

        $scope.Cancel = function () {
            $('#stockAddPopUp').modal('toggle');
        };

        $scope.init = function () {
            $scope.GetAllStocks();
            $scope.GetStocksRelatedData();
        }

        $scope.ShowStockAddPopUp = function () {
            $scope.newStock.stockName = '';
            $scope.newStock.avgPrice = '';
            $scope.newStock.change = '';
            $scope.newStock.currentInvestmentValue = '';
            $scope.newStock.currentSharePrice = '';
            $scope.newStock.date = '';
            $scope.newStock.quantity = '';
            $scope.newStock.sector = '';
            $scope.newStock.totalInvestmentValue = '';
            $scope.sellShare = false;
            $('#stockAddPopUp').modal('toggle');
        };

        $scope.UpdateStock = function (data) {
            var editStockData = data;
            $scope.editStockData = data;
            $('#stockUpdatePopUp').modal('toggle');
        };

        $scope.UpdateStockData = function () {
            var data = {
                stockName: $scope.editStockData.stockName,
                avgPrice: $scope.editStockData.avgPrice,
                currentSharePrice: $scope.editStockData.currentSharePrice,
                date: $scope.editStockData.date,
                quantity: $scope.editStockData.quantity,
                sector: $scope.editStockData.sector
            };
            $http.put("http://localhost:3772/api/AddNewStock", data).then(function (addResponse) {
                var response = addResponse;
                $scope.GetAllStocks();
            });
            $('#stockUpdatePopUp').modal('toggle');
        };

        $scope.GetStocksRelatedData = function () {
            $http.get("http://localhost:3772/api/AddNewStock/GetDetails").then(function (stockDetailsData) {
                var response = stockDetailsData.data;
                $scope.sumOfStocksWithProfit = response.totalProfitOnStocks;
                $scope.sumOfStocksWithLoss = response.totalLossOnStocks;
            });
        };


        $scope.AddStock = function () {
            var data = {
                stockName: $scope.newStock.stockName,
                avgPrice: $scope.newStock.avgPrice,
                currentSharePrice: $scope.newStock.currentSharePrice,
                quantity: $scope.newStock.quantity,
                sector: $scope.newStock.sector
            };
            $http.post("http://localhost:3772/api/AddNewStock", data).then(function (addResponse) {
                var response = addResponse;
                $('#stockAddPopUp').modal('toggle');
                $scope.GetAllStocks();
            });

        };

        $scope.loadFile = function (files) {
            $scope.selectedFile = files[0];
        }

        $scope.ProcessTransactions = function () {
            $http.post("http://localhost:3772/api/AddNewStock/ProcessImport").then(function (fileImportResponse) {
                var response = fileImportResponse.data;
                if (response !== undefined && response) {
                    $scope.success = true;
                    $scope.listOfUpdatedStocks = response;
                    $scope.init();
                }
            });
        }


        $scope.GetAllStocks = function () {
            $http.get("http://localhost:3772/api/AddNewStock").then(function (AllStocksResponse) {
                var response = AllStocksResponse;
                $scope.allStocks = AllStocksResponse.data;
            });
        };

        $scope.SellStock = function () {
            $scope.sellShare = true;
            $scope.updateSellingStatus();
        };

        $scope.updateSellingStatus = function () {
            var data = {
                stockName: $scope.editStockData.stockName,
                avgPrice: $scope.editStockData.avgPrice,
                currentSharePrice: $scope.editStockData.currentSharePrice,
                date: $scope.editStockData.date,
                quantity: $scope.editStockData.quantity,
                sector: $scope.editStockData.sector
            };
            $http.post("http://localhost:3772/api/AddNewStock/SellStock", data).then(function (sellResponse) {
            });
        }
        $scope.init();
    }]);