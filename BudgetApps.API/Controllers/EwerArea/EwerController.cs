using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Helpers;
using BudgetApps.API.Services.EwerArea;

namespace BudgetApps.API.Controllers.EwerArea
{
    [CustomAuthorize]
    [ApiController]
    [Route("[controller]")]
    public class EwerController : Controller
    {
        private readonly EwerService _ewerService;
        public EwerController(EwerService ewerService)
        {
            _ewerService = ewerService;
        }

        [HttpGet("all")]
        public IActionResult GetEwer()
        {
            var response = _ewerService.GetEwers();
            return Ok(response);
        }

        [HttpGet("credits")]
        public IActionResult GetEwerCredits()
        {
            var response = _ewerService.GetEwerCredits();
            return Ok(response);
        }

        [HttpGet("spends")]
        public IActionResult GetEwerSpends()
        {
            var response = _ewerService.GetEwerSpends();
            return Ok(response);
        }

        [HttpGet("currency/types")]
        public IActionResult GetEwerCurrencyTypes()
        {
            var response = _ewerService.GetEwerCurrencyTypes();
            return Ok(response);
        }
    }
}
