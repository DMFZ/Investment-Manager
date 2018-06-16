using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Manager.Services;
using Manager.API.Models;

namespace Manager.Controllers
{
    [Route("api/MutualFunds")]
    public class MutualFundsController : Controller
    {
        MutualFundService mfService = new MutualFundService();
        [HttpGet]
        public IActionResult GetAllMutualFunds()
        {
            var mutualFundsData = mfService.GetAllMutualFunds();
            return Ok(mutualFundsData);
        }

        [HttpPost]
        public IActionResult AddNewFunds([FromBody] MutualFund data)
        {
            var dataInsertResult = mfService.AddMfData(data);
            return Ok(dataInsertResult);
        }
    }
}