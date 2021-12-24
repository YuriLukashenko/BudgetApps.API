using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Attributes;

namespace BudgetApps.API.Entities.FluxArea
{
    public class FluxTypes
    {
        [Identifier]
        public int FtId { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
    }
}
