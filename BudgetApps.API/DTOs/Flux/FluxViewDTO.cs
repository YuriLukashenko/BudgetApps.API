using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApps.API.DTOs.Flux
{
    public class FluxViewDTO
    {
        public string Type { get; set; }
        public string Value { get; set; }
        public string Date { get; set; }
        public string Comment { get; set; }
    }
}
