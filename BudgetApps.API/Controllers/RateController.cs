using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

    }
}
