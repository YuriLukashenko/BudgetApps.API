using BudgetApps.API.Entities;
using BudgetApps.API.Helpers;
using BudgetApps.API.Interfaces;
using BudgetApps.API.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BudgetApps.API.Helpers.Builders;
using Dapper;

namespace BudgetApps.API.Services
{
    public class UserService : EntityBaseService, IUserService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private IEnumerable<Users> _users;

        private readonly AppSettings _appSettings;
        private readonly IConnectionService _connectionService;

        public UserService(IOptions<AppSettings> appSettings, IConnectionService connectionService, QueryBuilder queryBuilder) : base(connectionService, queryBuilder)
        {
            _appSettings = appSettings.Value;
            _connectionService = connectionService;
            _users = GetAll();
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _users.SingleOrDefault(x => x.UserName == model.Username && x.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = GenerateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public IEnumerable<Users> GetAll()
        {
            return GetAll<Users>();
        }

        public Users GetById(Guid id)
        {
            return _users.FirstOrDefault(x => x.UserId == id);
        }

        private string GenerateJwtToken(Users users)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", users.UserId.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
