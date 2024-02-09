using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmonRequest.Application.Constants
{
    public static class AppConstants
    {
        public static class ApprovalStatus
        {
            public const string APPROVED = "68B46CC6-9670-4C6C-9827-DEE5E97D6161";
            public const string PENDING = "3816D8A5-ECD1-4E74-A33F-85E33B09A676";
            public const string REJECTED = "79AF5092-42FC-4C68-B0D5-7FE40D541A37";
        }

        public static class UserRoles
        {
            public const string MANAGEMENTSTAFF = "Management";
            public const string STAFF = "Staff";
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
        public enum PersonAdditionalInfoType
        {
            NextofKin,
            Reference,
            AboutCompany
        }
    }
}

//{79AF5092-42FC-4C68-B0D5-7FE40D541A37}
