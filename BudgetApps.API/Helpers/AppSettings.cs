using BudgetApps.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApps.API.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }

        public DbConnector DbConnector { get; set; }
    }
}
