namespace AdmonRequest.Application.Models
{
    public class ApprovalModel
    {
        public string requestId { get; set; }
        public string action { get; set; } = "Approved";
    }
}
