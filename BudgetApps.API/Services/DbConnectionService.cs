using BudgetApps.API.Helpers;
using BudgetApps.API.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApps.API.Services
{
    public class DbConnectionService : IConnectionService
    {
        private readonly IOptions<AppSettings> _config;
        public DbConnectionService(IOptions<AppSettings> config)
        {
            _config = config;
        }
        public NpgsqlConnection Connect()
        {
            try
            {
                var connect = _config.Value.DbConnector;
                return new NpgsqlConnection($"Host={connect.Host};Port={connect.Port};Username={connect.Username};Password={connect.Password};Database={connect.Database};");
            }
            catch
            {
                Debug.WriteLine("Errors in appsettings or NpgsqlConnection");
                throw;
            }
        }
    }
}
