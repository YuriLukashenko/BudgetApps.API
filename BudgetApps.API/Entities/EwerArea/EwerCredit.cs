using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BudgetApps.API.Attributes;
using Newtonsoft.Json;

namespace BudgetApps.API.Entities.EwerArea
{
    public class EwerCredit
    {
        [Identifier]
        public int EcId { get; set; }
        public double Value { get; set; }
        public int EctId { get; set; }
        public double Rate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Comment { get; set; }

        public EwerCurrencyTypes EwerCurrencyTypes { get; set; }
    }
}
