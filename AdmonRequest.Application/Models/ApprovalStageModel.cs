namespace AdmonRequest.Application.Models
{
    public class ApprovalStageModel
    {
        public Guid ApprovalStageId { get; set; }

        public string StageName { get; set; }

        public int Level { get; set; }

        public bool IsFinal { get; set; }
    }
}
