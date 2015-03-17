using System;

namespace SSW.TimeProAPI.Models
{
    public class CurrencyModel
    {
        public string CurrencyID { get; set; }

        public string CurrencyName { get; set; }

        public decimal? SellRate { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public string EmpUpdated { get; set; }

        public Guid? rowguid { get; set; }

        public Guid msrepl_tran_version { get; set; }

    }
}
