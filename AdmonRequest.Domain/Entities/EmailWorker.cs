using System;

namespace AdmonRequest.Domain.Entities
{
    public partial class EmailWorker
    {
        public Guid EmailWorkerId { get; set; }
        public string ToAddress { get; set; }
        public string FromAddress { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public int SentStatus { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? DateSent { get; set; }
    }
}
