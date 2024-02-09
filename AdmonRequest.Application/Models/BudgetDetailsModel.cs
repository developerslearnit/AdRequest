namespace AdmonRequest.Application.Models
{
    public class BudgetDetailsModel
    {
        public Guid BudgetDetailPeriodID { get; set; }
        public Guid BudgetDetailId { get; set; }
        public Guid BudgetCategoryId { get; set; }
        public Guid DepartmentId { get; set; }
        public string AccountID { get; set; }
        public string AccountName { get; set; } = string.Empty;
        public decimal BudgetAmount { get; set; }
        public Guid BudgetMethodId { get; set; }
        public Guid BudgetPeriodId { get; set; }
        public Guid BudgetYearId { get; set; }
        public Guid DepartmentSubUnitId { get; set; }
        public bool ApplicableToUnit { get; set; }
    }
}
