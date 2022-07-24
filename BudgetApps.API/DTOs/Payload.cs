using BudgetApps.API.Attributes;
using BudgetApps.API.Entities.LocationArea;
using BudgetApps.API.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Entities.FopArea;

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

        public static Payload CreateFrom(FopBalance balance)
        {
            return new Payload()
            {
                KeyName = NameMapper.ToSnakeCase(nameof(balance.FopId)),
                KeyValue = balance.FopId,
                PropertyName = NameMapper.ToSnakeCase(nameof(balance.Value)),
                PropertyValue = balance.Value.ToString(CultureInfo.CurrentCulture)
            };
        }
    }
}
