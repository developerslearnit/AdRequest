namespace AdmonRequest.Application.Models
{
    public class EmailWorkerModel
    {
        public Guid EmailWorkerId { get; set; }
        public string ToAddress { get; set; }
        public string FromAddress { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public int SentStatus { get; set; }
    }
}
