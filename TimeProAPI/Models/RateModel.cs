using System;

namespace SSW.TimeProAPI.Models
{
    public class RateModel
    {
        public string ClientID { get; set; }

        public string EmpID { get; set; }

        public string CategoryID { get; set; }

        public DateTime? DateEnd { get; set; }

        public decimal? Rate { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        public string EmpUpdated { get; set; }

        public string Note { get; set; }

        public int ClientRateID { get; set; }

        public Guid rowguid { get; set; }

        //public DateTime SSWTimeStamp { get; set; }

        public decimal? PrepaidRate { get; set; }



    }
}
