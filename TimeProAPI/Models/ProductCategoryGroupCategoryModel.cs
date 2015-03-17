using System;

namespace SSW.TimeProAPI.Models
{
    public class ProductCategoryGroupCategoryModel
    {
        public string CategoryID { get; set; }

        public string CategoryName { get; set; }

        //public DateTime SSWTimeStamp { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        public string EmpUpdated { get; set; }

        public Guid rowguid { get; set; }

        public int? SortOrder { get; set; }

        public string Image { get; set; }

        public string ImageMedium { get; set; }

        public string WebSite { get; set; }

        public Guid msrepl_tran_version { get; set; }

    }




}