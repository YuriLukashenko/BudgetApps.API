using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Entities;
using BudgetApps.API.Helpers;
using BudgetApps.API.Services;

namespace BudgetApps.API.Controllers
{
    [CustomAuthorize]
    [ApiController]
    [Route("api/[controller]")]
    public class RateController : Controller
    {
        private readonly RateService _currentRateService;
        public RateController(RateService currentRateService)
        {
            _currentRateService = currentRateService;
        }

        [HttpGet("all")]
        public IActionResult GetCurrentRates()
        {
            var response = _currentRateService.GetCurrentRates();
            return Ok(response);
        }

        [HttpGet("by/{name}")]
        public IActionResult GetCurrentRateByName(string name)
        {
            var response = _currentRateService.GetRateByName(name);
            return Ok(response);
        }

        [HttpGet("last")]
        public IActionResult GetCurrentRatesLast()
        {
            var response = _currentRateService.GetLast();
            return Ok(response);
        }

        [HttpPost("add")]
        public IActionResult PostCurrentRates([FromBody] CurrentRate currentRate)
        {
            var response = _currentRateService.Add(currentRate);
            return Ok(response);
        }

    }
}
