using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Helpers;
using BudgetApps.API.Services.ObligationArea;

namespace BudgetApps.API.Controllers.ObligationArea
{
    [CustomAuthorize]
    [ApiController]
    [Route("api/[controller]")]

    public class ObligationController : Controller
    {
        private readonly ObligationService _obligationService;
        public ObligationController(ObligationService obligationService)
        {
            _obligationService = obligationService;
        }

        [HttpGet("all")]
        public IActionResult GetObligations()
        {
            var response = _obligationService.GetObligations();
            return Ok(response);
        }

        [HttpGet("types")]
        public IActionResult GetObligationTypes()
        {
            var response = _obligationService.GetObligationTypes();
            return Ok(response);
        }
    }
}
