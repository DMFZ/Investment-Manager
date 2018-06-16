using Microsoft.AspNetCore.Mvc;
using Manager.Services;
using Manager.API.Models;
using System;

namespace Manager.Controllers
{
    [Route("api/HomePage")]
    public class HomePageController : Controller
    {
        StockService _stockService = new StockService();
        MutualFundService _fundService = new MutualFundService();

        [HttpGet]
        public IActionResult Get()
        {
            var currentValue = 0.0;
            var investedValue = 0.0;
            var change = 0.0;
            var homeResponse = new HomePageResponse();
            var stocksData = _stockService.GetAllStocksData();
            foreach(var data in stocksData)
            {
                currentValue = currentValue + data.currentInvestmentValue;
                investedValue = investedValue + data.totalInvestmentValue;
            }
            homeResponse.profitLossStocks = Math.Round(currentValue - investedValue,2);
            change = (homeResponse.profitLossStocks / currentValue) * 100;
            homeResponse.currentValueStocks = Math.Round(currentValue, 2);
            homeResponse.amountInStocks = Math.Round(investedValue,2);
            homeResponse.changeStocks = Math.Round(change, 2); ;
            return Ok(homeResponse);
        }


        [Route("GetMutualFunds")]
        [HttpGet]
        public IActionResult GetMutualFundDetails()
        {
            var currentValue = 0.0;
            var investedValue = 0.0;
            var change = 0.0;
            var homeResponse = new HomePageResponse();
            var stocksData = _fundService.GetAllMutualFunds();
            foreach (var data in stocksData)
            {
                currentValue = currentValue + data.CurrentInvestmentValue;
                investedValue = investedValue + data.TotalInvestmentValue;
            }
            homeResponse.profitLossFunds = Math.Round(currentValue - investedValue, 2);
            change = (homeResponse.profitLossFunds / currentValue) * 100;
            homeResponse.currentValueFunds = Math.Round(currentValue, 2);
            homeResponse.amountInFunds = Math.Round(investedValue, 2);
            homeResponse.changeFunds = Math.Round(change, 2); ;
            return Ok(homeResponse);
        }
    }
}