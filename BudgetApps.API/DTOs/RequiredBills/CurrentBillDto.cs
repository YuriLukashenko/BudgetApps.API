using BudgetApps.API.Entities.RequiredBills;

namespace BudgetApps.API.DTOs.RequiredBills
{
    public class CurrentBillDto
    {
        public string Category { get; set; }
        public double RequiredBill { get; set; }
        public double ActualBill { get; set; }
        public bool IsCompleted { get; set; }
        public BillTypeDefinition Type { get; set; }
    }
}