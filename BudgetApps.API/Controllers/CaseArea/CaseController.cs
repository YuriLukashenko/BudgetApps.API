using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Helpers;
using BudgetApps.API.Services.CaseArea;

namespace BudgetApps.API.Controllers.CaseArea
{
    [CustomAuthorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CaseController : Controller
    {
        private readonly CaseService _caseService;
        public CaseController(CaseService caseService)
        {
            _caseService = caseService;
        }


        [HttpGet("all")]
        public IActionResult GetCases()
        {
            var response = _caseService.GetCases();
            return Ok(response);
        }

        [HttpGet("people")]
        public IActionResult GetCasePayoutPeople()
        {
            var response = _caseService.GetCasePayoutPeople();
            return Ok(response);
        }


        [HttpGet("payouts")]
        public IActionResult GetCasePayouts()
        {
            var response = _caseService.GetCasePayouts();
            return Ok(response);
        }

        [HttpGet("payouts/initial")]
        public IActionResult GetCasePayoutInitials()
        {
            var response = _caseService.GetCasePayoutInitials();
            return Ok(response);
        }
    }
}
