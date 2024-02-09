using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmonRequest.Application.Models
{
    public class RequestTypeModel
    {
        public Guid RequestTypeId { get; set; }
        public required string Name { get; set; }
        public bool Status { get; set; }
        public bool ReduceBuget { get; set; }
        public bool IsAdvance { get; set; }
        public bool IsProject { get; set; }
        public bool IsDirectPayment { get; set; }

        public string isActive { get { return Status ? "Active" : "Not Active"; } }
        public string reduceBudget { get { return ReduceBuget ? "Yes" : "No"; } }
        public string advance { get { return IsAdvance ? "Yes" : "No"; } }
        public string project { get { return IsProject ? "Yes" : "No"; } }
        public string directPay { get { return IsDirectPayment ? "Yes" : "No"; } }

    }
}
