using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Helpers;
using BudgetApps.API.Services.FopArea;

namespace BudgetApps.API.Controllers.FopArea
{
    [CustomAuthorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FopController : Controller
    {
        public readonly FopService _fopService;
        public FopController(FopService fopService)
        {
            _fopService = fopService;
        }

        [HttpGet("balance")]
        public IActionResult GetFopBalances()
        {
            var response = _fopService.GetFopBalances();
            return Ok(response);
        }
    }
}
