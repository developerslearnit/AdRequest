using System;

namespace AdmonRequest.Domain.Entities
{
    public partial class BudgetPeriod
    {
        public Guid BudgetPeriodId { get; set; }
        public string BudgetPeriodName { get; set; }
        public Guid BudgetYearId { get; set; }
        public int OrderNo { get; set; }
        public bool ActiveStatus { get; set; }
        public bool Open { get; set; }
        public BudgetYear BudgetYear { get; set; }
    }
}
