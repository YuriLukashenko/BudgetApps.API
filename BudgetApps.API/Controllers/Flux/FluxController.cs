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

        [HttpGet]
        public IActionResult Index()
        {
            var response = _fluxService.GetFlux2021();
            return Ok(response);
        }
    }
}
