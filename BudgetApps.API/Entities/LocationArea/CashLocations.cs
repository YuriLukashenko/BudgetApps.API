using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Attributes;

namespace BudgetApps.API.Entities.LocationArea
{
    public class CashLocations
    {
        public enum LocationTypes
        {
            None = 0,
            Cash = 1,
            PrivatUniversal = 2,
            PrivatPayout = 3, 
            MonoBlack = 4,
            MonoWhite = 5,
            MonoUsd = 6,
            MonoSupport = 7,
            Additional = 8,
            Outside = 9
        }
        [Identifier]
        public int ClId { get; set; }
        public double Value { get; set; }
        public string LocationName { get; set; }
        public LocationTypes Type { get; set; }
    }
}
