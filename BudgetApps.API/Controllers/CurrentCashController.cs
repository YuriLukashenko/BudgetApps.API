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
    public class CurrentCashController : Controller
    {
        private readonly CurrentCashService _currentCashService;
        public CurrentCashController(CurrentCashService currentCashService)
        {
            _currentCashService = currentCashService;
        }

        [HttpGet("all")]
        public IActionResult GetCurrentCash()
        {
            var response = _currentCashService.GetCurrentCash();
            return Ok(response);
        }
    }
}
