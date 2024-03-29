﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Helpers;
using BudgetApps.API.Services.LocationArea;
using BudgetApps.API.Models.Locations;

namespace BudgetApps.API.Controllers.LocationArea
{
    [CustomAuthorize]
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : Controller
    {
        private readonly LocationService _locationService;
        public LocationController(LocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet("all")]
        public IActionResult GetCashLocations()
        {
            var response = _locationService.GetCashLocations();
            return Ok(response);
        }

        [HttpPost("update")]
        public IActionResult PostCashLocations(IEnumerable<LocationRequestDTO> request)
        {
            var response = _locationService.Update(request);

            return Ok(response);
        }

        [HttpGet("bets")]
        public IActionResult GetCashLocationsCurrentBets()
        {
            var response = _locationService.GetCashLocationsCurrentBets();
            return Ok(response);
        }

        [HttpGet("debts")]
        public IActionResult GetCashLocationsMiniDebts()
        {
            var response = _locationService.GetCashLocationsMiniDebts();
            return Ok(response);
        }
    }
}
