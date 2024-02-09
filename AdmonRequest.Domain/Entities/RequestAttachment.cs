using System;
using System.Collections.Generic;
using System.Text;

namespace AdmonRequest.Domain.Entities
{
    public class RequestAttachment
    {
        public Guid RequestAttachmentId { get; set; }
        public Guid PaymentRequestId { get; set; }
        public byte[] Attachment { get; set; }
        public string FileExt { get; set; }
        public PaymentRequest PaymentRequest { get; set; }
    }
}
