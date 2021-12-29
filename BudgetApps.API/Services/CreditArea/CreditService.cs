using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Entities.CreditArea;
using BudgetApps.API.Helpers.Builders;
using BudgetApps.API.Interfaces;

namespace BudgetApps.API.Services.CreditArea
{
    public class CreditService: EntityBaseService
    {
        public CreditService(IConnectionService connectionService, QueryBuilder queryBuilder) : base(connectionService, queryBuilder)
        {
        }

        #region Entities

        public IEnumerable<Credit> GetCredits()
        {
            return GetAll<Credit>();
        }

        #endregion
    }
}
