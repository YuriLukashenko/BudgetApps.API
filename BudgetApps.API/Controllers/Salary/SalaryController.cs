﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Helpers;
using BudgetApps.API.Services.Flux;

namespace BudgetApps.API.Controllers.Salary
{
    [CustomAuthorize]
    [ApiController]
    [Route("[controller]")]
    public class SalaryController : Controller
    {
        private readonly SalaryService _salaryService;

        public SalaryController(SalaryService salaryService)
        {
            _salaryService = salaryService;
        }

        [HttpGet("company")]
        public IActionResult GetCompanies()
        {
            var response = _salaryService.GetCompanies();
            return Ok(response);
        }

        [HttpGet("formation")]
        public IActionResult GetSalaryFormations()
        {
            var response = _salaryService.GetSalaryFormations();
            return Ok(response);
        }

        [HttpGet("enrollment")]
        public IActionResult GetSalaryEnrollments()
        {
            var response = _salaryService.GetSalaryEnrollments();
            return Ok(response);
        }

        [HttpGet("bonuses")]
        public IActionResult GetSalaryBonuses()
        {
            var response = _salaryService.GetSalaryBonuses();
            return Ok(response);
        }

        [HttpGet("bonus-types")]
        public IActionResult GetSalaryBonusTypes()
        {
            var response = _salaryService.GetSalaryBonusTypes();
            return Ok(response);
        }

        [HttpGet("taxes")]
        public IActionResult GetTaxes()
        {
            var response = _salaryService.GetTaxes();
            return Ok(response);
        }

        [HttpGet("converting")]
        public IActionResult GetSalaryConvertings()
        {
            var response = _salaryService.GetSalaryConvertings();
            return Ok(response);
        }
    }
}
