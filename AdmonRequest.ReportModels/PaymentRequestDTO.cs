using System;

namespace AdmonRequest.ReportModels
{
    public class PaymentRequestDTO
    {
        public string RequestType { get; set; }
        public string SubDepartment { get; set; }
        public string Beneficiary { get; set; }
        public string RefNo { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime RequestDate { get; set; }
    }
}
