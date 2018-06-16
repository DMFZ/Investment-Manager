app.controller("MutualFundController", ["$scope", "$element", "$http",
    function ($scope, $element, $http) {
        $scope.allMutualfunds = {};
        $scope.newMutualFund = {};

        $scope.init = function () {
            $scope.GetAllMutualFunds();
        }

        $scope.MutualFundAdd = function () {
            $scope.newMutualFunds.mfName = '';
            $scope.newMutualFunds.mfavgNAV = '';
            $scope.newMutualFunds.mfCurrentNAV = '';
            $scope.newMutualFunds.mfQuantity = '';
            $('#MutualFundAddPopup').modal('toggle');
        }

        $scope.GetAllMutualFunds = function () {
            $http.get("http://localhost:3772/api/MutualFunds").then(function (AllMFsResponse) {
                $scope.allMutualfunds = AllMFsResponse.data;
            });
        };

        $scope.AddMutualFunds = function () {
            var data = {
                MutualFundName: $scope.newMutualFunds.mfName,
                InvestmentNAV: $scope.newMutualFunds.mfavgNAV,
                CurrentNAV: $scope.newMutualFunds.mfCurrentNAV,
                UnitsHeld: $scope.newMutualFunds.mfQuantity,
            };
            $http.post("http://localhost:3772/api/MutualFunds", data).then(function (addResponse) {
                var response = addResponse;
                $('#MutualFundAddPopup').modal('toggle');
                $scope.GetAllMutualFunds();
            });
        };

        $scope.Cancel = function () {
            $('#MutualFundAddPopup').modal('toggle');
        }




    }]);