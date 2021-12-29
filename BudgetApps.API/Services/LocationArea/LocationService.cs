using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Entities.LocationArea;
using BudgetApps.API.Helpers.Builders;
using BudgetApps.API.Interfaces;

namespace BudgetApps.API.Services.LocationArea
{
    public class LocationService : EntityBaseService
    {
        public LocationService(IConnectionService connectionService, QueryBuilder queryBuilder) : base(
            connectionService, queryBuilder)
        {
        }

        #region Entities

        public IEnumerable<CashLocations> GetCashLocations()
        {
            return GetAll<CashLocations>();
        }

        public IEnumerable<CashLocationsCurrentBets> GetCashLocationsCurrentBets()
        {
            return GetAll<CashLocationsCurrentBets>();
        }

        public IEnumerable<CashLocationsMiniDebts> GetCashLocationsMiniDebts()
        {
            return GetAll<CashLocationsMiniDebts>();
        }

        #endregion
    }
}
