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
    [Produces("application/json")]
    [Route("api/OptionsPage")]
    public class OptionsPageController : Controller
    {
        OptionService _optionService = new OptionService();
        [HttpGet]
        public IActionResult GetAllOptions()
        {
            var response = _optionService.GetAllOptions();
            return Ok();
        }


        [HttpPost]
        public IActionResult AddNewOptionTransaction([FromBody] Option option)
        {
            var response = _optionService.AddNewOptionTransaction(option);
            return Ok(response);
        }

        [Route("SellOption")]
        [HttpPost]
        public IActionResult SellSelectedOption([FromBody] Option option)
        {
            var response = _optionService.SellOption(option);
            return Ok(response);
        }

    }
}