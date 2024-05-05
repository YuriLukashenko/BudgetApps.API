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

        [AllowAnonymous]
        [HttpGet("categories")]
        public IActionResult GetCurrent()
        {
            var response = _requiredBillsService.GetCategories();
            return Ok(response);
        }
    }
}
