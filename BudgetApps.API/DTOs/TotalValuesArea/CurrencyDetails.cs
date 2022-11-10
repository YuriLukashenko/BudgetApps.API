using Newtonsoft.Json;

namespace BudgetApps.API.DTOs.TotalValuesArea
{
    public class CurrencyDetails
    {
        public string Currency { get; set; }
        public Details Details { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Details
    {
        public double? CurrentCash { get; set; }
        public double? Fund { get; set; }
        public double? Balance { get; set; }
        public double? Credit { get; set; }
        public double? Ewer { get; set; }
        public double? EwerCredit { get; set; }
        public double? Deposit { get; set; }
        public double? Obligation { get; set; }
        public double? Total { get; set; }
    }
}
