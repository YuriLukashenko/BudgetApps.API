using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Helpers;
using BudgetApps.API.Services.SalaryArea;

namespace BudgetApps.API.Controllers.Salary
{
    [CustomAuthorize]
    [ApiController]
    [Route("api/[controller]")]
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

        [HttpGet("bonus/types")]
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

        [HttpGet("rates/avg")]
        public IActionResult GetSalaryAverageRates()
        {
            var response = _salaryService.GetSalaryAverageRates();
            return Ok(response);
        }

        [HttpGet("bonuses/by/types")]
        public IActionResult GetSalaryBonusesByTypes()
        {
            var response = _salaryService.GetSalaryBonusesByTypes();
            return Ok(response);
        }

        [HttpGet("bonuses/by/months")]
        public IActionResult GetSalaryBonusesByMonths()
        {
            var response = _salaryService.GetSalaryBonusesByMonths();
            return Ok(response);
        }

        [HttpGet("formation/hours")]
        public IActionResult GetSalaryWorkHours()
        {
            var response = _salaryService.GetSalaryWorkHours();
            return Ok(response);
        }

        [HttpGet("enrollment/total")]
        public IActionResult GetTotalSalaryByMonths()
        {
            var response = _salaryService.GetTotalSalaryByMonths();
            return Ok(response);
        }

        [HttpGet("delta/months")]
        public IActionResult GetDeltaSalaryByMonths()
        {
            var response = _salaryService.GetDeltaSalaryByMonths();
            return Ok(response);
        }
    }
}
