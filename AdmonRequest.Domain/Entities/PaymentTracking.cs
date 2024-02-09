using AdmonRequest.Domain.Entities;
using System;

namespace AdmonRequest.Domain.Entitie
{
    public partial class PaymentTracking : BaseEntity
    {
        public Guid TrackingId { get; set; }
        public Guid SourceTableId { get; set; }
        public string OtherRefno { get; set; }
    }
}
