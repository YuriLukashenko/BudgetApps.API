using BudgetApps.API.Attributes;

namespace BudgetApps.API.Entities.RequiredBills
{
    public enum BillTypeDefinition { External = 0, Internal = 1 }

    public class RequiredBillCategory
    {
        [Identifier]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsArchive { get; set; }
        public BillTypeDefinition Type { get; set; }
    }
}
