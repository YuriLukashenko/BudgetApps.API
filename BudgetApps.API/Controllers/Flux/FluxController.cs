using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Helpers;
using BudgetApps.API.Services.FluxArea;

namespace BudgetApps.API.Controllers.Flux
{
    [CustomAuthorize]
    [ApiController]
    [Route("api/[controller]")]
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

        [HttpGet("year/{id}")]
        public IActionResult GetFluxByYear(int id)
        {
            var response = _fluxService.GetFluxesByYear(id);
            return Ok(response);
        }

        [HttpGet("year/{id}/sum")]
        public IActionResult GetFluxSumByYear(int id)
        {
            var response = _fluxService.GetFluxesSumByYear(id);
            return Ok(response);
        }


        [HttpGet("month/profit")]
        public IActionResult GetFluxMonthProfit()
        {
            var response = _fluxService.GetFluxesMonthProfits();
            return Ok(response);
        }

        [HttpGet("year/{id}/month/profit")]
        public IActionResult GetFluxMonthProfitByYear(int id)
        {
            var response = _fluxService.GetFluxesMonthProfitsByYear(id);
            return Ok(response);
        }

        [HttpGet("year/profit")]
        public IActionResult GetYearProfit()
        {
            var responce = _fluxService.GetFluxesYearProfits();
            return Ok(responce);
        }

        [HttpGet("delta/years")]
        public IActionResult GetDeltaYears()
        {
            var responce = _fluxService.GetYearDeltas();
            return Ok(responce);
        }

        [HttpGet("delta/months")]
        public IActionResult GetDeltaMonth()
        {
            var responce = _fluxService.GetMonthDeltas();
            return Ok(responce);
        }

        [HttpGet("delta/quarter")]
        public IActionResult GetDeltaQuarter()
        {
            var responce = _fluxService.GetQuarterDeltas();
            return Ok(responce);
        }

        [HttpGet("quarter/profit")]
        public IActionResult GetFluxesQuarterProfits()
        {
            var responce = _fluxService.GetFluxesQuarterProfits();
            return Ok(responce);
        }


    }
}
