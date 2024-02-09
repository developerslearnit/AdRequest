using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmonRequest.Application.Models
{
    public class PersonRegistrationModel
    {
        public Guid PersonRegistrationId { get; set; }
        public string PersonRegistrationNo { get; set; }
        public string PersonName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
         public byte[] Pictures { get; set; }
        public DateTime RegisterDate { get; set; }
        public string? Gender { get; set; }
        public string? Nationality { get; set; }
        public string? ContactPerson { get; set; }
        public string State { get; set; }
        public string LGA { get; set; }
       
       // public PreferCommunication PreferCommunication { get; set; }
        public string? AccountName { get; set; }

        public string? BankName { get; set; }
        public string? AccountNo { get; set; }

        public Guid PersonAdditionalInfoId { get; set; }
        public string AdditionalInfoTitleName { get; set; }
        public string AdditionalInfoEmail { get; set; }
        public string AdditionalInfoPhone { get; set; }
        public string AdditionalInfoAddress { get; set; }
        public string OtherDetails { get; set; }

    }
}
