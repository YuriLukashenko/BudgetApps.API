using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Helpers;
using BudgetApps.API.Services.Flux;

namespace BudgetApps.API.Controllers.Flux
{
    [CustomAuthorize]
    [ApiController]
    [Route("[controller]")]
    public class FluxController : Controller
    {
        private readonly FluxService _fluxService;

        public FluxController(FluxService fluxService)
        {
            _fluxService = fluxService;
        }

        [HttpGet("current")]
        public IActionResult GetCurrent()
        {
            var response = _fluxService.GetFluxes();
            return Ok(response);
        }

        [HttpGet("history")]
        public IActionResult GetHistory()
        {
            var response = _fluxService.GetFluxHistories();
            return Ok(response);
        }

        [HttpGet("types")]
        public IActionResult GetTypes()
        {
            var response = _fluxService.GetFluxTypes();
            return Ok(response);
        }
    }
}
