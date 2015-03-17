using System;

namespace SSW.TimeProAPI.Models
{
    public class CountryModel
    {
        public string CountryID { get; set; }

        public string Country { get; set; }

        public string RegionID { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        public string EmpUpdated { get; set; }

    }

}