using System;

namespace SSW.TimeProAPI.Models
{
    public class TimesheetModel
    {

        public string ClientID { get; set; }

        public int TimeID { get; set; }

        public DateTime? DateCreated { get; set; }

        public string EmpID { get; set; }

        public int InvoiceID { get; set; }

        public string ProjectID { get; set; }

        public string CategoryID { get; set; }

        public DateTime? TimeStart { get; set; }

        public DateTime? TimeEnd { get; set; }

        public decimal? TimeLess { get; set; }

        public decimal? TimeTotal { get; set; }

        public decimal? TimeBillable { get; set; }

        public string BillableID { get; set; }

        public decimal? SellPrice { get; set; }

        public decimal? SellTotal { get; set; }

        public DateTime? DateUpdated { get; set; }

        public string EmpUpdated { get; set; }

        public string Note { get; set; }

        public decimal? SalesTaxAmt { get; set; }

        public double? SalesTaxPct { get; set; }

        public Guid rowguid { get; set; }

        //public DateTime SSWTimeStamp { get; set; }

        public string Location { get; set; }

        public decimal? TimeTotalComputed { get; set; }

        public decimal? SellTotalComputed { get; set; }

        public decimal? SalesTaxAmtComputed { get; set; }

        public string EmpCreated { get; set; }

        public int IterationId { get; set; }

        public string LocationID { get; set; }

        public string ConfirmedBy { get; set; }

        public DateTime? ConfirmedDate { get; set; }

        public bool IsBillingTypeOverridden { get; set; }

        public decimal? TimeBillableComputed { get; set; }

        public bool IsAutomaticComments { get; set; }

        public string TfsComments { get; set; }


    }
}
