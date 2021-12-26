using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Attributes;

namespace BudgetApps.API.Entities.CaseArea
{
    public class CasePayoutInitial
    {
        [Identifier]
        public int CpiId { get; set; }
        public int CppId { get; set; }
        public double ValueUsd { get; set;}

        public CasePayoutPeople CasePayoutPeople { get; set; }
    }
}
