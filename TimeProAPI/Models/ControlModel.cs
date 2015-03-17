using System;

namespace SSW.TimeProAPI.Models
{
    public class ControlModel
    {
        public short ID { get; set; }

        public string CoID { get; set; }

        public string CoName { get; set; }

        public string ACN { get; set; }

        public string Address { get; set; }

        public string Suburb { get; set; }

        public string State { get; set; }

        public string Postcode { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public string Bank { get; set; }

        public string Branch { get; set; }

        public string AccountNo { get; set; }

        public string WWW { get; set; }

        public byte[] Logo { get; set; }

        public string NoteOnInvoice { get; set; }

        public string UserReport { get; set; }

        public string Font { get; set; }

        public string RegNo { get; set; }

        public string Country { get; set; }

        public string Backup { get; set; }

        public DateTime? DateLastBackup { get; set; }

        public DateTime? DateLastRefresh { get; set; }

        public DateTime? DateLastInvalidData { get; set; }

        public string LabelType { get; set; }

        public string SortBy { get; set; }

        public string InvoiceType { get; set; }

        public string DefaultState { get; set; }

        public string WWWPwd { get; set; }

        public string ImagePath { get; set; }

        public DateTime? DateClosedInvoice { get; set; }

        public DateTime? DateClosedReceipt { get; set; }

        public DateTime? DateClosedTimesheet { get; set; }

        public int? FirstReminder { get; set; }

        public int? SecondReminder { get; set; }

        public int? ThirdReminder { get; set; }

        public int? LegalLetter { get; set; }

        public string Month1Name { get; set; }

        public string Month2Name { get; set; }

        public string Month3Name { get; set; }

        public DateTime? Month1EndDate { get; set; }

        public DateTime? Month2EndDate { get; set; }

        public DateTime? Month3EndDate { get; set; }

        public string InternetLogPath { get; set; }

        public string InternetExtraHourProdID { get; set; }

        public string InternetExtraMBProdID { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        public string EmpUpdated { get; set; }

        public string Note { get; set; }

        public string WWWFileName { get; set; }

        public double? SalesTaxPct { get; set; }

        public Guid rowguid { get; set; }

        //public DateTime SSWTimeStamp { get; set; }

        public string SSWTimePROOnline { get; set; }

        public string PathOfNewVersion { get; set; }

        public short zzUpdateMSOutlook { get; set; }

        public short zzLogUpdate { get; set; }

        public short zzLimited { get; set; }

        public short zzInvoicing { get; set; }

        public short zzTimeSheets { get; set; }

        public short zzSaleReceipt { get; set; }

        public short zzInternetServiceProvider { get; set; }

        public short zzProject { get; set; }

        public short UpdateMSOutlook { get; set; }

        public short LogUpdate { get; set; }

        public short Limited { get; set; }

        public short Invoicing { get; set; }

        public short TimeSheets { get; set; }

        public short SaleReceipt { get; set; }

        public short InternetServiceProvider { get; set; }

        public short Project { get; set; }

        public string CCEmailInvoice { get; set; }

        public string BCCEmailInvoice { get; set; }

        public string SQLScriptPath { get; set; }

        public int? FourthReminder { get; set; }

        public bool IsCRMActive { get; set; }

        public string CRMServerUri { get; set; }

    }


}