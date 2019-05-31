using System.Collections.Generic;

namespace checkit.api.Models.Quickbook_Models
{
    public class VendorRefObj
    {
        public string value {get; set;}
    }
    public class AccountRefObj
    {
        public string value {get; set;}
    }

    public class AccountBasedExpenseLineDetailObj
    {
        public AccountRefObj AccountRef {get; set;}
    }
    
    public class LineObj_Bill
    {
        public float Amount {get; set;}
        public string DetailType = "AccountBasedExpenseLineDetail";
        public AccountBasedExpenseLineDetailObj AccountBasedExpenseLineDetail {get; set;}
    }

    public class QB_Bill
    {
        public List<LineObj_Bill> Line {get; set;}
        public VendorRefObj CustomerRef {get; set;}
    }
}