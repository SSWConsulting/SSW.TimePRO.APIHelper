namespace SSW.TimeProAPI.Models
{
    public class UnallocatedTimesheetModel
    {

        public virtual string EmpID
        {
            get;
            set;
        }
        public virtual string ClientID
        {
            get;
            set;
        }
        public virtual string CoName
        {
            get;
            set;
        }
        public virtual string FirstName
        {
            get;
            set;
        }
        public virtual string Surname
        {
            get;
            set;
        }
        public virtual string SumOfOSAmt
        {
            get;
            set;
        }

        public virtual string BAmt
        {
            get;
            set;
        }

        public virtual string WAmt
        {
            get;
            set;
        }

        public virtual string BPPAmt
        {
            get;
            set;
        }
    }
}