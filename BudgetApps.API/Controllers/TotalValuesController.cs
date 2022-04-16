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
    public class TotalValuesController : Controller
    {
        private readonly TotalValuesService _totalValuesService;
        public TotalValuesController(TotalValuesService totalValuesService)
        {
            _totalValuesService = totalValuesService;
        }

        [HttpGet("all")]
        public IActionResult GetCurrentCash()
        {
            var response = _totalValuesService.GetTotalUah();
            return Ok(response);
        }
    }
}
