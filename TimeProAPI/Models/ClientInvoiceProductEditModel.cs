using System;

namespace SSW.TimeProAPI.Models
{
    public class ClientInvoiceProductEditModel
    {
        public int InvoiceProdID { get; set; }

        public int InvoiceID { get; set; }

        public string CategoryID { get; set; }

        public string ProdID { get; set; }

        public string EmpID { get; set; }

        public decimal? SellAmt { get; set; }

        public decimal? SellTotal { get; set; }

        public string AccountID { get; set; }

        public DateTime? DateStart { get; set; }

        public DateTime? DateEnd { get; set; }

        public double? SalesTaxPct { get; set; }

        public decimal? CostTotal { get; set; }

        public double? MarginPct { get; set; }

        public decimal? Margin { get; set; }

        public string NoteInternal { get; set; }

        public string Note { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        public string EmpUpdated { get; set; }

        public double? Qty { get; set; }

        public decimal? SalesTaxAmt { get; set; }

        public Guid rowguid { get; set; }

        //public DateTime SSWTimeStamp { get; set; }

        public short zzShow { get; set; }

        public short Show { get; set; }

        public string Action { get; set; }
    }
}
