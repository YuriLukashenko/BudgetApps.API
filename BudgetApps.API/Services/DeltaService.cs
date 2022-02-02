using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApps.API.Services
{
    public class DeltaService
    {
        public enum BinDefenition { Year, Month }

        public BinDefenition Bin { get; set; }

        public string DeltaPeriodFormatting(BinDefenition bin, DateTime date)
        {
            switch (bin)
            {
                case BinDefenition.Year:
                    return $"{date.Year} vs {date.AddYears(-1).Year}";
                case BinDefenition.Month:
                    return string.Empty;
                default:
                    return string.Empty;
            }
        }

        public double CalculateDelta(double next, double prev)
        {
            return prev != 0.0 ? (next / prev) - 1.0 : 0.0;
        }
    }
}
