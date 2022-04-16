using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Entities.FopArea;
using BudgetApps.API.Helpers.Builders;
using BudgetApps.API.Interfaces;

namespace BudgetApps.API.Services.FopArea
{
    public class FopService : EntityBaseService
    {
        public FopService(IConnectionService connectionService, QueryBuilder queryBuilder) : base(connectionService, queryBuilder)
        {
        }

        #region Entities

        public IEnumerable<FopBalance> GetFopBalances()
        {
            return GetAll<FopBalance>();
        }

        #endregion

        public double GetWorkingBalance()
        {
            var fop = GetFopBalances();

            return fop.FirstOrDefault(x => x.Type == "Working")?.Value ?? double.NaN;
        }
    }
}
