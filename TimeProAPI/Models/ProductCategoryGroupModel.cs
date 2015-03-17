using System;

namespace SSW.TimeProAPI.Models
{
    public class ProductCategoryGroupModel
    {
        public string GroupID { get; set; }

        public string GroupCategoryID { get; set; }

        //public DateTime SSWTimeStamp { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        public string EmpUpdated { get; set; }

        public Guid rowguid { get; set; }

        public string CategoryID { get; set; }

        public Guid msrepl_tran_version { get; set; }

    }


}