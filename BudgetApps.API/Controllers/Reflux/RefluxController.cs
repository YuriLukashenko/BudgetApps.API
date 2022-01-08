using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Helpers;
using BudgetApps.API.Services.RefluxArea;
using Microsoft.AspNetCore.Mvc;

namespace BudgetApps.API.Controllers.Flux
{
    [CustomAuthorize]
    [ApiController]
    [Route("api/[controller]")]
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

        [HttpGet("month/spend")]
        public IActionResult GetFluxMonthProfit()
        {
            var response = _refluxService.GetRefluxesMonth();
            return Ok(response);
        }

        [HttpGet("categories")]
        public IActionResult GetRefluxByCaterogies()
        {
            var response = _refluxService.GetRefluxByCaterogies();
            return Ok(response);
        }

        [HttpGet("categories/{year}")]
        public IActionResult GetRefluxByCaterogiesByYear(int year)
        {
            var response = _refluxService.GetRefluxByCategoriesByYear(year);
            return Ok(response);
        }

        [HttpGet("categories/years")]
        public IActionResult GetRefluxByCaterogiesByYears()
        {
            var response = _refluxService.GetRefluxByCategoriesByYears();
            return Ok(response);
        }
    }
}
