using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Entities.DepositArea;
using BudgetApps.API.Helpers.Builders;
using BudgetApps.API.Interfaces;

namespace BudgetApps.API.Services.DepositArea
{
    public class DepositService : EntityBaseService
    {
        public DepositService(IConnectionService connectionService, QueryBuilder queryBuilder) : base(connectionService, queryBuilder)
        {
        }

        #region Entities

        public IEnumerable<Deposit> GetDeposits()
        {
            return GetAll<Deposit>();
        }

        public IEnumerable<Deposit> GetDepositsByYear(int year)
        {
            var deposits = GetDeposits();

            return deposits.Where(x => x.Date.Year == year);
        }

        #endregion
    }
}
