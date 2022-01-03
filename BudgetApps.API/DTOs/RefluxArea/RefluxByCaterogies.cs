using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApps.API.DTOs.RefluxArea
{
    public class RefluxByCaterogies
    {
        public int RtId { get; set; }
        public string TypeName { get; set; }
        public double Sum { get; set; }
    }
}
