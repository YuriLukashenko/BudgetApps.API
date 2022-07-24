using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.DTOs;
using BudgetApps.API.Entities.LocationArea;
using BudgetApps.API.Helpers.Builders;
using BudgetApps.API.Interfaces;
using BudgetApps.API.Models.Locations;

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

        public IEnumerable<CashLocations> Update(IEnumerable<LocationRequestDTO> dtos)
        {
            var locations = GetCashLocations();

            foreach (var location in locations)
            {
                var toUpdate = dtos.FirstOrDefault(x => x.Type == location.Type);

                if (toUpdate != null)
                {
                    location.Value = toUpdate.Value;
                    UpdateById<CashLocations>(Payload.CreateFrom(location));
                }
            }

            return locations;
        }

        #endregion
    }
}
