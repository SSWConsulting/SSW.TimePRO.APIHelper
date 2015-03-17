using System;

namespace SSW.TimeProAPI.Models
{
    public class AccountModel
    {
        public string AccountID { get; set; }

        public string AccountName { get; set; }

        public string CategoryID { get; set; }

        public string Note { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        public string EmpUpdated { get; set; }

        public Guid rowguid { get; set; }

        //public DateTime SSWTimeStamp { get; set; }

    }
}
