using System;

namespace SSW.TimeProAPI.Models
{
    public class ProductModel
    {

        public string ProdID { get; set; }

        public string ProdName { get; set; }

        public string CategoryID { get; set; }

        public string AccountID { get; set; }

        public string Unit { get; set; }

        public decimal? CostAmt { get; set; }

        public decimal? SellAmt { get; set; }

        public string Image { get; set; }

        public string NoteWWW { get; set; }

        public DateTime? DateEnd { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        public string EmpUpdated { get; set; }

        public string Note { get; set; }

        public Guid rowguid { get; set; }

        public DateTime SSWTimeStamp { get; set; }

        public int Sort { get; set; }

        public short? FirstInvPeriod { get; set; }

        public short? SubsequentInvPeriod { get; set; }

        public string CurrencyID { get; set; }

        public short zzOnSale { get; set; }

        public short zzDisplayOnWeb { get; set; }

        public short OnSale { get; set; }

        public short DisplayOnWeb { get; set; }

        public string SysRequirements { get; set; }

        public bool? IsFeatured { get; set; }

        public string Website { get; set; }

        public Guid msrepl_tran_version { get; set; }

        public DateTime? DateOfEvent { get; set; }

        public bool? RegistrationRequired { get; set; }

        public short FixedPrice { get; set; }

        public short Prepaid { get; set; }


    }
}
