using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Entities.DepositArea;
using BudgetApps.API.Helpers.Builders;
using BudgetApps.API.Interfaces;
using BudgetApps.API.Services.EwerArea;

namespace BudgetApps.API.Services.DepositArea
{
    public class DepositService : EntityBaseService
    {
        private readonly EwerService _ewerService;
        public DepositService(IConnectionService connectionService, 
            QueryBuilder queryBuilder, EwerService ewerService) : base(connectionService, queryBuilder)
        {
            _ewerService = ewerService;
        }

        #region Entities

        public IEnumerable<Deposit> GetDeposits()
        {
            return GetAll<Deposit>();
        }

        public IEnumerable<Deposit> GetDepositsByYear(int year, string currency)
        {
            var ectId = _ewerService.GetEwerCurrencyTypeIdByName(currency);
            if (ectId == 0) return null;

            var deposits = GetDeposits();

            return deposits.Where(x => x.Date.Year == year && x.EctId == ectId);
        }

        #endregion

        public double ActiveSumByYear(int year, string currency)
        {
            var deposits = GetDepositsByYear(year, currency);

            return deposits.Sum(x => x.Value);
        }
    }
}
