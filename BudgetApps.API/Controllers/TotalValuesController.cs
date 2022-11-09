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

        [HttpGet("uah")]
        public IActionResult GetTotalUah()
        {
            var response = _totalValuesService.GetTotalUah();
            return Ok(response);
        }

        [HttpGet("usd")]
        public IActionResult GetTotalUsd()
        {
            var response = _totalValuesService.GetTotalUsdInUah();
            return Ok(response);
        }

        [HttpGet("eur")]
        public IActionResult GetTotalEur()
        {
            var response = _totalValuesService.GetTotalEurInUah();
            return Ok(response);
        }

        [HttpGet("pln")]
        public IActionResult GetTotalPln()
        {
            var response = _totalValuesService.GetTotalPlnInUah();
            return Ok(response);
        }

        [HttpGet("fop")]
        public IActionResult GetTotalFop()
        {
            var response = _totalValuesService.GetTotalFopInUah();
            return Ok(response);
        }

        [HttpGet("all")]
        public IActionResult GetTotalAll()
        {
            var response = _totalValuesService.GetTotalValuesTotal();
            return Ok(response);
        }

        [HttpGet("percents")]
        public IActionResult GetTotalPercents()
        {
            var response = _totalValuesService.GetPercents();
            return Ok(response);
        }

        [HttpGet("slices")]
        public IActionResult GetSlices()
        {
            var response = _totalValuesService.GetSlices();
            return Ok(response);
        }
    }
}
