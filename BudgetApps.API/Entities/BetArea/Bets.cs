using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Attributes;

namespace BudgetApps.API.Entities.BetArea
{
    public class Bets
    {
        [Identifier] public int BId { get; set; }
        public double Bet { get; set; }
        public double Outcome { get; set; }
        public double Commission { get; set; }
        public DateTime BetDate { get; set; }
        public DateTime OutcomeDate { get; set; }
        public string Comment { get; set; }
    }
}
