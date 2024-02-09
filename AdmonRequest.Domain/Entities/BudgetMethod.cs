using System;

namespace AdmonRequest.Domain.Entities
{
    public partial class BudgetMethod
    {
        public Guid BudgetMethodId { get; set; }
        public string BudgetMethodName { get; set; }
        public bool ActiveStatus { get; set; }
    }
}
