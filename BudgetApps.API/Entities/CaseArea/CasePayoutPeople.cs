using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Attributes;

namespace BudgetApps.API.Entities.CaseArea
{
    public class CasePayoutPeople
    {
        [Identifier]
        public int CppId { get; set; }
        public string Name { get; set; }
    }
}
