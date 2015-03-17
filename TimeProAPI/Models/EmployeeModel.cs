using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSW.TimeProAPI.Models
{
    public class EmployeeModel
    {

        public string EmpID { get; set; }

        public string Surname { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string Position { get; set; }

        public string CategoryID { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Address { get; set; }

        public string Suburb { get; set; }

        public string State { get; set; }

        public string Postcode { get; set; }

        public string PAddress { get; set; }

        public string PSuburb { get; set; }

        public string PState { get; set; }

        public string PPostcode { get; set; }

        public string PhoneW { get; set; }

        public string FaxW { get; set; }

        public string PhoneH { get; set; }

        public string FaxH { get; set; }

        public string PhoneOther { get; set; }

        public string Email { get; set; }

        public byte[] EmpSignature { get; set; }

        public decimal? DefaultRate { get; set; }

        public string Security { get; set; }

        public DateTime? DateEnd { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        public string EmpUpdated { get; set; }

        public string Note { get; set; }

        //public string Pwd { get; set; }

        public Guid rowguid { get; set; }

        //public SSWTimeStamp SSWTimeStamp { get; set; }

        public string AccountName { get; set; }

        public string AccountNo { get; set; }

        public string BSB { get; set; }

        public string Bank { get; set; }

        public string Branch { get; set; }

        public string SuperAccountName { get; set; }

        public string SuperAccountNo { get; set; }

        public string SuperBSB { get; set; }

        public string SuperBank { get; set; }

        public string SuperBranch { get; set; }

        public string WorkHours { get; set; }

        public bool? HasJoinedThisMonth { get; set; }

        public Guid? CRMUserGUID { get; set; }

        public string LiveID { get; set; }

        public bool IsEnabled { get; set; }

        //public string PwdVerificationToken { get; set; }

        //public DateTime? PwdVerificationTokenSent { get; set; }

        //public string PwdHash { get; set; }

        public string TimezoneId { get; set; }

        public bool? EnableGamification { get; set; }

        //public string CurrentKey { get; set; }



    }
}
