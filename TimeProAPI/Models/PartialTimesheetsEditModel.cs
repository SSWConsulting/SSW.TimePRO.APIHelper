namespace SSW.TimeProAPI.Models
{
    public class PartialTimesheetsEditModel
    {
        public int TimeID { get; set; }
        public int InvoiceID { get; set; }
        public string BillableID { get; set; }
        public string Note { get; set; }
        public string Action { get; set; }
    }
}
