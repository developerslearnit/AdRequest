using System;

namespace AdmonRequest.Domain.Entities
{
    public partial class StatementofAccount
    {
        public Guid TransactionID { get; set; }
        public Guid AccountUniqueID { get; set; }
        public string AccountNo { get; set; }
        public string AccountName { get; set; }
        public DateTime trnDate { get; set; }
        public string Gjsource { get; set; }
        public string particulars { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public string Address { get; set; }
        public string? ProductName { get; set; }
        public Guid? ProductID { get; set; }
        public string? ProjectTitle { get; set; }
        public string? ProjectCode { get; set; }
        public string? ProjectDetailTitle { get; set; }
        public AccountTYpe AccounttypeID { get; set; }
    }

    public enum AccountTYpe
    {
        Consolidated,
        Project,
        Agent,
        Subcriber,
        Customer,
        Supplier,
        Staff
    }

}
