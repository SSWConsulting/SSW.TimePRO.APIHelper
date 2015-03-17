using System;

namespace SSW.TimeProAPI.Models
{
    public class ProjectModel
    {
        public string ProjectID { get; set; }

        public string ClientID { get; set; }

        public int? ContactID { get; set; }

        public string ProjectName { get; set; }

        public double? StatusPct { get; set; }

        public string EmpID { get; set; }

        public DateTime? QuotedStartDate { get; set; }

        public DateTime? QuotedEndDate { get; set; }

        public DateTime? ActualStartDate { get; set; }

        public DateTime? ActualEndDate { get; set; }

        public float? QuotedHrs { get; set; }

        public decimal? QuotedAmt { get; set; }

        public float? ActualHrs { get; set; }

        public decimal? ActualAmt { get; set; }

        public string CategoryID { get; set; }

        public string Address { get; set; }

        public string Suburb { get; set; }

        public string State { get; set; }

        public string Postcode { get; set; }

        public string Country { get; set; }

        public string Period { get; set; }

        public string DebtorID { get; set; }

        public int? DebtorContactID { get; set; }

        public string TypeID { get; set; }

        public short? BudgetEng { get; set; }

        public short? BudgetDraf { get; set; }

        public decimal? ActualAmtInvoiced { get; set; }

        public decimal? zzAmtLastInvoiced { get; set; }

        public DateTime? zzDateLastInvoiced { get; set; }

        public string ProjectFeeID { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        public string EmpUpdated { get; set; }

        public string Note { get; set; }

        public Guid rowguid { get; set; }

        //public DateTime SSWTimeStamp { get; set; }

        public decimal? ProjectCost { get; set; }

        public decimal? ProjectRate { get; set; }

        public float? AuthorizedHours { get; set; }

        public float? AuthorizedAmt { get; set; }

        public string TFSProjectName { get; set; }

        public string SharePointURL { get; set; }

        public string TFSURL { get; set; }

        public Guid? CRMProjectGUID { get; set; }

        public string ScrumMaster { get; set; }

        public string Technologies { get; set; }

    }

}
