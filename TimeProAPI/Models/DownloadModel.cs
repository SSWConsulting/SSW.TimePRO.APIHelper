using System;

namespace SSW.TimeProAPI.Models
{
    public class DownloadModel
{
    public string DownloadID { get; set; }

    public string FileNameURL { get; set; }

    public string FileNameTxt { get; set; }

    public string FileSize { get; set; }

    public string ProdID { get; set; }

    public Guid rowguid { get; set; }

    public string ProdCategoryID { get; set; }

    public string ProdName { get; set; }

    public string Description { get; set; }

    //public DateTime SSWTimeStamp { get; set; }

    public int? Sort { get; set; }

    public short Display { get; set; }

    public DateTime? DateUpdated { get; set; }

    public string EmpUpdated { get; set; }

    public DateTime DataCreated { get; set; }

    public decimal? ProdVersion { get; set; }

    public bool? FollowupRequired { get; set; }

    public string MainExeName { get; set; }

    public string UpdateUrl { get; set; }

    public Guid msrepl_tran_version { get; set; }

    public bool? IsClickOnce { get; set; }

}

}

