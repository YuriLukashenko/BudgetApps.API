using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApps.API.Models.Locations
{
    public class FopRequestDTO
    {
        public double Value { get; set; }
        public string Type { get; set; }
    }

    public class FopSubtractRequestDto
    {
        public double Value { get; set; }
        public string Type { get; set; }
    }
}
