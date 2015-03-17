using System;

namespace SSW.TimeProAPI.Models
{
    public class ClientsWithOutstandingTime : ClientModel
    {
        public ClientsWithOutstandingTime()
            : base()
        {

        }
        public decimal? OutstandingTime { get; set; }
    }
}
