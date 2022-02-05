using LinqStatistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApps.API.Services
{
    public class StatisticService
    {
        public double GetMedian(IEnumerable<int> numbers)
        {
            double[] array = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};
            return Percentile(array, 0.5);
        }

        public double GetMedian()
        {
            var numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            return GetMedian(numbers);
        }

        public double Percentile(double[] sequence, double excelPercentile)
        {
            Array.Sort(sequence);
            int N = sequence.Length;
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
