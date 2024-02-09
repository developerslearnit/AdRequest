using System;

namespace AdmonRequest.Domain.Entities
{
    public partial class PersonAdditionalInfo
    {
        public Guid PersonAdditionalInfoId { get; set; }
        public Guid PersonRegistrationId { get; set; }
        public string TitleName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string OtherDetails { get; set; }
        public PersonRegistration PersonRegistration { get; set; }
        public PersonAdditionalInfoType PersonAdditionalInfoType { get; set; }
    }


    public enum PersonAdditionalInfoType
    {
        NextofKin,
        Reference,
        AboutCompany
    }
}
