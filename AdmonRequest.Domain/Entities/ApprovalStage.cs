using System;

namespace AdmonRequest.Domain.Entities
{
    public partial class ApprovalStage
    {
        public Guid ApprovalStageId { get; set; }

        public string StageName { get; set; }

        public int Level { get; set; }

        public bool IsFinal { get; set; }
    }
}
