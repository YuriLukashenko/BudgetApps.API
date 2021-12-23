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
        private readonly AppSettings _appSettings;
        public DbConnectionService(IOptions<AppSettings> config)
        {
            _appSettings = config?.Value;
        }
        public NpgsqlConnection Connect()
        {
            try
            {
                var connect = _appSettings.DbConnector;
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
