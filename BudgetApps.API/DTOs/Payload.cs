using BudgetApps.API.Attributes;
using BudgetApps.API.Entities.LocationArea;
using BudgetApps.API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApps.API.DTOs
{
    public class Payload
    {
        public string KeyName { get; set; }
        public int KeyValue {get; set; }
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }

        public static Payload CreateFrom(CashLocations location)
        {
            return new Payload()
            {
                KeyName = NameMapper.ToSnakeCase(nameof(location.ClId)),
                KeyValue = location.ClId,
                PropertyName = NameMapper.ToSnakeCase(nameof(location.Value)),
                PropertyValue = location.Value.ToString()
            };
        }
    }
}
