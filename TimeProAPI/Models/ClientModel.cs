using System;

namespace SSW.TimeProAPI.Models
{
    public class ClientModel
    {
        #region Primitive Properties

        public virtual string ClientID
        {
            get; 
            set;
        }
        public virtual string EmpID
        {
            get;
            set;
        }
        public virtual string CoName
        {
            get;
            set;
        }

        public virtual string Salutation
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

        public virtual string Position
        {
            get;
            set;
        }

        public virtual string Address
        {
            get;
            set;
        }

        public virtual string Suburb
        {
            get;
            set;
        }

        public virtual string State
        {
            get;
            set;
        }

        public virtual string Postcode
        {
            get;
            set;
        }

        public virtual string Country
        {
            get;
            set;
        }

        public virtual string PAddress
        {
            get;
            set;
        }

        public virtual string PSuburb
        {
            get;
            set;
        }

        public virtual string PState
        {
            get;
            set;
        }

        public virtual string PPostcode
        {
            get;
            set;
        }

        public virtual string PCountry
        {
            get;
            set;
        }

        public virtual string Industry
        {
            get;
            set;
        }


        public virtual string ReferredBy
        {
            get;
            set;
        }




        public virtual Nullable<decimal> CreditLimit
        {
            get;
            set;
        }

        public virtual string PaymentMethodID
        {
            get;
            set;
        }

        public virtual string CreditCardName
        {
            get;
            set;
        }

        public virtual string CreditCardNo
        {
            get;
            set;
        }

        public virtual string CreditCardPIN
        {
            get;
            set;
        }

        public virtual string CreditCardExpiry
        {
            get;
            set;
        }

        public virtual string Drawer
        {
            get;
            set;
        }

        public virtual string Bank
        {
            get;
            set;
        }

        public virtual string Branch
        {
            get;
            set;
        }

        public virtual Nullable<decimal> SumOfInvoice
        {
            get;
            set;
        }

        public virtual Nullable<decimal> SumOfReceipt
        {
            get;
            set;
        }

        public virtual Nullable<decimal> SumOfOSAmt
        {
            get;
            set;
        }

        public virtual Nullable<decimal> DebtorMth1
        {
            get;
            set;
        }

        public virtual Nullable<decimal> DebtorMth2
        {
            get;
            set;
        }

        public virtual Nullable<decimal> DebtorMth3
        {
            get;
            set;
        }

        public virtual Nullable<decimal> YTDInvoice
        {
            get;
            set;
        }

        public virtual Nullable<decimal> LYInvoice
        {
            get;
            set;
        }

        public virtual string Rating
        {
            get;
            set;
        }

        public virtual Nullable<System.DateTime> DateCreated
        {
            get;
            set;
        }

        public virtual Nullable<System.DateTime> DateUpdated
        {
            get;
            set;
        }

        public virtual string EmpUpdated
        {
            get;
            set;
        }

        public virtual string Note
        {
            get;
            set;
        }

        public virtual Nullable<System.DateTime> DateLastContacted
        {
            get;
            set;
        }

        public virtual Nullable<decimal> WIPToBeWOff
        {
            get;
            set;
        }

        public virtual Nullable<decimal> WIPToBeInvoiced
        {
            get;
            set;
        }

        public virtual Nullable<decimal> TotalTimeInvoiced
        {
            get;
            set;
        }

        public virtual Nullable<decimal> TotalTimeWOff
        {
            get;
            set;
        }

        public virtual Nullable<double> TotalInvoicedPCT
        {
            get;
            set;
        }

        public virtual Nullable<decimal> YTDTimeInvoiced
        {
            get;
            set;
        }

        public virtual Nullable<decimal> YTDTimeWOff
        {
            get;
            set;
        }

        public virtual Nullable<double> YTDInvoicedPct
        {
            get;
            set;
        }

        public virtual Nullable<decimal> LifetimeValue
        {
            get;
            set;
        }


        public virtual System.Guid rowguid
        {
            get;
            set;
        }

        public virtual string www
        {
            get;
            set;
        }

        public virtual Nullable<int> AddressDP
        {
            get;
            set;
        }

        public virtual Nullable<int> PAddressDP
        {
            get;
            set;
        }

        public virtual Nullable<decimal> RatingAmt
        {
            get;
            set;
        }

        public virtual short zzHoldBilling
        {
            get;
            set;
        }

        public virtual short zzHoldReminders
        {
            get;
            set;
        }

        public virtual short zzHouseHold
        {
            get;
            set;
        }

        public virtual short HoldBilling
        {
            get;
            set;
        }

        public virtual short HoldReminders
        {
            get;
            set;
        }

        public virtual short HouseHold
        {
            get;
            set;
        }

        public virtual string Email
        {
            get;
            set;
        }

        public virtual string Phone
        {
            get;
            set;
        }

        public virtual string Fax
        {
            get;
            set;
        }

        public virtual Nullable<short> EmployeeCount
        {
            get;
            set;
        }

        public virtual string crm_VersionNumber
        {
            get;
            set;
        }

        public virtual int PaymentTerms
        {
            get;
            set;
        }

        public virtual short AutoInvoicing
        {
            get;
            set;
        }

        public virtual short PrepaidInvoicing
        {
            get;
            set;
        }

        public virtual Nullable<System.Guid> CRMClientGUID
        {
            get;
            set;
        }


        public virtual string ClientLogoUrl
        {
            get;
            set;
        }

        public virtual byte[] ClientLogo { get; set; }
        public virtual string CategoryID
        {
            get { return _categoryID; }
            set
            {
                _categoryID = value;
            }
        }
        private string _categoryID;
        #endregion
    }
}
