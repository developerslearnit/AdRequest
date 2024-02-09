namespace AdmonRequest.Application.Models
{
    public class RequestAttachmentModel    {
        public Guid RequestAttachmentId { get; set; }
        public Guid PaymentRequestId { get; set; }
        public byte[] Attachment { get; set; }
        public string FileExt { get; set; }
        public string FileName { get; set; }
    }
}
