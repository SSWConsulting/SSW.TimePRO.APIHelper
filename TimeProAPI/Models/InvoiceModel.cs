using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SSW.TimeProAPI.Models;

namespace SSW.TimeProAPI.Models
{
    public class InvoiceModel
    {
        public ClientInvoiceModel ClientInvoice { get; set; }
        public List<ClientInvoiceProductModel> ClientInvoiceProducts { get; set; }
        public List<PartialTimesheetsModel> Timesheets { get; set; }}
}
