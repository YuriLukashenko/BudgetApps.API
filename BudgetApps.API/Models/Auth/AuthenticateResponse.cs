using BudgetApps.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApps.API.Models.Auth
{
    public class AuthenticateResponse
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(Users users, string token)
        {
            UserId = users.UserId;
            FirstName = users.FirstName;
            LastName = users.LastName;
            Username = users.UserName;
            Token = token;
        }
    }
}
