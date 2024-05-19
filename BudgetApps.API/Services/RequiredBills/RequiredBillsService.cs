using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BudgetApps.API.Entities.FluxArea;
using BudgetApps.API.Entities.RefluxArea;
using BudgetApps.API.Entities.RequiredBills;
using BudgetApps.API.Helpers.Builders;
using BudgetApps.API.Interfaces;

namespace BudgetApps.API.Services.RequiredBills
{
    public class RequiredBillsService : EntityBaseService
    {
        private readonly IConnectionService _connectionService;

        public RequiredBillsService(IConnectionService connectionService, QueryBuilder queryBuilder) : base(connectionService, queryBuilder)
        {
            _connectionService = connectionService;
        }

        public IEnumerable<RequiredBillCategory> GetCategories()
        {
            return GetAll<RequiredBillCategory>();
        }

        public IEnumerable<RequiredBillCategory> GetActiveCategories()
        {
            var categories = GetCategories();

            return categories.Where(x => !x.IsArchive);
        }

        public RequiredBillPayed Add(RequiredBillPayed payed) => SafeInsert(payed);
    }
}
