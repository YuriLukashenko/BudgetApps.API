using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BudgetApps.API.Entities.EwerArea
{
    public class Ewer
    {
        [Identifier]
        public int EId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int EctId { get; set; }
        public double Value { get; set; }
        public double Rate { get; set; }

        
        public EwerCurrencyTypes EwerCurrencyTypes { get; set; }
    }
}
