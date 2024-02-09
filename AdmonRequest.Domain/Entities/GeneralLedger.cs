using System;
using System.Collections.Generic;
using System.Text;

namespace AdmonRequest.Domain.Entities
{
    public partial class GeneralLedger
    {
        public Guid TransactionID { get; set; }
        public Guid AccountYearID { get; set; }
        public Guid AccountPointSetupID { get; set; }
        public string Accountid { get; set; }
        public string AccountName { get; set; }
        public DateTime trnDate { get; set; }
        public string Gjsource { get; set; }
        public string particulars { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public string gjSourceParent { get; set; }
        public string AccountPointSetupCode { get; set; }
        public string AccountYear { get; set; }
        public string Classid { get; set; }
        public string Accountclass { get; set; }
        public string? InstrumentNo { get; set; }
        public string? Beneficiary { get; set; }

    }
}
