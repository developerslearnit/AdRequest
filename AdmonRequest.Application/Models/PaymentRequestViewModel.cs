using AdmonRequest.Application.Constants;


namespace AdmonRequest.Application.Models
{
    public class PaymentRequestViewModel
    {
        public Guid PaymentRequestId { get; set; }
        public Guid RequestTypeId { get; set; }
        public string RequestType { get; set; }
        public Guid DepartmentSubUnitId { get; set; }
        public string SubDepartment { get; set; }
        public Guid StaffId { get; set; }
        public string Beneficiary { get; set; }
        public string RefNo { get; set; }
        public Guid? BudgetCategoryId { get; set; }
        public string BudgeCategory { get; set; }
        public Guid? BudgetPeriodId { get; set; }
        public string BudgetPeriod { get; set; }
        public string? VoteType { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public Guid ApprovalStage { get; set; }
        public Guid? ApprovalStatus { get; set; }
        public bool IsSyncronized { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime RequestDate { get; set; }
        public string ReadAbleStatus
        {
            get
            {

                if (ApprovalStatus == Guid.Parse(AppConstants.ApprovalStatus.PENDING))
                {
                    return "Pending";
                }
                else if (ApprovalStatus == Guid.Parse(AppConstants.ApprovalStatus.APPROVED))
                {
                    return "Approved";
                }
                else if (ApprovalStatus == Guid.Parse(AppConstants.ApprovalStatus.REJECTED))
                {
                    return "Disapprove";
                }
                else
                {
                    return "";
                }


            }
        }
        public string AmountString { get { return Amount.ToString("#,##.00"); } }
        public string DateCreated { get { return RequestDate.ToString("dd-MM-yyyy"); } }
    }
}
