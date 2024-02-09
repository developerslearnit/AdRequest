using System;
using System.Collections.Generic;
using System.Text;

namespace AdmonRequest.Domain.Entities
{
    public partial class VoteType
    {
        public Guid VoteTypeId { get; set; }
        public string VoteTypeName { get; set; }
    }
}
