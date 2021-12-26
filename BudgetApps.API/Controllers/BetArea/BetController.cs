using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Helpers;
using BudgetApps.API.Services.BetArea;

namespace BudgetApps.API.Controllers.BetArea
{
    [CustomAuthorize]
    [ApiController]
    [Route("[controller]")]
    public class BetController : Controller
    {
        private readonly BetService _betService;
        public BetController(BetService betService)
        {
            _betService = betService;
        }


        [HttpGet("all")]
        public IActionResult GetCases()
        {
            var response = _betService.GetBets();
            return Ok(response);
        }
    }
}
