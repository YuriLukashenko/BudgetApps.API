using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Helpers;
using BudgetApps.API.Services.CreditArea;

namespace BudgetApps.API.Controllers.CreditArea
{
    [CustomAuthorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CreditController : Controller
    {
        private readonly CreditService _creditService;
        public CreditController(CreditService creditService)
        {
            _creditService = creditService;
        }

        [HttpGet("all")]
        public IActionResult GetCredits()
        {
            var response = _creditService.GetCredits();
            return Ok(response);
        }
    }
}
