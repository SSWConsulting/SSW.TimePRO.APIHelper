using System;

namespace SSW.TimeProAPI.Models
{
    public class InvoiceJoinedClientModel
    {
        public int InvoiceID { get; set; }
        public string InvoiceType { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string ClientID { get; set; }
        public string CoName { get; set; }
        public decimal? SellTotal { get; set; }
        public decimal? PaidAmt { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
    }


}
