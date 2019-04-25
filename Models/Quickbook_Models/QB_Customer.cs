namespace checkit.api.Models.Quickbook_Models
{
    public class CustBilling
    {
        public string Line1 {get; set;}
        public string City {get; set;}
        public string Country {get; set;}
        public string CountrySubDivisionCode {get; set;}
        public string PostalCode {get; set;}
    }

    public class CustPhone
    {
        public string FreeFormNumber {get; set;}
    }

    public class CustEmailAddr
    {
        public string Address {get; set;}
    }

    public class QB_Customer
    {
        public CustBilling BillAddr {get; set;}
        public string Notes {get; set;}
        public string DisplayName {get; set;}
        public CustPhone PrimaryPhone {get; set;}
        public CustEmailAddr PrimaryEmailAddr {get; set;}
        
    }
}