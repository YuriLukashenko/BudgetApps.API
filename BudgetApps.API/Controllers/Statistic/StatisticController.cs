using BudgetApps.API.Helpers;
using BudgetApps.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApps.API.Controllers.Statistic
{
    [CustomAuthorize]
    [ApiController]
    [Route("api/[controller]")]
    public class StatisticController : Controller
    {
        private readonly StatisticService _statisticService;
        public StatisticController(StatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        [HttpGet("median")]
        public IActionResult Index()
        {
            var responce = _statisticService.GetMedian();
            return Ok(responce);
        }
    }
}
