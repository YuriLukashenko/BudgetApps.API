using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.DTOs.Delta;

namespace BudgetApps.API.Helpers
{
    public class FormatManager
    {
        public static string DeltaPeriodFormatting(BinDefinition bin, DateTime date)
        {
            switch (bin)
            {
                case BinDefinition.Year:
                    return $"{date:yyyy} vs {date.AddYears(-1):yyyy}";
                case BinDefinition.Quarter:
                    return $"{GetQuarterName(date)} vs {GetQuarterName(date.AddMonths(-3))} ({date:yyyy})";
                case BinDefinition.Month:
                    return $"{date:MMM yyyy} vs {date.AddMonths(-1):MMM yyyy}";
                default:
                    return string.Empty;
            }
        }

        public static string IndexPeriodFormatting(BinDefinition bin, DateTime date, DateTime index)
        {
            switch (bin)
            {
                case BinDefinition.Year:
                    return $"{date:yyyy} vs {index:yyyy}";
                case BinDefinition.Quarter:
                    return $"{GetQuarterName(date)} ({date:yyyy}) vs {GetQuarterName(index)} ({index:yyyy})";
                case BinDefinition.Month:
                    return $"{date:MMM yyyy} vs {index:MMM yyyy}";
                default:
                    return string.Empty;
            }
        }

        public static string GetQuarterName(DateTime date)
        {
            return "Q" + (date.Month + 2) / 3;
        }
    }
}
