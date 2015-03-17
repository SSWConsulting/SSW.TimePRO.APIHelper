using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSW.TimeProAPI.Models
{
    public class PartialTimesheetsModel
    {
        public int TimeID { get; set; }
        public int InvoiceID { get; set; }
        public string BillableID { get; set; }
        public string Note { get; set; }
    }
}
