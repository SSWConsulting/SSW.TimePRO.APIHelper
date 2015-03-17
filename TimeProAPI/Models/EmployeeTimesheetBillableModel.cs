using System;

namespace SSW.TimeProAPI.Models
{
    public class EmployeeTimesheetBillableModel
    {
        public string CategoryID { get; set; }

        public string CategoryName { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        public string EmpUpdated { get; set; }

        public string Note { get; set; }

        public Guid rowguid { get; set; }

        public DateTime SSWTimeStamp { get; set; }

        public string Colour { get; set; }
    }
}