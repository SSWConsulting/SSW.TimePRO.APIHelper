using System.Collections.Generic;

namespace SSW.TimeProAPI.Models
{
    public class InvoiceEditModel
    {
        public ClientInvoiceEditModel ClientInvoice { get; set; }
        public List<ClientInvoiceProductEditModel> ClientInvoiceProducts { get; set; }
        public List<PartialTimesheetsEditModel> Timesheets { get; set; }
    }
}
