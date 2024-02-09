using System;

namespace AdmonRequest.Domain.Entities
{
    public partial class BudgetCategory
    {
        public Guid BudgetCategoryId { get; set; }
        public string BudgetCategoryName { get; set; }
        public bool ActiveStatus { get; set; }
    }
}
