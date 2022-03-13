using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Helpers;
using BudgetApps.API.Services.ArmyArea;

namespace BudgetApps.API.Controllers.ArmyArea
{
    [CustomAuthorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ArmyController : Controller
    {
        private readonly ArmyService _armyService;
        public ArmyController(ArmyService armyService)
        {
            _armyService = armyService;
        }

        [HttpGet("all")]
        public IActionResult GetArmies()
        {
            var response = _armyService.GetArmies();
            return Ok(response);
        }
    }
}
