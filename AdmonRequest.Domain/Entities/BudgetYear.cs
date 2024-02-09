using System;

namespace AdmonRequest.Domain.Entities
{
    public partial class BudgetYear
    {
        public Guid BudgetYearId { get; set; }
        public string BudgetYearName { get; set; }
        public bool ActiveStatus { get; set; }
    }
}
