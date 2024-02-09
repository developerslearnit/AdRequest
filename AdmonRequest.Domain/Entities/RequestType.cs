using System;

namespace AdmonRequest.Domain.Entities
{
    public partial class RequestType
    {
        public Guid RequestTypeId { get; set; }
        public string RequestTypeName { get; set; }
        public bool ActiveStatus { get; set; }
        public bool ReduceBuget { get; set; }
        public bool IsAdvance { get; set; }
        public bool IsProject { get; set; }
        public bool IsDirectPayment { get; set; }
    }
}
