using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSW.TimeProAPI.Models
{
    public class InvoiceProductsModel
    {


        public int InvoiceID { get; set; }

        public string CategoryID { get; set; }

        public string InvoiceType { get; set; }

        public int Batch { get; set; }
        /// <summary>
        ///Required Field 
        /// </summary>
        public string ClientID { get; set; }

        public string ProjectID { get; set; }

        public string DeliveryID { get; set; }

        public string ClientRef { get; set; }

        public DateTime? DateStart { get; set; }

        public DateTime? DateEnd { get; set; }

        public decimal? SubTotal { get; set; }

        public decimal? SellTotal { get; set; }

        public double? SalesTaxPct { get; set; }

        public decimal? SalesTaxAmt { get; set; }

        public decimal? CostTotal { get; set; }

        public decimal? Margin { get; set; }

        public double? MarginPct { get; set; }

        public decimal? SumOfWrittenOff { get; set; }

        public decimal? TotalMargin { get; set; }

        public double? TotalMarginPct { get; set; }

        public decimal? PaidAmt { get; set; }

        public decimal? OSAmt { get; set; }

        public short? ReminderStatus { get; set; }

        public string ExportID { get; set; }

        public string ClientInvoiceProducts { get; set; }
        /// <summary>
        ///Non-Required Field 
        /// </summary>
        public DateTime? DateCreated { get; set; }
        /// <summary>
        ///Non-Required Field 
        /// </summary>
        public DateTime? DateUpdated { get; set; }

        public string EmpUpdated { get; set; }

        public string Note { get; set; }

        public string Month { get; set; }

        public short? CollectionDays { get; set; }
        /// <summary>
        ///Non-Required Field 
        /// </summary>
        public Guid rowguid { get; set; }

        public DateTime SSWTimeStamp { get; set; }

        public string NoteInternal { get; set; }

        public string NoteValidation { get; set; }

        public DateTime? DatePromisedToPay { get; set; }

        public int ReminderSentCount { get; set; }

        public int ReminderTypeLastSent { get; set; }

        public short zzNeedRefresh { get; set; }

        public short NeedRefresh { get; set; }



    }
}
