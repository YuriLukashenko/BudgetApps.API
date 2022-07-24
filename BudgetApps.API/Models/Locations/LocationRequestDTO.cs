using BudgetApps.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BudgetApps.API.Entities.LocationArea.CashLocations;

namespace BudgetApps.API.Models.Locations
{
    public class LocationRequestDTO
    {
        public double Value { get; set; }
        public LocationTypes Type { get; set; }
    }
}
