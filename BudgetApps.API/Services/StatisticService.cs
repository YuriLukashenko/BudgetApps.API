using LinqStatistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApps.API.Services
{
    public class StatisticService
    {
        public double GetPercentile(IEnumerable<double> numbers, double percentile)
        {
            return Percentile(numbers.ToList(), percentile);
        }

        public double GetMockedMedian(double percentile)
        {
            var numbers = new List<double>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            return GetPercentile(numbers, percentile);
        }

        public double Percentile(List<double> sequence, double excelPercentile)
        {
            sequence.Sort();
            int N = sequence.Count();
            //double n = (N - 1) * excelPercentile + 1;
            double n = (N + 1) * excelPercentile;
            if (n == 1d) return sequence[0];
            else if (n == N) return sequence[N - 1];
            else
            {
                int k = (int)n;
                double d = n - k;
                return sequence[k - 1] + d * (sequence[k] - sequence[k - 1]);
            }
        }
    }
}
