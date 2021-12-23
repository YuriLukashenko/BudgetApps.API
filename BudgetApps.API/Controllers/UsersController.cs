using BudgetApps.API.Helpers;
using BudgetApps.API.Interfaces;
using BudgetApps.API.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApps.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConnectionService _connectionService;
        public UsersController(IUserService userService, IConnectionService connectionService)
        {
            _userService = userService;
            _connectionService = connectionService;
        }

        [HttpGet("connect")]
        public IActionResult Connect()
        {
            IEnumerable<string> s;
            using (var connection = _connectionService.Connect())
            {
                connection.Open();

                s = connection.Query<string>("SELECT fop_balance.value " +
                                         "FROM dbo.fop_balance AS fop_balance " +
                                         "WHERE fop_balance.type = 'Working' ");
                connection.Close();
            }
            return Ok(s);
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [CustomAuthorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
    }
}
