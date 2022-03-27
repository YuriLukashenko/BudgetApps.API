using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Helpers;
using BudgetApps.API.Services.DepositArea;

namespace BudgetApps.API.Controllers.DepositArea
{
    [CustomAuthorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DepositController : Controller
    {
        private readonly DepositService _depositService;

        public DepositController(DepositService depositService)
        {
            _depositService = depositService;
        }

        [HttpGet("all")]
        public IActionResult GetDeposits()
        {
            var response = _depositService.GetDeposits();
            return Ok(response);
        }
    }
}
