using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.DTOs.EwerArea;
using BudgetApps.API.Entities.EwerArea;
using BudgetApps.API.Helpers.Builders;
using BudgetApps.API.Interfaces;
using Newtonsoft.Json;

namespace BudgetApps.API.Services.EwerArea
{
    public class EwerService : EntityBaseService
    {
        public EwerService(IConnectionService connectionService, QueryBuilder queryBuilder) : base(connectionService, queryBuilder)
        {
        }

        #region Entities

        public IEnumerable<EwerCurrencyTypes> GetEwerCurrencyTypes()
        {
            return GetAll<EwerCurrencyTypes>();
        }
        public IEnumerable<Ewer> GetEwers()
        {
            return GetAll<Ewer>();
        }
        public IEnumerable<EwerCredit> GetEwerCredits()
        {
            return GetAll<EwerCredit>();
        }

        public IEnumerable<EwerSpend> GetEwerSpends()
        {
            return GetAll<EwerSpend>();
        }

        public IEnumerable<ClosedExchanges> GetClosedExchanges()
        {
            return GetAll<ClosedExchanges>();
        }

        #endregion

        public IEnumerable<Ewer> GetEwersByYear(int year)
        {
            var ewers = GetEwers();

            return ewers.Where(x => x.Year == year);
        }

        public IEnumerable<EwerViewDTO> GetEwerViewByYear(int year)
        {
            var ewersByYear = GetEwersByYear(year);
            var currency = GetEwerCurrencyTypes();

            return ewersByYear.Select(x => new EwerViewDTO()
            {
                Month = x.Month,
                InUah = x.Value * x.Rate,
                Name = currency.FirstOrDefault(y => y.EctId == x.EctId)?.Name
            });
        }

        public double CommonEwerUah()
        {
            var ewerUah = GetEwerUah();
            var commonEwerSpendUah = CommonEwerSpendUah();
            var commonEwerCreditUah = CommonEwerCreditUah();

            return ewerUah - commonEwerCreditUah - commonEwerSpendUah;
        }

        public double CommonEwerCreditUah()
        {
            var ewerCredits = GetEwerCredits();

            return ewerCredits.Where(x => x.EctId == 4).Sum(x => x.Value);
        }

        private double CommonEwerSpendUah()
        {
            var ewerSpends = GetEwerSpends();

            return ewerSpends.Where(x => x.EctId == 4).Sum(x => x.Value);
        }

        public double GetEwerUah()
        {
            var ewers = GetEwers();

            return ewers.Where(x => x.EctId == 4).Sum(x => x.Value);
        }
    }
}
