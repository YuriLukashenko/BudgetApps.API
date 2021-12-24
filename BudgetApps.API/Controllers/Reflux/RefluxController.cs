using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Helpers;
using BudgetApps.API.Services.Flux;
using Microsoft.AspNetCore.Mvc;

namespace BudgetApps.API.Controllers.Flux
{
    [CustomAuthorize]
    [ApiController]
    [Route("[controller]")]
    public class RefluxController : Controller
    {
        private readonly RefluxService _refluxService;

        public RefluxController(RefluxService refluxService)
        {
            _refluxService = refluxService;
        }

        [HttpGet("current")]
        public IActionResult GetCurrent()
        {
            var response = _refluxService.GetRefluxes();
            return Ok(response);
        }

        [HttpGet("history")]
        public IActionResult GetHistory()
        {
            var response = _refluxService.GetRefluxHistories();
            return Ok(response);
        }

        [HttpGet("types")]
        public IActionResult GetTypes()
        {
            var response = _refluxService.GetRefluxTypes();
            return Ok(response);
        }
    }
}
