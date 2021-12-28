using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Helpers;
using BudgetApps.API.Services.StackArea;

namespace BudgetApps.API.Controllers.StackArea
{
    [CustomAuthorize]
    [ApiController]
    [Route("[controller]")]
    public class StackController : Controller
    {
        private readonly StackService _stackService;
        public StackController(StackService stackService)
        {
            _stackService = stackService;
        }

        [HttpGet("all")]
        public IActionResult GetStacks()
        {
            var response = _stackService.GetStacks();
            return Ok(response);
        }

        [HttpGet("types")]
        public IActionResult GetStackTypes()
        {
            var response = _stackService.GetStackTypes();
            return Ok(response);
        }
    }
}
