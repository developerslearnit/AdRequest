using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace AdmonRequest.Domain.Entities
{
    public partial class PersonRegistration : BaseEntity
    {
        public Guid PersonRegistrationId { get; set; }
        public string PersonRegistrationNo { get; set; }
        public string PersonName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public byte[] Pictures { get; set; }
        public string Address { get; set; }
        public DateTime RegisterDate { get; set; }
        public string? Gender { get; set; }
        public string? Nationality { get; set; }
        public string? ContactPerson { get; set; }
        public string State { get; set; }
        public string LGA { get; set; }
        public PersonType PersonType { get; set; }
        public PreferCommunication PreferCommunication { get; set; }
        public string? AccountName { get; set; }

        public string? BankName { get; set; }
        public string? AccountNo { get; set; }

    }

    public enum PersonType
    {
        Agent,
        Subcriber,
        Customer,
        Supplier,
        Staff
    }
    public enum PreferCommunication
    {
        Email,
        Phone,
        WhatApps,
        SMS
    }
   
}

