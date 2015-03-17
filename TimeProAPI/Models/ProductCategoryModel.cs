using System;

namespace SSW.TimeProAPI.Models
{
    public class ProductCategoryModel
    {

        public string CategoryID { get; set; }

        public string CategoryName { get; set; }

        public int? Color { get; set; }

        public string Image { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        public string EmpUpdated { get; set; }

        public string Note { get; set; }

        public Guid rowguid { get; set; }

        //public DateTime SSWTimeStamp { get; set; }

        public int? Sort { get; set; }

        public string Head { get; set; }

        public string URL { get; set; }

        public string Email { get; set; }

        public short zzDisplayOnWeb { get; set; }

        public short DisplayOnWeb { get; set; }

        public string SysRequirements { get; set; }

        public bool? IsPopular { get; set; }

        public bool AllowDiscount { get; set; }

        public bool AllowDiscount2 { get; set; }

        public Guid msrepl_tran_version { get; set; }

        public bool isTraining { get; set; }

    }
}