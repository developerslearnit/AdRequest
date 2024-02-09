namespace AdmonRequest.Application.Models
{
    public class PaymentRequestModel
    {
        public Guid PaymentRequestId { get; set; }
        public Guid RequestTypeId { get; set; }
        public Guid DepartmentSubUnitId { get; set; }
        public Guid StaffId { get; set; }
        public DateTime RequestDate { get; set; }
        public string RequestDateString { get; set; }
        public string BeneficiaryName { get; set; }
        public string RefNo { get; set; }
        public Guid? BudgetCategoryId { get; set; }
        public Guid? BudgetPeriodId { get; set; }
        public string? VoteType { get; set; }
        public decimal Amount { get; set; }
        public decimal DeductionAmount { get; set; }
        public string Description { get; set; }
        public Guid? ApprovalStatus { get; set; }
        public Guid ApprovalLevel { get; set; }
        public Guid CreatedBy { get; set; }
    }

    //public class Test
    //{
    //    public Guid PaymentRequestId { get; set; }
    //    public Guid RequestTypeId { get; set; }
    //    public Guid DepartmentSubUnitId { get; set; }
    //    public Guid StaffId { get; set; }
    //    public DateTime RequestDate { get; set; }
    //    public string BeneficiaryName { get; set; }
    //    public string RefNo { get; set; }
    //    public Guid? BudgetCategoryId { get; set; }
    //    public Guid? BudgetPeriodId { get; set; }
    //    public string? VoteType { get; set; }
    //    public decimal Amount { get; set; }
    //    public decimal DeductionAmount { get; set; }
    //    public string LPONo { get; set; }
    //    public string Description { get; set; }
    //    public Guid? ApprovalStatus { get; set; }
    //}
}
