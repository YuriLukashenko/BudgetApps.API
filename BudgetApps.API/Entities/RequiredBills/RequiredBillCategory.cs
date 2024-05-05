using BudgetApps.API.Attributes;

namespace BudgetApps.API.Entities.RequiredBills
{
    public class RequiredBillCategory
    {
        [Identifier]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsArchive { get; set; }
    }
}
