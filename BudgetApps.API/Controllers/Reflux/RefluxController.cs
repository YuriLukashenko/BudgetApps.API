﻿using System;
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
        public IActionResult GetRefluxMonthSpend()
        {
            var response = _refluxService.GetRefluxesMonth();
            return Ok(response);
        }

        [HttpGet("month/spend/type/{type}")]
        public IActionResult GetRefluxMonthSpendByType(int type)
        {
            var response = _refluxService.GetRefluxesMonthByCategory(type);
            return Ok(response);
        }

        [HttpGet("year/spend")]
        public IActionResult GetRefluxYearSpend()
        {
            var response = _refluxService.GetRefluxesYear();
            return Ok(response);
        }

        [HttpGet("year/spend/type/{type}")]
        public IActionResult GetRefluxYearSpendByType(int type)
        {
            var response = _refluxService.GetRefluxesYearByCategory(type);
            return Ok(response);
        }

        [HttpGet("month/spend/{year}")]
        public IActionResult GetRefluxMonthSpendByYear(int year)
        {
            if (year == DateTime.Now.Year)
            {
                var response = _refluxService.GetRefluxesMonthCurrent();
                return Ok(response);
            }
            else
            {
                var response = _refluxService.GetRefluxesMonthByYear(year);
                return Ok(response);
            }
        }

        [HttpGet("month/spend/{year}/{type}")]
        public IActionResult GetRefluxMonthSpendByYear(int year, int type)
        {
            if (year == DateTime.Now.Year)
            {
                var response = _refluxService.GetRefluxesMonthCurrentByType(type);
                return Ok(response);
            }
            else
            {
                var response = _refluxService.GetRefluxesMonthByYearByType(year, type);
                return Ok(response);
            }
        }


        [HttpGet("types/{year}")]
        public IActionResult GetUsedRefluxTypesByYear(int year)
        {
            if (year == DateTime.Now.Year)
            {
                var response = _refluxService.GetUsedRefluxTypesMonthCurrent();
                return Ok(response);
            }
            else
            {
                var response = _refluxService.GetUsedRefluxTypesByYear(year);
                return Ok(response);
            }
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

        [HttpPost("add")]
        public IActionResult AddReflux(Entities.RefluxArea.Reflux reflux)
        {
            var response = _refluxService.Add(reflux);
            return Ok(response);
        }

        [HttpGet("categories/years")]
        public IActionResult GetRefluxByCaterogiesByYears()
        {
            var response = _refluxService.GetRefluxByCategoriesByYears();
            return Ok(response);
        }

        [HttpGet("last/{count}")]
        public IActionResult GetLast(int count)
        {
            var response = _refluxService.GetLast(count);
            return Ok(response);
        }
    }
}
