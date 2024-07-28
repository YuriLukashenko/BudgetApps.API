using BudgetApps.API.Entities.RequiredBills;

namespace BudgetApps.API.DTOs.RequiredBills
{
    public class DateBillDto
    {
        public BillTypeDefinition Type { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
    }
}
