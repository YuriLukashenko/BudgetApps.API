using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Attributes;

namespace BudgetApps.API.Entities.CaseArea
{
    public class CasePayouts
    {
        [Identifier]
        public int CpId { get; set; }
        public double ValueUsd { get; set; }
        public DateTime Date { get; set; }
        public int ToWhom { get; set; }

        //matched with ToWhom
        public CasePayoutPeople CasePayoutPeople { get; set; }
    }
}
