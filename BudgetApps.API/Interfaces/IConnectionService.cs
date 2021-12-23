using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApps.API.Interfaces
{
    public interface IConnectionService
    {
        NpgsqlConnection Connect();
    }
}
