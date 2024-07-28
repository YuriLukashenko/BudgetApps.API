using BudgetApps.API.DTOs.RequiredBills;
using BudgetApps.API.Entities.RequiredBills;
using BudgetApps.API.Helpers;
using BudgetApps.API.Services.RefluxArea;
using BudgetApps.API.Services.RequiredBills;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetApps.API.Controllers.RequiredBills
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequiredBillsController : Controller
    {
        private readonly RequiredBillsService _requiredBillsService;
        public RequiredBillsController(RequiredBillsService requiredBillsService)
        {
            _requiredBillsService = requiredBillsService;
        }

        [HttpGet("categories")]
        public IActionResult GetActiveCategories()
        {
            var response = _requiredBillsService.GetActiveCategories();
            return Ok(response);
        }

        [HttpGet("current/{type}")]
        public IActionResult GetCurrent(int type)
        {
            var billType = (BillTypeDefinition) type;
            var response = _requiredBillsService.GetCurrentBillsByType(billType);
            return Ok(response);
        }

        [HttpGet("total/{type}")]
        public IActionResult GetCurrentTotal(int type)
        {
            var billType = (BillTypeDefinition)type;
            var response = _requiredBillsService.GetCurrentBillsTotal(billType);
            return Ok(response);
        }

        [HttpPost("add")]
        public IActionResult Add(RequiredBillPayed payed)
        {
            var response = _requiredBillsService.Add(payed);
            return Ok(response);
        }

        [HttpPost("selected")]
        public IActionResult GetSelectedBill(DateBillDto dto)
        {
            var response = _requiredBillsService.GetBillsBy(dto);
            return Ok(response);
        }
    }
}
