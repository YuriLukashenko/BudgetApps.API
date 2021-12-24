using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApps.API.Helpers.FieldComponents
{
    public class FieldOrder
    {
        public string FieldName { get; set; }
        public enum OrderDefinition { NotSet, Asc, Desc }
        public OrderDefinition Order { get; set; } = OrderDefinition.NotSet;
    }
}
