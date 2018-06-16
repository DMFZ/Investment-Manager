using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Manager.API_Controllers.Models;
using System.Net.Http;
using Manager.Services;

namespace Manager.Controllers
{
    [Route("api/AddNewStock")]
    public class AddNewStockController : Controller
    {
        StockService _stockService = new StockService();
        [HttpPost]
        public IActionResult AddNewStock([FromBody] Stock data)
        {
            var dataInsertResult = _stockService.AddNewStock(data);
            return Ok(dataInsertResult);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var stocksData = _stockService.GetAllStocksData();
            return Ok(stocksData);
        }

        [Route("GetDetails")]
        [HttpGet]
        public IActionResult GetDetails()
        {
            var stocksData = _stockService.GetStocksRelatedData();
            return Ok(stocksData);
        }

        [HttpPut]
        public IActionResult UpdateStock([FromBody] Stock data)
        {
            var updateStockResult= _stockService.UpdateStock(data);
            return Ok();
        }

        [Route("ProcessImport")]
        [HttpPost]
        public IActionResult ProcessFileIMport()
        {
            string list = "";
            var importFile = _stockService.ProcessFileImport(out list);
            return Ok(list);
        }

        [Route("SellStock")]
        [HttpPost]
        public IActionResult SellStock([FromBody] Stock data)
        {
            var sellStockResponse = _stockService.SellStock(data);
            return Ok(sellStockResponse);
        }
    }
}