using System;

namespace AdmonRequest.Domain.Entities
{
    public partial class BaseEntity
    {
        public int SNo { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
