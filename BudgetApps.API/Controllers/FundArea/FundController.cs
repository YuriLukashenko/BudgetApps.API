using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Helpers;
using BudgetApps.API.Services.FundArea;

namespace BudgetApps.API.Controllers.FundArea
{
    [CustomAuthorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FundController : Controller
    {
        private readonly FundService _fundService;
        public FundController(FundService fundService)
        {
            _fundService = fundService;
        }

        [HttpGet("girls")]
        public IActionResult GetCurrent()
        {
            var response = _fundService.GetGirls();
            return Ok(response);
        }

        [HttpGet("sprints")]
        public IActionResult GetFundSprints()
        {
            var response = _fundService.GetFundSprints();
            return Ok(response);
        }

        [HttpGet("donations")]
        public IActionResult GetFundDonations()
        {
            var response = _fundService.GetFundDonations();
            return Ok(response);
        }

        [HttpGet("with/girls")]
        public IActionResult GetFundWithGirls()
        {
            var response = _fundService.GetFundWithGirls();
            return Ok(response);
        }

        [HttpGet("researches")]
        public IActionResult GetFundResearches()
        {
            var response = _fundService.GetFundResearches();
            return Ok(response);
        }

        [HttpGet("spends")]
        public IActionResult GetFundSpends()
        {
            var response = _fundService.GetFundSpends();
            return Ok(response);
        }
    }
}
