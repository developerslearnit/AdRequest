using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdmonRequest.Domain.Entities
{
    public partial class BudgetTracking
    {
        public Guid BudgetTrackingId { get; set; }
        public Guid BudgetDetailPeriodID { get; set; }
        public Guid BudgetPeriodId { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public DateTime TransactionDate { get; set; }
        public string GJSource { get; set; }
        public string Description { get; set; }
        public bool Syncronized { get; set; }
    }
}
